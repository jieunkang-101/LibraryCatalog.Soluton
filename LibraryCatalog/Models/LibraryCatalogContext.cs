using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalog.Models
{
  public class LibraryCatalogContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Author> Authors { get; set;}
    public DbSet<AuthorBook> AuthorBook { get; set; }
    public LibraryCatalogContext(DbContextOptions options) : base(options) { }
  }
}