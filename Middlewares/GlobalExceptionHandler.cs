using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using SocialMediaAPI.Models;

namespace SocialMediaAPI.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }


        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"An error occur when processing request ::: {exception.Message}");

            // Create error response object
            var errorResponse = new ErrorResponse
            {
                Message = exception.Message,
                // Switch exception syntax to get status code base on exception
                StatusCode = exception switch
                {
                    BadHttpRequestException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                }
            };

            // Set http response status code
            httpContext.Response.StatusCode = errorResponse.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}