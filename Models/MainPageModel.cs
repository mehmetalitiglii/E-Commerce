namespace E_Commerce_Website_Project.Models;
public class MainPageModel
{
    public List<Product> SliderProducts { get; set; }
    public List<Product> NewProducts { get; set; }
    public Product? ProductOfDay { get; set; }
    public List<Product> SpecialProducts { get; set; } 
    public List<Product> StarredProducts { get; set; }
    public List<Product> FeaturedProducts { get; set; }
    public List<Product> DiscountedProducts { get; set; }
    public List<Product> HighlightedProducts { get; set; }
    public List<Product> TopSellerProducts { get; set; }
    public List<Product> NotableProducts { get; set; }
}
