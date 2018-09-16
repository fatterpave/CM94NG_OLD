using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public PlayerPersonality Personality { get; set; }
        public PlayerPosition Position { get; set; }
        public PlayerContract Contract { get; set; }
        public PlayerAttributes Attributes { get; set; }
        public PlayerInjury Injury { get; set; }
        public List<PlayerHistory> History { get; set; }
        public decimal Average { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }

    }
}
