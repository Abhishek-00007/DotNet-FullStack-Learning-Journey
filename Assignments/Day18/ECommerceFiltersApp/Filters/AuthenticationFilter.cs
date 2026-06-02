using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters
{
    public class AuthenticationFilter : IActionFilter
    {
        private readonly IAuthService _authService;

        public AuthenticationFilter(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_authService.IsLoggedIn())
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Home",
                    null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}