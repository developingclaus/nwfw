using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string OrderStatusName { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        public OrderStatus()
        {
        }
    }
}
