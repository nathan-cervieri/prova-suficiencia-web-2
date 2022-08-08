using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.Entity.Core;
using System.Net;

namespace FurbAPIRest.Helpers
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException || context.Exception is ObjectNotFoundException)
            {
                context.Result = new ContentResult()
                {
                    Content = context.Exception.ToString(),
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return;
            }

            context.Result = new ContentResult()
            {
                Content = context.Exception.ToString(),
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
