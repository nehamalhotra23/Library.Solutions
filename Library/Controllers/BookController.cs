using System;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager; //new line

        //updated constructor
        public BookController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userBooks = _db.Books.Where(entry => entry.User.Id == currentUser.Id);
            return View(userBooks);
        }

        public ActionResult Create()
        {
            // ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
            // ViewBag.Author2Id = new SelectList(_db.Authors, "AuthorId", "Name");
            // ViewBag.Author3Id = new SelectList(_db.Authors, "AuthorId", "Name");
            return View();
        }


        // [HttpPost]
        // public async Task<ActionResult> Create(Book book, int AuthorId, int Author2Id, int Author3Id )
        // {
        //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //     var currentUser = await _userManager.FindByIdAsync(userId);
        //     book.User = currentUser;
        //     _db.Books.Add(book);
        //     if ( AuthorId != 0)
        //     {
        //         _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
        //     }
        //     if(Author2Id != 0)
        //     {
        //         _db.AuthorBook.Add(new AuthorBook() { AuthorId = Author2Id, BookId = book.BookId }); 
        //     }
        //      if(Author3Id != 0)
        //     {
        //         _db.AuthorBook.Add(new AuthorBook() { AuthorId = Author3Id, BookId = book.BookId }); 
        //     }
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
        [HttpPost]
        public async Task<ActionResult> Create(Book book, string Author1, string Author2, string Author3)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            book.User = currentUser;
            _db.Books.Add(book);
            _db.SaveChanges();
            
            List<string> authors = new List<string>();
            authors.Add(Author1);
            authors.Add(Author2);
            authors.Add(Author3);
           
            foreach(string author in authors)
            {
                if (author != null)
                {
                    Author authorObj;
                    int authorId;
                    if(_db.Authors.Contains(new Author() { Name = author}))
                    {
                        authorObj = _db.Authors.FirstOrDefault(Author => Author.Name == author);
                        authorId = authorObj.AuthorId;
                    } 
                    else 
                    {
                        var newAuthor = new Author();
                        _db.Authors.Add(new Author() { Name = author}); // add author to database
                        _db.SaveChanges();
                        authorObj = _db.Authors.FirstOrDefault(Author => Author.Name == author);
                        authorId = authorObj.AuthorId;
                    }
                    _db.AuthorBook.Add(new AuthorBook() {AuthorId = authorId, BookId = book.BookId});                    
                }
            }
            

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // var currentUser = await _userManager.FindByIdAsync(userId);
            // // book.User = currentUser;
            List<AuthorBook> authorBooks = new List<AuthorBook>();
            authorBooks = _db.AuthorBook
                .Include(authorBook => authorBook.Author)
                .Where(authorBook => authorBook.BookId == id)
                .ToList();
            List<Author> authors = new List<Author>();

            foreach (AuthorBook authorBook in authorBooks)
            {
                authors.Add(authorBook.Author);
            }
            ViewBag.Authors = authors;
            Book thisBook = _db.Books
                .Include(book => book.Authors)
                .FirstOrDefault(book => book.BookId == id);
            return View(thisBook);
        }
    }
}