using System;
using System.Windows.Input;

namespace WeatherAPP.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherWindowViewModel ViewModel { get; set; }

        public SearchCommand(WeatherWindowViewModel viewModel)
        {
            ViewModel = viewModel;
        }


        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(parameter as string);
        }

        public void Execute(object? parameter)
        {
            // call a method on view model
            ViewModel.MakeQuery();
        }
    }
}
