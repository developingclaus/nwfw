using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.ViewModels
{
  public class ProductViewModel
  {
    public int Id { get; set; }
    public string ProductName { get; set; }      
    public double ProductBasePrice { get; set; }  
    public WoodViewModel Wood { get; set; }    
    public ProductTypeViewModel ProductType { get; set; }    
    public ICollection<OrderItemViewModel> OrderItems { get; set; }    
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
