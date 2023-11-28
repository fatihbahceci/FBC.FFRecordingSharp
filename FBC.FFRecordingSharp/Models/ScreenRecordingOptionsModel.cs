using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FBC.FFRecordingSharp.Helpers;

namespace FFRecordingSharp.Models
{
    public class ScreenRecordingOptionsModel : INotifyPropertyChanged
    {
        private string _ffmpegPath = "ffmpeg.exe";
        private string? _outputFileName = "output.mp4";
        private bool _gdiGraph = true;
        private string? _videoSource;
        private bool _enableSystemAudio;
        private bool _enableMicrophone;
        private string? _systemAudio;
        private string? _microphone;
        private Rectangle? _region;

        public event PropertyChangedEventHandler? PropertyChanged;


        private Rectangle makeDivisibleBy2(Rectangle rect)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width / 2 * 2, rect.Height / 2 * 2);
        }

        public Rectangle? Region
        {
            get { return _region; }
            set
            {
                _region = value;
                if (_region.HasValue && (_region.Value.IsEmpty))
                {
                    _region = null;
                }
                if (_region.HasValue)
                {
                    _region = makeDivisibleBy2(_region.Value);
                }
                adjustMarkForm();
                NotifyPropertyChanged();
            }
        }

        public string RegionAsString
        {
            get
            {
                return _region.HasValue
                    ? $"x: {_region.Value.X} y: {_region!.Value.Y} w: {_region!.Value.Width} h: {_region!.Value.Height}"
                    : "Entire Screen";
            }
        }

        public string FFMpegPath
        {
            get { return _ffmpegPath; }
            set
            {
                _ffmpegPath = value;
                NotifyPropertyChanged();
            }
        }

        public string? OutputFileName
        {
            get { return _outputFileName; }
            set
            {
                _outputFileName = value;
                NotifyPropertyChanged();
            }
        }

        public bool GdiGraph
        {
            get { return _gdiGraph; }
            set
            {
                _gdiGraph = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(EnableVideoSource));
            }
        }

        public bool EnableVideoSource
        {
            get { return !GdiGraph; }
        }

        public string? VideoSource
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableSystemAudio
        {
            get { return _enableSystemAudio; }
            set
            {
                _enableSystemAudio = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableMicrophone
        {
            get { return _enableMicrophone; }
            set
            {
                _enableMicrophone = value;
                NotifyPropertyChanged();
            }
        }

        public string? SystemAudio
        {
            get { return _systemAudio; }
            set
            {
                _systemAudio = value;
                NotifyPropertyChanged();
            }
        }

        public string? Microphone
        {
            get { return _microphone; }
            set
            {
                _microphone = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // Other options
        //public bool EnableMouseClicks { get; set; }
        //public bool EnableMousePointer { get; set; }
        //public bool EnableMouseHighlight { get; set; }
        //public bool EnableKeystrokes { get; set; }
        //public bool EnableTimestamp { get; set; }
        //public bool EnablePreview { get; set; }
        //public bool EnableDebug { get; set; }
        //public bool EnableDebugLog { get; set; }
        //public bool EnableDebugLogVerbose { get; set; }
        //public bool EnableDebugLogToFile { get; set; }
        //public bool EnableDebugLogToConsole { get; set; }
        //public bool EnableDebugLogToDebugOutput { get; set; }
        //public bool EnableDebugLogToEventLog { get; set; }
        //public bool EnableDebugLogToTraceLog { get; set; }
        //public bool EnableDebugLogToTraceLogVerbose { get; set; }
        //public bool EnableDebugLogToTraceLogToFile { get; set; }
        //public bool EnableDebugLogToTraceLogToConsole { get; set; }
        //public bool EnableDebugLogToTraceLogToDebugOutput { get; set; }

        //Add fullc screen, window, region, etc. options

        /**
        -hide_banner 
        -f dshow 
        -thread_queue_size 1024 
        -rtbufsize 256M 
        -audio_buffer_size 80 
        -framerate 30 
        -i video="screen-capture-recorder":audio="Microphone Array (Intel® Smart Sound Technology for Digital Microphones)" 
        -c:v libx264 
        -r 30 
        -preset ultrafast 
        -tune zerolatency 
        -crf 28 
        -pix_fmt yuv420p 
        -movflags +faststart 
        -c:a aac -ac 2 
        -b:a 256k 
        -y "C:\Users\fatih\Documents\ShareX\Screenshots\2023-11\000983_2023-11-27_00-12-59-938.mp4"


        -hide_banner 
        -f dshow 
        -thread_queue_size 1024 
        -rtbufsize 256M 
        -audio_buffer_size 80 
        
        -i audio="Microphone Array (Intel® Smart Sound Technology for Digital Microphones)" 
        -f gdigrab 
        -thread_queue_size 1024 
        -rtbufsize 256M 
        -framerate 30 
        -offset_x 448 
        -offset_y 126 
        -video_size 1048x648 
        -draw_mouse 1 
        -i desktop -c:v libx264 -r 30 -preset ultrafast -tune zerolatency -crf 28 -pix_fmt yuv420p -movflags +faststart -c:a aac -ac 2 -b:a 256k -y "C:\Users\fatih\Documents\ShareX\Screenshots\2023-11\000984_2023-11-27_04-11-17-216.mp4"

         */




        public string GenerateFFMpegCommand()
        {
            if (string.IsNullOrEmpty(SystemAudio))
            {
                EnableSystemAudio = false;
            }
            if (string.IsNullOrEmpty(Microphone))
            {
                EnableMicrophone = false;
            }
            //Ecample parameters
            /*-hide_banner -f dshow -thread_queue_size 1024 -rtbufsize 256M -audio_buffer_size 80 -framerate 30 -i video="screen-capture-recorder":audio="Microphone Array (Intel® Smart Sound Technology for Digital Microphones)" -c:v libx264 -r 30 -preset ultrafast -tune zerolatency -crf 28 -pix_fmt yuv420p -movflags +faststart -c:a aac -ac 2 -b:a 256k -y "output.mp4"*/
            StringBuilder args = new StringBuilder();
            args.Append("-hide_banner ");
            args.Append("-f dshow ");
            args.Append("-thread_queue_size 1024 ");
            args.Append("-rtbufsize 256M ");
            if (!GdiGraph)
            {
                args.Append("-audio_buffer_size 80 ");
            }
            args.Append("-framerate 30 ");

            if (Region.HasValue)
            {


                if (!GdiGraph && FBCHelper.IsScreenCaptureRecorder(VideoSource))
                {
                    // https://github.com/rdp/screen-capture-recorder-to-video-windows-free
                    string registryPath = "Software\\screen-capture-recorder";
                    FBCHelper.CreateRegistry(registryPath, "start_x", Region.Value.X);
                    FBCHelper.CreateRegistry(registryPath, "start_y", Region.Value.Y);
                    FBCHelper.CreateRegistry(registryPath, "capture_width", Region.Value.Width);
                    FBCHelper.CreateRegistry(registryPath, "capture_height", Region.Value.Height);
                    FBCHelper.CreateRegistry(registryPath, "default_max_fps", 60);
                    //RegistryHelpers.CreateRegistry(registryPath, "capture_mouse_default_1", DrawCursor ? 1 : 0);
                }
                else
                {
                    args.Append($"-offset_x {Region.Value.X} ");
                    args.Append($"-offset_y {Region.Value.Y} ");
                    args.Append($"-video_size {Region.Value.Width}x{Region.Value.Height} ");
                    //args.Append($"offset_x={Region.Value.X}:"); // Horizontal offset of the captured video.
                    //args.Append($"offset_y={Region.Value.Y}:"); // Vertical offset of the captured video.
                    //args.Append($"video_size={Region.Value.Width}x{Region.Value.Height}:"); // Specify the size of the captured video.
                }
            }
            else
            {
                string registryPath = "Software\\screen-capture-recorder";
                FBCHelper.RemoveRegistry(registryPath, true);
                //GHelper.RemoveRegistryKey(registryPath, "start_x");
                //GHelper.RemoveRegistryKey(registryPath, "start_y");
                //GHelper.RemoveRegistryKey(registryPath, "capture_width");
                //GHelper.RemoveRegistryKey(registryPath, "capture_height");
                //GHelper.RemoveRegistryKey(registryPath, "default_max_fps");
                //RegistryHelpers.RemoveRegistryKey(registryPath, "capture_mouse_default_1", DrawCursor ? 1 : 0);

            }
            //else
            //{
            //    sb.Append("-video_size 1920x1080 ");
            //}

            if (GdiGraph)
            {
                args.Append("-f gdigrab ");
                args.Append("-i desktop ");
            }
            else
            {
                args.Append($"-i video=\"{VideoSource}\" ");
            }
            //if (EnableSystemAudio)
            //{
            //    sb.Append(":audio=\"");
            //    sb.Append(SystemAudio);
            //    sb.Append("\"");
            //}
            //if (EnableMicrophone)
            //{
            //    sb.Append(":audio=\"");
            //    sb.Append(Microphone);
            //    sb.Append("\"");
            //}

            if (EnableSystemAudio)
            {
                args.Append(@$"-f dshow -i audio=""{SystemAudio}"" ");
            }
            if (EnableMicrophone)
            {
                args.Append(@$"-f dshow -i audio=""{Microphone}"" ");
            }
            if (EnableSystemAudio && EnableMicrophone)
            {
                args.Append(@"-filter_complex ""[1:a][2:a]amerge = inputs = 2[a]"" -map 0:v -map ""[a]""  ");
            }
            args.Append(" -c:v libx264 ");
            args.Append("-r 30 ");
            args.Append("-preset ultrafast ");
            args.Append("-tune zerolatency ");
            args.Append("-crf 28 ");
            args.Append("-pix_fmt yuv420p ");
            args.Append("-movflags +faststart ");
            args.Append("-c:a aac ");
            args.Append("-ac 2 ");
            args.Append("-b:a 256k ");
            args.Append("-y ");
            args.Append("\"");
            args.Append(OutputFileName);
            args.Append("\"");
            return args.ToString();


        }

        public string RunFFMpegCommand()
        {
            return FBCHelper.RunFFMpegCommand(FFMpegPath, GenerateFFMpegCommand());
        }

        private void adjustMarkForm()
        {
            destroyMarkForm();
            if (Region.HasValue)
            {
                markForm = new OverlayForm(Region.Value, Color.DarkBlue);
                markForm.Show();
            }
        }
        private void destroyMarkForm()
        {
            if (markForm != null)
            {
                markForm.Close();
                markForm.Dispose();
                markForm = null;
            }
        }

        private void createOverlayForm()
        {
            if (Region.HasValue)
            {
                overlayForm = new OverlayForm(Region.Value, Color.Red);
                overlayForm.Show();
            }
        }
        private void destroyOverlayForm()
        {
            if (overlayForm != null)
            {
                overlayForm.Close();
                overlayForm.Dispose();
                overlayForm = null;
            }
        }

        OverlayForm? overlayForm;
        OverlayForm? markForm;
        public async Task RunFFMpegCommandAsync(Action<string> onLogAction, CancellationToken ct)
        {
            var command = GenerateFFMpegCommand();
            onLogAction("Command: ");
            onLogAction(command);
            onLogAction("Starting ffmpeg...");
            destroyMarkForm();
            createOverlayForm();
            await FBCHelper.RunFFMpegCommandAsync(FFMpegPath, command, onLogAction, ct);
            destroyOverlayForm();
            this.Region = null;
            adjustMarkForm();

        }

    }
}
