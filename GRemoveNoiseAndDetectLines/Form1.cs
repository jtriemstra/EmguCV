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
        private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\ShapeTest.jpg";
        private const String WINDOW_NAME = "Test Window";
        private Mat m_objSourceImage;
        private int m_intPyrRepetitions;
        private int m_intBlurAperture;
        private Mat m_objBlurredImage;
        private Mat m_objResampledImage;

        public Form1()
        {
            InitializeComponent();

            m_objSourceImage = new Mat(m_strSourceImageFileName);
        }

        private void UpdateImages()
        {
            RemoveNoise();

            FindEdges(m_objBlurredImage);
            FindEdges(m_objResampledImage);
        }

        private void RemoveNoise()
        {
            m_objBlurredImage = new Mat();
            CvInvoke.MedianBlur(m_objSourceImage, m_objBlurredImage, m_intBlurAperture);

            m_objResampledImage = m_objSourceImage.Clone();
            for (int i = 0; i < m_intPyrRepetitions; i++)
            {
                CvInvoke.PyrDown(m_objResampledImage, m_objResampledImage);
            }
            for (int i = 0; i < m_intPyrRepetitions; i++)
            {
                CvInvoke.PyrUp(m_objResampledImage, m_objResampledImage);
            }

            objBlurDisplay.Image = m_objBlurredImage.Bitmap;
            objPyrDisplay.Image = m_objResampledImage.Bitmap;
        }

        private void FindEdges(Mat objImageWithNoiseRemoved)
        {
            UMat objCannyEdgeImage = new UMat();
            //CvInvoke.Canny(objImageWithNoiseRemoved, objCannyEdgeImage, cannyThreshold, cannyThresholdLinking);
        }


        private void numReptitions_ValueChanged(object sender, EventArgs e)
        {
            m_intPyrRepetitions = (int)numRepetitions.Value;
            UpdateImages();
        }

        private void numAperture_ValueChanged(object sender, EventArgs e)
        {
            m_intBlurAperture = (int)numAperture.Value;
            
            if (m_intBlurAperture > 0 && m_intBlurAperture % 2 == 0)
            {
                m_intBlurAperture += 1;
            }

            UpdateImages();
        }
    }
}
