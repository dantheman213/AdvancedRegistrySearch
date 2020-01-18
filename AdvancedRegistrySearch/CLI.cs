using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedRegistrySearch
{
    class CLI
    {
        public static Process runCommand(string command)
        {
            Process proc = new Process();
            var info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.Arguments = "/C " + command;
            info.CreateNoWindow = true;
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            proc.StartInfo = info;
            proc.Start();

            return proc;
        }

        public static bool isRegeditRunning()
        {
            Process[] localAll = Process.GetProcesses();
            var proc = localAll.FirstOrDefault(x => x.ProcessName.ToLower().IndexOf("regedit") > -1);
            if (proc != null)
            {
                return true;
            }

            return false;
        }
    }
}
