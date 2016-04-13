using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string NwfwOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime FulfillDate { get; set; }
        // public OrderType OrderType { get; set; }   
        // public OrderStatus OrderStatus { get; set; }   
        // public Customer Customer { get; set; }   
        // public Vendor Vendor { get; set; }   
        public ICollection<OrderItem> OrderItems { get; set; }    

        
        public Order()
        {
        }
    }
}
