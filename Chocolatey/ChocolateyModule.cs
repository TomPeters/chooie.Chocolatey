using System;
using Chooie.Interface.PackageManager;
using Chooie.Interface.TinyIoC;

namespace Chooie.Chocolatey
{
    public class ChocolateyModule : IPackageManagerModule
    {
        public Type PackageManagerType
        {
            get { return typeof (Chocolatey); }
        }

        public void RegisterDependencies(TinyIoCContainer container)
        {
            container.Register<PackageListRetriver>();
            container.Register<PackageInstaller>();
            container.Register<PackageUninstaller>();
        }
    }
}
