using Chooie.Interface;
using Chooie.Interface.Helpers;

namespace Chooie.Chocolatey
{
    public class PackageInstaller
    {
        private readonly IShellCommandRunner _shellCommandRunner;

        public PackageInstaller(IShellCommandRunner shellCommandRunner)
        {
            _shellCommandRunner = shellCommandRunner;
        }

        public void InstallPackage(Package package)
        {
            _shellCommandRunner.RunCommandWihLogging("cinst " + package.Name);
        } 
    }
}