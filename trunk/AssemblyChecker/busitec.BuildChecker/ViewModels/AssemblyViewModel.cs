using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AssemblyChecker;
using busitec.BuildChecker.Annotations;
using busitec.BuildChecker.Models;

namespace busitec.BuildChecker.ViewModels
{
    public class AssemblyViewModel : INotifyPropertyChanged
    {
        private bool _isDirectory;

        public ICommand CheckAssembly { get; private set; }

        public AssemblyModel AssemblyModel { get; set; }
        public bool IncludeSubDirectories { get; set; }
        public bool IsDirectory
        {
            get { return _isDirectory; }
            set
            {
                _isDirectory = value;
                OnPropertyChanged();
            }
        }

        public AssemblyViewModel()
        {
            AssemblyModel = new AssemblyModel();
            CheckAssembly = new RelayCommand(() => CheckFile(AssemblyModel.PathToCheck));
        }

        public void CheckDirectory()
        {
            // TODO implement logic for directories, subdirectories and simple file check
        }

        public bool CheckFile(string filepath)
        {
            return AssemblyHelper.IsAssemblyDebugBuild(filepath);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}