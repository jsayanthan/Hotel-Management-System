namespace EmployeeManagement
{
    partial class AddNewBeverage
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
            this.bevetypeinsert = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bevetypeid = new System.Windows.Forms.Label();
            this.bevetype = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.beveid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bevenameinsert = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bevename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Beverage ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bevetypeinsert
            // 
            this.bevetypeinsert.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bevetypeinsert.Location = new System.Drawing.Point(141, 172);
            this.bevetypeinsert.Name = "bevetypeinsert";
            this.bevetypeinsert.Size = new System.Drawing.Size(66, 35);
            this.bevetypeinsert.TabIndex = 11;
            this.bevetypeinsert.Text = "Insert";
            this.bevetypeinsert.UseVisualStyleBackColor = true;
            this.bevetypeinsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1080, 222);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(73, 37);
            this.button4.TabIndex = 14;
            this.button4.Text = "Home";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(278, 363);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(468, 234);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.dataGridView1_ChangeUICues);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bevetypeid);
            this.groupBox1.Controls.Add(this.bevetype);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bevetypeinsert);
            this.groupBox1.Location = new System.Drawing.Point(41, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 237);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AddBeverageType";
            // 
            // bevetypeid
            // 
            this.bevetypeid.AutoSize = true;
            this.bevetypeid.Location = new System.Drawing.Point(216, 73);
            this.bevetypeid.Name = "bevetypeid";
            this.bevetypeid.Size = new System.Drawing.Size(88, 13);
            this.bevetypeid.TabIndex = 20;
            this.bevetypeid.Text = "BeverageTypeID";
            // 
            // bevetype
            // 
            this.bevetype.Location = new System.Drawing.Point(219, 106);
            this.bevetype.Name = "bevetype";
            this.bevetype.Size = new System.Drawing.Size(149, 20);
            this.bevetype.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Beverage Type ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Beverage Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.beveid);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.bevenameinsert);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.bevename);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(584, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 237);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AddBeverage";
            // 
            // beveid
            // 
            this.beveid.AutoSize = true;
            this.beveid.Location = new System.Drawing.Point(224, 40);
            this.beveid.Name = "beveid";
            this.beveid.Size = new System.Drawing.Size(64, 13);
            this.beveid.TabIndex = 74;
            this.beveid.Text = "BeverageID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "BeverageID";
            // 
            // bevenameinsert
            // 
            this.bevenameinsert.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bevenameinsert.Location = new System.Drawing.Point(178, 172);
            this.bevenameinsert.Name = "bevenameinsert";
            this.bevenameinsert.Size = new System.Drawing.Size(75, 35);
            this.bevenameinsert.TabIndex = 24;
            this.bevenameinsert.Text = "Insert";
            this.bevenameinsert.UseVisualStyleBackColor = true;
            this.bevenameinsert.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(227, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bevename
            // 
            this.bevename.Location = new System.Drawing.Point(227, 96);
            this.bevename.Name = "bevename";
            this.bevename.Size = new System.Drawing.Size(153, 20);
            this.bevename.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 23);
            this.label6.TabIndex = 21;
            this.label6.Text = "Beverage Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Beverage Name";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1080, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 37);
            this.button3.TabIndex = 21;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1080, 153);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(73, 37);
            this.button5.TabIndex = 22;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AddNewBeverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1194, 625);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Name = "AddNewBeverage";
            this.Text = "AddNewBeverage";
            this.Load += new System.EventHandler(this.AddNewBeverage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bevetypeinsert;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label bevetypeid;
        private System.Windows.Forms.TextBox bevetype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bevenameinsert;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox bevename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label beveid;
        private System.Windows.Forms.Label label5;
    }
}