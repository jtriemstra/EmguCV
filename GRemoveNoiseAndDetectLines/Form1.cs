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
    public partial class Form1 : Form
    {
        //private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\ShapeTest.jpg";
        private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";
        private const String WINDOW_NAME = "Test Window";
        private Mat m_objSourceImage;
        private int m_intPyrRepetitions;
        private int m_intBlurAperture;

        private Mat[,] m_objProcessedImages = new Mat[2,4];
        private PictureBox[,] m_objPictureBoxes = new PictureBox[2, 4];

        private const int BLUR = 0;
        private const int RESAMPLE = 1;
        private const int NO_EDGE = 0;
        private const int CANNY = 1;
        private const int SOBEL = 2;
        private const int LAPLACE = 3;


        public Form1()
        {
            InitializeComponent();

            m_objPictureBoxes[BLUR, NO_EDGE] = objBlurDisplay;
            m_objPictureBoxes[BLUR, CANNY] = objBlurCannyDisplay;
            m_objPictureBoxes[BLUR, SOBEL] = objBlurSobelDisplay;
            m_objPictureBoxes[BLUR, LAPLACE] = objBlurLaplaceDisplay;
            m_objPictureBoxes[RESAMPLE, NO_EDGE] = objPyrDisplay;
            m_objPictureBoxes[RESAMPLE, CANNY] = objPyrCannyDisplay;
            m_objPictureBoxes[RESAMPLE, SOBEL] = objPyrSobelDisplay;
            m_objPictureBoxes[RESAMPLE, LAPLACE] = objPyrLaplaceDisplay;

            m_objSourceImage = new Mat(m_strSourceImageFileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form load event");

            //ImageViewer.Show(objSourceImage, WINDOW_NAME);
            UpdateImagesWrapper();

            numSobelAperture.Minimum = -1;
            numSobelAperture.Maximum = 7;
            numSobelAperture.Increment = 2;
            numSobelAperture.Value = 1;
        }

        private void UpdateImagesWrapper()
        {
            UpdateImages();
        }

        private void UpdateImages()
        {
            DoBlur(m_objSourceImage, objBlurDisplay);
            DoPyr(m_objSourceImage, objPyrDisplay);                     
        }
        
        private void DoBlur(Mat objSourceImage, PictureBox objOutput)
        {
            using (Mat objBlurredImage = new Mat())
            {
                if (m_intBlurAperture % 2 != 0)
                {
                    CvInvoke.MedianBlur(objSourceImage, objBlurredImage, m_intBlurAperture);

                    //TODO: this is funky, but if I don't keep a reference to the Bitmap, the picturebox doesn't populate, at least for large images. See the HPictureBox project.
                    Bitmap x = new Bitmap(objBlurredImage.Bitmap);
                    if (objOutput.Image != null) objOutput.Image.Dispose();
                    objOutput.Image = x;

                    FindEdges(objBlurredImage, BLUR);
                }
            }
        }

        private void DoPyr(Mat objSourceImage, PictureBox objOutput)
        {
            using (Mat objResampledImage = objSourceImage.Clone())
            {
                if (m_intPyrRepetitions > 0)
                {
                    for (int i = 0; i < m_intPyrRepetitions; i++)
                    {
                        CvInvoke.PyrDown(objResampledImage, objResampledImage);
                    }
                    for (int i = 0; i < m_intPyrRepetitions; i++)
                    {
                        CvInvoke.PyrUp(objResampledImage, objResampledImage);
                    }

                    Bitmap x = new Bitmap(objResampledImage.Bitmap);
                    if (objOutput.Image != null) objOutput.Image.Dispose();
                    objOutput.Image = x;

                    FindEdges(objResampledImage, RESAMPLE);
                }
            }
        }

        private void FindEdges(Mat objDetailRemovedImage, int intDetailRemoveMethod)
        {
            DoCanny(objDetailRemovedImage, m_objPictureBoxes[intDetailRemoveMethod, CANNY]);
            DoSobel(objDetailRemovedImage, m_objPictureBoxes[intDetailRemoveMethod, SOBEL]);
            DoLaplace(objDetailRemovedImage, m_objPictureBoxes[intDetailRemoveMethod, LAPLACE]);
        }

        private void DoCanny(Mat objSourceImage, PictureBox objOutput)
        {
            using (Mat objCannyImage = new Mat())
            {
                double cannyThreshold = 180.0;
                double cannyThresholdLinking = 120.0;
                CvInvoke.Canny(objSourceImage, objCannyImage, cannyThreshold, cannyThresholdLinking);

                if (objOutput.Image != null) objOutput.Image.Dispose();
                objOutput.Image = objCannyImage.Bitmap;
            }
        }

        //Here, src and dst are your image input and output. The argument ddepth allows you to select the depth (type) of the generated output (e.g., CV_32F). As a good example of how to use ddepth, if src is an 8-bit image, then the dst should have a depth of at least CV_16S to avoid overflow. xorder and yorder are the orders of the derivative. Typically, you’ll use 0, 1, or at most 2; a 0 value indicates no derivative in that direction.11 The ksize parameter should be odd and is the width (and the height) of the filter to be used. Currently, aperture sizes up to 31 are supported.12 The scale factor and delta are applied to the derivative before storing in dst. 
        private void DoSobel(Mat objSourceImage, PictureBox objOutput)
        {
            using (Mat objSobelEdgeImage = new Mat())
            {
                int intSobelAperture = (int)numSobelAperture.Value;

                //TODO: x, y > 0 ignores horizontal/vertical lines, but setting both to 0 throws exception. Why?
                //TODO: why would I use different x, y here? If I know/expect something about the image?
                //NOTE: looks like Scharr only works with x,y == 0,1 or 1,0

                CvInvoke.Sobel(objSourceImage, objSobelEdgeImage, DepthType.Cv16S, 1, 0, intSobelAperture);

                if (objOutput.Image != null) objOutput.Image.Dispose();
                objOutput.Image = objSobelEdgeImage.Bitmap;
            }
        }

        private void DoLaplace(Mat objSourceImage, PictureBox objOutput)
        {
            using (Mat objLaplaceEdgeImage = new Mat())
            {
                CvInvoke.Laplacian(objSourceImage, objLaplaceEdgeImage, DepthType.Cv16S);

                if (objOutput.Image != null) objOutput.Image.Dispose();
                objOutput.Image = objLaplaceEdgeImage.Bitmap;
            }
        }


        private void numReptitions_ValueChanged(object sender, EventArgs e)
        {
            m_intPyrRepetitions = (int)numRepetitions.Value;
            UpdateImagesWrapper();
        }

        private void numAperture_ValueChanged(object sender, EventArgs e)
        {
            m_intBlurAperture = (int)numAperture.Value;
            
            if (m_intBlurAperture > 0 && m_intBlurAperture % 2 == 0)
            {
                m_intBlurAperture += 1;
            }

            UpdateImagesWrapper();
        }

        private void objBlurCannyDisplay_Click(object sender, EventArgs e)
        {
            //DetailView objDetail = new DetailView(m_objProcessedImages[BLUR, CANNY]);
            DetailView objDetail = new DetailView(objBlurCannyDisplay.Image);
            objDetail.Show();
        }

        private void objBlurSobelDisplay_Click(object sender, EventArgs e)
        {
            //DetailView objDetail = new DetailView(m_objProcessedImages[BLUR, SOBEL]);
            DetailView objDetail = new DetailView(objBlurSobelDisplay.Image);
            objDetail.Show();
        }

        private void objBlurLaplaceDisplay_Click(object sender, EventArgs e)
        {
            //DetailView objDetail = new DetailView(m_objProcessedImages[BLUR, LAPLACE]);
            DetailView objDetail = new DetailView(objBlurLaplaceDisplay.Image);
            objDetail.Show();
        }

        private void objPyrCannyDisplay_Click(object sender, EventArgs e)
        {
            //DetailView objDetail = new DetailView(m_objProcessedImages[RESAMPLE, CANNY]);
            DetailView objDetail = new DetailView(objPyrCannyDisplay.Image);
            objDetail.Show();
        }

        private void objPyrSobelDisplay_Click(object sender, EventArgs e)
        {
            //DetailView objDetail = new DetailView(m_objProcessedImages[RESAMPLE, SOBEL]);
            DetailView objDetail = new DetailView(objPyrSobelDisplay.Image);
            objDetail.Show();
        }

        private void objPyrLaplaceDisplay_Click(object sender, EventArgs e)
        {
            //DetailView objDetail = new DetailView(m_objProcessedImages[RESAMPLE, LAPLACE]);
            DetailView objDetail = new DetailView(objPyrLaplaceDisplay.Image);
            objDetail.Show();
        }


        private void btnShowHough_Click(object sender, EventArgs e)
        {
            HoughView objLines = new HoughView(objBlurCannyDisplay.Image);
            objLines.Show();
        }
    }
}
