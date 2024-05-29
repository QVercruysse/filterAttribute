using FiltersAttributes.TypeFilterAttributes;
using FiltersAttributes.TypeFilters;
using Microsoft.AspNetCore.Mvc;

namespace FilterExempleSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeFilterController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ActionFilterController> _logger;

        public TypeFilterController(ILogger<ActionFilterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("TypeFilters")]
        [CustomTypeFilters]
        public IEnumerable<WeatherForecast> GetByFilters()
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
        [Route("TypeFilterAttributes")]
        [TypeFilter(typeof(TypeFilterAttributeAttributes))]
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
