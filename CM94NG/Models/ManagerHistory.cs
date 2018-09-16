using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class ManagerHistory
    {
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int LeaguePosition { get; set; }

    }
}
