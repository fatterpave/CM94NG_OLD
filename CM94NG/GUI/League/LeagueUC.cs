using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM94NG.GUI.Components
{
    public partial class LeagueUC : UserControl
    {
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;
        public LeagueUC()
        {
            InitializeComponent();
            Location = new Point(0,100);
            btnLeagueExit.Click += OnExitButtonClicked;
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            //if (Visible && !Disposing) ;
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (OnUserControlButtonClicked != null)
                OnUserControlButtonClicked(this, e);
        }


        private void btnLeagueTables_Click(object sender, EventArgs e)
        {
            leagueTable1.BringToFront();
            leagueTable1.Show();
        }
    }
}
