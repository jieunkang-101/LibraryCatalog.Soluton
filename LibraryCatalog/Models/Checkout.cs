using System;
using System.Collections.Generic;

namespace LibraryCatalog.Models
{
  public class Checkout
  {
    public int CheckoutId { get; set; }
    public int PatronId { get; set; }
    public int CopyId { get; set; }

    public DateTime DueDate { get; set; }
    public bool Returned { get; set; } = false;
    public Patron Patron { get; set; }
    public Copy Copy { get; set; }
  }
}  