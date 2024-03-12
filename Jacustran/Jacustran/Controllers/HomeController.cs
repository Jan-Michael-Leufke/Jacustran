using Microsoft.AspNetCore.Mvc;

namespace Jacustran.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok("Hello, World from home controller!");
    }
}
