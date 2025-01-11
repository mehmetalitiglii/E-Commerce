using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class User
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int UserID { get; set; }

    [Required]
    [StringLength(50)]

    public string? NameSurname { get; set; }

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(100)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public string? Telephone { get; set; }


    public string? InvoicesAddress { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? Active { get; set; }


}
