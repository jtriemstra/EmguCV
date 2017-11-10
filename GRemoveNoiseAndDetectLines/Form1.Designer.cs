namespace GRemoveNoiseAndDetectLines
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numAperture = new System.Windows.Forms.NumericUpDown();
            this.numRepetitions = new System.Windows.Forms.NumericUpDown();
            this.objBlurDisplay = new System.Windows.Forms.PictureBox();
            this.objPyrDisplay = new System.Windows.Forms.PictureBox();
            this.objBlurCannyDisplay = new System.Windows.Forms.PictureBox();
            this.objBlurSobelDisplay = new System.Windows.Forms.PictureBox();
            this.objBlurLaplaceDisplay = new System.Windows.Forms.PictureBox();
            this.objPyrLaplaceDisplay = new System.Windows.Forms.PictureBox();
            this.objPyrSobelDisplay = new System.Windows.Forms.PictureBox();
            this.objPyrCannyDisplay = new System.Windows.Forms.PictureBox();
            this.numSobelAperture = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAperture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepetitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurCannyDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurSobelDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurLaplaceDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrLaplaceDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrSobelDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrCannyDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSobelAperture)).BeginInit();
            this.SuspendLayout();
            // 
            // numAperture
            // 
            this.numAperture.Location = new System.Drawing.Point(12, 181);
            this.numAperture.Name = "numAperture";
            this.numAperture.Size = new System.Drawing.Size(40, 20);
            this.numAperture.TabIndex = 1;
            this.numAperture.ValueChanged += new System.EventHandler(this.numAperture_ValueChanged);
            // 
            // numRepetitions
            // 
            this.numRepetitions.Location = new System.Drawing.Point(12, 527);
            this.numRepetitions.Name = "numRepetitions";
            this.numRepetitions.Size = new System.Drawing.Size(40, 20);
            this.numRepetitions.TabIndex = 2;
            this.numRepetitions.ValueChanged += new System.EventHandler(this.numReptitions_ValueChanged);
            // 
            // objBlurDisplay
            // 
            this.objBlurDisplay.Location = new System.Drawing.Point(72, 87);
            this.objBlurDisplay.Name = "objBlurDisplay";
            this.objBlurDisplay.Size = new System.Drawing.Size(294, 213);
            this.objBlurDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objBlurDisplay.TabIndex = 3;
            this.objBlurDisplay.TabStop = false;
            // 
            // objPyrDisplay
            // 
            this.objPyrDisplay.Location = new System.Drawing.Point(72, 433);
            this.objPyrDisplay.Name = "objPyrDisplay";
            this.objPyrDisplay.Size = new System.Drawing.Size(294, 213);
            this.objPyrDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objPyrDisplay.TabIndex = 4;
            this.objPyrDisplay.TabStop = false;
            // 
            // objBlurCannyDisplay
            // 
            this.objBlurCannyDisplay.Location = new System.Drawing.Point(395, 87);
            this.objBlurCannyDisplay.Name = "objBlurCannyDisplay";
            this.objBlurCannyDisplay.Size = new System.Drawing.Size(473, 299);
            this.objBlurCannyDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objBlurCannyDisplay.TabIndex = 5;
            this.objBlurCannyDisplay.TabStop = false;
            this.objBlurCannyDisplay.Click += new System.EventHandler(this.objBlurCannyDisplay_Click);
            // 
            // objBlurSobelDisplay
            // 
            this.objBlurSobelDisplay.Location = new System.Drawing.Point(868, 87);
            this.objBlurSobelDisplay.Name = "objBlurSobelDisplay";
            this.objBlurSobelDisplay.Size = new System.Drawing.Size(473, 299);
            this.objBlurSobelDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objBlurSobelDisplay.TabIndex = 6;
            this.objBlurSobelDisplay.TabStop = false;
            this.objBlurSobelDisplay.Click += new System.EventHandler(this.objBlurSobelDisplay_Click);
            // 
            // objBlurLaplaceDisplay
            // 
            this.objBlurLaplaceDisplay.Location = new System.Drawing.Point(1347, 87);
            this.objBlurLaplaceDisplay.Name = "objBlurLaplaceDisplay";
            this.objBlurLaplaceDisplay.Size = new System.Drawing.Size(473, 299);
            this.objBlurLaplaceDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objBlurLaplaceDisplay.TabIndex = 7;
            this.objBlurLaplaceDisplay.TabStop = false;
            this.objBlurLaplaceDisplay.Click += new System.EventHandler(this.objBlurLaplaceDisplay_Click);
            // 
            // objPyrLaplaceDisplay
            // 
            this.objPyrLaplaceDisplay.Location = new System.Drawing.Point(1347, 433);
            this.objPyrLaplaceDisplay.Name = "objPyrLaplaceDisplay";
            this.objPyrLaplaceDisplay.Size = new System.Drawing.Size(473, 299);
            this.objPyrLaplaceDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objPyrLaplaceDisplay.TabIndex = 10;
            this.objPyrLaplaceDisplay.TabStop = false;
            this.objPyrLaplaceDisplay.Click += new System.EventHandler(this.objPyrLaplaceDisplay_Click);
            // 
            // objPyrSobelDisplay
            // 
            this.objPyrSobelDisplay.Location = new System.Drawing.Point(868, 433);
            this.objPyrSobelDisplay.Name = "objPyrSobelDisplay";
            this.objPyrSobelDisplay.Size = new System.Drawing.Size(473, 299);
            this.objPyrSobelDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objPyrSobelDisplay.TabIndex = 9;
            this.objPyrSobelDisplay.TabStop = false;
            this.objPyrSobelDisplay.Click += new System.EventHandler(this.objPyrSobelDisplay_Click);
            // 
            // objPyrCannyDisplay
            // 
            this.objPyrCannyDisplay.Location = new System.Drawing.Point(395, 433);
            this.objPyrCannyDisplay.Name = "objPyrCannyDisplay";
            this.objPyrCannyDisplay.Size = new System.Drawing.Size(473, 299);
            this.objPyrCannyDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objPyrCannyDisplay.TabIndex = 8;
            this.objPyrCannyDisplay.TabStop = false;
            this.objPyrCannyDisplay.Click += new System.EventHandler(this.objPyrCannyDisplay_Click);
            // 
            // numSobelAperture
            // 
            this.numSobelAperture.Location = new System.Drawing.Point(819, 47);
            this.numSobelAperture.Name = "numSobelAperture";
            this.numSobelAperture.Size = new System.Drawing.Size(120, 20);
            this.numSobelAperture.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1822, 813);
            this.Controls.Add(this.numSobelAperture);
            this.Controls.Add(this.objPyrLaplaceDisplay);
            this.Controls.Add(this.objPyrSobelDisplay);
            this.Controls.Add(this.objPyrCannyDisplay);
            this.Controls.Add(this.objBlurLaplaceDisplay);
            this.Controls.Add(this.objBlurSobelDisplay);
            this.Controls.Add(this.objBlurCannyDisplay);
            this.Controls.Add(this.objPyrDisplay);
            this.Controls.Add(this.objBlurDisplay);
            this.Controls.Add(this.numRepetitions);
            this.Controls.Add(this.numAperture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAperture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRepetitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurCannyDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurSobelDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objBlurLaplaceDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrLaplaceDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrSobelDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objPyrCannyDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSobelAperture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numAperture;
        private System.Windows.Forms.NumericUpDown numRepetitions;
        private System.Windows.Forms.PictureBox objBlurDisplay;
        private System.Windows.Forms.PictureBox objPyrDisplay;
        private System.Windows.Forms.PictureBox objBlurCannyDisplay;
        private System.Windows.Forms.PictureBox objBlurSobelDisplay;
        private System.Windows.Forms.PictureBox objBlurLaplaceDisplay;
        private System.Windows.Forms.PictureBox objPyrLaplaceDisplay;
        private System.Windows.Forms.PictureBox objPyrSobelDisplay;
        private System.Windows.Forms.PictureBox objPyrCannyDisplay;
        private System.Windows.Forms.NumericUpDown numSobelAperture;
    }
}

