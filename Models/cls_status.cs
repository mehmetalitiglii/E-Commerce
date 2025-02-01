using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Website_Project.Models;
public class cls_status
{

    E_CommerceDbContext _context = new E_CommerceDbContext();

    public async Task<List<Status>> GetStatusesAsync(int? id)
    {
        List<Status> statuses = await _context.statuses.ToListAsync();
        return statuses;
    }

    public static bool StatusInsert(Status status)
    {
        //metod statik olduğu için _context nesnesi doğrudan oluşturulamaz. Bu yüzden _context nesnesi oluşturulur yada using kullanılır.

        //E_CommerceDbContext _context = new E_CommerceDbContext(); YADA
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.statuses.Add(status);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }


    public async Task<Status?> GetStatusDetailsAsync(int? id)
    {
        Status? status = await
                _context
                .statuses
                .FirstOrDefaultAsync(
                    x => x.StatusID == id
                    );

        return status;
    }


    public static bool StatusUpdate(Status status)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                _context.Update(status);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public static bool StatusDelete(int stID)
    {
        using (E_CommerceDbContext _context = new())
        {
            try
            {
                Status? status = _context
                    .statuses
                    .FirstOrDefault(x => x.StatusID == stID);

                status!.IsActive = false;

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
