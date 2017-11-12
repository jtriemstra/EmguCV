using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
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
            OUTPUT_PICTUREBOX
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

        private static void DoCallbacks(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
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
                CvInvoke.Laplacian(objSourceImage, objLaplaceEdgeImage, DepthType.Cv16S);
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
    }
}
