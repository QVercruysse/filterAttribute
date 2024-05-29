using FiltersAttributes.ServiceFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FilterExempleSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceFilterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ActionFilterController> _logger;

        public ServiceFilterController(ILogger<ActionFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ServiceFilters")]
        [CustomServiceFilters]
        public IEnumerable<WeatherForecast> GetByFilter()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("ServiceFilterAttributes")]
        [ServiceFilter(typeof(ServiceFilterAttributes))]
        public IEnumerable<WeatherForecast> GetByFilterAttributes()
        {
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
