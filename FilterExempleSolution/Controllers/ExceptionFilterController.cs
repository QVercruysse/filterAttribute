using FiltersAttributes.ServiceFilterAttributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FilterExempleSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExceptionFilterController : ControllerBase
    {
        private static readonly string[] Summaries;

        private readonly ILogger<ActionFilterController> _logger;

        public ExceptionFilterController(ILogger<ActionFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ExceptionFilterAttributes")]
        [ExceptionFilterAttributes]
        public WeatherForecast Get()
        {
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Freezing"
            };
        }


        [HttpGet]
        [Route("ExceptionFilterAttributes/error")]
        [ExceptionFilterAttributes]
        public WeatherForecast GetWithError()
        {
            var firstSummary = Summaries.FirstOrDefault();


            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = firstSummary
            };
        }
    }
}
