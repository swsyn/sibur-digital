using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESModel
{
    public class ProductAvailability
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Department Department { get; set; }
    }
}
