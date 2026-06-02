using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ILoggingService _loggingService;

        public LoggingFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _loggingService.Log(
                $"Request: {context.HttpContext.Request.Method} " +
                $"{context.HttpContext.Request.Path}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _loggingService.Log(
                $"Response Status Code: " +
                $"{context.HttpContext.Response.StatusCode}");
        }
    }
}