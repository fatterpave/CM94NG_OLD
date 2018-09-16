using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class Club
    {
        public Club()
        {
            CurrentSeason = new ClubSeason();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Color PrimaryColor { get; set; }
        public Color SecondaryColor { get; set; }
        public int StadiumCapacity { get; set; }
        public string StadiumName { get; set; }
        public string NickName { get; set; }
        public Int64 Funds { get; set; }
        public Manager Manager { get; set; }
        public List<Player> Players { get; set; }
        public List<ClubSeason> PreviousSeasons { get; set; }
        public ClubSeason CurrentSeason { get; set; }
    }
}
