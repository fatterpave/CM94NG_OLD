using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CM94NG.Models
{
    public class Division
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public List<Club> Clubs { get; set; }

    }
}
