using FFMpegCore;

namespace LiteCut
{
    public partial class LiteCut : Form
    {
        string initialFilePath = "";
        public LiteCut(string[] args)
        {
            //check if FFMpeg is installed and prompt to install it if not
            try
            {
                FFMpeg.GetCodecs();
            }
            catch
            {
                DialogResult result = MessageBox.Show("FFMpeg is not installed, or has no codecs. Do you want to try to install it now?", "error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var installResult = InstallFFmpeg.installFFmpeg();
                    if (installResult == true)
                    {
                        MessageBox.Show("Successfully installed FFMpeg!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to install FFMpeg.");
                    }
                }
            }

            //if opened via file association, get initial file path from arguments
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

            //associate a file path
            try
            {
                FileAssociation.AssociateFile();
            }
            catch { } //it's really not too bad if it doesn't work.
        }

        private void PickFileButton_Click(object sender, EventArgs e)
        {
            var result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PickFile(FileDialog.FileName);
            }
        }

        private async void PickFile(string path)
        {
            try
            {
                var info = await FFProbe.AnalyseAsync(path); //fetch duration of video and set the values of the time boxes
                StartTimeBox.Invoke(() =>
                {
                    StartTimeBox.Value = 0;
                    EndTimeBox.Maximum = (decimal)info.Duration.TotalSeconds;
                    EndTimeBox.Value = (decimal)info.Duration.TotalSeconds;
                    FileNameTextBox.Text = path;
                });
            }
            catch
            {
                MessageBox.Show("Cannot retrieve video info. Please check the provided video, and if you have installed FFmpeg.");
            }
        }

        //start a compression task
        private async void CompressButton_Click(object sender, EventArgs e)
        {
            var size = (int)MbBox.Value;
            var fileName = FileNameTextBox.Text;
            var startTime = TimeSpan.FromSeconds((double)StartTimeBox.Value);
            var endTime = TimeSpan.FromSeconds((double)EndTimeBox.Value);
            var mergeAudio = MergeAudioTrackCheckBox.Checked;

            CompressionTask compression = new CompressionTask(fileName, fileName + "_compressed.mp4", size, startTime, endTime, mergeAudio );
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
                MessageBox.Show($"File not found: {ex.FileName}", "Error");
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

        //disable form controls during compression
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

        //these methods stop you from setting your end before your start
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