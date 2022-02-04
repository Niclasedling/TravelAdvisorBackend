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
    [Route("[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IForecast _forecast;

        public ForecastController(IForecast forecast)
        {
            _forecast = forecast;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string cityName)
        {

            var item = await _forecast.GetWateherByCityName(cityName);

            return Ok(item);

        }

      

    }
}
