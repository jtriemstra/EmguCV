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

namespace GRemoveNoiseAndDetectLines
{
    public partial class DetailView : Form
    {
        public DetailView(Mat objDetailImage)
        {
            InitializeComponent();

            objDetailDisplay.Image = objDetailImage.Bitmap;
        }

        public DetailView(Image objDetailImage)
        {
            InitializeComponent();

            objDetailDisplay.Image = objDetailImage;
        }
    }
}
