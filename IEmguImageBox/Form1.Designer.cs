namespace IEmguImageBox
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
            this.components = new System.ComponentModel.Container();
            this.objImageDisplay = new Emgu.CV.UI.ImageBox();
            this.objMemoryLeakDisplay = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objMemoryLeakDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // objImageDisplay
            // 
            this.objImageDisplay.Location = new System.Drawing.Point(29, 33);
            this.objImageDisplay.Name = "objImageDisplay";
            this.objImageDisplay.Size = new System.Drawing.Size(213, 194);
            this.objImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objImageDisplay.TabIndex = 2;
            this.objImageDisplay.TabStop = false;
            // 
            // objMemoryLeakDisplay
            // 
            this.objMemoryLeakDisplay.Location = new System.Drawing.Point(29, 245);
            this.objMemoryLeakDisplay.Name = "objMemoryLeakDisplay";
            this.objMemoryLeakDisplay.Size = new System.Drawing.Size(213, 203);
            this.objMemoryLeakDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objMemoryLeakDisplay.TabIndex = 2;
            this.objMemoryLeakDisplay.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 480);
            this.Controls.Add(this.objMemoryLeakDisplay);
            this.Controls.Add(this.objImageDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objMemoryLeakDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox objImageDisplay;
        private Emgu.CV.UI.ImageBox objMemoryLeakDisplay;
    }
}

