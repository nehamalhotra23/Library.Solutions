using System.Collections.Generic;

namespace Library.Models
{
  public class Author
    {
        public Author()
        {
            this.Books = new HashSet<AuthorBook>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<AuthorBook> Books { get; set; }


        public override bool Equals(System.Object otherAuthor)
        {
            if (!(otherAuthor is Author))
            {
                return false;
            }
            else
            {
                Author newAuthor = (Author) otherAuthor;
                bool nameEquality = (this.Name == newAuthor.Name);
                return nameEquality;
            }
        }
    }
}