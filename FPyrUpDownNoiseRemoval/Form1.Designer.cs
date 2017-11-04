namespace FPyrUpDownNoiseRemoval
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
            this.numRepetitions = new System.Windows.Forms.NumericUpDown();
            this.objImageDisplay = new System.Windows.Forms.PictureBox();
            this.objImageDisplay2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRepetitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay2)).BeginInit();
            this.SuspendLayout();
            // 
            // numRepetitions
            // 
            this.numRepetitions.Location = new System.Drawing.Point(12, 12);
            this.numRepetitions.Name = "numRepetitions";
            this.numRepetitions.Size = new System.Drawing.Size(58, 20);
            this.numRepetitions.TabIndex = 0;
            this.numRepetitions.ValueChanged += new System.EventHandler(this.numReptitions_ValueChanged);
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
            // objImageDisplay2
            // 
            this.objImageDisplay2.Location = new System.Drawing.Point(12, 319);
            this.objImageDisplay2.Name = "objImageDisplay2";
            this.objImageDisplay2.Size = new System.Drawing.Size(421, 262);
            this.objImageDisplay2.TabIndex = 2;
            this.objImageDisplay2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 663);
            this.Controls.Add(this.objImageDisplay2);
            this.Controls.Add(this.objImageDisplay);
            this.Controls.Add(this.numRepetitions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRepetitions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objImageDisplay2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRepetitions;
        private System.Windows.Forms.PictureBox objImageDisplay;
        private System.Windows.Forms.PictureBox objImageDisplay2;
    }
}

