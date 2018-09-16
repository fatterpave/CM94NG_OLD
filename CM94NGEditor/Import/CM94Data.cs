using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM94NG;
using CM94NG.Models;

namespace CM94NGEditor.Import
{
    public class CM94Data
    {
        public List<string> clubs { get; set; }
        public List<CM94PlayerName> playerNames { get; set; }
        public List<CM94Player> players { get; set; }

    }
}
