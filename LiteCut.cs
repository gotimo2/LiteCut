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
            var size = (int)MbBox.Value;
            var fileName = FileNameTextBox.Text;
            var startTime = TimeSpan.FromSeconds((double) StartTimeBox.Value);
            var endTime = TimeSpan.FromSeconds((double) EndTimeBox.Value);

            Compression compression = new Compression(fileName , fileName + "_compressed.mp4", size , 0D, 90D);
            compression.CompressionProgress += (sender, progress) =>
            {
                if (ProgressBar.InvokeRequired)
                {
                    ProgressBar.Invoke(new MethodInvoker(() =>
                    {
                        ProgressBar.Value = (int)progress;
                    }));
                }

            };
            await compression.CompressVideo().ConfigureAwait(false);
        }

    }
}