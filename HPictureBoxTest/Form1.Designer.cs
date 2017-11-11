namespace HPictureBoxTest
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
            this.objRawDisplay = new System.Windows.Forms.PictureBox();
            this.objEmguDisplay = new System.Windows.Forms.PictureBox();
            this.objButtonEmguDisplay = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.objButtonBlurDisplay = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.objNumBlurDisplay = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.objLargeEmguDisplay = new System.Windows.Forms.PictureBox();
            this.objMemoryLeakDisplay = new System.Windows.Forms.PictureBox();
            this.objLargeRawDisplay = new System.Windows.Forms.PictureBox();
            this.objTinyDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.objRawDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objEmguDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objButtonEmguDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objButtonBlurDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objNumBlurDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objLargeEmguDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objMemoryLeakDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objLargeRawDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objTinyDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // objRawDisplay
            // 
            this.objRawDisplay.Location = new System.Drawing.Point(24, 32);
            this.objRawDisplay.Name = "objRawDisplay";
            this.objRawDisplay.Size = new System.Drawing.Size(243, 210);
            this.objRawDisplay.TabIndex = 0;
            this.objRawDisplay.TabStop = false;
            // 
            // objEmguDisplay
            // 
            this.objEmguDisplay.Location = new System.Drawing.Point(294, 32);
            this.objEmguDisplay.Name = "objEmguDisplay";
            this.objEmguDisplay.Size = new System.Drawing.Size(243, 210);
            this.objEmguDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objEmguDisplay.TabIndex = 1;
            this.objEmguDisplay.TabStop = false;
            // 
            // objButtonEmguDisplay
            // 
            this.objButtonEmguDisplay.Location = new System.Drawing.Point(294, 272);
            this.objButtonEmguDisplay.Name = "objButtonEmguDisplay";
            this.objButtonEmguDisplay.Size = new System.Drawing.Size(243, 210);
            this.objButtonEmguDisplay.TabIndex = 2;
            this.objButtonEmguDisplay.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // objButtonBlurDisplay
            // 
            this.objButtonBlurDisplay.Location = new System.Drawing.Point(294, 531);
            this.objButtonBlurDisplay.Name = "objButtonBlurDisplay";
            this.objButtonBlurDisplay.Size = new System.Drawing.Size(243, 210);
            this.objButtonBlurDisplay.TabIndex = 4;
            this.objButtonBlurDisplay.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(383, 756);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // objNumBlurDisplay
            // 
            this.objNumBlurDisplay.Location = new System.Drawing.Point(581, 531);
            this.objNumBlurDisplay.Name = "objNumBlurDisplay";
            this.objNumBlurDisplay.Size = new System.Drawing.Size(243, 210);
            this.objNumBlurDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objNumBlurDisplay.TabIndex = 6;
            this.objNumBlurDisplay.TabStop = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(642, 756);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // objLargeEmguDisplay
            // 
            this.objLargeEmguDisplay.Location = new System.Drawing.Point(859, 32);
            this.objLargeEmguDisplay.Name = "objLargeEmguDisplay";
            this.objLargeEmguDisplay.Size = new System.Drawing.Size(243, 210);
            this.objLargeEmguDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objLargeEmguDisplay.TabIndex = 8;
            this.objLargeEmguDisplay.TabStop = false;
            // 
            // objMemoryLeakDisplay
            // 
            this.objMemoryLeakDisplay.Location = new System.Drawing.Point(1131, 32);
            this.objMemoryLeakDisplay.Name = "objMemoryLeakDisplay";
            this.objMemoryLeakDisplay.Size = new System.Drawing.Size(243, 210);
            this.objMemoryLeakDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objMemoryLeakDisplay.TabIndex = 9;
            this.objMemoryLeakDisplay.TabStop = false;
            // 
            // objLargeRawDisplay
            // 
            this.objLargeRawDisplay.Location = new System.Drawing.Point(24, 272);
            this.objLargeRawDisplay.Name = "objLargeRawDisplay";
            this.objLargeRawDisplay.Size = new System.Drawing.Size(243, 210);
            this.objLargeRawDisplay.TabIndex = 10;
            this.objLargeRawDisplay.TabStop = false;
            // 
            // objTinyDisplay
            // 
            this.objTinyDisplay.Location = new System.Drawing.Point(1163, 599);
            this.objTinyDisplay.Name = "objTinyDisplay";
            this.objTinyDisplay.Size = new System.Drawing.Size(47, 45);
            this.objTinyDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objTinyDisplay.TabIndex = 11;
            this.objTinyDisplay.TabStop = false;
            this.objTinyDisplay.Click += new System.EventHandler(this.objTinyDisplay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 791);
            this.Controls.Add(this.objTinyDisplay);
            this.Controls.Add(this.objLargeRawDisplay);
            this.Controls.Add(this.objMemoryLeakDisplay);
            this.Controls.Add(this.objLargeEmguDisplay);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.objNumBlurDisplay);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.objButtonBlurDisplay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.objButtonEmguDisplay);
            this.Controls.Add(this.objEmguDisplay);
            this.Controls.Add(this.objRawDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objRawDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objEmguDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objButtonEmguDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objButtonBlurDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objNumBlurDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objLargeEmguDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objMemoryLeakDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objLargeRawDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objTinyDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox objRawDisplay;
        private System.Windows.Forms.PictureBox objEmguDisplay;
        private System.Windows.Forms.PictureBox objButtonEmguDisplay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox objButtonBlurDisplay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox objNumBlurDisplay;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox objLargeEmguDisplay;
        private System.Windows.Forms.PictureBox objMemoryLeakDisplay;
        private System.Windows.Forms.PictureBox objLargeRawDisplay;
        private System.Windows.Forms.PictureBox objTinyDisplay;
    }
}

