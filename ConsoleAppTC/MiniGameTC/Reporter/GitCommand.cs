using System;
using System.Diagnostics;

namespace MiniGameTC {
    internal class GitCommand {
        public void CommitAndPush(string filePath, string message)
        {
            try {
                RunCommand($"git add {filePath}");
                RunCommand($"git commit -m \"{message}\"");
                RunCommand("git push");
            } catch (Exception ex) {
                Console.WriteLine($"Error while executing Git command: {ex.Message}");
            }
        }

        private void RunCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command) {
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new Process {
                StartInfo = processInfo
            };

            process.Start();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrEmpty(error)) {
                throw new Exception($"Error while executing command '{command}': {error}");
            }
        }
    }
}