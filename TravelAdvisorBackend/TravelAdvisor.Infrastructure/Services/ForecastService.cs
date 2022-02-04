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

        readonly string apiKey = "9efd37d819022017f01553c97b2c9796";
        readonly string language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        public async Task<List<WeatherDate>> GetWateherByCityName(string cityName)
        {
            HttpClient httpClient = new HttpClient();

          

            var uri = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric&lang={language}&appid={apiKey}";
            var response = await httpClient.GetAsync(uri);

            var stringResult = await response.Content.ReadAsStringAsync();

            WeatherApiData obj = JsonConvert.DeserializeObject<WeatherApiData>(stringResult);
            List<WeatherDate> myForecastList = new List<WeatherDate>();
            
            foreach (var item in obj.list)
            {

                myForecastList.Add(new WeatherDate
                {
                    Temperature = Math.Round(item.main.temp),
                    DateofForecast = item.dt_txt,
                        Humidity = item.main.humidity,
                    WindSpeed = item.wind.speed,
                  
                    

                }
                ); 
                

            }

           
            return myForecastList;
            
        }
      
    }
}
