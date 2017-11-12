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

namespace KChainableTestRig
{
    public partial class Form1 : Form
    {
        private String m_strSourceImageFileName = @"C:\TestProjects\EmguCV\IMG_20171104_140009649.jpg";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mat objSourceImage = new Mat(m_strSourceImageFileName);

            Dictionary<ParameterKey, Object> hshParameters = new Dictionary<ParameterKey,object>();
            hshParameters[ParameterKey.BLUR_APERTURE] = 1;
            hshParameters[ParameterKey.OUTPUT_PICTUREBOX] = objFinalDisplay;

            Transform.Do(objSourceImage, hshParameters, Transform.DoBlur, Transform.DoCanny, Transform.Display2);
            

        }
    }
}
