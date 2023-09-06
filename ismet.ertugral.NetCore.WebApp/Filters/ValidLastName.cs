using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class ValidLastName : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Customer? _customer = (context.ActionArguments.FirstOrDefault(x => x.Key == "customer")).Value as Customer;
            if (_customer != null && _customer.LastName.ToLower() == "ertuğral")
            {
                context.Result = new RedirectResult("/");
            }
        }
    }
}
