using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM94NG.Models;

namespace CM94NGEditor
{
    public class CMData
    {
        public List<Division> Divisions { get; set; }
        public List<Club> Clubs { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Player> Players { get; set; }
        public List<string> FirstNames { get; set; }
        public List<string> LastNames { get; set; }

        public List<Division> LeagueData { get; set; }

        public CMData()
        {
            Divisions = new List<Division>();
            Clubs = new List<Club>();
            Managers = new List<Manager>();
            Players = new List<Player>();
            FirstNames = new List<string>();
            LastNames = new List<string>();
            LeagueData = new List<Division>();
        }
    }
}
