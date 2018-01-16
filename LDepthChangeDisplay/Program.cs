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
using JChainableTransforms;
using ParameterKey = JChainableTransforms.Transform.ParameterKey;
using DoTransform = JChainableTransforms.Transform.DoTransform;

namespace LDepthChangeDisplay
{
    class Program
    {
        private static String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";

        static void Main(string[] args)
        {

            

            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            //ImageViewer.Show(objSourceImage);

            Dictionary<ParameterKey, Object> hshParameters = new Dictionary<ParameterKey, object>();
            hshParameters[ParameterKey.BLUR_APERTURE] = 1;
            hshParameters[ParameterKey.SOBEL_APERTURE] = 1;

            hshParameters[ParameterKey.PYR_REPETITIONS] = 1;
            hshParameters[ParameterKey.CONVERT_DEST_DEPTH] = DepthType.Cv8S;
            hshParameters[ParameterKey.WINDOW_NAME] = "8S";

            //Results of test - ImageViewer also displays all black after changing the depth
            //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.ChangeDepth, DisplayNewWindow2);

            //Results of test - ImageViewer also displays all black after doing laplace
            Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoLaplace, DisplayNewWindow2);

        }

        private static void DisplayNewWindow2(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            ImageViewer.Show(objSourceImage);
        }
    }
}
