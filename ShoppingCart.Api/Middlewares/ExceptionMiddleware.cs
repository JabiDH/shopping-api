
using Microsoft.AspNetCore.Http.Extensions;
using ShoppingCart.Dtos.Common.Responses;

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
                    StatusCode = 500,
                    Message = "Internal Server Error." 
                };
                
                await context.Response.WriteAsJsonAsync(errResponse);
            }
        }
    }
}
