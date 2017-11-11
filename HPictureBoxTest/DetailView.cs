using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPictureBoxTest
{
    public partial class DetailView : Form
    {
        public DetailView(Image objDetailImage)
        {
            InitializeComponent();
            objDetailDisplay.Image = objDetailImage;
        }

    }
}
