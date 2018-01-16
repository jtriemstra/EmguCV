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

namespace MLaplaceGrayscale
{
    class Program
    {
        private static String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";

        //this was to test a problem where Laplace on grayscale always yielded only black results. Solution was to add the ConvertScaleAbs call to go from 16bit to 8bit

        static void Main(string[] args)
        {

            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            Mat objGrayImage = new Mat();
            CvInvoke.CvtColor(objSourceImage, objGrayImage, ColorConversion.Bgr2Gray);
            Mat objLaplaceEdgeImage = new Mat();
            CvInvoke.Laplacian(objGrayImage, objLaplaceEdgeImage, DepthType.Cv16S);

            Mat objOutputImage = new Mat();
            CvInvoke.ConvertScaleAbs(objLaplaceEdgeImage, objOutputImage, 1.0, 0.0);
            ImageViewer.Show(objOutputImage);

            //.5 scale results in "duller" whites
            objOutputImage = new Mat();
            CvInvoke.ConvertScaleAbs(objLaplaceEdgeImage, objOutputImage, .5, 0.0);
            ImageViewer.Show(objOutputImage);

            //100 offset results in gray instead of black
            objOutputImage = new Mat();
            CvInvoke.ConvertScaleAbs(objLaplaceEdgeImage, objOutputImage, 1.0, 100.0);
            ImageViewer.Show(objOutputImage);
        }
    }
}
