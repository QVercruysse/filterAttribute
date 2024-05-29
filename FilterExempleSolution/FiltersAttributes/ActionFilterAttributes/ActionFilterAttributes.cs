using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAttributes.ActionFilterAttributes
{
    public class ActionFilterAttributes : ActionFilterAttribute
    {
        //Permet d'exécuter du code avant et après l'exécution d'une action d'un contrôleur.

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action is about to execute.");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action has executed.");
        }
    }
}