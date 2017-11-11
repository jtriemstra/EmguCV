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

namespace GRemoveNoiseAndDetectLines
{
    public partial class HoughView : Form
    {
        private Image m_objEdgeImage;

        public HoughView(Image objEdgeImage)
        {
            InitializeComponent();

            m_objEdgeImage = objEdgeImage;    
        }

        private void HoughView_Load(object sender, EventArgs e)
        {
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(new Bitmap(m_objEdgeImage));
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(img, grayImage, ColorConversion.Bgr2Gray);

            try
            {
                LineSegment2D[] lines = CvInvoke.HoughLinesP(
                   grayImage,
                   1, //Distance resolution in pixel-related units
                   Math.PI / 45.0, //Angle resolution measured in radians.
                   20, //threshold
                   30, //min Line width
                   10); //gap between lines

                List<RotatedRect> boxList = new List<RotatedRect>(); //a box is a rotated rectangle

                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {
                    CvInvoke.FindContours(grayImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                    int count = contours.Size;
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        using (VectorOfPoint approxContour = new VectorOfPoint())
                        {
                            CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                            if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                            {
                                if (approxContour.Size == 4) //The contour has 4 vertices.
                                {
                                    #region determine if all the angles in the contour are within [80, 100] degree
                                    bool isRectangle = true;
                                    Point[] pts = approxContour.ToArray();
                                    LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                                    /*for (int j = 0; j < edges.Length; j++)
                                    {
                                        double angle = Math.Abs(
                                           edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                        if (angle < 80 || angle > 100)
                                        {
                                            isRectangle = false;
                                            break;
                                        }
                                    }*/
                                    #endregion

                                    if (isRectangle) boxList.Add(CvInvoke.MinAreaRect(approxContour));
                                }
                            }
                        }
                    }
                }

                Image<Bgr, Byte> triangleRectangleImage = img.CopyBlank();
                foreach (RotatedRect box in boxList)
                    triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
                //objHoughDisplay.Image = triangleRectangleImage.Bitmap;
                ImageViewer.Show(triangleRectangleImage, "Test Window 2");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                int i = 0;
            }
        }
    }
}
