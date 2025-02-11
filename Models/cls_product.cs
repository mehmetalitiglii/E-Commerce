using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website_Project.Models;
public class cls_product
{
    E_CommerceDbContext _context = new E_CommerceDbContext();


    public async Task<List<Product>> GetProductsAsync()
    {
        List<Product> products = await _context.products.ToListAsync();
        return products;
    }


    public static bool ProductInsert(Product product)
    {
        //metod statik olduğu için _context nesnesi doğrudan oluşturulamaz. Bu yüzden _context nesnesi oluşturulur yada using kullanılır.

        //E_CommerceDbContext _context = new E_CommerceDbContext(); YADA
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                //product.ProductName = product.ProductName!.Trim().ToLower();

                if (product.Notes == null)
                { product.Notes = ""; }

                product.AddDate = DateTime.Now;


                bool exist =
                    _context
                    .products
                    .Any(
                        x => x.ProductName!.ToLower().Trim().Equals
                        (product.ProductName!.ToLower().Trim())
                        );

                if (!exist)
                {
                    _context.products.Add(product);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public async Task<Product?> GetProductDetailsAsync(int? id)
    {
        Product? product = await
                _context
                .products
                .FirstOrDefaultAsync(
                    x => x.ProductID == id
                    );

        return product;
    }

    public static bool ProductUpdate(Product product)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.Update(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }


    public static bool ProductDelete(int id)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                Product? product = _context
                    .products
                    .FirstOrDefault(x => x.ProductID == id);

                product!.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }


    public List<Product> GetProducts(string mainpageName)
    {
        List<Product> products;

        if (mainpageName is "SliderProducts")
        {
            //slider ürünleri getir
            products = _context.products.Where(x => x.StatusID == 1).Take(8).ToList();
        }
        else if (mainpageName is "NewProducts")
        {
            //yeni ürünleri getir
            products = _context.products.OrderByDescending(x => x.AddDate).Take(8).ToList();
        }
        else if (mainpageName is "SpecialProducts")
        {
            //Özel ürünleri getir
            products = _context.products.Where(x => x.StatusID == 2).OrderByDescending(x=> x.AddDate).Take(8).ToList();

        }
        else
        {
            return null;
        }

        return products;
    }

    public Product? GetProductOfDay()
    {
        //Günün ürünleri getir
       var product = _context.products.FirstOrDefault(x => x.StatusID == 6);

        return product;
    }
}