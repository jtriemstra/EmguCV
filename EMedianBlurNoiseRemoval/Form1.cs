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

namespace EMedianBlurNoiseRemoval
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

        private void numAperture_ValueChanged(object sender, EventArgs e)
        {
            int intAperture = (int) numAperture.Value;
            if (intAperture == 0)
            {
                DisplayOriginal();
                return;
            }

            if (intAperture % 2 == 0)
            {
                intAperture += 1;
            }

            DisplayBlurred(intAperture);
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
        }

        private void DisplayBlurred(int intAperture)
        {
            Mat objDestinationImage = new Mat();
            CvInvoke.MedianBlur(m_objSourceImage, objDestinationImage, intAperture);
            objImageDisplay.Image = objDestinationImage.Bitmap;
        }
    }
}
