namespace EMedianBlurNoiseRemoval
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
            this.objImageDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAperture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // numAperture
            // 
            this.numAperture.Location = new System.Drawing.Point(12, 12);
            this.numAperture.Name = "numAperture";
            this.numAperture.Size = new System.Drawing.Size(58, 20);
            this.numAperture.TabIndex = 0;
            this.numAperture.ValueChanged += new System.EventHandler(this.numAperture_ValueChanged);
            // 
            // objImageDisplay
            // 
            this.objImageDisplay.Location = new System.Drawing.Point(12, 47);
            this.objImageDisplay.Name = "objImageDisplay";
            this.objImageDisplay.Size = new System.Drawing.Size(421, 266);
            this.objImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.objImageDisplay.TabIndex = 1;
            this.objImageDisplay.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 390);
            this.Controls.Add(this.objImageDisplay);
            this.Controls.Add(this.numAperture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAperture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numAperture;
        private System.Windows.Forms.PictureBox objImageDisplay;
    }
}

