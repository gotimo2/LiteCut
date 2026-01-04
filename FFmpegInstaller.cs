using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCut
{
    public static class FFmpegInstaller
    {
        public static bool InstallFFmpeg()
        {
            try
            {
                var output = new StringBuilder();
                ProcessStartInfo startInfo = new()
                {
                    FileName = "winget",
                    Arguments = $"install ffmpeg",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = false
                };

                using Process process = new();
                process.StartInfo = startInfo;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
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
