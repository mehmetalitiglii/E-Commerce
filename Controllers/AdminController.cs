using E_Commerce_Website_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce_Website_Project.Controllers;

public class AdminController : Controller
{
    cls_User u = new cls_User();
    cls_category c = new cls_category();

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

    public async Task<IActionResult> CategoryIndex()
    {
        var categories = await c.GetCategoriesAsync();
        return View(categories);
    }

    [HttpGet]

    public IActionResult CategoryCreate()
    {

        CategoryFill();
        return View();
    }
    void CategoryFill()
    {

        List<Category> categories = c.GetMainCategories();
        ViewData["CategoryList"] = categories
            .Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryID.ToString()
            });
    }

}