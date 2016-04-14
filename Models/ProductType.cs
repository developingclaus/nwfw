using System;
using System.Collections.Generic;

namespace nwfw.Models
{
  public class ProductType
  {
    public int Id { get; set; }
    public string ProductTypeName { get; set; }
    public ICollection<Product> Products { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ProductType()
    {
    }
  }
}
