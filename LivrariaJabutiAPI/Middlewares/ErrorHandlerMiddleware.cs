using LivrariaJabutiAPI.Domain.Models.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace LivrariaJabutiAPI.Web.Middlewares
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var exceptionResponse = JsonConvert.SerializeObject(new ExceptionResponse(exception));

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsync(exceptionResponse);
            }
        }
    }
}
