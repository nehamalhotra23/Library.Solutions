using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Models
{
    public class BookPatron
    {
        public int BookPatronId { get; set; }
        public int BookId { get; set; } 
        public int PatronId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
       [ForeignKey("PatronId")]
        public Patron Patron { get; set; }
    }
}