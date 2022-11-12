using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.DataStore;

namespace mvc.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Database _database;

    public AdminController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _database = Database.GetInstance();
    }

    public IActionResult Index()
    {
        var users = _database.GetUsers();
        return View("Index", new AdminModel { Users = users });
    }

    public IActionResult RemoveUser(string username, string usernameToRemove)
    {
        _database.RemoveUser(username);
        return RedirectToAction("Index");
    }

    public IActionResult AddUser(string username)
    {
        _database.AddUser(username);
        return RedirectToAction("Index");
    }

}
