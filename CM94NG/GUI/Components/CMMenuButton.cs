using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM94NG.GUI.Components
{
    public class CMMenuButton : Button
    {
        public CMMenuButton()
        {
            this.BackColor = Color.Blue;
            this.Size = new Size(230,175);
            this.ForeColor = Color.Yellow;
            this.Font = new Font("Calibri",28);
            this.FlatStyle = FlatStyle.Popup;
        }
    }
}
