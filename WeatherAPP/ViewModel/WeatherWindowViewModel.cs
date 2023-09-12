using System.ComponentModel;
using System.Linq;
using WeatherAPP.Model;
using WeatherAPP.ViewModel.Commands;
using WeatherAPP.ViewModel.Helpers;

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

        // Command property 
        public SearchCommand SearchCommand { get; set; }



        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion 

        public WeatherWindowViewModel()
        {
            SearchCommand = new SearchCommand(this);

            //SelectedCity = new City
            //{
            //    LocalizedName = "Test"
            //};

            CurrentCondition = new CurrentCondition
            {
                WeatherText = "Partly Cloudy",
                Temperature = new Temperature
                {
                    Metric = new Units
                    {
                        Value = 21
                    }
                }
            };
        }

        public async void MakeQuery()
        {
            if (string.IsNullOrWhiteSpace(Query))
                return;

            // calling model
            var cities = await AccuWeatherHelper.GetCities(Query);

            if (cities is not null && cities.Any())
                SelectedCity = cities[0];
        }
    }
}
