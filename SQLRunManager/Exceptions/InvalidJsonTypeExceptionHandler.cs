using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SQLRunManager.Exceptions
{
    public class InvalidJsonTypeExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var invalidJsonTypeException = context.Exception as InvalidJsonTypeException;

            if (invalidJsonTypeException == null)
                return;

            context.Result = new BadRequestObjectResult(new {message = invalidJsonTypeException.Message});
        }
    }
}