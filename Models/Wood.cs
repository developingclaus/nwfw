using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nwfw.Models
{
    public class Wood
    {
        public int Id { get; set; }
        public string WoodName { get; set; }
        public ICollection<Product> Products { get; set; }        
        
        public Wood()
        {
        }
    }
}
