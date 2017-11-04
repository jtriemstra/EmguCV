using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace FPyrUpDownNoiseRemoval
{
    public partial class Form1 : Form
    {
        private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\ShapeTest.jpg";
        private const String WINDOW_NAME = "Test Window";
        private Mat m_objSourceImage;

        public Form1()
        {
            InitializeComponent();

            m_objSourceImage = new Mat(m_strSourceImageFileName);
        }

        private void numReptitions_ValueChanged(object sender, EventArgs e)
        {
            int intRepetitions = (int) numRepetitions.Value;
            if (intRepetitions == 0)
            {
                DisplayOriginal();
                return;
            }          

            //Compare these two approaches, not sure how OpenCV handles the memory. Conclusion: approaches are equivalent.
            DisplayBlurred(intRepetitions);
            DisplayBlurredExplicitCopy(intRepetitions);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form load event");

            //ImageViewer.Show(objSourceImage, WINDOW_NAME);
            DisplayOriginal();
        }

        private void DisplayOriginal()
        {
            objImageDisplay.Image = m_objSourceImage.Bitmap;
            objImageDisplay2.Image = m_objSourceImage.Bitmap;
        }

        private void DisplayBlurred(int intRepetitions)
        {
            Mat objDestinationImage = m_objSourceImage.Clone();

            for (int i = 0; i < intRepetitions; i++)
            {
                CvInvoke.PyrDown(objDestinationImage, objDestinationImage);
            }
            for (int i = 0; i < intRepetitions; i++)
            {
                CvInvoke.PyrUp(objDestinationImage, objDestinationImage);
            }

            objImageDisplay.Image = objDestinationImage.Bitmap;
        }

        private void DisplayBlurredExplicitCopy(int intRepetitions)
        {
            if (intRepetitions > 3 || intRepetitions < 1) return;

            Mat objDestinationImage1 = new Mat();
            Mat objDestinationImage2 = new Mat();
            Mat objDestinationImage3 = new Mat();
            Mat objDestinationImage4 = new Mat();
            Mat objDestinationImage5 = new Mat();
            Mat objDestinationImage6 = new Mat();

            CvInvoke.PyrDown(m_objSourceImage, objDestinationImage1);
            if (intRepetitions > 1)
            {
                CvInvoke.PyrDown(objDestinationImage1, objDestinationImage2);
                if (intRepetitions > 2)
                {
                    CvInvoke.PyrDown(objDestinationImage2, objDestinationImage3);
                    CvInvoke.PyrUp(objDestinationImage3, objDestinationImage4);
                    CvInvoke.PyrUp(objDestinationImage4, objDestinationImage5);
                    CvInvoke.PyrUp(objDestinationImage5, objDestinationImage6);
                }
                else
                {

                    CvInvoke.PyrUp(objDestinationImage2, objDestinationImage5);
                    CvInvoke.PyrUp(objDestinationImage5, objDestinationImage6);
                }
            }
            else
            {

                CvInvoke.PyrUp(objDestinationImage1, objDestinationImage6);
            }

            objImageDisplay2.Image = objDestinationImage6.Bitmap;
        }



    }
}


