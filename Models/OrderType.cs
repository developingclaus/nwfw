using System;
using System.Collections.Generic;

namespace nwfw.Models
{
  public class OrderType
  {
    public int Id { get; set; }
    public string OrderTypeName { get; set; }
    public ICollection<Order> Orders { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public OrderType()
    {
    }
  }
}
