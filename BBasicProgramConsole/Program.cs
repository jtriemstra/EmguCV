using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace BBasicProgramConsole
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

                //Show the image using ImageViewer from Emgu.CV.UI
                ImageViewer.Show(My_Image, "Test Window");
            }
        }
    }
}
