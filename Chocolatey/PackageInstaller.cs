using System;
using System.Diagnostics;
using Chooie.Core;

namespace Chooie.Chocolatey
{
    public class PackageInstaller
    {
        public void InstallPackage(Package package)
        {
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C cinst " + package.Name;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Console.WriteLine("Running Command");
            p.Start();
            p.StandardOutput.ReadToEnd();
            p.WaitForExit();
        } 
    }
}