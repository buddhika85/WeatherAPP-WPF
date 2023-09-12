using System.ComponentModel;
using WeatherAPP.Model;

namespace WeatherAPP.ViewModel
{
    public class WeatherWindowViewModel : INotifyPropertyChanged
    {
        private string? _query;
        public string? Query
        {
            get => _query;
            set
            {
                _query = value;
                // send notifications to listeners in XAML
                // listeners like text boxes, labels...etc
                OnPropertyChanged(nameof(Query));
            }
        }

        private CurrentCondition _currentCondition = null!;

        public CurrentCondition CurrentCondition
        {
            get => _currentCondition;
            set
            {
                _currentCondition = value;
                OnPropertyChanged(nameof(CurrentCondition));
            }
        }

        private City _selectedCity = null!;

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
