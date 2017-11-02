namespace EmployeeManagement
{
    partial class PoolGameManagement
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.netamount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.TextBox();
            this.discount = new System.Windows.Forms.TextBox();
            this.amountpaid = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.hours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rid = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.totalamount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cusphone = new System.Windows.Forms.Label();
            this.cusname = new System.Windows.Forms.Label();
            this.roomid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.outstandpaid = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.outstandbalance = new System.Windows.Forms.TextBox();
            this.paymentid = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.PoolID = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "PoolGame Management System";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.status);
            this.groupBox4.Controls.Add(this.netamount);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.balance);
            this.groupBox4.Controls.Add(this.discount);
            this.groupBox4.Controls.Add(this.amountpaid);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.amount);
            this.groupBox4.Controls.Add(this.hours);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(27, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 294);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " ";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(182, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 19);
            this.label12.TabIndex = 70;
            this.label12.Text = "Date";
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "Un Paid",
            "Paid"});
            this.status.Location = new System.Drawing.Point(186, 269);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(121, 21);
            this.status.TabIndex = 69;
            // 
            // netamount
            // 
            this.netamount.Location = new System.Drawing.Point(185, 157);
            this.netamount.Name = "netamount";
            this.netamount.Size = new System.Drawing.Size(184, 20);
            this.netamount.TabIndex = 65;
            this.netamount.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(2, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 23);
            this.label11.TabIndex = 68;
            this.label11.Text = "Status";
            // 
            // balance
            // 
            this.balance.Location = new System.Drawing.Point(186, 232);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(185, 20);
            this.balance.TabIndex = 63;
            this.balance.Text = "0";
            // 
            // discount
            // 
            this.discount.Location = new System.Drawing.Point(185, 120);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(184, 20);
            this.discount.TabIndex = 64;
            this.discount.Text = "0";
            this.discount.TextChanged += new System.EventHandler(this.discount_TextChanged_1);
            // 
            // amountpaid
            // 
            this.amountpaid.Location = new System.Drawing.Point(185, 195);
            this.amountpaid.Name = "amountpaid";
            this.amountpaid.Size = new System.Drawing.Size(184, 20);
            this.amountpaid.TabIndex = 62;
            this.amountpaid.Text = "0";
            this.amountpaid.TextChanged += new System.EventHandler(this.amountpaid_TextChanged_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(1, 229);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(159, 23);
            this.label20.TabIndex = 59;
            this.label20.Text = "BalanceToPaid";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(5, 195);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(156, 23);
            this.label19.TabIndex = 58;
            this.label19.Text = "AmountOfPaid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 23);
            this.label6.TabIndex = 57;
            this.label6.Text = "OrderedDate";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(5, 154);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 23);
            this.label22.TabIndex = 61;
            this.label22.Text = "NetAmount";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(5, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 23);
            this.label21.TabIndex = 60;
            this.label21.Text = "Discount";
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(185, 80);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(183, 20);
            this.amount.TabIndex = 44;
            this.amount.Text = "0";
            // 
            // hours
            // 
            this.hours.Location = new System.Drawing.Point(186, 42);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(183, 20);
            this.hours.TabIndex = 43;
            this.hours.TextChanged += new System.EventHandler(this.hours_TextChanged_2);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 23);
            this.label5.TabIndex = 41;
            this.label5.Text = "TotalAmount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Hours";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(982, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 19);
            this.label15.TabIndex = 69;
            this.label15.Text = "Time";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Room Customer",
            "Restaurent Customer"});
            this.comboBox1.Location = new System.Drawing.Point(236, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 21);
            this.comboBox1.TabIndex = 72;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_3);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(54, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(159, 23);
            this.label13.TabIndex = 71;
            this.label13.Text = "Customer Type";
            // 
            // rid
            // 
            this.rid.FormattingEnabled = true;
            this.rid.Location = new System.Drawing.Point(208, 39);
            this.rid.Name = "rid";
            this.rid.Size = new System.Drawing.Size(121, 21);
            this.rid.TabIndex = 66;
            this.rid.SelectedIndexChanged += new System.EventHandler(this.cusid_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(796, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 19);
            this.label10.TabIndex = 70;
            this.label10.Text = "Date";
            // 
            // totalamount
            // 
            this.totalamount.Enabled = false;
            this.totalamount.Location = new System.Drawing.Point(187, 25);
            this.totalamount.Name = "totalamount";
            this.totalamount.Size = new System.Drawing.Size(140, 20);
            this.totalamount.TabIndex = 57;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cusphone);
            this.groupBox1.Controls.Add(this.cusname);
            this.groupBox1.Controls.Add(this.roomid);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(574, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 134);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // cusphone
            // 
            this.cusphone.AutoSize = true;
            this.cusphone.Location = new System.Drawing.Point(177, 98);
            this.cusphone.Name = "cusphone";
            this.cusphone.Size = new System.Drawing.Size(91, 13);
            this.cusphone.TabIndex = 23;
            this.cusphone.Text = "Customer Contact";
            // 
            // cusname
            // 
            this.cusname.AutoSize = true;
            this.cusname.Location = new System.Drawing.Point(177, 66);
            this.cusname.Name = "cusname";
            this.cusname.Size = new System.Drawing.Size(82, 13);
            this.cusname.TabIndex = 22;
            this.cusname.Text = "Customer Name";
            // 
            // roomid
            // 
            this.roomid.AutoSize = true;
            this.roomid.Location = new System.Drawing.Point(177, 33);
            this.roomid.Name = "roomid";
            this.roomid.Size = new System.Drawing.Size(46, 13);
            this.roomid.TabIndex = 21;
            this.roomid.Text = "RoomID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Customer Contact";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Customer Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "RoomID";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1090, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 33);
            this.button2.TabIndex = 65;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(127, 551);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(879, 136);
            this.dataGridView1.TabIndex = 64;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(1090, 259);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(93, 33);
            this.delete.TabIndex = 63;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click_1);
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(1090, 200);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(93, 33);
            this.add.TabIndex = 62;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(1090, 141);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(93, 33);
            this.back.TabIndex = 61;
            this.back.Text = "Home";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.totalamount);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.outstandpaid);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.outstandbalance);
            this.groupBox3.Location = new System.Drawing.Point(574, 365);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 180);
            this.groupBox3.TabIndex = 68;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calculate Balance";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(140, 23);
            this.label23.TabIndex = 56;
            this.label23.Text = "TotalAmount";
            // 
            // outstandpaid
            // 
            this.outstandpaid.Location = new System.Drawing.Point(188, 63);
            this.outstandpaid.Name = "outstandpaid";
            this.outstandpaid.Size = new System.Drawing.Size(139, 20);
            this.outstandpaid.TabIndex = 54;
            this.outstandpaid.TextChanged += new System.EventHandler(this.outstandpaid_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 23);
            this.label14.TabIndex = 52;
            this.label14.Text = "Cash Paid";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(145, 23);
            this.label18.TabIndex = 53;
            this.label18.Text = "Cash Balance";
            // 
            // outstandbalance
            // 
            this.outstandbalance.Enabled = false;
            this.outstandbalance.Location = new System.Drawing.Point(189, 98);
            this.outstandbalance.Name = "outstandbalance";
            this.outstandbalance.Size = new System.Drawing.Size(139, 20);
            this.outstandbalance.TabIndex = 55;
            // 
            // paymentid
            // 
            this.paymentid.AutoSize = true;
            this.paymentid.Location = new System.Drawing.Point(202, 112);
            this.paymentid.Name = "paymentid";
            this.paymentid.Size = new System.Drawing.Size(59, 13);
            this.paymentid.TabIndex = 51;
            this.paymentid.Text = "PaymentID";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 23);
            this.label16.TabIndex = 50;
            this.label16.Text = "PaymentID";
            // 
            // PoolID
            // 
            this.PoolID.AutoSize = true;
            this.PoolID.Location = new System.Drawing.Point(203, 79);
            this.PoolID.Name = "PoolID";
            this.PoolID.Size = new System.Drawing.Size(37, 13);
            this.PoolID.TabIndex = 49;
            this.PoolID.Text = "PoolId";
            // 
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(413, 41);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(88, 23);
            this.Search.TabIndex = 45;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click_2);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "PooID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Room ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.rid);
            this.groupBox2.Controls.Add(this.paymentid);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.PoolID);
            this.groupBox2.Controls.Add(this.Search);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(28, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 435);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gym";
            // 
            // PoolGameManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1210, 733);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.back);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Name = "PoolGameManagement";
            this.Text = "PoolGameManagement";
            this.Load += new System.EventHandler(this.PoolGameManagement_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.TextBox netamount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox balance;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.TextBox amountpaid;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.TextBox hours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox rid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox totalamount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label cusphone;
        private System.Windows.Forms.Label cusname;
        private System.Windows.Forms.Label roomid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox outstandpaid;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox outstandbalance;
        private System.Windows.Forms.Label paymentid;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label PoolID;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}