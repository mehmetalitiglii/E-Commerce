using E_Commerce_Website_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace E_Commerce_Website_Project.Controllers;

public class AdminController : Controller
{
    cls_User u = new cls_User();
    cls_category c = new cls_category();
    E_CommerceDbContext _context = new E_CommerceDbContext();

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

    [HttpPost]
    public IActionResult CategoryCreate(Category category)
    {
        bool answer = cls_category.CategoryInsert(category);

        if (answer)
        {
            TempData["Message"] = "Kategori Ekleme Başarılı";

        }
        else
        {
            TempData["Message"] = "HATA! Kategori Ekleme Başarısız";
        }
        return RedirectToAction("CategoryCreate");
    }



    public async Task<IActionResult> CategoryEdit(int id)
    {
        CategoryFill();

        if (id == null || _context.categories == null)
        {
            return NotFound();

        }
        var category = await c.GetCategoryDetailsAsync(id);
        
        return View(category);
    }


    [HttpPost]
    public IActionResult CategoryEdit(Category category)
    {
        bool answer = cls_category.CategoryUpdate(category);

        if (answer)
        {
            TempData["Message"] = "Kategori Güncelleme Başarılı";
            return RedirectToAction("CategoryIndex");
        }
        else
        {
            TempData["Message"] = "HATA! Kategori Güncelleme Başarısız";
        }

        return RedirectToAction("CategoryEdit");
    }



    public async Task<IActionResult> CategoryDetails(int id)
    {
        var category = await _context.categories.FindAsync(id);
        ViewBag.category = category?.CategoryName;
        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> CategoryDelete(int? id)
    {

        if (id == null || _context == null)
        {
            return NotFound();
        }

        var category = await _context
            .categories
            .FirstOrDefaultAsync(x => x.CategoryID == id);

        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }


    [HttpPost, ActionName("CategoryDelete")]
    public async Task<IActionResult> CategoryDeleteConfirmed(int id)
    {
        bool answer = cls_category.CategoryDelete(id);

        if (answer)
        {
            TempData["Message"] = "Kategori Silindi";
            return RedirectToAction("CategoryIndex");
        }
        else
        {
            TempData["Message"] = "HATA! Kategori Silinemedi";
        }

        return RedirectToAction("CategoryDelete");
    }
}