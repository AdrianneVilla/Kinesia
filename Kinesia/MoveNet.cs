using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Kinesia
{
    public class MoveNet : IDisposable
    {
        private readonly InferenceSession _session;
        private const int ImageSize = 256;

        public MoveNet(string modelPath)
        {
            _session = new InferenceSession(modelPath);
        }

        public Tensor<float> RunInference(byte[] rgbBuffer, int imageWidth, int imageHeight)
        {
            var inputTensor = PreprocessImage(rgbBuffer, imageWidth, imageHeight);

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input", inputTensor)
            };

            using (var results = _session.Run(inputs))
            {
                return results.First().AsTensor<float>();
            }
        }

        public unsafe Tensor<int> PreprocessImage(byte[] rgbBuffer, int imageWidth, int imageHeight)
        {
            var tensor = new DenseTensor<int>(new[] { 1, ImageSize, ImageSize, 3 });

            fixed (byte* pBuffer = rgbBuffer)
            {
                for (int y = 0; y < ImageSize; y++)
                {
                    for (int x = 0; x < ImageSize; x++)
                    {
                        int srcX = x * imageWidth / ImageSize;
                        int srcY = y * imageHeight / ImageSize;
                        int srcIndex = (srcY * imageWidth + srcX) * 3;

                        tensor[0, y, x, 0] = pBuffer[srcIndex];     // R
                        tensor[0, y, x, 1] = pBuffer[srcIndex + 1]; // G
                        tensor[0, y, x, 2] = pBuffer[srcIndex + 2]; // B
                    }
                }
            }
            return tensor;
        }

        public PointF[] ExtractKeypoints(Tensor<float> keypointsTensor, int imageWidth, int imageHeight)
        {
            var keypoints = new PointF[17];
            for (int i = 0; i < 17; i++)
            {
                float y = keypointsTensor[0, 0, i, 0] * imageHeight;
                float x = keypointsTensor[0, 0, i, 1] * imageWidth;
                float score = keypointsTensor[0, 0, i, 2];

                if (score > 0.3f)
                {
                    keypoints[i] = new PointF(x, y);
                }
                else
                {
                    keypoints[i] = PointF.Empty;
                }
            }
            return keypoints;
        }

        public void DrawRightArmPose(Graphics g, PointF[] keypoints, Color skeletonColor)
        {
            using (var pen = new Pen(skeletonColor, 3))
            using (var brush = new SolidBrush(skeletonColor))
            {
                // Right Arm Connections
                var connections = new[]
                {
                    Tuple.Create(6, 8), // Right Shoulder to Right Elbow
                    Tuple.Create(8, 10) // Right Elbow to Right Wrist
                };

                foreach (var conn in connections)
                {
                    if (!keypoints[conn.Item1].IsEmpty && !keypoints[conn.Item2].IsEmpty)
                    {
                        g.DrawLine(pen, keypoints[conn.Item1], keypoints[conn.Item2]);
                    }
                }

                // Draw Right Arm Joints
                for (int i = 6; i <= 10; i += 2)
                {
                    if (!keypoints[i].IsEmpty)
                    {
                        g.FillEllipse(brush, keypoints[i].X - 5, keypoints[i].Y - 5, 10, 10);
                    }
                }
            }
        }

        public void Dispose()
        {
            _session?.Dispose();
        }
    }
}

