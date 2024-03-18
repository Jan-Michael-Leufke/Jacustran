using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jacustran.Middleware.ExceptionsHandling;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, $"Exception Message: {exception.Message}");

        var problemDetails = new ProblemDetails
        {
            Title = "Server Error handled from Global Exception Handler",
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1", //Server Error
            Instance = httpContext.Request.Path,
            Detail = $"There was a Server Error",
            Extensions = { { "trace", Activity.Current?.Id ?? httpContext.TraceIdentifier } }
        };

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails);

        return true;
    }
}
