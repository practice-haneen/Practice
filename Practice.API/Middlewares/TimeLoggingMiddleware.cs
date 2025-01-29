using System.Text.Json;

namespace Practice.API.Middlewares;

public class TimeLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TimeLoggingMiddleware> _logger;

    public TimeLoggingMiddleware(RequestDelegate next, ILogger<TimeLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Pass the request to the next middleware in the pipeline
            await _next(context);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "An unhandled exception occurred at :{time}.", DateTime.UtcNow.ToShortTimeString());

            // Handle the exception and return a response
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            error = "An unexpected error occurred.",
            details = exception.Message,
            time = DateTime.UtcNow.ToShortTimeString(),
            place = exception.StackTrace
        };

        var jsonResponse = JsonSerializer.Serialize(response); // to convert the object into a JSON string that can be sent to the client

        return context.Response.WriteAsync(jsonResponse);
    }
}