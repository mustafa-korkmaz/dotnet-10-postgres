using System.Net;

namespace API
{
    public sealed class RequestHandlingMiddleware(
        RequestDelegate next,
        ILogger<RequestHandlingMiddleware> logger)
    {
        private const string RequestIdHeader = "RequestId";
        private const string InternalErrorMessage = "An internal server error occured";

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                SetCorrelationId(context);
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static void SetCorrelationId(HttpContext context)
        {
            context.Items[RequestIdHeader] = Guid.NewGuid();
        }

        private static string GetRequestId(HttpContext context)
        {
            return context.Items[RequestIdHeader]!.ToString()!;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string requestId = GetRequestId(context);
            string message = exception.Message;

            (HttpStatusCode statusCode, string? description) = exception switch
            {
                UnauthorizedAccessException => (HttpStatusCode.Unauthorized, message),
                InvalidOperationException => (HttpStatusCode.BadRequest, message),
                KeyNotFoundException => (HttpStatusCode.NotFound, null),
                _ => (HttpStatusCode.InternalServerError, InternalErrorMessage)
            };

            if (statusCode == HttpStatusCode.InternalServerError)
            {
                logger.LogError(exception, message, requestId);
            }
            else
            {
                logger.LogWarning(message, requestId);
            }

            var response = new
            {
                RequestId = requestId,
                Description = description
            };

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
