using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorBook { get; set; }
         public DbSet<BookPatron> BookPatron { get; set; }
         public DbSet<Patron> Patron { get; set; }


        public LibraryContext(DbContextOptions options) : base(options) { }
    

    }
}