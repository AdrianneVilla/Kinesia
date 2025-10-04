// These are the 'using' statements. They import necessary libraries from the .NET framework and other packages.
// For example, System.Drawing is for images, and System.Windows.Forms is for the user interface.
using Astra;
using Astra.Core;
using Microsoft.ML.OnnxRuntime.Tensors;
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
    // This is the main window of your application. The 'partial' keyword means the class is split
    // into multiple files (the other part is in AssessmentROM.Designer.cs, which is auto-generated).
    public partial class AssessmentROM : Form
    {
        // An 'enum' is a set of named constants. This makes the code more readable.
        // Instead of using numbers (0, 1), we can use descriptive names for the arms.
        private enum TrackedLimb
        {
            RightArm,
            LeftArm
        }

        // This variable holds the currently selected limb from the ComboBox. It defaults to RightArm.
        private TrackedLimb _currentLimb = TrackedLimb.RightArm;

        // A 'struct' is a simple, lightweight way to group related data.
        // This one holds the X, Y, and Z coordinates for a point in 3D space.
        private struct Point3D
        {
            public float X, Y, Z;
            // This overrides the default ToString() method so we can print the coordinates in a nice format.
            public override string ToString() => $"({X:F2}, {Y:F2}, {Z:F2}m)";
        }

        // --- Camera and SDK Fields ---
        // These fields hold the core objects for interacting with the Astra camera SDK.
        private StreamSet _streamSet;                   // Represents the connection to the physical camera device.
        private Astra.StreamReader _reader;             // Reads the data frames (color and depth) from the camera.
        private ColorStream _colorStream;               // Specifically manages the color video stream.
        private DepthStream _depthStream;               // Specifically manages the depth data stream.
        private System.Windows.Forms.Timer _sdkTimer;   // A timer that 'ticks' every 33ms to process a new frame (approx. 30 FPS).

        // --- Data Buffers ---
        // These arrays hold the raw pixel data from the camera for each frame.
        private byte[] _colorBuffer;    // Holds the color image data (3 bytes per pixel: Blue, Green, Red).
        private short[] _depthBuffer;   // Holds the depth image data (1 value per pixel, representing distance in millimeters).

        // --- AI Model Fields ---
        private MoveNet _moveNet;       // Our custom class that handles the AI pose estimation logic.
        private string _modelPath;      // The full file path to the ONNX model file (e.g., "C:\...\models\model.onnx").
        private const string ModelFileName = "model.onnx"; // The name of the AI model file.

        // --- Smoothing and Filtering Fields ---
        private PointF[] _smoothedJoints;               // Stores the 2D joint positions after basic smoothing.

        // These fields are for the 'moving average' filter, which averages data over several frames to make it stable.
        private int MovingAverageWindowSize = 7;      // The number of frames to average over. A higher number means more smoothing but more lag.
        private readonly Queue<double> _angleHistory = new Queue<double>(); // A queue to store the last few calculated angles.
        private readonly Queue<Point3D[]> _jointHistory3D = new Queue<Point3D[]>(); // A queue to store the last few sets of 3D joint positions.
        private Point3D[] _lastGood3DJoints;            // Holds the last known valid set of 3D points, used when tracking is temporarily lost.

        // --- Occlusion (Hidden Joint) Feedback Fields ---
        // These are used to provide the red-dot feedback when a joint is hidden from the depth camera.
        private const int OcclusionGracePeriod = 5;     // A joint must be hidden for this many frames before it turns red. This prevents flickering.
        private int[] _jointOcclusionCounters = new int[3]; // An array to count how many consecutive frames each of the three limb joints has been hidden.

        // --- UI State and Capture Fields ---
        // These manage the state of the "Capture" button and store the final result.
        private bool _isFrozen = false;                 // A flag that is 'true' when the screen is frozen after a capture.
        private double _lastCapturedAngle = 0;          // Stores the most recently calculated angle.
        private bool _lastCaptureWasValid = false;      // A flag to check if the last angle was a valid measurement (i.e., not 0).
        private Color _lastCaptureConfidenceColor = Color.Red; // Stores the color of the skeleton at the moment of capture, used for the confidence score.

        // --- Drawing and Rendering Fields ---
        // These GDI+ objects are used for drawing on the image. We create them once for performance.
        private Font _font;
        private SolidBrush _fontBrush;
        private SolidBrush _backBrush;
        private SolidBrush _jointBrush;
        private Pen _bonePen;

        // This is the constructor for the Form. It's called when the application starts.
        public AssessmentROM()
        {
            // This is a required method for Windows Forms. It initializes all the UI components you added in the designer.
            InitializeComponent();
            // These lines 'subscribe' our methods to the form's events.
            this.Load += AssessmentROM_Load;             // When the form loads, call the AssessmentROM_Load method.
            this.FormClosing += AssessmentROM_FormClosing; // When the form is about to close, call the AssessmentROM_FormClosing method.

            // This builds the full path to the AI model file, assuming it's in a 'models' subfolder.
            _modelPath = Path.Combine(Application.StartupPath, "models", ModelFileName);
        }

        // This method runs once when the form is first loaded. It's used for all one-time setup tasks.
        private void AssessmentROM_Load(object sender, EventArgs e)
        {
            // Initialize all the drawing objects we will reuse in every frame. This is much more efficient
            // than creating new ones 30 times per second.
            _font = new Font("Arial", 10, FontStyle.Bold);
            _fontBrush = new SolidBrush(Color.White);
            _backBrush = new SolidBrush(Color.FromArgb(150, Color.Black));
            _jointBrush = new SolidBrush(Color.White);
            _bonePen = new Pen(Color.Red, 4);

            // Add the limb names to the ComboBox's dropdown list.
            cmbLimbSelection.Items.Add("Right Arm");
            cmbLimbSelection.Items.Add("Left Arm");
            cmbLimbSelection.SelectedIndex = 0; // Set the default selection to "Right Arm".

            // --- AI Model Loading ---
            // Check if the model file actually exists before trying to load it.
            if (File.Exists(_modelPath))
            {
                try
                {
                    // Create an instance of our MoveNet class, which loads the AI model into memory.
                    _moveNet = new MoveNet(_modelPath);
                }
                catch (Exception ex)
                {
                    // If loading fails, show an error message and close the application.
                    MessageBox.Show($"Failed to load MoveNet model: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                // If the file is missing, show an error and close.
                MessageBox.Show($"Model file not found at: {_modelPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // --- Camera SDK Initialization ---
            Context.Initialize();                       // Initialize the Astra SDK.
            _streamSet = StreamSet.Open();              // Connect to the default camera.
            _reader = _streamSet.CreateReader();        // Create a reader to get frames from the camera.

            _colorStream = _reader.GetStream<ColorStream>(); // Get the color stream object.
            _depthStream = _reader.GetStream<DepthStream>(); // Get the depth stream object.
            _colorStream.Start();                       // Tell the camera to start sending color frames.
            _depthStream.Start();                       // Tell the camera to start sending depth frames.

            // --- Main Loop Timer Setup ---
            // Set up the timer that will drive the main processing loop.
            _sdkTimer = new System.Windows.Forms.Timer
            {
                Interval = 33 // The interval in milliseconds. 33ms is approximately 30 frames per second (1000ms / 30fps).
            };
            _sdkTimer.Tick += SdkTimer_Tick; // Each time the timer ticks, it will call our SdkTimer_Tick method.
            _sdkTimer.Start();               // Start the timer.
        }

        // This is the main loop of the application. This method is called approximately 30 times every second.
        private void SdkTimer_Tick(object sender, EventArgs e)
        {
            // If the user has clicked "Capture", the screen is frozen, so we skip all processing.
            if (_isFrozen) return;

            // This tells the Astra SDK to perform its internal processing to get the latest camera data ready.
            Context.Update();

            // Try to get a new 'frame' from the camera. A frame contains both a color and a depth image.
            // If no new frame is ready, we just exit the method for this tick.
            if (!_reader.TryOpenFrame(0, out var frame))
                return;

            try // A try-catch block is used to handle any unexpected errors during processing.
            {
                // Extract the individual color and depth images from the main frame object.
                var cf = frame.GetFrame<ColorFrame>();
                var df = frame.GetFrame<DepthFrame>();

                // --- STAGE 1: Process the Color Frame and Run AI ---
                // We only proceed if we have a valid color frame with a positive width and a valid data pointer.
                if (cf != null && cf.Width > 0 && cf.DataPtr != IntPtr.Zero)
                {
                    // Ensure our color buffer is the correct size.
                    int colorLength = cf.Width * cf.Height * 3;
                    if (_colorBuffer == null || _colorBuffer.Length != colorLength)
                        _colorBuffer = new byte[colorLength];

                    // Copy the image data from the camera's memory into our buffer array.
                    cf.CopyData(ref _colorBuffer);

                    // The camera gives us data in BGR (Blue, Green, Red) format, but our display needs RGB.
                    // This loop swaps the first (Blue) and third (Red) bytes for every pixel.
                    for (int i = 0; i < _colorBuffer.Length; i += 3)
                    {
                        byte temp = _colorBuffer[i];
                        _colorBuffer[i] = _colorBuffer[i + 2];
                        _colorBuffer[i + 2] = temp;
                    }

                    // --- STAGE 2: AI Inference ---
                    // Run the color image through the MoveNet AI model to get the 2D joint positions.
                    var keypointsTensor = _moveNet.RunInference(_colorBuffer, cf.Width, cf.Height);
                    var rawJoints = _moveNet.ExtractKeypoints(keypointsTensor, cf.Width, cf.Height);
                    // Apply a simple smoothing filter to the 2D points to reduce visual jitter.
                    var smoothedJoints = SmoothJoints(rawJoints, 0.5f);

                    Point3D[] rawLimb3D = null;
                    Point3D[] smoothedLimb3D = null;

                    // --- STAGE 3: Process the Depth Frame and Fuse Data ---
                    // We only proceed if we also have a valid depth frame.
                    if (df != null && df.Width > 0 && df.DataPtr != IntPtr.Zero)
                    {
                        // Ensure our depth buffer is the correct size.
                        int depthCount = df.Width * df.Height;
                        if (_depthBuffer == null || _depthBuffer.Length != depthCount)
                            _depthBuffer = new short[depthCount];

                        // Copy the depth data from the camera into our buffer.
                        df.CopyData(ref _depthBuffer);
                        // Apply a Median Filter to remove "salt-and-pepper" noise from the depth map.
                        MedianFilter(_depthBuffer, df.Width, df.Height);

                        // This is the core 3D FUSION step: combine the 2D points with the depth data to get 3D points.
                        rawLimb3D = GetLimb3DPose(smoothedJoints, _depthBuffer,
                            df.Width, df.Height, cf.Width, cf.Height);

                        // --- STAGE 4: Smooth the 3D Data and Calculate Angle ---
                        // Apply the moving average filter to the 3D points to make them stable.
                        smoothedLimb3D = Smooth3DJointsMovingAverage(rawLimb3D);

                        // Calculate the final angle using the cleaned and smoothed 3D points.
                        double limbAngle = CalculateAngle3D(smoothedLimb3D[0], smoothedLimb3D[1], smoothedLimb3D[2]);

                        // Apply the moving average filter to the final angle for a stable display.
                        _lastCapturedAngle = SmoothAngleMovingAverage(limbAngle);
                        // Check if the angle is valid (not zero), which indicates a successful calculation.
                        _lastCaptureWasValid = limbAngle > 0;
                    }

                    // --- STAGE 5: Render the Final Output ---
                    // Draw the skeleton, distance guide, and occlusion feedback on top of the color image.
                    RenderColorWithPose(cf.Width, cf.Height, _colorBuffer, smoothedJoints, smoothedLimb3D, rawLimb3D);
                }
            }
            catch (Exception ex) // If any error occurred in the 'try' block, it will be caught here.
            {
                // Print the error to the debug output window so we can diagnose problems.
                Debug.WriteLine($"Error during frame processing: {ex.ToString()}");
            }
            finally // The 'finally' block always runs, whether there was an error or not.
            {
                // It's critical to 'Dispose' the frame object to release the camera's memory.
                frame.Dispose();
            }
        }

        // This method is called when the "Capture" button is clicked.
        private void btnCapture_Click(object sender, EventArgs e)
        {
            // Toggle the frozen state. If it was false, it becomes true, and vice-versa.
            _isFrozen = !_isFrozen;

            if (_isFrozen) // If we just froze the screen...
            {
                btnCapture.Text = "Resume"; // Change the button text.
                string confidenceText;

                // Determine the confidence level based on the color of the skeleton at the moment of capture.
                if (_lastCaptureConfidenceColor == Color.LawnGreen)
                {
                    confidenceText = "Good";
                }
                else if (_lastCaptureConfidenceColor == Color.Yellow)
                {
                    confidenceText = "Fair";
                }
                else
                {
                    confidenceText = "Low";
                }

                // Display the final captured result in the status label.
                if (_lastCaptureWasValid)
                {
                    lblStatus.Text = $"{_currentLimb}: {_lastCapturedAngle:F1}° (Confidence: {confidenceText})";
                    lblStatus.ForeColor = _lastCaptureConfidenceColor;
                }
                else
                {
                    lblStatus.Text = "Could not capture: A joint was hidden.";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            else // If we just resumed the feed...
            {
                btnCapture.Text = "Capture"; // Change the button text back.
                lblStatus.Text = "";        // Clear the status label.
            }
        }

        // This method is called whenever the user selects a different item in the ComboBox.
        private void cmbLimbSelection_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the text of the selected item.
            string selectedLimb = cmbLimbSelection.SelectedItem.ToString();
            // Update the _currentLimb variable based on the selection.
            switch (selectedLimb)
            {
                case "Right Arm":
                    _currentLimb = TrackedLimb.RightArm;
                    break;
                case "Left Arm":
                    _currentLimb = TrackedLimb.LeftArm;
                    break;
            }

            // It's important to reset the smoothing filters when changing the target limb,
            // otherwise, it would try to average old arm data with new leg data.
            _angleHistory.Clear();
            _jointHistory3D.Clear();
            _lastGood3DJoints = null;
            Array.Clear(_jointOcclusionCounters, 0, _jointOcclusionCounters.Length);
        }

        // This method applies a Median Filter to an image buffer to remove salt-and-pepper noise.
        private void MedianFilter(short[] data, int width, int height)
        {
            var tempData = (short[])data.Clone(); // Work on a copy to avoid corrupting the data during processing.
            var window = new List<short>(9);      // A list to hold the 9 pixels in the 3x3 window.

            // Loop through every pixel, but skip the 1-pixel border since the window needs neighbors.
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    window.Clear();
                    // Gather the 9 pixel values in the 3x3 window around the current (x, y) pixel.
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            short val = tempData[(y + j) * width + (x + i)];
                            if (val > 0) // Only consider valid depth readings (ignore 0).
                            {
                                window.Add(val);
                            }
                        }
                    }

                    if (window.Count > 0)
                    {
                        window.Sort(); // Sort the values from smallest to largest.
                        // Replace the original pixel's value with the median (the middle value).
                        data[y * width + x] = window[window.Count / 2];
                    }
                }
            }
        }

        // This method calculates the angle between three 3D points.
        private double CalculateAngle3D(Point3D p1, Point3D p2, Point3D p3)
        {
            // Safety check: if any point has a Z of 0, it means its depth is unknown, so the calculation is invalid.
            if (p1.Z <= 0 || p2.Z <= 0 || p3.Z <= 0)
                return 0;

            // Create two vectors from the three points. The angle is at p2.
            // Vector 1: from p2 to p1.
            Point3D vector1 = new Point3D { X = p1.X - p2.X, Y = p1.Y - p2.Y, Z = p1.Z - p2.Z };
            // Vector 2: from p2 to p3.
            Point3D vector2 = new Point3D { X = p3.X - p2.X, Y = p3.Y - p2.Y, Z = p3.Z - p2.Z };

            // Calculate the dot product of the two vectors.
            double dotProduct = (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
            // Calculate the magnitude (length) of each vector.
            double magnitude1 = Math.Sqrt((vector1.X * vector1.X) + (vector1.Y * vector1.Y) + (vector1.Z * vector1.Z));
            double magnitude2 = Math.Sqrt((vector2.X * vector2.X) + (vector2.Y * vector2.Y) + (vector2.Z * vector2.Z));

            // Safety check to avoid division by zero.
            if (magnitude1 == 0 || magnitude2 == 0)
                return 0;

            // Use the dot product formula to find the cosine of the angle.
            double cosTheta = dotProduct / (magnitude1 * magnitude2);
            // Clamp the value to the valid range of -1.0 to 1.0 to prevent math errors.
            cosTheta = Math.Max(-1.0, Math.Min(1.0, cosTheta));
            // Calculate the angle in radians using the arccosine.
            double angleRad = Math.Acos(cosTheta);
            // Convert the angle from radians to degrees and return it.
            return angleRad * (180.0 / Math.PI);
        }

        // This is the main data fusion method. It converts 2D points into 3D points using the depth map.
        private Point3D[] GetLimb3DPose(PointF[] joints2D, short[] depthBuffer, int depthW, int depthH, int colorW, int colorH)
        {
            int[] limbIndices = GetLimbIndices(); // Get the joint indices for the currently selected limb.
            var outPts = new Point3D[limbIndices.Length];

            for (int i = 0; i < limbIndices.Length; i++)
            {
                int idx = limbIndices[i];
                // Safety check for valid index.
                if (idx >= joints2D.Length || joints2D[idx].IsEmpty)
                {
                    outPts[i] = new Point3D { X = 0, Y = 0, Z = 0 }; // Return a point with 0 depth if the 2D joint wasn't found.
                    continue;
                }

                PointF p2d = joints2D[idx];
                // --- Coordinate Mapping ---
                // Scale the 2D point from the color image's coordinate system to the depth image's coordinate system.
                int dx = (int)(p2d.X * depthW / (float)colorW);
                int dy = (int)(p2d.Y * depthH / (float)colorH);
                // Clamp the values to be within the bounds of the depth image.
                dx = Math.Max(0, Math.Min(dx, depthW - 1));
                dy = Math.Max(0, Math.Min(dy, depthH - 1));

                // --- Depth Lookup ---
                // Get the depth value (in millimeters) from the depth buffer at the mapped coordinate.
                short depthInMm = depthBuffer[dy * depthW + dx];
                // Convert millimeters to meters for our 3D point.
                float depthInMeters = depthInMm / 1000.0f;
                // Create the final 3D point.
                outPts[i] = new Point3D { X = p2d.X, Y = p2d.Y, Z = depthInMeters };
            }

            return outPts;
        }

        // This is a simple Exponential Moving Average (EMA) filter for 2D points.
        private PointF[] SmoothJoints(PointF[] newJoints, float alpha)
        {
            // If this is the first frame, just copy the new joints.
            if (_smoothedJoints == null || _smoothedJoints.Length != newJoints.Length)
            {
                _smoothedJoints = (PointF[])newJoints.Clone();
                return _smoothedJoints;
            }

            for (int i = 0; i < newJoints.Length; i++)
            {
                if (newJoints[i].IsEmpty) continue; // Skip invalid points.
                if (_smoothedJoints[i].IsEmpty)
                {
                    _smoothedJoints[i] = newJoints[i]; // Initialize if the smoothed point was previously empty.
                    continue;
                }
                // Calculate the new smoothed position as a weighted average of the new point and the old smoothed point.
                float newX = alpha * newJoints[i].X + (1 - alpha) * _smoothedJoints[i].X;
                float newY = alpha * newJoints[i].Y + (1 - alpha) * _smoothedJoints[i].Y;
                _smoothedJoints[i] = new PointF(newX, newY);
            }
            return _smoothedJoints;
        }

        // This method applies a moving average filter to the 3D joint data.
        private Point3D[] Smooth3DJointsMovingAverage(Point3D[] newJoints)
        {
            // Add the latest set of joints to our history queue.
            _jointHistory3D.Enqueue(newJoints);
            // If the queue is now larger than our window size, remove the oldest item.
            while (_jointHistory3D.Count > MovingAverageWindowSize)
            {
                _jointHistory3D.Dequeue();
            }

            // If we have no history, return the last known good points or the current points.
            if (_jointHistory3D.Count == 0) return _lastGood3DJoints ?? newJoints;

            var averageJoints = new Point3D[newJoints.Length];
            // Loop through each joint (shoulder, elbow, wrist).
            for (int i = 0; i < newJoints.Length; i++)
            {
                float sumX = 0, sumY = 0, sumZ = 0;
                int validCount = 0;
                // Loop through all the frames in our history.
                foreach (var frame in _jointHistory3D)
                {
                    // Only include points that had a valid depth reading.
                    if (frame.Length > i && frame[i].Z > 0)
                    {
                        sumX += frame[i].X;
                        sumY += frame[i].Y;
                        sumZ += frame[i].Z;
                        validCount++;
                    }
                }

                // If we found any valid points in the history, calculate the average.
                if (validCount > 0)
                {
                    averageJoints[i] = new Point3D { X = sumX / validCount, Y = sumY / validCount, Z = sumZ / validCount };
                }
                // Otherwise, fall back to the last known good average to avoid returning (0,0,0).
                else if (_lastGood3DJoints != null && _lastGood3DJoints.Length > i)
                {
                    averageJoints[i] = _lastGood3DJoints[i];
                }
            }
            // Store this frame's average as the new 'last known good' set of points.
            _lastGood3DJoints = averageJoints;
            return averageJoints;
        }

        // This method applies a moving average filter to the final calculated angle.
        private double SmoothAngleMovingAverage(double newAngle)
        {
            // Only add valid angles to the history.
            if (newAngle > 0)
            {
                _angleHistory.Enqueue(newAngle);
                while (_angleHistory.Count > MovingAverageWindowSize)
                {
                    _angleHistory.Dequeue();
                }
            }

            if (_angleHistory.Count == 0) return 0;

            // Return the average of all angles in the history queue.
            return _angleHistory.Average();
        }

        // This method handles all the drawing onto the color image.
        private void RenderColorWithPose(int w, int h, byte[] buffer, PointF[] joints, Point3D[] joints3D_smoothed, Point3D[] joints3D_raw)
        {
            Bitmap bmp = null;
            Bitmap displayBmp = null;
            try
            {
                // Create a Bitmap object that wraps our raw color buffer data.
                bmp = new Bitmap(
                    w, h,
                    w * 3,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                    Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0));

                // Get a Graphics object so we can draw on the bitmap.
                using (var g = Graphics.FromImage(bmp))
                {
                    // Call our main drawing method.
                    DrawLimbPose(g, joints, joints3D_smoothed, joints3D_raw);
                }

                // Clone the bitmap. The original bmp is tied to the buffer, which will be overwritten.
                // The clone is a new, independent image that we can safely display.
                displayBmp = (Bitmap)bmp.Clone();

                // Safely update the PictureBox on the UI thread.
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

        // This is a helper method to get the correct joint indices based on the ComboBox selection.
        private int[] GetLimbIndices()
        {
            switch (_currentLimb)
            {
                case TrackedLimb.RightArm:
                    return new[] { 5, 7, 9 }; // L Shoulder, Elbow, Wrist
                case TrackedLimb.LeftArm:
                    return new[] { 6, 8, 10 }; // R Shoulder, Elbow, Wrist
                default:
                    return new int[0];
            }
        }

        // This is a helper method to get the correct bone connections based on the ComboBox selection.
        private Tuple<int, int>[] GetLimbConnections()
        {
            switch (_currentLimb)
            {
                case TrackedLimb.RightArm:
                    return new[] { Tuple.Create(5, 7), Tuple.Create(7, 9) };
                case TrackedLimb.LeftArm:
                    return new[] { Tuple.Create(6, 8), Tuple.Create(8, 10) };
                default:
                    return new Tuple<int, int>[0];
            }
        }


        // This is the main drawing method that renders the skeleton and UI elements.
        private void DrawLimbPose(Graphics g, PointF[] joints2D, Point3D[] joints3D_smoothed, Point3D[] joints3D_raw)
        {
            if (joints2D == null) return;

            // --- Define Depth Zones for Color Feedback ---
            const float optimalDepthStart = 0.6f;
            const float optimalDepthEnd = 1.0f;
            const float acceptableMargin = 0.15f;

            Color limbColor = Color.Red; // Default to Red (low confidence).
            if (joints3D_smoothed != null)
            {
                int middleJoint3DIndex = 1; // The middle joint (elbow or knee) is used as the reference for distance.
                // Check if the smoothed 3D point is valid.
                if (joints3D_smoothed.Length > middleJoint3DIndex && joints3D_smoothed[middleJoint3DIndex].Z > 0)
                {
                    float middleJointDepth = joints3D_smoothed[middleJoint3DIndex].Z;
                    // Set the color based on the distance from the camera.
                    if (middleJointDepth >= optimalDepthStart && middleJointDepth <= optimalDepthEnd)
                        limbColor = Color.LawnGreen; // Good range
                    else if (middleJointDepth >= optimalDepthStart - acceptableMargin && middleJointDepth <= optimalDepthEnd + acceptableMargin)
                        limbColor = Color.Yellow; // Fair range
                }

                // Store this color so the "Capture" button knows the confidence level.
                _lastCaptureConfidenceColor = limbColor;
                // Update the color of our reusable pen.
                _bonePen.Color = limbColor;

                // --- Draw Bones ---
                var connections = GetLimbConnections();
                foreach (var conn in connections)
                {
                    PointF p1_2d = joints2D[conn.Item1];
                    PointF p2_2d = joints2D[conn.Item2];

                    if (!p1_2d.IsEmpty && !p2_2d.IsEmpty)
                    {
                        g.DrawLine(_bonePen, p1_2d, p2_2d);
                    }
                }

                // --- Draw Distance Guide UI ---
                if (joints3D_smoothed.Length > middleJoint3DIndex && joints3D_smoothed[middleJoint3DIndex].Z > 0)
                {
                    float currentDepth = joints3D_smoothed[middleJoint3DIndex].Z;
                    string depthText = $"Your Distance: {currentDepth:F2}m";
                    string targetText = $"Good Range: {optimalDepthStart:F2}m - {optimalDepthEnd:F2}m";

                    g.FillRectangle(_backBrush, 5, 5, 200, 50);
                    g.DrawString(depthText, _font, _fontBrush, new PointF(10, 10));
                    g.DrawString(targetText, _font, _fontBrush, new PointF(10, 30));
                }
            }

            // --- Draw Joints with Occlusion Feedback ---
            int[] limbIndices = GetLimbIndices();
            for (int i = 0; i < limbIndices.Length; i++)
            {
                int jointIndex = limbIndices[i];
                if (joints2D.Length > jointIndex && !joints2D[jointIndex].IsEmpty)
                {
                    PointF p2d = joints2D[jointIndex];
                    // Check the RAW (un-smoothed) 3D data to see if the joint is visible in THIS specific frame.
                    bool isJointVisible = joints3D_raw != null && joints3D_raw.Length > i && joints3D_raw[i].Z > 0;

                    // Update the occlusion counter for this joint.
                    if (isJointVisible)
                    {
                        _jointOcclusionCounters[i] = 0; // Reset counter if the joint is visible.
                    }
                    else
                    {
                        _jointOcclusionCounters[i]++; // Increment counter if it's hidden.
                    }

                    // If the joint has been hidden for more frames than our grace period, turn it red. Otherwise, it's white.
                    Color jointColor = (_jointOcclusionCounters[i] > OcclusionGracePeriod) ? Color.Red : Color.White;

                    _jointBrush.Color = jointColor;
                    g.FillEllipse(_jointBrush, p2d.X - 5, p2d.Y - 5, 10, 10);
                }
            }
        }

        // This method is called when the form is closing. It's crucial for releasing all resources.
        private void AssessmentROM_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sdkTimer?.Stop();
            _reader?.Dispose();
            _streamSet?.Dispose();
            _moveNet?.Dispose();

            // Dispose of all the GDI+ drawing objects we created.
            _font?.Dispose();
            _fontBrush?.Dispose();
            _backBrush?.Dispose();
            _jointBrush?.Dispose();
            _bonePen?.Dispose();

            // Shut down the Astra SDK.
            Context.Terminate();
        }
    }
}

