using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Services
{
    public class ForecastService : IForecast
    {
        //public async Task<CurrentWeateher> GetCurrentWateherByCityName(string cityName)
        //{
        //    HttpClient httpClient = new HttpClient();
            

        //    string path = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric&lang=uk&appid=6f1369d9886064a1ff9c1b784a4c93cb";
        
        //    var response = await httpClient.GetAsync(path);

        //    var stringResult = await response.Content.ReadAsStringAsync();

        //    CurrentWeatherApiData currentWeatherResult = JsonConvert.DeserializeObject<CurrentWeatherApiData>(stringResult);
        //    CurrentWeateher myForecast = new CurrentWeateher();

        //    myForecast.Temperature = Math.Round(currentWeatherResult.main.temp);
        //    myForecast.Humidity = currentWeatherResult.main.humidity;
        //    myForecast.WindSpeed = currentWeatherResult.wind.speed; 

            
            
    
        //    return myForecast;
        //}

        public async Task<List<WeatherDate>> GetWateherByCityName(string cityName)
        {
            HttpClient httpClient = new HttpClient();
            const int hourNumber = 18;
            string path = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&lang=uk&appid=6f1369d9886064a1ff9c1b784a4c93cb";
            var response = await httpClient.GetAsync(path);

            var stringResult = await response.Content.ReadAsStringAsync();

            WeatherApiData obj = JsonConvert.DeserializeObject<WeatherApiData>(stringResult);
            List<WeatherDate> myForecastList = new List<WeatherDate>();
            
            foreach (var item in obj.list)
            {
                if (DateTime.Parse(item.dt_txt).Hour == hourNumber)
                {
                    myForecastList.Add(new WeatherDate
                    {
                        Temperature = Math.Round(item.main.temp),
                        DateofForecast = item.dt_txt,
                        Humidity= item.main.humidity,
                        WindSpeed = item.wind.speed    
                        
                    }
                    );
                }

            }
            return myForecastList;
            
        }
    }
}
