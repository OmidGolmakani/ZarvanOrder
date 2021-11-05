﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using ZarvanOrder.CustomException;

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
                Error Err = null;

                if (ex.GetType().Equals(typeof(FluentValidation.ValidationException)) == true ||
                    ex.GetType().Equals(typeof(MyException)) == true)
                {
                    Err = new Error()
                    {
                        Description = ex.Message,
                        Code = context.Response.StatusCode.ToString()
                    };
                }
                else
                {
                    Err = new Error()
                    {
                        Description = "یک خطای ناشناخته رخ داده است.جزئیات خطا به مدیران سایت گزارش داده شد",
                        Code = ((int)System.Net.WebExceptionStatus.UnknownError).ToString()
                    };
                    logger.LogError(ex, ex.Message);
                }
                var result = JsonConvert.SerializeObject(Err);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
            app.UseHsts();
        }
    }
}