namespace FFRecordingSharp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnStop = new Button();
            btnStart = new Button();
            cbMinimizeToTrayOnRecording = new CheckBox();
            cbOpenOutputOnFinished = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            ssOptions = new Controls.ScreenRecordingOptionsControl();
            tabPage2 = new TabPage();
            logger = new Controls.AsyncLogControl();
            tbAbout = new TabPage();
            creditsControl1 = new FBC.FFRecordingSharp.Controls.CreditsControl();
            trayIcon = new NotifyIcon(components);
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tbAbout.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 561);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 50);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnStop, 1, 0);
            tableLayoutPanel1.Controls.Add(btnStart, 0, 0);
            tableLayoutPanel1.Controls.Add(cbMinimizeToTrayOnRecording, 2, 0);
            tableLayoutPanel1.Controls.Add(cbOpenOutputOnFinished, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(589, 50);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // btnStop
            // 
            btnStop.Dock = DockStyle.Left;
            btnStop.Location = new Point(90, 5);
            btnStop.Margin = new Padding(5);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 40);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += button2_Click;
            // 
            // btnStart
            // 
            btnStart.Dock = DockStyle.Left;
            btnStart.Location = new Point(5, 5);
            btnStart.Margin = new Padding(5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 40);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button1_Click_1;
            // 
            // cbMinimizeToTrayOnRecording
            // 
            cbMinimizeToTrayOnRecording.AutoSize = true;
            cbMinimizeToTrayOnRecording.Checked = true;
            cbMinimizeToTrayOnRecording.CheckState = CheckState.Checked;
            cbMinimizeToTrayOnRecording.Dock = DockStyle.Left;
            cbMinimizeToTrayOnRecording.Location = new Point(180, 3);
            cbMinimizeToTrayOnRecording.Margin = new Padding(10, 3, 3, 3);
            cbMinimizeToTrayOnRecording.Name = "cbMinimizeToTrayOnRecording";
            cbMinimizeToTrayOnRecording.Size = new Size(218, 44);
            cbMinimizeToTrayOnRecording.TabIndex = 2;
            cbMinimizeToTrayOnRecording.Text = "Minimize to the tray when recording";
            cbMinimizeToTrayOnRecording.UseVisualStyleBackColor = true;
            // 
            // cbOpenOutputOnFinished
            // 
            cbOpenOutputOnFinished.AutoSize = true;
            cbOpenOutputOnFinished.Checked = true;
            cbOpenOutputOnFinished.CheckState = CheckState.Checked;
            cbOpenOutputOnFinished.Dock = DockStyle.Left;
            cbOpenOutputOnFinished.Location = new Point(411, 3);
            cbOpenOutputOnFinished.Margin = new Padding(10, 3, 3, 3);
            cbOpenOutputOnFinished.Name = "cbOpenOutputOnFinished";
            cbOpenOutputOnFinished.Size = new Size(136, 44);
            cbOpenOutputOnFinished.TabIndex = 3;
            cbOpenOutputOnFinished.Text = "Show file on finished";
            cbOpenOutputOnFinished.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tbAbout);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(589, 561);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ssOptions);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(581, 533);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Options";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ssOptions
            // 
            ssOptions.Dock = DockStyle.Fill;
            ssOptions.Location = new Point(3, 3);
            ssOptions.Name = "ssOptions";
            ssOptions.Size = new Size(575, 527);
            ssOptions.TabIndex = 2;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(logger);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(581, 533);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Log";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // logger
            // 
            logger.Dock = DockStyle.Fill;
            logger.Location = new Point(3, 3);
            logger.Name = "logger";
            logger.Size = new Size(575, 527);
            logger.TabIndex = 0;
            // 
            // tbAbout
            // 
            tbAbout.Controls.Add(creditsControl1);
            tbAbout.Location = new Point(4, 24);
            tbAbout.Name = "tbAbout";
            tbAbout.Padding = new Padding(3);
            tbAbout.Size = new Size(581, 533);
            tbAbout.TabIndex = 2;
            tbAbout.Text = "About && Credits";
            tbAbout.UseVisualStyleBackColor = true;
            // 
            // creditsControl1
            // 
            creditsControl1.Dock = DockStyle.Fill;
            creditsControl1.Location = new Point(3, 3);
            creditsControl1.Name = "creditsControl1";
            creditsControl1.Size = new Size(575, 527);
            creditsControl1.TabIndex = 0;
            // 
            // trayIcon
            // 
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "Click the icon to finish recording.";
            trayIcon.Visible = true;
            trayIcon.Click += trayIcon_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 611);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(605, 650);
            Name = "MainForm";
            Text = "FBC Screen Recorder";
            FormClosing += MainForm_FormClosing;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tbAbout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btnStart;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Controls.ScreenRecordingOptionsControl ssOptions;
        private TabPage tabPage2;
        private Controls.AsyncLogControl logger;
        private Button btnStop;
        private TableLayoutPanel tableLayoutPanel1;
        private NotifyIcon trayIcon;
        private CheckBox cbMinimizeToTrayOnRecording;
        private CheckBox cbOpenOutputOnFinished;
        private TabPage tbAbout;
        private FBC.FFRecordingSharp.Controls.CreditsControl creditsControl1;
    }
}
