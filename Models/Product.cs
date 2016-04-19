using System;
using System.Collections.Generic;

namespace nwfw.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string ProductName { get; set; }      
    public double ProductBasePrice { get; set; }  
    public virtual Wood Wood { get; set; }    
    public virtual ProductType ProductType { get; set; }    
    public virtual ICollection<OrderItem> OrderItems { get; set; }    
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Product()
    {
      // this.OrderItems = new List<OrderItem>();
    }
  }
}
