using System.Collections.Generic;

namespace LibraryCatalog.Models
{
  public class Book
  {
    public Book()
    {
      this.Authors = new HashSet<AuthorBook>();
      this.Copies = new HashSet<Copy>();
    }

    public int BookId { get; set; }
    public string Title { get; set; }

    public ICollection<AuthorBook> Authors { get; set; }
    public ICollection<Copy> Copies { get; set; }
  }
}