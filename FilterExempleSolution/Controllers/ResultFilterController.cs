using FiltersAttributes.ResultFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FilterExempleSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultFilterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ActionFilterController> _logger;

        public ResultFilterController(ILogger<ActionFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ResultFilterAttributes/onResultExecuting")]
        [AddCustomHeaderResultFilter]
        public IEnumerable<WeatherForecast> GetOnResultExecuting()
        {
            Console.WriteLine("hey, I am added at controller startup");

            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            Console.WriteLine("hey, I am added at controller endup");

            return weatherForecasts;
        }
    }
}
