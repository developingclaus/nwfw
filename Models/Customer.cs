using System;
using System.Collections.Generic;

namespace nwfw.Models
{
    public class Customer
  {
    public int Id { get; set; }
    public string CustomerFirstName { get; set; } 
    public string CustomerLastName { get; set; }
    public string CustomerCompanyName { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    
    public Customer()
    {
      // this.Orders = new List<Order>();
    }
  }
}
