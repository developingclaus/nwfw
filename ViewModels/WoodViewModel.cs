using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.ViewModels
{
  public class WoodViewModel
  {
    public int Id { get; set; }
    public string WoodName { get; set; }
    // public ICollection<ProductViewModel> Products { get; set; }        
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }    
  }
}
