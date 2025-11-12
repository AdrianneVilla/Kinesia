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
using System.Threading.Tasks;
using System.Windows.Forms;
using KinesiaLibrary.DTOs.ROMDTOs;
using KinesiaLibrary;
using System.ServiceModel.Channels; // Added for ROMHelper

namespace Kinesia.Assessment
{

    public partial class AssessmentROM : Form
    {
        // Enums and other fields remain the same...
        private enum BodySide { None, Right, Left }
        private enum JointType { None, Shoulder, Elbow, Hip, Knee }
        private enum MovementType { None, Flexion, Extension }
        private enum MeasurementState { Idle, Measuring, Paused }

        private MeasurementState _currentState = MeasurementState.Idle;
        private BodySide _currentSide = BodySide.None;
        private JointType _currentJoint = JointType.None;
        private MovementType _currentMovement = MovementType.None;
        private string _currentExtremity = "";
        private string _currentJointName = "";

        private double _initialAngle = 0;
        private double _endAngle = 0;
        private double _lastLiveAngle = 0;
        private bool _lastAngleWasValid = false;
        private Color _lastConfidenceColor = Color.Red;
        private string _initialConfidence = "N/A";
        private string _endConfidence = "N/A";

        private struct Point3D { public float X, Y, Z; public override string ToString() => $"({X:F2}, {Y:F2}, {Z:F2}m)"; }

        private StreamSet _streamSet;
        private Astra.StreamReader _reader; // Ensure this uses Astra.StreamReader if ambiguous
        private ColorStream _colorStream;
        private DepthStream _depthStream;
        private System.Windows.Forms.Timer _sdkTimer;

        private byte[] _colorBuffer;
        private short[] _depthBuffer;

        private MoveNet _moveNet;
        private string _modelPath;
        private const string ModelFileName = "model.onnx";

        private PointF[] _smoothedJoints;
        private int MovingAverageWindowSize = 5;
        private readonly Queue<double> _angleHistory = new Queue<double>();
        private readonly Queue<Point3D[]> _jointHistory3D = new Queue<Point3D[]>();
        private Point3D[] _lastGood3DJoints;
        private const int OcclusionGracePeriod = 5;
        private int[] _jointOcclusionCounters = new int[3];

        private Font _font;
        private SolidBrush _fontBrush;
        private SolidBrush _backBrush;
        private SolidBrush _jointBrush;
        private Pen _bonePen;

        private bool _isCameraConnected = true;
        private bool _isClosing = false; // Flag to prevent multiple close attempts

        public AssessmentROM()
        {
            InitializeComponent();
            this.FormClosing += AssessmentROM_FormClosing;
            _modelPath = Path.Combine(Application.StartupPath, "models", ModelFileName);
        }

        private void AssessmentROM_Load(object sender, EventArgs e)
        {
            lblExtremity.Text = PageObjects.assessmentDetails.Extremity;
            lblJoint.Text = PageObjects.assessmentDetails.Joint;
            lblJointSide.Text = PageObjects.assessmentDetails.JointSide;

            _font = new Font("Arial", 10, FontStyle.Bold);
            _fontBrush = new SolidBrush(Color.White);
            _backBrush = new SolidBrush(Color.FromArgb(150, Color.Black));
            _jointBrush = new SolidBrush(Color.White);
            _bonePen = new Pen(Color.Red, 4);

            _currentExtremity = PageObjects.assessmentDetails.Extremity;
            _currentJointName = PageObjects.assessmentDetails.Joint;
            string sideName = PageObjects.assessmentDetails.JointSide;

            _currentSide = sideName.Equals("Right", StringComparison.OrdinalIgnoreCase) ? BodySide.Right :
                             sideName.Equals("Left", StringComparison.OrdinalIgnoreCase) ? BodySide.Left : BodySide.None;

            _currentJoint = _currentJointName.Equals("Shoulder", StringComparison.OrdinalIgnoreCase) ? JointType.Shoulder :
                             _currentJointName.Equals("Elbow and forearm", StringComparison.OrdinalIgnoreCase) ? JointType.Elbow :
                             _currentJointName.Equals("Hip", StringComparison.OrdinalIgnoreCase) ? JointType.Hip :
                             _currentJointName.Equals("Knee", StringComparison.OrdinalIgnoreCase) ? JointType.Knee : JointType.None;

            SetupMovementSelectionBasedOnDetails();

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

            try
            {
                Context.Initialize();
                _streamSet = StreamSet.Open();
                if (!_streamSet.IsAvailable)
                {
                    _isCameraConnected = false;
                    MessageBox.Show("Astra camera not detected. Please check the connection.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Close immediately if not found on load
                    return;
                }

                _reader = _streamSet.CreateReader();
                _colorStream = _reader.GetStream<ColorStream>();
                _depthStream = _reader.GetStream<DepthStream>();
                _colorStream.Start();
                _depthStream.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Astra SDK: {ex.Message}", "SDK Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }

            _sdkTimer = new System.Windows.Forms.Timer { Interval = 33 };
            _sdkTimer.Tick += SdkTimer_Tick;
            _sdkTimer.Start();

            ResetMeasurementState();
        }

        private void SetupMovementSelectionBasedOnDetails()
        {
            cmbMovementSelection.Enabled = false;
            cmbMovementSelection.Items.Clear();
            cmbMovementSelection.Items.Add("Select movement");

            if (_currentJoint != JointType.None)
            {
                cmbMovementSelection.Items.Add("Flexion");
                cmbMovementSelection.Items.Add("Extension");
                cmbMovementSelection.Enabled = true;
            }
            else
            {
                cmbMovementSelection.Items.Clear();
                cmbMovementSelection.Items.Add("Joint not set");
            }
            cmbMovementSelection.SelectedIndex = 0;
            _currentMovement = MovementType.None;
        }

        private void cmbMovementSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovementSelection.SelectedIndex > 0)
            {
                string selection = cmbMovementSelection.SelectedItem.ToString();
                _currentMovement = Enum.TryParse(selection, out MovementType movement) ? movement : MovementType.None;
            }
            else
            {
                _currentMovement = MovementType.None;
            }

            if (_currentState != MeasurementState.Idle)
            {
                ResetMeasurementState();
            }
        }

        private void SdkTimer_Tick(object sender, EventArgs e)
        {
            // If already closing, do nothing
            if (_isClosing) return;

            try { Context.Update(); }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during Context.Update: {ex.Message}");
                if (_isCameraConnected) { HandleDisconnection("Error communicating with camera."); }
                return; // Stop processing this tick if Update fails
            }

            bool currentlyAvailable = _streamSet?.IsAvailable ?? false;

            if (!currentlyAvailable && _isCameraConnected)
            {
                HandleDisconnection("Camera disconnected. Closing assessment.");
                return; // Stop the tick after handling disconnect
            }

            // Don't process frames if disconnected (already handled), paused by user, or no movement selected
            if (!_isCameraConnected || _currentState == MeasurementState.Paused || _currentMovement == MovementType.None)
            {
                return;
            }

            // --- Frame Processing ---
            ReaderFrame frame = null;
            try
            {
                if (!_reader.TryOpenFrame(0, out frame)) { return; } // No new frame

                ColorFrame cf = null;
                DepthFrame df = null;
                PointF[] rawJoints = null;
                Point3D[] smoothedLimb3D = null;

                cf = frame.GetFrame<ColorFrame>();
                df = frame.GetFrame<DepthFrame>();

                // --- Color Frame Processing & MoveNet ---
                if (cf != null && cf.Width > 0 && cf.DataPtr != IntPtr.Zero)
                {
                    int colorLength = cf.Width * cf.Height * 3;
                    if (_colorBuffer == null || _colorBuffer.Length != colorLength) { _colorBuffer = new byte[colorLength]; }
                    cf.CopyData(ref _colorBuffer);

                    // BGR -> RGB swap
                    for (int i = 0; i < _colorBuffer.Length; i += 3)
                    {
                        byte temp = _colorBuffer[i]; _colorBuffer[i] = _colorBuffer[i + 2]; _colorBuffer[i + 2] = temp;
                    }

                    var keypointsTensor = _moveNet.RunInference(_colorBuffer, cf.Width, cf.Height);
                    rawJoints = _moveNet.ExtractKeypoints(keypointsTensor, cf.Width, cf.Height);
                    _smoothedJoints = SmoothJoints(rawJoints, 0.5f);
                }
                else { _smoothedJoints = null; }

                // --- Depth Frame Processing & 3D Pose/Angle ---
                if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero && _smoothedJoints != null && cf != null)
                {
                    int depthCount = df.Width * df.Height;
                    if (_depthBuffer == null || _depthBuffer.Length != depthCount) { _depthBuffer = new short[depthCount]; }
                    df.CopyData(ref _depthBuffer);
                    MedianFilter(_depthBuffer, df.Width, df.Height);

                    var rawLimb3D = GetLimb3DPose(_smoothedJoints, _depthBuffer, df.Width, df.Height, cf.Width, cf.Height);
                    smoothedLimb3D = Smooth3DJointsMovingAverage(rawLimb3D);

                    if (smoothedLimb3D != null && smoothedLimb3D.Length == 3)
                    {
                        double limbAngle = CalculateAngle3D(smoothedLimb3D[0], smoothedLimb3D[1], smoothedLimb3D[2]);
                        _lastAngleWasValid = limbAngle >= 0;
                        if (_lastAngleWasValid) { _lastLiveAngle = SmoothAngleMovingAverage(limbAngle); }
                    }
                    else { _lastAngleWasValid = false; }
                }
                else { _lastAngleWasValid = false; }

                // --- Render ---
                if (cf != null && _colorBuffer != null)
                {
                    RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, _smoothedJoints, smoothedLimb3D);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during frame processing: {ex}");
                if (_isCameraConnected) { HandleDisconnection("An error occurred during frame processing. Closing assessment."); }
            }
            finally
            {
                frame?.Dispose();
            }
        }

        // *** MODIFIED: HandleDisconnection to close the form ***
        private void HandleDisconnection(string message)
        {
            if (_isClosing) return; // Prevent recursive calls if Close triggers events
            _isClosing = true;      // Set flag immediately

            _isCameraConnected = false; // Update status
            _sdkTimer?.Stop();        // Stop timer before showing modal dialog

            MessageBox.Show(message, "Camera Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // Close the form safely on the UI thread
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }

        // *** REMOVED: HandleReconnection method is no longer needed ***

        private void btnStartStopMeasurement_Click(object sender, EventArgs e)
        {
            // Check added previously is still good
            if (!_isCameraConnected)
            {
                MessageBox.Show("Camera is not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Rest of the method remains the same...
            switch (_currentState)
            {
                case MeasurementState.Idle:
                    if (_currentMovement == MovementType.None)
                    {
                        MessageBox.Show("Please select a movement type first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                    }
                    if (_lastAngleWasValid)
                    {
                        btnConfigure.Enabled = false;
                        _initialAngle = _lastLiveAngle;
                        _initialConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblStartingPositionValue.Text = $"{_initialAngle:F1}° ({_initialConfidence})";
                        lblRomValue.Text = ""; lblNormalRange.Text = ""; lblDeficit.Text = "";
                        btnStartStopMeasurement.Text = "Stop Measurement";
                        _currentState = MeasurementState.Measuring;
                        ResetSmoothingFilters();
                    }
                    else { MessageBox.Show("Cannot start measurement. Joint occluded/out of range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
                case MeasurementState.Measuring:
                    if (_lastAngleWasValid)
                    {
                        btnConfigure.Enabled = true;
                        _endAngle = _lastLiveAngle;
                        _endConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblRomValue.Text = $"{_endAngle:F1}° ({_endConfidence})";

                        string movementName = _currentMovement.ToString();
                        double normalRange = ROMHelper.GetNormalRange(_currentJointName, movementName);
                        double deficit = ROMHelper.CalculateDeficit(_endAngle, _currentJointName, movementName);
                        lblNormalRange.Text = $"{normalRange:F1}°";
                        lblDeficit.Text = $"{deficit:F1}°";

                        btnStartStopMeasurement.Text = "New Measurement";
                        _currentState = MeasurementState.Paused;
                    }
                    else { MessageBox.Show("Cannot stop measurement. Joint occluded/out of range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;
                case MeasurementState.Paused:
                    ResetMeasurementState();
                    break;
            }
        }

        private string GetConfidenceString(Color color)
        {
            if (color == Color.LawnGreen) return "Accuracy: Good";
            if (color == Color.Yellow) return "Accuracy: Fair";
            return "Accuracy: Low";
        }

        private void ResetMeasurementState()
        {
            _currentState = MeasurementState.Idle;
            // Button state depends only on connection now, as form will close if disconnected
            btnStartStopMeasurement.Enabled = _isCameraConnected;
            btnStartStopMeasurement.Text = "Start Measurement";
            lblStartingPositionValue.Text = ""; lblRomValue.Text = ""; lblNormalRange.Text = ""; lblDeficit.Text = "";
            _initialAngle = 0; _endAngle = 0;
            _initialConfidence = "N/A"; _endConfidence = "N/A";
            ResetSmoothingFilters();
        }

        // --- Other methods (GetCalculationIndices, ResetSmoothingFilters, MedianFilter, CalculateAngle3D, GetLimb3DPose, Smooth*, Render*, DrawLimbPose, btnSaveROM_Click, AssessmentROM_FormClosing) remain unchanged below this point ---
        // ... (Keep all the remaining methods exactly as they were in the previous version) ...

        private int[] GetCalculationIndices()
        {
            bool userSelectedRight = (_currentSide == BodySide.Right);
            switch (_currentJoint)
            {
                case JointType.Elbow: return userSelectedRight ? new[] { 5, 7, 9 } : new[] { 6, 8, 10 };
                case JointType.Shoulder: return userSelectedRight ? new[] { 11, 5, 7 } : new[] { 12, 6, 8 };
                case JointType.Hip: return userSelectedRight ? new[] { 5, 11, 13 } : new[] { 6, 12, 14 };
                case JointType.Knee: return userSelectedRight ? new[] { 11, 13, 15 } : new[] { 12, 14, 16 };
            }
            return Array.Empty<int>();
        }

        private void ResetSmoothingFilters()
        {
            _angleHistory.Clear();
            _jointHistory3D.Clear();
            _lastGood3DJoints = null;
            if (_jointOcclusionCounters == null || _jointOcclusionCounters.Length != 3)
            {
                _jointOcclusionCounters = new int[3];
            }
            else
            {
                Array.Clear(_jointOcclusionCounters, 0, _jointOcclusionCounters.Length);
            }
        }

        private void MedianFilter(short[] data, int width, int height)
        {
            if (data == null || data.Length != width * height) return;
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

        private double CalculateAngle3D(Point3D p1, Point3D p2_vertex, Point3D p3)
        {
            const float minValidDepth = 0.1f;
            if (p1.Z < minValidDepth || p2_vertex.Z < minValidDepth || p3.Z < minValidDepth)
            {
                Debug.WriteLine($"Invalid depth for angle calculation: P1.Z={p1.Z:F3}, P2.Z={p2_vertex.Z:F3}, P3.Z={p3.Z:F3}");
                return -1;
            }

            Point3D vector1 = new Point3D { X = p1.X - p2_vertex.X, Y = p1.Y - p2_vertex.Y, Z = p1.Z - p2_vertex.Z };
            Point3D vector2 = new Point3D { X = p3.X - p2_vertex.X, Y = p3.Y - p2_vertex.Y, Z = p3.Z - p2_vertex.Z };

            double magnitude1Sq = (vector1.X * vector1.X) + (vector1.Y * vector1.Y) + (vector1.Z * vector1.Z);
            double magnitude2Sq = (vector2.X * vector2.X) + (vector2.Y * vector2.Y) + (vector2.Z * vector2.Z);

            if (magnitude1Sq <= float.Epsilon || magnitude2Sq <= float.Epsilon)
            {
                Debug.WriteLine("Magnitude is near zero, cannot calculate angle.");
                return -1;
            }

            double magnitude1 = Math.Sqrt(magnitude1Sq);
            double magnitude2 = Math.Sqrt(magnitude2Sq);
            double dotProduct = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
            double cosTheta = dotProduct / (magnitude1 * magnitude2);
            cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta));
            double angleRad = Math.Acos(cosTheta);
            double interiorAngle = angleRad * (180.0 / Math.PI);

            if (_currentJoint == JointType.Elbow || _currentJoint == JointType.Knee)
            {
                return 180.0 - interiorAngle;
            }
            return interiorAngle;
        }

        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH)
        {
            int[] limbIndices = GetCalculationIndices();
            if (limbIndices.Length == 0 || joints2D == null || depthBuffer == null) return null;

            var outPts = new Point3D[limbIndices.Length];

            for (int i = 0; i < limbIndices.Length; i++)
            {
                int idx = limbIndices[i];
                if (idx < 0 || idx >= joints2D.Length || joints2D[idx].IsEmpty)
                {
                    outPts[i] = new Point3D { X = 0, Y = 0, Z = 0 };
                    _jointOcclusionCounters[i] = Math.Min(_jointOcclusionCounters[i] + 1, OcclusionGracePeriod + 1);
                    continue;
                }

                PointF p2d = joints2D[idx];
                int dx = (int)(p2d.X * depthW / (float)colorW);
                int dy = (int)(p2d.Y * depthH / (float)colorH);
                dx = Math.Max(0, Math.Min(dx, depthW - 1));
                dy = Math.Max(0, Math.Min(dy, depthH - 1));
                short depthInMm = depthBuffer[dy * depthW + dx];

                if (depthInMm <= 0)
                {
                    outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = 0 };
                    _jointOcclusionCounters[i] = Math.Min(_jointOcclusionCounters[i] + 1, OcclusionGracePeriod + 1);
                }
                else
                {
                    float depthInMeters = depthInMm / 1000.0f;
                    outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = depthInMeters };
                    _jointOcclusionCounters[i] = 0;
                }
            }
            return outPts;
        }

        private PointF[] SmoothJoints(PointF[] newJoints, float alpha)
        {
            if (newJoints == null) return _smoothedJoints;

            if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length)
            {
                _smoothedJoints = (PointF[])newJoints.Clone();
                return _smoothedJoints;
            }

            for (int i = 0; i < newJoints.Length; i++)
            {
                if (newJoints[i].IsEmpty) { continue; }
                if (_smoothedJoints[i].IsEmpty) { _smoothedJoints[i] = newJoints[i]; continue; }

                float newX = alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X;
                float newY = alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y;
                _smoothedJoints[i] = new PointF(newX, newY);
            }
            return _smoothedJoints;
        }

        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints)
        {
            if (newJoints == null || newJoints.All(p => p.Z <= 0)) { return _lastGood3DJoints; }

            _jointHistory3D.Enqueue(newJoints);
            while (_jointHistory3D.Count > MovingAverageWindowSize) { _jointHistory3D.Dequeue(); }
            if (_jointHistory3D.Count == 0) return newJoints;

            var averageJoints = new Point3D[newJoints.Length];
            for (int i = 0; i < newJoints.Length; i++)
            {
                float sumX = 0, sumY = 0, sumZ = 0; int validCount = 0;
                foreach (var frameJoints in _jointHistory3D)
                {
                    if (frameJoints != null && frameJoints.Length > i && frameJoints[i].Z > 0)
                    {
                        sumX += frameJoints[i].X; sumY += frameJoints[i].Y; sumZ += frameJoints[i].Z; validCount++;
                    }
                }
                if (validCount > 0) { averageJoints[i] = new Point3D { X = sumX / validCount, Y = sumY / validCount, Z = sumZ / validCount }; }
                else if (_lastGood3DJoints != null && _lastGood3DJoints.Length > i && _lastGood3DJoints[i].Z > 0) { averageJoints[i] = _lastGood3DJoints[i]; }
                else { averageJoints[i] = new Point3D { X = 0, Y = 0, Z = 0 }; }
            }
            if (averageJoints.Any(p => p.Z > 0)) { _lastGood3DJoints = averageJoints; }
            return averageJoints;
        }

        private double SmoothAngleMovingAverage(double newAngle)
        {
            if (newAngle >= 0)
            {
                _angleHistory.Enqueue(newAngle);
                while (_angleHistory.Count > MovingAverageWindowSize) { _angleHistory.Dequeue(); }
            }
            if (_angleHistory.Count == 0) { return newAngle >= 0 ? newAngle : 0; }
            return _angleHistory.Average();
        }

        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            if (buffer == null || buffer.Length == 0) return;

            Bitmap displayBmp = null;
            try
            {
                using (Bitmap bmp = new Bitmap(w, h, w * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0)))
                {
                    using (var g = Graphics.FromImage(bmp))
                    {
                        DrawLimbPose(g, joints2D, joints3D_smoothed);
                    }
                    displayBmp = (Bitmap)bmp.Clone();
                }

                pictureBoxRgb.Invoke((Action)(() =>
                {
                    pictureBoxRgb.Image?.Dispose();
                    pictureBoxRgb.Image = displayBmp;
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during rendering: {ex.ToString()}");
                displayBmp?.Dispose();
            }
        }

        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            if (g == null || joints2D == null) return;
            int[] activeIndices = GetCalculationIndices();
            if (activeIndices.Length < 3) return;

            const float optimalDepthStart = 0.7f; const float optimalDepthEnd = 2.5f; const float acceptableMargin = 0.2f;
            Color limbColor = Color.Red; float middleJointDepth = 0;

            if (joints3D_smoothed != null && joints3D_smoothed.Length > 1 && joints3D_smoothed[1].Z > 0)
            {
                middleJointDepth = joints3D_smoothed[1].Z;
                if (middleJointDepth >= optimalDepthStart && middleJointDepth <= optimalDepthEnd) limbColor = Color.LawnGreen;
                else if (middleJointDepth >= optimalDepthStart - acceptableMargin && middleJointDepth <= optimalDepthEnd + acceptableMargin) limbColor = Color.Yellow;
            }
            _lastConfidenceColor = limbColor; _bonePen.Color = limbColor;

            if (activeIndices[0] < joints2D.Length && !joints2D[activeIndices[0]].IsEmpty && activeIndices[1] < joints2D.Length && !joints2D[activeIndices[1]].IsEmpty)
            { g.DrawLine(_bonePen, joints2D[activeIndices[0]], joints2D[activeIndices[1]]); }
            if (activeIndices[1] < joints2D.Length && !joints2D[activeIndices[1]].IsEmpty && activeIndices[2] < joints2D.Length && !joints2D[activeIndices[2]].IsEmpty)
            { g.DrawLine(_bonePen, joints2D[activeIndices[1]], joints2D[activeIndices[2]]); }

            for (int i = 0; i < activeIndices.Length; i++)
            {
                int jointIndex = activeIndices[i];
                if (jointIndex < joints2D.Length && !joints2D[jointIndex].IsEmpty)
                {
                    PointF p2d = joints2D[jointIndex];
                    bool isOccluded = (i < _jointOcclusionCounters.Length && _jointOcclusionCounters[i] > OcclusionGracePeriod);
                    _jointBrush.Color = isOccluded ? Color.Red : Color.White;
                    g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10);
                }
            }

            if (middleJointDepth > 0)
            {
                string depthText = $"Your Distance: {middleJointDepth:F2}m"; string targetText = $"Good Range: {optimalDepthStart:F1}m - {optimalDepthEnd:F1}m";
                g.FillRectangle(_backBrush, 5, 5, 200, 50);
                g.DrawString(depthText, _font, _fontBrush, new PointF(10, 10));
                g.DrawString(targetText, _font, _fontBrush, new PointF(10, 30));
            }

            if ((_currentState == MeasurementState.Measuring || _currentState == MeasurementState.Paused) && _lastAngleWasValid)
            {
                if (activeIndices[1] < joints2D.Length && !joints2D[activeIndices[1]].IsEmpty)
                {
                    PointF vertexPoint = joints2D[activeIndices[1]]; double angleToDisplay = (_currentState == MeasurementState.Measuring) ? _lastLiveAngle : _endAngle;
                    string angleText = $"{angleToDisplay:F1}°";
                    SizeF textSize = g.MeasureString(angleText, _font);
                    RectangleF textRect = new RectangleF(vertexPoint.X + 15, vertexPoint.Y - 25, textSize.Width + 10, textSize.Height + 5);
                    g.FillRectangle(_backBrush, textRect);
                    g.DrawString(angleText, _font, _fontBrush, textRect.Location.X + 5, textRect.Location.Y + 2.5f);
                }
            }
        }

        private async void btnSaveROM_Click(object sender, EventArgs e)
        {
            if (_currentState != MeasurementState.Paused)
            {
                MessageBox.Show("Please complete a measurement (Start and then Stop) before saving.", "Measurement Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            var newRomDto = new AddROMDTO { AssessmentID = PageObjects.assessmentDetails.AssessmentID, UserID = SessionManager.UserID, GoniometerType = "Astra Pro Plus + MoveNet", StartingPosition = _initialAngle, Rom = _endAngle, NormalRom = Convert.ToDouble(lblNormalRange.Text), Deficit = Convert.ToDouble(lblDeficit.Text), Movement = _currentMovement.ToString(), MotionType = "Active", };
            bool success = false;
            try
            {
                btnSaveROM.Enabled = false; btnSaveROM.Text = "Saving..."; success = await Queries.ROMQueries.AddROM(newRomDto);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error saving ROM: {ex}"); MessageBox.Show($"An unexpected error occurred while saving: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (btnSaveROM.IsHandleCreated) { btnSaveROM.Invoke((Action)(() => { btnSaveROM.Enabled = true; btnSaveROM.Text = "Save ROM"; })); }
            }
            if (success)
            {
                MessageBox.Show("Range of Motion data saved successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await Queries.ROMQueries.DisplayROM(PageObjects.assessmentDetails.AssessmentID, "All");
                this.Close();
            }
        }

        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isClosing = true; // Set flag to prevent issues during close
            _sdkTimer?.Stop();
            _reader?.Dispose();
            _streamSet?.Dispose();
            _moveNet?.Dispose();
            _font?.Dispose(); _fontBrush?.Dispose(); _backBrush?.Dispose(); _jointBrush?.Dispose(); _bonePen?.Dispose();
            try { Context.Terminate(); } catch (Exception ex) { Debug.WriteLine($"Error during Context.Terminate: {ex.Message}"); }
        }

        private void linkLblGuide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open a URL in the default browser
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://kinesia.kiri8tives.com/help-standalone",
                UseShellExecute = true
            });
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            var configureROMPage = new ConfigureROM();
            configureROMPage.TopMost = true;
            configureROMPage.ShowDialog();
        }
    } // End of AssessmentROM class
} // End of namespace