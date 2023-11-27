using FBC.FFRecordingSharp.Helpers;
using FFRecordingSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FFRecordingSharp.Controls
{
    public partial class ScreenRecordingOptionsControl : UserControl
    {
        private ScreenRecordingOptionsModel _model = new ScreenRecordingOptionsModel();
        public ScreenRecordingOptionsControl()
        {
            InitializeComponent();
            _model.PropertyChanged += ModelPropertyChanged;
            bsData.DataSource = _model;

            // if not in designer
            if (!DesignMode)
            {
                initializeCombos();
            }
        }



        private void LinkFailed(bool isFailed)
        {
            if (isFailed)
            {
                lReload.Text = FBCHelper.FFMPEG_NOT_FOUND_LINKED_LABEL;
                lReload.LinkColor = Color.Red;
                lReload.VisitedLinkColor = Color.Red;
            }
            else
            {
                lReload.Text = FBCHelper.DEFAULT_LINKED_LABEL;
                lReload.LinkColor = Color.Blue;
                lReload.VisitedLinkColor = Color.Blue;
            }
        }

        private void initializeCombos()
        {
            try
            {
                var devices = Device.GetAllDevicesWithFFmpeg(_model.FFMpegPath);
                var videoDevices = devices.Where(x => x.Type == DeviceType.Video).Select(x => x.Name!).ToList();
                var audioDevices = devices.Where(x => x.Type == DeviceType.Audio).Select(x => x.Name!).ToList();
                cbVideoDevices.DataSource = new[] { "" }.Concat(videoDevices).ToList();
                cbAudioDevicesForMic.DataSource = new[] { "" }.Concat(audioDevices).ToList();
                cbAudioDevicesForSystem.DataSource = new[] { "" }.Concat(audioDevices).ToList();
                if (videoDevices.Any())
                {
                    var index = videoDevices.GetScreenCaptureRecorderIndex();
                    if (index >= 0)
                    {
                        _model.VideoSource = videoDevices[index];
                        _model.GdiGraph = false;
                    }
                    else
                    {
                        _model.VideoSource = videoDevices[0];
                    }
                }
                if (audioDevices.Any())
                {
                    var index = audioDevices.GetAudioCaptureRecorderIndex();
                    if (index >= 0)
                    {
                        _model.SystemAudio = audioDevices[index];
                    }
                    else
                    {
                        _model.SystemAudio = audioDevices[0];
                    }
                    _model.EnableSystemAudio = !string.IsNullOrEmpty(_model.SystemAudio);
                    var otherAudioDevices = audioDevices.Where(x => x != _model.SystemAudio).ToList();
                    if (otherAudioDevices.Any())
                    {
                        _model.Microphone = otherAudioDevices[0];
                    }
                    else
                    {
                        _model.Microphone = null;
                    }

                    _model.EnableMicrophone = !string.IsNullOrEmpty(_model.Microphone);

                }

                LinkFailed(false);
            }
            //If exception is Win32Exception, then ffmpeg is not installed
            catch (System.ComponentModel.Win32Exception)
            {
                //MessageBox.Show("FFmpeg not found. Please install FFmpeg and try again.", "FFmpeg not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LinkFailed(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LinkFailed(true);
            }
        }

        public ScreenRecordingOptionsModel GetModel()
        {
            return _model;
        }

        private void lReload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            initializeCombos();
        }

        private void ModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_model.Region):
                    if (_model.Region != null)
                    {
                        rbRegion.Checked = true;
                    }
                    else
                    {
                        rbFullScreen.Checked = true;
                    }
                    break;
            }
        }

        private void region_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender is RadioButton rb && rb.Checked))
            {
                switch (rb.Name)
                {
                    case nameof(rbRegion):
                        using (var form = new RegionSelectForm())
                        {
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                _model.Region = form.SelectedRegion;
                            }
                        }
                        break;
                    case nameof(rbFullScreen):
                        _model.Region = null;
                        break;
                }
            }

        }
    }
}
