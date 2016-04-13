using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public ICollection<Product> Products { get; set; }
        
        public ProductType()
        {
        }
    }
}
