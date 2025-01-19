using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models;

public class Comment
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int CommentID { get; set; }
    public string UserID { get; set; }
    public int ProductID { get; set; }
    [StringLength(150)]
    public string? CommentText { get; set; }
    public DateTime? CommentDate { get; set; }
}
