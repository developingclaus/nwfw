using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.ViewModels
{
  public class ProductTypeViewModel
  {
    public int Id { get; set; }
    public string ProductTypeName { get; set; }
    // public ICollection<ProductViewModel> Products { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
