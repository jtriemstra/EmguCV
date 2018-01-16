namespace KChainableTestRig
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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.objDetailDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // objDetailDisplay
            // 
            this.objDetailDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.objDetailDisplay.Location = new System.Drawing.Point(26, 21);
            this.objDetailDisplay.Name = "objDetailDisplay";
            this.objDetailDisplay.Size = new System.Drawing.Size(1554, 759);
            this.objDetailDisplay.TabIndex = 0;
            this.objDetailDisplay.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.objDetailDisplay);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1606, 805);
            this.panel1.TabIndex = 1;
            // 
            // DetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1630, 829);
            this.Controls.Add(this.panel1);
            this.Name = "DetailView";
            this.Text = "DetailView";
            ((System.ComponentModel.ISupportInitialize)(this.objDetailDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox objDetailDisplay;
        private System.Windows.Forms.Panel panel1;
    }
}