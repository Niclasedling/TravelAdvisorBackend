using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Models
{
    public class WeatherDate
    {
        public double Temperature { get; set; }
        public string DateofForecast { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Icon { get; set; }



    }
}
