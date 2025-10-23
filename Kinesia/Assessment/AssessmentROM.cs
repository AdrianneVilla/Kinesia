using Astra;
using Astra.Core;
using KinesiaLibrary.DTOs.ROMDTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kinesia.Assessment
{
    public partial class AssessmentROM : Form
    {
        // Enums for managing state
        private enum BodySide { None, Right, Left }
        // Updated JointType Enum
        private enum JointType { None, Shoulder, Elbow, Hip, Knee }
        private enum MovementType { None, Flexion, Extension }
        private enum MeasurementState { Idle, Measuring, Paused }

        // Current state variables
        private MeasurementState _currentState = MeasurementState.Idle;
        private BodySide _currentSide = BodySide.None;
        private JointType _currentJoint = JointType.None;
        private MovementType _currentMovement = MovementType.None;
        private string _currentExtremity = ""; // Store the extremity string

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
        private const int OcclusionGracePeriod = 5; // Frames before marking joint red
        private int[] _jointOcclusionCounters = new int[3]; // Track occlusion per relevant joint

        // GDI+ drawing resources
        private Font _font;
        private SolidBrush _fontBrush;
        private SolidBrush _backBrush;
        private SolidBrush _jointBrush;
        private Pen _bonePen;

        public AssessmentROM()
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
            _backBrush = new SolidBrush(Color.FromArgb(150, Color.Black)); // Semi-transparent black
            _jointBrush = new SolidBrush(Color.White); // Default joint color
            _bonePen = new Pen(Color.Red, 4); // Default bone color (changes based on confidence)

            // --- Read Assessment Details ---
            _currentExtremity = PageObjects.assessmentDetails.Extremity;
            string jointName = PageObjects.assessmentDetails.Joint;
            string sideName = PageObjects.assessmentDetails.JointSide;

            // Map side string to enum
            if (sideName.Equals("Right", StringComparison.OrdinalIgnoreCase))
                _currentSide = BodySide.Right;
            else if (sideName.Equals("Left", StringComparison.OrdinalIgnoreCase))
                _currentSide = BodySide.Left;
            else
                _currentSide = BodySide.None; // Handle error or default

            // Map joint string to enum
            if (jointName.Equals("Shoulder", StringComparison.OrdinalIgnoreCase))
                _currentJoint = JointType.Shoulder;
            else if (jointName.Equals("Elbow and forearm", StringComparison.OrdinalIgnoreCase)) // Handle specific string
                _currentJoint = JointType.Elbow;
            else if (jointName.Equals("Hip", StringComparison.OrdinalIgnoreCase))
                _currentJoint = JointType.Hip;
            else if (jointName.Equals("Knee", StringComparison.OrdinalIgnoreCase))
                _currentJoint = JointType.Knee;
            else
                _currentJoint = JointType.None; // Handle error or default

            // --- Setup Movement ComboBox ---
            SetupMovementSelectionBasedOnDetails();

            // --- Initialize MoveNet ---
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

            // --- Initialize Astra SDK ---
            Context.Initialize();
            _streamSet = StreamSet.Open();
            _reader = _streamSet.CreateReader();
            _colorStream = _reader.GetStream<ColorStream>();
            _depthStream = _reader.GetStream<DepthStream>();
            _colorStream.Start();
            _depthStream.Start();

            // --- Start the main processing timer ---
            _sdkTimer = new System.Windows.Forms.Timer { Interval = 33 }; // ~30 FPS
            _sdkTimer.Tick += SdkTimer_Tick;
            _sdkTimer.Start();

            ResetMeasurementState(); // Initialize labels and state
        }

        // --- New Method to Setup Movement ComboBox ---
        private void SetupMovementSelectionBasedOnDetails()
        {
            cmbMovementSelection.Enabled = false; // Disable until a valid joint is set
            cmbMovementSelection.Items.Clear();
            cmbMovementSelection.Items.Add("Select movement"); // Placeholder

            if (_currentJoint != JointType.None)
            {
                // Add Flexion and Extension for all supported joints based on your list
                cmbMovementSelection.Items.Add("Flexion");
                cmbMovementSelection.Items.Add("Extension");
                cmbMovementSelection.Enabled = true; // Enable the combo box
            }
            else
            {
                cmbMovementSelection.Items.Clear();
                cmbMovementSelection.Items.Add("Joint not set"); // Error state
            }
            cmbMovementSelection.SelectedIndex = 0; // Select placeholder
            _currentMovement = MovementType.None; // Reset current movement
        }

        // --- Kept Movement Selection Handler ---
        private void cmbMovementSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovementSelection.SelectedIndex > 0)
            {
                string selection = cmbMovementSelection.SelectedItem.ToString();
                if (Enum.TryParse(selection, out MovementType movement))
                {
                    _currentMovement = movement;
                }
                else
                {
                    _currentMovement = MovementType.None; // Should not happen if items are correct
                }
            }
            else
            {
                _currentMovement = MovementType.None;
            }
            // Reset measurement only if a new movement is selected or deselected
            if (_currentState != MeasurementState.Idle)
            {
                ResetMeasurementState();
            }
        }

        private void SdkTimer_Tick(object sender, EventArgs e)
        {
            // Don't process if paused or no valid movement is selected
            if (_currentState == MeasurementState.Paused || _currentMovement == MovementType.None) return;

            Context.Update();

            if (!_reader.TryOpenFrame(0, out var frame)) return;

            ColorFrame cf = null;
            DepthFrame df = null;

            try
            {
                cf = frame.GetFrame<ColorFrame>();
                df = frame.GetFrame<DepthFrame>();

                // Process Color Frame and Run MoveNet Inference
                PointF[] rawJoints = null;
                if (cf != null && cf.Width > 0 && cf.DataPtr != IntPtr.Zero)
                {
                    int colorLength = cf.Width * cf.Height * 3;
                    if (_colorBuffer == null || _colorBuffer.Length != colorLength)
                        _colorBuffer = new byte[colorLength];
                    cf.CopyData(ref _colorBuffer);

                    // BGR -> RGB conversion (inplace)
                    for (int i = 0; i < _colorBuffer.Length; i += 3)
                    {
                        byte temp = _colorBuffer[i];
                        _colorBuffer[i] = _colorBuffer[i + 2];
                        _colorBuffer[i + 2] = temp;
                    }

                    // Run Inference
                    var keypointsTensor = _moveNet.RunInference(_colorBuffer, cf.Width, cf.Height);
                    rawJoints = _moveNet.ExtractKeypoints(keypointsTensor, cf.Width, cf.Height);
                    _smoothedJoints = SmoothJoints(rawJoints, 0.5f); // Smooth 2D keypoints
                }

                // Process Depth Frame and Calculate 3D Pose/Angle
                Point3D[] smoothedLimb3D = null;
                if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero && _smoothedJoints != null && cf != null)
                {
                    int depthCount = df.Width * df.Height;
                    if (_depthBuffer == null || _depthBuffer.Length != depthCount)
                        _depthBuffer = new short[depthCount];

                    df.CopyData(ref _depthBuffer);
                    MedianFilter(_depthBuffer, df.Width, df.Height); // Apply filter to depth data

                    // Get 3D pose for the relevant limb
                    var rawLimb3D = GetLimb3DPose(_smoothedJoints, _depthBuffer, df.Width, df.Height, cf.Width, cf.Height);
                    smoothedLimb3D = Smooth3DJointsMovingAverage(rawLimb3D); // Smooth 3D keypoints

                    // Calculate Angle
                    if (smoothedLimb3D != null && smoothedLimb3D.Length == 3) // Ensure we have 3 points for angle calc
                    {
                        double limbAngle = CalculateAngle3D(smoothedLimb3D[0], smoothedLimb3D[1], smoothedLimb3D[2]);
                        if (limbAngle >= 0) // Check if angle calculation was valid (all points had depth > 0)
                        {
                            _lastLiveAngle = SmoothAngleMovingAverage(limbAngle); // Smooth the final angle
                            _lastAngleWasValid = true;
                        }
                        else
                        {
                            _lastAngleWasValid = false; // Mark angle as invalid if calculation failed
                        }
                    }
                    else
                    {
                        _lastAngleWasValid = false; // Mark angle as invalid if 3D pose extraction failed
                    }
                }
                else
                {
                    _lastAngleWasValid = false; // Mark angle invalid if depth or color frame missing
                }


                // Render the color frame with overlays
                if (cf != null && _colorBuffer != null)
                {
                    RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, _smoothedJoints, smoothedLimb3D);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during frame processing: {ex.ToString()}");
                // Potentially log the error or show a user-friendly message
            }
            finally
            {
                // Only dispose the main frame object
                frame.Dispose();
                // Individual frames like cf, df are managed by the SDK/ReaderFrame
            }
        }

        private void btnStartStopMeasurement_Click(object sender, EventArgs e)
        {
            switch (_currentState)
            {
                case MeasurementState.Idle:
                    // Check if a movement is selected
                    if (_currentMovement == MovementType.None)
                    {
                        MessageBox.Show("Please select a movement type first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Check if the last calculated angle was valid
                    if (_lastAngleWasValid)
                    {
                        _initialAngle = _lastLiveAngle;
                        _initialConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblInitialROM.Text = $"{_initialAngle:F1}° ({_initialConfidence})"; // Updated: Removed "Initial:"
                        lblEndROM.Text = ""; // Updated: Ensure End is blank
                        btnStartStopMeasurement.Text = "Stop Measurement";
                        _currentState = MeasurementState.Measuring;
                        // Clear history for the new measurement phase
                        ResetSmoothingFilters();
                    }
                    else
                    {
                        MessageBox.Show("Cannot start measurement. A required joint is hidden or too far/close.", "Joint Occluded/Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MeasurementState.Measuring:
                    // Check if the last calculated angle was valid
                    if (_lastAngleWasValid)
                    {
                        _endAngle = _lastLiveAngle;
                        _endConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblEndROM.Text = $"{_endAngle:F1}° ({_endConfidence})"; // Updated: Removed "End:"
                        btnStartStopMeasurement.Text = "New Measurement";
                        _currentState = MeasurementState.Paused; // Pause to allow saving or starting new
                    }
                    else
                    {
                        MessageBox.Show("Cannot stop measurement. A required joint is hidden or too far/close.", "Joint Occluded/Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MeasurementState.Paused:
                    // Reset everything to start fresh
                    ResetMeasurementState();
                    break;
            }
        }

        private string GetConfidenceString(Color color)
        {
            if (color == Color.LawnGreen) return "Good";
            if (color == Color.Yellow) return "Fair";
            return "Low"; // Corresponds to Red
        }

        // --- Updated ResetMeasurementState ---
        private void ResetMeasurementState()
        {
            _currentState = MeasurementState.Idle;
            btnStartStopMeasurement.Text = "Start Measurement";
            lblInitialROM.Text = ""; // Updated: Set to blank
            lblEndROM.Text = "";     // Updated: Set to blank
            _initialAngle = 0;
            _endAngle = 0;
            _initialConfidence = "N/A";
            _endConfidence = "N/A";
            ResetSmoothingFilters(); // Clear angle and joint history
        }

        // --- Updated GetCalculationIndices Method (Left/Right Swapped) ---
        private int[] GetCalculationIndices()
        {
            bool userSelectedRight = (_currentSide == BodySide.Right);

            // MoveNet Keypoint Indices:
            // 0: nose, 1: left_eye, 2: right_eye, 3: left_ear, 4: right_ear,
            // 5: left_shoulder, 6: right_shoulder, 7: left_elbow, 8: right_elbow,
            // 9: left_wrist, 10: right_wrist, 11: left_hip, 12: right_hip,
            // 13: left_knee, 14: right_knee, 15: left_ankle, 16: right_ankle

            switch (_currentJoint)
            {
                case JointType.Elbow: // Shoulder, Elbow, Wrist
                    // If Right selected, use LEFT indices (5, 7, 9). If Left selected, use RIGHT indices (6, 8, 10)
                    return userSelectedRight ? new[] { 5, 7, 9 } : new[] { 6, 8, 10 };
                case JointType.Shoulder: // Hip, Shoulder, Elbow
                    // If Right selected, use LEFT indices (11, 5, 7). If Left selected, use RIGHT indices (12, 6, 8)
                    return userSelectedRight ? new[] { 11, 5, 7 } : new[] { 12, 6, 8 };
                case JointType.Hip: // Shoulder, Hip, Knee
                    // If Right selected, use LEFT indices (5, 11, 13). If Left selected, use RIGHT indices (6, 12, 14)
                    return userSelectedRight ? new[] { 5, 11, 13 } : new[] { 6, 12, 14 };
                case JointType.Knee: // Hip, Knee, Ankle
                    // If Right selected, use LEFT indices (11, 13, 15). If Left selected, use RIGHT indices (12, 14, 16)
                    return userSelectedRight ? new[] { 11, 13, 15 } : new[] { 12, 14, 16 };
            }
            return new int[0]; // Return empty if no valid joint is selected
        }

        private void ResetSmoothingFilters()
        {
            _angleHistory.Clear();
            _jointHistory3D.Clear();
            _lastGood3DJoints = null;
            // Ensure array exists before clearing
            if (_jointOcclusionCounters == null || _jointOcclusionCounters.Length != 3)
                _jointOcclusionCounters = new int[3];
            else
                Array.Clear(_jointOcclusionCounters, 0, _jointOcclusionCounters.Length);
        }


        // --- Median Filter for Depth Data ---
        private void MedianFilter(short[] data, int width, int height)
        {
            var tempData = (short[])data.Clone();
            var window = new List<short>(9); // 3x3 window
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    window.Clear();
                    // Collect valid (non-zero) depth values in the 3x3 neighborhood
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            short val = tempData[(y + j) * width + (x + i)];
                            if (val > 0) // Only consider valid depth readings
                            {
                                window.Add(val);
                            }
                        }
                    }
                    // If we have valid neighbors, find the median
                    if (window.Count > 0)
                    {
                        window.Sort();
                        data[y * width + x] = window[window.Count / 2]; // Use median value
                    }
                    // If no valid neighbors, leave the original value (might be 0)
                }
            }
        }

        // --- Calculate 3D Angle ---
        private double CalculateAngle3D(Point3D p1, Point3D p2_vertex, Point3D p3)
        {
            // Check if any point has zero depth (likely invalid/occluded)
            if (p1.Z <= 0.1 || p2_vertex.Z <= 0.1 || p3.Z <= 0.1) // Use a small threshold > 0
            {
                Debug.WriteLine($"Invalid depth for angle calculation: P1.Z={p1.Z}, P2.Z={p2_vertex.Z}, P3.Z={p3.Z}");
                return -1; // Indicate invalid angle
            }


            // Vectors from vertex P2 to P1 and P3
            Point3D vector1 = new Point3D { X = p1.X - p2_vertex.X, Y = p1.Y - p2_vertex.Y, Z = p1.Z - p2_vertex.Z };
            Point3D vector2 = new Point3D { X = p3.X - p2_vertex.X, Y = p3.Y - p2_vertex.Y, Z = p3.Z - p2_vertex.Z };

            // Magnitudes of vectors
            double magnitude1 = Math.Sqrt((vector1.X * vector1.X) + (vector1.Y * vector1.Y) + (vector1.Z * vector1.Z));
            double magnitude2 = Math.Sqrt((vector2.X * vector2.X) + (vector2.Y * vector2.Y) + (vector2.Z * vector2.Z));

            // Avoid division by zero
            if (magnitude1 == 0 || magnitude2 == 0)
            {
                Debug.WriteLine("Magnitude is zero, cannot calculate angle.");
                return -1; // Indicate invalid angle
            }


            // Dot product
            double dotProduct = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);

            // Cosine of the angle
            double cosTheta = dotProduct / (magnitude1 * magnitude2);

            // Clamp cosTheta to [-1, 1] to avoid Math.Acos domain errors due to floating point inaccuracies
            cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta));

            // Angle in radians, then degrees
            double angleRad = Math.Acos(cosTheta);
            double interiorAngle = angleRad * (180.0 / Math.PI);

            // Adjust angle based on joint type (e.g., Elbow/Knee are often measured as 180 - interior)
            if (_currentJoint == JointType.Elbow || _currentJoint == JointType.Knee)
            {
                return 180.0 - interiorAngle; // Standard convention for flexion/extension
            }
            // For Shoulder/Hip, the interior angle might be what's needed for Flexion/Extension relative to trunk/hip line.
            // This might need refinement based on precise PT definitions.
            return interiorAngle;
        }


        // --- Get 3D Pose for Selected Limb ---
        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH)
        {
            int[] limbIndices = GetCalculationIndices();
            if (limbIndices.Length == 0) return null; // No joint selected or invalid

            var outPts = new Point3D[limbIndices.Length]; // Should always be 3
            bool allPointsValid = true;

            for (int i = 0; i < limbIndices.Length; i++)
            {
                int idx = limbIndices[i];

                // Check if the 2D joint index is valid and the joint was detected
                if (idx >= joints2D.Length || joints2D[idx].IsEmpty)
                {
                    outPts[i] = new Point3D { X = 0, Y = 0, Z = 0 }; // Mark as invalid
                    allPointsValid = false;
                    _jointOcclusionCounters[i]++; // Increment occlusion counter
                    continue; // Skip depth lookup if 2D point is missing
                }

                PointF p2d = joints2D[idx];

                // Map 2D color coordinates to depth coordinates
                int dx = (int)(p2d.X * depthW / (float)colorW);
                int dy = (int)(p2d.Y * depthH / (float)colorH);

                // Clamp coordinates to be within depth image bounds
                dx = Math.Max(0, Math.Min(dx, depthW - 1));
                dy = Math.Max(0, Math.Min(dy, depthH - 1));

                // Get depth value (in millimeters)
                short depthInMm = depthBuffer[dy * depthW + dx];

                // Check if depth value is valid (greater than zero)
                if (depthInMm <= 0) // Invalid depth reading
                {
                    outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = 0 }; // Mark Z as 0 for invalid depth
                    allPointsValid = false;
                    _jointOcclusionCounters[i]++;
                }
                else
                {
                    // Convert depth to meters
                    float depthInMeters = depthInMm / 1000.0f;
                    outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = depthInMeters };
                    _jointOcclusionCounters[i] = 0; // Reset occlusion counter if valid depth found
                }
            }

            // Return the points; the angle calculation will handle Z=0 checks
            return outPts;
        }


        // --- EMA Smoothing for 2D Joints ---
        private PointF[] SmoothJoints(PointF[] newJoints, float alpha)
        {
            // Initialize or resize smoothing buffer if necessary
            if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length)
            {
                _smoothedJoints = (PointF[])newJoints.Clone();
                return _smoothedJoints; // Return initial points on first call
            }

            // Apply Exponential Moving Average
            for (int i = 0; i < newJoints.Length; i++)
            {
                // If new joint is undetected, keep the smoothed value
                if (newJoints[i].IsEmpty)
                {
                    // Optionally, you could mark the smoothed joint as empty too,
                    // but keeping the last known position might be visually smoother.
                    continue;
                }
                // If smoothed joint was previously empty, use the new one directly
                if (_smoothedJoints[i].IsEmpty)
                {
                    _smoothedJoints[i] = newJoints[i];
                    continue;
                }

                // Apply smoothing formula: smoothed = alpha * new + (1 - alpha) * previous_smoothed
                float newX = alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X;
                float newY = alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y;
                _smoothedJoints[i] = new PointF(newX, newY);
            }
            return _smoothedJoints;
        }

        // --- Moving Average Smoothing for 3D Joints ---
        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints)
        {
            // If the new measurement is invalid (e.g., points missing), return the last known good average
            if (newJoints == null || newJoints.Any(p => p.Z <= 0)) // Check if any joint has invalid depth
            {
                // Increment occlusion counters for affected joints if needed (handled in GetLimb3DPose)
                return _lastGood3DJoints; // Return the last valid smoothed position
            }

            // Add the valid new set of joints to the history queue
            _jointHistory3D.Enqueue(newJoints);

            // Maintain the window size by removing the oldest entry if the queue is too large
            while (_jointHistory3D.Count > MovingAverageWindowSize)
            {
                _jointHistory3D.Dequeue();
            }

            // Should not happen if we enqueue first, but safety check
            if (_jointHistory3D.Count == 0) return newJoints; // Or return null/lastGood

            // Calculate the average over the window
            var averageJoints = new Point3D[newJoints.Length]; // Assuming all frames in queue have same length
            for (int i = 0; i < newJoints.Length; i++) // Iterate through each joint index (0, 1, 2)
            {
                float sumX = 0, sumY = 0, sumZ = 0;
                int validCount = 0;
                // Sum up positions for joint 'i' across all frames in the history window
                foreach (var frameJoints in _jointHistory3D)
                {
                    // Ensure the frame has this joint and it's valid (Z > 0)
                    if (frameJoints.Length > i && frameJoints[i].Z > 0)
                    {
                        sumX += frameJoints[i].X;
                        sumY += frameJoints[i].Y;
                        sumZ += frameJoints[i].Z;
                        validCount++;
                    }
                }

                // Calculate the average if we have valid data
                if (validCount > 0)
                {
                    averageJoints[i] = new Point3D { X = sumX / validCount, Y = sumY / validCount, Z = sumZ / validCount };
                }
                // If no valid data in the window for this joint, fall back to the last known good position or mark invalid
                else if (_lastGood3DJoints != null && _lastGood3DJoints.Length > i)
                {
                    averageJoints[i] = _lastGood3DJoints[i]; // Use last good average
                }
                else
                {
                    averageJoints[i] = new Point3D { X = 0, Y = 0, Z = 0 }; // Mark as invalid
                }
            }

            _lastGood3DJoints = averageJoints; // Store this average as the last known good set
            return averageJoints;
        }

        // --- Moving Average Smoothing for Angle ---
        private double SmoothAngleMovingAverage(double newAngle)
        {
            // Only add valid angles to the history
            if (newAngle >= 0)
            {
                _angleHistory.Enqueue(newAngle);

                // Maintain the window size
                while (_angleHistory.Count > MovingAverageWindowSize)
                {
                    _angleHistory.Dequeue();
                }
            }
            // If history is empty (e.g., first valid frame), return the current angle
            if (_angleHistory.Count == 0) return newAngle >= 0 ? newAngle : 0; // Return 0 if current is also invalid

            // Calculate and return the average of angles in the history
            return _angleHistory.Average();
        }


        // --- Rendering Method ---
        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            Bitmap bmp = null;
            Bitmap displayBmp = null;
            try
            {
                // Create a Bitmap wrapper around the RGB buffer
                // IMPORTANT: Ensure buffer is RGB format here, not BGR
                bmp = new Bitmap(w, h, w * 3, // Stride = width * 3 bytes (for 24bpp)
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                    Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0)); // Direct pointer to buffer

                // Create Graphics object to draw on the bitmap
                using (var g = Graphics.FromImage(bmp))
                {
                    // Draw the pose overlay using the helper method
                    DrawLimbPose(g, joints2D, joints3D_smoothed);
                }

                // Clone the bitmap for display (avoids issues with GDI+ object ownership)
                displayBmp = (Bitmap)bmp.Clone();

                // Update the PictureBox on the UI thread
                pictureBoxRgb.Invoke((Action)(() =>
                {
                    // Dispose the previous image to free memory
                    if (pictureBoxRgb.Image != null)
                        pictureBoxRgb.Image.Dispose();
                    // Set the new image
                    pictureBoxRgb.Image = displayBmp;
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during rendering: {ex.ToString()}");
                displayBmp?.Dispose(); // Clean up clone if Invoke failed
                                       // Avoid disposing bmp here if it's just a wrapper
            }
            finally
            {
                // Dispose the original Bitmap wrapper IF it was created with `new Bitmap(...)` from scratch,
                // but NOT if it's just wrapping the Marshal pointer. In this case, we don't dispose bmp.
                // bmp?.Dispose(); // Potentially incorrect if bmp wraps the buffer directly.
            }
        }

        // --- Drawing Helper Method ---
        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed)
        {
            if (joints2D == null) return;
            int[] activeIndices = GetCalculationIndices(); // Get indices for Shoulder, Elbow, Wrist OR Hip, Knee, Ankle etc.
            if (activeIndices.Length < 3) return; // Need 3 points to draw limb/angle

            // --- Determine Bone Color based on Depth Confidence ---
            const float optimalDepthStart = 0.7f; // meters
            const float optimalDepthEnd = 2.5f; // meters
            const float acceptableMargin = 0.2f; // meters buffer zone

            Color limbColor = Color.Red; // Default to low confidence
            float middleJointDepth = 0; // Depth of the vertex joint (Elbow or Knee)

            if (joints3D_smoothed != null && joints3D_smoothed.Length > 1 && joints3D_smoothed[1].Z > 0) // Check vertex joint (index 1)
            {
                middleJointDepth = joints3D_smoothed[1].Z;
                if (middleJointDepth >= optimalDepthStart && middleJointDepth <= optimalDepthEnd)
                    limbColor = Color.LawnGreen; // Good range
                else if (middleJointDepth >= optimalDepthStart - acceptableMargin && middleJointDepth <= optimalDepthEnd + acceptableMargin)
                    limbColor = Color.Yellow; // Fair range
                else
                    limbColor = Color.Red; // Out of acceptable range
            }
            _lastConfidenceColor = limbColor; // Store for recording confidence
            _bonePen.Color = limbColor; // Update the pen color

            // --- Draw Bones ---
            // Draw bone between joint 0 and joint 1
            if (joints2D.Length > activeIndices[0] && !joints2D[activeIndices[0]].IsEmpty &&
                joints2D.Length > activeIndices[1] && !joints2D[activeIndices[1]].IsEmpty)
            {
                g.DrawLine(_bonePen, joints2D[activeIndices[0]], joints2D[activeIndices[1]]);
            }
            // Draw bone between joint 1 and joint 2
            if (joints2D.Length > activeIndices[1] && !joints2D[activeIndices[1]].IsEmpty &&
                joints2D.Length > activeIndices[2] && !joints2D[activeIndices[2]].IsEmpty)
            {
                g.DrawLine(_bonePen, joints2D[activeIndices[1]], joints2D[activeIndices[2]]);
            }


            // --- Draw Joints (Circles) ---
            for (int i = 0; i < activeIndices.Length; i++)
            {
                int jointIndex = activeIndices[i];
                if (joints2D.Length > jointIndex && !joints2D[jointIndex].IsEmpty)
                {
                    PointF p2d = joints2D[jointIndex];

                    // Determine if joint is considered occluded based on counters
                    bool isOccluded = (_jointOcclusionCounters[i] > OcclusionGracePeriod);
                    Color jointColor = isOccluded ? Color.Red : Color.White; // Red if occluded for too long
                    _jointBrush.Color = jointColor;

                    g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10); // Draw joint circle
                }
            }

            // --- Draw Distance Feedback Text ---
            if (middleJointDepth > 0) // Only show if depth is valid
            {
                string depthText = $"Your Distance: {middleJointDepth:F2}m";
                string targetText = $"Good Range: {optimalDepthStart:F1}m - {optimalDepthEnd:F1}m";
                g.FillRectangle(_backBrush, 5, 5, 200, 50); // Background rectangle
                g.DrawString(depthText, _font, _fontBrush, new PointF(10, 10));
                g.DrawString(targetText, _font, _fontBrush, new PointF(10, 30));
            }

            // --- Draw Angle Text ---
            // Show angle only when measuring or paused, and if the angle is valid
            if ((_currentState == MeasurementState.Measuring || _currentState == MeasurementState.Paused) && _lastAngleWasValid)
            {
                // Get the position of the vertex joint (Elbow or Knee)
                PointF vertexPoint = joints2D[activeIndices[1]];
                if (!vertexPoint.IsEmpty)
                {
                    // Decide which angle to display (live or final)
                    double angleToDisplay = (_currentState == MeasurementState.Measuring) ? _lastLiveAngle : _endAngle;
                    string angleText = $"{angleToDisplay:F1}°"; // Format angle to one decimal place

                    // Calculate text position near the vertex joint
                    SizeF textSize = g.MeasureString(angleText, _font);
                    RectangleF textRect = new RectangleF(
                        vertexPoint.X + 15, // Offset from joint
                        vertexPoint.Y - 25,
                        textSize.Width + 10, // Padding
                        textSize.Height + 5);

                    g.FillRectangle(_backBrush, textRect); // Background for readability
                    g.DrawString(angleText, _font, _fontBrush, textRect.Location.X + 5, textRect.Location.Y + 2.5f); // Draw text
                }
            }
        }


        // --- Cleanup Method ---
        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sdkTimer?.Stop();
            // Check if objects are null before disposing
            _reader?.Dispose();
            _streamSet?.Dispose();
            _moveNet?.Dispose();

            // Dispose GDI+ resources
            _font?.Dispose();
            _fontBrush?.Dispose();
            _backBrush?.Dispose();
            _jointBrush?.Dispose();
            _bonePen?.Dispose();

            Context.Terminate(); // Shutdown Astra SDK
        }

        private async void btnSaveROM_Click(object sender, EventArgs e)
        {
            if (_currentState != MeasurementState.Paused)
            {
                MessageBox.Show("Please complete a measurement (Start and then Stop) before saving.",
                                  "Measurement Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbMotionType.SelectedIndex < 0 || cbMotionType.SelectedItem == null)
            {
                MessageBox.Show("Please select a Motion Type.",
                                 "Motion Type Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newROM = new AddROMDTO
            {
                AssessmentID = PageObjects.assessmentDetails.AssessmentID,
                UserID = SessionManager.UserID,
                GoniometerType = "Astra Camera",
                InitialROM = _initialAngle,
                EndROM = _endAngle,
                Movement = _currentMovement.ToString(),
                MotionType = cbMotionType.Texts,
                Subjective = txtSubjective.Texts.Trim(),
                Objective = txtObjective.Texts.Trim(),
                Deviation = txtDeviation.Texts.Trim(),
            };

            var success = await Queries.ROMQueries.AddROM(newROM);

            if (success)
            {
                MessageBox.Show("Range of Motion data saved successfully!",
                              "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await Queries.LogsQueries.AddLog($"has added ROM for {newROM.AssessmentID}", "ROM");
                this.Close();
            }
        }
    }
}