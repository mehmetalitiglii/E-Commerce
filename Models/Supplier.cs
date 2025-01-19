using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class Supplier
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int SupplierID { get; set; }
    [Required]
    [StringLength(100)]
    public string? BrandName { get; set; }

    public string? PhotoPath { get; set; }

    public bool? IsActive { get; set; }
}