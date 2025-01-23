using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_Commerce_Website_Project.Models;

public class cls_category
{
    E_CommerceDbContext _context = new E_CommerceDbContext();


    #region GET METHODS 

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

    #endregion


    #region POST METHODS


    #endregion

}