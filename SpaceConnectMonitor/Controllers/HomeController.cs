using Microsoft.AspNetCore.Mvc;

namespace SpaceConnectMonitor.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
