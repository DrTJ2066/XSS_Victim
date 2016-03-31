using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RoyaMVC_EN
{
    public static class ShellCommands
    {
        public static string ExecuteCommand(string command, string args) {
            var info = new ProcessStartInfo(command, args);
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.RedirectStandardOutput = true;

            var p = Process.Start(info);

            p.WaitForExit();
            var res = p.StandardOutput.ReadToEnd();

            return res;
        }
    }
}
