﻿namespace EmployeeManagement
{
    partial class Laundry
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RNo = new System.Windows.Forms.ComboBox();
            this.UPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.TextBox();
            this.RID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Edate = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ADD = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sta = new System.Windows.Forms.ComboBox();
            this.Wash = new System.Windows.Forms.ComboBox();
            this.Ddate = new System.Windows.Forms.DateTimePicker();
            this.Res = new System.Windows.Forms.TextBox();
            this.Nitems = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(162)))), ((int)(((byte)(198)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.RNo);
            this.panel1.Controls.Add(this.UPrice);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.RID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Edate);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ADD);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.Sta);
            this.panel1.Controls.Add(this.Wash);
            this.panel1.Controls.Add(this.Ddate);
            this.panel1.Controls.Add(this.Res);
            this.panel1.Controls.Add(this.Nitems);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 470);
            this.panel1.TabIndex = 0;
            // 
            // RNo
            // 
            this.RNo.FormattingEnabled = true;
            this.RNo.Location = new System.Drawing.Point(159, 111);
            this.RNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RNo.Name = "RNo";
            this.RNo.Size = new System.Drawing.Size(151, 26);
            this.RNo.TabIndex = 85;
            this.RNo.SelectedIndexChanged += new System.EventHandler(this.RNo_SelectedIndexChanged);
            // 
            // UPrice
            // 
            this.UPrice.Location = new System.Drawing.Point(788, 70);
            this.UPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UPrice.Name = "UPrice";
            this.UPrice.Size = new System.Drawing.Size(161, 24);
            this.UPrice.TabIndex = 84;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(692, 70);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 18);
            this.label10.TabIndex = 83;
            this.label10.Text = "UnitPrice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 82;
            this.label4.Text = "Search";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(482, 221);
            this.Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(161, 24);
            this.Search.TabIndex = 81;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // RID
            // 
            this.RID.AutoSize = true;
            this.RID.Location = new System.Drawing.Point(156, 63);
            this.RID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RID.Name = "RID";
            this.RID.Size = new System.Drawing.Size(96, 18);
            this.RID.TabIndex = 79;
            this.RID.Text = "Laundry ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, -2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 27);
            this.label2.TabIndex = 78;
            this.label2.Text = "Laundry System Management";
            // 
            // Edate
            // 
            this.Edate.AutoSize = true;
            this.Edate.Location = new System.Drawing.Point(478, 70);
            this.Edate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Edate.Name = "Edate";
            this.Edate.Size = new System.Drawing.Size(94, 18);
            this.Edate.TabIndex = 77;
            this.Edate.Text = "Entry Date";
            this.Edate.Click += new System.EventHandler(this.Edate_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(996, 187);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 31);
            this.button4.TabIndex = 74;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(996, 128);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 31);
            this.button3.TabIndex = 73;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(996, 69);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 31);
            this.button2.TabIndex = 72;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ADD
            // 
            this.ADD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ADD.Location = new System.Drawing.Point(996, 12);
            this.ADD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(76, 31);
            this.ADD.TabIndex = 71;
            this.ADD.Text = "Add";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 260);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1060, 188);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Sta
            // 
            this.Sta.FormattingEnabled = true;
            this.Sta.Items.AddRange(new object[] {
            "Delivery",
            "Processing",
            ""});
            this.Sta.Location = new System.Drawing.Point(788, 115);
            this.Sta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Sta.Name = "Sta";
            this.Sta.Size = new System.Drawing.Size(153, 26);
            this.Sta.TabIndex = 69;
            // 
            // Wash
            // 
            this.Wash.FormattingEnabled = true;
            this.Wash.Items.AddRange(new object[] {
            "---Select Wash Type---",
            " Normal wash",
            " Pigment wash",
            " Bleach wash",
            " Stone wash with or without bleach",
            " Acid wash",
            " Enzyme wash",
            " Caustic wash",
            " Garment wash and over-dye",
            " Whitening"});
            this.Wash.Location = new System.Drawing.Point(481, 167);
            this.Wash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Wash.Name = "Wash";
            this.Wash.Size = new System.Drawing.Size(164, 26);
            this.Wash.TabIndex = 68;
            this.Wash.SelectedIndexChanged += new System.EventHandler(this.Wash_SelectedIndexChanged);
            // 
            // Ddate
            // 
            this.Ddate.CustomFormat = "MM-dd-yyyy";
            this.Ddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Ddate.Location = new System.Drawing.Point(481, 113);
            this.Ddate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Ddate.Name = "Ddate";
            this.Ddate.Size = new System.Drawing.Size(164, 24);
            this.Ddate.TabIndex = 67;
            this.Ddate.ValueChanged += new System.EventHandler(this.Ddate_ValueChanged);
            // 
            // Res
            // 
            this.Res.Location = new System.Drawing.Point(788, 166);
            this.Res.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Res.Name = "Res";
            this.Res.Size = new System.Drawing.Size(161, 24);
            this.Res.TabIndex = 66;
            // 
            // Nitems
            // 
            this.Nitems.Location = new System.Drawing.Point(159, 163);
            this.Nitems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Nitems.Name = "Nitems";
            this.Nitems.Size = new System.Drawing.Size(151, 24);
            this.Nitems.TabIndex = 65;
            this.Nitems.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(692, 167);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 18);
            this.label11.TabIndex = 63;
            this.label11.Text = "Receiver";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(692, 114);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 18);
            this.label9.TabIndex = 61;
            this.label9.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(357, 167);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 60;
            this.label8.Text = "Wash Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 115);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 18);
            this.label7.TabIndex = 59;
            this.label7.Text = "Delivery Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 58;
            this.label6.Text = "Entry Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 167);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 18);
            this.label5.TabIndex = 57;
            this.label5.Text = "No Of Kilo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "Room No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 55;
            this.label1.Text = "Laundry ID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 86;
            this.button1.Text = "Crystal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Laundry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 488);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Laundry";
            this.Text = "Laundry";
            this.Load += new System.EventHandler(this.Laundry_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Edate;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox Sta;
        private System.Windows.Forms.ComboBox Wash;
        private System.Windows.Forms.DateTimePicker Ddate;
        private System.Windows.Forms.TextBox Res;
        private System.Windows.Forms.TextBox Nitems;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RID;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox UPrice;
        private System.Windows.Forms.ComboBox RNo;
        private System.Windows.Forms.Button button1;
    }
}