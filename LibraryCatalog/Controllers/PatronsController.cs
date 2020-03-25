using LibraryCatalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibraryCatalog.Controllers
{
  [Authorize]
  public class PatronsController : Controller
  {
    private readonly LibraryCatalogContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatronsController(UserManager<ApplicationUser> userManager, LibraryCatalogContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userPatron = _db.Patrons.Where(entry => entry.User.Id == currentUser.Id);
      return View(userPatron);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Patron patron)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      patron.User = currentUser;
      _db.Patrons.Add(patron);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPatron = _db.Patrons
          .Include(patron => patron.Copies)
          .ThenInclude(join => join.Copy)
          .FirstOrDefault(patron => patron.PatronId == id);
      return View(thisPatron);
    }
  }
}    