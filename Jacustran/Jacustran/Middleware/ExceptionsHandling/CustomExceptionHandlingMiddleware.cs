using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Middleware.ExceptionsHandling;

public class CustomExceptionHandlingMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Exception Message: {ex.Message}");

            var problemDetails = new ProblemDetails
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "Server Error",
                Detail = $"There was a Server Error {GetType().Name}",
                Instance = context.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

}
