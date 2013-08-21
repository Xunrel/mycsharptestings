using System;
using System.Windows.Input;

namespace busitec.BuildChecker
{
    public class RelayCommand : ICommand
    {
        private readonly Action _onExecute;
        private readonly Func<bool> _checkExecutable;

        /// <summary>
        /// Creates a RelayCommand which is always available.
        /// </summary>
        /// <param name="onExecute">The action to execute.</param>
        public RelayCommand(Action onExecute)
        {
            _onExecute = onExecute;
            _checkExecutable = () => true;
        }

        /// <summary>
        /// Creates a relayCommand which will be check if the action is available before executing it.
        /// </summary>
        /// <param name="onExecute">The action to execute.</param>
        /// <param name="checkExecutable">The condition whether the action is available.</param>
        public RelayCommand(Action onExecute, Func<bool> checkExecutable)
        {
            _onExecute = onExecute;
            _checkExecutable = checkExecutable;
        }

        /// <summary>
        /// Defines the method that checks whether the action can be executed in its current state.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            var action = _checkExecutable;
            return action == null || action();
        }

        /// <summary>
        /// Defines the method to executed when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var action = _onExecute;
            if (action != null)
            {
                action();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}