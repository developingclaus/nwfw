using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace nwfw.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string NwfwOrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime FulfillDate { get; set; }
    public virtual OrderType OrderType { get; set; }   
    public virtual OrderStatus OrderStatus { get; set; }   
    public virtual Customer Customer { get; set; }   
    public virtual Vendor Vendor { get; set; }   
    public virtual ICollection<OrderItem> OrderItems { get; set; } 
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }   
    
    public Order()
    {
      // this.OrderItems = new List<OrderItem>();
    }
  }
}
