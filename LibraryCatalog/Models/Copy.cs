using System.Collections.Generic;

namespace LibraryCatalog.Models
{
  public class Copy
  {
    public int CopyId {get;set;}
    public int BookId {get;set;}
    public bool Available {get; set;} = true;
    public Book Book { get; set; }
  }
}