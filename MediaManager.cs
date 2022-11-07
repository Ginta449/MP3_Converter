using MediaToolkit;
using MediaToolkit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace MP3_Converter
{
    public class MediaManager
    {
        public MediaManager(string folderPath, string videoLink)
        {
            Convert(folderPath, videoLink);
        }
        private void Convert(string folderPath, string videoLink)
        {
            var video = YouTube.Default.GetVideo(videoLink);
            File.WriteAllText(folderPath + "/" + video.FullName.Replace("mp4", "mp3"), video.FullName);
            var inputFile = InputOutputFile(folderPath, video, FileType.InputFile);
            var outputFile = InputOutputFile(folderPath, video, FileType.OutputFile);
            ConvertVideo(inputFile, outputFile);
        }

        private MediaFile InputOutputFile(string folderPath, YouTubeVideo videoLink, FileType fileType) =>
           fileType == FileType.InputFile ? new MediaFile { Filename = folderPath + "/" + videoLink.FullName.Replace("mp4", "mp3") } : new MediaFile { Filename = folderPath + "/" + videoLink.FullName.Replace("mp4", "mp3") };

        private void ConvertVideo(MediaFile inputFile, MediaFile outputFile)
        {
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }
        }

        enum FileType
        {
            InputFile,
            OutputFile
        }
    }
}
