using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.CustomException;

namespace ZarvanOrder.Filters
{
    public class CustomExceptionFilter : ActionFilterAttribute
    {
        //public int Order { get; } = int.MaxValue - 10;

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is MyException exception)
            {
                context.Result = new ObjectResult(exception.Error.Description)
                {
                    StatusCode = exception.Error.Code,
                    Value = exception.Error.Description
                };
                context.ExceptionHandled = true;
            }
        }
        //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    {
        //        var executed = await next();
        //        if (executed.Exception.GetType() == typeof(FluentValidation.ValidationException))
        //        {
        //            MyException exception = new MyException(executed.Exception.Message);
        //            context.Result = new ObjectResult(executed.Exception.Message)
        //            {
        //                StatusCode = (int)System.Net.HttpStatusCode.BadRequest,
        //                Value = executed.Exception.Message
        //            };
        //            executed.ExceptionHandled = true;
        //        }
        //    }
        //    await base.OnActionExecutionAsync(context, next);
        //}
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    base.OnActionExecuting(context);
        //}
        //public async override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        //{
        //    var executed = await next();
        //    await base.OnResultExecutionAsync(context, next);
        //}
    }
}
