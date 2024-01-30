
using Microsoft.AspNetCore.Http.Extensions;
using ShoppingCart.Dtos.Common.Responses;
using System.Net;

namespace ShoppingCart.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly RequestDelegate next;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try 
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Log exception to file
                string message = "";
                message = $"Exception while processing -> {context.Request.Method}: {context.Request.GetDisplayUrl()}\n";
                message += $"Exception -> {ex}\n";
                logger.LogError(message);

                var errResponse = new ErrorResponseDto() 
                {
                    Id = Guid.NewGuid(),
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal Server Error." 
                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(errResponse);
            }
        }
    }
}
