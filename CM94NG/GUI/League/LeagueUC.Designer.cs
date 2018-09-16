using CM94NG.GUI.League;
using CM94NG.GUI.Components;

namespace CM94NG.GUI.Components
{
    partial class LeagueUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leagueTable1 = new LeagueTable();
            this.btnLeagueGoalscorers = new CMSubMenuButton();
            this.btnLeagueGroupTables = new CMSubMenuButton();
            this.btnLeagueTables = new CMSubMenuButton();
            this.btnLeagueExit = new CMSubMenuButton();
            this.SuspendLayout();
            // 
            // leagueTable1
            // 
            this.leagueTable1.Location = new System.Drawing.Point(19, 0);
            this.leagueTable1.Name = "leagueTable1";
            this.leagueTable1.Size = new System.Drawing.Size(977, 583);
            this.leagueTable1.TabIndex = 4;
            this.leagueTable1.Visible = false;
            // 
            // btnLeagueGoalscorers
            // 
            this.btnLeagueGoalscorers.BackColor = System.Drawing.Color.Silver;
            this.btnLeagueGoalscorers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeagueGoalscorers.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeagueGoalscorers.ForeColor = System.Drawing.Color.White;
            this.btnLeagueGoalscorers.Location = new System.Drawing.Point(19, 239);
            this.btnLeagueGoalscorers.Name = "btnLeagueGoalscorers";
            this.btnLeagueGoalscorers.Size = new System.Drawing.Size(495, 54);
            this.btnLeagueGoalscorers.TabIndex = 3;
            this.btnLeagueGoalscorers.Text = "Top goalscorers";
            this.btnLeagueGoalscorers.UseVisualStyleBackColor = false;
            // 
            // btnLeagueGroupTables
            // 
            this.btnLeagueGroupTables.BackColor = System.Drawing.Color.Silver;
            this.btnLeagueGroupTables.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeagueGroupTables.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeagueGroupTables.ForeColor = System.Drawing.Color.White;
            this.btnLeagueGroupTables.Location = new System.Drawing.Point(19, 168);
            this.btnLeagueGroupTables.Name = "btnLeagueGroupTables";
            this.btnLeagueGroupTables.Size = new System.Drawing.Size(495, 54);
            this.btnLeagueGroupTables.TabIndex = 2;
            this.btnLeagueGroupTables.Text = "Group tables";
            this.btnLeagueGroupTables.UseVisualStyleBackColor = false;
            // 
            // btnLeagueTables
            // 
            this.btnLeagueTables.BackColor = System.Drawing.Color.Silver;
            this.btnLeagueTables.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeagueTables.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeagueTables.ForeColor = System.Drawing.Color.White;
            this.btnLeagueTables.Location = new System.Drawing.Point(19, 95);
            this.btnLeagueTables.Name = "btnLeagueTables";
            this.btnLeagueTables.Size = new System.Drawing.Size(495, 54);
            this.btnLeagueTables.TabIndex = 1;
            this.btnLeagueTables.Text = "League tables";
            this.btnLeagueTables.UseVisualStyleBackColor = false;
            this.btnLeagueTables.Click += new System.EventHandler(this.btnLeagueTables_Click);
            // 
            // btnLeagueExit
            // 
            this.btnLeagueExit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLeagueExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeagueExit.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeagueExit.ForeColor = System.Drawing.Color.White;
            this.btnLeagueExit.Location = new System.Drawing.Point(19, 25);
            this.btnLeagueExit.Name = "btnLeagueExit";
            this.btnLeagueExit.Size = new System.Drawing.Size(495, 54);
            this.btnLeagueExit.TabIndex = 0;
            this.btnLeagueExit.Text = "Exit";
            this.btnLeagueExit.UseVisualStyleBackColor = false;
            // 
            // LeagueUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.leagueTable1);
            this.Controls.Add(this.btnLeagueGoalscorers);
            this.Controls.Add(this.btnLeagueGroupTables);
            this.Controls.Add(this.btnLeagueTables);
            this.Controls.Add(this.btnLeagueExit);
            this.Name = "LeagueUC";
            this.Size = new System.Drawing.Size(996, 583);
            this.ResumeLayout(false);

        }

        #endregion

        private CMSubMenuButton btnLeagueExit;
        private CMSubMenuButton btnLeagueTables;
        private CMSubMenuButton btnLeagueGroupTables;
        private CMSubMenuButton btnLeagueGoalscorers;
        private LeagueTable leagueTable1;
    }
}
