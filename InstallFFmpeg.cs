using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCut
{
    public static class InstallFFmpeg
    {
        public static bool installFFmpeg()
        {
            try
            {
                var output = new StringBuilder();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"install ffmpeg",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
            return true;

        }
    }


}
