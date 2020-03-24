using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalog.Models
{
  public class LibraryCatalogContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set;}
    public DbSet<AuthorBook> AuthorBook { get; set; }
    public LibraryCatalogContext(DbContextOptions options) : base(options) { }
  }
}