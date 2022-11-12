using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RedirectToUser()
    {
        if (Request.Form["username"] == "admin")
        {
            return RedirectToAction("Index", "Admin", new { username = Request.Form["username"] });
        }
        else
        {
            return RedirectToAction("Index", "User", new { username = Request.Form["username"] });
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
