using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _12_pract
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> execute;

        public AsyncRelayCommand(Func<Task> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter) => await execute();

        public event EventHandler CanExecuteChanged;
    }
}
