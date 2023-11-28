using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFRecordingSharp.Controls
{
    public partial class FileTextBoxControl : UserControl
    {
        public FileTextBoxControl()
        {
            InitializeComponent();
            adjustControls();
        }

        private void adjustControls()
        {
            var newMarginHeight = (tPanel.Height - tbPath.Height) / 2;
            tbPath.Margin = new Padding(5, newMarginHeight, 0, newMarginHeight);
            btnOpenFile.Margin = new Padding(3, newMarginHeight, 0, newMarginHeight);
        }
        private void FileTextBoxControl_Resize(object sender, EventArgs e)
        {
           adjustControls();
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (IsSaveFileDialog)
            {
                if (new SaveFileDialog()
                {
                    Title = FileDialogTitle,
                    Filter = FileDialogFilter,
                    FileName = Path,
                    OverwritePrompt = FileDialogOverwritePrompt,

                }
                    is SaveFileDialog saveFileDialog
                    && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Path = saveFileDialog.FileName;
                }
            }
            else
            {
                if (new OpenFileDialog()
                {
                    Title = FileDialogTitle,
                    Filter = FileDialogFilter,
                    FileName = Path,
                }
                    is OpenFileDialog openFileDialog &&
                    openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Path = openFileDialog.FileName;
                }
            }
        }

        public string Title
        {
            get
            {
                return lTitle.Text;
            }
            set
            {
                lTitle.Text = value;
                lTitle.Width = TextRenderer.MeasureText(lTitle.Text, lTitle.Font).Width + 10;
                adjustControls();
            }
        }

        public string Path
        {
            get
            {
                return tbPath.Text;
            }
            set
            {
                tbPath.Text = value;
                if (!string.IsNullOrEmpty(ForceToExtension))
                    tbPath.Text = System.IO.Path.ChangeExtension(tbPath.Text, ForceToExtension);
            }
        }

        public string ForceToExtension { get; set; }

        public bool IsSaveFileDialog
        {
            get;
            //{
            //return btnOpenFile.Text == "Save";
            //}
            set;
            //{
            //btnOpenFile.Text = value ? "Save" : "Open";
            //}
        } = true;


        public string FileDialogTitle { get; set; } = "Select a file";
        public string FileDialogFilter { get; set; } = "All files (*.*)|*.*";
        public bool FileDialogOverwritePrompt { get; set; } = true;

    }
}
