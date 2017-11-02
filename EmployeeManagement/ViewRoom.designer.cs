namespace EmployeeManagement
{
    partial class Add_Room
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RoomGrid = new System.Windows.Forms.DataGridView();
            this.RoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FloorNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maxperson = new System.Windows.Forms.ComboBox();
            this.Bed_Type = new System.Windows.Forms.ComboBox();
            this.Floor_Num = new System.Windows.Forms.ComboBox();
            this.Room_Type = new System.Windows.Forms.ComboBox();
            this.room_id = new System.Windows.Forms.ComboBox();
            this.Statuscb = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Costs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RoomGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Room Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Floor Num";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(608, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bed Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(608, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(608, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MylaiFixTSC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(631, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "Rooms Details";
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
            this.RoomGrid.Location = new System.Drawing.Point(-5, 216);
            this.RoomGrid.Name = "RoomGrid";
            this.RoomGrid.Size = new System.Drawing.Size(1275, 427);
            this.RoomGrid.TabIndex = 1;
            this.RoomGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoomGrid_CellClick);
            this.RoomGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.maxperson);
            this.panel1.Controls.Add(this.Bed_Type);
            this.panel1.Controls.Add(this.Floor_Num);
            this.panel1.Controls.Add(this.Room_Type);
            this.panel1.Controls.Add(this.room_id);
            this.panel1.Controls.Add(this.RoomGrid);
            this.panel1.Controls.Add(this.Statuscb);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.Costs);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(47, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 648);
            this.panel1.TabIndex = 2;
            // 
            // maxperson
            // 
            this.maxperson.FormattingEnabled = true;
            this.maxperson.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.maxperson.Location = new System.Drawing.Point(726, 112);
            this.maxperson.Name = "maxperson";
            this.maxperson.Size = new System.Drawing.Size(71, 21);
            this.maxperson.TabIndex = 13;
            // 
            // Bed_Type
            // 
            this.Bed_Type.FormattingEnabled = true;
            this.Bed_Type.Items.AddRange(new object[] {
            "Single",
            "Double"});
            this.Bed_Type.Location = new System.Drawing.Point(725, 20);
            this.Bed_Type.Name = "Bed_Type";
            this.Bed_Type.Size = new System.Drawing.Size(121, 21);
            this.Bed_Type.TabIndex = 12;
            // 
            // Floor_Num
            // 
            this.Floor_Num.FormattingEnabled = true;
            this.Floor_Num.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Floor_Num.Location = new System.Drawing.Point(197, 150);
            this.Floor_Num.Name = "Floor_Num";
            this.Floor_Num.Size = new System.Drawing.Size(121, 21);
            this.Floor_Num.TabIndex = 12;
            // 
            // Room_Type
            // 
            this.Room_Type.FormattingEnabled = true;
            this.Room_Type.Items.AddRange(new object[] {
            "A/C",
            "Non A/C"});
            this.Room_Type.Location = new System.Drawing.Point(197, 83);
            this.Room_Type.Name = "Room_Type";
            this.Room_Type.Size = new System.Drawing.Size(121, 21);
            this.Room_Type.TabIndex = 12;
            // 
            // room_id
            // 
            this.room_id.FormattingEnabled = true;
            this.room_id.Location = new System.Drawing.Point(197, 20);
            this.room_id.Name = "room_id";
            this.room_id.Size = new System.Drawing.Size(121, 21);
            this.room_id.TabIndex = 12;
            this.room_id.SelectedIndexChanged += new System.EventHandler(this.room_id_SelectedIndexChanged);
            // 
            // Statuscb
            // 
            this.Statuscb.Cursor = System.Windows.Forms.Cursors.Default;
            this.Statuscb.FormattingEnabled = true;
            this.Statuscb.Items.AddRange(new object[] {
            "Available",
            "Reserved"});
            this.Statuscb.Location = new System.Drawing.Point(725, 155);
            this.Statuscb.Name = "Statuscb";
            this.Statuscb.Size = new System.Drawing.Size(214, 21);
            this.Statuscb.TabIndex = 8;
            this.Statuscb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1037, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 32);
            this.button6.TabIndex = 7;
            this.button6.Text = "Exit";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1037, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 32);
            this.button3.TabIndex = 4;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Costs
            // 
            this.Costs.Location = new System.Drawing.Point(726, 67);
            this.Costs.Name = "Costs";
            this.Costs.Size = new System.Drawing.Size(213, 20);
            this.Costs.TabIndex = 1;
            this.Costs.TextChanged += new System.EventHandler(this.Costs_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(608, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Max Person";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1037, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Crystal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Add_Room";
            this.Text = "View Room";
            this.Load += new System.EventHandler(this.Add_Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoomGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView RoomGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Costs;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox Statuscb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FloorNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.ComboBox room_id;
        private System.Windows.Forms.ComboBox Bed_Type;
        private System.Windows.Forms.ComboBox Floor_Num;
        private System.Windows.Forms.ComboBox Room_Type;
        private System.Windows.Forms.ComboBox maxperson;
        private System.Windows.Forms.Button button1;
    }
}