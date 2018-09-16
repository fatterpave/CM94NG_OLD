using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CM94NG.Models;

namespace CM94NGEditor
{
    public partial class CM94NGEdit : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        private Division currentChosenDivision = null;
        private Club currentChosenClub = null;
        private Player currentChosenPlayer = null;
        private Manager currentChosenManager = null;
        
        public CM94NGEdit()
        {
            InitializeComponent();
            DbDataService.Init();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvDiv.ListViewItemSorter = lvwColumnSorter;
            this.lvClub.ListViewItemSorter = lvwColumnSorter;
            this.lvPlayer.ListViewItemSorter = lvwColumnSorter;
            this.lvManager.ListViewItemSorter = lvwColumnSorter;
            this.lvLeagueDivisions.ListViewItemSorter = lvwColumnSorter;
            this.lvLeagueClubs.ListViewItemSorter = lvwColumnSorter;
            this.lvLeagueManagers.ListViewItemSorter = lvwColumnSorter;
            this.lvLeaguePlayers.ListViewItemSorter = lvwColumnSorter;
            comboPlayerPersonality.DataSource = Enum.GetValues(typeof (PlayerPersonality));
            comboManagerPersonality.DataSource = Enum.GetValues(typeof (ManagerPersonality));
        }

        #region menu

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit application?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CM94NG Files | *.cmng";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                string filepath = ofd.FileName;
                DbDataService.Init();
                if (DbDataService.Load(filepath))
                {
                    UpdateLeagueTree();
                    UpdateDivisionList();
                    UpdateClubList();
                    UpdatePlayerList();
                    UpdateManagerList();
                    UpdateLeagueDivisionList();
                    UpdateLeagueClubList();
                    UpdateLeaguePlayerList();
                    UpdateLeagueManagerList();
                    ShowStatusText(string.Format("Loaded {0} divisions, {1} clubs, {2} players and {3} managers.",DbDataService.CmData.Divisions.Count,DbDataService.CmData.Clubs.Count,DbDataService.CmData.Players.Count,DbDataService.CmData.Managers.Count));
                }
                else ShowStatusText("Error loading file.");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DbDataService.FilePath == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CM94NG Files | *.cmng";
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    if(DbDataService.SaveAs(sfd.FileName)) ShowStatusText("Saved as "+sfd.FileName);
                    else ShowStatusText("Error saving.");
                }
            }
            else
            {
                if (DbDataService.Save()) ShowStatusText("Saved."); 
                else ShowStatusText("Error saving.");          
            }
        }

        private void ShowStatusText(string text)
        {
            lblToolStrip.Text = text;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Erase all data and start new shit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DbDataService.Init();
                UpdateDivisionList();
                UpdateClubList();
                UpdatePlayerList();
                UpdateManagerList();
                UpdateLeagueDivisionList();
                UpdateLeagueTree();
                ShowStatusText("Erased all data.");
            }
        }

        private void importCM94DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CM94 JSON Files | *.json";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                DbDataService.Import(ofd.FileName);
                UpdateClubList();
                UpdatePlayerList();
                ShowStatusText(string.Format("Imported {0} clubs and {1} players.", DbDataService.CmData.Clubs.Count, DbDataService.CmData.Players.Count));
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CM94NG Files | *.cmng";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                if (DbDataService.SaveAs(sfd.FileName)) ShowStatusText("Saved as " + sfd.FileName);
                else ShowStatusText("Error saving.");
            }
        }

        private void exportToCM94NGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CM94NG Files | *.cmng";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                if (DbDataService.Export(sfd.FileName)) ShowStatusText("Saved as " + sfd.FileName);
                else ShowStatusText("Error saving.");
            }
        }

        #endregion
        #region club




        #endregion
        #region division
        private void btnDivSave_Click(object sender, EventArgs e)
        {

            if (txtDivName.Text.Length == 0)
            {
                errorDivName.SetError(txtDivName,"Name is empty");
                return;
            }

            int level = (int) numDivLevel.Value;
            if (DbDataService.CmData.Divisions.Any(d => d.Level == level) && (currentChosenDivision==null || currentChosenDivision.Level!=level ))
            {
                errorDivLevel.SetError(numDivLevel,"A division having level "+level+" already exists");
                return;
            }

            if (currentChosenDivision == null)
            {
                Division div = new Division() {Level = level, Name = txtDivName.Text};
                DbDataService.CmData.Divisions.Add(div);
            }
            else
            {
                Division item = DbDataService.CmData.Divisions.Single(d => d.Level == currentChosenDivision.Level);
                item.Level = level;
                item.Name = txtDivName.Text;

            }
            UpdateDivisionList();
            btnAddDiv_Click(sender,e);
        }
        
        private void UpdateDivisionList()
        {
            lvDiv.Items.Clear();
            foreach (var division in DbDataService.CmData.Divisions)
            {
                ListViewItem item = new ListViewItem(new []{division.Level.ToString(),division.Name});
                item.Tag = division;
                lvDiv.Items.Add(item);
            }
            UpdateLeagueDivisionList();
        }

        private void UpdateClubList()
        {
            lvClub.Items.Clear();
            foreach (var club in DbDataService.CmData.Clubs)
            {
                ListViewItem item = new ListViewItem(new[] { club.Name,club.City,club.StadiumCapacity.ToString(),club.Funds.ToString() });
                item.Tag = club;
                lvClub.Items.Add(item);
            }
            lblNoOfClubs.Text = DbDataService.CmData.Clubs.Count.ToString() + " clubs";
        }

        private void txtDivName_Enter(object sender, EventArgs e)
        {
            errorDivName.Clear();
        }

        private void numDivLevel_Enter(object sender, EventArgs e)
        {
            errorDivLevel.Clear();
        }

        private void btnAddDiv_Click(object sender, EventArgs e)
        {
            txtDivName.Text = "";
            numDivLevel.Value = DbDataService.CmData.Divisions.Count>0?DbDataService.CmData.Divisions.Max(d => d.Level) + 1:0;
            currentChosenDivision = null;
        }


        private void lvDiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDiv.SelectedIndices.Count > 0)
            {
                Division div = (Division) lvDiv.SelectedItems[0].Tag;
                txtDivName.Text = div.Name;
                numDivLevel.Value = div.Level;
                currentChosenDivision = div;
            }
        }

       
        private void btnRemoveDiv_Click(object sender, EventArgs e)
        {
            int selItem = lvDiv.SelectedItems.Count;
            if (selItem > 0)
            {
                Division div = (Division) lvDiv.SelectedItems[0].Tag;
                if (MessageBox.Show(String.Format("Delete division {0} ?", div.Name), "Confirm deletion",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbDataService.CmData.Divisions.Remove(div);
                    btnAddDiv_Click(sender,e);
                    UpdateDivisionList();
                }
            }
        }

        

        private void btnClubSave_Click(object sender, EventArgs e)
        {
            if (txtClubId.Text.Length == 0) currentChosenClub = null;

            if (txtClubName.Text.Length == 0)
            {
                errorClubName.SetError(txtClubName, "Name is empty");
                return;
            }

            if (txtClubCity.Text.Length == 0)
            {
                errorClubCIty.SetError(txtClubCity,"City name is empty");
                return;
            }

            int id = DbDataService.CmData.Clubs.Count>0?(DbDataService.CmData.Clubs.Max(c=>c.Id)+1):0;
            string name = txtClubName.Text;
            string city = txtClubCity.Text;
            string nick = txtClubNick.Text.Length > 0 ? txtClubNick.Text : "";
            Color primaryColor = lblCLubColorPrimary.BackColor;
            Color secondaryColor = lblClubCOlorSecondary.BackColor;
            int capacity = txtClubStCapacity.Text.Length>0?Convert.ToInt32(txtClubStCapacity.Text):1000;
            string stadium = txtClubStName.Text;
            int funds = txtClubFunds.Text.Length > 0 ? Convert.ToInt32(txtClubFunds.Text) : 1000;

            if (currentChosenClub == null)
            {
                Club c = new Club();
                c.Id = id;
                c.Name = name;
                c.City = city;
                c.NickName = nick;
                c.PrimaryColor = primaryColor;
                c.SecondaryColor = secondaryColor;
                c.StadiumCapacity = capacity;
                c.StadiumName = stadium;
                c.Funds = funds;
                txtClubId.Text = id.ToString();
                DbDataService.CmData.Clubs.Add(c);
                UpdateClubList();
            }
            else
            {
                Club c = DbDataService.CmData.Clubs.Single(cl => cl.Id == currentChosenClub.Id);
                c.Id = id;
                c.Name = name;
                c.City = city;
                c.NickName = nick;
                c.PrimaryColor = primaryColor;
                c.SecondaryColor = secondaryColor;
                c.StadiumCapacity = capacity;
                c.StadiumName = stadium;
                c.Funds = funds;
                UpdateClubList();
            }
            btnClubAdd_Click(sender,e);
            ShowStatusText(String.Format("Club {0} saved.",name));
        }

        private void txtClubName_Enter(object sender, EventArgs e)
        {
            errorClubName.Clear();
        }

        private void txtClubCity_Enter(object sender, EventArgs e)
        {
            errorClubCIty.Clear();
        }

        private void lblCLubColorPrimary_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                lblCLubColorPrimary.BackColor = colorDialog1.Color;
            }
        }

        private void lblClubCOlorSecondary_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                lblClubCOlorSecondary.BackColor = colorDialog1.Color;
            }
        }

        private void lvClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClub.SelectedIndices.Count > 0)
            {
                Club club = (Club)lvClub.SelectedItems[0].Tag;
                currentChosenClub = club;
                txtClubId.Text = club.Id.ToString();
                txtClubName.Text = club.Name;
                txtClubCity.Text = club.City;
                txtClubNick.Text = club.NickName;
                lblCLubColorPrimary.BackColor = club.PrimaryColor;
                lblClubCOlorSecondary.BackColor = club.SecondaryColor;
                txtClubStName.Text = club.StadiumName;
                txtClubStCapacity.Text = club.StadiumCapacity.ToString();
                txtClubFunds.Text = club.Funds.ToString();
            }
        }

        private void btnClubAdd_Click(object sender, EventArgs e)
        {
            currentChosenClub = null;
            txtClubId.Text = "";
            txtClubName.Text = "";
            txtClubCity.Text = "";
            txtClubNick.Text = "";
            lblCLubColorPrimary.BackColor = Color.FromName("Control");
            lblClubCOlorSecondary.BackColor = Color.FromName("Control");
            txtClubStName.Text = "";
            txtClubStCapacity.Text = "";
            txtClubFunds.Text = "";
        }

        private void btnClubRemove_Click(object sender, EventArgs e)
        {
            int selItem = lvClub.SelectedItems.Count;
            if (selItem > 0)
            {
                Club club = (Club)lvClub.SelectedItems[0].Tag;
                if (MessageBox.Show(String.Format("Delete club {0} ?", club.Name), "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbDataService.CmData.Clubs.Remove(club);
                    btnClubAdd_Click(sender, e);
                    UpdateClubList();
                }
            }
        }
        #endregion
        #region player
        private void cbxPlayerRandomName_CheckedChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            int firstNamesLength = DbDataService.CmData.FirstNames.Count;
            int lastNamesLength = DbDataService.CmData.LastNames.Count;
            if (firstNamesLength == 0 || lastNamesLength == 0)
            {
                MessageBox.Show("No names loaded.");
                return;
            }
            txtPlayerLast.Text = DbDataService.CmData.LastNames[random.Next(0, lastNamesLength - 1)];
            txtPlayerFirst.Text = DbDataService.CmData.FirstNames[random.Next(0, firstNamesLength - 1)];
        }

        private void btnPlayerSave_Click(object sender, EventArgs e)
        {
            if (txtPlayerFirst.Text.Length == 0 || txtPlayerLast.Text.Length == 0)
            {
                errorPlayerName.SetError(label13,"Missing player name");
                return;
            }

            if (!cbxPlayerPosGK.Checked && !cbxPlayerPosDef.Checked && !cbxPlayerPosMid.Checked &&
                !cbxPlayerPosAtt.Checked && !cbxPLayerPosCenter.Checked && !cbxPlayerPosLeft.Checked &&
                !cbxPlayerPosRight.Checked)
            {
                errorPLayerPosition.SetError(label17,"Player has no position");
                return;
            }

            int id = DbDataService.CmData.Players.Count > 0 ? (DbDataService.CmData.Players.Max(c => c.Id) + 1) : 0;
            string firstname = txtPlayerFirst.Text;
            string lastname = txtPlayerLast.Text;
            DateTime birth = dtpPlayerBirth.Value;
            PlayerPersonality personality;
            Enum.TryParse<PlayerPersonality>(comboPlayerPersonality.SelectedValue.ToString(), out personality);

            PlayerPosition pos = new PlayerPosition()
            {
                Goalkeeper = cbxPlayerPosGK.Checked,
                Defender = cbxPlayerPosDef.Checked,
                Midfield = cbxPlayerPosMid.Checked,
                Forward = cbxPlayerPosAtt.Checked,
                Center = cbxPLayerPosCenter.Checked,
                Right = cbxPlayerPosRight.Checked,
                Left = cbxPlayerPosLeft.Checked
            };

            PlayerContract contract = new PlayerContract()
            {
                StartDate = dtpPlayerContractStart.Value,
                Expiry = dtpPlayerContractExpiry.Value,
                Salary = txtPlayerContractSalary.Text.Length>0?Convert.ToInt32(txtPlayerContractSalary.Text):1000
            };

            PlayerAttributes attr = new PlayerAttributes()
            {
                Stamina = (int)numPlayerAttrStamina.Value,
                Passing = (int)numPlayerAttrPassing.Value,
                Heading = (int)numPlayerAttrHeading.Value,
                Tackling = (int)numPlayerAttrTackling.Value,
                Strength = (int)numPlayerAttrStrength.Value,
                Pace = (int)numPlayerAttrPace.Value,
                Presence = (int)numPlayerAttrPresence.Value,
                Persevarance = (int)numPlayerAttrPerseverance.Value,
                Versatility = (int)numPlayerAttrVersatility.Value,
                Agility = (int)numPlayerAttrAgility.Value,
                Goalscoring = (int)numPlayerAttrGoalscoring.Value,
                Shot = (int)numPlayerAttrShot.Value,
                Dribbling = (int)numPlayerAttrDribbling.Value,
                Potential = (int)numPlayerAttrPotential.Value,
                CurrentPotential = (int)numPlayerAttrCurrPotential.Value,
                Development = (int)numPlayerAttrDevelopment.Value,
                InjuryProne = (int)numPlayerAttrInjuryProne.Value,
                Aggression = (int)numPlayerAttrAggression.Value,
                GoalKeeping = (int)numPlayerAttrGoalkeeping.Value,
            };

            if (currentChosenPlayer != null)
            {
                Player p = DbDataService.CmData.Players.Single(pl => pl.Id == currentChosenPlayer.Id);
                p.FirstName = firstname;
                p.LastName = lastname;
                p.BirthDate = birth;
                p.Personality = personality;
                p.Position = pos;
                p.Contract = contract;
                p.Attributes = attr;
                UpdatePlayerList();
            }
            else
            {
                Player p = new Player();
                p.Id = id;
                p.FirstName = firstname;
                p.LastName = lastname;
                p.BirthDate = birth;
                p.Personality = personality;
                p.Position = pos;
                p.Contract = contract;
                p.Attributes = attr;
                txtPlayerId.Text = id+"";
                DbDataService.CmData.Players.Add(p);
                UpdatePlayerList();
            }
            errorPLayerPosition.Clear();
            errorPlayerName.Clear();
            btnPlayerAdd_Click(sender,e);
            ShowStatusText(String.Format("Player {0} saved.", firstname+" "+lastname));
        }
        private void UpdatePlayerList()
        {
            lvPlayer.Items.Clear();
            foreach (var player in DbDataService.CmData.Players)
            {
                ListViewItem item = new ListViewItem(new[] { player.LastName+", "+player.FirstName, Util.GetAge(player.BirthDate).ToString(),Util.GetPositionString(player.Position),player.Attributes.Potential.ToString(),player.Attributes.CurrentPotential.ToString(),player.Attributes.Stamina.ToString(),player.Attributes.Pace.ToString(),player.Attributes.Shot.ToString() });
                item.Tag = player;
                lvPlayer.Items.Add(item);
            }
            lblNoOfPlayers.Text = DbDataService.CmData.Players.Count.ToString() + " players";
        }

        

        private void lvPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPlayer.SelectedIndices.Count > 0)
            {
                Player player = (Player)lvPlayer.SelectedItems[0].Tag;
                currentChosenPlayer = player;
                txtPlayerId.Text = player.Id.ToString();
                txtPlayerLast.Text = player.LastName;
                txtPlayerFirst.Text = player.FirstName;
                dtpPlayerBirth.Value = player.BirthDate;
                cbxPlayerPosGK.Checked = player.Position.Goalkeeper;
                cbxPlayerPosDef.Checked = player.Position.Defender;
                cbxPlayerPosMid.Checked = player.Position.Midfield;
                cbxPlayerPosAtt.Checked = player.Position.Forward;
                cbxPlayerPosRight.Checked = player.Position.Right;
                cbxPLayerPosCenter.Checked = player.Position.Center;
                cbxPlayerPosLeft.Checked = player.Position.Left;
                comboPlayerPersonality.SelectedItem = player.Personality;
                dtpPlayerContractExpiry.Value = player.Contract.Expiry;
                dtpPlayerContractStart.Value = player.Contract.StartDate;
                txtPlayerContractSalary.Text = player.Contract.Salary.ToString();
                numPlayerAttrStamina.Value = player.Attributes.Stamina;
                numPlayerAttrPassing.Value = player.Attributes.Passing;
                numPlayerAttrHeading.Value = player.Attributes.Heading;
                numPlayerAttrTackling.Value = player.Attributes.Tackling;
                numPlayerAttrStrength.Value = player.Attributes.Strength;
                numPlayerAttrPace.Value = player.Attributes.Pace;
                numPlayerAttrPresence.Value = player.Attributes.Presence;
                numPlayerAttrPerseverance.Value = player.Attributes.Persevarance;
                numPlayerAttrVersatility.Value = player.Attributes.Versatility;
                numPlayerAttrAgility.Value = player.Attributes.Agility;
                numPlayerAttrGoalscoring.Value = player.Attributes.Goalscoring;
                numPlayerAttrShot.Value = player.Attributes.Shot;
                numPlayerAttrDribbling.Value = player.Attributes.Dribbling;
                numPlayerAttrPotential.Value = player.Attributes.Potential;
                numPlayerAttrCurrPotential.Value = player.Attributes.CurrentPotential;
                numPlayerAttrDevelopment.Value = player.Attributes.Development;
                numPlayerAttrInjuryProne.Value = player.Attributes.InjuryProne;
                numPlayerAttrAggression.Value = player.Attributes.Aggression;
                numPlayerAttrGoalkeeping.Value = player.Attributes.GoalKeeping;
            }
        }

        private void btnPlayerRemove_Click(object sender, EventArgs e)
        {
            int selItem = lvPlayer.SelectedItems.Count;
            if (selItem > 0)
            {
                Player player = (Player)lvPlayer.SelectedItems[0].Tag;
                if (MessageBox.Show(string.Format("Delete player {0} ?", player.FirstName+" "+player.LastName), "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbDataService.CmData.Players.Remove(player);
                    btnPlayerAdd_Click(sender, e);
                    UpdatePlayerList();
                }
            }
        }

        private void btnPlayerAdd_Click(object sender, EventArgs e)
        {
            currentChosenPlayer = null;
            txtPlayerId.Text = "";
            txtPlayerFirst.Text = "";
            txtPlayerLast.Text = "";
            dtpPlayerBirth.Value = new DateTime(1990,1,1);
            cbxPlayerPosGK.Checked = false;
            cbxPlayerPosDef.Checked = false;
            cbxPlayerPosMid.Checked = false;
            cbxPlayerPosAtt.Checked = false;
            cbxPlayerPosRight.Checked = false;
            cbxPLayerPosCenter.Checked = false;
            cbxPlayerPosLeft.Checked = false;
            comboPlayerPersonality.SelectedIndex = 0;
            dtpPlayerContractExpiry.Value = DateTime.Now;
            dtpPlayerContractStart.Value = DateTime.Now;
            txtPlayerContractSalary.Text = "";
            numPlayerAttrStamina.Value = 10;
            numPlayerAttrPassing.Value = 10;
            numPlayerAttrHeading.Value = 10;
            numPlayerAttrTackling.Value = 10;
            numPlayerAttrStrength.Value = 10;
            numPlayerAttrPace.Value = 10;
            numPlayerAttrPresence.Value = 10;
            numPlayerAttrPerseverance.Value = 10;
            numPlayerAttrVersatility.Value = 10;
            numPlayerAttrAgility.Value = 10;
            numPlayerAttrGoalscoring.Value = 10;
            numPlayerAttrShot.Value = 10;
            numPlayerAttrDribbling.Value = 10;
            numPlayerAttrPotential.Value = 100;
            numPlayerAttrCurrPotential.Value = 100;
            numPlayerAttrDevelopment.Value = 10;
            numPlayerAttrInjuryProne.Value = 10;
            numPlayerAttrAggression.Value = 10;
            numPlayerAttrGoalkeeping.Value = 10;
            errorPLayerPosition.Clear();
            errorPlayerName.Clear();
        }
        #endregion
        #region manager
        private void UpdateManagerList()
        {
            lvManager.Items.Clear();
            foreach (var manager in DbDataService.CmData.Managers)
            {
                ListViewItem item = new ListViewItem(new[] { manager.LastName + ", " + manager.FirstName, Util.GetAge(manager.BirthDate).ToString(), manager.Potential.ToString(),manager.CurrentPotential.ToString(),manager.PlayerInfluence.ToString() });
                item.Tag = manager;
                lvManager.Items.Add(item);
            }
            lblNoOfManagers.Text = DbDataService.CmData.Managers.Count.ToString() + " managers";
        }
        

        private void btnManagerSave_Click(object sender, EventArgs e)
        {
            if (txtManagerFirst.Text.Length == 0)
            {
                errorManagerFIrstName.SetError(label44,"Missing manager first name");
                return;
            }

            if (txtManagerLast.Text.Length == 0)
            {
                errorManagerFIrstName.SetError(label46, "Missing manager last name");
                return;
            }

            int id = DbDataService.CmData.Managers.Count > 0 ? (DbDataService.CmData.Managers.Max(c => c.Id) + 1) : 0;
            string firstname = txtManagerFirst.Text;
            string lastname = txtManagerLast.Text;
            DateTime birth = dtpManBirth.Value;
            int currpot = (int) numManagerCurrPotential.Value;
            int pot = (int) numManagerPotential.Value;
            int inflence = (int) numManagerPlInfluence.Value;
            ManagerPersonality personality;
            Enum.TryParse<ManagerPersonality>(comboManagerPersonality.SelectedValue.ToString(), out personality);

            if (currentChosenManager == null)
            {
                Manager manager = new Manager();
                manager.Id = id;
                manager.FirstName = firstname;
                manager.LastName = lastname;
                manager.BirthDate = birth;
                manager.CurrentPotential = currpot;
                manager.Potential = pot;
                manager.PlayerInfluence = inflence;
                manager.Personality = personality;
                txtManagerId.Text = id.ToString();
                DbDataService.CmData.Managers.Add(manager);
                UpdateManagerList();
            }
            else
            {
                Manager manager = DbDataService.CmData.Managers.Single(pl => pl.Id == currentChosenManager.Id);
                manager.FirstName = firstname;
                manager.LastName = lastname;
                manager.BirthDate = birth;
                manager.CurrentPotential = currpot;
                manager.Potential = pot;
                manager.PlayerInfluence = inflence;
                manager.Personality = personality;
                UpdateManagerList();
            }

            errorManagerFIrstName.Clear();
            errorManagerLastName.Clear();
            btnManagerAdd_Click(sender,e);
            ShowStatusText(String.Format("Manager {0} saved.", firstname + " " + lastname));
        }

        private void lvManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvManager.SelectedIndices.Count > 0)
            {
                Manager manager = (Manager) lvManager.SelectedItems[0].Tag;
                currentChosenManager = manager;
                txtManagerId.Text = manager.Id.ToString();
                txtManagerFirst.Text = manager.FirstName;
                txtManagerLast.Text = manager.LastName;
                dtpManBirth.Value = manager.BirthDate;
                numManagerCurrPotential.Value = manager.CurrentPotential;
                numManagerPotential.Value = manager.Potential;
                numManagerPlInfluence.Value = manager.PlayerInfluence;
                comboManagerPersonality.SelectedItem = manager.Personality;

            }
        }

        private void btnManagerAdd_Click(object sender, EventArgs e)
        {
            currentChosenManager = null;
            txtManagerId.Text = "";
            txtManagerFirst.Text = "";
            txtManagerLast.Text = "";
            dtpManBirth.Value = new DateTime(1960,1,1);
            numManagerCurrPotential.Value = 100;
            numManagerPotential.Value = 100;
            numManagerPlInfluence.Value = 10;
            comboManagerPersonality.SelectedIndex = 0;
            errorManagerFIrstName.Clear();
            errorManagerLastName.Clear();
        }

        private void btnManagerRemove_Click(object sender, EventArgs e)
        {
            int selItem = lvManager.SelectedItems.Count;
            if (selItem > 0)
            {
                Manager manager = (Manager)lvManager.SelectedItems[0].Tag;
                if (MessageBox.Show(string.Format("Delete manager {0} ?", manager.FirstName + " " + manager.LastName), "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbDataService.CmData.Managers.Remove(manager);
                    btnManagerAdd_Click(sender, e);
                    UpdateManagerList();
                }
            }
        }
        private void cbxManagerRandomName_CheckedChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            int firstNamesLength = DbDataService.CmData.FirstNames.Count;
            int lastNamesLength = DbDataService.CmData.LastNames.Count;
            if (firstNamesLength == 0 || lastNamesLength == 0)
            {
                MessageBox.Show("No names loaded.");
                return;
            }
            txtManagerLast.Text = DbDataService.CmData.LastNames[random.Next(0, lastNamesLength - 1)];
            txtManagerFirst.Text = DbDataService.CmData.FirstNames[random.Next(0, firstNamesLength - 1)];
        }

        #endregion

        /*************************
        **   LEAGUE EDITOR
        **
        ************************/

        #region listUpdates
        private void UpdateLeagueTree()
        {
            TreeNode root = tvLeague.Nodes[0];
            root.Nodes.Clear();
            root.Text = "Divisions [" + DbDataService.CmData.LeagueData.Count + "]";
            foreach (Division division in DbDataService.CmData.LeagueData)
            {
                int noOfClubs = 0;
                if (division.Clubs != null) noOfClubs = division.Clubs.Count;
                TreeNode divisionNode = new TreeNode(division.Name + " (level " + division.Level + ") [" + noOfClubs + "]");
                divisionNode.Tag = division;
                root.Nodes.Add(divisionNode);
                if (noOfClubs > 0)
                {
                    foreach (Club club in division.Clubs)
                    {
                        int noOfPlayers = 0;
                        if (club.Players != null) noOfPlayers = club.Players.Count;
                        TreeNode clubNode = new TreeNode(club.Name + " ["+noOfPlayers+"]");
                        clubNode.Tag = club;
                        divisionNode.Nodes.Add(clubNode);
                        if (noOfPlayers > 0)
                        {
                            foreach (Player player in club.Players)
                            {
                                TreeNode playerNode = new TreeNode(player.LastName+" "+player.FirstName);
                                playerNode.Tag = player;
                                clubNode.Nodes.Add(playerNode);
                            }
                        }
                        if (club.Manager != null)
                        {
                            TreeNode managerNode = new TreeNode("[Manager] "+club.Manager.FirstName+" "+club.Manager.LastName);
                            managerNode.Tag = club.Manager;
                            clubNode.Nodes.Add(managerNode);
                        }
                    }
                }

            }
        }

        private void UpdateLeagueDivisionList()
        {
            lvLeagueDivisions.Items.Clear();
            foreach (var division in DbDataService.CmData.Divisions)
            {
                if (!Util.HasDivision(tvLeague.Nodes[0], division))
                {
                    ListViewItem item = new ListViewItem(new[] {division.Level.ToString(), division.Name});
                    item.Tag = division;
                    lvLeagueDivisions.Items.Add(item);
                }
            }
        }

        private void UpdateLeagueClubList()
        {
            lvLeagueClubs.Items.Clear();
            foreach (var club in DbDataService.CmData.Clubs)
            {
                if (!Util.HasClub(tvLeague.Nodes[0], club))
                {
                    ListViewItem item = new ListViewItem(new[] { club.Name });
                    item.Tag = club;
                    lvLeagueClubs.Items.Add(item);
                }
            }
        }

        private void UpdateLeaguePlayerList()
        {
            lvLeaguePlayers.Items.Clear();
            foreach (var player in DbDataService.CmData.Players)
            {
                if (!Util.HasPlayer(tvLeague.Nodes[0], player))
                {
                    ListViewItem item = new ListViewItem(new[] { player.LastName+ " "+player.FirstName,player.Attributes.CurrentPotential.ToString(),player.Attributes.Potential.ToString(),Util.GetAge(player.BirthDate).ToString() });
                    item.Tag = player;
                    lvLeaguePlayers.Items.Add(item);
                }
            }
        }

        private void UpdateLeagueManagerList()
        {
            lvLeagueManagers.Items.Clear();
            foreach (var manager in DbDataService.CmData.Managers)
            {
                if (!Util.HasManager(tvLeague.Nodes[0], manager))
                {
                    ListViewItem item = new ListViewItem(new[] { manager.LastName + " " + manager.FirstName, manager.CurrentPotential.ToString(), manager.Potential.ToString(), Util.GetAge(manager.BirthDate).ToString() });
                    item.Tag = manager;
                    lvLeagueManagers.Items.Add(item);
                }
            }
        }

        #endregion

        #region dragndrop

        private void lvLeagueDivisions_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (node != null && node.Level > 0)
            {   
                if (node.Tag.GetType() == typeof(Division))
                {
                    tvLeague.Nodes.Remove(node);
                    Division d = (Division)node.Tag;
                    DbDataService.CmData.LeagueData.Remove(d);
                    UpdateLeaguePlayerList();
                    UpdateLeagueClubList();
                    UpdateLeagueDivisionList();
                    UpdateLeagueTree();
                }              
            }
        }

        private void tvLeague_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode nodeToDropIn = this.tvLeague.GetNodeAt(this.tvLeague.PointToClient(new Point(e.X, e.Y)));

            foreach (ListViewItem item in ((ListView.SelectedListViewItemCollection) e.Data.GetData(typeof (ListView.SelectedListViewItemCollection))))
            {
                if (item.Tag.GetType() == typeof (Division) && (nodeToDropIn.FirstNode==null || nodeToDropIn.Level==0))
                {
                    Division div = (Division) item.Tag;
                    lvLeagueDivisions.Items[item.Index].Remove();
                    DbDataService.CmData.LeagueData.Add(div);
                }   
                else if (item.Tag.GetType() == typeof (Club) && nodeToDropIn.Level==1)
                {
                    Division div = (Division) nodeToDropIn.Tag;
                    Club club = (Club) item.Tag;
                    lvLeagueClubs.Items[item.Index].Remove();
                    Division chosenDiv = DbDataService.CmData.LeagueData.Single(d => d.Level == div.Level);
                    if(chosenDiv.Clubs==null) chosenDiv.Clubs = new List<Club>();
                    chosenDiv.Clubs.Add(club);
                }
                else if (item.Tag.GetType() == typeof (Player) && nodeToDropIn.Level == 2)
                {
                    Division div = (Division)nodeToDropIn.Parent.Tag;
                    Club club = (Club) nodeToDropIn.Tag;
                    Player player = (Player) item.Tag;
                    lvLeaguePlayers.Items[item.Index].Remove();
                    Club chosenClub =
                        DbDataService.CmData.LeagueData.Single(d => d.Level == div.Level)
                            .Clubs.Single(c => c.Id == club.Id);
                    if(chosenClub.Players==null)chosenClub.Players = new List<Player>();
                    chosenClub.Players.Add(player);
                }
                else if (item.Tag.GetType() == typeof (Manager) && nodeToDropIn.Level == 2)
                {
                    Division div = (Division)nodeToDropIn.Parent.Tag;
                    Club club = (Club)nodeToDropIn.Tag;
                    Manager tempManager = club.Manager;
                    Manager manager = (Manager)item.Tag;
                    lvLeagueManagers.Items[item.Index].Remove();
                    if (tempManager != null)
                    {
                        ListViewItem itemMan = new ListViewItem(new[] { tempManager.LastName + " " + tempManager.FirstName, tempManager.CurrentPotential.ToString(), tempManager.Potential.ToString(), Util.GetAge(tempManager.BirthDate).ToString() });
                        itemMan.Tag = tempManager;
                        lvLeagueManagers.Items.Add(item);
                    }
                    
                    Club chosenClub =
                        DbDataService.CmData.LeagueData.Single(d => d.Level == div.Level)
                            .Clubs.Single(c => c.Id == club.Id);
                    chosenClub.Manager = manager;
                }
            }
            UpdateLeagueTree();
            tvLeague.Nodes[0].ExpandAll();
        }
        private void lvLeagueManagers_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (node != null && node.Level > 0)
            {
                if (node.Tag.GetType() == typeof(Manager))
                {
                    Division d = (Division)node.Parent.Parent.Tag;
                    Club c = (Club)node.Parent.Tag;
                    Manager m = (Manager)node.Tag;
                    DbDataService.CmData.LeagueData.Single(div => div.Level == d.Level)
                        .Clubs.Single(cl => cl.Id == c.Id)
                        .Manager = null;
                    tvLeague.Nodes.Remove(node);
                    UpdateLeagueManagerList();
                    UpdateLeagueTree();
                }
            }
        }
        private void lvLeagueClubs_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (node != null && node.Level > 0)
            {
                if (node.Tag.GetType() == typeof(Club))
                {
                    Division d = (Division) node.Parent.Tag;
                    Club c = (Club)node.Tag;
                    DbDataService.CmData.LeagueData.Single(div => div.Level == d.Level).Clubs.Remove(c);
                    tvLeague.Nodes.Remove(node);
                    UpdateLeagueClubList();
                    UpdateLeagueTree();
                }  
            }
        }
        private void lvLeaguePlayers_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (node != null && node.Level > 0)
            {
                if (node.Tag.GetType() == typeof(Player))
                {
                    Division d = (Division) node.Parent.Parent.Tag;
                    Club c = (Club)node.Parent.Tag;
                    Player p = (Player)node.Tag;
                    DbDataService.CmData.LeagueData.Single(div => div.Level == d.Level)
                        .Clubs.Single(cl => cl.Id == c.Id)
                        .Players.Remove(p);
                    tvLeague.Nodes.Remove(node);
                    UpdateLeaguePlayerList();
                    UpdateLeagueTree();
                }          
            }
        }
        #endregion

        #region columnClick
        private void lvLeagueDivisions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvLeagueDivisions.Sort();
        }

        private void lvDiv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvDiv.Sort();
        }


        private void lvClub_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvClub.Sort();
        }

        private void lvPlayer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvPlayer.Sort();
        }

        private void lvManager_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvManager.Sort();
        }
        private void lvLeagueManagers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvLeagueManagers.Sort();
        }
        private void lvLeagueClubs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvLeagueClubs.Sort();
        }
        private void lvLeaguePlayers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvLeaguePlayers.Sort();
        }
        #endregion

        #region dragEvents
        private void lvLeagueDivisions_MouseDown(object sender, MouseEventArgs e)
        {
            this.lvLeagueDivisions.DoDragDrop(this.lvLeagueDivisions.SelectedItems, DragDropEffects.Move);
        }

        private void lvLeagueDivisions_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvLeague_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lvLeagueDivisions_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvLeague_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvLeague_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void lvLeagueManagers_MouseDown(object sender, MouseEventArgs e)
        {
            this.lvLeagueManagers.DoDragDrop(this.lvLeagueManagers.SelectedItems, DragDropEffects.Move);
        }
        private void lvLeagueClubs_MouseDown(object sender, MouseEventArgs e)
        {
            this.lvLeagueClubs.DoDragDrop(this.lvLeagueClubs.SelectedItems, DragDropEffects.Move);
        }
        private void lvLeaguePlayers_MouseDown(object sender, MouseEventArgs e)
        {
            this.lvLeaguePlayers.DoDragDrop(this.lvLeaguePlayers.SelectedItems, DragDropEffects.Move);
        }
        private void lvLeagueManagers_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void lvLeagueClubs_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void lvLeaguePlayers_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void lvLeagueManagers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lvLeagueClubs_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lvLeaguePlayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }







        #endregion

        
    }
}
