using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SQLRunManager.Controllers;

namespace SQLRunManager.Exceptions
{
    public class BadRequestExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var invalidJsonTypeException = context.Exception as BadRequestException;

            if (invalidJsonTypeException == null)
                return;

            context.Result = new BadRequestObjectResult(new {message = invalidJsonTypeException.Message});
        }
    }
}