using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NG.Models
{
    public enum Injury
    {
        NONE=0,
        HAMSTRING = 1,
        BROKEN_LEG = 2
    }

    static class InjuryHelper
    {
        public static String GetString(this Injury injury)
        {
            switch (injury)
            {
                case Injury.BROKEN_LEG:
                    return "Broken leg";
                case Injury.HAMSTRING:
                    return "Pulled hamstring";
                default:
                    return "N/A";
            }
        }
    }
}
