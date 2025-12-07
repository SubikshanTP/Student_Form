using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Student_Form.Filter
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var errorResponse = new
            {
                Message = context.Exception.Message,
                StackTrace = context.Exception.StackTrace
            };

            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            // Mark exception as handled
            context.ExceptionHandled = true;

        }

    }
}
