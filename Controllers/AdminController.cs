﻿using E_Commerce_Website_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace E_Commerce_Website_Project.Controllers;

public class AdminController : Controller
{
    cls_User u = new cls_User();
    cls_category c = new cls_category();
    cls_supplier s = new cls_supplier();
    E_CommerceDbContext _context = new E_CommerceDbContext();
    cls_status st = new cls_status();
    cls_product p = new cls_product();

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

    async Task SupplierFill()
    {

        List<Supplier> suppliers = await s.GetSuppliersAsync();
        ViewData["suppliersList"] = suppliers
            .Select(x => new SelectListItem
            {
                Text = x.BrandName,
                Value = x.SupplierID.ToString()
            });
    }


    async Task StatusFill()
    {

        List<Status> statuses = await st.GetStatusesAsync();
        ViewData["statusesList"] = statuses
            .Select(x => new SelectListItem
            {
                Text = x.StatusName,
                Value = x.StatusID.ToString()
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


    public async Task<IActionResult> SupplierIndex()
    {
        List<Supplier> supliers = await s.GetSuppliersAsync();
        return View(supliers);
    }

    [HttpGet]
    public async Task<IActionResult> SupplierCreate(int id)
    {

        return View();
    }


    [HttpPost]
    public IActionResult SupplierCreate(Supplier supplier)
    {
        bool answer = cls_supplier.SupplierInsert(supplier);

        if (answer)
        {
            TempData["Message"] = "Marka Ekleme Başarılı";

        }
        else
        {
            TempData["Message"] = "HATA! Marka Ekleme Başarısız";
        }
        return RedirectToAction("SupplierCreate");
    }


    [HttpGet]
    public async Task<IActionResult> SupplierEdit(int id)
    {
        if (id == null || _context.suppliers == null)
        {
            return NotFound();

        }
        var suppliers = await s.GetSupplierDetailsAsync(id);

        return View(suppliers);
    }


    [HttpPost]
    public IActionResult SupplierEdit(Supplier supplier)
    {
        if (supplier.PhotoPath == null)
        {
            //Foto değiştirmezse eski fotoyu al
            string? photoPath = _context.suppliers.FirstOrDefault(x => x.SupplierID == supplier.SupplierID)?.PhotoPath;
            supplier.PhotoPath = photoPath;
        }


        bool answer = cls_supplier.SupplierUpdate(supplier);

        if (answer)
        {
            TempData["Message"] = supplier.BrandName?.ToUpper() + " Markası Güncellendi";
        }
        else
        {
            TempData["Message"] = "HATA! Marka Güncelleme Başarısız";
        }

        return RedirectToAction("SupplierIndex");
    }



    public async Task<IActionResult> SupplierDetails(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var supplier = await s.GetSupplierDetailsAsync(id);
        ViewBag.supplier = supplier?.BrandName;
        return View(supplier);
    }



    [HttpGet]
    public async Task<IActionResult> SupplierDelete(int? id)
    {

        if (id == null || _context.suppliers == null)
        {
            return NotFound();
        }

        var supplier = await _context
            .suppliers
            .FirstOrDefaultAsync(x => x.SupplierID == id);

        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }


    [HttpPost, ActionName("SupplierDelete")]
    public async Task<IActionResult> SupplierDeleteConfirmed(int id)
    {
        bool answer = cls_supplier.SupplierDelete(id);

        if (answer)
        {
            TempData["Message"] = "Marka Silindi";
            return RedirectToAction("SupplierIndex");
        }
        else
        {
            TempData["Message"] = "HATA! Marka Silinemedi";
        }

        return RedirectToAction("SupplierDelete");
    }


    public async Task<IActionResult> StatusIndex()
    {
        List<Status> statuses = await st.GetStatusesAsync();
        return View(statuses);
    }


    [HttpGet]
    public async Task<IActionResult> StatusCreate(int id)
    {

        return View();
    }


    [HttpPost]
    public IActionResult StatusCreate(Status status)
    {
        bool answer = cls_status.StatusInsert(status);

        if (answer)
        {
            TempData["Message"] = "Durum Ekleme Başarılı";

        }
        else
        {
            TempData["Message"] = "HATA! Durum Ekleme Başarısız";
        }
        return RedirectToAction(nameof(StatusCreate));
    }

    [HttpGet]
    public async Task<IActionResult> StatusEdit(int? id)
    {
        if (id == null || _context.statuses == null)
        {
            return NotFound();

        }
        var status = await st.GetStatusDetailsAsync(id);

        return View(status);
    }


    [HttpPost]
    public IActionResult StatusEdit(Status status)
    {

        bool answer = cls_status.StatusUpdate(status);

        if (answer)
        {
            TempData["Message"] = status.StatusName?.ToUpper() + " Güncellendi";
        }
        else
        {
            TempData["Message"] = "HATA! Güncelleme Başarısız";
        }

        return RedirectToAction("StatusIndex");
    }


    public async Task<IActionResult> StatusDetails(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var status = await st.GetStatusDetailsAsync(id);
        ViewBag.status = status.StatusName;
        return View(status);
    }



    [HttpGet]
    public async Task<IActionResult> StatusDelete(int? id)
    {

        if (id == null || _context.statuses == null)
        {
            return NotFound();
        }

        var status = await _context
            .statuses
            .FirstOrDefaultAsync(x => x.StatusID == id);

        if (status == null)
        {
            return NotFound();
        }
        return View(status);
    }


    [HttpPost, ActionName("StatusDelete")]
    public async Task<IActionResult> StatusDeleteConfirmed(int id)
    {
        bool answer = cls_status.StatusDelete(id);

        if (answer)
        {
            TempData["Message"] = "Durum Silindi";
            return RedirectToAction("StatusIndex");
        }
        else
        {
            TempData["Message"] = "HATA! Durum Silinemedi";
        }

        return RedirectToAction("StatusDelete");
    }


    public async Task<IActionResult> ProductIndex()
    {
        var products = await p.GetProductsAsync();
        return View(products);
    }



    [HttpGet]
    public async Task<IActionResult> ProductCreate()
    {

        CategoryFill();
        await SupplierFill();
        await StatusFill();
        return View();
    }


    [HttpPost]
    public IActionResult ProductCreate(Product product)
    {
        if (ModelState.IsValid)
        {
            bool answer = cls_product.ProductInsert(product);

            if (answer)
            {
                TempData["Message"] = "Ürün Ekleme Başarılı";

            }
            else
            {
                TempData["Message"] = "HATA! Ürün Ekleme Başarısız";
            }
        }
        else
        {
            TempData["Message"] = "HATA! Zorunlu alanları doldurun";
        }


        return RedirectToAction("ProductCreate");
    }

  
    [HttpGet]
    public async Task<IActionResult> ProductEdit(int id)
    {
        CategoryFill();
        await SupplierFill();
        await StatusFill();

        if (id == null || _context.products == null)
        {
            return NotFound();

        }
        var product = await p.GetProductDetailsAsync(id);

        return View(product);
    }
    [HttpPost]
    public async Task<IActionResult> ProductEdit(Product product)
    {
        var existProduct = await p.GetProductDetailsAsync(product.ProductID);

        if (product.PhotoPath == null)
        {
            ////Foto değiştirmezse eski fotoyu al
            //string? photoPath = _context.products.FirstOrDefault(x => x.ProductID== product.ProductID)?.PhotoPath;
            product.PhotoPath = existProduct?.PhotoPath;
        }

        // Backende yollanmayan değerler: Highligted, TopSeller, AddDate

        product.HighLighted = existProduct!.HighLighted;
        product.TopSeller = existProduct!.TopSeller;
        product.AddDate = existProduct!.AddDate;


        bool answer = cls_product.ProductUpdate(product);

        if (answer)
        {
            TempData["Message"] = "Ürün Güncelleme Başarılı";
            return RedirectToAction("ProductIndex");
        }
        else
        {
            TempData["Message"] = "HATA! Ürün Güncelleme Başarısız";
        }
        return RedirectToAction("ProductEdit");
    }


    [HttpGet]
    public async Task<IActionResult> ProductDelete(int? id)
    {

        if (id == null || _context.products == null)
        {
            return NotFound();
        }

        var product = await _context
            .products
            .FirstOrDefaultAsync(x => x.ProductID == id);

        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }


    [HttpPost, ActionName("ProductDelete")]
    public async Task<IActionResult> ProductDeleteConfirmed(int id)
    {
        bool answer = cls_product.ProductDelete(id);

        if (answer)
        {
            TempData["Message"] = "Ürün Silindi";
            return RedirectToAction("ProductIndex");
        }
        else
        {
            TempData["Message"] = "HATA! Ürün Silinemedi";
        }

        return RedirectToAction("ProductDelete");
    }


    public async Task<IActionResult> ProductDetails(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var product = await p.GetProductDetailsAsync(id);
        ViewBag.product = product?.ProductName;
        return View(product);
    }
}