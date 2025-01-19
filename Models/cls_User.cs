using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website_Project.Models;

public class cls_User
{
    E_CommerceDbContext _context = new E_CommerceDbContext();
    public async Task<User?> LoginControl(User user)
    {
        User? usr = await _context
            .users
            .FirstOrDefaultAsync(u => 
                u.Email == user.Email && 
                u.Password == user.Password && 
                u.IsAdmin == true && 
                u.Active == true);

        return usr;
    }


}