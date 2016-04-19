using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.ViewModels
{
  public class VendorViewModel
  {
    public int Id { get; set; }
    public string VendorFirstName { get; set; }
    public string VendorLastName { get; set; }
    public string VendorCompanyName { get; set; }
    public virtual ICollection<OrderViewModel> Orders { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
