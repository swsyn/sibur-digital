using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESModel
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Leader { get; set; }
        public Department Department { get; set; }
    }
}
