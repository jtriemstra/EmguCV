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
using JChainableTransforms;
using ParameterKey = JChainableTransforms.Transform.ParameterKey;
using DoTransform = JChainableTransforms.Transform.DoTransform;

namespace KChainableTestRig
{
    public partial class Form1 : Form
    {
        private const String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20180113_152015034.jpg";

        private Mat objSourceImage = new Mat(m_strSourceImageFileName);

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (String s in Transform.TransformNames)
            {
                objAvailableList.Items.Add(s);
            }
            return;


            Dictionary<ParameterKey, Object> hshParameters = new Dictionary<ParameterKey,object>();
            hshParameters[ParameterKey.BLUR_APERTURE] = 3;
            hshParameters[ParameterKey.SOBEL_APERTURE] = 1;
            hshParameters[ParameterKey.PYR_REPETITIONS] = 1;

            try
            {
                /*
                 * Canny + noise removal. Removing noise is getting rid of some of the edge detail as well
                 * 
                Transform.Do(objSourceImage, hshParameters, Transform.DoCanny, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoPyr, Transform.DoCanny, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoCanny, DisplayNewWindow);

                return; 
                */

                /*
                 * Sobel + noise removal. Pyr makes the edges pop a little more.
                 * 
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoPyr, Transform.DoSobel, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoSobel, DisplayNewWindow);

                return; 
                */

                /*
                 * Not seeing much difference between 1 and -1
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, DisplayNewWindow);
                hshParameters[ParameterKey.SOBEL_APERTURE] = 1;
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, DisplayNewWindow);
                */

                /*
                 * Sobel + canny loses many edges, even the more y-axis oriented ones
                 *
                //hshParameters[ParameterKey.SOBEL_APERTURE] = 1;
                hshParameters[ParameterKey.WINDOW_NAME] = "Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, Transform.DoCanny, DisplayNewWindow);
                hshParameters[ParameterKey.WINDOW_NAME] = "Resample Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoPyr, Transform.DoSobel, Transform.DoCanny, DisplayNewWindow);
                hshParameters[ParameterKey.WINDOW_NAME] = "Blur Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoSobel, Transform.DoCanny, DisplayNewWindow);
                return;
                */

                /*
                 * Sobel+Scharr introduces much noise
                //hshParameters[ParameterKey.SOBEL_APERTURE] = -1;
                hshParameters[ParameterKey.WINDOW_NAME] = "Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, Transform.DoCanny, DisplayNewWindow);
                hshParameters[ParameterKey.WINDOW_NAME] = "Blur Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoSobel, Transform.DoCanny, DisplayNewWindow);
                hshParameters[ParameterKey.WINDOW_NAME] = "Resample Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoPyr, Transform.DoSobel, Transform.DoCanny, DisplayNewWindow);
                */

                /*
                 * Blurring post-Sobel doesn't reduce the noise
                hshParameters[ParameterKey.WINDOW_NAME] = "Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, Transform.DoBlur, Transform.DoCanny, DisplayNewWindow);
                hshParameters[ParameterKey.WINDOW_NAME] = "Blur Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoSobel, Transform.DoBlur, Transform.DoCanny, DisplayNewWindow);
                hshParameters[ParameterKey.WINDOW_NAME] = "Resample Sobel";
                Transform.Do(objSourceImage, hshParameters, Transform.DoPyr, Transform.DoSobel, Transform.DoBlur, Transform.DoCanny, DisplayNewWindow);
                */

                /*
                 * Sobel test results
                 * Sobel yields a grayish result, similar to Laplace (expected since they are both derivative based). Sobel is clearer to the eye. 
                 * It only works in one dimension though. Would be interesting to try doing x and y dimensions separately, and compositing them.
                 * 8-bit transform results in a nearly binary result. Not doing the 8-bit transform with the gray-scaling results in a black image *
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoSobel, Transform.To8Bit, DisplayNewWindow);
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoSobel, Transform.To8Bit, DisplayNewWindow);
                
                return;
                */

                //grayscale first hurts Canny
                Transform.Do(objSourceImage, hshParameters, Transform.DoCanny, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoCanny, Transform.DoHough, DisplayNewWindow);
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoCanny, DisplayNewWindow);
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoCanny, Transform.DoHough, DisplayNewWindow);
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoCanny, Transform.DoContours, DisplayNewWindow);

                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, DisplayNewWindow);


                //Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, Transform.To8Bit, DisplayNewWindow);
                //grayscale first doesn't make a huge difference on Laplace
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoLaplace, Transform.To8Bit, DisplayNewWindow);
                //this threshold value is tricky
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoLaplace, Transform.To8Bit, Transform.DoStaticThreshold, DisplayNewWindow);
                //seems like the ordering of the grayscale call doesn't matter much, if at all in this case
                //Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, Transform.To8Bit, Transform.DoGrayscale, Transform.DoStaticThreshold, DisplayNewWindow);

                //pretty good noise removal and edges stay
                //Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, Transform.DoHough, DisplayNewWindow);

                //Pyr + Laplace is extremely faint - might be able to use threshold but ?
                //Transform.Do(objSourceImage, hshParameters, Transform.DoPyr, Transform.DoLaplace, Transform.To8Bit, DisplayNewWindow);

                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, Transform.DoStaticThreshold, DisplayNewWindow);
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, Transform.DoStaticThreshold, Transform.DoHough, DisplayNewWindow);
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, Transform.DoStaticThreshold, Transform.Dilate, DisplayNewWindow);
                //Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, Transform.DoStaticThreshold, Transform.Dilate, Transform.Erode, DisplayNewWindow);

                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.DoBlur, Transform.DoLaplace, Transform.To8Bit, Transform.DoStaticThreshold, Transform.Dilate, Transform.DoHough, DisplayNewWindow);


                Transform.Do(objSourceImage, hshParameters, Transform.DoCanny, Transform.Dilate, Transform.Erode, Transform.DoHough, DisplayNewWindow);
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }

        private void DisplayNewWindow(Mat objSourceImage, Dictionary<ParameterKey, Object> hshParameters, params DoTransform[] chainedCallbacks)
        {
            /*if (objSourceImage.Depth != DepthType.Cv8U)
            {
                throw new Exception("This should probably be converted to an 8bit depth before displaying");
            }*/

            DetailView objDetail = new DetailView(objSourceImage);
            if (hshParameters.ContainsKey(ParameterKey.WINDOW_NAME)) objDetail.Text = (String) hshParameters[ParameterKey.WINDOW_NAME];
            objDetail.Show();

            Transform.DoCallbacks(objSourceImage, hshParameters, chainedCallbacks);
        }

        private void DisplayThisWindow(Mat objSourceImage)
        {
            objFinalDisplay.Image = objSourceImage.Bitmap;

        }

        private void ConversionTesting()
        {
            /*
             * All conversions to greater depth result in black images. 8U -> 8S results in anything over 127 being truncated to that. 8U -> 16U results in 
             * 
             * hshParameters[ParameterKey.CONVERT_DEST_DEPTH] = DepthType.Cv8U;
                hshParameters[ParameterKey.WINDOW_NAME] = "8U";
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.ChangeDepth, DisplayNewWindow);

                hshParameters[ParameterKey.CONVERT_DEST_DEPTH] = DepthType.Cv8S;
                hshParameters[ParameterKey.WINDOW_NAME] = "8S";
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.ChangeDepth, DisplayNewWindow);

                hshParameters[ParameterKey.CONVERT_DEST_DEPTH] = DepthType.Cv16U;
                hshParameters[ParameterKey.WINDOW_NAME] = "16U";
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.ChangeDepth, DisplayNewWindow);

                hshParameters[ParameterKey.CONVERT_DEST_DEPTH] = DepthType.Cv16S;
                hshParameters[ParameterKey.WINDOW_NAME] = "16S";
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.ChangeDepth, DisplayNewWindow);

                hshParameters[ParameterKey.CONVERT_DEST_DEPTH] = DepthType.Cv32F;
                hshParameters[ParameterKey.WINDOW_NAME] = "32F";
                Transform.Do(objSourceImage, hshParameters, Transform.DoGrayscale, Transform.ChangeDepth, DisplayNewWindow);
             */
        }

        private void LaplaceOverflowTesting()
        {
            /*
             * The first two overflow, resulting in sort of a binary image? The majority is black, rather than the majority being gray. The commented out one fails - unsigned can't convert to signed.
             * 
            hshParameters[ParameterKey.LAPLACE_DEST_DEPTH] = DepthType.Cv8U;
            hshParameters[ParameterKey.WINDOW_NAME] = "8U";
            Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, DisplayNewWindow);

            //hshParameters[ParameterKey.LAPLACE_DEST_DEPTH] = DepthType.Cv8S;
            //Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, DisplayNewWindow);

            hshParameters[ParameterKey.LAPLACE_DEST_DEPTH] = DepthType.Cv16U;
            hshParameters[ParameterKey.WINDOW_NAME] = "16U";
            Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, DisplayNewWindow);

            hshParameters[ParameterKey.LAPLACE_DEST_DEPTH] = DepthType.Cv16S;
            hshParameters[ParameterKey.WINDOW_NAME] = "16S";
            Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, DisplayNewWindow);

            hshParameters[ParameterKey.LAPLACE_DEST_DEPTH] = DepthType.Cv32F;
            hshParameters[ParameterKey.WINDOW_NAME] = "32F";
            Transform.Do(objSourceImage, hshParameters, Transform.DoLaplace, DisplayNewWindow);
             * */
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String strName = (String)objAvailableList.SelectedItem;
            CommandObjects.Transform objCommand = CommandObjects.GetObject(strName);
            objUsedList.Items.Add(objCommand);          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (objUsedList.SelectedIndex > 0)
            {
                Object objSelectedReference = objUsedList.SelectedItem;
                objUsedList.Items.Insert(objUsedList.SelectedIndex - 1, objSelectedReference);
                objUsedList.Items.RemoveAt(objUsedList.SelectedIndex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (objUsedList.SelectedIndex < objUsedList.Items.Count - 1)
            {
                Object objSelectedReference = objUsedList.SelectedItem;
                objUsedList.Items.Insert(objUsedList.SelectedIndex + 2, objSelectedReference);
                objUsedList.Items.RemoveAt(objUsedList.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (objUsedList.SelectedIndex >= 0)
            {
                objUsedList.Items.RemoveAt(objUsedList.SelectedIndex);
            }
        }

        private void objUsedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommandObjects.Transform objCurrentTransform = (CommandObjects.Transform)objUsedList.SelectedItem;
            objParameterPanel.Controls.Clear();

            if (objCurrentTransform != null)
            {
                Transform.TransformParameter[] objCurrentParameters = Transform.GetParameters(objUsedList.SelectedItem.ToString());
                int intCurrentLeft = 0;
                foreach (Transform.TransformParameter p in objCurrentParameters)
                {
                    Control objNewParameterField;
                    
                    switch (p.Type)
                    {
                        case Transform.ParameterType.FLOAT:
                        case Transform.ParameterType.INT:
                            objNewParameterField = new NumericUpDown();
                            ((NumericUpDown)objNewParameterField).Minimum = p.MinValue;
                            ((NumericUpDown)objNewParameterField).Maximum = p.MaxValue;
                            ((NumericUpDown)objNewParameterField).Value = Convert.ToDecimal(((CommandObjects.Transform)objUsedList.SelectedItem).Parameters[p.Key]);
                            break;
                        default:
                            objNewParameterField = new TextBox();
                            break;
                    }
                    objNewParameterField.LostFocus += objNewParameterField_LostFocus;
                    objNewParameterField.Left = intCurrentLeft;

                    objParameterPanel.Controls.Add(objNewParameterField);
                    intCurrentLeft += objNewParameterField.Width;
                }
            }
        }

        void objNewParameterField_LostFocus(object sender, EventArgs e)
        {
            SaveParameters();
        }

        private void SaveParameters()
        {
            if (objUsedList.SelectedItem == null) return;

            Transform.TransformParameter[] objCurrentParameters = Transform.GetParameters(objUsedList.SelectedItem.ToString());
            int intCurrentIndex = 0;
            foreach (Transform.TransformParameter p in objCurrentParameters)
            {
                Control objThisParameterField;
                objThisParameterField = objParameterPanel.Controls[intCurrentIndex];
                switch (p.Type)
                {
                    case Transform.ParameterType.FLOAT:
                    case Transform.ParameterType.INT:
                        ((CommandObjects.Transform)objUsedList.SelectedItem).Parameters[p.Key] = (double) ((NumericUpDown)objThisParameterField).Value;
                        break;
                    default:
                        break;
                }
                intCurrentIndex++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SaveParameters();

            CommandObjects.Transform objPreviousTransform = null;
            foreach (CommandObjects.Transform objCurrentTransform in objUsedList.Items)
            {
                if (objPreviousTransform != null)
                {
                    objPreviousTransform.Next = objCurrentTransform;
                }

                objPreviousTransform = objCurrentTransform;
            }

            objPreviousTransform.Next = new CommandObjects.Display(DisplayThisWindow);

            CommandObjects.Transform objFirstTransform = (CommandObjects.Transform) objUsedList.Items[0];
            objFirstTransform.Execute(objSourceImage);
        }

        private void objFinalDisplay_DoubleClick(object sender, EventArgs e)
        {
            DetailView objDetail = new DetailView(objFinalDisplay.Image);
            
            objDetail.Show();
        }
    }
}
