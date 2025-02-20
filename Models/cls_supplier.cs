﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<Supplier?> GetSupplierDetailsAsync(int? id)
    {
        Supplier? supplier = await
                _context
                .suppliers
                .FirstOrDefaultAsync(
                    x => x.SupplierID == id
                    );

        return supplier;
    }


    public static bool SupplierUpdate(Supplier supplier)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.Update(supplier);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }


    public static bool SupplierDelete(int supID)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                Supplier? supplier = _context
                    .suppliers
                    .FirstOrDefault(x => x.SupplierID == supID);

                supplier!.IsActive = false;
               
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

