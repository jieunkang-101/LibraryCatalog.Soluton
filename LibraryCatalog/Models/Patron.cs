using System.Collections.Generic;

namespace LibraryCatalog.Models
{
  public class Patron
  {
    public Patron()
    {
      this.Copies = new HashSet<Checkout>();
    }

    public int PatronId { get; set; }
    public string PatronName { get; set; }
    public ApplicationUser User { get; set; }
    public ICollection<Checkout> Copies { get; }
  }
}  