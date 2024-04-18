using FFMpegCore;
using FFMpegCore.Enums;

namespace LiteCut
{
    internal class Compression
    {
        public async Task CompressVideo(string inputFile, string outputFile, int targetFileSizeMB, double startTime, double endTime)
        {
            // Calculate an approximate bitrate based on the target file size
            double targetFileSizeBytes = targetFileSizeMB * 1024 * 1024;
            var videoInfo = await FFProbe.AnalyseAsync(inputFile);
            double durationSeconds = videoInfo.Duration.TotalSeconds;
            int targetBitrate = (int)(targetFileSizeBytes * 8 / durationSeconds);

            // Two-pass encoding for better quality control

            await FFMpegArguments.FromFileInput(inputFile).OutputToFile(outputFile, true, options =>
            {
                options.WithVideoCodec(VideoCodec.LibX265);
                options.WithVideoBitrate(targetBitrate);
                options.WithDuration(TimeSpan.FromSeconds(durationSeconds));
                options.Seek(TimeSpan.FromSeconds(startTime));
                options.EndSeek(TimeSpan.FromSeconds(endTime));
            })
                                .ProcessAsynchronously();
        }
    }
}
