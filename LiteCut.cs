using FFMpegCore;
using FFMpegCore.Enums;
using LiteCut;

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

        private async void CompressButton_Click(object sender, EventArgs e)
        {
            Compression compression = new Compression(FileNameTextBox.Text, FileNameTextBox.Text + "_output.mp4", 25, 0D, 90D);
            compression.CompressionProgress += async (progress) =>
            {
                ProgressBar.Value = (int)progress;
            };
            await compression.CompressVideo().ConfigureAwait(false);
        }
    }
}