using System.Net;
using System.Text.Json;

namespace ProFinder.WebAPI.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(IHostEnvironment env, ILogger<ErrorHandlingMiddleware> logger)
        {
            _env = env;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var logExceptionMessage = $"{DateTime.Now} - Exception Type: {ex.GetType().FullName} - Message: {ex.Message} - Inner Exceptions: {ex.InnerException} - Stack Trace: {ex.StackTrace}\n";
                _logger.LogError(logExceptionMessage);

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is ArgumentException)
                code = HttpStatusCode.BadRequest;
            else if (ex is InvalidOperationException)
                code = HttpStatusCode.NotFound;

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name,
                    description = _env.IsDevelopment() ? ex.StackTrace : null
                }
            })).ConfigureAwait(false);
        }
    }
}
