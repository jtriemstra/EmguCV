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

            UpdateImagesLocal();
        }

        private void UpdateImagesLocal()
        {
            using (Mat objBlurredImage = new Mat())
            {
                if (m_intBlurAperture % 2 != 0)
                {
                    CvInvoke.MedianBlur(m_objSourceImage, objBlurredImage, m_intBlurAperture);
                    //TODO: this seems to be a memory leak, but also the only way to keep the bitmap around long enough for the form to display
                    Bitmap x = new Bitmap(objBlurredImage.Bitmap);
                    if (objBlurDisplay.Image != null) objBlurDisplay.Image.Dispose();
                    objBlurDisplay.Image = x;
                    
                    using (Mat objCannyImage = new Mat())
                    {
                        double cannyThreshold = 180.0;
                        double cannyThresholdLinking = 120.0;
                        CvInvoke.Canny(objBlurredImage, objCannyImage, cannyThreshold, cannyThresholdLinking);

                        if (objBlurCannyDisplay.Image != null) objBlurCannyDisplay.Image.Dispose();
                        objBlurCannyDisplay.Image = objCannyImage.Bitmap;
                    }

                    using (Mat objSobelEdgeImage = new Mat())
                    {
                        int intSobelAperture = (int)numSobelAperture.Value;
                        CvInvoke.Sobel(objBlurredImage, objSobelEdgeImage, DepthType.Cv16S, 1, 0, intSobelAperture);

                        if (objBlurSobelDisplay.Image != null) objBlurSobelDisplay.Image.Dispose();
                        objBlurSobelDisplay.Image = objSobelEdgeImage.Bitmap;
                    }

                    using (Mat objLaplaceEdgeImage = new Mat())
                    {
                        CvInvoke.Laplacian(objBlurredImage, objLaplaceEdgeImage, DepthType.Cv16S);
                        if (objBlurLaplaceDisplay.Image != null) objBlurLaplaceDisplay.Image.Dispose();
                        objBlurLaplaceDisplay.Image = objLaplaceEdgeImage.Bitmap;
                    }                    
                }
            }
                
            using (Mat objResampledImage = m_objSourceImage.Clone())
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
                    if (objPyrDisplay.Image != null) objPyrDisplay.Image.Dispose();
                    objPyrDisplay.Image = x;

                    using (Mat objCannyImage = new Mat())
                    {
                        double cannyThreshold = 180.0;
                        double cannyThresholdLinking = 120.0;
                        CvInvoke.Canny(objResampledImage, objCannyImage, cannyThreshold, cannyThresholdLinking);

                        if (objPyrCannyDisplay.Image != null) objPyrCannyDisplay.Image.Dispose();
                        objPyrCannyDisplay.Image = objCannyImage.Bitmap;
                    }

                    using (Mat objSobelEdgeImage = new Mat())
                    {
                        int intSobelAperture = (int)numSobelAperture.Value;
                        CvInvoke.Sobel(objResampledImage, objSobelEdgeImage, DepthType.Cv16S, 1, 0, intSobelAperture);

                        if (objPyrSobelDisplay.Image != null) objPyrSobelDisplay.Image.Dispose();
                        objPyrSobelDisplay.Image = objSobelEdgeImage.Bitmap;
                    }

                    using (Mat objLaplaceEdgeImage = new Mat())
                    {
                        CvInvoke.Laplacian(objResampledImage, objLaplaceEdgeImage, DepthType.Cv16S);
                        if (objPyrLaplaceDisplay.Image != null) objPyrLaplaceDisplay.Image.Dispose();
                        objPyrLaplaceDisplay.Image = objLaplaceEdgeImage.Bitmap;
                    }
                }                            
            }
        }

        private void UpdateImages()
        {
            RemoveNoise();

            FindEdges(BLUR);
            FindEdges(RESAMPLE);
        }

        private void RemoveNoise()
        {
            DoBlur();
            DoPyr();
        }

        private void DoBlur()
        {
            //if (m_objProcessedImages[BLUR, NO_EDGE] != null) m_objProcessedImages[BLUR, NO_EDGE].Dispose();
            //Mat oldImage = m_objProcessedImages[BLUR, NO_EDGE];

            if (m_intBlurAperture % 2 != 0)
            {
                Mat objBlurredImage = new Mat();
                m_objProcessedImages[BLUR, NO_EDGE] = objBlurredImage;
                CvInvoke.MedianBlur(m_objSourceImage, objBlurredImage, m_intBlurAperture);                
            }
            else if (m_intBlurAperture == 0)
            {
                m_objProcessedImages[BLUR, NO_EDGE] = m_objSourceImage;
            }

            objBlurDisplay.Image = m_objProcessedImages[BLUR, NO_EDGE].Bitmap;
            //if (oldImage != null) oldImage.Dispose();
        }

        private void DoPyr()
        {
            //if (m_objProcessedImages[RESAMPLE, NO_EDGE] != null) m_objProcessedImages[RESAMPLE, NO_EDGE].Dispose();
            //Mat oldImage = m_objProcessedImages[RESAMPLE, NO_EDGE];

            if (m_intPyrRepetitions < 0) return;
            if (m_intPyrRepetitions == 0)
            {
                m_objProcessedImages[RESAMPLE, NO_EDGE] = m_objSourceImage;
            }
            else
            {
                m_objProcessedImages[RESAMPLE, NO_EDGE] = m_objSourceImage.Clone();
                for (int i = 0; i < m_intPyrRepetitions; i++)
                {
                    CvInvoke.PyrDown(m_objProcessedImages[RESAMPLE, NO_EDGE], m_objProcessedImages[RESAMPLE, NO_EDGE]);
                }
                for (int i = 0; i < m_intPyrRepetitions; i++)
                {
                    CvInvoke.PyrUp(m_objProcessedImages[RESAMPLE, NO_EDGE], m_objProcessedImages[RESAMPLE, NO_EDGE]);
                }
            }
            objPyrDisplay.Image = m_objProcessedImages[RESAMPLE, NO_EDGE].Bitmap;
            //if (oldImage != null) oldImage.Dispose();
        }

        private void FindEdges(int intNoiseRemoveIndex)
        {
            if (m_objProcessedImages[intNoiseRemoveIndex, 0] == null) return;

            DoCanny(intNoiseRemoveIndex);
            DoSobel(intNoiseRemoveIndex);
            DoLaplace(intNoiseRemoveIndex);
        }

        private void DoCanny(int intNoiseRemoveIndex)
        {
            if (m_objProcessedImages[intNoiseRemoveIndex, 0] == null) return;

            Mat objCannyEdgeImage = new Mat();
            double cannyThreshold = 180.0;
            double cannyThresholdLinking = 120.0;
            CvInvoke.Canny(m_objProcessedImages[intNoiseRemoveIndex, 0], objCannyEdgeImage, cannyThreshold, cannyThresholdLinking);

            //m_objProcessedImages[intNoiseRemoveIndex, CANNY] = objCannyEdgeImage;
            m_objPictureBoxes[intNoiseRemoveIndex, CANNY].Image = objCannyEdgeImage.Bitmap;
            objCannyEdgeImage.Dispose();

        }

        //Here, src and dst are your image input and output. The argument ddepth allows you to select the depth (type) of the generated output (e.g., CV_32F). As a good example of how to use ddepth, if src is an 8-bit image, then the dst should have a depth of at least CV_16S to avoid overflow. xorder and yorder are the orders of the derivative. Typically, you’ll use 0, 1, or at most 2; a 0 value indicates no derivative in that direction.11 The ksize parameter should be odd and is the width (and the height) of the filter to be used. Currently, aperture sizes up to 31 are supported.12 The scale factor and delta are applied to the derivative before storing in dst. 
        private void DoSobel(int intNoiseRemoveIndex)
        {
            if (m_objProcessedImages[intNoiseRemoveIndex, 0] == null) return;

            int intSobelAperture = (int) numSobelAperture.Value;
            
            Mat objSobelEdgeImage = new Mat();
            //TODO: x, y > 0 ignores horizontal/vertical lines, but setting both to 0 throws exception. Why?
            //TODO: why would I use different x, y here? If I know/expect something about the image?
            //NOTE: looks like Scharr only works with x,y == 0,1 or 1,0

            CvInvoke.Sobel(m_objProcessedImages[intNoiseRemoveIndex, 0], objSobelEdgeImage, DepthType.Cv16S, 1, 0, intSobelAperture);

            //m_objProcessedImages[intNoiseRemoveIndex, SOBEL] = objSobelEdgeImage;
            m_objPictureBoxes[intNoiseRemoveIndex, SOBEL].Image = objSobelEdgeImage.Bitmap;
            objSobelEdgeImage.Dispose();
        }

        private void DoLaplace(int intNoiseRemoveIndex)
        {
            if (m_objProcessedImages[intNoiseRemoveIndex, 0] == null) return;

            Mat objLaplaceEdgeImage = new Mat();
            CvInvoke.Laplacian(m_objProcessedImages[intNoiseRemoveIndex, 0], objLaplaceEdgeImage, DepthType.Cv16S);

            //m_objProcessedImages[intNoiseRemoveIndex, LAPLACE] = objLaplaceEdgeImage;
            m_objPictureBoxes[intNoiseRemoveIndex, LAPLACE].Image = objLaplaceEdgeImage.Bitmap;
            objLaplaceEdgeImage.Dispose();
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
    }
}
