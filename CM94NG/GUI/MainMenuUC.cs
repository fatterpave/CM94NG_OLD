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
    public partial class MainMenuUC : UserControl
    {
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;
        public MainMenuUC()
        {
            InitializeComponent();
            btnContinue.Tag = new OrigButtonValues() {RowIndex=0,ColIndex = 0,Location = btnContinue.Location,Size=btnContinue.Size};
            btnLeague.Tag = new OrigButtonValues() {RowIndex=0,ColIndex = 2,Location = btnLeague.Location,Size=btnLeague.Size};
            btnFIxtures.Tag = new OrigButtonValues() {RowIndex=0,ColIndex = 3,Location = btnFIxtures.Location,Size=btnFIxtures.Size};
            btnBoard.Tag = new OrigButtonValues() {RowIndex=1,ColIndex = 3,Location = btnBoard.Location,Size=btnBoard.Size};
            btnFind.Tag = new OrigButtonValues() {RowIndex=1,ColIndex = 2,Location = btnFind.Location,Size=btnFind.Size};
            btnReports.Tag = new OrigButtonValues() {RowIndex=1,ColIndex = 1,Location = btnReports.Location,Size=btnReports.Size};
            btnClub.Tag = new OrigButtonValues() {RowIndex=1,ColIndex = 0,Location = btnClub.Location,Size=btnClub.Size};
            btnJobs.Tag = new OrigButtonValues( ){RowIndex=2,ColIndex = 0, Location = btnJobs.Location,Size=btnJobs.Size};
            btnOptions.Tag = new OrigButtonValues() {RowIndex=2,ColIndex = 2, Location = btnOptions.Location,Size=btnOptions.Size};
            btnSave.Tag = new OrigButtonValues() {RowIndex=2,ColIndex = 3, Location = btnSave.Location,Size=btnSave.Size};
            btnNational.Tag = new OrigButtonValues() {RowIndex=2,ColIndex = 1, Location = btnNational.Location,Size=btnNational.Size};
            this.Tag = this.Size;
            btnLeague.Click += OnLeagueButtonClicked;
        }

        public void FullScreen(Size windowSize)
        {
            if (windowSize.Width>0)
            {
                this.Size = windowSize;
                int width = windowSize.Width/4;
                int height = (windowSize.Height-100)/3;
                foreach (var butt in this.Controls.OfType<Button>())
                {
                    if (butt.Tag!=null)
                    {
                        OrigButtonValues orig = (OrigButtonValues) butt.Tag;
                        butt.Size = butt.Name=="btnContinue"?new Size(width*2-5,height-5) : new Size(width-5,height-5);
                        butt.Location = new Point(orig.ColIndex*width,orig.RowIndex*height);
                    }
                }
            }
            else
            {
                this.Size = (Size) this.Tag;
                foreach (var butt in this.Controls.OfType<Button>())
                {
                    if (butt.Tag!=null)
                    {
                        OrigButtonValues orig = (OrigButtonValues) butt.Tag;
                        butt.Size = orig.Size;
                        butt.Location = orig.Location;
                    }
                }
                
            }
        }

        private void OnLeagueButtonClicked(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (OnUserControlButtonClicked != null)
                OnUserControlButtonClicked(this, e);
        }

        public struct OrigButtonValues
        {
            public Size Size;
            public Point Location;
            public int ColIndex;
            public int RowIndex;
        }
    }
}
