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

    // public ActionResult Details(int id)
    // {
    //   // Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   // return View(thisItem);
    //   var thisItem = _db.Items
    //       .Include(item => item.Categories)
    //       .ThenInclude(join => join.Category)
    //       .FirstOrDefault(item => item.ItemId == id);
    //   return View(thisItem);

    // }

    // public ActionResult Edit(int id)
    // {
    //   var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult Edit(Item item, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //   }
    //   _db.Entry(item).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult AddCategory(int id)
    // {
    //   var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult AddCategory(Item item, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //   _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   return View(thisItem);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   _db.Items.Remove(thisItem);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult DeleteCategory(int joinId)
    // {
    //   var joinEntry = _db.CategoryItem.FirstOrDefault(entry => entry.CategoryItemId == joinId);
    //   _db.CategoryItem.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}