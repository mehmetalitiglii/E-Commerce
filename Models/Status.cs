using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Website_Project.Models
{
    public class Status
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusID { get; set; }

        [StringLength(100)]
        [Required]
        [DisplayName("Durum Adı")]
        public string? StatusName { get; set; }

        [DisplayName("Aktif-Deaktif")]
        public bool IsActive{ get; set; }
    }
}