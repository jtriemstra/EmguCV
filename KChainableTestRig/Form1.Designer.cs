namespace KChainableTestRig
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
            this.objFinalDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.objFinalDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // objFinalDisplay
            // 
            this.objFinalDisplay.Location = new System.Drawing.Point(34, 25);
            this.objFinalDisplay.Name = "objFinalDisplay";
            this.objFinalDisplay.Size = new System.Drawing.Size(791, 577);
            this.objFinalDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objFinalDisplay.TabIndex = 0;
            this.objFinalDisplay.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 642);
            this.Controls.Add(this.objFinalDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objFinalDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox objFinalDisplay;
    }
}

