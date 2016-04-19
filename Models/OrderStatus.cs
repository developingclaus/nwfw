using System;
using System.Collections.Generic;

namespace nwfw.Models
{
  public class OrderStatus
  {
    public int Id { get; set; }
    public string OrderStatusName { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public OrderStatus()
    {
      // this.Orders = new List<Order>();
    }
  }
}
