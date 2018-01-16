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

namespace NAddSobelDimensions
{
    class Program
    {
        private static String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";

        static void Main(string[] args)
        {

            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            Mat objSobelXImage = new Mat();
            Mat objSobelYImage = new Mat();
            Mat objCannyXImage = new Mat();
            Mat objCannyYImage = new Mat();


            CvInvoke.Sobel(objSourceImage, objSobelXImage, DepthType.Cv16S, 0, 1, 1);

            CvInvoke.Sobel(objSourceImage, objSobelYImage, DepthType.Cv16S, 1, 0, 1);

            /*
            if (objSobelXImage.Depth != DepthType.Cv8S) objSobelXImage.ConvertTo(objSobelXImage, DepthType.Cv8U);
            CvInvoke.Canny(objSobelXImage, objCannyXImage, 180.0, 120.0);

            if (objSobelYImage.Depth != DepthType.Cv8S) objSobelYImage.ConvertTo(objSobelYImage, DepthType.Cv8U);
            CvInvoke.Canny(objSobelYImage, objCannyYImage, 180.0, 120.0);
            */

            if (objSobelXImage.Depth != DepthType.Cv8S) CvInvoke.ConvertScaleAbs(objSobelXImage, objSobelXImage, 1.0, 0.0);
            CvInvoke.Canny(objSobelXImage, objCannyXImage, 180.0, 120.0);

            if (objSobelYImage.Depth != DepthType.Cv8S) CvInvoke.ConvertScaleAbs(objSobelYImage, objSobelYImage, 1.0, 0.0);
            CvInvoke.Canny(objSobelYImage, objCannyYImage, 180.0, 120.0);

            ImageViewer.Show(objCannyXImage);
            ImageViewer.Show(objCannyYImage);
        }
    }
}
