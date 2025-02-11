using E_Commerce_Website_Project.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website_Project.Models;

namespace E_Commerce_Website_Project.Controllers;

public class HomeController : Controller
{
    /*
     * 1- slider
     * 2- Özel 
     * 3- yıldızlı
     * 4- fırsat
     * 5- dikkat çeken
     * 6- günün
     * 
     * addDate = yeni ürünler
     * discount = indirimli ürünler
     * 
     */

    E_CommerceDbContext _context = new E_CommerceDbContext();
    MainPageModel MainPageModel = new MainPageModel();
    cls_product cls_Product = new cls_product();

    
    public IActionResult Index()
    {
        MainPageModel.SliderProducts = cls_Product.GetProducts("SliderProducts");
        MainPageModel.NewProducts = cls_Product.GetProducts("NewProducts");
        //_context.products.Where(x => x.StatusID == 1).ToList();
        MainPageModel.ProductOfDay = cls_Product.GetProductOfDay();
        MainPageModel.SpecialProducts = cls_Product.GetProducts("SpecialProducts");


        return View(MainPageModel);
    }
    //projenin herhangi bir sayfasında sepete ekle butonu tıklanınca bu aksiyon çalışacak
    public IActionResult CartProcess(int id)
    {

        return RedirectToAction("Index");
    }
    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult NewProducts()
    { 
    return View();


    }
}