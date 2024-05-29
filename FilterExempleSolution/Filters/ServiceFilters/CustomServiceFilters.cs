using Microsoft.AspNetCore.Mvc;

namespace FiltersAttributes.ServiceFilterAttributes
{
    public class CustomServiceFilters : ServiceFilterAttribute
    {
        public CustomServiceFilters() : base(typeof(ServiceFilterAttributes))
        {
        }
    }
}
