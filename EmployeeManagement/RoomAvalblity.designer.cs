namespace EmployeeManagement
{
    partial class RoomAvalblity
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
            this.RoomGrid = new System.Windows.Forms.DataGridView();
            this.RoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FloorNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RoomGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // RoomGrid
            // 
            this.RoomGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RoomGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoomGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomID,
            this.RoomType,
            this.FloorNo,
            this.BedType,
            this.Status,
            this.Cost});
            this.RoomGrid.Location = new System.Drawing.Point(21, 1);
            this.RoomGrid.Name = "RoomGrid";
            this.RoomGrid.Size = new System.Drawing.Size(760, 378);
            this.RoomGrid.TabIndex = 2;
            // 
            // RoomID
            // 
            this.RoomID.DataPropertyName = "RoomID";
            this.RoomID.HeaderText = "Room ID";
            this.RoomID.Name = "RoomID";
            // 
            // RoomType
            // 
            this.RoomType.DataPropertyName = "RoomType";
            this.RoomType.HeaderText = "Room Type";
            this.RoomType.Name = "RoomType";
            // 
            // FloorNo
            // 
            this.FloorNo.DataPropertyName = "FloorNo";
            this.FloorNo.HeaderText = "Floor No";
            this.FloorNo.Name = "FloorNo";
            // 
            // BedType
            // 
            this.BedType.DataPropertyName = "BedType";
            this.BedType.HeaderText = "Bed Type";
            this.BedType.Name = "BedType";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Cost
            // 
            this.Cost.DataPropertyName = "Cost";
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // RoomAvalblity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 374);
            this.Controls.Add(this.RoomGrid);
            this.Name = "RoomAvalblity";
            this.Text = "RoomAvalblity";
            this.Load += new System.EventHandler(this.RoomAvalblity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RoomGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FloorNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
    }
}