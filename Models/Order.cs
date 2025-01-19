using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class Order
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int OrderID { get; set; }

    public DateTime OrderDate { get; set; }

    [StringLength(30)]
    public string? OrderGroupGUID { get; set; }

    public int UserID{ get; set; }

    public int ProductID { get; set; }


    // var UserOrder = Order.Where(x => x.UserID == User.UserID)
    public int Quantity { get; set; }
}