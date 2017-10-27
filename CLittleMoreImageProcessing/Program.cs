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

namespace CLittleMoreImageProcessing
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(Openfile.FileName);
                //pictureBox1.Image = My_Image.ToBitmap();

                Image<Gray, byte> gray_image = My_Image.Convert<Gray, byte>();

                //Show the image using ImageViewer from Emgu.CV.UI
                ImageViewer.Show(gray_image, "Test Window");
            }
        }
    }
}
