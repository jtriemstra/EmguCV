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

        public Form1()
        {
            InitializeComponent();

            Mat objSourceImage = new Mat(m_strSourceImageFileName);
            ImageViewer.Show(objSourceImage, WINDOW_NAME);
        }

        private void numAperture_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form load event");
            //TODO: why did image not show in this event?
        }
    }
}
