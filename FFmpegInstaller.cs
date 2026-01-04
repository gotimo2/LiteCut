using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LiteCut
{
    public static class FFmpegInstaller
    {
        public static bool InstallFFmpeg()
        {
            try
            {

                ProcessStartInfo startInfo = new()
                {
                    FileName = "winget",
                    Arguments = "install Gyan.FFmpeg -h",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using Process process = new();
                process.StartInfo = startInfo;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();

                // Refresh this process' PATH from the registry so newly-installed executables are found without restarting
                RefreshProcessPathFromRegistry();

                // Quick verification: try running `ffmpeg -version`
                if (CanRunFFmpeg())
                {
                    return true;
                }

                var ffmpegInstallationDirectory = FindFFmpeg();

                if (!string.IsNullOrEmpty(ffmpegInstallationDirectory))
                {
                    string dir = Path.GetDirectoryName(ffmpegInstallationDirectory);
                    string current = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process) ?? string.Empty;
                    Environment.SetEnvironmentVariable("PATH", dir + ";" + current, EnvironmentVariableTarget.Process);

                    if (!CanRunFFmpeg())
                    {
                        MessageBox.Show("FFmpeg was not directly accessbile. You may need to restart LiteCut or your computer.");
                        return true; // installation likely succeeded, but process PATH wasn't picked up by all mechanisms
                    }
                }
                else
                {
                    MessageBox.Show("FFmpeg was installed but could not be located. Try restarting Litecut or your computer.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }

            return false;
        }

        private static void RefreshProcessPathFromRegistry()
        {
            try
            {
                const string systemEnvKey = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
                string systemPath = Registry.LocalMachine.OpenSubKey(systemEnvKey)?.GetValue("Path") as string ?? string.Empty;
                string userPath = Registry.CurrentUser.OpenSubKey("Environment")?.GetValue("Path") as string ?? string.Empty;

                string merged;
                if (string.IsNullOrEmpty(systemPath)) merged = userPath;
                else if (string.IsNullOrEmpty(userPath)) merged = systemPath;
                else merged = systemPath + ";" + userPath;

                if (!string.IsNullOrEmpty(merged))
                {
                    Environment.SetEnvironmentVariable("PATH", merged, EnvironmentVariableTarget.Process);
                }
            }
            catch
            {
                // Non-fatal — leave process PATH unchanged if registry read fails.
            }
        }

        private static bool CanRunFFmpeg()
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = "ffmpeg",
                    Arguments = "-version",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,       
                    CreateNoWindow = true
                };

                using Process p = Process.Start(psi);
                if (p is null)
                {
                    return false;
                }
                p.WaitForExit(3000);
                return p.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }


        private static string FindFFmpeg()
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = "where",
                    Arguments = "ffmpeg",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using Process p = Process.Start(psi);
                if (p == null) return string.Empty;

                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit(2000);

                if (string.IsNullOrWhiteSpace(output)) return string.Empty;

                var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var path = line.Trim();
                    if (File.Exists(path)) return path;
                }
            }
            catch
            {
            }

            return string.Empty;
        }
    }
}
