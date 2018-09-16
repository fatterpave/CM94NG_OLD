using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class PlayerHistory
    {
        public int ClubId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Average { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
