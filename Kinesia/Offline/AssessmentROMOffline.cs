using Astra;
using Astra.Core;
using ClosedXML.Excel;
using KinesiaLibrary; // Make sure you have this using directive
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
        private enum JointTypeEnum { None, Shoulder, ElbowAndForearm, Hip, Knee } // Renamed Elbow
        private enum MovementType { None, Flexion, Extension, Abduction, Adduction }
        private enum MeasurementState { Idle, Measuring, Paused }

        // Current state variables
        private MeasurementState _currentState = MeasurementState.Idle;
        private BodySide _currentSide = BodySide.None;
        private JointTypeEnum _currentJoint = JointTypeEnum.None;
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
            ClearResultsLabels(); // Set labels to blank initially

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
            _sdkTimer = new System.Windows.Forms.Timer { Interval = 33 }; // ~30 FPS
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
                cmbJointSelection.Items.Add("Elbow and Forearm"); // Updated Text
                cmbJointSelection.Items.Add("Hip");
                cmbJointSelection.Items.Add("Knee");
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
            ClearResultsLabels();
            ResetMeasurementState();
        }

        private void cmbJointSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJointSelection.SelectedIndex > 0)
            {
                string selectedJoint = cmbJointSelection.SelectedItem.ToString();
                // Map the string to the correct enum value
                switch (selectedJoint)
                {
                    case "Shoulder": _currentJoint = JointTypeEnum.Shoulder; break;
                    case "Elbow and Forearm": _currentJoint = JointTypeEnum.ElbowAndForearm; break; // Use new enum
                    case "Hip": _currentJoint = JointTypeEnum.Hip; break;
                    case "Knee": _currentJoint = JointTypeEnum.Knee; break;
                    default: _currentJoint = JointTypeEnum.None; break;
                }


                cmbMovementSelection.Enabled = true;
                cmbMovementSelection.Items.Clear();
                cmbMovementSelection.Items.Add("Select a movement type");

                switch (_currentJoint)
                {
                    case JointTypeEnum.Shoulder:
                        cmbMovementSelection.Items.Add("Flexion");
                        cmbMovementSelection.Items.Add("Extension");
                        cmbMovementSelection.Items.Add("Abduction");
                        cmbMovementSelection.Items.Add("Adduction");
                        break;
                    case JointTypeEnum.ElbowAndForearm: // Updated case
                        cmbMovementSelection.Items.Add("Flexion");
                        cmbMovementSelection.Items.Add("Extension");
                        break;
                    case JointTypeEnum.Hip:
                        cmbMovementSelection.Items.Add("Flexion");
                        cmbMovementSelection.Items.Add("Extension");
                        break;
                    case JointTypeEnum.Knee:
                        cmbMovementSelection.Items.Add("Flexion");
                        cmbMovementSelection.Items.Add("Extension");
                        break;
                }
                cmbMovementSelection.SelectedIndex = 0;
            }
            else
            {
                _currentJoint = JointTypeEnum.None;
                ResetMovementSelection(false, "Select a joint first");
            }
            ClearResultsLabels();
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
                    string jointStr = GetSelectedJointString();
                    if (!string.IsNullOrEmpty(jointStr))
                    {
                        double normalRange = ROMHelper.GetNormalRange(jointStr, selection);
                        if (normalRange == 0 && (selection == "Abduction" || selection == "Adduction"))
                        {
                            lblNormalRange.Text = "<N/A>";
                        }
                        else
                        {
                            lblNormalRange.Text = $"{normalRange}°";
                        }
                    }
                    else
                    {
                        lblNormalRange.Text = "<N/A>";
                    }
                }
                else
                {
                    _currentMovement = MovementType.None;
                    lblNormalRange.Text = "";
                }
            }
            else
            {
                _currentMovement = MovementType.None;
                lblNormalRange.Text = "";
            }
            lblDeficit.Text = "";
            ResetMeasurementState();
        }

        // Helper to get the selected joint as a string for ROMHelper
        private string GetSelectedJointString()
        {
            if (_currentJoint != JointTypeEnum.None) // Use the enum value directly
            {
                switch (_currentJoint)
                {
                    case JointTypeEnum.Shoulder: return "Shoulder";
                    case JointTypeEnum.ElbowAndForearm: return "Elbow and Forearm"; // Matches ROMHelper
                    case JointTypeEnum.Hip: return "Hip";
                    case JointTypeEnum.Knee: return "Knee";
                    default: return null;
                }
            }
            return null;
        }

        // Helper to get the selected movement as a string for ROMHelper
        private string GetSelectedMovementString()
        {
            if (cmbMovementSelection.SelectedIndex > 0 && cmbMovementSelection.SelectedItem != null)
            {
                return cmbMovementSelection.SelectedItem.ToString();
            }
            return null;
        }


        private void ResetMovementSelection(bool enabled, string placeholder)
        {
            _currentMovement = MovementType.None;
            cmbMovementSelection.Enabled = enabled;
            cmbMovementSelection.Items.Clear();
            cmbMovementSelection.Items.Add(placeholder);
            cmbMovementSelection.SelectedIndex = 0;
        }

        // Clears all result labels to empty strings
        private void ClearResultsLabels()
        {
            lblStartingPosition.Text = "";
            lblROM.Text = "";
            lblNormalRange.Text = "";
            lblDeficit.Text = "";
        }


        #endregion

        private void SdkTimer_Tick(object sender, EventArgs e)
        {
            if (_currentState == MeasurementState.Paused || _currentMovement == MovementType.None) return;

            Context.Update();

            if (!_reader.TryOpenFrame(0, out var frame)) return;

            Astra.ColorFrame cf = null;
            Astra.DepthFrame df = null;

            try
            {
                cf = frame.GetFrame<ColorFrame>();
                df = frame.GetFrame<DepthFrame>();

                Point3D[] smoothedLimb3D = null;

                if (cf != null && cf.Width > 0 && cf.DataPtr != IntPtr.Zero)
                {
                    int colorLength = cf.Width * cf.Height * 3;
                    if (_colorBuffer == null || _colorBuffer.Length != colorLength)
                        _colorBuffer = new byte[colorLength];
                    cf.CopyData(ref _colorBuffer);

                    // BGR to RGB swap
                    for (int i = 0; i < _colorBuffer.Length; i += 3)
                    {
                        byte temp = _colorBuffer[i];
                        _colorBuffer[i] = _colorBuffer[i + 2];
                        _colorBuffer[i + 2] = temp;
                    }

                    var keypointsTensor = _moveNet.RunInference(_colorBuffer, cf.Width, cf.Height);
                    var rawJoints = _moveNet.ExtractKeypoints(keypointsTensor, cf.Width, cf.Height);
                    _smoothedJoints = SmoothJoints(rawJoints, 0.5f);

                    if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero)
                    {
                        int depthCount = df.Width * df.Height;
                        if (_depthBuffer == null || _depthBuffer.Length != depthCount)
                            _depthBuffer = new short[depthCount];

                        df.CopyData(ref _depthBuffer);
                        MedianFilter(_depthBuffer, df.Width, df.Height);

                        var rawLimb3D = GetLimb3DPose(_smoothedJoints, _depthBuffer, df.Width, df.Height, cf.Width, cf.Height);
                        smoothedLimb3D = Smooth3DJointsMovingAverage(rawLimb3D);

                        if (smoothedLimb3D != null && smoothedLimb3D.Length == 3 && smoothedLimb3D.All(p => p.Z > 0))
                        {
                            double limbAngle = CalculateAngle3D(smoothedLimb3D[0], smoothedLimb3D[1], smoothedLimb3D[2]);
                            if (limbAngle >= 0)
                            {
                                _lastLiveAngle = SmoothAngleMovingAverage(limbAngle);
                                _lastAngleWasValid = true;
                            }
                            else
                            {
                                _lastAngleWasValid = false;
                            }
                        }
                        else
                        {
                            _lastAngleWasValid = false;
                        }
                    }
                    else
                    {
                        _lastAngleWasValid = false;
                    }
                    RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, _smoothedJoints, smoothedLimb3D);
                }
                else
                {
                    _lastAngleWasValid = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during frame processing: {ex.ToString()}");
                _lastAngleWasValid = false;
            }
            finally
            {
                frame.Dispose();
            }
        }


        // *** UPDATED Label Text Formatting ***
        private void btnStartStopMeasurement_Click(object sender, EventArgs e)
        {
            string jointStr = GetSelectedJointString();
            string movementStr = GetSelectedMovementString();

            switch (_currentState)
            {
                case MeasurementState.Idle:
                    if (_currentMovement == MovementType.None || string.IsNullOrEmpty(jointStr))
                    {
                        MessageBox.Show("Please select a side, joint, and movement type first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_lastAngleWasValid)
                    {
                        _initialAngle = _lastLiveAngle;
                        _initialConfidence = GetConfidenceString(_lastConfidenceColor);
                        // Removed "Initial:" prefix
                        lblStartingPosition.Text = $"{_initialAngle:F1}° (Accuracy: {_initialConfidence})";
                        lblROM.Text = ""; // Clear ROM label at start
                        lblDeficit.Text = ""; // Clear deficit at start
                        btnStartStopMeasurement.Text = "Stop Measurement";
                        _currentState = MeasurementState.Measuring;
                        cmbLimbSelection.Enabled = false;
                        cmbJointSelection.Enabled = false;
                        cmbMovementSelection.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Cannot start measurement. Required joints might be occluded or out of range. Please ensure the limb is clearly visible.", "Joint Occluded/Invalid Angle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MeasurementState.Measuring:
                    if (_lastAngleWasValid)
                    {
                        _endAngle = _lastLiveAngle;
                        _endConfidence = GetConfidenceString(_lastConfidenceColor);
                        // Removed "End:" prefix
                        lblROM.Text = $"{_endAngle:F1}° (Accuracy: {_endConfidence})";

                        if (!string.IsNullOrEmpty(jointStr) && !string.IsNullOrEmpty(movementStr))
                        {
                            double deficit = ROMHelper.CalculateDeficit(_endAngle, jointStr, movementStr);
                            lblDeficit.Text = $"{deficit:F1}°";
                        }
                        else
                        {
                            lblDeficit.Text = "<N/A>";
                        }

                        btnStartStopMeasurement.Text = "New Measurement";
                        _currentState = MeasurementState.Paused;
                    }
                    else
                    {
                        MessageBox.Show("Cannot stop measurement. Required joints might be occluded or out of range. Please ensure the limb is clearly visible.", "Joint Occluded/Invalid Angle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MeasurementState.Paused:
                    ResetMeasurementState();
                    cmbLimbSelection.Enabled = true;
                    cmbJointSelection.Enabled = _currentSide != BodySide.None;
                    cmbMovementSelection.Enabled = _currentJoint != JointTypeEnum.None;
                    break;
            }
        }


        // Returns "Good", "Fair", or "Low"
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
            // Clear result labels (Normal Range is set by combo box change)
            lblStartingPosition.Text = "";
            lblROM.Text = "";
            lblDeficit.Text = "";
            // Reset internal angle variables
            _initialAngle = 0;
            _endAngle = 0;
            _initialConfidence = "N/A";
            _endConfidence = "N/A";
            ResetSmoothingFilters();
        }


        // Returns MoveNet indices (0-16), swapped L/R
        private int[] GetCalculationIndices()
        {
            bool useLeftIndices = (_currentSide == BodySide.Right); // SWAPPED

            switch (_currentJoint)
            {
                case JointTypeEnum.ElbowAndForearm: // Flexion/Extension // UPDATED Enum
                    return useLeftIndices ? new[] { 5, 7, 9 } : new[] { 6, 8, 10 };

                case JointTypeEnum.Shoulder:
                    switch (_currentMovement)
                    {
                        case MovementType.Flexion:
                        case MovementType.Extension:
                            return useLeftIndices ? new[] { 11, 5, 7 } : new[] { 12, 6, 8 };
                        case MovementType.Abduction:
                        case MovementType.Adduction:
                            // Note: May need refinement based on accuracy
                            return useLeftIndices ? new[] { 1, 5, 7 } : new[] { 1, 6, 8 };
                        default: return new int[0];
                    }

                case JointTypeEnum.Hip: // Flexion/Extension
                    return useLeftIndices ? new[] { 9, 11, 13 } : new[] { 9, 12, 14 };

                case JointTypeEnum.Knee: // Flexion/Extension
                    return useLeftIndices ? new[] { 11, 13, 15 } : new[] { 12, 14, 16 };
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
            if (data == null || data.Length != width * height) return;
            var tempData = (short[])data.Clone();
            var window = new List<short>(9);
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    window.Clear();
                    for (int j = -1; j <= 1; j++) for (int i = -1; i <= 1; i++)
                        {
                            short val = tempData[(y + j) * width + (x + i)];
                            if (val > 0) window.Add(val);
                        }
                    if (window.Count > 0)
                    {
                        window.Sort();
                        data[y * width + x] = window[window.Count / 2];
                    }
                }
            }
        }


        // Updated CalculateAngle3D
        private double CalculateAngle3D(Point3D p1, Point3D p2_Vertex, Point3D p3)
        {
            if (p1.Z <= 0 || p2_Vertex.Z <= 0 || p3.Z <= 0) return -1;
            Point3D v1 = new Point3D { X = p1.X - p2_Vertex.X, Y = p1.Y - p2_Vertex.Y, Z = p1.Z - p2_Vertex.Z };
            Point3D v2 = new Point3D { X = p3.X - p2_Vertex.X, Y = p3.Y - p2_Vertex.Y, Z = p3.Z - p2_Vertex.Z };
            double mag1 = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            double mag2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
            if (mag1 == 0 || mag2 == 0) return -1;
            double dot = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
            double cosTheta = Math.Max(-1.0, Math.Min(1.0, dot / (mag1 * mag2)));
            double angleDeg = Math.Acos(cosTheta) * (180.0 / Math.PI);

            // Adjust angle based on joint/movement
            if (_currentJoint == JointTypeEnum.ElbowAndForearm) // UPDATED Enum
            {
                return 180.0 - angleDeg; // Interior angle for elbow
            }
            // Knee calculation Hip-Knee-Ankle already gives interior angle
            // Shoulder & Hip Flex/Ext calculation gives angle relative to trunk/vertical axis
            // Shoulder Ab/Adduction might need further refinement based on plane

            return angleDeg; // Default
        }


        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH)
        {
            int[] limbIndices = GetCalculationIndices();
            if (limbIndices.Length != 3) return null;
            var outPts = new Point3D[3];
            for (int i = 0; i < 3; i++)
            {
                int idx = limbIndices[i];
                if (idx < 0 || idx >= joints2D.Length || joints2D[idx].IsEmpty)
                { outPts[i] = new Point3D(); continue; }
                PointF p2d = joints2D[idx];
                int dx = (int)(p2d.X * depthW / (float)colorW);
                int dy = (int)(p2d.Y * depthH / (float)colorH);
                dx = Math.Max(0, Math.Min(dx, depthW - 1));
                dy = Math.Max(0, Math.Min(dy, depthH - 1));
                short depthMm = depthBuffer[dy * depthW + dx];
                float depthM = depthMm / 1000.0f;
                outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = (depthM > 0) ? depthM : 0 };
            }
            return outPts;
        }


        private PointF[] SmoothJoints(PointF[] newJoints, float alpha)
        {
            if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length)
            {
                _smoothedJoints = new PointF[newJoints.Length];
                for (int i = 0; i < newJoints.Length; i++) _smoothedJoints[i] = newJoints[i].IsEmpty ? PointF.Empty : newJoints[i];
                return _smoothedJoints;
            }
            for (int i = 0; i < newJoints.Length; i++)
            {
                if (newJoints[i].IsEmpty) continue;
                if (_smoothedJoints[i].IsEmpty) { _smoothedJoints[i] = newJoints[i]; continue; }
                _smoothedJoints[i] = new PointF(alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X,
                                               alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y);
            }
            return _smoothedJoints;
        }


        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints)
        {
            if (newJoints == null || newJoints.Length != 3)
            {
                bool wasGood = _lastGood3DJoints != null && _lastGood3DJoints.All(p => p.Z > 0);
                if (wasGood) for (int i = 0; i < 3; i++) _jointOcclusionCounters[i]++;
                return _lastGood3DJoints;
            }
            Point3D[] currentFrame = new Point3D[3];
            bool frameValid = false;
            for (int i = 0; i < 3; i++)
            {
                if (newJoints[i].Z > 0) { currentFrame[i] = newJoints[i]; _jointOcclusionCounters[i] = 0; frameValid = true; }
                else { _jointOcclusionCounters[i]++; currentFrame[i] = (_jointOcclusionCounters[i] <= OcclusionGracePeriod && _lastGood3DJoints?.Length == 3) ? _lastGood3DJoints[i] : new Point3D(); }
            }
            if (frameValid)
            {
                _jointHistory3D.Enqueue(currentFrame);
                while (_jointHistory3D.Count > MovingAverageWindowSize) _jointHistory3D.Dequeue();
                _lastGood3DJoints = currentFrame;
            }
            else if (_jointHistory3D.Count == 0) return null;
            if (_jointHistory3D.Count == 0) return null;
            var average = new Point3D[3];
            for (int i = 0; i < 3; i++)
            { float sx = 0, sy = 0, sz = 0; int vc = 0; foreach (var f in _jointHistory3D) if (f.Length > i && f[i].Z > 0) { sx += f[i].X; sy += f[i].Y; sz += f[i].Z; vc++; } average[i] = (vc > 0) ? new Point3D { X = sx / vc, Y = sy / vc, Z = sz / vc } : new Point3D(); }
            return average;
        }


        private double SmoothAngleMovingAverage(double newAngle)
        {
            if (newAngle >= 0) { _angleHistory.Enqueue(newAngle); while (_angleHistory.Count > MovingAverageWindowSize) _angleHistory.Dequeue(); }
            else if (_angleHistory.Count > 0) return _angleHistory.Average();
            else return -1;
            if (_angleHistory.Count == 0) return (newAngle >= 0) ? newAngle : -1;
            return _angleHistory.Average();
        }


        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            Bitmap bmp = null; Bitmap displayBmp = null; Graphics g = null;
            try
            {
                if (buffer == null || buffer.Length != w * h * 3) return;
                bmp = new Bitmap(w, h, w * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));
                g = Graphics.FromImage(bmp);
                DrawLimbPose(g, joints2D, joints3D_smoothed);
                displayBmp = (Bitmap)bmp.Clone();
                pictureBoxRgb.Invoke((Action)(() => { pictureBoxRgb.Image?.Dispose(); pictureBoxRgb.Image = displayBmp; }));
            }
            catch (Exception ex) { Debug.WriteLine($"Render Error: {ex}"); displayBmp?.Dispose(); }
            finally { g?.Dispose(); bmp?.Dispose(); }
        }


        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            if (joints2D == null) return; int[] idxs = GetCalculationIndices(); if (idxs.Length != 3) return;
            const float optStart = 0.7f, optEnd = 2.5f, margin = 0.2f; Color limbColor = Color.Red; float midDepth = 0;
            if (joints3D_smoothed?.Length == 3) { midDepth = joints3D_smoothed[1].Z; if (midDepth > 0) { if (midDepth >= optStart && midDepth <= optEnd) limbColor = Color.LawnGreen; else if (midDepth >= optStart - margin && midDepth <= optEnd + margin) limbColor = Color.Yellow; } }
            _lastConfidenceColor = limbColor; _bonePen.Color = limbColor;
            string dTxt = (midDepth > 0) ? $"Dist: {midDepth:F2}m" : "Dist: N/A"; string tTxt = $"Range: {optStart:F1}-{optEnd:F1}m";
            g.FillRectangle(_backBrush, 5, 5, 160, 50); g.DrawString(dTxt, _font, _fontBrush, 10, 10); g.DrawString(tTxt, _font, _fontBrush, 10, 30);
            PointF p1 = GetSafeJoint2D(joints2D, idxs[0]), pV = GetSafeJoint2D(joints2D, idxs[1]), p3 = GetSafeJoint2D(joints2D, idxs[2]);
            if (!p1.IsEmpty && !pV.IsEmpty) g.DrawLine(_bonePen, p1, pV); if (!pV.IsEmpty && !p3.IsEmpty) g.DrawLine(_bonePen, pV, p3);
            for (int i = 0; i < 3; i++) { int jIdx = idxs[i]; PointF p2d = GetSafeJoint2D(joints2D, jIdx); if (!p2d.IsEmpty) { bool vis = joints3D_smoothed?.Length > i && joints3D_smoothed[i].Z > 0; if (vis) _jointOcclusionCounters[i] = 0; else _jointOcclusionCounters[i]++; Color jCol = (_jointOcclusionCounters[i] > OcclusionGracePeriod) ? Color.Red : Color.White; _jointBrush.Color = jCol; g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10); } else { _jointOcclusionCounters[i]++; } }
            if ((_currentState == MeasurementState.Measuring || _currentState == MeasurementState.Paused) && _lastAngleWasValid && !pV.IsEmpty) { double angle = (_currentState == MeasurementState.Measuring) ? _lastLiveAngle : _endAngle; string aTxt = $"{angle:F1}°"; SizeF sz = g.MeasureString(aTxt, _font); RectangleF r = new RectangleF(pV.X + 15, pV.Y - 25, sz.Width + 10, sz.Height + 5); g.FillRectangle(_backBrush, r); g.DrawString(aTxt, _font, _fontBrush, r.X + 5, r.Y + 2.5f); }
        }

        private PointF GetSafeJoint2D(PointF[] joints, int index) => (joints != null && index >= 0 && index < joints.Length && !joints[index].IsEmpty) ? joints[index] : PointF.Empty;

        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sdkTimer?.Stop();
            try { _colorStream?.Stop(); _depthStream?.Stop(); _reader?.Dispose(); _streamSet?.Dispose(); Context.Terminate(); } catch { }
            _moveNet?.Dispose(); _font?.Dispose(); _fontBrush?.Dispose(); _backBrush?.Dispose(); _jointBrush?.Dispose(); _bonePen?.Dispose();
        }

        private void btnSaveAssessment_Click(object sender, EventArgs e)
        {
            // 1. Check if there's valid data to save (measurement must be paused/complete)
            if (_currentState != MeasurementState.Paused || _endAngle == 0)
            {
                MessageBox.Show("Please complete a measurement before saving.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Get the data to save
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string side = _currentSide.ToString();
            string joint = GetSelectedJointString(); // Use helper
            string movement = GetSelectedMovementString(); // Use helper
            string startAngleStr = $"{_initialAngle:F1}° (Accuracy: {_initialConfidence})";
            string endAngleStr = $"{_endAngle:F1}° (Accuracy: {_endConfidence})";
            string normalRangeStr = lblNormalRange.Text; // Get text directly from label
            string deficitStr = lblDeficit.Text;         // Get text directly from label

            // 3. Prompt user for save location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Save Assessment Data";
                saveFileDialog.FileName = "Kinesia_Assessments.xlsx"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        XLWorkbook workbook;
                        IXLWorksheet worksheet;

                        // 4. Create or Open Workbook/Worksheet
                        if (File.Exists(filePath))
                        {
                            workbook = new XLWorkbook(filePath); // Open existing
                            if (!workbook.Worksheets.TryGetWorksheet("Assessments", out worksheet))
                            {
                                worksheet = workbook.Worksheets.Add("Assessments"); // Add sheet if missing
                                AddHeaders(worksheet); // Add headers if it's a new sheet in existing file
                            }
                        }
                        else
                        {
                            workbook = new XLWorkbook(); // Create new
                            worksheet = workbook.Worksheets.Add("Assessments");
                            AddHeaders(worksheet); // Add headers for new file
                        }

                        // 5. Find the next empty row
                        int nextRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1; // Find last used row, or start at 1
                        if (nextRow == 1 && worksheet.Cell(1, 1).IsEmpty()) // Handle case where sheet exists but is empty
                        {
                            AddHeaders(worksheet); // Add headers if first row is empty
                            nextRow = 2; // Data starts on row 2
                        }
                        else if (nextRow == 1 && !worksheet.Cell(1, 1).IsEmpty()) // Sheet has headers but no data
                        {
                            nextRow = 2; // Data starts on row 2
                        }


                        // 6. Add the data to the next row
                        worksheet.Cell(nextRow, 1).Value = timeStamp;
                        worksheet.Cell(nextRow, 2).Value = side;
                        worksheet.Cell(nextRow, 3).Value = joint;
                        worksheet.Cell(nextRow, 4).Value = movement;
                        worksheet.Cell(nextRow, 5).Value = startAngleStr;
                        worksheet.Cell(nextRow, 6).Value = endAngleStr;
                        worksheet.Cell(nextRow, 7).Value = normalRangeStr;
                        worksheet.Cell(nextRow, 8).Value = deficitStr;

                        // Adjust column widths to content
                        worksheet.Columns().AdjustToContents();

                        // 7. Save the workbook
                        workbook.SaveAs(filePath);
                        MessageBox.Show($"Assessment saved successfully to:\n{filePath}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save assessment data.\nError: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Helper method to add headers to the worksheet
        private void AddHeaders(IXLWorksheet worksheet)
        {
            worksheet.Cell(1, 1).Value = "Timestamp";
            worksheet.Cell(1, 2).Value = "Side";
            worksheet.Cell(1, 3).Value = "Joint";
            worksheet.Cell(1, 4).Value = "Movement";
            worksheet.Cell(1, 5).Value = "Starting Position";
            worksheet.Cell(1, 6).Value = "ROM";
            worksheet.Cell(1, 7).Value = "Normal Range";
            worksheet.Cell(1, 8).Value = "Deficit";
            // Optional: Style headers
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.LightGray;
        }
    }
}