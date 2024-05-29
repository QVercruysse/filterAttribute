using FiltersAttributes.ResultFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FilterExempleSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormatFilterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ActionFilterController> _logger;

        public FormatFilterController(ILogger<ActionFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ResultFilterAttributes/onResultExecuting/summary/{summary}.{format?}")]
        public IActionResult GetWeatherForecast(string summary)
        {
            var weatherForecasts = Summaries.Select(summarie => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summarie
            })
            .ToArray();

            var weatherForecast = weatherForecasts.FirstOrDefault(wf => wf.Summary == summary);

            if (weatherForecast == null)
            {
                return NotFound();
            }

            return Ok(weatherForecast);
        }
    }
}
