using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILoggingService _loggingService;

        public GlobalExceptionFilter(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public void OnException(ExceptionContext context)
        {
            _loggingService.Log(
                $"Exception: {context.Exception.Message}");

            context.Result = new ViewResult
            {
                ViewName = "Error"
            };

            context.ExceptionHandled = true;
        }
    }
}