using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerCompanyName { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        public Customer()
        {
        }
    }
}
