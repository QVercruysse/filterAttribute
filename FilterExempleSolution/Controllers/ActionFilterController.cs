using FiltersAttributes.ActionFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FilterExempleSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActionFilterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ActionFilterController> _logger;

        public ActionFilterController(ILogger<ActionFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ActionFilterAttributes")]
        [ActionFilterAttributes]
        public IEnumerable<WeatherForecast> Get()
        {

            Console.WriteLine("Action is executing.");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
