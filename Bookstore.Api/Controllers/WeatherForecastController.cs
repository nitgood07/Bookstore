using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggerManager logger;

        public WeatherForecastController(ILoggerManager _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            logger.LogInfo("I am logging informaiton");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
