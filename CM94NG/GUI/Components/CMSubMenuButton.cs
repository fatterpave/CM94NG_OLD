using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM94NG.GUI.Components
{
    public class CMSubMenuButton : Button
    {
        public CMSubMenuButton()
        {
            this.BackColor = System.Drawing.Color.Silver;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(495, 54);
            this.Text = "cmSubMenuButton1";
            this.UseVisualStyleBackColor = false;
        }
    }
}
