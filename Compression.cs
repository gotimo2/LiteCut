using FFMpegCore;
using FFMpegCore.Enums;

namespace LiteCut
{
    internal class Compression
    {
        public EventHandler<double>? CompressionProgress;

        public EventHandler<string>? CompressionError;

        public EventHandler<string>? CompressionOutput;

        private string inputFilePath;
        private string outputFilePath;
        private int targetFileSizeMB;
        private double startTime;
        private double endTime;

        public Compression(string inputFile, string outputFile, int targetFileSizeMB, double startTime, double endTime)
        {
            this.inputFilePath = inputFile;
            this.outputFilePath = outputFile;
            this.targetFileSizeMB = targetFileSizeMB;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public async Task<IMediaAnalysis> GetVideoInfoAsync()
        {
            var videoInfo = await FFProbe.AnalyseAsync(inputFilePath);
            return videoInfo;
        }

        public async Task CompressVideo()
        {
            // Calculate an approximate bitrate based on the target file size
            double targetFileSizeBytes = targetFileSizeMB * 1024 * 1024;
            var videoInfo = await FFProbe.AnalyseAsync(inputFilePath);
            double durationSeconds = videoInfo.Duration.TotalSeconds;
            int targetBitrate = (int)(targetFileSizeBytes * 8 / durationSeconds);

            // Two-pass encoding for better quality control

            Action<double>? compressionProgressAction = new Action<double>(p =>
            {
                Console.WriteLine("progress: " + p);
                CompressionProgress?.Invoke(this, p);
            });

            await FFMpegArguments.FromFileInput(inputFilePath).OutputToFile(outputFilePath, true, options =>
            {
                options.WithVideoCodec(VideoCodec.LibX265);
                options.WithVideoBitrate(targetBitrate);
                options.WithDuration(TimeSpan.FromSeconds(durationSeconds));
                options.Seek(TimeSpan.FromSeconds(startTime));
                options.EndSeek(TimeSpan.FromSeconds(endTime));
            })
            .NotifyOnProgress(compressionProgressAction, TimeSpan.FromSeconds(durationSeconds))
            .NotifyOnOutput((output) =>
            {
                CompressionOutput?.Invoke(this, output);
            })
            .NotifyOnError((error) =>
            {
                CompressionError?.Invoke(this, error);
            })
           .ProcessAsynchronously();
        }
    }
}
