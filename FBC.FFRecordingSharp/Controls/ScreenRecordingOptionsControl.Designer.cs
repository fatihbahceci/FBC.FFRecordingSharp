namespace FFRecordingSharp.Controls
{
    partial class ScreenRecordingOptionsControl
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            pSource = new TabPage();
            gbRegion = new GroupBox();
            label4 = new Label();
            bsData = new BindingSource(components);
            rbRegion = new RadioButton();
            rbFullScreen = new RadioButton();
            lReload = new LinkLabel();
            fFFMpegPath = new FileTextBoxControl();
            fileTextBoxControl1 = new FileTextBoxControl();
            cbAudioDevicesForMic = new ComboBox();
            cbAudioDevicesForSystem = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox1 = new CheckBox();
            cbVideoDevices = new ComboBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            pSource.SuspendLayout();
            gbRegion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsData).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(pSource);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(573, 566);
            tabControl1.TabIndex = 0;
            // 
            // pSource
            // 
            pSource.Controls.Add(gbRegion);
            pSource.Controls.Add(lReload);
            pSource.Controls.Add(fFFMpegPath);
            pSource.Controls.Add(fileTextBoxControl1);
            pSource.Controls.Add(cbAudioDevicesForMic);
            pSource.Controls.Add(cbAudioDevicesForSystem);
            pSource.Controls.Add(label3);
            pSource.Controls.Add(label2);
            pSource.Controls.Add(checkBox2);
            pSource.Controls.Add(checkBox3);
            pSource.Controls.Add(checkBox1);
            pSource.Controls.Add(cbVideoDevices);
            pSource.Controls.Add(label1);
            pSource.Location = new Point(4, 24);
            pSource.Name = "pSource";
            pSource.Padding = new Padding(3);
            pSource.Size = new Size(565, 538);
            pSource.TabIndex = 0;
            pSource.Text = "Source";
            pSource.UseVisualStyleBackColor = true;
            // 
            // gbRegion
            // 
            gbRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbRegion.Controls.Add(label4);
            gbRegion.Controls.Add(rbRegion);
            gbRegion.Controls.Add(rbFullScreen);
            gbRegion.Location = new Point(18, 407);
            gbRegion.Name = "gbRegion";
            gbRegion.Size = new Size(526, 91);
            gbRegion.TabIndex = 8;
            gbRegion.TabStop = false;
            gbRegion.Text = "[ Region ]";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.DataBindings.Add(new Binding("Text", bsData, "RegionAsString", true, DataSourceUpdateMode.OnPropertyChanged));
            label4.Location = new Point(160, 30);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 1;
            label4.Text = "label4";
            // 
            // bsData
            // 
            bsData.DataSource = typeof(Models.ScreenRecordingOptionsModel);
            // 
            // rbRegion
            // 
            rbRegion.AutoSize = true;
            rbRegion.Location = new Point(29, 53);
            rbRegion.Name = "rbRegion";
            rbRegion.Size = new Size(96, 19);
            rbRegion.TabIndex = 0;
            rbRegion.Text = "Selected Area";
            rbRegion.UseVisualStyleBackColor = true;
            rbRegion.CheckedChanged += region_CheckedChanged;
            // 
            // rbFullScreen
            // 
            rbFullScreen.AutoSize = true;
            rbFullScreen.Checked = true;
            rbFullScreen.Location = new Point(29, 28);
            rbFullScreen.Name = "rbFullScreen";
            rbFullScreen.Size = new Size(93, 19);
            rbFullScreen.TabIndex = 0;
            rbFullScreen.TabStop = true;
            rbFullScreen.Text = "Entire Screen";
            rbFullScreen.UseVisualStyleBackColor = true;
            rbFullScreen.CheckedChanged += region_CheckedChanged;
            // 
            // lReload
            // 
            lReload.LinkColor = Color.Red;
            lReload.Location = new Point(26, 47);
            lReload.Name = "lReload";
            lReload.Size = new Size(518, 49);
            lReload.TabIndex = 7;
            lReload.TabStop = true;
            lReload.Text = "-";
            lReload.LinkClicked += lReload_LinkClicked;
            // 
            // fFFMpegPath
            // 
            fFFMpegPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fFFMpegPath.DataBindings.Add(new Binding("Path", bsData, "FFMpegPath", true, DataSourceUpdateMode.OnPropertyChanged));
            fFFMpegPath.FileDialogFilter = "FFmpeg Executable (ffmpeg.exe)|ffmpeg.exe";
            fFFMpegPath.FileDialogOverwritePrompt = true;
            fFFMpegPath.FileDialogTitle = "Select a file";
            fFFMpegPath.IsSaveFileDialog = false;
            fFFMpegPath.Location = new Point(18, 6);
            fFFMpegPath.Name = "fFFMpegPath";
            fFFMpegPath.Path = "";
            fFFMpegPath.Size = new Size(526, 43);
            fFFMpegPath.TabIndex = 6;
            fFFMpegPath.Title = "FFMpeg Path";
            // 
            // fileTextBoxControl1
            // 
            fileTextBoxControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileTextBoxControl1.DataBindings.Add(new Binding("Path", bsData, "OutputFileName", true, DataSourceUpdateMode.OnPropertyChanged));
            fileTextBoxControl1.FileDialogFilter = "All files (*.*)|*.*";
            fileTextBoxControl1.FileDialogOverwritePrompt = true;
            fileTextBoxControl1.FileDialogTitle = "Select a file";
            fileTextBoxControl1.IsSaveFileDialog = true;
            fileTextBoxControl1.Location = new Point(6, 351);
            fileTextBoxControl1.Name = "fileTextBoxControl1";
            fileTextBoxControl1.Path = "";
            fileTextBoxControl1.Size = new Size(538, 46);
            fileTextBoxControl1.TabIndex = 5;
            fileTextBoxControl1.Title = "OutputFileName";
            // 
            // cbAudioDevicesForMic
            // 
            cbAudioDevicesForMic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbAudioDevicesForMic.DataBindings.Add(new Binding("SelectedItem", bsData, "Microphone", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAudioDevicesForMic.DataBindings.Add(new Binding("Enabled", bsData, "EnableMicrophone", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAudioDevicesForMic.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAudioDevicesForMic.FormattingEnabled = true;
            cbAudioDevicesForMic.Location = new Point(100, 307);
            cbAudioDevicesForMic.Name = "cbAudioDevicesForMic";
            cbAudioDevicesForMic.Size = new Size(444, 23);
            cbAudioDevicesForMic.TabIndex = 4;
            // 
            // cbAudioDevicesForSystem
            // 
            cbAudioDevicesForSystem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbAudioDevicesForSystem.DataBindings.Add(new Binding("SelectedItem", bsData, "SystemAudio", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAudioDevicesForSystem.DataBindings.Add(new Binding("Enabled", bsData, "EnableSystemAudio", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAudioDevicesForSystem.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAudioDevicesForSystem.FormattingEnabled = true;
            cbAudioDevicesForSystem.Location = new Point(100, 206);
            cbAudioDevicesForSystem.Name = "cbAudioDevicesForSystem";
            cbAudioDevicesForSystem.Size = new Size(444, 23);
            cbAudioDevicesForSystem.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 310);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 3;
            label3.Text = "Microphone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 209);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 3;
            label2.Text = "SystemAudio";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.DataBindings.Add(new Binding("Checked", bsData, "EnableMicrophone", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBox2.Location = new Point(23, 274);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(126, 19);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "EnableMicrophone";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.DataBindings.Add(new Binding("Checked", bsData, "GdiGraph", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBox3.Location = new Point(23, 96);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(76, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "GdiGraph";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.DataBindings.Add(new Binding("Checked", bsData, "EnableSystemAudio", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBox1.Location = new Point(23, 173);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(131, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "EnableSystemAudio";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbVideoDevices
            // 
            cbVideoDevices.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbVideoDevices.DataBindings.Add(new Binding("SelectedItem", bsData, "VideoSource", true, DataSourceUpdateMode.OnPropertyChanged));
            cbVideoDevices.DataBindings.Add(new Binding("Enabled", bsData, "EnableVideoSource", true, DataSourceUpdateMode.OnPropertyChanged));
            cbVideoDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVideoDevices.FormattingEnabled = true;
            cbVideoDevices.Location = new Point(100, 126);
            cbVideoDevices.Name = "cbVideoDevices";
            cbVideoDevices.Size = new Size(444, 23);
            cbVideoDevices.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 129);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "VideoSource";
            // 
            // ScreenRecordingOptionsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "ScreenRecordingOptionsControl";
            Size = new Size(573, 566);
            tabControl1.ResumeLayout(false);
            pSource.ResumeLayout(false);
            pSource.PerformLayout();
            gbRegion.ResumeLayout(false);
            gbRegion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage pSource;
        private ComboBox cbVideoDevices;
        private Label label1;
        private ComboBox cbAudioDevicesForMic;
        private ComboBox cbAudioDevicesForSystem;
        private Label label3;
        private Label label2;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private BindingSource bsData;
        private FileTextBoxControl fileTextBoxControl1;
        private FileTextBoxControl fFFMpegPath;
        private LinkLabel lReload;
        private GroupBox gbRegion;
        private RadioButton rbRegion;
        private RadioButton rbFullScreen;
        private Label label4;
        private CheckBox checkBox3;
    }
}
