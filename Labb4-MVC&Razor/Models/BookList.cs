using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb4_MVC_Razor.Models
{
    public class BookList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookListId { get; set; }
        [ForeignKey(nameof(book))]
        [DisplayName("Book")]
        public int FK_BookId { get; set; }
        public virtual Book? book { get; set; }
        [ForeignKey(nameof(customer))]
        [DisplayName("Customer")]
        public int FK_CustomerId { get; set; }
        public virtual Customer? customer { get; set; }
        [DisplayName("Due date")]
        public DateTime ReturnDate { get; set; }
        [DisplayName("Date returned")]
		public DateTime DateReturned { get; set; }
        [DisplayName("Is the Book returned?")]
		public bool IsReturned { get; set; }
	}
}
