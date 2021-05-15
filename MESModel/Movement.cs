using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESModel
{
    public class Movement
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Department Source { get; set; }
        public Department Destination { get; set; }
        public DateTime MovementDate { get; set; }
        public Team Team { get; set; } // team that do movement
    }
}
