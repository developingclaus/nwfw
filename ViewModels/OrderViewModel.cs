using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.ViewModels
{
  public class OrderViewModel
  {
    public int Id { get; set; }
    public string NwfwOrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime FulfillDate { get; set; }    
    public virtual OrderStatusNavViewModel OrderStatus { get; set; }
    public virtual CustomerNavViewModel Customer { get; set; }  
    public virtual VendorNavViewModel Vendor { get; set; } 
    public virtual ICollection<OrderItemViewModel> OrderItems { get; set; } 
  }
}
