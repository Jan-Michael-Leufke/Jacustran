using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

public class TestController(ISender sender, IMapper mapper) : ApiController(sender, mapper)
{
    [HttpGet]   
    public IActionResult Get() => Ok("test");
    
}
