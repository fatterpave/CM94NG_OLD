using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CM94NG.GUI.Components;
using CM94NG.Models;

namespace CM94NG.GUI
{
    public partial class CM94NG : Form
    {
        public CM94NG()
        {
            InitializeComponent();
            lblMain.Tag = lblMain.Width;
            Init();
        }

        private void Init()
        {

            
            mainUC.OnUserControlButtonClicked += OnLeagueButtonClicked;
            leagueUC1.OnUserControlButtonClicked += OnExitButtonClicked;
        }

        private void CM94NG_Load(object sender, EventArgs e)
        {
            //PlayerInjury inj = PlayerInjury.BROKEN_LEG;
            //MessageBox.Show(inj.GetString()+"");
            //MessageBox.Show((int)inj + "");
        }

        private void CM94NG_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                lblMain.Width = Screen.PrimaryScreen.Bounds.Width - 10;
                mainUC.FullScreen(new Size(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.Size = new Size(1025,726);
                lblMain.Width = (int)lblMain.Tag;
                mainUC.FullScreen(new Size(0,0));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region callbacks

        private void OnLeagueButtonClicked(object sender, EventArgs e)
        {
            // Handle event from here
            mainUC.Hide();
            leagueUC1.Show();
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            leagueUC1.Hide();
            mainUC.Show();
        }


        #endregion

        private void lblMain_Click(object sender, EventArgs e)
        {
            mainUC.Show();
        }
    }
}
