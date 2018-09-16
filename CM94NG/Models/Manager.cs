using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Potential { get; set; }
        public int CurrentPotential { get; set; }
        public int PlayerInfluence { get; set; }
        public ManagerPersonality Personality { get; set; }
        public int auto { get; set; }//0=disabled -> 100 (best)
    }
}
