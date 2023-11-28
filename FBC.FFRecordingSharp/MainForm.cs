using FBC.FFRecordingSharp.Helpers;
using System.Text;

namespace FFRecordingSharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private CancellationTokenSource? cts;



        private void button1_Click_1(object sender, EventArgs e)
        {
            var options = ssOptions.GetModel();
            if (string.IsNullOrEmpty(options.OutputFileName))
            {
                MessageBox.Show("Please select an output file name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fullPath = Path.GetFullPath(options.OutputFileName ?? "");

            if (!FBCHelper.CanWriteToDirectory(Path.GetDirectoryName(fullPath)!))
            {
                if (MessageBox.Show(
                    $"It seems that the path is not accessible for saving the file ({fullPath}). This could lead to an error. Do you still want to proceed?", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No) { return; }
            }
            else
                //if output path is same as the app path, then warn user
                if (Path.GetDirectoryName(fullPath) == Path.GetDirectoryName(Application.ExecutablePath))
            {
                if (MessageBox.Show(
                    $"It seems that the output path is the same as the application path ({fullPath}). This could lead to an error. Do you still want to proceed?", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error) == DialogResult.No) { return; }
            }

            if (File.Exists(fullPath))
            {
                if (MessageBox.Show(
                    $"The file ({fullPath}) already exists. Do you want to overwrite it?", "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.No) { return; }
            }

            tabControl1.SelectedIndex = 1;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            cts = new CancellationTokenSource();
            var cancellationToken = new CancellationTokenSource();
            if (cbMinimizeToTrayOnRecording.Checked)
            {
                MinimizeToTray();
            }
            _ = options.RunFFMpegCommandAsync((s) =>
            {
                logger.Log(s);
            }, cts.Token).ContinueWith((t) =>
            {
                //if (t.IsFaulted)
                //{
                //    logger.Log(t.Exception!.ToString());
                //}
                btnStart.InvokeIfRequired(() => btnStart.Enabled = true);
                btnStop.InvokeIfRequired(() => btnStop.Enabled = false);
                if (cbOpenOutputOnFinished.Checked)
                {
                    FBCHelper.OpenFolderAndSelectFile(options.OutputFileName!);
                }
                if (isMinimizedToTray)
                {
                    RestoreFromTray();
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts?.Cancel();
        }
        private bool isMinimizedToTray = false;

        private void MinimizeToTray()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            trayIcon.Visible = true;
            isMinimizedToTray = true;
            //Pop message balloon from tray icon
            trayIcon.ShowBalloonTip(500, "FFRecordingSharp", "Click tray icon to finish recording", ToolTipIcon.Info);
        }

        private void RestoreFromTray()
        {
            this.InvokeIfRequired(() =>
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                trayIcon.Visible = false;
                isMinimizedToTray = false;
            });
        }

        private void trayIcon_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }
    }
}
