using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System.Windows.Forms;
using System.Drawing;

namespace JChainableTransforms
{
    public class Transform
    {
        public delegate void DoTransform(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks);

        public enum ParameterKey
        {
            SOBEL_APERTURE,
            BLUR_APERTURE,
            PYR_REPETITIONS,
            OUTPUT_PICTUREBOX,
            WINDOW_NAME,
            LAPLACE_DEST_DEPTH,
            CONVERT_DEST_DEPTH,
            DILATE_ITERATIONS,
            ERODE_ITERATIONS,
            HOUGH_THRESHOLD,
            HOUGH_THETA_DEGREES,
            HOUGH_MAX_LINE_GAP,
            HOUGH_TOLERANCE,
            HOUGH_MIN_LENGTH,
            CANNY_UPPER_THRESHOLD,
            CANNY_LOWER_THRESHOLD,
            THRESH_MIN,
            THRESH_MAX
        }

        public static String[] TransformNames = { "Canny", "Sobel", "Laplace", "Blur", "Pyr", "Grayscale", "AdaptiveThreshold", "StaticThreshold", "To8Bit", "Dilate", "Erode", "Hough", "HoughP", "DrawRectangles" };

        public static TransformParameter[] GetParameters(String strTransform)
        {
            switch (strTransform)
            {
                case "Canny":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.CANNY_LOWER_THRESHOLD, Type = ParameterType.FLOAT, MinValue = 1, MaxValue = 255 }, new TransformParameter() { Key = ParameterKey.CANNY_UPPER_THRESHOLD, Type = ParameterType.FLOAT, MinValue = 2, MaxValue = 255 } };
                case "Sobel":
                    return new TransformParameter[] { new TransformParameter() {Key= ParameterKey.SOBEL_APERTURE, Type = ParameterType.INT, IntValue = 1, MinValue = 1, MaxValue = 7 }};
                case "Laplace":
                    return new TransformParameter[] { new TransformParameter() {Key=ParameterKey.LAPLACE_DEST_DEPTH, Type = ParameterType.CHANNEL_DEPTH, DepthValue=DepthType.Cv16S }};
                case "Blur":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.BLUR_APERTURE, Type = ParameterType.INT, IntValue = 1, MinValue = 1, MaxValue = 7 } };
                case "Pyr":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.PYR_REPETITIONS, Type = ParameterType.INT, IntValue = 1, MinValue = 1, MaxValue = 7 } };
                case "Grayscale":
                    return new TransformParameter[] { };
                case "AdaptiveThreshold":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.THRESH_MAX, Type = ParameterType.INT, IntValue = 255, MinValue = 0, MaxValue = 255 } };
                case "StaticThreshold":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.THRESH_MIN, Type = ParameterType.INT, IntValue = 90, MinValue = 0, MaxValue = 255 }, new TransformParameter() { Key = ParameterKey.THRESH_MAX, Type = ParameterType.INT, IntValue = 255, MinValue = 0, MaxValue = 255 } };
                case "To8Bit":
                    return new TransformParameter[] { };
                case "Dilate":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.DILATE_ITERATIONS, Type = ParameterType.INT, IntValue = 2, MinValue = 1, MaxValue = 10 } };
                case "Erode":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.ERODE_ITERATIONS, Type = ParameterType.INT, IntValue = 2, MinValue = 1, MaxValue = 10 } };
                case "HoughP":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.HOUGH_THRESHOLD, Type = ParameterType.INT, IntValue = 20, MinValue = 0, MaxValue = 255 }, new TransformParameter() { Key = ParameterKey.HOUGH_THETA_DEGREES, Type = ParameterType.INT, IntValue = 4, MinValue = 0, MaxValue = 180 }, new TransformParameter() { Key = ParameterKey.HOUGH_TOLERANCE, Type = ParameterType.INT, IntValue = 5, MinValue = 0, MaxValue = 20 }, new TransformParameter() { Key = ParameterKey.HOUGH_MIN_LENGTH, Type = ParameterType.INT, IntValue = 30, MinValue = 0, MaxValue = 300 }, new TransformParameter() { Key = ParameterKey.HOUGH_MAX_LINE_GAP, Type = ParameterType.INT, IntValue = 10, MinValue = 0, MaxValue = 40 } };
                case "Hough":
                    return new TransformParameter[] { new TransformParameter() { Key = ParameterKey.HOUGH_THRESHOLD, Type = ParameterType.INT, IntValue = 20, MinValue = 0, MaxValue = 255 }, new TransformParameter() { Key = ParameterKey.HOUGH_THETA_DEGREES, Type = ParameterType.INT, IntValue = 4, MinValue = 0, MaxValue = 180 } };
                case "DrawRectangles":
                    return new TransformParameter[] { };
                default:
                    return new TransformParameter[] { };
            }
        }
        
        public enum ParameterType
        {
            FLOAT,
            INT,
            CHANNEL_DEPTH
        }

        public class TransformParameter
        {
            public ParameterKey Key;
            public ParameterType Type;
            public int IntValue;
            public float FloatValue;
            public DepthType DepthValue;
            public int MinValue = Int32.MinValue;
            public int MaxValue = Int32.MaxValue;
        }

        public static void Do(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            DoCallbacks(objSourceImage, hshParameters, chainedCallbacks);
        }

        public static void Display(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            PictureBox objOutput = (PictureBox) hshParameters[ParameterKey.OUTPUT_PICTUREBOX];
            if (objOutput.Image != null) objOutput.Image.Dispose();
            objOutput.Image = objSourceImage.Bitmap;
        }

        public static void Display2(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            PictureBox objOutput = (PictureBox)hshParameters[ParameterKey.OUTPUT_PICTUREBOX];
            //TODO: this is funky, but if I don't keep a reference to the Bitmap, the picturebox doesn't populate, at least for large images. See the HPictureBox project.
            Bitmap x = new Bitmap(objSourceImage.Bitmap);
            if (objOutput.Image != null) objOutput.Image.Dispose();
            objOutput.Image = x;
        }

        public static void DoCallbacks(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            if (chainedCallbacks.Length > 0)
            {
                DoTransform[] reducedCallbacks = new DoTransform[chainedCallbacks.Length - 1];
                Array.Copy(chainedCallbacks, 1, reducedCallbacks, 0, reducedCallbacks.Length);

                chainedCallbacks[0](objSourceImage, hshParameters, reducedCallbacks);
            }
        }

        public static void DoCanny(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objCannyImage = new Mat())
            {
                double cannyThreshold = 180.0;
                double cannyThresholdLinking = 120.0;
                //TODO: looks like source image can't be greater than 8-bit depths? Investigate
                if (objSourceImage.Depth != DepthType.Cv8S) objSourceImage.ConvertTo(objSourceImage, DepthType.Cv8U);
                CvInvoke.Canny(objSourceImage, objCannyImage, cannyThreshold, cannyThresholdLinking);

                DoCallbacks(objCannyImage, hshParameters, chainedCallbacks);
            }
        }

        //Here, src and dst are your image input and output. The argument ddepth allows you to select the depth (type) of the generated output (e.g., CV_32F). As a good example of how to use ddepth, if src is an 8-bit image, then the dst should have a depth of at least CV_16S to avoid overflow. xorder and yorder are the orders of the derivative. Typically, you’ll use 0, 1, or at most 2; a 0 value indicates no derivative in that direction.11 The ksize parameter should be odd and is the width (and the height) of the filter to be used. Currently, aperture sizes up to 31 are supported.12 The scale factor and delta are applied to the derivative before storing in dst. 
        public static void DoSobel(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objSobelEdgeImage = new Mat())
            {
                int intSobelAperture = (int)hshParameters[ParameterKey.SOBEL_APERTURE];

                //TODO: x, y > 0 ignores horizontal/vertical lines, but setting both to 0 throws exception. Why?
                //TODO: why would I use different x, y here? If I know/expect something about the image?
                //NOTE: looks like Scharr only works with x,y == 0,1 or 1,0

                CvInvoke.Sobel(objSourceImage, objSobelEdgeImage, DepthType.Cv16S, 1, 0, intSobelAperture);

                DoCallbacks(objSobelEdgeImage, hshParameters, chainedCallbacks);
            }
        }

        public static void DoLaplace(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objLaplaceEdgeImage = new Mat())
            {
                DepthType depth = DepthType.Cv16S;
                if (hshParameters.ContainsKey(ParameterKey.LAPLACE_DEST_DEPTH))
                {
                    depth = (DepthType)hshParameters[ParameterKey.LAPLACE_DEST_DEPTH];
                }

                CvInvoke.Laplacian(objSourceImage, objLaplaceEdgeImage, depth);
                DoCallbacks(objLaplaceEdgeImage, hshParameters, chainedCallbacks);
            }
        }

        public static void DoBlur(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objBlurredImage = new Mat())
            {
                if ((int)hshParameters[ParameterKey.BLUR_APERTURE] % 2 != 0)
                {
                    CvInvoke.MedianBlur(objSourceImage, objBlurredImage, (int)hshParameters[ParameterKey.BLUR_APERTURE]);
                    DoCallbacks(objBlurredImage, hshParameters, chainedCallbacks);
                }
            }
        }

        public static void DoPyr(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objResampledImage = objSourceImage.Clone())
            {
                if ((int)hshParameters[ParameterKey.PYR_REPETITIONS] > 0)
                {
                    for (int i = 0; i < (int)hshParameters[ParameterKey.PYR_REPETITIONS]; i++)
                    {
                        CvInvoke.PyrDown(objResampledImage, objResampledImage);
                    }
                    for (int i = 0; i < (int)hshParameters[ParameterKey.PYR_REPETITIONS]; i++)
                    {
                        CvInvoke.PyrUp(objResampledImage, objResampledImage);
                    }
                    DoCallbacks(objResampledImage, hshParameters, chainedCallbacks);
                }
            }
        }

        /* this requires input depth == CV_8U || depth == CV_16U || depth == CV_32F */
        public static void DoGrayscale(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objGrayImage = new Mat())
            {
                CvInvoke.CvtColor(objSourceImage, objGrayImage, ColorConversion.Bgr2Gray);
                DoCallbacks(objGrayImage, hshParameters, chainedCallbacks);
            }
        }

        /* this requires a grayscale input */
        public static void DoAdaptiveThreshold(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objBinaryImage = new Mat())
            {
                CvInvoke.AdaptiveThreshold(objSourceImage, objBinaryImage, 10, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 7, 0);
                DoCallbacks(objBinaryImage, hshParameters, chainedCallbacks);
            }
        }
        
        /* this requires a grayscale input */
        public static void DoStaticThreshold(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objBinaryImage = new Mat())
            {
                CvInvoke.Threshold(objSourceImage, objBinaryImage, 10, 255, ThresholdType.Binary);
                DoCallbacks(objBinaryImage, hshParameters, chainedCallbacks);
            }
        }

        //TODO: this should include some scaling logic if I keep it
        public static void ChangeDepth(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            DepthType depth = DepthType.Cv16U;
            if (hshParameters.ContainsKey(ParameterKey.CONVERT_DEST_DEPTH))
            {
                depth = (DepthType)hshParameters[ParameterKey.CONVERT_DEST_DEPTH];
            }

            using (Mat objConvertedImage = new Mat())
            {
                objSourceImage.ConvertTo(objConvertedImage, depth);
                DoCallbacks(objConvertedImage, hshParameters, chainedCallbacks);
            }
        }

        public static void To8Bit(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            using (Mat objConvertedImage = new Mat())
            {
                CvInvoke.ConvertScaleAbs(objSourceImage, objConvertedImage, 1.0, 0.0);
                DoCallbacks(objConvertedImage, hshParameters, chainedCallbacks);
            }
        }

        public static void Dilate(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            int iterations = 2;
            if (hshParameters.ContainsKey(ParameterKey.DILATE_ITERATIONS)) iterations = (int) hshParameters[ParameterKey.DILATE_ITERATIONS];

            using (Mat objConvertedImage = new Mat())
            {
                //TODO: this was just copied from https://stackoverflow.com/questions/27819882/emgu-cv-skeleton-of-an-image-in-emgucv-skeletonization
                var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(3, 3), new Point(-1, -1));
                CvInvoke.Dilate(objSourceImage, objConvertedImage, element, new Point(-1, -1), iterations, BorderType.Default, default(MCvScalar));
                DoCallbacks(objConvertedImage, hshParameters, chainedCallbacks);
            }
        }

        public static void Erode(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            int iterations = 2;
            if (hshParameters.ContainsKey(ParameterKey.ERODE_ITERATIONS)) iterations = (int)hshParameters[ParameterKey.ERODE_ITERATIONS];

            using (Mat objConvertedImage = new Mat())
            {
                //TODO: this was just copied from https://stackoverflow.com/questions/27819882/emgu-cv-skeleton-of-an-image-in-emgucv-skeletonization
                var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(3, 3), new Point(-1, -1));
                CvInvoke.Erode(objSourceImage, objConvertedImage, element, new Point(-1, -1), 2, BorderType.Default, default(MCvScalar));
                DoCallbacks(objConvertedImage, hshParameters, chainedCallbacks);
            }
        }

        public static void DoHough(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            int threshold = 20;
            if (hshParameters.ContainsKey(ParameterKey.HOUGH_THRESHOLD)) threshold = (int)hshParameters[ParameterKey.HOUGH_THRESHOLD];

            //TODO: push this out to the caller, or wrap in a conditional
            Image<Bgr, Byte> objConvertedSource = objSourceImage.ToImage<Bgr, Byte>();
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(objConvertedSource, grayImage, ColorConversion.Bgr2Gray);

            LineSegment2D[] lines = CvInvoke.HoughLinesP(
                   grayImage,
                   1, //Distance resolution in pixel-related units
                   Math.PI / 45.0, //Angle resolution measured in radians.
                   threshold, 
                   30, //min Line length
                   10); //gap between lines

            Image<Bgr, Byte> lineImage = objConvertedSource.CopyBlank();
            foreach (LineSegment2D line in lines)
                lineImage.Draw(line, new Bgr(Color.Green), 2);

            using (Mat objOutput = new Mat(lineImage.Mat, new Rectangle(new Point(0,0), lineImage.Size)))
            {
                DoCallbacks(objOutput, hshParameters, chainedCallbacks);
            }
        }

        public static void DoContours(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            Image<Bgr, Byte> objConvertedSource = objSourceImage.ToImage<Bgr, Byte>();
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(objConvertedSource, grayImage, ColorConversion.Bgr2Gray);

            List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(grayImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                        if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                        {
                            if (approxContour.Size == 4) //The contour has 4 vertices.
                            {
                                #region determine if all the angles in the contour are within [80, 100] degree
                                bool isRectangle = true;
                                Point[] pts = approxContour.ToArray();
                                LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                /*for (int j = 0; j < edges.Length; j++)
                                {
                                    double angle = Math.Abs(
                                       edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                    if (angle < 80 || angle > 100)
                                    {
                                        isRectangle = false;
                                        break;
                                    }
                                }*/
                                #endregion

                                if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                            }
                        }
                    }
                }
            }

            Image<Bgr, Byte> triangleRectangleImage = objConvertedSource.CopyBlank();
            foreach (RotatedRect box in boxList)
                triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);

            using (Mat objOutput = new Mat(triangleRectangleImage.Mat, new Rectangle(new Point(0, 0), triangleRectangleImage.Size)))
            {
                DoCallbacks(objOutput, hshParameters, chainedCallbacks);
            }
        }
    }
}
