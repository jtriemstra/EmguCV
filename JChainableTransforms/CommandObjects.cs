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
using ParameterKey = JChainableTransforms.Transform.ParameterKey;

namespace JChainableTransforms
{
    public class CommandObjects
    {
        public static Transform GetObject(String strTransform)
        {
            switch (strTransform)
            {
                case "Canny":
                    return new Canny();
                case "Sobel":
                    return new Sobel();
                case "Laplace":
                    return new Laplace();
                case "Blur":
                    return new Blur();
                case "Pyr":
                    return new Pyr();
                case "Grayscale":
                    return new Grayscale();
                case "AdaptiveThreshold":
                    return new AdaptiveThreshold();
                case "StaticThreshold":
                    return new StaticThreshold();
                case "To8Bit":
                    return new To8Bit();
                case "Dilate":
                    return new Dilate();
                case "Erode":
                    return new Erode();
                case "HoughP":
                    return new HoughP();
                case "Hough":
                    return new Hough();
                default:
                    return null;
            }
        }

        public abstract class Transform
        {
            public Transform Next;
            public Dictionary<ParameterKey, Object> Parameters;
            public abstract void Execute(Mat objSourceImage);
            public override string ToString()
            {
                return this.GetType().Name;
            }
        }

        public class Pyr : Transform
        {
            public Pyr()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.PYR_REPETITIONS] = 1;
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objResampledImage = objSourceImage.Clone())
                {
                    int repetitions = Convert.ToInt32(Parameters[ParameterKey.PYR_REPETITIONS]);
                    if (repetitions > 0)
                    {
                        for (int i = 0; i < repetitions; i++)
                        {
                            CvInvoke.PyrDown(objResampledImage, objResampledImage);
                        }
                        for (int i = 0; i < repetitions; i++)
                        {
                            CvInvoke.PyrUp(objResampledImage, objResampledImage);
                        }
                    }
                    if (Next != null) Next.Execute(objResampledImage);
                }
            }
        }

        public class Blur : Transform
        {
            public Blur()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.BLUR_APERTURE] = 1;
            }
            
            public override void Execute(Mat objSourceImage)
            {
                using (Mat objBlurredImage = new Mat())
                {
                    int aperture = Convert.ToInt32(Parameters[ParameterKey.BLUR_APERTURE]);

                    if (aperture % 2 == 0)
                    {
                        aperture += 1;
                    }
                    CvInvoke.MedianBlur(objSourceImage, objBlurredImage, aperture);
                    if (Next != null) Next.Execute(objBlurredImage);                    
                }
            }
        }

        public class Sobel : Transform
        {
            public Sobel()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.SOBEL_APERTURE] = 1;
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objSobelEdgeImage = new Mat())
                {
                    int intSobelAperture = Convert.ToInt32(Parameters[ParameterKey.SOBEL_APERTURE]);

                    //TODO: x, y > 0 ignores horizontal/vertical lines, but setting both to 0 throws exception. Why?
                    //TODO: why would I use different x, y here? If I know/expect something about the image?
                    //NOTE: looks like Scharr only works with x,y == 0,1 or 1,0

                    CvInvoke.Sobel(objSourceImage, objSobelEdgeImage, DepthType.Cv16S, 1, 0, intSobelAperture);

                    if (Next != null) Next.Execute(objSobelEdgeImage);  
                }
            }
        }

        public class Laplace : Transform
        {
            public Laplace()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.LAPLACE_DEST_DEPTH] = DepthType.Cv16S;
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objLaplaceEdgeImage = new Mat())
                {
                    DepthType depth = DepthType.Cv16S;
                    if (Parameters.ContainsKey(ParameterKey.LAPLACE_DEST_DEPTH))
                    {
                        depth = (DepthType)Parameters[ParameterKey.LAPLACE_DEST_DEPTH];
                    }

                    CvInvoke.Laplacian(objSourceImage, objLaplaceEdgeImage, depth);
                    if (Next != null) Next.Execute(objLaplaceEdgeImage);  
                }
            }
        }

        public class Canny : Transform
        {
            public Canny()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.CANNY_LOWER_THRESHOLD] = (decimal)180.0;
                Parameters[ParameterKey.CANNY_UPPER_THRESHOLD] = (decimal)120.0;
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objCannyImage = new Mat())
                {
                    double cannyLowerThreshold = Convert.ToDouble(Parameters[ParameterKey.CANNY_LOWER_THRESHOLD]);
                    double cannyUpperThreshold = Convert.ToDouble(Parameters[ParameterKey.CANNY_UPPER_THRESHOLD]);
                    //TODO: looks like source image can't be greater than 8-bit depths? Investigate
                    if (objSourceImage.Depth != DepthType.Cv8S) objSourceImage.ConvertTo(objSourceImage, DepthType.Cv8U);
                    CvInvoke.Canny(objSourceImage, objCannyImage, cannyLowerThreshold, cannyUpperThreshold);

                    if (Next != null) Next.Execute(objCannyImage);  
                }
            }
        }

        public class Grayscale : Transform
        {
            public Grayscale()
            {
                Parameters = new Dictionary<ParameterKey, object>();
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objGrayImage = new Mat())
                {
                    try
                    {
                        CvInvoke.CvtColor(objSourceImage, objGrayImage, ColorConversion.Bgr2Gray);
                        if (Next != null) Next.Execute(objGrayImage);
                    }
                    catch (Exception ex)
                    {
                        int i = 0;
                    }
                }
            }
        }

        public class StaticThreshold : Transform
        {
            public StaticThreshold()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.THRESH_MIN] = 90;
                Parameters[ParameterKey.THRESH_MAX] = 255;
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objBinaryImage = new Mat())
                {
                    CvInvoke.Threshold(objSourceImage, objBinaryImage, Convert.ToInt32(Parameters[ParameterKey.THRESH_MIN]), Convert.ToInt32(Parameters[ParameterKey.THRESH_MAX]), ThresholdType.Binary);
                    
                    if (Next != null) Next.Execute(objBinaryImage);  
                }
            }
        }

        public class AdaptiveThreshold : Transform
        {
            public AdaptiveThreshold()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.THRESH_MAX] = 255;
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objBinaryImage = new Mat())
                {
                    try
                    {
                        CvInvoke.AdaptiveThreshold(objSourceImage, objBinaryImage, Convert.ToInt32(Parameters[ParameterKey.THRESH_MAX]), AdaptiveThresholdType.MeanC, ThresholdType.Binary, 7, 0);
                    }
                    catch (Exception ex)
                    {
                        int i = 0;
                    }
                    if (Next != null) Next.Execute(objBinaryImage);  
                }
            }
        }

        public class To8Bit : Transform
        {
            public To8Bit()
            {
                Parameters = new Dictionary<ParameterKey, object>();
            }

            public override void Execute(Mat objSourceImage)
            {
                using (Mat objConvertedImage = new Mat())
                {
                    CvInvoke.ConvertScaleAbs(objSourceImage, objConvertedImage, 1.0, 0.0);
                    if (Next != null) Next.Execute(objConvertedImage);  
                }
            }
        }

        public class Dilate : Transform
        {
            public Dilate()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.DILATE_ITERATIONS] = 2;
            }

            public override void Execute(Mat objSourceImage)
            {
                int iterations = Convert.ToInt32(Parameters[ParameterKey.DILATE_ITERATIONS]);

                using (Mat objConvertedImage = new Mat())
                {
                    //TODO: this was just copied from https://stackoverflow.com/questions/27819882/emgu-cv-skeleton-of-an-image-in-emgucv-skeletonization
                    var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(7, 7), new Point(-1, -1));
                    CvInvoke.Dilate(objSourceImage, objConvertedImage, element, new Point(-1, -1), iterations, BorderType.Default, default(MCvScalar));
                    if (Next != null) Next.Execute(objConvertedImage);  
                }
            }
        }

        public class Erode : Transform
        {
            public Erode()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.ERODE_ITERATIONS] = 2;
            }

            public override void Execute(Mat objSourceImage)
            {
                int iterations = Convert.ToInt32(Parameters[ParameterKey.ERODE_ITERATIONS]);

                using (Mat objConvertedImage = new Mat())
                {
                    //TODO: this was just copied from https://stackoverflow.com/questions/27819882/emgu-cv-skeleton-of-an-image-in-emgucv-skeletonization
                    var element = CvInvoke.GetStructuringElement(ElementShape.Cross, new Size(7, 7), new Point(-1, -1));
                    CvInvoke.Erode(objSourceImage, objConvertedImage, element, new Point(-1, -1), iterations, BorderType.Default, default(MCvScalar));
                    if (Next != null) Next.Execute(objConvertedImage);  
                }
            }
        }

        public class HoughP : Transform
        {
            public HoughP()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.HOUGH_THRESHOLD] = 20;
                Parameters[ParameterKey.HOUGH_THETA_DEGREES] = 45.0;
                Parameters[ParameterKey.HOUGH_TOLERANCE] = 5;
                Parameters[ParameterKey.HOUGH_MIN_LENGTH] = 30;
                Parameters[ParameterKey.HOUGH_MAX_LINE_GAP] = 10;
            }

            public override void Execute(Mat objSourceImage)
            {
                int threshold = 20;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_THRESHOLD)) threshold = Convert.ToInt32(Parameters[ParameterKey.HOUGH_THRESHOLD]);
                double theta = 4.0;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_THETA_DEGREES)) theta = Convert.ToDouble(Parameters[ParameterKey.HOUGH_THETA_DEGREES]);
                int maxlinegap = 10;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_MAX_LINE_GAP)) maxlinegap = Convert.ToInt32(Parameters[ParameterKey.HOUGH_MAX_LINE_GAP]);
                double tolerance = 5;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_TOLERANCE)) tolerance = Convert.ToDouble(Parameters[ParameterKey.HOUGH_TOLERANCE]);
                int minlength = 5;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_MIN_LENGTH)) minlength = Convert.ToInt32(Parameters[ParameterKey.HOUGH_MIN_LENGTH]);

                //TODO: push this out to the caller, or wrap in a conditional
                /*Image<Bgr, Byte> objConvertedSource = objSourceImage.ToImage<Bgr, Byte>();
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(objConvertedSource, grayImage, ColorConversion.Bgr2Gray);
                */

                System.Diagnostics.Debug.Write(theta * Math.PI / 180.0);
                System.Diagnostics.Debug.Write(" ");
                LineSegment2D[] lines = CvInvoke.HoughLinesP(
                       objSourceImage,
                       tolerance, //Distance resolution in pixel-related units
                       theta * Math.PI / 180.0, //Angle resolution measured in radians.
                       threshold,
                       minlength, //min Line length
                       maxlinegap); //gap between lines
                System.Diagnostics.Debug.WriteLine(lines.Length);

                Image<Bgr, Byte> objConvertedSource = objSourceImage.ToImage<Bgr, Byte>();
                Image<Bgr, Byte> lineImage = objConvertedSource.CopyBlank();
                foreach (LineSegment2D line in lines)
                    lineImage.Draw(line, new Bgr(Color.Green), 2);

                using (Mat objOutput = new Mat(lineImage.Mat, new Rectangle(new Point(0, 0), lineImage.Size)))
                {
                    if (Next != null) Next.Execute(objOutput); 
                }
            }
        }

        public class Hough : Transform
        {
            public Hough()
            {
                Parameters = new Dictionary<ParameterKey, object>();
                Parameters[ParameterKey.HOUGH_THRESHOLD] = 20;
                Parameters[ParameterKey.HOUGH_THETA_DEGREES] = 45.0;
            }

            public override void Execute(Mat objSourceImage)
            {
                int threshold = 20;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_THRESHOLD)) threshold = Convert.ToInt32(Parameters[ParameterKey.HOUGH_THRESHOLD]);
                double theta = 4.0;
                if (Parameters.ContainsKey(ParameterKey.HOUGH_THETA_DEGREES)) theta = Convert.ToDouble(Parameters[ParameterKey.HOUGH_THETA_DEGREES]);

                //TODO: push this out to the caller, or wrap in a conditional
                /*Image<Bgr, Byte> objConvertedSource = objSourceImage.ToImage<Bgr, Byte>();
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(objConvertedSource, grayImage, ColorConversion.Bgr2Gray);
                */
                LineSegment2D[] lines;
                using (var vector = new VectorOfPointF())
                {
                    CvInvoke.HoughLines(objSourceImage, vector,
                        1,
                        theta * Math.PI / 180.0,
                        threshold);

                    var linesList = new List<LineSegment2D>();
                    for (var i = 0; i < vector.Size; i++)
                    {
                        var rho = vector[i].X;
                        var theta_actual = vector[i].Y;
                        var pt1 = new Point();
                        var pt2 = new Point();
                        var a = Math.Cos(theta_actual);
                        var b = Math.Sin(theta_actual);
                        var x0 = a * rho;
                        var y0 = b * rho;
                        pt1.X = (int)Math.Round(x0 + objSourceImage.Width * (-b));
                        pt1.Y = (int)Math.Round(y0 + objSourceImage.Height * (a));
                        pt2.X = (int)Math.Round(x0 - objSourceImage.Width * (-b));
                        pt2.Y = (int)Math.Round(y0 - objSourceImage.Height * (a));

                        linesList.Add(new LineSegment2D(pt1, pt2));
                    }

                    lines = linesList.ToArray();
                }

                /*LineSegment2D[] lines = CvInvoke.HoughLines(
                       grayImage,
                       1, //Distance resolution in pixel-related units
                       theta * Math.PI / 180.0, //Angle resolution measured in radians.
                       threshold); //gap between lines*/

                Image<Bgr, Byte> objConvertedSource = objSourceImage.ToImage<Bgr, Byte>();
                Image<Bgr, Byte> lineImage = objConvertedSource.CopyBlank();
                foreach (LineSegment2D line in lines)
                    lineImage.Draw(line, new Bgr(Color.Green), 2);

                using (Mat objOutput = new Mat(lineImage.Mat, new Rectangle(new Point(0, 0), lineImage.Size)))
                {
                    if (Next != null) Next.Execute(objOutput);
                }
            }
        }

        public delegate void DisplayCommand(Mat objSourceImage);

        public class Display : Transform
        {
            private DisplayCommand m_objDelegate;

            public Display(DisplayCommand objDelegate)
            {
                m_objDelegate = objDelegate;
            }

            public override void Execute(Mat objSourceImage)
            {
                m_objDelegate(objSourceImage);
            }
        }
    }
}
