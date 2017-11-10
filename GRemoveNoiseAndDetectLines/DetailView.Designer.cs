namespace GRemoveNoiseAndDetectLines
{
    partial class DetailView
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
            this.objDetailDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.objDetailDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // objDetailDisplay
            // 
            this.objDetailDisplay.Location = new System.Drawing.Point(36, 25);
            this.objDetailDisplay.Name = "objDetailDisplay";
            this.objDetailDisplay.Size = new System.Drawing.Size(1682, 707);
            this.objDetailDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objDetailDisplay.TabIndex = 0;
            this.objDetailDisplay.TabStop = false;
            // 
            // DetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 764);
            this.Controls.Add(this.objDetailDisplay);
            this.Name = "DetailView";
            this.Text = "DetailView";
            ((System.ComponentModel.ISupportInitialize)(this.objDetailDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox objDetailDisplay;
    }
}