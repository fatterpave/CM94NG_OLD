using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CM94NG.Models;
using CM94NG.Utils;

namespace CM94NG.GUI.League
{
    public partial class LeagueTable : UserControl
    {
        public LeagueTable()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            this.divisionBindingSource.DataSource = typeof(LeagueTableModel);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible && !Disposing)
            {
                dataGridView1.DataSource = LeagueUtil.GetLeague(0);
            }
        }

        private void btnExitTable_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("llk");
        }
    }
}
