using Microsoft.AspNetCore.Mvc;

namespace LibraryCatalog.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}