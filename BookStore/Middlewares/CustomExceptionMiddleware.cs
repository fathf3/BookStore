using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BookStore.Common;
using BookStore.Services;

namespace BookStore.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                string message = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} : [Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                Console.WriteLine(message);

                _loggerService.writeLog(message);
                await _next(context);
                watch.Stop();

                message = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} : [Response] HTTP " + context.Request.Method+ " - " + context.Request.Path + " responsed " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds;
                _loggerService.writeLog(message);
                Console.WriteLine(message);

            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
                
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            string message = $"{DateTime.Now.ToString("MM/dd/yyyy HH:mm")} : [Error] HTTP" + context.Request.Method + " - " + context.Response.StatusCode + " Error Message : " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds;
            _loggerService.writeLog(message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }



    }
    public static class CustomExceptionMiddilewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionBuilder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}


