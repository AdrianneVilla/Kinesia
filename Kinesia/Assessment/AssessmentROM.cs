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
using System.Threading.Tasks; // Added for async Task
using System.Windows.Forms;
using KinesiaLibrary.DTOs.ROMDTOs; // For AddROMDTO
using KinesiaLibrary;
using System.ServiceModel.Channels;             // Added for ROMHelper

namespace Kinesia.Assessment
{

    public partial class AssessmentROM : Form
    {
        // Enums for managing state
        private enum BodySide { None, Right, Left }
        private enum JointType { None, Shoulder, Elbow, Hip, Knee }
        private enum MovementType { None, Flexion, Extension }
        private enum MeasurementState { Idle, Measuring, Paused }

        // Current state variables
        private MeasurementState _currentState = MeasurementState.Idle;
        private BodySide _currentSide = BodySide.None;
        private JointType _currentJoint = JointType.None;
        private MovementType _currentMovement = MovementType.None;
        private string _currentExtremity = "";
        private string _currentJointName = ""; // Added to store joint name string

        // ROM measurement variables
        private double _initialAngle = 0; // Corresponds to Starting Position
        private double _endAngle = 0;     // Corresponds to ROM
        private double _lastLiveAngle = 0;
        private bool _lastAngleWasValid = false;
        private Color _lastConfidenceColor = Color.Red;
        private string _initialConfidence = "N/A";
        private string _endConfidence = "N/A";

        // 3D Point Structure remains the same...
        private struct Point3D { public float X, Y, Z; public override string ToString() => $"({X:F2}, {Y:F2}, {Z:F2}m)"; }

        // Astra SDK components remain the same...
        private StreamSet _streamSet;
        private Astra.StreamReader _reader;
        private ColorStream _colorStream;
        private DepthStream _depthStream;
        private System.Windows.Forms.Timer _sdkTimer;

        // Data buffers remain the same...
        private byte[] _colorBuffer;
        private short[] _depthBuffer;

        // MoveNet components remain the same...
        private MoveNet _moveNet;
        private string _modelPath;
        private const string ModelFileName = "model.onnx";

        // Smoothing components remain the same...
        private PointF[] _smoothedJoints;
        private int MovingAverageWindowSize = 5;
        private readonly Queue<double> _angleHistory = new Queue<double>();
        private readonly Queue<Point3D[]> _jointHistory3D = new Queue<Point3D[]>();
        private Point3D[] _lastGood3DJoints;
        private const int OcclusionGracePeriod = 5;
        private int[] _jointOcclusionCounters = new int[3];

        // GDI+ drawing resources remain the same...
        private Font _font;
        private SolidBrush _fontBrush;
        private SolidBrush _backBrush;
        private SolidBrush _jointBrush;
        private Pen _bonePen;


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

            // Initialize drawing tools
            _font = new Font("Arial", 10, FontStyle.Bold);
            _fontBrush = new SolidBrush(Color.White);
            _backBrush = new SolidBrush(Color.FromArgb(150, Color.Black));
            _jointBrush = new SolidBrush(Color.White);
            _bonePen = new Pen(Color.Red, 4);

            // --- Read Assessment Details ---
            _currentExtremity = PageObjects.assessmentDetails.Extremity;
            _currentJointName = PageObjects.assessmentDetails.Joint; // Store the joint name string
            string sideName = PageObjects.assessmentDetails.JointSide;

            // Map side string to enum
            _currentSide = sideName.Equals("Right", StringComparison.OrdinalIgnoreCase) ? BodySide.Right :
                           sideName.Equals("Left", StringComparison.OrdinalIgnoreCase) ? BodySide.Left : BodySide.None;

            // Map joint string to enum
            _currentJoint = _currentJointName.Equals("Shoulder", StringComparison.OrdinalIgnoreCase) ? JointType.Shoulder :
                            _currentJointName.Equals("Elbow and forearm", StringComparison.OrdinalIgnoreCase) ? JointType.Elbow :
                            _currentJointName.Equals("Hip", StringComparison.OrdinalIgnoreCase) ? JointType.Hip :
                            _currentJointName.Equals("Knee", StringComparison.OrdinalIgnoreCase) ? JointType.Knee : JointType.None;

            // --- Setup Movement ComboBox ---
            SetupMovementSelectionBasedOnDetails();

            // --- Initialize MoveNet --- (No changes here)
            if (File.Exists(_modelPath)) { try { _moveNet = new MoveNet(_modelPath); } catch (Exception ex) { MessageBox.Show($"Failed to load MoveNet model: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); return; } } else { MessageBox.Show($"Model file not found at: {_modelPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); this.Close(); return; }

            // --- Initialize Astra SDK --- (No changes here)
            Context.Initialize(); _streamSet = StreamSet.Open(); _reader = _streamSet.CreateReader(); _colorStream = _reader.GetStream<ColorStream>(); _depthStream = _reader.GetStream<DepthStream>(); _colorStream.Start(); _depthStream.Start();

            // --- Start the main processing timer --- (No changes here)
            _sdkTimer = new System.Windows.Forms.Timer { Interval = 33 }; _sdkTimer.Tick += SdkTimer_Tick; _sdkTimer.Start();

            ResetMeasurementState(); // Initialize labels and state
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
            else { cmbMovementSelection.Items.Clear(); cmbMovementSelection.Items.Add("Joint not set"); }
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
            else { _currentMovement = MovementType.None; }
            if (_currentState != MeasurementState.Idle) { ResetMeasurementState(); }
        }

        // SdkTimer_Tick remains the same as your last version
        private void SdkTimer_Tick(object sender, EventArgs e)
        {
            if (_currentState == MeasurementState.Paused || _currentMovement == MovementType.None) return;
            Context.Update();
            if (!_reader.TryOpenFrame(0, out var frame)) return;
            ColorFrame cf = null; DepthFrame df = null;
            try
            {
                cf = frame.GetFrame<ColorFrame>(); df = frame.GetFrame<DepthFrame>();
                PointF[] rawJoints = null;
                if (cf != null && cf.Width > 0 && cf.DataPtr != IntPtr.Zero)
                {
                    int colorLength = cf.Width * cf.Height * 3;
                    if (_colorBuffer == null || _colorBuffer.Length != colorLength) _colorBuffer = new byte[colorLength];
                    cf.CopyData(ref _colorBuffer);
                    for (int i = 0; i < _colorBuffer.Length; i += 3) { byte temp = _colorBuffer[i]; _colorBuffer[i] = _colorBuffer[i + 2]; _colorBuffer[i + 2] = temp; }
                    var keypointsTensor = _moveNet.RunInference(_colorBuffer, cf.Width, cf.Height);
                    rawJoints = _moveNet.ExtractKeypoints(keypointsTensor, cf.Width, cf.Height);
                    _smoothedJoints = SmoothJoints(rawJoints, 0.5f);
                }
                Point3D[] smoothedLimb3D = null;
                if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero && _smoothedJoints != null && cf != null)
                {
                    int depthCount = df.Width * df.Height;
                    if (_depthBuffer == null || _depthBuffer.Length != depthCount) _depthBuffer = new short[depthCount];
                    df.CopyData(ref _depthBuffer);
                    MedianFilter(_depthBuffer, df.Width, df.Height);
                    var rawLimb3D = GetLimb3DPose(_smoothedJoints, _depthBuffer, df.Width, df.Height, cf.Width, cf.Height);
                    smoothedLimb3D = Smooth3DJointsMovingAverage(rawLimb3D);
                    if (smoothedLimb3D != null && smoothedLimb3D.Length == 3)
                    {
                        double limbAngle = CalculateAngle3D(smoothedLimb3D[0], smoothedLimb3D[1], smoothedLimb3D[2]);
                        if (limbAngle >= 0) { _lastLiveAngle = SmoothAngleMovingAverage(limbAngle); _lastAngleWasValid = true; } else { _lastAngleWasValid = false; }
                    }
                    else { _lastAngleWasValid = false; }
                }
                else { _lastAngleWasValid = false; }
                if (cf != null && _colorBuffer != null) { RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, _smoothedJoints, smoothedLimb3D); }
            }
            catch (Exception ex) { Debug.WriteLine($"Error during frame processing: {ex.ToString()}"); }
            finally { frame.Dispose(); }
        }

        // --- Updated btnStartStopMeasurement_Click ---
        private void btnStartStopMeasurement_Click(object sender, EventArgs e)
        {
            switch (_currentState)
            {
                case MeasurementState.Idle:
                    if (_currentMovement == MovementType.None) { MessageBox.Show("Please select a movement type first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (_lastAngleWasValid)
                    {
                        _initialAngle = _lastLiveAngle; // Starting Position
                        _initialConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblStartingPositionValue.Text = $"{_initialAngle:F1}° ({_initialConfidence})"; // Update renamed label
                        lblRomValue.Text = "";            // Clear ROM label
                        lblNormalRange.Text = "";       // Clear Normal Range
                        lblDeficit.Text = "";           // Clear Deficit
                        btnStartStopMeasurement.Text = "Stop Measurement";
                        _currentState = MeasurementState.Measuring;
                        ResetSmoothingFilters();
                    }
                    else { MessageBox.Show("Cannot start measurement. A required joint is hidden or too far/close.", "Joint Occluded/Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;

                case MeasurementState.Measuring:
                    if (_lastAngleWasValid)
                    {
                        _endAngle = _lastLiveAngle; // ROM
                        _endConfidence = GetConfidenceString(_lastConfidenceColor);
                        lblRomValue.Text = $"{_endAngle:F1}° ({_endConfidence})"; // Update renamed label

                        // Calculate and display Normal Range and Deficit
                        string movementName = _currentMovement.ToString();
                        double normalRange = ROMHelper.GetNormalRange(_currentJointName, movementName);
                        double deficit = ROMHelper.CalculateDeficit(_endAngle, _currentJointName, movementName);

                        lblNormalRange.Text = $"{normalRange:F1}°";
                        lblDeficit.Text = $"{deficit:F1}°"; // Display deficit (can be negative)

                        btnStartStopMeasurement.Text = "New Measurement";
                        _currentState = MeasurementState.Paused;
                    }
                    else { MessageBox.Show("Cannot stop measurement. A required joint is hidden or too far/close.", "Joint Occluded/Out of Range", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    break;

                case MeasurementState.Paused:
                    ResetMeasurementState();
                    break;
            }
        }

        // --- Updated GetConfidenceString ---
        private string GetConfidenceString(Color color)
        {
            if (color == Color.LawnGreen) return "Accuracy: Good";
            if (color == Color.Yellow) return "Accuracy: Fair";
            return "Accuracy: Low"; // Corresponds to Red
        }

        // --- Updated ResetMeasurementState ---
        private void ResetMeasurementState()
        {
            _currentState = MeasurementState.Idle;
            btnStartStopMeasurement.Text = "Start Measurement";
            lblStartingPositionValue.Text = ""; // Clear renamed label
            lblRomValue.Text = "";             // Clear renamed label
            lblNormalRange.Text = "";          // Clear new label
            lblDeficit.Text = "";              // Clear new label
            _initialAngle = 0;
            _endAngle = 0;
            _initialConfidence = "N/A";
            _endConfidence = "N/A";
            ResetSmoothingFilters();
        }

        // GetCalculationIndices remains the same (Left/Right Swapped version)
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
            return new int[0];
        }

        // ResetSmoothingFilters remains the same
        private void ResetSmoothingFilters() { _angleHistory.Clear(); _jointHistory3D.Clear(); _lastGood3DJoints = null; if (_jointOcclusionCounters == null || _jointOcclusionCounters.Length != 3) _jointOcclusionCounters = new int[3]; else Array.Clear(_jointOcclusionCounters, 0, _jointOcclusionCounters.Length); }

        // MedianFilter remains the same
        private void MedianFilter(short[] data, int width, int height) { var tempData = (short[])data.Clone(); var window = new List<short>(9); for (int y = 1; y < height - 1; y++) { for (int x = 1; x < width - 1; x++) { window.Clear(); for (int j = -1; j <= 1; j++) { for (int i = -1; i <= 1; i++) { short val = tempData[(y + j) * width + (x + i)]; if (val > 0) window.Add(val); } } if (window.Count > 0) { window.Sort(); data[y * width + x] = window[window.Count / 2]; } } } }

        // CalculateAngle3D remains the same
        private double CalculateAngle3D(Point3D p1, Point3D p2_vertex, Point3D p3) { if (p1.Z <= 0.1 || p2_vertex.Z <= 0.1 || p3.Z <= 0.1) { Debug.WriteLine($"Invalid depth for angle calculation: P1.Z={p1.Z}, P2.Z={p2_vertex.Z}, P3.Z={p3.Z}"); return -1; } Point3D vector1 = new Point3D { X = p1.X - p2_vertex.X, Y = p1.Y - p2_vertex.Y, Z = p1.Z - p2_vertex.Z }; Point3D vector2 = new Point3D { X = p3.X - p2_vertex.X, Y = p3.Y - p2_vertex.Y, Z = p3.Z - p2_vertex.Z }; double magnitude1 = Math.Sqrt((vector1.X * vector1.X) + (vector1.Y * vector1.Y) + (vector1.Z * vector1.Z)); double magnitude2 = Math.Sqrt((vector2.X * vector2.X) + (vector2.Y * vector2.Y) + (vector2.Z * vector2.Z)); if (magnitude1 == 0 || magnitude2 == 0) { Debug.WriteLine("Magnitude is zero, cannot calculate angle."); return -1; } double dotProduct = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z); double cosTheta = dotProduct / (magnitude1 * magnitude2); cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta)); double angleRad = Math.Acos(cosTheta); double interiorAngle = angleRad * (180.0 / Math.PI); if (_currentJoint == JointType.Elbow || _currentJoint == JointType.Knee) { return 180.0 - interiorAngle; } return interiorAngle; }

        // GetLimb3DPose remains the same
        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH) { int[] limbIndices = GetCalculationIndices(); if (limbIndices.Length == 0) return null; var outPts = new Point3D[limbIndices.Length]; bool allPointsValid = true; for (int i = 0; i < limbIndices.Length; i++) { int idx = limbIndices[i]; if (idx >= joints2D.Length || joints2D[idx].IsEmpty) { outPts[i] = new Point3D { X = 0, Y = 0, Z = 0 }; allPointsValid = false; _jointOcclusionCounters[i]++; continue; } PointF p2d = joints2D[idx]; int dx = (int)(p2d.X * depthW / (float)colorW); int dy = (int)(p2d.Y * depthH / (float)colorH); dx = Math.Max(0, Math.Min(dx, depthW - 1)); dy = Math.Max(0, Math.Min(dy, depthH - 1)); short depthInMm = depthBuffer[dy * depthW + dx]; if (depthInMm <= 0) { outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = 0 }; allPointsValid = false; _jointOcclusionCounters[i]++; } else { float depthInMeters = depthInMm / 1000.0f; outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = depthInMeters }; _jointOcclusionCounters[i] = 0; } } return outPts; }

        // SmoothJoints remains the same
        private PointF[] SmoothJoints(PointF[] newJoints, float alpha) { if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length) { _smoothedJoints = (PointF[])newJoints.Clone(); return _smoothedJoints; } for (int i = 0; i < newJoints.Length; i++) { if (newJoints[i].IsEmpty) { continue; } if (_smoothedJoints[i].IsEmpty) { _smoothedJoints[i] = newJoints[i]; continue; } float newX = alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X; float newY = alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y; _smoothedJoints[i] = new PointF(newX, newY); } return _smoothedJoints; }

        // Smooth3DJointsMovingAverage remains the same
        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints) { if (newJoints == null || newJoints.Any(p => p.Z <= 0)) { return _lastGood3DJoints; } _jointHistory3D.Enqueue(newJoints); while (_jointHistory3D.Count > MovingAverageWindowSize) { _jointHistory3D.Dequeue(); } if (_jointHistory3D.Count == 0) return newJoints; var averageJoints = new Point3D[newJoints.Length]; for (int i = 0; i < newJoints.Length; i++) { float sumX = 0, sumY = 0, sumZ = 0; int validCount = 0; foreach (var frameJoints in _jointHistory3D) { if (frameJoints.Length > i && frameJoints[i].Z > 0) { sumX += frameJoints[i].X; sumY += frameJoints[i].Y; sumZ += frameJoints[i].Z; validCount++; } } if (validCount > 0) { averageJoints[i] = new Point3D { X = sumX / validCount, Y = sumY / validCount, Z = sumZ / validCount }; } else if (_lastGood3DJoints != null && _lastGood3DJoints.Length > i) { averageJoints[i] = _lastGood3DJoints[i]; } else { averageJoints[i] = new Point3D { X = 0, Y = 0, Z = 0 }; } } _lastGood3DJoints = averageJoints; return averageJoints; }

        // SmoothAngleMovingAverage remains the same
        private double SmoothAngleMovingAverage(double newAngle) { if (newAngle >= 0) { _angleHistory.Enqueue(newAngle); while (_angleHistory.Count > MovingAverageWindowSize) { _angleHistory.Dequeue(); } } if (_angleHistory.Count == 0) return newAngle >= 0 ? newAngle : 0; return _angleHistory.Average(); }

        // RenderColorWithPose remains the same
        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints2D, Point3D[] joints3D_smoothed) { Bitmap bmp = null; Bitmap displayBmp = null; try { bmp = new Bitmap(w, h, w * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0)); using (var g = Graphics.FromImage(bmp)) { DrawLimbPose(g, joints2D, joints3D_smoothed); } displayBmp = (Bitmap)bmp.Clone(); pictureBoxRgb.Invoke((Action)(() => { if (pictureBoxRgb.Image != null) pictureBoxRgb.Image.Dispose(); pictureBoxRgb.Image = displayBmp; })); } catch (Exception ex) { Debug.WriteLine($"Error during rendering: {ex.ToString()}"); displayBmp?.Dispose(); } finally { /* Don't dispose bmp wrapping Marshal pointer */ } }

        // DrawLimbPose remains the same
        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed) { if (joints2D == null) return; int[] activeIndices = GetCalculationIndices(); if (activeIndices.Length < 3) return; const float optimalDepthStart = 0.7f; const float optimalDepthEnd = 2.5f; const float acceptableMargin = 0.2f; Color limbColor = Color.Red; float middleJointDepth = 0; if (joints3D_smoothed != null && joints3D_smoothed.Length > 1 && joints3D_smoothed[1].Z > 0) { middleJointDepth = joints3D_smoothed[1].Z; if (middleJointDepth >= optimalDepthStart && middleJointDepth <= optimalDepthEnd) limbColor = Color.LawnGreen; else if (middleJointDepth >= optimalDepthStart - acceptableMargin && middleJointDepth <= optimalDepthEnd + acceptableMargin) limbColor = Color.Yellow; else limbColor = Color.Red; } _lastConfidenceColor = limbColor; _bonePen.Color = limbColor; if (joints2D.Length > activeIndices[0] && !joints2D[activeIndices[0]].IsEmpty && joints2D.Length > activeIndices[1] && !joints2D[activeIndices[1]].IsEmpty) { g.DrawLine(_bonePen, joints2D[activeIndices[0]], joints2D[activeIndices[1]]); } if (joints2D.Length > activeIndices[1] && !joints2D[activeIndices[1]].IsEmpty && joints2D.Length > activeIndices[2] && !joints2D[activeIndices[2]].IsEmpty) { g.DrawLine(_bonePen, joints2D[activeIndices[1]], joints2D[activeIndices[2]]); } for (int i = 0; i < activeIndices.Length; i++) { int jointIndex = activeIndices[i]; if (joints2D.Length > jointIndex && !joints2D[jointIndex].IsEmpty) { PointF p2d = joints2D[jointIndex]; bool isOccluded = (_jointOcclusionCounters[i] > OcclusionGracePeriod); Color jointColor = isOccluded ? Color.Red : Color.White; _jointBrush.Color = jointColor; g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10); } } if (middleJointDepth > 0) { string depthText = $"Your Distance: {middleJointDepth:F2}m"; string targetText = $"Good Range: {optimalDepthStart:F1}m - {optimalDepthEnd:F1}m"; g.FillRectangle(_backBrush, 5, 5, 200, 50); g.DrawString(depthText, _font, _fontBrush, new PointF(10, 10)); g.DrawString(targetText, _font, _fontBrush, new PointF(10, 30)); } if ((_currentState == MeasurementState.Measuring || _currentState == MeasurementState.Paused) && _lastAngleWasValid) { PointF vertexPoint = joints2D[activeIndices[1]]; if (!vertexPoint.IsEmpty) { double angleToDisplay = (_currentState == MeasurementState.Measuring) ? _lastLiveAngle : _endAngle; string angleText = $"{angleToDisplay:F1}°"; SizeF textSize = g.MeasureString(angleText, _font); RectangleF textRect = new RectangleF(vertexPoint.X + 15, vertexPoint.Y - 25, textSize.Width + 10, textSize.Height + 5); g.FillRectangle(_backBrush, textRect); g.DrawString(angleText, _font, _fontBrush, textRect.Location.X + 5, textRect.Location.Y + 2.5f); } } }

        // --- Updated btnSaveROM_Click ---
        private async void btnSaveROM_Click(object sender, EventArgs e)
        {
            // 1. Validation (Only check if measurement is Paused)
            if (_currentState != MeasurementState.Paused)
            {
                MessageBox.Show("Please complete a measurement (Start and then Stop) before saving.",
                                  "Measurement Not Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Data Gathering & DTO Population
            var newRomDto = new AddROMDTO
            {
                // !!! IMPORTANT: Replace placeholders with actual logic !!!
                AssessmentID = PageObjects.assessmentDetails.AssessmentID,
                UserID = SessionManager.UserID,

                GoniometerType = "Astra Pro Plus + MoveNet",
                StartingPosition = _initialAngle, // Starting Position value
                Rom = _endAngle,         // ROM value
                Movement = _currentMovement.ToString(),
                MotionType = "Active", // Fixed value
            };

            // 3. API Call
            bool success = false;
            try
            {
                btnSaveROM.Enabled = false; btnSaveROM.Text = "Saving...";
                success = await Queries.ROMQueries.AddROM(newRomDto);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error in btnSaveROM_Click: {ex}");
                MessageBox.Show("An unexpected error occurred while preparing to save.\nPlease try again.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            finally { btnSaveROM.Enabled = true; btnSaveROM.Text = "Save ROM"; }

            // 4. Handle Result
            if (success)
            {
                MessageBox.Show("Range of Motion data saved successfully!", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await Queries.ROMQueries.DisplayROM(PageObjects.assessmentDetails.AssessmentID);
                this.Close();
            }
            // Error dialogs are handled within AddROM
        }

        // AssessmentROM_FormClosing remains the same
        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e) { _sdkTimer?.Stop(); _reader?.Dispose(); _streamSet?.Dispose(); _moveNet?.Dispose(); _font?.Dispose(); _fontBrush?.Dispose(); _backBrush?.Dispose(); _jointBrush?.Dispose(); _bonePen?.Dispose(); Context.Terminate(); }

    }
}