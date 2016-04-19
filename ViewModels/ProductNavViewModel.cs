using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.ViewModels
{
  public class ProductNavViewModel
  {
    // public int Id { get; set; }
    public string ProductName { get; set; }      
    public double ProductBasePrice { get; set; }  
    public virtual WoodViewModel Wood { get; set; }    
    public virtual ProductTypeViewModel ProductType { get; set; }
  }
}
