namespace FFRecordingSharp.Controls
{
    partial class AsyncLogControl
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
            tbLog = new TextBox();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnClear = new Button();
            btnCopyClear = new Button();
            cbWordWrap = new CheckBox();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tbLog
            // 
            tbLog.Dock = DockStyle.Fill;
            tbLog.Font = new Font("Courier New", 9F);
            tbLog.Location = new Point(0, 0);
            tbLog.Multiline = true;
            tbLog.Name = "tbLog";
            tbLog.ScrollBars = ScrollBars.Both;
            tbLog.Size = new Size(784, 591);
            tbLog.TabIndex = 2;
            tbLog.WordWrap = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 591);
            panel2.Name = "panel2";
            panel2.Size = new Size(784, 39);
            panel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btnClear, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCopyClear, 1, 0);
            tableLayoutPanel1.Controls.Add(cbWordWrap, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(784, 39);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Left;
            btnClear.Location = new Point(5, 5);
            btnClear.Margin = new Padding(5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 29);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCopyClear
            // 
            btnCopyClear.Dock = DockStyle.Left;
            btnCopyClear.Location = new Point(90, 5);
            btnCopyClear.Margin = new Padding(5);
            btnCopyClear.Name = "btnCopyClear";
            btnCopyClear.Size = new Size(114, 29);
            btnCopyClear.TabIndex = 2;
            btnCopyClear.Text = "Copy && Clear";
            btnCopyClear.UseVisualStyleBackColor = true;
            btnCopyClear.Click += btnCopyClear_Click;
            // 
            // cbWordWrap
            // 
            cbWordWrap.AutoSize = true;
            cbWordWrap.Dock = DockStyle.Left;
            cbWordWrap.Location = new Point(219, 3);
            cbWordWrap.Margin = new Padding(10, 3, 3, 3);
            cbWordWrap.Name = "cbWordWrap";
            cbWordWrap.Size = new Size(83, 33);
            cbWordWrap.TabIndex = 3;
            cbWordWrap.Text = "WordWrap";
            cbWordWrap.UseVisualStyleBackColor = true;
            cbWordWrap.CheckedChanged += cbWordWrap_CheckedChanged;
            // 
            // AsyncLogControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbLog);
            Controls.Add(panel2);
            Name = "AsyncLogControl";
            Size = new Size(784, 630);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbLog;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnClear;
        private Button btnCopyClear;
        private CheckBox cbWordWrap;
    }
}
