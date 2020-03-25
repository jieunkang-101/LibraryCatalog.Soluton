using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalog.Models
{
  public class LibraryCatalogContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Author> Authors { get; set;}
    public DbSet<Book> Books { get; set; }
    public DbSet<AuthorBook> AuthorBook { get; set; }
    public DbSet<Copy> Copies { get; set; }
    public DbSet<Checkout> Checkouts { get;set; }
    public DbSet<Patron> Patrons { get;set; }
    public LibraryCatalogContext(DbContextOptions options) : base(options) { }
  }
}