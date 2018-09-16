using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM94NGEditor.Import
{
    public class CM94Position
    {
        public string hex { get; set; }
        public string secondaryHex { get; set; }
        public bool G { get; set; }
        public bool D { get; set; }
        public bool M { get; set; }
        public bool A { get; set; }
        public bool R { get; set; }
        public bool L { get; set; }
        public bool C { get; set; }
        public string descriptor { get; set; }
    }
}
