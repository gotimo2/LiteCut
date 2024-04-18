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
        private TimeSpan startTime;
        private TimeSpan endTime;
        private bool mergeAudio;

        public Compression(string inputFile, string outputFile, int targetFileSizeMB, TimeSpan startTime, TimeSpan endTime, bool mergeAudio)
        {
            this.inputFilePath = inputFile;
            this.outputFilePath = outputFile;
            this.targetFileSizeMB = targetFileSizeMB;
            this.startTime = startTime;
            this.endTime = endTime;
            this.mergeAudio = mergeAudio;
        }

        public static async Task<IMediaAnalysis> GetVideoInfoAsync(string inputFilePath)
        {
            var videoInfo = await FFProbe.AnalyseAsync(inputFilePath);
            return videoInfo;
        }

        public async Task CompressVideo()
        {

            double targetFileSizeBytes = targetFileSizeMB * 1024;
            var videoInfo = await FFProbe.AnalyseAsync(inputFilePath);
            double durationSeconds = endTime.TotalSeconds - startTime.TotalSeconds;
            int targetBitrate = (int)(targetFileSizeBytes * 7 / durationSeconds);

            Action<double>? compressionProgressAction = new Action<double>(p =>
            {
                Console.WriteLine("progress: " + p);
                CompressionProgress?.Invoke(this, p);
            });

            await FFMpegArguments.FromFileInput(inputFilePath).OutputToFile(outputFilePath, true, options =>
            {
                if (mergeAudio)
                {
                    options.WithCustomArgument("-c:v copy -c:a aac -b:a 160k -ac 2 -filter_complex amerge=inputs=2");
                }
                options.UsingMultithreading(true);
                options.WithAudioBitrate(AudioQuality.Normal);
                options.WithSpeedPreset(Speed.VeryFast);
                options.WithVideoBitrate(targetBitrate);
                options.WithVideoCodec(VideoCodec.LibX264);
                options.WithDuration(TimeSpan.FromSeconds(durationSeconds));
                options.Seek(startTime);
                options.EndSeek(endTime);

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
