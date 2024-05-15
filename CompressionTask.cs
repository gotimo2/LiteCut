using FFMpegCore;
using FFMpegCore.Enums;

namespace LiteCut
{
    internal class CompressionTask
    {
        public EventHandler<double>? CompressionProgress;

        public EventHandler<string>? CompressionError;

        public EventHandler<string>? CompressionOutput;

        private readonly string inputFilePath;
        private readonly string outputFilePath;
        private readonly int targetFileSizeMB;
        private readonly TimeSpan startTime;
        private readonly TimeSpan endTime;
        private readonly bool mergeAudio;

        public CompressionTask(string inputFilePath, string outputFilePath, int targetFileSizeMB, TimeSpan startTime, TimeSpan endTime, bool mergeAudio)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
            this.targetFileSizeMB = targetFileSizeMB;
            this.startTime = startTime;
            this.endTime = endTime;
            this.mergeAudio = mergeAudio;
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
                    options.WithCustomArgument($"-c:v copy -c:a aac -b:a 160k -ac 2 -filter_complex amerge=inputs={videoInfo.AudioStreams.Count}");
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
