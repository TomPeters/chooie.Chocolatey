using System.Collections.Generic;
using System.Linq;
using Chooie.Interface;
using Chooie.Interface.Helpers;

namespace Chooie.Chocolatey
{
    public class PackageListRetriver
    {
        private readonly IShellCommandRunner _shellCommandRunner;

        public PackageListRetriver(IShellCommandRunner shellCommandRunner)
        {
            _shellCommandRunner = shellCommandRunner;
        }

        private const string Url = @"http://chocolatey.org/api/v2";
        public IEnumerable<Package> Packages
        {
            get
            {
                return ConvertCommandOutputToPackages(_shellCommandRunner.RunCommand("clist -source " + Url));
            }
        }

        private IEnumerable<Package> ConvertCommandOutputToPackages(IEnumerable<string> output)
        {
            return output.Select(ConvertPackageLineToPackage).Where(p => p != null);
        }

        private Package ConvertPackageLineToPackage(string packageLine)
        {
            string[] words = packageLine.Split(' ');
            if (words.Length != 2) return null;
            return new Package()
                {
                    Name = words[0],
                    CurrentVersion = words[1]
                };
        }
    }
}
