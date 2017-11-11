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

namespace IEmguImageBox
{
    public partial class Form1 : Form
    {
        private String m_strLargeImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Mat objSourceImage = new Mat(m_strLargeImageFileName))
            {
                objImageDisplay.Image = objSourceImage;
            }

            Mat objSourceImage2 = new Mat(m_strLargeImageFileName);
            objMemoryLeakDisplay.Image = objSourceImage2;
            
        }
    }
}
