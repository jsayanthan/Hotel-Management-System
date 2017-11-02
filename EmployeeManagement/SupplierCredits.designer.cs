namespace EmployeeManagement
{
    partial class SupplierCredits
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
            this.amount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SPid = new System.Windows.Forms.TextBox();
            this.Sid = new System.Windows.Forms.ComboBox();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.SupCr = new System.Windows.Forms.DataGridView();
            this.SupPayment = new System.Windows.Forms.DataGridView();
            this.PayTypeCombo = new System.Windows.Forms.ComboBox();
            this.chqLabel = new System.Windows.Forms.Label();
            this.ChqDate = new System.Windows.Forms.DateTimePicker();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Updtbtn = new System.Windows.Forms.Button();
            this.Delbtn = new System.Windows.Forms.Button();
            this.Backbtn = new System.Windows.Forms.Button();
            this.Homebtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SupCr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier PID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SipplierID";
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Location = new System.Drawing.Point(344, 79);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(43, 13);
            this.amount.TabIndex = 2;
            this.amount.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "PaymentType";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(186, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(525, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "SUPPLIER CREDIT AND PAYMENTS DETAILS";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // SPid
            // 
            this.SPid.Location = new System.Drawing.Point(104, 73);
            this.SPid.Name = "SPid";
            this.SPid.Size = new System.Drawing.Size(211, 20);
            this.SPid.TabIndex = 5;
            // 
            // Sid
            // 
            this.Sid.FormattingEnabled = true;
            this.Sid.Location = new System.Drawing.Point(104, 104);
            this.Sid.Name = "Sid";
            this.Sid.Size = new System.Drawing.Size(211, 21);
            this.Sid.TabIndex = 6;
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(422, 72);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(200, 20);
            this.amountBox.TabIndex = 7;
            // 
            // SupCr
            // 
            this.SupCr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupCr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupCr.Location = new System.Drawing.Point(35, 191);
            this.SupCr.Name = "SupCr";
            this.SupCr.Size = new System.Drawing.Size(352, 293);
            this.SupCr.TabIndex = 9;
            // 
            // SupPayment
            // 
            this.SupPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupPayment.Location = new System.Drawing.Point(393, 191);
            this.SupPayment.Name = "SupPayment";
            this.SupPayment.Size = new System.Drawing.Size(611, 293);
            this.SupPayment.TabIndex = 10;
            this.SupPayment.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupPayment_CellContentDoubleClick);
            // 
            // PayTypeCombo
            // 
            this.PayTypeCombo.FormattingEnabled = true;
            this.PayTypeCombo.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.PayTypeCombo.Location = new System.Drawing.Point(422, 105);
            this.PayTypeCombo.Name = "PayTypeCombo";
            this.PayTypeCombo.Size = new System.Drawing.Size(200, 21);
            this.PayTypeCombo.TabIndex = 11;
            this.PayTypeCombo.SelectedIndexChanged += new System.EventHandler(this.PayTypeCombo_SelectedIndexChanged);
            // 
            // chqLabel
            // 
            this.chqLabel.AutoSize = true;
            this.chqLabel.Location = new System.Drawing.Point(344, 139);
            this.chqLabel.Name = "chqLabel";
            this.chqLabel.Size = new System.Drawing.Size(70, 13);
            this.chqLabel.TabIndex = 12;
            this.chqLabel.Text = "Cheque Date";
            // 
            // ChqDate
            // 
            this.ChqDate.Location = new System.Drawing.Point(422, 132);
            this.ChqDate.Name = "ChqDate";
            this.ChqDate.Size = new System.Drawing.Size(200, 20);
            this.ChqDate.TabIndex = 13;
            this.ChqDate.ValueChanged += new System.EventHandler(this.ChqDate_ValueChanged);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(675, 105);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 14;
            this.Addbtn.Text = "ADD";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Updtbtn
            // 
            this.Updtbtn.Location = new System.Drawing.Point(769, 105);
            this.Updtbtn.Name = "Updtbtn";
            this.Updtbtn.Size = new System.Drawing.Size(75, 23);
            this.Updtbtn.TabIndex = 15;
            this.Updtbtn.Text = "UPDATE";
            this.Updtbtn.UseVisualStyleBackColor = true;
            this.Updtbtn.Click += new System.EventHandler(this.Updtbtn_Click);
            // 
            // Delbtn
            // 
            this.Delbtn.Location = new System.Drawing.Point(861, 105);
            this.Delbtn.Name = "Delbtn";
            this.Delbtn.Size = new System.Drawing.Size(75, 23);
            this.Delbtn.TabIndex = 16;
            this.Delbtn.Text = "DELETE";
            this.Delbtn.UseVisualStyleBackColor = true;
            this.Delbtn.Click += new System.EventHandler(this.Delbtn_Click);
            // 
            // Backbtn
            // 
            this.Backbtn.Location = new System.Drawing.Point(9, 9);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(75, 23);
            this.Backbtn.TabIndex = 17;
            this.Backbtn.Text = "BACK";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // Homebtn
            // 
            this.Homebtn.Location = new System.Drawing.Point(90, 9);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Size = new System.Drawing.Size(75, 23);
            this.Homebtn.TabIndex = 18;
            this.Homebtn.Text = "HOME";
            this.Homebtn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Crystal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SupplierCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 528);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Homebtn);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.Delbtn);
            this.Controls.Add(this.Updtbtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.ChqDate);
            this.Controls.Add(this.chqLabel);
            this.Controls.Add(this.PayTypeCombo);
            this.Controls.Add(this.SupPayment);
            this.Controls.Add(this.SupCr);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.Sid);
            this.Controls.Add(this.SPid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SupplierCredits";
            this.Text = "SupplierCredits";
            this.Load += new System.EventHandler(this.SupplierCredits_Load);
            this.DoubleClick += new System.EventHandler(this.SupplierCredits_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.SupCr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SPid;
        private System.Windows.Forms.ComboBox Sid;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.DataGridView SupCr;
        private System.Windows.Forms.DataGridView SupPayment;
        private System.Windows.Forms.ComboBox PayTypeCombo;
        private System.Windows.Forms.Label chqLabel;
        private System.Windows.Forms.DateTimePicker ChqDate;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button Updtbtn;
        private System.Windows.Forms.Button Delbtn;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button Homebtn;
        private System.Windows.Forms.Button button1;
    }
}