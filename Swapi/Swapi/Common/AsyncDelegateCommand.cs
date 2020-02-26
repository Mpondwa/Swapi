using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swapi.Common
{
    public class AsyncDelegateCommand : ICommand
    {
        private readonly Func<object, Task> _asyncAction;

        private readonly Func<object, bool> _canExecute;

        public AsyncDelegateCommand(Func<object, Task> asyncAction)
            : this(asyncAction, null)
        {

        }

        public AsyncDelegateCommand(Func<object, Task> asyncAction, Func<object, bool> canExecute)
        {
            _asyncAction = asyncAction;
            _canExecute = canExecute;
        }

        public async void Execute(object parameter)
        {
            await AsyncExecute(parameter);
        }

        public async Task AsyncExecute(object parameter)
        {
            await _asyncAction(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
