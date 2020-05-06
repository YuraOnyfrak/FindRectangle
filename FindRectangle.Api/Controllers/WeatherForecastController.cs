using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRectangle.Infastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FindRectangle.Api.Controllers
{
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

         var a =   new FindRectangleService().GetCountRectangle
                (
                new [,]
                {
                    {10, 2},
                    {10, 0},
                    {7, 0},
                    {7, 3},
                    {10, 3},
                    {10, 0},
                    {7,  0},
                    {7,  3},
                    {10, 5},
                    {10, 0},
                    {8,  0},
                    {8,  5},
                    {4, 2},
                    {2, 4},
                    {7, 5},
                    {5, 7}
                }
                );


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
