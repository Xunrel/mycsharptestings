using AssemblyChecker;
using busitec.BuildChecker.Models;

namespace busitec.BuildChecker.ViewModels
{
    public class AssemblyViewModel
    {
        public AssemblyModel AssemblyModel { get; set; }
        public bool IsDirectory { get; set; }
        public bool IncludeSubDirectories { get; set; }

        public void CheckAssemblies()
        {
            // TODO implement logic for directories, subdirectories and simple file check
        }

        private bool CheckAssembly(string filepath)
        {
            return AssemblyHelper.IsAssemblyDebugBuild(filepath);
        }
    }
}