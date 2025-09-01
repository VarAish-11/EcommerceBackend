using System.Net;

namespace Ecommerce.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Continue processing the request
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unexpected error occurred.");

                // Set response status code
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Set response content type
                httpContext.Response.ContentType = "application/json";

                // Write the error response
                var errorResponse = new { message = "An unexpected error occurred. Please try again later." };
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
