using System.ComponentModel;

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
                OnPropertyChanged(nameof(Query));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
