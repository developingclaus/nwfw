using System;
using System.Collections.Generic;

namespace nwfw.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string ProductName { get; set; }      
    public double ProductBasePrice { get; set; }  
    // public Wood Wood { get; set; }    
    // public ProductType ProductType { get; set; }    
    public ICollection<OrderItem> OrderItems { get; set; }    
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Product()
    {
    }
  }
}
