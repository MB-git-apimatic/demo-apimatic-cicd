using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreAPIs.Controllers
{
    /// <summary>
    /// Manage Weather Forecast
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// GET /WeatherForecast 
        /// <summary>
        /// Gets the Weather Forecast details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                id= index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// GET /WeatherForecast/{forecastId}
        /// <summary>
        /// Get the single Weather Forecast details by id.
        /// </summary>
        /// <param name="forecastId">The forecast Id changed.</param>
        /// <returns></returns>
        [HttpGet("{forecastId}")]
        public WeatherForecast GetById(int forecastId)
        {
            var rng = new Random();
            var c=  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return c.Where(x => x.id == forecastId).FirstOrDefault();
        }

        /// GET /WeatherForecast/index/{index}
        /// <summary>
        /// Gets the index of the by.
        /// </summary>
        /// <param name="indexId">The index identifier.</param>
        /// <returns></returns>
        [HttpGet("index/{indexId}")]
        public WeatherForecast GetByIndex(int indexId)
        {
            var rng = new Random();
            var c = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return c.Where(x => x.id == indexId).FirstOrDefault();
        }
    }
}
