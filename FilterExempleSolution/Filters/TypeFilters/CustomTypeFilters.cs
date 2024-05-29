using FiltersAttributes.TypeFilterAttributes;
using Microsoft.AspNetCore.Mvc;

namespace FiltersAttributes.TypeFilters
{
    public class CustomTypeFilters : TypeFilterAttribute
    {
        public CustomTypeFilters() : base(typeof(TypeFilterAttributeAttributes))
        {
        }
    }
}
