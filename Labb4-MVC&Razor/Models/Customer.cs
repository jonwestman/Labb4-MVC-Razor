using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4_MVC_Razor.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Phone { get; set; }
        ICollection<Book>? Books { get; set; }
    }
}
