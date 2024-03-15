using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Presentation.Controllers;

public class TestController(ISender sender) : ApiController(sender)
{
    [HttpGet]   
    public IActionResult Get() => Ok("test");
    
}
