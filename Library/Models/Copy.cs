using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Library.Models
{
    public class Copy
    {
        public Copy()
        {
            this.Patrons = new HashSet<CopyPatron>();
        }

        public int CopyId {get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book {get; set; }
        public virtual ApplicationUser User { get; set; }

        public ICollection<CopyPatron> Patrons { get;}

    }
}