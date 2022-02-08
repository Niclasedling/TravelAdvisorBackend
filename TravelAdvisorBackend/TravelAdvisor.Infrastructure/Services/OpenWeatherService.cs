using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Services
{
    public class OpenWeatherService: IOpenWeatherService
    {
        public OpenWeatherService()
        {
            _cache = new ConcurrentDictionary<string, Forecast>();
        }

        HttpClient httpClient = new HttpClient();
        readonly string apiKey = "24a715a5e9fd5ee19fc7a2dfcfb3affb"; // Your API Key

        // part of your event and cache code here
        private readonly ConcurrentDictionary<string, Forecast> _cache;

        public async Task<Forecast> GetForecastAsync(string City)
        {
            //part of cache code here
            //TODO kolla om vi har ett cachat värde för City
            var cachedForecast = GetCachedForecast(City);
            //TODO om cachen inte är null dvs det finns ett värde, returnera
            if (cachedForecast != null)
            {
              
                return cachedForecast;
            }

            //https://openweathermap.org/current
            var language = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?q={City}&units=metric&lang={language}&appid={apiKey}";

            Forecast forecast = await ReadWebApiAsync(uri);

            //part of event and cache code here
            //generate an event with different message if cached data
       
            return InsertCachedForecast(City, forecast);

        }
    

        private Forecast GetCachedForecast(string cacheKey)
        {
            var cacheKeyWithTimestamp = GetCacheKeyWithTimestamp(cacheKey, DateTime.Now);
            //TODO om inte cachekeyn finns i cachen, returnerna null
            if (!_cache.ContainsKey(cacheKeyWithTimestamp))
                return null;

            //TODO om cachekeyn finns i cachen, hämta och kolla om den fortfarande är valid.
            if (_cache.TryGetValue(cacheKeyWithTimestamp, out var cache))
            {
                return cache;
            }
            return null;
        }

        private Forecast InsertCachedForecast(string cacheKey, Forecast forecast)
        {
            _cache.GetOrAdd(GetCacheKeyWithTimestamp(cacheKey, DateTime.Now), forecast);
            return forecast;
        }

        private string GetCacheKeyWithTimestamp(string cacheKey, DateTime dateTime)
        {
            return $"{cacheKey}-{dateTime:yyy-MM-dd HH:mm}";
        }


        private async Task<Forecast> ReadWebApiAsync(string uri)
        {
            // part of your read web api code here
            using var client = new HttpClient();
            var response = await client.GetFromJsonAsync<WeatherApiData>(uri);
            if (response == null)
                return null;

            // part of your data transformation to Forecast here
            return new Forecast
            {
                City = response.city.name,
                Items = response.list.Select(x => new ForecastItem
                {
                    DateTime = UnixTimeStampToDateTime(x.dt),
                    Description = x.weather.FirstOrDefault()?.description.FirstCharToUpper(),
                    Icon = x.weather.FirstOrDefault()?.icon,
                    Temperature = x.main.temp,
                    WindSpeed = x.wind.speed,
                    Humidity = x.main.humidity,
                    Latitude = response.city.coord.lat,
                    Longitude = response.city.coord.lon,
                }).ToList()
            };
        }
        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
        public static class StringExtensions
        {
            public static string FirstCharToUpper(this string input) =>
                input switch
                {
                    null => throw new ArgumentNullException(nameof(input)),
                    "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                    _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
                };
        }
}
