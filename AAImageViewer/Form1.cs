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

namespace AAImageViewer
{
    public partial class Form1 : Form
    {
        private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\ShapeTest.jpg";

        public Form1()
        {
            InitializeComponent();
            
            Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(m_strSourceImageFileName);
            
            ImageViewer.Show(My_Image, "Test Window");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(m_strSourceImageFileName);
            //This fails
            ImageViewer.Show(My_Image, "Test Window");
        }
    }
}
