using Microsoft.EntityFrameworkCore;
namespace E_Commerce_Website_Project.Models;

public class cls_supplier
{
    E_CommerceDbContext _context = new E_CommerceDbContext();


    public async Task<List<Supplier>> GetSuppliersAsync()
    {
        List<Supplier> suppliers = await _context.suppliers.ToListAsync();
        return suppliers;
    }

    public static bool SupplierInsert(Supplier supplier)
    {
        //metod statik olduğu için _context nesnesi doğrudan oluşturulamaz. Bu yüzden _context nesnesi oluşturulur yada using kullanılır.

        //E_CommerceDbContext _context = new E_CommerceDbContext(); YADA
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.suppliers.Add(supplier);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }



}



