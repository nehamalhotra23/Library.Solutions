using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
  public class AuthorController : Controller
  {
    private readonly LibraryContext _db;

    public AuthorController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Author> model = _db.Authors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Author author)
    {
      _db.Authors.Add(author);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      List<AuthorBook> authorBooks = new List<AuthorBook>();
      authorBooks = _db.AuthorBook
        .Include(authorBook => authorBook.Book)
        .Where(authorBook => authorBook.AuthorId == id)
        .ToList();

      List<Book> books = new List<Book>();
      foreach(AuthorBook authorBook in authorBooks)
      {
        books.Add(authorBook.Book);
      }
      ViewBag.Books = books;
      Author thisAuthor = _db.Authors
          .FirstOrDefault(a => a.AuthorId == id);
      return View(thisAuthor);
    }

  }
}