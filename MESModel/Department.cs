using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESModel
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Parent { get; set; }
        public List<ProductAvailability> ProductAvailabilities { get; set; }
    }
}
