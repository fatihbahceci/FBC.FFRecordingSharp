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
            fFFMpegPath = new FileTextBoxControl();
            bsData = new BindingSource(components);
            gbRegion = new GroupBox();
            btnSelectRegion = new Button();
            label4 = new Label();
            lReload = new LinkLabel();
            fileTextBoxControl1 = new FileTextBoxControl();
            cbAudioDevicesForMic = new ComboBox();
            cbAudioDevicesForSystem = new ComboBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox1 = new CheckBox();
            cbVideoDevices = new ComboBox();
            label1 = new Label();
            btnEntireScreen = new Button();
            tabControl1.SuspendLayout();
            pSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsData).BeginInit();
            gbRegion.SuspendLayout();
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
            pSource.Controls.Add(fFFMpegPath);
            pSource.Controls.Add(gbRegion);
            pSource.Controls.Add(lReload);
            pSource.Controls.Add(fileTextBoxControl1);
            pSource.Controls.Add(cbAudioDevicesForMic);
            pSource.Controls.Add(cbAudioDevicesForSystem);
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
            // fFFMpegPath
            // 
            fFFMpegPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fFFMpegPath.DataBindings.Add(new Binding("Path", bsData, "FFMpegPath", true, DataSourceUpdateMode.OnPropertyChanged));
            fFFMpegPath.FileDialogFilter = "FFmpeg Executable (ffmpeg.exe)|ffmpeg.exe";
            fFFMpegPath.FileDialogOverwritePrompt = true;
            fFFMpegPath.FileDialogTitle = "Select a file";
            fFFMpegPath.IsSaveFileDialog = false;
            fFFMpegPath.Location = new Point(18, 354);
            fFFMpegPath.Name = "fFFMpegPath";
            fFFMpegPath.Path = "";
            fFFMpegPath.Size = new Size(525, 43);
            fFFMpegPath.TabIndex = 9;
            fFFMpegPath.Title = "FFMpeg Path";
            // 
            // bsData
            // 
            bsData.DataSource = typeof(Models.ScreenRecordingOptionsModel);
            // 
            // gbRegion
            // 
            gbRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbRegion.Controls.Add(btnEntireScreen);
            gbRegion.Controls.Add(btnSelectRegion);
            gbRegion.Controls.Add(label4);
            gbRegion.Location = new Point(25, 58);
            gbRegion.Name = "gbRegion";
            gbRegion.Size = new Size(173, 105);
            gbRegion.TabIndex = 8;
            gbRegion.TabStop = false;
            gbRegion.Text = "[ Region ]";
            // 
            // btnSelectRegion
            // 
            btnSelectRegion.Location = new Point(18, 45);
            btnSelectRegion.Name = "btnSelectRegion";
            btnSelectRegion.Size = new Size(113, 23);
            btnSelectRegion.TabIndex = 3;
            btnSelectRegion.Text = "Select Region";
            btnSelectRegion.UseVisualStyleBackColor = true;
            btnSelectRegion.Click += btnSelectRegion_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.DataBindings.Add(new Binding("Text", bsData, "RegionAsString", true, DataSourceUpdateMode.OnPropertyChanged));
            label4.Location = new Point(18, 74);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 1;
            label4.Text = "label4";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lReload
            // 
            lReload.LinkColor = Color.Red;
            lReload.Location = new Point(204, 58);
            lReload.Name = "lReload";
            lReload.Size = new Size(339, 105);
            lReload.TabIndex = 7;
            lReload.TabStop = true;
            lReload.Text = "-";
            lReload.LinkClicked += lReload_LinkClicked;
            // 
            // fileTextBoxControl1
            // 
            fileTextBoxControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileTextBoxControl1.DataBindings.Add(new Binding("Path", bsData, "OutputFileName", true, DataSourceUpdateMode.OnPropertyChanged));
            fileTextBoxControl1.FileDialogFilter = "All files (*.*)|*.*";
            fileTextBoxControl1.FileDialogOverwritePrompt = true;
            fileTextBoxControl1.FileDialogTitle = "Select a file";
            fileTextBoxControl1.IsSaveFileDialog = true;
            fileTextBoxControl1.Location = new Point(18, 6);
            fileTextBoxControl1.Name = "fileTextBoxControl1";
            fileTextBoxControl1.Path = "";
            fileTextBoxControl1.Size = new Size(526, 46);
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
            cbAudioDevicesForMic.Location = new Point(72, 321);
            cbAudioDevicesForMic.Name = "cbAudioDevicesForMic";
            cbAudioDevicesForMic.Size = new Size(471, 23);
            cbAudioDevicesForMic.TabIndex = 4;
            // 
            // cbAudioDevicesForSystem
            // 
            cbAudioDevicesForSystem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbAudioDevicesForSystem.DataBindings.Add(new Binding("SelectedItem", bsData, "SystemAudio", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAudioDevicesForSystem.DataBindings.Add(new Binding("Enabled", bsData, "EnableSystemAudio", true, DataSourceUpdateMode.OnPropertyChanged));
            cbAudioDevicesForSystem.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAudioDevicesForSystem.FormattingEnabled = true;
            cbAudioDevicesForSystem.Location = new Point(72, 259);
            cbAudioDevicesForSystem.Name = "cbAudioDevicesForSystem";
            cbAudioDevicesForSystem.Size = new Size(471, 23);
            cbAudioDevicesForSystem.TabIndex = 4;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.DataBindings.Add(new Binding("Checked", bsData, "EnableMicrophone", true, DataSourceUpdateMode.OnPropertyChanged));
            checkBox2.Location = new Point(25, 296);
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
            checkBox3.Location = new Point(122, 178);
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
            checkBox1.Location = new Point(25, 232);
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
            cbVideoDevices.Location = new Point(72, 203);
            cbVideoDevices.Name = "cbVideoDevices";
            cbVideoDevices.Size = new Size(471, 23);
            cbVideoDevices.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 179);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "VideoSource";
            // 
            // btnEntireScreen
            // 
            btnEntireScreen.Location = new Point(18, 18);
            btnEntireScreen.Name = "btnEntireScreen";
            btnEntireScreen.Size = new Size(113, 23);
            btnEntireScreen.TabIndex = 3;
            btnEntireScreen.Text = "Entire Screen";
            btnEntireScreen.UseVisualStyleBackColor = true;
            btnEntireScreen.Click += btnEntireScreen_Click;
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
            ((System.ComponentModel.ISupportInitialize)bsData).EndInit();
            gbRegion.ResumeLayout(false);
            gbRegion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage pSource;
        private ComboBox cbVideoDevices;
        private Label label1;
        private ComboBox cbAudioDevicesForMic;
        private ComboBox cbAudioDevicesForSystem;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private BindingSource bsData;
        private FileTextBoxControl fileTextBoxControl1;
        private LinkLabel lReload;
        private GroupBox gbRegion;
        private Label label4;
        private CheckBox checkBox3;
        private FileTextBoxControl fFFMpegPath;
        private Button btnSelectRegion;
        private Button btnEntireScreen;
    }
}
