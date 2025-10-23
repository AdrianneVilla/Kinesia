using Astra;
using Astra.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kinesia.Offline
{
    public partial class AssessmentROMOffline : Form
    {
        // Enums for managing state
        private enum BodySide { None, Right, Left }
        private enum JointType { None, Shoulder, Elbow }
        private enum MovementType { None, Flexion, Extension }
        private enum MeasurementState { Idle, Measuring, Paused }

        // Current state variables
        private MeasurementState _currentState = MeasurementState.Idle;
        private BodySide _currentSide = BodySide.None;
        private JointType _currentJoint = JointType.None;
        private MovementType _currentMovement = MovementType.None;

        // ROM measurement variables
        private double _initialAngle = 0;
        private double _endAngle = 0;
        private double _lastLiveAngle = 0;
        private bool _lastAngleWasValid = false;
        private Color _lastConfidenceColor = Color.Red;
        private string _initialConfidence = "N/A";
        private string _endConfidence = "N/A";


        // 3D Point Structure
        private struct Point3D
        {
            public float X, Y, Z;
            public override string ToString() => $"({X:F2}, {Y:F2}, {Z:F2}m)";
        }

        // Astra SDK components
        private StreamSet _streamSet;
        private Astra.StreamReader _reader;
        private ColorStream _colorStream;
        private DepthStream _depthStream;
        private System.Windows.Forms.Timer _sdkTimer;

        // Data buffers
        private byte[] _colorBuffer;
        private short[] _depthBuffer;

        // MoveNet components
        private MoveNet _moveNet;
        private string _modelPath;
        private const string ModelFileName = "model.onnx";

        // Smoothing and filtering components
        private PointF[] _smoothedJoints;
        private int MovingAverageWindowSize = 5;
        private readonly Queue<double> _angleHistory = new Queue<double>();
        private readonly Queue<Point3D[]> _jointHistory3D = new Queue<Point3D[]>();
        private Point3D[] _lastGood3DJoints;
        private const int OcclusionGracePeriod = 5;
        private int[] _jointOcclusionCounters = new int[3];

        // GDI+ drawing resources
        private Font _font;
        private SolidBrush _fontBrush;
        private SolidBrush _backBrush;
        private SolidBrush _jointBrush;
        private Pen _bonePen;

        public AssessmentROMOffline()
        {
            InitializeComponent();
            this.Load += AssessmentROM_Load;
            this.FormClosing += AssessmentROM_FormClosing;
            _modelPath = Path.Combine(Application.StartupPath, "models", ModelFileName);
        }

        private void AssessmentROM_Load(object sender, EventArgs e)
        {
            // Initialize drawing tools
            _font = new Font("Arial", 10, FontStyle.Bold);
            _fontBrush = new SolidBrush(Color.White);
            _backBrush = new SolidBrush(Color.FromArgb(150, Color.Black));
            _jointBrush = new SolidBrush(Color.White);
            _bonePen = new Pen(Color.Red, 4);

            SetupSideSelection();

            // Initialize MoveNet
            if (File.Exists(_modelPath))
            {
                try { _moveNet = new MoveNet(_modelPath); }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load MoveNet model: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); return;
                }
            }
            else
            {
                MessageBox.Show($"Model file not found at: {_modelPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }

            // Initialize Astra SDK
            Context.Initialize();
            _streamSet = StreamSet.Open();
            _reader = _streamSet.CreateReader();
            _colorStream = _reader.GetStream<ColorStream>();
            _depthStream = _reader.GetStream<DepthStream>();
            _colorStream.Start();
            _depthStream.Start();

            // Start the main processing timer
            _sdkTimer = new System.Windows.Forms.Timer { Interval = 33 };
            _sdkTimer.Tick += SdkTimer_Tick;
            _sdkTimer.Start();
        }

        #region ComboBox Setup and Event Handlers

        private void SetupSideSelection()
        {
            cmbLimbSelection.Items.Clear();
            cmbLimbSelection.Items.Add("Select a side");
            cmbLimbSelection.Items.Add("Right");
            cmbLimbSelection.Items.Add("Left");
            cmbLimbSelection.SelectedIndex = 0;

            cmbJointSelection.Enabled = false;
            cmbMovementSelection.Enabled = false;
            cmbJointSelection.Items.Add("Select a side first");
            cmbMovementSelection.Items.Add("Select a joint first");
            cmbJointSelection.SelectedIndex = 0;
            cmbMovementSelection.SelectedIndex = 0;
        }

        private void cmbLimbSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLimbSelection.SelectedIndex > 0)
            {
                _currentSide = (BodySide)cmbLimbSelection.SelectedIndex;
                cmbJointSelection.Enabled = true;
                cmbJointSelection.Items.Clear();
                cmbJointSelection.Items.Add("Select a joint");
                cmbJointSelection.Items.Add("Shoulder");
                cmbJointSelection.Items.Add("Elbow");
                cmbJointSelection.SelectedIndex = 0;
            }
            else
            {
                _currentSide = BodySide.None;
                cmbJointSelection.Enabled = false;
                cmbJointSelection.Items.Clear();
                cmbJointSelection.Items.Add("Select a side first");
                cmbJointSelection.SelectedIndex = 0;
            }
            ResetMovementSelection(false, "Select a joint first");
            ResetMeasurementState();
        }

        private void cmbJointSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJointSelection.SelectedIndex > 0)
            {
                _currentJoint = (JointType)cmbJointSelection.SelectedIndex;
                cmbMovementSelection.Enabled = true;
                cmbMovementSelection.Items.Clear();
                cmbMovementSelection.Items.Add("Select a movement type");

                switch (_currentJoint)
                {
                    case JointType.Shoulder:
                        cmbMovementSelection.Items.Add("Flexion");
                        cmbMovementSelection.Items.Add("Extension");
                        break;
                    case JointType.Elbow:
                        cmbMovementSelection.Items.Add("Flexion");
                        break;
                }
                cmbMovementSelection.SelectedIndex = 0;
            }
            else
            {
                _currentJoint = JointType.None;
                ResetMovementSelection(false, "Select a joint first");
            }
            ResetMeasurementState();
        }

        private void cmbMovementSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovementSelection.SelectedIndex > 0)
            {
                string selection = cmbMovementSelection.SelectedItem.ToString();
                if (Enum.TryParse(selection, out MovementType movement))
                {
                    _currentMovement = movement;
                }
            }
            else
            {
                _currentMovement = MovementType.None;
            }
            ResetMeasurementState();
        }

        private void ResetMovementSelection(bool enabled, string placeholder)
        {
            _currentMovement = MovementType.None;
            cmbMovementSelection.Enabled = enabled;
            cmbMovementSelection.Items.Clear();
            cmbMovementSelection.Items.Add(placeholder);
            cmbMovementSelection.SelectedIndex = 0;
        }

        #endregion

        private void SdkTimer_Tick(object sender, EventArgs e)
        {
            if (_currentState == MeasurementState.Paused || _currentMovement == MovementType.None) return;

            Context.Update();

            if (!_reader.TryOpenFrame(0, out var frame)) return;

            try
            {
                var cf = frame.GetFrame<ColorFrame>();
                var df = frame.GetFrame<DepthFrame>();

                if (cf != null && cf.Width > 0 && cf.DataPtr != IntPtr.Zero)
                {
                    int colorLength = cf.Width * cf.Height * 3;
                    if (_colorBuffer == null || _colorBuffer.Length != colorLength)
                        _colorBuffer = new byte[colorLength];
                    cf.CopyData(ref _colorBuffer);

                    for (int i = 0; i < _colorBuffer.Length; i += 3)
                    {
                        byte temp = _colorBuffer[i];
                        _colorBuffer[i] = _colorBuffer[i + 2];
                        _colorBuffer[i + 2] = temp;
                    }

                    var keypointsTensor = _moveNet.RunInference(_colorBuffer, cf.Width, cf.Height);
                    var rawJoints = _moveNet.ExtractKeypoints(keypointsTensor, cf.Width, cf.Height);
                    _smoothedJoints = SmoothJoints(rawJoints, 0.5f);

                    Point3D[] smoothedLimb3D = null;

                    if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero)
                    {
                        int depthCount = df.Width * df.Height;
                        if (_depthBuffer == null || _depthBuffer.Length != depthCount)
                            _depthBuffer = new short[depthCount];

                        df.CopyData(ref _depthBuffer);
                        MedianFilter(_depthBuffer, df.Width, df.Height);

                        var rawLimb3D = GetLimb3DPose(_smoothedJoints, _depthBuffer, df.Width, df.Height, cf.Width, cf.Height);
                        smoothedLimb3D = Smooth3DJointsMovingAverage(rawLimb3D);

                        if (smoothedLimb3D != null && smoothedLimb3D.Length == 3)
                        {
                            double limbAngle = CalculateAngle3D(smoothedLimb3D[0], smoothedLimb3D[1], smoothedLimb3D[2]);
                            _lastLiveAngle = SmoothAngleMovingAverage(limbAngle);
                            _lastAngleWasValid = limbAngle >= 0;
                        }
                        else
                        {
                            _lastAngleWasValid = false;
                        }
                    }

                    RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, _smoothedJoints, smoothedLimb3D);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during frame processing: {ex.ToString()}");
            }
            finally
            {
                frame.Dispose();
            }
        }

        private void btnStartStopMeasurement_Click(object sender, EventArgs e)
        {
            switch (_currentState)
            {
                case MeasurementState.Idle:
                    if (_currentMovement == MovementType.None)
                    {
                        MessageBox.Show("Please select a side, joint, and movement type first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_lastAngleWasValid)
                    {
                        _initialAngle = _lastLiveAngle;
                        _initialConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblInitialROM.Text = $"Initial: {_initialAngle:F1}° ({_initialConfidence})";
                        lblEndROM.Text = "End:";
                        btnStartStopMeasurement.Text = "Stop Measurement";
                        _currentState = MeasurementState.Measuring;
                    }
                    else
                    {
                        MessageBox.Show("Cannot start measurement. A required joint is hidden.", "Joint Occluded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MeasurementState.Measuring:
                    if (_lastAngleWasValid)
                    {
                        _endAngle = _lastLiveAngle;
                        _endConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblEndROM.Text = $"End: {_endAngle:F1}° ({_endConfidence})";
                        btnStartStopMeasurement.Text = "New Measurement";
                        _currentState = MeasurementState.Paused;
                    }
                    else
                    {
                        MessageBox.Show("Cannot stop measurement. A required joint is hidden.", "Joint Occluded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MeasurementState.Paused:
                    ResetMeasurementState();
                    break;
            }
        }

        private string GetConfidenceString(Color color)
        {
            if (color == Color.LawnGreen) return "Good";
            if (color == Color.Yellow) return "Fair";
            return "Low";
        }

        private void ResetMeasurementState()
        {
            _currentState = MeasurementState.Idle;
            btnStartStopMeasurement.Text = "Start Measurement";
            lblInitialROM.Text = "Initial:";
            lblEndROM.Text = "End:";
            _initialAngle = 0;
            _endAngle = 0;
            _initialConfidence = "N/A";
            _endConfidence = "N/A";
            ResetSmoothingFilters();
        }

        private int[] GetCalculationIndices()
        {
            bool userSelectedRight = (_currentSide == BodySide.Right);

            switch (_currentJoint)
            {
                case JointType.Elbow:
                    return userSelectedRight ? new[] { 5, 7, 9 } : new[] { 6, 8, 10 };
                case JointType.Shoulder:
                    return userSelectedRight ? new[] { 11, 5, 7 } : new[] { 12, 6, 8 };
            }
            return new int[0];
        }

        private void ResetSmoothingFilters()
        {
            _angleHistory.Clear();
            _jointHistory3D.Clear();
            _lastGood3DJoints = null;
            if (_jointOcclusionCounters != null)
                Array.Clear(_jointOcclusionCounters, 0, _jointOcclusionCounters.Length);
        }

        private void MedianFilter(short[] data, int width, int height)
        {
            var tempData = (short[])data.Clone();
            var window = new List<short>(9);
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    window.Clear();
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            short val = tempData[(y + j) * width + (x + i)];
                            if (val > 0) window.Add(val);
                        }
                    }
                    if (window.Count > 0)
                    {
                        window.Sort();
                        data[y * width + x] = window[window.Count / 2];
                    }
                }
            }
        }

        private double CalculateAngle3D(Point3D p1, Point3D p2, Point3D p3)
        {
            if (p1.Z <= 0 || p2.Z <= 0 || p3.Z <= 0) return -1;

            Point3D vector1 = new Point3D { X = p1.X - p2.X, Y = p1.Y - p2.Y, Z = p1.Z - p2.Z };
            Point3D vector2 = new Point3D { X = p3.X - p2.X, Y = p3.Y - p2.Y, Z = p3.Z - p2.Z };

            double dotProduct = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
            double magnitude1 = Math.Sqrt((vector1.X * vector1.X) + (vector1.Y * vector1.Y) + (vector1.Z * vector1.Z));
            double magnitude2 = Math.Sqrt((vector2.X * vector2.X) + (vector2.Y * vector2.Y) + (vector2.Z * vector2.Z));

            if (magnitude1 == 0 || magnitude2 == 0) return -1;

            double cosTheta = dotProduct / (magnitude1 * magnitude2);
            cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta));
            double angleRad = Math.Acos(cosTheta);
            double interiorAngle = angleRad * (180.0 / Math.PI);

            if (_currentJoint == JointType.Shoulder)
            {
                return interiorAngle;
            }

            return 180.0 - interiorAngle;
        }

        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH)
        {
            int[] limbIndices = GetCalculationIndices();
            if (limbIndices.Length == 0) return null;

            var outPts = new Point3D[limbIndices.Length];
            for (int i = 0; i < limbIndices.Length; i++)
            {
                int idx = limbIndices[i];
                if (idx >= joints2D.Length || joints2D[idx].IsEmpty)
                {
                    outPts[i] = new Point3D { X = 0, Y = 0, Z = 0 };
                    continue;
                }
                PointF p2d = joints2D[idx];
                int dx = (int)(p2d.X * depthW / (float)colorW);
                int dy = (int)(p2d.Y * depthH / (float)colorH);
                dx = Math.Max(0, Math.Min(dx, depthW - 1));
                dy = Math.Max(0, Math.Min(dy, depthH - 1));
                short depthInMm = depthBuffer[dy * depthW + dx];
                float depthInMeters = depthInMm / 1000.0f;
                outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = depthInMeters };
            }
            return outPts;
        }

        private PointF[] SmoothJoints(PointF[] newJoints, float alpha)
        {
            if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length)
            {
                _smoothedJoints = (PointF[])newJoints.Clone();
                return _smoothedJoints;
            }
            for (int i = 0; i < newJoints.Length; i++)
            {
                if (newJoints[i].IsEmpty) continue;
                if (_smoothedJoints[i].IsEmpty)
                {
                    _smoothedJoints[i] = newJoints[i];
                    continue;
                }
                float newX = alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X;
                float newY = alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y;
                _smoothedJoints[i] = new PointF(newX, newY);
            }
            return _smoothedJoints;
        }

        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints)
        {
            if (newJoints == null) return _lastGood3DJoints;

            _jointHistory3D.Enqueue(newJoints);
            while (_jointHistory3D.Count > MovingAverageWindowSize)
            {
                _jointHistory3D.Dequeue();
            }

            if (_jointHistory3D.Count == 0) return _lastGood3DJoints ?? newJoints;

            var averageJoints = new Point3D[newJoints.Length];
            for (int i = 0; i < newJoints.Length; i++)
            {
                float sumX = 0, sumY = 0, sumZ = 0;
                int validCount = 0;
                foreach (var frame in _jointHistory3D)
                {
                    if (frame.Length > i && frame[i].Z > 0)
                    {
                        sumX += frame[i].X;
                        sumY += frame[i].Y;
                        sumZ += frame[i].Z;
                        validCount++;
                    }
                }
                if (validCount > 0)
                {
                    averageJoints[i] = new Point3D { X = sumX / validCount, Y = sumY / validCount, Z = sumZ / validCount };
                }
                else if (_lastGood3DJoints != null && _lastGood3DJoints.Length > i)
                {
                    averageJoints[i] = _lastGood3DJoints[i];
                }
            }
            _lastGood3DJoints = averageJoints;
            return averageJoints;
        }

        private double SmoothAngleMovingAverage(double newAngle)
        {
            if (newAngle >= 0)
            {
                _angleHistory.Enqueue(newAngle);
                while (_angleHistory.Count > MovingAverageWindowSize)
                {
                    _angleHistory.Dequeue();
                }
            }
            if (_angleHistory.Count == 0) return 0;
            return _angleHistory.Average();
        }

        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints, Point3D[] joints3D_smoothed)
        {
            Bitmap bmp = null;
            Bitmap displayBmp = null;
            try
            {
                bmp = new Bitmap(w, h, w * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));
                using (var g = Graphics.FromImage(bmp))
                {
                    DrawLimbPose(g, joints, joints3D_smoothed);
                }
                displayBmp = (Bitmap)bmp.Clone();
                pictureBoxRgb.Invoke((Action)(() =>
                {
                    if (pictureBoxRgb.Image != null)
                        pictureBoxRgb.Image.Dispose();
                    pictureBoxRgb.Image = displayBmp;
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during rendering: {ex.ToString()}");
                displayBmp?.Dispose();
            }
            finally
            {
                bmp?.Dispose();
            }
        }

        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            if (joints2D == null) return;
            int[] activeIndices = GetCalculationIndices();
            if (activeIndices.Length < 3) return;

            const float optimalDepthStart = 0.7f;
            const float optimalDepthEnd = 2.5f;
            const float acceptableMargin = 0.2f;

            Color limbColor = Color.Red;
            if (joints3D_smoothed != null && joints3D_smoothed.Length > 1)
            {
                float middleJointDepth = joints3D_smoothed[1].Z;
                if (middleJointDepth > 0)
                {
                    if (middleJointDepth >= optimalDepthStart && middleJointDepth <= optimalDepthEnd)
                        limbColor = Color.LawnGreen;
                    else if (middleJointDepth >= optimalDepthStart - acceptableMargin && middleJointDepth <= optimalDepthEnd + acceptableMargin)
                        limbColor = Color.Yellow;
                }
                _lastConfidenceColor = limbColor;
                _bonePen.Color = limbColor;

                g.DrawLine(_bonePen, joints2D[activeIndices[0]], joints2D[activeIndices[1]]);
                g.DrawLine(_bonePen, joints2D[activeIndices[1]], joints2D[activeIndices[2]]);

                string depthText = $"Your Distance: {middleJointDepth:F2}m";
                string targetText = $"Good Range: {optimalDepthStart:F2}m - {optimalDepthEnd:F2}m";
                g.FillRectangle(_backBrush, 5, 5, 200, 50);
                g.DrawString(depthText, _font, _fontBrush, new PointF(10, 10));
                g.DrawString(targetText, _font, _fontBrush, new PointF(10, 30));
            }

            for (int i = 0; i < activeIndices.Length; i++)
            {
                int jointIndex = activeIndices[i];
                if (joints2D.Length > jointIndex && !joints2D[jointIndex].IsEmpty)
                {
                    PointF p2d = joints2D[jointIndex];
                    bool isJointVisible = joints3D_smoothed != null && joints3D_smoothed.Length > i && joints3D_smoothed[i].Z > 0;
                    if (isJointVisible) _jointOcclusionCounters[i] = 0;
                    else _jointOcclusionCounters[i]++;

                    Color jointColor = (_jointOcclusionCounters[i] > OcclusionGracePeriod) ? Color.Red : Color.White;
                    _jointBrush.Color = jointColor;
                    g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10);
                }
            }

            if ((_currentState == MeasurementState.Measuring || _currentState == MeasurementState.Paused) && _lastAngleWasValid)
            {
                PointF vertexPoint = joints2D[activeIndices[1]];
                if (!vertexPoint.IsEmpty)
                {
                    double angleToDisplay = (_currentState == MeasurementState.Measuring) ? _lastLiveAngle : _endAngle;
                    string angleText = $"{angleToDisplay:F1}°";
                    SizeF textSize = g.MeasureString(angleText, _font);
                    RectangleF textRect = new RectangleF(vertexPoint.X + 15, vertexPoint.Y - 25, textSize.Width + 10, textSize.Height + 5);
                    g.FillRectangle(_backBrush, textRect);
                    g.DrawString(angleText, _font, _fontBrush, textRect.Location.X + 5, textRect.Location.Y + 2.5f);
                }
            }
        }

        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sdkTimer?.Stop();
            _reader?.Dispose();
            _streamSet?.Dispose();
            _moveNet?.Dispose();
            _font?.Dispose();
            _fontBrush?.Dispose();
            _backBrush?.Dispose();
            _jointBrush?.Dispose();
            _bonePen?.Dispose();
            Context.Terminate();
        }
    }
}