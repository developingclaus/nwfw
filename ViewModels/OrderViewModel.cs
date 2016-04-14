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
    public ICollection<OrderItem> OrderItems { get; set; } 
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }   
  }
}
