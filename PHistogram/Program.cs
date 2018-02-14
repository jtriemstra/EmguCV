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
using System.Diagnostics;
using Emgu.CV.Util;
using System.Runtime.InteropServices;

namespace PHistogram
{
    class Program
    {
        private static String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20180113_152015034.jpg";

        static void Main(string[] args)
        {
            AutoGenerateGray();
        }

        static void HistogramClassGray()
        {
            float[] GrayHist;

            Image<Gray, Byte> img_gray = new Image<Gray, byte>("ImageFileName");

            DenseHistogram objHistogram = new DenseHistogram(256, new RangeF(0, 255));
            objHistogram.Calculate(new Image<Gray, Byte>[] { img_gray }, true, null);
            //The data is here
            //Histo.MatND.ManagedArray
            GrayHist = new float[256];
            //objHistogram.MatND.ManagedArray.CopyTo(GrayHist, 0);
        }

        static void AutoGenerate()
        {
            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            Form frm = new Form();
            Image<Bgr, byte> img = objSourceImage.ToImage<Bgr, byte>();

            HistogramBox hb = new HistogramBox();
            hb.GenerateHistograms(img, 256);// show 256 shades
            hb.Enabled = true;
            

            hb.Size = new System.Drawing.Size(700,700);// change to your preferred size 
            frm.Controls.Add(hb);
            hb.Refresh();

            frm.ShowDialog(); 
        }

        static void AutoGenerateGray()
        {
            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            Form frm = new Form();
            Image<Gray, byte> img = objSourceImage.ToImage<Gray, byte>();

            HistogramBox hb = new HistogramBox();
            hb.GenerateHistograms(img, 256);// show 256 shades
            hb.Enabled = true;


            hb.Size = new System.Drawing.Size(700, 700);// change to your preferred size 
            frm.Controls.Add(hb);
            hb.Refresh();

            frm.ShowDialog();
        }

        static void BookGray()
        {
            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            Mat objGray = new Mat();
            CvInvoke.CvtColor(objSourceImage, objGray, ColorConversion.Bgr2Gray);

            //float[] bValueRange = new float[] { 0, 255 };
            //float[] gValueRange = new float[] { 0, 255 };
            float[] bothValueRange = new float[] { 0, 255 };
            int[] histSize = new int[] { 255 };
            int[] ch = new int[] { 0 };

            Mat objHist = new Mat();
            VectorOfMat objInputs = new VectorOfMat();
            objInputs.Push(objGray);

            try
            {
                CvInvoke.CalcHist(objInputs, ch, null, objHist, histSize, bothValueRange, true);
            }
            catch (Exception ex)
            {
                int asdf = 0;
            }
            CvInvoke.Normalize(objHist, objHist, 0, 1000, NormType.MinMax);

            int scale = 10;
            Mat objHistImg = new Mat(1000, histSize[0] * scale, DepthType.Cv8U, 1);

            for (int h = 0; h < histSize[0]; h++)
            {
                float[] hval = new float[1];

                Marshal.Copy(objHist.DataPointer + ((h * 1 + 0) * objHist.ElementSize), hval, 0, 1);

                CvInvoke.Rectangle(objHistImg, new Rectangle(h * scale, 0, scale, Convert.ToInt32(hval[0])), new MCvScalar(255), -1);

            }

            ImageViewer.Show(objHistImg);

        }

        static void ImplementBook()
        {
            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            Mat objHsv = new Mat();
            CvInvoke.CvtColor(objSourceImage, objHsv, ColorConversion.Bgr2Hsv);

            float[] hValueRange = new float[] { 0, 180 };
            float[] sValueRange = new float[] { 0, 256 };
            float[] bothValueRange = new float[] { 0, 180, 0, 256 };
            int[] histSize = new int[] {30,32};
            int[] ch = new int[] {0,1};
            
            Mat objHist = new Mat();
            VectorOfMat objInputs = new VectorOfMat();
            objInputs.Push(objHsv);

            try
            {
                CvInvoke.CalcHist(objInputs, ch, null, objHist, histSize, bothValueRange, false);
            }
            catch (Exception ex)
            {
                int asdf = 0;
            }
            CvInvoke.Normalize(objHist, objHist, 0, 255, NormType.MinMax);

            int scale = 10;
            Mat objHistImg = new Mat(histSize[0] * scale, histSize[1] * scale, DepthType.Cv8U, 3);

            for (int h = 0; h < histSize[0]; h++)
            {
                for (int s = 0; s < histSize[1]; s++)
                {
                    float[] hval = new float[1];

                    Marshal.Copy(objHist.DataPointer + (h * objHist.Cols + s) * objHist.ElementSize, hval, 0, 1);

                    CvInvoke.Rectangle(objHistImg, new Rectangle(h * scale, s * scale, scale, scale), new MCvScalar(hval[0]), -1);
                }
            }

            ImageViewer.Show(objHistImg);

        }
    }
}
