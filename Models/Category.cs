using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class Category
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID { get; set; }
    public int ParentID { get; set; }

    [StringLength(50, ErrorMessage = "Maksimum 50 karakter girebilirsiniz.")]
    [Required(ErrorMessage = "Kategori Adı Zorunlu Alan")]
    [DisplayName("Kategori Adı")]
    public string? CategoryName { get; set; }

    [DisplayName("Aktif-Pasif")]
    public bool IsActive { get; set; }

}