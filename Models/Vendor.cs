using System;
using System.Collections.Generic;

namespace nwfw.Models
{
  public class Vendor
  {
    public int Id { get; set; }
    public string VendorFirstName { get; set; }
    public string VendorLastName { get; set; }
    public string VendorCompanyName { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Vendor()
    {
      // this.Orders = new List<Order>();
    }
  }
}
