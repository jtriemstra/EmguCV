namespace GRemoveNoiseAndDetectLines
{
    partial class HoughView
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
            this.objHoughDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.objHoughDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // objHoughDisplay
            // 
            this.objHoughDisplay.Location = new System.Drawing.Point(12, 12);
            this.objHoughDisplay.Name = "objHoughDisplay";
            this.objHoughDisplay.Size = new System.Drawing.Size(1300, 770);
            this.objHoughDisplay.TabIndex = 0;
            this.objHoughDisplay.TabStop = false;
            // 
            // HoughView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 794);
            this.Controls.Add(this.objHoughDisplay);
            this.Name = "HoughView";
            this.Text = "HoughView";
            this.Load += new System.EventHandler(this.HoughView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objHoughDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox objHoughDisplay;
    }
}