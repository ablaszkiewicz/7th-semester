using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.DataStore;
using System.Text;
using System.Text.Json;

namespace mvc.Controllers;

public class UserController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private Database _database;

    public UserController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _database = Database.GetInstance();
    }

    public IActionResult Index(string username)
    {
        var friends = _database.GetFriendsOfUser(username);
        return View("Index", new UserModel { Username = username, Friends = friends });
    }

    public IActionResult RemoveFriend(string username, string usernameToRemove)
    {
        _database.RemoveFriendOfUser(username, usernameToRemove);
        return RedirectToAction("Index", new { username = username });
    }

    public IActionResult AddFriend(string username, string usernameToAdd)
    {
        _database.AddFriendOfUser(username, usernameToAdd);
        return RedirectToAction("Index", new { username = username });
    }
    
    //export friends list to JSON file and download it
    public IActionResult ExportFriends(string username)
    {
        var friends = _database.GetFriendsOfUser(username);
        var json = JsonSerializer.Serialize(friends);

        var bytes = Encoding.UTF8.GetBytes(json);
        return File(bytes, "application/json", "friends.json");
    }
}
