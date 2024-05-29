using FilterExempleSolution.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAttributes.ServiceFilterAttributes
{
    //Permet d'injecter des filtres comme services à partir du conteneur de services DI.
    //Le filtre lui-même doit être enregistré dans le conteneur DI.
    //Cycle de Vie: dépend de si c'set un singleton, scoped ou transient.

    public class ServiceFilterAttributes : IActionFilter
    {
        private readonly ILoggerService _loggerService;

        public ServiceFilterAttributes(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _loggerService.Log("Action is about to execute.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _loggerService.Log("Action has executed.");
        }
    }
}
