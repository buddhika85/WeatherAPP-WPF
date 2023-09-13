using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPP.Model;

namespace WeatherAPP.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        // http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=API_KEY&q=Colom
        // http://dataservice.accuweather.com/currentconditions/v1/311399?apikey=API_KEY

        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string ApiKey = "put in your API key here";

        // 0 api key 1 query 
        public const string AutoCompleteEndPoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";

        // 1 api key 0 city key 
        public const string CurrentConditionsEndPoint = "currentconditions/v1/{0}?apikey={1}";

        public static async Task<List<City>?> GetCities(string query)
        {
            var url = $"{BaseUrl}{string.Format(AutoCompleteEndPoint, ApiKey, query)}";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<City>?>(json);
        }


        public static async Task<CurrentCondition?> GetCurrentCondition(string cityKey)
        {
            var url = $"{BaseUrl}{string.Format(CurrentConditionsEndPoint, cityKey, ApiKey)}";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<CurrentCondition>>(json);
            return list?.FirstOrDefault();
        }
    }
}
