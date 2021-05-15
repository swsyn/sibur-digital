using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESClient
{
    public class ProductOutputMovement
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string DestinationName { get; set; }
        public DateTime MovementDate { get; set; }
        public string TeamName { get; set; }
    }
}
