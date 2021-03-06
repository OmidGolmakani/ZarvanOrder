using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using ZarvanOrder.CustomException;
using ZarvanOrder.Extensions.Other;

namespace ZarvanOrder.Middleware
{
    internal static class CustomExceptionMiddlewere
    {
        internal static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var ex = exceptionHandlerPathFeature.Error;
                ErrorResponse Err = new ErrorResponse();

                if (ex.GetType().Equals(typeof(MyException)) == true)
                {
                    Err = ((MyException)ex).Error;
                }
                else if (ex.GetType().Equals(typeof(FluentValidation.ValidationException)) == true)
                {
                    Err.Description = ex.Message;
                    Err.Code = (int)System.Net.HttpStatusCode.BadRequest;
                }

                else
                {
                    Err = new ErrorResponse()
                    {
                        Description = "یک خطای ناشناخته رخ داده است.جزئیات خطا به مدیران سایت گزارش داده شد",
                        Code = (int)System.Net.WebExceptionStatus.UnknownError
                    };
                    logger.LogError(ex, ex.Message);
                }
                var result = JsonConvert.SerializeObject(new ErrorResponse() {Code =1,Description ="222" });
                context.Response.StatusCode = Err.Code.ToInt();
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
            app.UseHsts();
        }
    }
}
