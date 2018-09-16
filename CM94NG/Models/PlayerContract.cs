using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class PlayerContract
    {
        public DateTime Expiry { get; set; }
        public Int64 Salary { get; set; }
        public DateTime StartDate { get; set; }
        public int Auto { get; set; }
    }
}
