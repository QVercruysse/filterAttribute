using FilterExempleSolution.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAttributes.TypeFilterAttributes
{
    //Permet de spécifier un filtre par type et d'injecter ses dépendances à partir du conteneur de services DI.
    //Cycle de Vie: Crée une nouvelle instance du filtre à chaque requête.
    public class TypeFilterAttributeAttributes : IActionFilter
    {
        private readonly ILoggerService _loggerService;

        public TypeFilterAttributeAttributes(ILoggerService loggerService)
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