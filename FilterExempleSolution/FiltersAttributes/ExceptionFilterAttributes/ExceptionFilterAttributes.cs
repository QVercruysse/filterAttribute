using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersAttributes.ServiceFilterAttributes
{
    //Permet de gérer les exceptions non prises en charge par les actions des contrôleurs.
    public class ExceptionFilterAttributes : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine("An exception occurred: " + context.Exception.Message);
            context.Result = new ContentResult
            {
                StatusCode = 500,
                Content = "An error occurred. Please try again later."
            };
        }
    }
}