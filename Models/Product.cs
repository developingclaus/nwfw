using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }      
        public double ProductBasePrice { get; set; }  
        // public Wood Wood { get; set; }    
        // public ProductType ProductType { get; set; }    
        public ICollection<OrderItem> OrderItems { get; set; }    
            
        public Product()
        {
        }
    }
}
