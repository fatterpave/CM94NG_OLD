using CM94NG.GUI.Components;

namespace CM94NG.GUI
{
    partial class CM94NG
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMain = new System.Windows.Forms.Label();
            this.mainUC = new MainMenuUC();
            this.leagueUC1 = new LeagueUC();
            this.SuspendLayout();
            // 
            // lblMain
            // 
            this.lblMain.BackColor = System.Drawing.Color.Transparent;
            this.lblMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.ForeColor = System.Drawing.Color.Blue;
            this.lblMain.Location = new System.Drawing.Point(6, 9);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(996, 51);
            this.lblMain.TabIndex = 0;
            this.lblMain.Text = "label1";
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMain.Click += new System.EventHandler(this.lblMain_Click);
            // 
            // mainUC
            // 
            this.mainUC.Location = new System.Drawing.Point(6, 63);
            this.mainUC.Name = "mainUC";
            this.mainUC.Size = new System.Drawing.Size(996, 583);
            this.mainUC.TabIndex = 1;
            this.mainUC.Tag = new System.Drawing.Size(996, 583);
            // 
            // leagueUC1
            // 
            this.leagueUC1.Location = new System.Drawing.Point(-3, 63);
            this.leagueUC1.Name = "leagueUC1";
            this.leagueUC1.Size = new System.Drawing.Size(996, 583);
            this.leagueUC1.TabIndex = 2;
            this.leagueUC1.Visible = false;
            // 
            // CM94NG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1005, 683);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.mainUC);
            this.Controls.Add(this.leagueUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(1025, 726);
            this.Name = "CM94NG";
            this.Text = "CM94NG v1.0";
            this.Load += new System.EventHandler(this.CM94NG_Load);
            this.Resize += new System.EventHandler(this.CM94NG_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMain;
        private MainMenuUC mainUC;
        private LeagueUC leagueUC1;
    }
}