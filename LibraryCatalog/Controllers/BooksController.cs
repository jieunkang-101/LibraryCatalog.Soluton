using LibraryCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalog.Controllers
{
  public class BooksController : Controller
  {
    private readonly LibraryCatalogContext _db;

    public BooksController(LibraryCatalogContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Books.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      ViewBag.Authors = _db.Authors.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Book book, int AuthorId)
    {
      _db.Books.Add(book);
      if (AuthorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
          .Include(book => book.Authors)
          .ThenInclude(join => join.Author)
          .FirstOrDefault(book => book.BookId == id);
      ViewBag.AvailableCopies = _db.Copies.Where(copy => copy.BookId == id && copy.Available == true).ToList();    
      return View(thisBook);

    }

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book, int AuthorId)
    {
      if (AuthorId != 0)
      {
        _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.Entry(book).State = EntityState.Modified;
      //_db.Books.Add(book);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddAuthor(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddAuthor(Book book, int AuthorId)
    {
      if (AuthorId != 0)
      {
      _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteAuthor(int joinId)
    {
      var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
      _db.AuthorBook.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult SearchBook(string search)
    {
      List<Book> model = _db.Books.ToList();
      if (!String.IsNullOrEmpty(serch))
      {
        model = model.Where(book => book.Title.ToLower().Contains(search.ToLower())).Select(book => book).ToList();
      }
      return View(model);
    }
  }
}


// public ActionResult Index()
// {
// // original LINQ query with .ToList()
// List<Category> model = _db.Categories.ToList();

// // using EF.Functions.Like() 
// List<Category> model = _db.Categories.Where(c => 
// EF.Functions.Like(c.Name, "h%")).ToList();

// // using the System.Linq.Ennumerable.Where() with String.Contains()
// List<Category> model = _db.Categories.Where(c => c.Name.Contains("fun")).ToList();

// // using the System.Linq.Ennumerable.Where() with String.StartsWith()
// List<Category> model = _db.Categories.Where(c => c.Name.StartsWith("h")).ToList();

// // using LINQ query expression AND // EF.Functions.Like()
// var model = (from c in _db.Categories
//             where EF.Functions.Like(c.Name, "h%")
//             select c)
//             .ToList();

// return View(model);
// }
