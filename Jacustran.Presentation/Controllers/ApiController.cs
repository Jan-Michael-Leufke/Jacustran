using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController(ISender sender) : ControllerBase
{
    protected readonly ISender _sender = sender;
}
