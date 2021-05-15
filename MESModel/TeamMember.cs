using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESModel
{
    public class TeamMember
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Team Team { get; set; }
    }
}
