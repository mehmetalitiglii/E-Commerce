namespace E_Commerce_Website_Project.Models;
public class MainPageModel
{
    public List<Product> SliderProducts { get; set; }
    public List<Product> NewProducts { get; set; }
    public Product? ProductOfDay { get; set; }
    public List<Product> SpecialProducts { get; set; }
}
