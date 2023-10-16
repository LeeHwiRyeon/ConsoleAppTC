using System;
using System.Diagnostics;

namespace MiniGameTC {
    internal class GitCommand {
        public void CommitAndPush(string filePath, string message)
        {
            try {
                RunCommand("git", $"add {filePath}");
                RunCommand("git", $"commit -m \"{message}\"");
                RunCommand("git", "push");
                Console.WriteLine($"Successfully committed and pushed {filePath} with message: \"{message}\"");
            } catch (Exception ex) {
                Console.WriteLine($"Error in CommitAndPush: {ex.Message}");
            }
        }

        private void RunCommand(string command, string arguments)
        {
            var processStartInfo = new ProcessStartInfo {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new Process {
                StartInfo = processStartInfo
            };

            process.Start();
            process.StandardInput.WriteLine($"{command} {arguments}");
            process.StandardInput.WriteLine("exit");
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0) {
                string error = process.StandardError.ReadToEnd();
                throw new Exception($"Command failed with error: {error}");
            }
        }
    }
}