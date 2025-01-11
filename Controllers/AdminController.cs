using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website_Project.Controllers;

public class AdminController : Controller
{
    public IActionResult Login()
    {
        return View();

    }

    [HttpPost]
    public IActionResult Login(int id)
    {
        return View();
    }

}

