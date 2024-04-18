using FFMpegCore;
using FFMpegCore.Enums;

namespace TighteningStrap
{
    public partial class LiteCut : Form
    {
        public LiteCut()
        {
            InitializeComponent();
        }

        private void PickFileButton_Click(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FileNameTextBox.Text = FileDialog.FileName;
            }
        }

        private async Task CompressVideo(string inputFile, string outputFile, int targetFileSizeMB)
        {
            // Calculate an approximate bitrate based on the target file size
            double targetFileSizeBytes = targetFileSizeMB * 1024 * 1024;
            var videoInfo = await FFProbe.AnalyseAsync(inputFile);
            double durationSeconds = videoInfo.Duration.TotalSeconds;
            int targetBitrate = (int)(targetFileSizeBytes * 8 / durationSeconds);

            // Two-pass encoding for better quality control
            string pass1Args = $"-y -i {inputFile} -c:v libx265 -b:v {targetBitrate}k -pass 1 -f null NUL";
            string pass2Args = $"-y -i {inputFile} -c:v libx265 -b:v {targetBitrate}k -pass 2 {outputFile}";

            await FFMpegArguments.FromFileInput(inputFile).OutputToFile(outputFile, true, options => options.WithVideoCodec(VideoCodec.LibX265))
                                .ProcessAsynchronously();
        }
    }
}