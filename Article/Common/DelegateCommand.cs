using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Article.Common
{
    public class DelegateCommand : ICommand
    {
        private readonly Action commandExecuteAction;
        private readonly Func<bool> commandCanExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            commandExecuteAction = execute ?? throw new ArgumentNullException(nameof(execute));
            commandCanExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object parameter = null)
        {
            try
            {
                return commandCanExecute();
            }
            catch
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            try
            {
                commandExecuteAction();
            }
            catch
            {
                Debugger.Break();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> commandExecuteAction;
        private readonly Func<T, bool> commandCanExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> executeAction, Func<T, bool> canExecute = null)
        {
            commandExecuteAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            commandCanExecute = canExecute ?? (e => true);
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return commandCanExecute(ConvertParameterValue(parameter));
            }
            catch
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            try
            {
                commandExecuteAction(ConvertParameterValue(parameter));
            }
            catch
            {
                Debugger.Break();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private static T ConvertParameterValue(object parameter)
        {
            parameter = parameter is T ? parameter : Convert.ChangeType(parameter, typeof(T));
            return (T)parameter;
        }
    }
}
