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
        public MediaManager(string folderPath, string videoLink) => Convert(folderPath, videoLink);

        private void Convert(string folderPath, string videoLink)
        {
            var video = GetVideoLink(videoLink);
            ConvertBytes(folderPath, video);
            var inputFile = InputFile(folderPath, video);
            var outputFile = OutputFile(folderPath, video);
            ConvertVideo(inputFile, outputFile);
        }

        private YouTubeVideo GetVideoLink(string vidoeLink) => YouTube.Default.GetVideo(vidoeLink);

        private void ConvertBytes(string folderPath, YouTubeVideo videoLink) => File.WriteAllBytes($"{folderPath}/{videoLink.FullName}", videoLink.GetBytes());

        private MediaFile InputFile(string folderPath, YouTubeVideo videoLink) => new MediaFile { Filename = $"{folderPath}/{videoLink.FullName}" };

        private MediaFile OutputFile(string folderPath, YouTubeVideo videoLink) => new MediaFile { Filename = $"{folderPath}/{videoLink.FullName}.mp3" };

        private void ConvertVideo(MediaFile inputFile, MediaFile outputFile)
        {
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }
        }
    }
}
