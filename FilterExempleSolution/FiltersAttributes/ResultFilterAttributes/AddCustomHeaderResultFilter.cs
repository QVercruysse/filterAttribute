using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersAttributes.ResultFilterAttributes
{
    //Permet d'exécuter du code avant et après l'exécution du résultat d'une action.

    public class AddCustomHeaderResultFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("hey, I am added before the result of an action");
            context.HttpContext.Response.Headers.Add("OnResultExecuting", "hey, I am added before the result of an action");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("hey, I am added after the result of an action");
        }
    }
}