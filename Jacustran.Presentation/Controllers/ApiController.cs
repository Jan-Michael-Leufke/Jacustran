using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jacustran.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController(ISender sender, IMapper mapper) : ControllerBase
{
    protected readonly ISender _sender = sender;
    protected readonly IMapper _mapper = mapper;

    protected ActionResult<T> FailureToProblemDetails<T>(Result<T> result) => result switch
    {
        { IsSuccess: true } => throw new InvalidOperationException("The result is a success"),
        IValidationResult validationResult =>
            BadRequest(CreateProblemDetails(
                "Validation Error",
                result.Error,
                HttpContext,
                StatusCodes.Status400BadRequest,
                validationResult.ValidationErrors)),
        _ => BadRequest(CreateProblemDetails(
                "Bad Request",
                result.Error,
                httpContext: HttpContext,
                StatusCodes.Status400BadRequest))
    };

    private static ProblemDetails CreateProblemDetails(
        string title,
        Error error,
        HttpContext httpContext,
        int status,
        Error[]? validationErrors = null) => 
        new()
        {
            Title = title,
            Status = status,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1", //Bad Request
            Instance = httpContext.Request.Path.ToString(),
            Detail = error.description,
            Extensions = { { nameof(validationErrors), validationErrors }, { "trace", httpContext?.TraceIdentifier } }
        };
}


