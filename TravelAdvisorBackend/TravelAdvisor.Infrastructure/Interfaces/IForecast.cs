using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Infrastructure.Interfaces
{
    public interface IForecast
    {
         Task<List<WeatherDate>> GetWateherByCityName(string cityName);  
         Task<CurrentWeateher> GetCurrentWateherByCityName(string cityName);  
        
    }
}
