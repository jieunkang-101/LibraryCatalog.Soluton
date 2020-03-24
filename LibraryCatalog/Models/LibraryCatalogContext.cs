using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalog.Models
{
  public class LibraryCatalogContext : IdentityDbContext<ApplicationUser>
  {
    
    public LibraryCatalogContext(DbContextOptions options) : base(options) { }
  }
}