using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using nwfw.Models;

namespace nwfw.ViewModels
{
  public class CustomerNavViewModel
  {
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerCompanyName { get; set; }
  }
}
