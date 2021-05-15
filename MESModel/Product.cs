using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESModel
{
    // Instance of Product Type, e.g. "Airplane Wing #346"
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductAvailability> ProductAvailabilities { get; set; }
    }
}
