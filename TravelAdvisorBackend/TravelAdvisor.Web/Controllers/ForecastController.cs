using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IForecast _forecast;

        public ForecastController(IForecast forecast)
        {
            _forecast = forecast;
        }


        [HttpPost("GetAllWeatherByCity")]
        public async Task<IActionResult> GetAllWeatherByCity(string cityName)
        {

            var item = await _forecast.GetWateherByCityName(cityName);

            return Ok(item);

        }

        //[HttpPost("GetCurrentWeatherByCity")]
        //public async Task<IActionResult> GetCurrentWeatherByCity(string cityName)
        //{

        //    var item = await _forecast.GetCurrentWateherByCityName(cityName); 

        //    return Ok(item);

        //}

    }
}
