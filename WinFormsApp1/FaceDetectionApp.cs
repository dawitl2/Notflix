using System;
using System.Drawing;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace FullScreenApp
{
    public class FaceDetectionService
    {
        private VideoCapture capture;
        private CascadeClassifier faceCascade;
        private Mat frame;
        private bool isRunning;
        public event Action FaceDetected;
        public event Action FaceNotDetected;

        public FaceDetectionService()
        {
            string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\enkud\\Desktop\\Cinema\\face_detection_xml\\haarcascade_frontalface_default.xml");

            if (!File.Exists(xmlPath))
            {
                throw new FileNotFoundException($"The XML file was not found at: {xmlPath}");
            }

            try
            {
                faceCascade = new CascadeClassifier(xmlPath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading cascade classifier: {ex.Message}");
            }

            try
            {
                capture = new VideoCapture(0);
                frame = new Mat();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error initializing video capture: {ex.Message}");
            }

            isRunning = false;
        }

        public void StartDetection()
        {
            if (!isRunning)
            {
                isRunning = true;
                Application.Idle += ProcessFrame;
            }
        }

        public void StopDetection()
        {
            if (isRunning)
            {
                isRunning = false;
                Application.Idle -= ProcessFrame;
                capture.Release();
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (capture == null || frame == null || faceCascade == null)
            {
                throw new InvalidOperationException("Initialization error.");
            }

            capture.Read(frame);
            if (frame.Empty())
                return;

            Mat grayFrame = new Mat();
            Cv2.CvtColor(frame, grayFrame, ColorConversionCodes.BGR2GRAY);

            var faces = faceCascade.DetectMultiScale(
                grayFrame,
                scaleFactor: 1.1,
                minNeighbors: 6,
                flags: HaarDetectionTypes.DoRoughSearch | HaarDetectionTypes.ScaleImage,
                minSize: new OpenCvSharp.Size(30, 30)
            );

            if (faces.Length > 0)
            {
                FaceDetected?.Invoke();
            }
            else
            {
                FaceNotDetected?.Invoke();
            }
        }
    }
}