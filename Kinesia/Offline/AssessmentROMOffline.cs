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

        // --- NEW: State Flags for Camera Connection ---
        private bool _isCameraConnected = true;
        private bool _isClosing = false; // Flag to prevent multiple close attempts

        public AssessmentROMOffline()
        {
            InitializeComponent();
            this.Load += AssessmentROM_Load; // Changed from AssessmentROM_Load
            this.FormClosing += AssessmentROM_FormClosing;
            _modelPath = Path.Combine(Application.StartupPath, "models", ModelFileName);
        }

        private void AssessmentROM_Load(object sender, EventArgs e) // Changed from AssessmentROM_Load
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
            try
            {
                Context.Initialize();
                _streamSet = StreamSet.Open();

                // --- NEW: Initial Camera Check ---
                if (!_streamSet.IsAvailable)
                {
                    _isCameraConnected = false;
                    MessageBox.Show("Astra camera not detected. Please check the connection.", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close(); // Close immediately if not found on load
                    return;
                }
                // --- End NEW ---

                _reader = _streamSet.CreateReader();
                _colorStream = _reader.GetStream<ColorStream>();
                _depthStream = _reader.GetStream<DepthStream>();
                _colorStream.Start();
                _depthStream.Start();
            }
            catch (Exception ex)
            {
                _isCameraConnected = false; // Mark as disconnected if init fails
                MessageBox.Show($"Failed to initialize Astra SDK: {ex.Message}", "SDK Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); return;
            }


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
            // --- NEW: Prevent processing if closing ---
            if (_isClosing) return;

            // --- NEW: Check for SDK communication errors ---
            try
            {
                Context.Update();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during Context.Update: {ex.Message}");
                if (_isCameraConnected) // Only handle if it was previously connected
                {
                    HandleDisconnection("Error communicating with camera. Closing assessment.");
                }
                return; // Stop processing this tick if Update fails
            }

            // --- NEW: Check if camera is still available ---
            bool currentlyAvailable = _streamSet?.IsAvailable ?? false;
            if (!currentlyAvailable && _isCameraConnected)
            {
                HandleDisconnection("Camera disconnected. Closing assessment.");
                return; // Stop the tick after handling disconnect
            }

            // --- Don't process if disconnected, paused, or no movement selected ---
            if (!_isCameraConnected || _currentState == MeasurementState.Paused || _currentMovement == MovementType.None)
            {
                return;
            }
            // --- End NEW ---


            // --- Frame Processing (mostly unchanged) ---
            ReaderFrame frame = null; // Use ReaderFrame instead of var for clarity
            try
            {
                if (!_reader.TryOpenFrame(0, out frame)) return; // No new frame, exit tick

                Astra.ColorFrame cf = null;
                Astra.DepthFrame df = null;
                Point3D[] smoothedLimb3D = null; // Keep this outside cf block

                cf = frame.GetFrame<ColorFrame>();
                df = frame.GetFrame<DepthFrame>(); // Get depth frame regardless of color success

                // --- Color Frame Processing & MoveNet ---
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
                }
                else
                {
                    _smoothedJoints = null; // Ensure smoothed joints are null if color fails
                    _lastAngleWasValid = false; // Angle becomes invalid if no color/pose
                }


                // --- Depth Frame Processing & 3D Pose/Angle (Only if pose exists) ---
                if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero && _smoothedJoints != null) // Check _smoothedJoints
                {
                    int depthCount = df.Width * df.Height;
                    if (_depthBuffer == null || _depthBuffer.Length != depthCount)
                        _depthBuffer = new short[depthCount];

                    df.CopyData(ref _depthBuffer);
                    MedianFilter(_depthBuffer, df.Width, df.Height);

                    var rawLimb3D = GetLimb3DPose(_smoothedJoints, _depthBuffer, df.Width, df.Height, cf.Width, cf.Height); // cf might be null here, ensure GetLimb3DPose handles it or pass dimensions differently
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
                else // Depth frame failed or no 2D pose
                {
                    _lastAngleWasValid = false;
                }

                // --- Render (only if color buffer is valid) ---
                if (cf != null && _colorBuffer != null)
                {
                    RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, _smoothedJoints, smoothedLimb3D);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during frame processing: {ex}");
                // --- NEW: Handle disconnect on processing error ---
                if (_isCameraConnected)
                {
                    HandleDisconnection("An error occurred during frame processing. Closing assessment.");
                }
                // --- End NEW ---
                _lastAngleWasValid = false; // Ensure angle is invalid after error
            }
            finally
            {
                frame?.Dispose(); // Use null-conditional Dispose
            }
        }

        // --- NEW: HandleDisconnection Method (Copied from AssessmentROM.cs) ---
        private void HandleDisconnection(string message)
        {
            if (_isClosing) return; // Prevent recursive calls if Close triggers events
            _isClosing = true;      // Set flag immediately

            _isCameraConnected = false; // Update status
            _sdkTimer?.Stop();        // Stop timer before showing modal dialog

            // Use Invoke if called from a non-UI thread (though Timer usually ticks on UI thread)
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() => MessageBox.Show(message, "Camera Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            }
            else
            {
                MessageBox.Show(message, "Camera Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            // Close the form safely on the UI thread
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                this.BeginInvoke(new Action(() => this.Close()));
            }
        }
        // --- End NEW ---


        // *** UPDATED Label Text Formatting ***
        private void btnStartStopMeasurement_Click(object sender, EventArgs e)
        {
            // --- NEW: Check camera connection ---
            if (!_isCameraConnected)
            {
                MessageBox.Show("Camera is not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- End NEW ---

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
            // --- NEW: Enable/disable based on connection status ---
            btnStartStopMeasurement.Enabled = _isCameraConnected;
            // --- End NEW ---
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
                            // Using Hip-Shoulder-Elbow for approximation
                            return useLeftIndices ? new[] { 11, 5, 7 } : new[] { 12, 6, 8 }; // TODO: Re-evaluate indices if needed for Ab/Adduction accuracy
                        default: return Array.Empty<int>();
                    }

                case JointTypeEnum.Hip: // Flexion/Extension - Using Shoulder-Hip-Knee
                    return useLeftIndices ? new[] { 5, 11, 13 } : new[] { 6, 12, 14 };

                case JointTypeEnum.Knee: // Flexion/Extension
                    return useLeftIndices ? new[] { 11, 13, 15 } : new[] { 12, 14, 16 };
            }
            return Array.Empty<int>();
        }


        private void ResetSmoothingFilters()
        {
            _angleHistory.Clear();
            _jointHistory3D.Clear();
            _lastGood3DJoints = null;
            if (_jointOcclusionCounters == null || _jointOcclusionCounters.Length != 3) // Initialize if null or wrong size
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
            const float minValidDepth = 0.1f; // Minimum realistic depth in meters
            if (p1.Z < minValidDepth || p2_Vertex.Z < minValidDepth || p3.Z < minValidDepth)
            {
                Debug.WriteLine($"Invalid depth for angle calculation: P1.Z={p1.Z:F3}, P2.Z={p2_Vertex.Z:F3}, P3.Z={p3.Z:F3}");
                return -1; // Indicate invalid angle due to depth
            }

            Point3D v1 = new Point3D { X = p1.X - p2_Vertex.X, Y = p1.Y - p2_Vertex.Y, Z = p1.Z - p2_Vertex.Z };
            Point3D v2 = new Point3D { X = p3.X - p2_Vertex.X, Y = p3.Y - p2_Vertex.Y, Z = p3.Z - p2_Vertex.Z };

            double mag1Sq = (v1.X * v1.X) + (v1.Y * v1.Y) + (v1.Z * v1.Z);
            double mag2Sq = (v2.X * v2.X) + (v2.Y * v2.Y) + (v2.Z * v2.Z);

            // Check for zero magnitude vectors
            if (mag1Sq <= float.Epsilon || mag2Sq <= float.Epsilon)
            {
                Debug.WriteLine("Magnitude is near zero, cannot calculate angle.");
                return -1;
            }

            double mag1 = Math.Sqrt(mag1Sq);
            double mag2 = Math.Sqrt(mag2Sq);
            double dot = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
            double cosTheta = dot / (mag1 * mag2);

            // Clamp cosTheta to handle potential floating-point inaccuracies
            cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta));

            double angleRad = Math.Acos(cosTheta);
            double interiorAngle = angleRad * (180.0 / Math.PI); // Angle inside the joint vertex

            // Adjust angle based on joint/movement for 0-180 ROM standard
            if (_currentJoint == JointTypeEnum.ElbowAndForearm || _currentJoint == JointTypeEnum.Knee)
            {
                // For Elbow and Knee, ROM is typically measured as the deviation from full extension (180 degrees)
                // The calculated interior angle is the bend angle. We want 180 - bend angle.
                return 180.0 - interiorAngle;
            }
            // For Shoulder and Hip flexion/extension, the interior angle relative to the adjacent segments
            // often aligns with the standard ROM measurement (relative to neutral anatomical position).
            // Ab/Adduction might need further axis definition depending on desired plane.
            return interiorAngle; // Default return for Shoulder/Hip (may need refinement)
        }


        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH)
        {
            int[] limbIndices = GetCalculationIndices();
            if (limbIndices.Length != 3 || joints2D == null || depthBuffer == null) return null; // Ensure exactly 3 indices

            var outPts = new Point3D[3];

            for (int i = 0; i < 3; i++) // Iterate exactly 3 times
            {
                int idx = limbIndices[i];
                if (idx < 0 || idx >= joints2D.Length || joints2D[idx].IsEmpty)
                {
                    outPts[i] = new Point3D { X = 0, Y = 0, Z = 0 }; // Mark as invalid (Z=0)
                    //_jointOcclusionCounters[i] = Math.Min(_jointOcclusionCounters[i] + 1, OcclusionGracePeriod + 1); // Increment counter
                    continue; // Skip to next joint if 2D pose is missing
                }

                PointF p2d = joints2D[idx];
                // Map color (RGB) coords to depth frame coords
                int dx = (int)(p2d.X * depthW / (float)colorW);
                int dy = (int)(p2d.Y * depthH / (float)colorH);

                // Clamp coordinates to be within depth image bounds
                dx = Math.Max(0, Math.Min(dx, depthW - 1));
                dy = Math.Max(0, Math.Min(dy, depthH - 1));

                // Get depth value in millimeters
                short depthMm = depthBuffer[dy * depthW + dx];

                if (depthMm <= 0) // Invalid depth reading
                {
                    outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = 0 }; // Mark as invalid (Z=0)
                    //_jointOcclusionCounters[i] = Math.Min(_jointOcclusionCounters[i] + 1, OcclusionGracePeriod + 1);
                }
                else
                {
                    float depthM = depthMm / 1000.0f; // Convert mm to meters
                    outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = depthM };
                    // _jointOcclusionCounters[i] = 0; // Reset counter on valid reading
                }
            }
            return outPts;
        }


        private PointF[] SmoothJoints(PointF[] newJoints, float alpha)
        {
            if (newJoints == null) return _smoothedJoints; // Return last known if input is null

            // Initialize or resize _smoothedJoints if needed
            if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length)
            {
                _smoothedJoints = (PointF[])newJoints.Clone(); // Start with the first valid frame
                return _smoothedJoints;
            }

            // Apply exponential moving average
            for (int i = 0; i < newJoints.Length; i++)
            {
                // Skip if new joint is invalid
                if (newJoints[i].IsEmpty)
                {
                    // Optionally: decay the smoothed joint towards empty or keep last known?
                    // _smoothedJoints[i] = PointF.Empty; // Option 1: Mark as empty
                    continue; // Option 2: Keep the last smoothed position
                }

                // If the smoothed joint was previously empty, start with the new joint
                if (_smoothedJoints[i].IsEmpty)
                {
                    _smoothedJoints[i] = newJoints[i];
                    continue;
                }

                // Apply smoothing formula
                float newX = alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X;
                float newY = alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y;
                _smoothedJoints[i] = new PointF(newX, newY);
            }
            return _smoothedJoints;
        }


        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints)
        {
            // If new joints are completely invalid, return the last known good set (if any)
            if (newJoints == null || newJoints.Length != 3 || newJoints.All(p => p.Z <= 0))
            {
                // Increment occlusion counters only if the last frame was good
                bool wasGood = _lastGood3DJoints != null && _lastGood3DJoints.All(p => p.Z > 0);
                if (wasGood)
                {
                    for (int i = 0; i < 3; i++) _jointOcclusionCounters[i]++;
                }
                return _lastGood3DJoints; // Return last good pose, might be null
            }

            // Process the current frame: Use new valid points, or fall back to last good point within grace period
            Point3D[] currentFrameCorrected = new Point3D[3];
            bool anyValidInCurrent = false;
            for (int i = 0; i < 3; i++)
            {
                if (newJoints[i].Z > 0) // Current joint is valid
                {
                    currentFrameCorrected[i] = newJoints[i];
                    _jointOcclusionCounters[i] = 0; // Reset counter
                    anyValidInCurrent = true;
                }
                else // Current joint is occluded/invalid
                {
                    _jointOcclusionCounters[i]++; // Increment counter
                                                  // If within grace period AND a previous good pose exists, use the old point
                    if (_jointOcclusionCounters[i] <= OcclusionGracePeriod && _lastGood3DJoints != null && _lastGood3DJoints.Length == 3 && _lastGood3DJoints[i].Z > 0)
                    {
                        currentFrameCorrected[i] = _lastGood3DJoints[i];
                    }
                    else
                    {
                        currentFrameCorrected[i] = new Point3D { X = 0, Y = 0, Z = 0 }; // Mark as invalid
                    }
                }
            }

            // Add the corrected frame to history only if it contained at least one valid new point
            if (anyValidInCurrent)
            {
                _jointHistory3D.Enqueue(currentFrameCorrected);
                while (_jointHistory3D.Count > MovingAverageWindowSize)
                {
                    _jointHistory3D.Dequeue();
                }
                // Update last good pose if the current frame had valid data
                _lastGood3DJoints = currentFrameCorrected;
            }
            // If the current frame was entirely estimated, don't add it to history,
            // but allow averaging to continue based on previous frames.

            // Calculate the moving average from history
            if (_jointHistory3D.Count == 0) return null; // No history yet

            var averageJoints = new Point3D[3];
            for (int i = 0; i < 3; i++)
            {
                float sumX = 0, sumY = 0, sumZ = 0;
                int validCount = 0;
                foreach (var frameJoints in _jointHistory3D)
                {
                    // Only include points that were valid (Z > 0) in the average
                    if (frameJoints != null && frameJoints.Length > i && frameJoints[i].Z > 0)
                    {
                        sumX += frameJoints[i].X;
                        sumY += frameJoints[i].Y;
                        sumZ += frameJoints[i].Z;
                        validCount++;
                    }
                }

                if (validCount > 0)
                {
                    averageJoints[i] = new Point3D { X = sumX / validCount, Y = sumY / validCount, Z = sumZ / validCount };
                }
                else
                {
                    // If no valid points in history for this joint, mark as invalid
                    averageJoints[i] = new Point3D { X = 0, Y = 0, Z = 0 };
                }
            }

            // If the average contains valid points, it becomes the new "last good pose"
            if (averageJoints.Any(p => p.Z > 0))
            {
                _lastGood3DJoints = averageJoints;
            }

            return averageJoints;
        }


        private double SmoothAngleMovingAverage(double newAngle)
        {
            // Add valid angles to history
            if (newAngle >= 0)
            {
                _angleHistory.Enqueue(newAngle);
                // Maintain window size
                while (_angleHistory.Count > MovingAverageWindowSize)
                {
                    _angleHistory.Dequeue();
                }
            }
            // If the new angle is invalid, rely solely on the history average if available
            else if (_angleHistory.Count > 0)
            {
                return _angleHistory.Average();
            }
            // If new angle is invalid and history is empty, return invalid marker
            else
            {
                return -1; // Indicate invalid angle
            }

            // If history is not empty after potentially adding a new angle, return average
            if (_angleHistory.Count > 0)
            {
                return _angleHistory.Average();
            }

            // Should only reach here if the first angle calculation was invalid
            return -1;
        }


        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            Bitmap bmp = null;
            Bitmap displayBmp = null;
            Graphics g = null;
            try
            {
                // Ensure buffer is valid
                if (buffer == null || buffer.Length != w * h * 3) return;

                // Create Bitmap pointing to the buffer memory
                // Critical: Ensure buffer remains pinned/valid while Bitmap uses it.
                // Marshal.UnsafeAddrOfPinnedArrayElement implies buffer won't be moved by GC.
                bmp = new Bitmap(w, h, w * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));

                // Create Graphics object to draw on the bitmap
                g = Graphics.FromImage(bmp);

                // Perform drawing operations
                DrawLimbPose(g, joints2D, joints3D_smoothed);

                // Clone the bitmap for display. This creates a separate copy
                // so the original can be disposed without affecting the displayed image.
                displayBmp = (Bitmap)bmp.Clone();

                // Update the PictureBox on the UI thread
                pictureBoxRgb.Invoke((Action)(() =>
                {
                    pictureBoxRgb.Image?.Dispose(); // Dispose previous image if any
                    pictureBoxRgb.Image = displayBmp; // Set the new image
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Render Error: {ex.ToString()}");
                displayBmp?.Dispose(); // Dispose cloned bitmap if error occurred after cloning
            }
            finally
            {
                // Ensure GDI+ resources are always released
                g?.Dispose();
                bmp?.Dispose(); // Dispose the original bitmap wrapper
            }
        }


        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            if (g == null || joints2D == null) return;

            int[] activeIndices = GetCalculationIndices();
            if (activeIndices.Length != 3) return; // Expecting 3 joints for angle calculation

            const float optimalDepthStart = 0.7f;
            const float optimalDepthEnd = 2.5f;
            const float acceptableMargin = 0.2f;

            Color limbColor = Color.Red; // Default color (low confidence)
            float middleJointDepth = 0;

            // Determine confidence color based on middle joint's depth
            if (joints3D_smoothed != null && joints3D_smoothed.Length == 3 && joints3D_smoothed[1].Z > 0)
            {
                middleJointDepth = joints3D_smoothed[1].Z;
                if (middleJointDepth >= optimalDepthStart && middleJointDepth <= optimalDepthEnd)
                {
                    limbColor = Color.LawnGreen; // Good confidence
                }
                else if (middleJointDepth >= optimalDepthStart - acceptableMargin &&
                         middleJointDepth <= optimalDepthEnd + acceptableMargin)
                {
                    limbColor = Color.Yellow; // Fair confidence
                }
            }
            _lastConfidenceColor = limbColor; // Store for measurement accuracy string
            _bonePen.Color = limbColor;

            // Draw distance feedback text
            string depthText = (middleJointDepth > 0) ? $"Your Distance: {middleJointDepth:F2}m" : "Your Distance: N/A";
            string targetText = $"Good Range: {optimalDepthStart:F1}m - {optimalDepthEnd:F1}m";
            g.FillRectangle(_backBrush, 5, 5, 200, 50); // Background for text
            g.DrawString(depthText, _font, _fontBrush, new PointF(10, 10));
            g.DrawString(targetText, _font, _fontBrush, new PointF(10, 30));


            // Get 2D points safely
            PointF p1 = GetSafeJoint2D(joints2D, activeIndices[0]);
            PointF pVertex = GetSafeJoint2D(joints2D, activeIndices[1]);
            PointF p3 = GetSafeJoint2D(joints2D, activeIndices[2]);

            // Draw bones (lines between joints) if points are valid
            if (!p1.IsEmpty && !pVertex.IsEmpty)
            {
                g.DrawLine(_bonePen, p1, pVertex);
            }
            if (!pVertex.IsEmpty && !p3.IsEmpty)
            {
                g.DrawLine(_bonePen, pVertex, p3);
            }

            // Draw joints (circles) and handle occlusion visualization
            for (int i = 0; i < 3; i++)
            {
                int jointIndex = activeIndices[i];
                PointF p2d = GetSafeJoint2D(joints2D, jointIndex);

                if (!p2d.IsEmpty)
                {
                    // Determine if joint is considered occluded based on counters
                    bool isOccluded = (_jointOcclusionCounters != null && i < _jointOcclusionCounters.Length && _jointOcclusionCounters[i] > OcclusionGracePeriod);
                    _jointBrush.Color = isOccluded ? Color.Red : Color.White; // Red if occluded for too long
                    g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10); // Draw joint circle
                }
                // No need to explicitly draw something if p2d is Empty
            }


            // Draw angle text near the vertex joint if measuring/paused and angle is valid
            if ((_currentState == MeasurementState.Measuring || _currentState == MeasurementState.Paused) && _lastAngleWasValid && !pVertex.IsEmpty)
            {
                double angleToDisplay = (_currentState == MeasurementState.Measuring) ? _lastLiveAngle : _endAngle;
                string angleText = $"{angleToDisplay:F1}°";
                SizeF textSize = g.MeasureString(angleText, _font);
                // Position text box near the vertex, adjust as needed
                RectangleF textRect = new RectangleF(pVertex.X + 15, pVertex.Y - 25, textSize.Width + 10, textSize.Height + 5);
                g.FillRectangle(_backBrush, textRect); // Background for angle text
                g.DrawString(angleText, _font, _fontBrush, textRect.Location.X + 5, textRect.Location.Y + 2.5f);
            }
        }

        private PointF GetSafeJoint2D(PointF[] joints, int index) => (joints != null && index >= 0 && index < joints.Length && !joints[index].IsEmpty) ? joints[index] : PointF.Empty;

        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e)
        {
            // --- NEW: Set closing flag ---
            _isClosing = true; // Set flag to prevent issues during close

            _sdkTimer?.Stop();
            // Wrap SDK disposal in try-catch to prevent errors during shutdown
            try
            {
                _colorStream?.Stop();
                _depthStream?.Stop();
                _reader?.Dispose();
                _streamSet?.Dispose();
                Context.Terminate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during SDK cleanup: {ex.Message}");
            }
            // Dispose other resources
            _moveNet?.Dispose();
            _font?.Dispose();
            _fontBrush?.Dispose();
            _backBrush?.Dispose();
            _jointBrush?.Dispose();
            _bonePen?.Dispose();
        }

        private void btnSaveAssessment_Click(object sender, EventArgs e)
        {
            // 1. Check if there's valid data to save (measurement must be paused/complete)
            if (_currentState != MeasurementState.Paused || _endAngle == 0) // Check _endAngle too
            {
                MessageBox.Show("Please complete a measurement (Start and then Stop) before saving.", "Measurement Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Get the data to save
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string side = _currentSide.ToString();
            string joint = GetSelectedJointString(); // Use helper
            string movement = GetSelectedMovementString(); // Use helper

            // Ensure confidence strings are captured correctly
            string startAngleStr = $"{_initialAngle:F1}° (Accuracy: {_initialConfidence})";
            string endAngleStr = $"{_endAngle:F1}° (Accuracy: {_endConfidence})";

            string normalRangeStr = lblNormalRange.Text; // Get text directly from label
            string deficitStr = lblDeficit.Text;         // Get text directly from label

            // Check if essential data is missing (shouldn't happen if state is Paused, but good practice)
            if (string.IsNullOrEmpty(joint) || string.IsNullOrEmpty(movement))
            {
                MessageBox.Show("Cannot save: Joint or Movement information is missing.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


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

                        // 5. Find the next empty row robustly
                        int nextRow = 1; // Default to row 1
                        if (worksheet.LastRowUsed() != null)
                        {
                            nextRow = worksheet.LastRowUsed().RowNumber() + 1;
                        }

                        // If starting a new sheet (nextRow is 1), add headers and set data row to 2
                        if (nextRow == 1)
                        {
                            // Double-check if headers are truly missing even if LastRowUsed is null
                            if (worksheet.Cell(1, 1).IsEmpty())
                            {
                                AddHeaders(worksheet);
                            }
                            nextRow = 2; // Data always starts at row 2 if headers are present/added
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

                        // Optionally, reset after saving
                        // ResetMeasurementState();
                        // cmbLimbSelection.Enabled = true;
                        // cmbJointSelection.Enabled = _currentSide != BodySide.None;
                        // cmbMovementSelection.Enabled = _currentJoint != JointTypeEnum.None;

                    }
                    catch (IOException ioEx) // Handle file access issues specifically
                    {
                        MessageBox.Show($"Failed to save assessment data. The file might be open in another program.\nError: {ioEx.Message}", "File Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // General error handler
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