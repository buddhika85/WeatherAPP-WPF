# WeatherAPP-WPF
Weather Information Application - Built with WPF .NET 6 using MVVM architecture.

Model-View-ViewModel architecture is implemented with the below techniques.

* Uses Data Binding
* Uses INofity Property Changed Interface implementations for View-ViewModel-Model communications.
* Uses ICommand Interface implementations - Instead click events for buttons...etc
* Uses ObservableCollection<T> - Sends notifications to View when the list of data changes.
* Uses IValueConverter - To show presentable data in the view, and to convert view inputs to data that is accepted by the model.

![New](https://github.com/buddhika85/WeatherAPP-WPF/blob/main/WeatherWindow.png?raw=true)

How the App works?

* As per the above screenshot, the user can type a string and search for a city.
* Then the user can select one of the cities from the list view.
* The selected cities' weather information will be displayed (temperature, cloudy or sunny, currently raining or not).

Consumes trial API (HTTP Service calls) - https://developer.accuweather.com/ - to retrieve weather information for the selected city.
