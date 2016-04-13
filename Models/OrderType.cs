using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class OrderType
    {
        public int Id { get; set; }
        public string OrderTypeName { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        public OrderType()
        {
        }
    }
}
