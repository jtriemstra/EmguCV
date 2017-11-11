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

namespace HPictureBoxTest
{
    public partial class Form1 : Form
    {
        private String m_strLargeImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";
        private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\ShapeTest.jpg";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            using (Mat objSourceImage = new Mat(m_strSourceImageFileName))
            {
                objEmguDisplay.Image = objSourceImage.Bitmap;
            }

            using (Mat objSourceImage = new Mat(m_strLargeImageFileName))
            {
                objLargeEmguDisplay.Image = objSourceImage.Bitmap;
            }

            using (Mat objSourceImage = new Mat(m_strLargeImageFileName))
            {
                Bitmap b = new Bitmap(objSourceImage.Bitmap);
                objMemoryLeakDisplay.Image = b;
            }

            using (Image objSourceImage = Image.FromFile(m_strSourceImageFileName))
            {
                objRawDisplay.Image = objSourceImage;
            }

            using (Image objSourceImage = Image.FromFile(m_strLargeImageFileName))
            {
                objLargeRawDisplay.Image = objSourceImage;
            }

            objTinyDisplay.Image = Image.FromFile(m_strLargeImageFileName);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Mat objSourceImage = new Mat(m_strSourceImageFileName))
            {
                objButtonEmguDisplay.Image = objSourceImage.Bitmap;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Mat objSourceImage = new Mat(m_strSourceImageFileName))
            {
                using (Mat objBlurredImage = new Mat())
                {
                    CvInvoke.MedianBlur(objSourceImage, objBlurredImage, 3);
                    objButtonBlurDisplay.Image = objBlurredImage.Bitmap;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            using (Mat objSourceImage = new Mat(m_strSourceImageFileName))
            {
                using (Mat objBlurredImage = new Mat())
                {
                    CvInvoke.MedianBlur(objSourceImage, objBlurredImage, 3);
                    objNumBlurDisplay.Image = objBlurredImage.Bitmap;
                }
            }
        }

        private void objTinyDisplay_Click(object sender, EventArgs e)
        {
            DetailView objDetail = new DetailView(objTinyDisplay.Image);
            objDetail.Show();
        }
    }
}
