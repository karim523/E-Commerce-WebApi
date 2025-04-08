using Microsoft.AspNetCore.Http;
using Shared.ErrorModels;
using System.Net;

namespace E_CommerceG01.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate? _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong : {ex}");
                await HandleException(httpContext, ex);

                throw;
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var response = new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = ex.Message
            }.ToString();
            await httpContext.Response.WriteAsync(response);
        }
    }
}
