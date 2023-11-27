namespace FFRecordingSharp.Controls
{
    partial class FileTextBoxControl
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
            tPanel = new TableLayoutPanel();
            lTitle = new Label();
            tbPath = new TextBox();
            btnOpenFile = new Button();
            tPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tPanel
            // 
            tPanel.ColumnCount = 3;
            tPanel.ColumnStyles.Add(new ColumnStyle());
            tPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            tPanel.Controls.Add(lTitle, 0, 0);
            tPanel.Controls.Add(tbPath, 1, 0);
            tPanel.Controls.Add(btnOpenFile, 2, 0);
            tPanel.Dock = DockStyle.Fill;
            tPanel.Location = new Point(0, 0);
            tPanel.Name = "tPanel";
            tPanel.RowCount = 1;
            tPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tPanel.Size = new Size(804, 43);
            tPanel.TabIndex = 0;
            // 
            // lTitle
            // 
            lTitle.Dock = DockStyle.Left;
            lTitle.Location = new Point(3, 0);
            lTitle.Name = "lTitle";
            lTitle.Size = new Size(29, 43);
            lTitle.TabIndex = 0;
            lTitle.Text = "Title";
            lTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tbPath
            // 
            tbPath.Dock = DockStyle.Fill;
            tbPath.Location = new Point(38, 3);
            tbPath.Name = "tbPath";
            tbPath.Size = new Size(731, 23);
            tbPath.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Dock = DockStyle.Fill;
            btnOpenFile.Location = new Point(775, 3);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(26, 37);
            btnOpenFile.TabIndex = 2;
            btnOpenFile.Text = "...";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // FileTextBoxControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tPanel);
            Name = "FileTextBoxControl";
            Size = new Size(804, 43);
            Resize += FileTextBoxControl_Resize;
            tPanel.ResumeLayout(false);
            tPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tPanel;
        private Label lTitle;
        private TextBox tbPath;
        private Button btnOpenFile;
    }
}
