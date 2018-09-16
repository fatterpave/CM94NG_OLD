using CM94NG.Models;

namespace CM94NG.GUI.League
{
    partial class LeagueTable
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDivMinus = new System.Windows.Forms.Button();
            this.btnDivPlus = new System.Windows.Forms.Button();
            this.btnExitTable = new System.Windows.Forms.Button();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clubDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.divisionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.clubDataGridViewTextBoxColumn,
            this.matchesDataGridViewTextBoxColumn,
            this.wDataGridViewTextBoxColumn,
            this.dDataGridViewTextBoxColumn,
            this.lDataGridViewTextBoxColumn,
            this.gFDataGridViewTextBoxColumn,
            this.gADataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.divisionBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(996, 531);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // btnDivMinus
            // 
            this.btnDivMinus.BackColor = System.Drawing.Color.Red;
            this.btnDivMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDivMinus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivMinus.ForeColor = System.Drawing.Color.Yellow;
            this.btnDivMinus.Location = new System.Drawing.Point(0, 540);
            this.btnDivMinus.Name = "btnDivMinus";
            this.btnDivMinus.Size = new System.Drawing.Size(156, 43);
            this.btnDivMinus.TabIndex = 1;
            this.btnDivMinus.Text = "-DIV";
            this.btnDivMinus.UseVisualStyleBackColor = false;
            // 
            // btnDivPlus
            // 
            this.btnDivPlus.BackColor = System.Drawing.Color.Red;
            this.btnDivPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDivPlus.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivPlus.ForeColor = System.Drawing.Color.Yellow;
            this.btnDivPlus.Location = new System.Drawing.Point(840, 540);
            this.btnDivPlus.Name = "btnDivPlus";
            this.btnDivPlus.Size = new System.Drawing.Size(156, 43);
            this.btnDivPlus.TabIndex = 2;
            this.btnDivPlus.Text = "DIV+";
            this.btnDivPlus.UseVisualStyleBackColor = false;
            // 
            // btnExitTable
            // 
            this.btnExitTable.BackColor = System.Drawing.Color.Blue;
            this.btnExitTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExitTable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitTable.ForeColor = System.Drawing.Color.White;
            this.btnExitTable.Location = new System.Drawing.Point(162, 540);
            this.btnExitTable.Name = "btnExitTable";
            this.btnExitTable.Size = new System.Drawing.Size(672, 43);
            this.btnExitTable.TabIndex = 3;
            this.btnExitTable.Text = "EXIT";
            this.btnExitTable.UseVisualStyleBackColor = false;
            this.btnExitTable.Click += new System.EventHandler(this.btnExitTable_Click);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 46;
            // 
            // clubDataGridViewTextBoxColumn
            // 
            this.clubDataGridViewTextBoxColumn.DataPropertyName = "Club";
            this.clubDataGridViewTextBoxColumn.HeaderText = "Club";
            this.clubDataGridViewTextBoxColumn.Name = "clubDataGridViewTextBoxColumn";
            this.clubDataGridViewTextBoxColumn.ReadOnly = true;
            this.clubDataGridViewTextBoxColumn.ToolTipText = "Club name";
            this.clubDataGridViewTextBoxColumn.Width = 53;
            // 
            // matchesDataGridViewTextBoxColumn
            // 
            this.matchesDataGridViewTextBoxColumn.DataPropertyName = "Matches";
            this.matchesDataGridViewTextBoxColumn.HeaderText = "Matches";
            this.matchesDataGridViewTextBoxColumn.Name = "matchesDataGridViewTextBoxColumn";
            this.matchesDataGridViewTextBoxColumn.ReadOnly = true;
            this.matchesDataGridViewTextBoxColumn.Width = 73;
            // 
            // wDataGridViewTextBoxColumn
            // 
            this.wDataGridViewTextBoxColumn.DataPropertyName = "W";
            this.wDataGridViewTextBoxColumn.HeaderText = "W";
            this.wDataGridViewTextBoxColumn.Name = "wDataGridViewTextBoxColumn";
            this.wDataGridViewTextBoxColumn.ReadOnly = true;
            this.wDataGridViewTextBoxColumn.ToolTipText = "Won";
            this.wDataGridViewTextBoxColumn.Width = 43;
            // 
            // dDataGridViewTextBoxColumn
            // 
            this.dDataGridViewTextBoxColumn.DataPropertyName = "D";
            this.dDataGridViewTextBoxColumn.HeaderText = "D";
            this.dDataGridViewTextBoxColumn.Name = "dDataGridViewTextBoxColumn";
            this.dDataGridViewTextBoxColumn.ReadOnly = true;
            this.dDataGridViewTextBoxColumn.ToolTipText = "Drawn";
            this.dDataGridViewTextBoxColumn.Width = 40;
            // 
            // lDataGridViewTextBoxColumn
            // 
            this.lDataGridViewTextBoxColumn.DataPropertyName = "L";
            this.lDataGridViewTextBoxColumn.HeaderText = "L";
            this.lDataGridViewTextBoxColumn.Name = "lDataGridViewTextBoxColumn";
            this.lDataGridViewTextBoxColumn.ReadOnly = true;
            this.lDataGridViewTextBoxColumn.ToolTipText = "Lost";
            this.lDataGridViewTextBoxColumn.Width = 38;
            // 
            // gFDataGridViewTextBoxColumn
            // 
            this.gFDataGridViewTextBoxColumn.DataPropertyName = "GF";
            this.gFDataGridViewTextBoxColumn.HeaderText = "GF";
            this.gFDataGridViewTextBoxColumn.Name = "gFDataGridViewTextBoxColumn";
            this.gFDataGridViewTextBoxColumn.ReadOnly = true;
            this.gFDataGridViewTextBoxColumn.ToolTipText = "Goals For";
            this.gFDataGridViewTextBoxColumn.Width = 46;
            // 
            // gADataGridViewTextBoxColumn
            // 
            this.gADataGridViewTextBoxColumn.DataPropertyName = "GA";
            this.gADataGridViewTextBoxColumn.HeaderText = "GA";
            this.gADataGridViewTextBoxColumn.Name = "gADataGridViewTextBoxColumn";
            this.gADataGridViewTextBoxColumn.ReadOnly = true;
            this.gADataGridViewTextBoxColumn.ToolTipText = "Goals Against";
            this.gADataGridViewTextBoxColumn.Width = 47;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Points";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            this.pointsDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointsDataGridViewTextBoxColumn.ToolTipText = "Points";
            this.pointsDataGridViewTextBoxColumn.Width = 61;
            // 
            // divisionBindingSource
            // 
            this.divisionBindingSource.DataSource = typeof(LeagueTableModel);
            // 
            // LeagueTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExitTable);
            this.Controls.Add(this.btnDivPlus);
            this.Controls.Add(this.btnDivMinus);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LeagueTable";
            this.Size = new System.Drawing.Size(996, 583);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.divisionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource divisionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn winHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drawHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lossHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winAwayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drawAwayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lossAwayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsForHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsAgainstHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsForAwayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalsAgainstAwayDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnDivMinus;
        private System.Windows.Forms.Button btnDivPlus;
        private System.Windows.Forms.Button btnExitTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matchesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
    }
}
