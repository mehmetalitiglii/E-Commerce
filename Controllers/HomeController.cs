using E_Commerce_Website_Project.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website_Project.Models;

namespace E_Commerce_Website_Project.Controllers;

public class HomeController : Controller
{
    /*
     * 1- slider -
     * 2- Özel -
     * 3- yıldızlı -
     * 4- fırsat -
     * 5- dikkat çeken -
     * 6- günün -
     * 
     * addDate = yeni ürünler - 
     * discount = indirimli ürünler -
     * higlighted ürünler - 
     * top seller ürünler -
     */
 
    MainPageModel MainPageModel = new MainPageModel();
    cls_product cls_Product = new cls_product();

    
    public IActionResult Index()
    {
        MainPageModel.SliderProducts = cls_Product.GetProducts("SliderProducts");
        MainPageModel.NewProducts = cls_Product.GetProducts("NewProducts");
        //_context.products.Where(x => x.StatusID == 1).ToList();
        MainPageModel.ProductOfDay = cls_Product.GetProductOfDay();
        MainPageModel.SpecialProducts = cls_Product.GetProducts("SpecialProducts");
        MainPageModel.StarredProducts = cls_Product.GetProducts("StarredProducts");
        MainPageModel.FeaturedProducts = cls_Product.GetProducts("FeaturedProducts");
        MainPageModel.DiscountedProducts = cls_Product.GetProducts("DiscountedProducts");
        MainPageModel.HighlightedProducts = cls_Product.GetProducts("HighlightedProducts");
        MainPageModel.TopSellerProducts = cls_Product.GetProducts("TopSellerProducts");
        MainPageModel.NotableProducts = cls_Product.GetProducts("NotableProducts");

        return View(MainPageModel);
    }

    //projenin herhangi bir sayfasında sepete ekle butonu tıklanınca bu aksiyon çalışacak
    public IActionResult CartProcess(int id)
    {


        //higlighted arttırılacak
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {



        //higlighted arttırılacak
        return View();
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