using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.ViewModels
{
  public class OrderItemViewModel
  {
    public int Id { get; set; }
    public double DiscountPercent { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
  }
}
