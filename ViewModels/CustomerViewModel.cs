using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.ViewModels
{
  public class CustomerViewModel
  {
    public int Id { get; set; }
    [StringLength(100)]
    public string CustomerFirstName { get; set; }
    [StringLength(100)]
    public string CustomerLastName { get; set; }
    [StringLength(100)]
    public string CustomerCompanyName { get; set; }
    public ICollection<Order> Orders { get; set; }
  }
}
