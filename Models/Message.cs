using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class Message
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MessageID { get; set; }

    public int UserID { get; set; }

    public int ProductID { get; set; }

    public string? Content { get; set; }


}
