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
            if (IsDirectory)
            {
                if (IncludeSubDirectories)
                {
                    
                }
            }
            var result = CheckAssembly(AssemblyModel.PathToCheck);
        }

        private bool CheckAssembly(string filepath)
        {
            return AssemblyChecker.AssemblyChecker.IsAssemblyDebugBuild(filepath);
        }
    }
}