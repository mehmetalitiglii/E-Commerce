using E_Commerce_Website_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website_Project.Controllers;

public class AdminController : Controller
{
    cls_User u = new cls_User();

    public IActionResult Login()
    {

        return View();

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Email,Password,NameSurname")] User user)
    {
        if (ModelState.IsValid)
        {

            Models.User? usr = await u.LoginControl(user);

            if (usr != null)
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        else
        {
            ViewBag.Error = "Login Bilgileri Yanlış";
        }

        return View();
    }

    public IActionResult Index()
    {



        return View();
    }
}