namespace FBC.FFRecordingSharp.Controls
{
    partial class CreditsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            label3 = new Label();
            linkLabel2 = new LinkLabel();
            label4 = new Label();
            linkLabel3 = new LinkLabel();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(18, 106);
            label1.Name = "label1";
            label1.Size = new Size(74, 25);
            label1.TabIndex = 0;
            label1.Text = "Credits";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(60, 170);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(142, 15);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://www.ffmpeg.org/";
            linkLabel1.LinkClicked += linkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 144);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 0;
            label2.Text = "FFmpeg";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 195);
            label3.Name = "label3";
            label3.Size = new Size(137, 15);
            label3.TabIndex = 0;
            label3.Text = "Screen Capture Recorder";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(60, 224);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(392, 15);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "https://github.com/rdp/screen-capture-recorder-to-video-windows-free";
            linkLabel2.LinkClicked += linkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label4.Location = new Point(18, 14);
            label4.Name = "label4";
            label4.Size = new Size(215, 25);
            label4.TabIndex = 0;
            label4.Text = "FBC.FFRecordingSharp";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Location = new Point(60, 76);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(304, 15);
            linkLabel3.TabIndex = 1;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "https://github.com/fatihbahceci/FBC.FFRecordingSharp";
            linkLabel3.LinkClicked += linkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 51);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 0;
            label5.Text = "App Site";
            // 
            // CreditsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "CreditsControl";
            Size = new Size(487, 520);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabel2;
        private Label label4;
        private LinkLabel linkLabel3;
        private Label label5;
    }
}
