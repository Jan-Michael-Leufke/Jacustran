using Microsoft.AspNetCore.Mvc;


namespace MVC_BC.Presentation.Areas.Tester.Controllers;


[Area("Tester")]
public class TestmvcController : Controller
{
    public IActionResult Forward()
    {
        return View("Forward");
    }
}
