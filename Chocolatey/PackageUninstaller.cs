using Chooie.Interface;
using Chooie.Interface.Helpers;

namespace Chooie.Chocolatey
{
    public class PackageUninstaller
    {
        private readonly IShellCommandRunner _shellCommandRunner;

        public PackageUninstaller(IShellCommandRunner shellCommandRunner)
        {
            _shellCommandRunner = shellCommandRunner;
        }

        public void UninstallPackage(Package package)
        {
            _shellCommandRunner.RunCommandWihLogging("cuninst " + package.Name);
        } 
    }
}
