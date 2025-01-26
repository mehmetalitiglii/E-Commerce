using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Commerce_Website_Project.Models;

public class cls_category
{
    E_CommerceDbContext _context = new E_CommerceDbContext();




    //Bütün kategorileri liste olarak döner(asenkron)
    public async Task<List<Category>> GetCategoriesAsync()
    {
        List<Category> categories = await _context.categories.ToListAsync();
        return categories;
    }

    //Ana kategorileri getirir
    public List<Category> GetMainCategories()
    {
        List<Category> categories = _context.categories.Where(x => x.ParentID == 0).ToList();
        return categories;
    }


    public static bool CategoryInsert(Category category)
    {
        //metod statik olduğu için _context nesnesi doğrudan oluşturulamaz. Bu yüzden _context nesnesi oluşturulur yada using kullanılır.

        //E_CommerceDbContext _context = new E_CommerceDbContext(); YADA
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }


    public async Task<Category?> GetCategoryDetailsAsync(int? id)
    {
        Category? Category = await
                _context
                .categories
                .FirstOrDefaultAsync(
                    x => x.CategoryID == id
                    );

        return Category;
    }



    public static bool CategoryUpdate(Category category)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.Update(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public static bool CategoryDelete(int catID)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                Category? category = _context
                    .categories
                    .FirstOrDefault(x => x.CategoryID == catID);

                category!.IsActive = false;
               List<Category> subCategories = _context.categories.Where(x => x.ParentID == catID).ToList();


                foreach (var item in subCategories)
                {
                    item.IsActive = false;
                }

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