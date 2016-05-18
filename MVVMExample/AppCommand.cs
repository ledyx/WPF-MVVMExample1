using System;
using System.Windows.Input;

namespace MVVMExample
{
    class AppCommand : ICommand
    {
        public AppCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        Action<object> execute;
        Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
