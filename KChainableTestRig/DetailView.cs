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
using Emgu.CV.Util;

namespace KChainableTestRig
{
    public partial class DetailView : Form
    {
        public DetailView(Mat objDetailImage)
        {
            InitializeComponent();

            if (objDetailImage.NumberOfChannels == 1 && objDetailImage.Depth == DepthType.Cv8U)
            {
                Image<Gray, Byte> x = objDetailImage.ToImage<Gray, Byte>();
                objDetailDisplay.Image = x.ToBitmap();
            }
            else if (objDetailImage.NumberOfChannels == 3 && objDetailImage.Depth == DepthType.Cv8U)
            {
                Image<Bgr, Byte> x = objDetailImage.ToImage<Bgr, Byte>();
                objDetailDisplay.Image = x.ToBitmap();
            }
            else
            {
                objDetailDisplay.Image = objDetailImage.Bitmap;
            }
            DoSizing();
        }

        public DetailView(Image objImage)
        {
            InitializeComponent();
            objDetailDisplay.Image = objImage;

            DoSizing();
        }

        public void DoSizing()
        {
            panel1.Controls.Add(objDetailDisplay);

        }
    }
}
