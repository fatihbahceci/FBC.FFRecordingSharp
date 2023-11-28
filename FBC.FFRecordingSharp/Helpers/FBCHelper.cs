using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FBC.FFRecordingSharp.Helpers
{
    internal static class FBCHelper
    {
        public const string FFMPEG_NOT_FOUND = "FFmpeg not found. Please add the path to ffmpeg.exe in your system environment's PATH variable and set the ffmpeg path as 'ffmpeg.exe', or specify the full path to ffmpeg.exe directly in the ffmpeg path setting.";
        public const string FFMPEG_NOT_FOUND_LINKED_LABEL = FFMPEG_NOT_FOUND + " Then click on this message to try again.";
        public const string DEFAULT_LINKED_LABEL = "Click here to reload devices.";

        public const string SCREEN_CAPTURE_RECORDER = "screen-capture-recorder";
        public const string SCREEN_CAPTURE_RECORDER2 = "dshow (screen-capture-recorder)";

        public const string AUDIO_CAPTURE_RECORDER = "virtual-audio-capturer";
        public const string AUDIO_CAPTURE_RECORDER2 = "dshow (virtual-audio-capturer)";


        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private static ProcessStartInfo GetProcessStartInfo(string ffmpegPath, string command)
        {
            return new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                CreateNoWindow = true
            };
        }

        public async static Task RunFFMpegCommandAsync(string ffmpegPath, string command, Action<string> onLogAction, CancellationToken cancellationToken)
        {
            using (var process = new Process { StartInfo = GetProcessStartInfo(ffmpegPath, command) })
            {
                try
                {
                    process.Start();

                }
                catch (Win32Exception)
                {
                    onLogAction(FFMPEG_NOT_FOUND);
                }
                catch (Exception ex)
                {
                    onLogAction("Error: " + ex.Message);
                }
                var logTask = Task.Run(async () =>
                {
                    using (var reader = process.StandardError)
                    {
                        string? line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            onLogAction(line);
                        }
                    }
                });

                var cancelTask = Task.Run(() =>
                {
                    if (cancellationToken.WaitHandle.WaitOne())
                    {
                        if (!process.HasExited)
                        {
                            process.StandardInput.WriteLine("q");
                        }
                    }
                });

                await Task.WhenAny(logTask, cancelTask);

                if (!process.HasExited)
                {
                    process.WaitForExit();
                }
            }
        }

        public async static Task RunFFMpegCommandAsync(string ffmpegPath, string command, Action<string> onLogAction)
        {
            try
            {
                using (var process = Process.Start(GetProcessStartInfo(ffmpegPath, command)))
                {
                    using (var reader = process!.StandardError)
                    {
                        string? line;
                        while ((line = await reader!.ReadLineAsync()) != null)
                        {
                            onLogAction(line);
                        }
                    }
                }
            }
            catch (Win32Exception)
            {
                onLogAction(FFMPEG_NOT_FOUND);
            }
            catch (Exception ex)
            {
                onLogAction("Error: " + ex.Message);
            }

        }
        public static string RunFFMpegCommand(string ffmpegPath, string command)
        {
            StringBuilder sb = new StringBuilder();
            using (var process = Process.Start(GetProcessStartInfo(ffmpegPath, command)))
            {
                using (var reader = process!.StandardError)
                {
                    string? line;
                    while ((line = reader!.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            return sb.ToString();
        }

        public static void OpenFolderAndSelectFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    return;
                }
            }

            string argument = @$"/select, ""{filePath}""";
            Process.Start("explorer.exe", argument);
        }

        public static void CreateRegistry(string path, string name, int value, RegistryHive root = RegistryHive.CurrentUser)
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(root, RegistryView.Default).CreateSubKey(path))
            {
                if (rk != null)
                {
                    rk.SetValue(name, value, RegistryValueKind.DWord);
                }
            }
        }

        public static void RemoveRegistry(string path, bool recursive = false, RegistryHive root = RegistryHive.CurrentUser)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    using (RegistryKey rk = RegistryKey.OpenBaseKey(root, RegistryView.Default))
                    {
                        if (recursive)
                        {
                            rk.DeleteSubKeyTree(path, false);
                        }
                        else
                        {
                            rk.DeleteSubKey(path, false);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public static void RemoveRegistryKey(string path, string name, RegistryHive root = RegistryHive.CurrentUser)
        {
            try
            {
                using (RegistryKey rk = RegistryKey.OpenBaseKey(root, RegistryView.Default).OpenSubKey(path, true)!)
                {
                    if (rk != null)
                    {
                        rk.DeleteValue(name, false);
                    }
                }
            }
            catch
            {

            }
        }


        public static bool IsScreenCaptureRecorder(this string? VideoSource)
        {
            return VideoSource?.Equals(SCREEN_CAPTURE_RECORDER, StringComparison.OrdinalIgnoreCase) == true ||
                VideoSource?.Equals(SCREEN_CAPTURE_RECORDER2, StringComparison.OrdinalIgnoreCase) == true;
        }

        public static int GetScreenCaptureRecorderIndex(this List<string> videoDevices)
        {
            //one of the video devices is screen capture recorder or dshow (screen-capture-recorder)
            return videoDevices.FindIndex(x => x.IsScreenCaptureRecorder());
        }

        public static bool IsAudioCaptureRecorder(this string? AudioSource)
        {
            return AudioSource?.Equals(AUDIO_CAPTURE_RECORDER, StringComparison.OrdinalIgnoreCase) == true ||
                AudioSource?.Equals(AUDIO_CAPTURE_RECORDER2, StringComparison.OrdinalIgnoreCase) == true;
        }

        public static int GetAudioCaptureRecorderIndex(this List<string> audioDevices)
        {
            //one of the audio devices is virtual-audio-capturer or dshow (virtual-audio-capturer)
            return audioDevices.FindIndex(x => x.IsAudioCaptureRecorder());
        }

        public static Size GetScreenResolution()
        {
            return new Size(Screen.PrimaryScreen!.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public static void OpenUrlInDefaultBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        public static bool CanWriteToDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            try
            {
                if (Directory.Exists(path))
                {
                    string tempPath = Path.Combine(path, Guid.NewGuid().ToString() + ".test");
                    File.WriteAllText(tempPath, "Test Write");
                    File.Delete(tempPath);
                    return true;
                }
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }
    }
}
