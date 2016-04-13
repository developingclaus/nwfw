using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public double DiscountPercent { get; set; }
        public int Quantity { get; set; }
        // public Order Order { get; set; }
        // public Product Product { get; set; }
        
        public OrderItem()
        {
        }
    }
}
