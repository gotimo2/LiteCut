namespace LiteCut
{
    public partial class LiteCut : Form
    {
        string initialFilePath = "";
        public LiteCut(string[] args)
        {   
            if (args.Length == 1)
            {
                if (File.Exists(args[0]))
                {
                    initialFilePath = args[0];
                }
            }
            InitializeComponent();
            if (!string.IsNullOrEmpty(initialFilePath))
            {
                PickFile(initialFilePath);
            }
        }

        private void PickFileButton_Click(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PickFile(FileNameTextBox.Text);
            }
        }

        private async void PickFile(string path)
        {
            try
            {
                var info = await Compression.GetVideoInfoAsync(path);
                StartTimeBox.Value = 0;
                EndTimeBox.Maximum = (decimal)info.Duration.TotalSeconds;
                EndTimeBox.Value = (decimal)info.Duration.TotalSeconds;
                FileNameTextBox.Text = FileDialog.FileName;
            }
            catch
            {
                MessageBox.Show("Cannot retrieve video info. please check the provided video.");
            }
        }

        private async void CompressButton_Click(object sender, EventArgs e)
        {
            var size = (int)MbBox.Value;
            var fileName = FileNameTextBox.Text;
            var startTime = TimeSpan.FromSeconds((double)StartTimeBox.Value);
            var endTime = TimeSpan.FromSeconds((double)EndTimeBox.Value);
            var mergeAudio = MergeAudioTrackCheckBox.Checked;

            Compression compression = new Compression(fileName, fileName + "_compressed.mp4", size, startTime, endTime, mergeAudio );
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

            ToggleFormControls(false);
            try
            {
                await compression.CompressVideo().ConfigureAwait(false);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"File not found: {ex.FileName}. if this isn't your video file, this error is likely because you haven't installed ffmpeg.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error compressing file: " + ex.Message, "Error");
            }
            MessageBox.Show("Compression done, file can be found under " + fileName + "_compressed.mp4");
            ToggleFormControls(true);

            ProgressBar.Invoke(new MethodInvoker(() =>
            {
                ProgressBar.Value = 0;
            }));

        }


        private void ToggleFormControls(bool enabled)
        {
            PickFileButton.Invoke(
                 new MethodInvoker(() =>
                 {
                     PickFileButton.Enabled = enabled;
                     MbBox.Enabled = enabled;
                     StartTimeBox.Enabled = enabled;
                     EndTimeBox.Enabled = enabled;
                 }
                )
          );
        }

        private void StartTimeBox_ValueChanged(object sender, EventArgs e)
        {
            EndTimeBox.Minimum = StartTimeBox.Value;
        }

        private void EndTimeBox_ValueChanged(object sender, EventArgs e)
        {
            StartTimeBox.Maximum = EndTimeBox.Value;
        }
    }
}