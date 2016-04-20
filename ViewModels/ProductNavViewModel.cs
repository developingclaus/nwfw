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
    public virtual WoodNavViewModel Wood { get; set; }    
    public virtual ProductTypeNavViewModel ProductType { get; set; }
  }
}
