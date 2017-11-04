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
            this.SuspendLayout();
            // 
            // numAperture
            // 
            this.numAperture.Location = new System.Drawing.Point(12, 12);
            this.numAperture.Name = "numAperture";
            this.numAperture.Size = new System.Drawing.Size(58, 20);
            this.numAperture.TabIndex = 1;
            // 
            // numRepetitions
            // 
            this.numRepetitions.Location = new System.Drawing.Point(12, 358);
            this.numRepetitions.Name = "numRepetitions";
            this.numRepetitions.Size = new System.Drawing.Size(58, 20);
            this.numRepetitions.TabIndex = 2;
            // 
            // objBlurDisplay
            // 
            this.objBlurDisplay.Location = new System.Drawing.Point(12, 38);
            this.objBlurDisplay.Name = "objBlurDisplay";
            this.objBlurDisplay.Size = new System.Drawing.Size(294, 213);
            this.objBlurDisplay.TabIndex = 3;
            this.objBlurDisplay.TabStop = false;
            this.objBlurDisplay.Click += new System.EventHandler(this.objBlurDisplay_Click);
            // 
            // objPyrDisplay
            // 
            this.objPyrDisplay.Location = new System.Drawing.Point(12, 384);
            this.objPyrDisplay.Name = "objPyrDisplay";
            this.objPyrDisplay.Size = new System.Drawing.Size(294, 213);
            this.objPyrDisplay.TabIndex = 4;
            this.objPyrDisplay.TabStop = false;
            // 
            // objBlurCannyDisplay
            // 
            this.objBlurCannyDisplay.Location = new System.Drawing.Point(335, 38);
            this.objBlurCannyDisplay.Name = "objBlurCannyDisplay";
            this.objBlurCannyDisplay.Size = new System.Drawing.Size(294, 213);
            this.objBlurCannyDisplay.TabIndex = 5;
            this.objBlurCannyDisplay.TabStop = false;
            // 
            // objBlurSobelDisplay
            // 
            this.objBlurSobelDisplay.Location = new System.Drawing.Point(656, 38);
            this.objBlurSobelDisplay.Name = "objBlurSobelDisplay";
            this.objBlurSobelDisplay.Size = new System.Drawing.Size(294, 213);
            this.objBlurSobelDisplay.TabIndex = 6;
            this.objBlurSobelDisplay.TabStop = false;
            // 
            // objBlurLaplaceDisplay
            // 
            this.objBlurLaplaceDisplay.Location = new System.Drawing.Point(980, 38);
            this.objBlurLaplaceDisplay.Name = "objBlurLaplaceDisplay";
            this.objBlurLaplaceDisplay.Size = new System.Drawing.Size(294, 213);
            this.objBlurLaplaceDisplay.TabIndex = 7;
            this.objBlurLaplaceDisplay.TabStop = false;
            // 
            // objPyrLaplaceDisplay
            // 
            this.objPyrLaplaceDisplay.Location = new System.Drawing.Point(980, 384);
            this.objPyrLaplaceDisplay.Name = "objPyrLaplaceDisplay";
            this.objPyrLaplaceDisplay.Size = new System.Drawing.Size(294, 213);
            this.objPyrLaplaceDisplay.TabIndex = 10;
            this.objPyrLaplaceDisplay.TabStop = false;
            // 
            // objPyrSobelDisplay
            // 
            this.objPyrSobelDisplay.Location = new System.Drawing.Point(656, 384);
            this.objPyrSobelDisplay.Name = "objPyrSobelDisplay";
            this.objPyrSobelDisplay.Size = new System.Drawing.Size(294, 213);
            this.objPyrSobelDisplay.TabIndex = 9;
            this.objPyrSobelDisplay.TabStop = false;
            // 
            // objPyrCannyDisplay
            // 
            this.objPyrCannyDisplay.Location = new System.Drawing.Point(335, 384);
            this.objPyrCannyDisplay.Name = "objPyrCannyDisplay";
            this.objPyrCannyDisplay.Size = new System.Drawing.Size(294, 213);
            this.objPyrCannyDisplay.TabIndex = 8;
            this.objPyrCannyDisplay.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 678);
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
    }
}

