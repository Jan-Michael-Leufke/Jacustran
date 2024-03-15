using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController(ISender sender, IMapper mapper) : ControllerBase
{
    protected readonly ISender _sender = sender;
    protected readonly IMapper _mapper = mapper;
}
