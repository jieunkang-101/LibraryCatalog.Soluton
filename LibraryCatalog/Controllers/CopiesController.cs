using LibraryCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryCatalog.Controllers
{
  public class CopiesController : Controller
  {
    private readonly LibraryCatalogContext _db;

    public CopiesController(LibraryCatalogContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Copies.ToList());
    }

    [HttpPost]
    public ActionResult Create (Copy copy)
    {
      _db.Copies.Add(copy);
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id = copy.BookId });
    }
  }
}    