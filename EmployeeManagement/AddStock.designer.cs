namespace EmployeeManagement
{
    partial class AddStock
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
            this.label6 = new System.Windows.Forms.Label();
            this.stockidbox = new System.Windows.Forms.TextBox();
            this.stocknamebox = new System.Windows.Forms.TextBox();
            this.quantitybox = new System.Windows.Forms.TextBox();
            this.unitpricebox = new System.Windows.Forms.TextBox();
            this.placecombo = new System.Windows.Forms.ComboBox();
            this.suppliercombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Addbtn = new System.Windows.Forms.Button();
            this.addstockdgv = new System.Windows.Forms.DataGridView();
            this.backbtn = new System.Windows.Forms.Button();
            this.Homebtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.addstockdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stock Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Allocating Place";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Unit Price";
            // 
            // stockidbox
            // 
            this.stockidbox.Location = new System.Drawing.Point(151, 181);
            this.stockidbox.Name = "stockidbox";
            this.stockidbox.Size = new System.Drawing.Size(153, 20);
            this.stockidbox.TabIndex = 6;
            // 
            // stocknamebox
            // 
            this.stocknamebox.Location = new System.Drawing.Point(151, 218);
            this.stocknamebox.Name = "stocknamebox";
            this.stocknamebox.Size = new System.Drawing.Size(153, 20);
            this.stocknamebox.TabIndex = 7;
            // 
            // quantitybox
            // 
            this.quantitybox.Location = new System.Drawing.Point(151, 257);
            this.quantitybox.Name = "quantitybox";
            this.quantitybox.Size = new System.Drawing.Size(153, 20);
            this.quantitybox.TabIndex = 8;
            // 
            // unitpricebox
            // 
            this.unitpricebox.Location = new System.Drawing.Point(151, 299);
            this.unitpricebox.Name = "unitpricebox";
            this.unitpricebox.Size = new System.Drawing.Size(153, 20);
            this.unitpricebox.TabIndex = 9;
            // 
            // placecombo
            // 
            this.placecombo.FormattingEnabled = true;
            this.placecombo.Items.AddRange(new object[] {
            "Rooms",
            "Halls",
            "Restaurent",
            "Bar",
            "Gym",
            "Parlour"});
            this.placecombo.Location = new System.Drawing.Point(154, 336);
            this.placecombo.Name = "placecombo";
            this.placecombo.Size = new System.Drawing.Size(153, 21);
            this.placecombo.TabIndex = 11;
            // 
            // suppliercombo
            // 
            this.suppliercombo.FormattingEnabled = true;
            this.suppliercombo.Location = new System.Drawing.Point(151, 138);
            this.suppliercombo.Name = "suppliercombo";
            this.suppliercombo.Size = new System.Drawing.Size(153, 21);
            this.suppliercombo.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Supplier";
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(154, 393);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 14;
            this.Addbtn.Text = "ADD";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // addstockdgv
            // 
            this.addstockdgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.addstockdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addstockdgv.Location = new System.Drawing.Point(371, 111);
            this.addstockdgv.Name = "addstockdgv";
            this.addstockdgv.Size = new System.Drawing.Size(472, 362);
            this.addstockdgv.TabIndex = 15;
            this.addstockdgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(11, 12);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 16;
            this.backbtn.Text = "BACK";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // Homebtn
            // 
            this.Homebtn.Location = new System.Drawing.Point(92, 12);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Size = new System.Drawing.Size(75, 23);
            this.Homebtn.TabIndex = 17;
            this.Homebtn.Text = "HOME";
            this.Homebtn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(311, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(289, 37);
            this.label7.TabIndex = 18;
            this.label7.Text = "ADD NEW STOCK";
            // 
            // AddStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 496);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Homebtn);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.addstockdgv);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.suppliercombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.placecombo);
            this.Controls.Add(this.unitpricebox);
            this.Controls.Add(this.quantitybox);
            this.Controls.Add(this.stocknamebox);
            this.Controls.Add(this.stockidbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddStock";
            this.Text = "AddStock";
            this.Load += new System.EventHandler(this.AddStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addstockdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox stockidbox;
        private System.Windows.Forms.TextBox stocknamebox;
        private System.Windows.Forms.TextBox quantitybox;
        private System.Windows.Forms.TextBox unitpricebox;
        private System.Windows.Forms.ComboBox placecombo;
        private System.Windows.Forms.ComboBox suppliercombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.DataGridView addstockdgv;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button Homebtn;
        private System.Windows.Forms.Label label7;
    }
}