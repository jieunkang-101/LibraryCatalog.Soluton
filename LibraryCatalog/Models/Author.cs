using System.Collections.Generic;

namespace LibraryCatalog.Models
{
  public class Author
  {
    public Author()
    {
      this.Books = new HashSet<AuthorBook>();
    }

    public int AuthorId { get; set; }
    public string AuthorName { get; set; }  
    public ICollection<AuthorBook> Books { get; set; }
  }
}  