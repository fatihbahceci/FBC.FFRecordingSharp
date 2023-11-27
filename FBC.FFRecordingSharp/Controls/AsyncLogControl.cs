using FBC.FFRecordingSharp.Helpers;
using System;
using System.Collections.Concurrent;
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
    public partial class AsyncLogControl : UserControl
    {
        public AsyncLogControl()
        {
            InitializeComponent();
        }
        private ConcurrentQueue<string> _logQueue = new ConcurrentQueue<string>();
        private volatile bool _isRunning = false;
        private void consumeQueue()
        {
            if (_isRunning) return;
            _isRunning = true;
            try
            {
                while (_logQueue.Any())
                {
                    if (_logQueue.TryDequeue(out string? message))
                    {

                        _internalLog(message);
                    }
                    else
                    {
                        //System.Threading.Thread.Sleep(1);
                        Application.DoEvents();
                    }
                }
            }
            finally
            {
                _isRunning = false;
            }
        }
        public void _internalLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(_internalLog), message);
                return;
            }
            tbLog.AppendText(message + Environment.NewLine);
        }
        public void Log(string message)
        {
            _logQueue.Enqueue(message);
            if (!_isRunning)
            {
                Task.Run(() => consumeQueue());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void btnCopyClear_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbLog.Text);

            tbLog.Clear();
        }

        private void cbWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            tbLog.InvokeIfRequired(() => tbLog.WordWrap = cbWordWrap.Checked);
        }
    }
}
