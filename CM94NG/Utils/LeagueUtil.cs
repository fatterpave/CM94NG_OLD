using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM94NG.Models;

namespace CM94NG.Utils
{
    public class LeagueUtil
    {
        public static BindingList<LeagueTableModel> GetLeague(int level)
        {
            BindingList < LeagueTableModel > leagueList = new BindingList<LeagueTableModel>();
            foreach (var c in DataUtil._DIVISIONS[level].Clubs.Select((value, i) => new { i, value }))
            {
                LeagueTableModel league = new LeagueTableModel();
                league.Club = c.value.Name;
                league.No = c.i + 1;
                ClubSeason season = c.value.CurrentSeason;
                league.W = season.WinHome + season.WinAway;
                league.D = season.DrawHome + season.DrawAway;
                league.L = season.LossHome + season.LossAway;
                league.GF = season.GoalsForHome + season.GoalsForAway;
                league.GA = season.GoalsAgainstHome + season.GoalsAgainstAway;
                league.HW = season.WinHome;
                league.HD = season.DrawHome;
                league.HL = season.LossHome;
                league.HGF = season.GoalsForHome;
                league.HGA = season.GoalsAgainstHome;
                league.AW = season.WinAway;
                league.AD = season.DrawAway;
                league.AL = season.LossAway;
                league.AGF = season.GoalsForAway;
                league.AGA = season.GoalsAgainstAway;
                leagueList.Add(league);
            }
            return leagueList;
        } 
    }
}
