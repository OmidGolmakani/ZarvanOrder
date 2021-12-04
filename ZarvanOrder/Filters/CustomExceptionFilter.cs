using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using ZarvanOrder.CustomException;

namespace ZarvanOrder.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = ErrorHandle(context);
            context.ExceptionHandled = true;
            base.OnException(context);
        }
        private IActionResult ErrorHandle(ExceptionContext context)
        {
            MyException exception = new MyException();

            if (context.Exception.GetType() == typeof(MyException))
            {
                if (((MyException)context.Exception).Error.Code <= 0)
                {
                    exception = new MyException("خطای ناشناخته");
                }
                else
                {
                    exception = (MyException)context.Exception;
                }
            }
            else if (context.Exception.GetType() == typeof(FluentValidation.ValidationException))
            {
                exception = new MyException(0, "خطای ناشناخته");
            }
            else
            {

                exception = new MyException(context.Exception.Message, context.Exception.InnerException);
            }

            if (exception.Error != null && string.IsNullOrEmpty(exception.Error.Description) == false)
            {
                context.Result = new ObjectResult(exception.Error.Description)
                {
                    StatusCode = exception.Error.Code,
                    Value = exception.Error.Description
                };
            }
            else
            {
                context.Result = new ObjectResult(exception.Message)
                {
                    StatusCode = exception.HResult,
                    Value = exception.Message
                };
            }
            return context.Result;
        }
    }
}
