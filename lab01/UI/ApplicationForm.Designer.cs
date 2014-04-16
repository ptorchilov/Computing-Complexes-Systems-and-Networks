namespace UI
{
    using System.Windows.Forms;

    partial class ApplicationForm
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
            TextBox.CheckForIllegalCrossThreadCalls = false;

            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxHost3 = new System.Windows.Forms.TextBox();
            this.textBoxHost2 = new System.Windows.Forms.TextBox();
            this.textBoxHost1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxStatistics = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxHost3);
            this.groupBox1.Controls.Add(this.textBoxHost2);
            this.groupBox1.Controls.Add(this.textBoxHost1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hosts";
            // 
            // textBoxHost3
            // 
            this.textBoxHost3.Location = new System.Drawing.Point(418, 19);
            this.textBoxHost3.Multiline = true;
            this.textBoxHost3.Name = "textBoxHost3";
            this.textBoxHost3.Size = new System.Drawing.Size(175, 74);
            this.textBoxHost3.TabIndex = 2;
            this.textBoxHost3.Text = "3333333333";
            // 
            // textBoxHost2
            // 
            this.textBoxHost2.Location = new System.Drawing.Point(211, 20);
            this.textBoxHost2.Multiline = true;
            this.textBoxHost2.Name = "textBoxHost2";
            this.textBoxHost2.Size = new System.Drawing.Size(175, 74);
            this.textBoxHost2.TabIndex = 1;
            this.textBoxHost2.Text = "2222222222";
            // 
            // textBoxHost1
            // 
            this.textBoxHost1.Location = new System.Drawing.Point(7, 20);
            this.textBoxHost1.Multiline = true;
            this.textBoxHost1.Name = "textBoxHost1";
            this.textBoxHost1.Size = new System.Drawing.Size(175, 74);
            this.textBoxHost1.TabIndex = 0;
            this.textBoxHost1.Text = "1111111111";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxStatistics);
            this.groupBox2.Location = new System.Drawing.Point(13, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // textBoxStatistics
            // 
            this.textBoxStatistics.Location = new System.Drawing.Point(7, 20);
            this.textBoxStatistics.Multiline = true;
            this.textBoxStatistics.Name = "textBoxStatistics";
            this.textBoxStatistics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatistics.Size = new System.Drawing.Size(586, 104);
            this.textBoxStatistics.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxOutput);
            this.groupBox3.Location = new System.Drawing.Point(13, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(599, 130);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(7, 19);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(586, 104);
            this.textBoxOutput.TabIndex = 1;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(176, 401);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(82, 29);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(375, 401);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(87, 29);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ApplicationForm";
            this.Text = "Lab 01 - CSMA/CD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationFormFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxHost3;
        private System.Windows.Forms.TextBox textBoxHost2;
        private System.Windows.Forms.TextBox textBoxHost1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox textBoxStatistics;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
    }
}

