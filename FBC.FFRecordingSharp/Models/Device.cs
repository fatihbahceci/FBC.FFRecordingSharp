using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using FBC.FFRecordingSharp.Helpers;

namespace FFRecordingSharp.Models
{
    public class Device
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DeviceType Type { get; set; }

        override public string ToString()
        {
            return $"Type: {Type}\r\nId: {Id}\r\nName: {Name}";
        }

        public Device()
        {
            Id = null;
            Name = null;
            Type = DeviceType.None;
        }


        //        Example output from ffmpeg -list_devices true -f dshow -i dummy:
        //
        //         Microsoft Windows [Version 10.0.19045.3693]
        //(c) Microsoft Corporation. All rights reserved.
        //
        //C:\Users\fatih>ffmpeg -list_devices true -f dshow -i dummy
        //ffmpeg version N-110486-ga59b4ac713-20230505 Copyright (c) 2000-2023 the FFmpeg developers
        //  built with gcc 12.2.0 (crosstool-NG 1.25.0.152_89671bf)
        //  configuration: --prefix=/ffbuild/prefix --pkg-config-flags=--static --pkg-config=pkg-config --cross-prefix=x86_64-w64-mingw32- --arch=x86_64 --target-os=mingw32 --enable-gpl --enable-version3 --disable-debug --enable-shared --disable-static --disable-w32threads --enable-pthreads --enable-iconv --enable-libxml2 --enable-zlib --enable-libfreetype --enable-libfribidi --enable-gmp --enable-lzma --enable-fontconfig --enable-libvorbis --enable-opencl --disable-libpulse --enable-libvmaf --disable-libxcb --disable-xlib --enable-amf --enable-libaom --enable-libaribb24 --enable-avisynth --enable-chromaprint --enable-libdav1d --enable-libdavs2 --disable-libfdk-aac --enable-ffnvcodec --enable-cuda-llvm --enable-frei0r --enable-libgme --enable-libkvazaar --enable-libass --enable-libbluray --enable-libjxl --enable-libmp3lame --enable-libopus --enable-librist --enable-libssh --enable-libtheora --enable-libvpx --enable-libwebp --enable-lv2 --disable-libmfx --enable-libvpl --enable-openal --enable-libopencore-amrnb --enable-libopencore-amrwb --enable-libopenh264 --enable-libopenjpeg --enable-libopenmpt --enable-librav1e --enable-librubberband --enable-schannel --enable-sdl2 --enable-libsoxr --enable-libsrt --enable-libsvtav1 --enable-libtwolame --enable-libuavs3d --disable-libdrm --disable-vaapi --enable-libvidstab --enable-vulkan --enable-libshaderc --enable-libplacebo --enable-libx264 --enable-libx265 --enable-libxavs2 --enable-libxvid --enable-libzimg --enable-libzvbi --extra-cflags=-DLIBTWOLAME_STATIC --extra-cxxflags= --extra-ldflags=-pthread --extra-ldexeflags= --extra-libs=-lgomp --extra-version=20230505
        //  libavutil      58.  7.100 / 58.  7.100
        //  libavcodec     60. 10.100 / 60. 10.100
        //  libavformat    60.  5.100 / 60.  5.100
        //  libavdevice    60.  2.100 / 60.  2.100
        //  libavfilter     9.  7.100 /  9.  7.100
        //  libswscale      7.  2.100 /  7.  2.100
        //  libswresample   4. 11.100 /  4. 11.100
        //  libpostproc    57.  2.100 / 57.  2.100
        //[dshow @ 00000252e9b97e40] "Integrated Webcam" (video)
        //[dshow @ 00000252e9b97e40]   Alternative name "@device_pnp_\\?\usb#vid_0c45&pid_6a09&mi_00#6&127cc57d&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\global"
        //[dshow @ 00000252e9b97e40] "screen-capture-recorder" (video)
        //[dshow @ 00000252e9b97e40]   Alternative name "@device_sw_{860BB310-5D01-11D0-BD3B-00A0C911CE86}\{4EA69364-2C8A-4AE6-A561-56E4B5044439}"
        //[dshow @ 00000252e9b97e40] "OBS Virtual Camera" (none)
        //[dshow @ 00000252e9b97e40]   Alternative name "@device_sw_{860BB310-5D01-11D0-BD3B-00A0C911CE86}\{A3FCE0F5-3493-419F-958A-ABA1250EC20B}"
        //[dshow @ 00000252e9b97e40] "Microphone Array (Intel® Smart Sound Technology for Digital Microphones)" (audio)
        //[dshow @ 00000252e9b97e40]   Alternative name "@device_cm_{33D9A762-90C8-11D0-BD43-00A0C911CE86}\wave_{EC8DD06B-CF20-455D-A80E-F56B4BD1D8AE}"
        //[dshow @ 00000252e9b97e40] "virtual-audio-capturer" (audio)
        //[dshow @ 00000252e9b97e40]   Alternative name "@device_sw_{33D9A762-90C8-11D0-BD43-00A0C911CE86}\{8E146464-DB61-4309-AFA1-3578E927E935}"
        //[dshow @ 00000252e9b97e40] "Headset (HUAWEI FreeBuds 5i Hands-Free AG Audio)" (audio)
        //[dshow @ 00000252e9b97e40]   Alternative name "@device_cm_{33D9A762-90C8-11D0-BD43-00A0C911CE86}\wave_{8F9667CC-771C-44EE-BF62-9C209AEEF5B5}"
        //dummy: Immediate exit requested
        //
        //        Yukarıdaki çıktıyı parse ederek şöyle bir çıktı elde etmeliyiz:
        //         Id  : @device_pnp_\\?\usb#vid_0c45&pid_6a09&mi_00#6&127cc57d&0&0000#{65e8773d-8f56-11d0-a3b9-00a0c9223196}\global
        //            Name: Integrated Webcam
        //            Type: Video
        //
        //            Id  : @device_sw_{860BB310-5D01-11D0-BD3B-00A0C911CE86}\{4EA69364-2C8A-4AE6-A561-56E4B5044439}
        //            Name: screen-capture-recorder
        //            Type: Video
        //
        //            Id  : @device_sw_{860BB310-5D01-11D0-BD3B-00A0C911CE86}\{A3FCE0F5-3493-419F-958A-ABA1250EC20B}
        //            Name: OBS Virtual Camera
        //            Type: None
        //
        //            Id  : @device_cm_{33D9A762-90C8-11D0-BD43-00A0C911CE86}\wave_{EC8DD06B-CF20-455D-A80E-F56B4BD1D8AE}
        //            Name: Microphone Array (Intel® Smart Sound Technology for Digital Microphones)
        //            Type: Audio
        //
        //            Id  : @device_sw_{33D9A762-90C8-11D0-BD43-00A0C911CE86}\{8E146464-DB61-4309-AFA1-3578E927E935}
        //            Name: virtual-audio-capturer
        //            Type: Audio
        //
        //            Id  : @device_cm_{33D9A762-90C8-11D0-BD43-00A0C911CE86}\wave_{8F9667CC-771C-44EE-BF62-9C209AEEF5B5}
        //            Name: Headset (HUAWEI FreeBuds 5i Hands-Free AG Audio)
        //            Type: Audio
        public static List<Device> ParseFFmpegOutput(string ffmpegOutput)
        {
            List<Device> devices = new List<Device>();

            // Regex to match the device lines from FFmpeg output
            string pattern = @"""(.*)"" \((.*)\)\s*.*Alternative name ""(.*)""";
            var matches = Regex.Matches(ffmpegOutput, pattern);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    devices.Add(new Device
                    {
                        Id = match.Groups[3].Value,
                        Name = match.Groups[1].Value,
                        Type = //parse enum
                        match.Groups[2].Value switch
                        {
                            "video" => DeviceType.Video,
                            "audio" => DeviceType.Audio,
                            "none" => DeviceType.None,
                            _ => DeviceType.Unknown,
                        }
                    });
                }
            }

            return devices;
        }

        public static List<Device> GetAllDevicesWithFFmpeg(string ffmpegPath)
        {
            var str = FBCHelper.RunFFMpegCommand(ffmpegPath, "-list_devices true -f dshow -i dummy");


            return ParseFFmpegOutput(str);
        }
    }

}
