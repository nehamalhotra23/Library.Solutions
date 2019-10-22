using System.ComponentModel.DataAnnotations.Schema;
namespace Library.Models
{
  public class AuthorBook
    {       
        public int AuthorBookId { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}