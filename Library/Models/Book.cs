using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<AuthorBook>();
            this.Copies = new HashSet<CopyPatron>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public virtual ApplicationUser User { get; set; }

    
        public ICollection<AuthorBook> Authors { get;}
        public ICollection<CopyPatron> Copies { get;}

    }
}