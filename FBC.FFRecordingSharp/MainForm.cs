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
            tabControl1.SelectedIndex = 1;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            cts = new CancellationTokenSource();
            var options = ssOptions.GetModel();
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
