using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace IFAVALIACAO.API.Middleware
{
    public class GlobalExceptionHandlingFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionHandlingFilter> _log;

        public GlobalExceptionHandlingFilter(ILogger<GlobalExceptionHandlingFilter> log)
        {
            _log = log;
        }

        public override void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;

            response.StatusCode = 500;
            response.ContentType = "application/json";
            var message = context.Exception.InnerException == null ?
                context.Exception.Message : context.Exception.InnerException.Message;

            context.ExceptionHandled = true;
            _log.LogError(context.Exception.StackTrace);
            context.Result = new JsonResult(new { message });
        }
    }
}