using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class ClubSeason
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int LeagueLevel { get; set; }
        public CupStage LeagueCup { get; set; }
        public CupStage FaCup { get; set; }
        public CupStage EuropaLeague { get; set; }
        public CupStage ChampionsLegue { get; set; }
        public int WinHome { get; set; }
        public int DrawHome { get; set; }
        public int LossHome { get; set; }
        public int WinAway { get; set; }
        public int DrawAway { get; set; }
        public int LossAway { get; set; }
        public int GoalsForHome { get; set; }
        public int GoalsAgainstHome { get; set; }
        public int GoalsForAway { get; set; }
        public int GoalsAgainstAway { get; set; }
    }
}
