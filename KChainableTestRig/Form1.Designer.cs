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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.objParameterPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.objAvailableList = new System.Windows.Forms.ListBox();
            this.objUsedList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.objFinalDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // objFinalDisplay
            // 
            this.objFinalDisplay.Location = new System.Drawing.Point(244, 155);
            this.objFinalDisplay.Name = "objFinalDisplay";
            this.objFinalDisplay.Size = new System.Drawing.Size(1059, 663);
            this.objFinalDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.objFinalDisplay.TabIndex = 0;
            this.objFinalDisplay.TabStop = false;
            this.objFinalDisplay.DoubleClick += new System.EventHandler(this.objFinalDisplay_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Used";
            // 
            // objParameterPanel
            // 
            this.objParameterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objParameterPanel.Location = new System.Drawing.Point(500, 54);
            this.objParameterPanel.Name = "objParameterPanel";
            this.objParameterPanel.Size = new System.Drawing.Size(651, 95);
            this.objParameterPanel.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // objAvailableList
            // 
            this.objAvailableList.FormattingEnabled = true;
            this.objAvailableList.Location = new System.Drawing.Point(31, 54);
            this.objAvailableList.Name = "objAvailableList";
            this.objAvailableList.Size = new System.Drawing.Size(174, 95);
            this.objAvailableList.TabIndex = 9;
            // 
            // objUsedList
            // 
            this.objUsedList.FormattingEnabled = true;
            this.objUsedList.Location = new System.Drawing.Point(244, 54);
            this.objUsedList.Name = "objUsedList";
            this.objUsedList.Size = new System.Drawing.Size(174, 95);
            this.objUsedList.TabIndex = 10;
            this.objUsedList.SelectedIndexChanged += new System.EventHandler(this.objUsedList_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "^";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(424, 86);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(424, 115);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "V";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(457, 86);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Run";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 830);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.objUsedList);
            this.Controls.Add(this.objAvailableList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.objParameterPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.objFinalDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objFinalDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox objFinalDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel objParameterPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox objAvailableList;
        private System.Windows.Forms.ListBox objUsedList;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

