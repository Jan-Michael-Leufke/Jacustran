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

    protected IActionResult FailureToProblemDetails<T>(Result<T> result) => result switch
    {
        { IsSuccess: true } => throw new InvalidOperationException("The result is a success"),
        IValidationResult validationResult =>
            BadRequest(CreateProblemDetails(
                "Validation Error",
                StatusCodes.Status400BadRequest,
                result.Error,
                HttpContext,
                validationResult.ValidationErrors)),
        _ => BadRequest(CreateProblemDetails(
                "Bad Request",
                StatusCodes.Status400BadRequest,
                result.Error,
                httpContext: HttpContext))
    };

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        HttpContext? httpContext,
        Error[]? validationErrors = null) => 
        new()
        {
            Title = title,
            Status = status,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1", //Bad Request
            Instance = httpContext?.Request.Path.ToString() ?? "not specified",
            Detail = error.description,
            Extensions = { { nameof(validationErrors), validationErrors }, { "trace", httpContext?.TraceIdentifier } }
        };
}


