namespace EmployeeManagement
{
    partial class UpdateStock
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
            this.updtstockdgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.idbox = new System.Windows.Forms.TextBox();
            this.stockidbox = new System.Windows.Forms.TextBox();
            this.placeBox = new System.Windows.Forms.ComboBox();
            this.backbtn = new System.Windows.Forms.Button();
            this.Stockdgv = new System.Windows.Forms.DataGridView();
            this.searchstockBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.homebtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.updtstockdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stockdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // updtstockdgv
            // 
            this.updtstockdgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.updtstockdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updtstockdgv.Location = new System.Drawing.Point(333, 159);
            this.updtstockdgv.Name = "updtstockdgv";
            this.updtstockdgv.Size = new System.Drawing.Size(342, 340);
            this.updtstockdgv.TabIndex = 0;
            this.updtstockdgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.updtstockdgv_CellContentDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "StockID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Allocated Place";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(24, 373);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 4;
            this.updatebtn.Text = "UPDATE";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(136, 373);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(75, 23);
            this.Deletebtn.TabIndex = 5;
            this.Deletebtn.Text = "DELETE";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // idbox
            // 
            this.idbox.Location = new System.Drawing.Point(136, 194);
            this.idbox.Name = "idbox";
            this.idbox.Size = new System.Drawing.Size(167, 20);
            this.idbox.TabIndex = 6;
            // 
            // stockidbox
            // 
            this.stockidbox.Location = new System.Drawing.Point(136, 248);
            this.stockidbox.Name = "stockidbox";
            this.stockidbox.Size = new System.Drawing.Size(167, 20);
            this.stockidbox.TabIndex = 7;
            // 
            // placeBox
            // 
            this.placeBox.FormattingEnabled = true;
            this.placeBox.Items.AddRange(new object[] {
            "Rooms",
            "Halls",
            "Restaurent",
            "Bar",
            "Gym",
            "Parlour"});
            this.placeBox.Location = new System.Drawing.Point(136, 303);
            this.placeBox.Name = "placeBox";
            this.placeBox.Size = new System.Drawing.Size(167, 21);
            this.placeBox.TabIndex = 8;
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(12, 12);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 9;
            this.backbtn.Text = "BACK";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // Stockdgv
            // 
            this.Stockdgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Stockdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Stockdgv.Location = new System.Drawing.Point(681, 159);
            this.Stockdgv.Name = "Stockdgv";
            this.Stockdgv.Size = new System.Drawing.Size(332, 340);
            this.Stockdgv.TabIndex = 10;
            // 
            // searchstockBox
            // 
            this.searchstockBox.Location = new System.Drawing.Point(450, 109);
            this.searchstockBox.Name = "searchstockBox";
            this.searchstockBox.Size = new System.Drawing.Size(225, 20);
            this.searchstockBox.TabIndex = 11;
            this.searchstockBox.TextChanged += new System.EventHandler(this.searchstockBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Search By PerStockID";
            // 
            // homebtn
            // 
            this.homebtn.Location = new System.Drawing.Point(93, 12);
            this.homebtn.Name = "homebtn";
            this.homebtn.Size = new System.Drawing.Size(75, 23);
            this.homebtn.TabIndex = 13;
            this.homebtn.Text = "HOME";
            this.homebtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(337, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(266, 37);
            this.label5.TabIndex = 14;
            this.label5.Text = "UPDATE STOCK";
            // 
            // UpdateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 511);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.homebtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchstockBox);
            this.Controls.Add(this.Stockdgv);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.placeBox);
            this.Controls.Add(this.stockidbox);
            this.Controls.Add(this.idbox);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updtstockdgv);
            this.Name = "UpdateStock";
            this.Text = "UpdateStock";
            this.Load += new System.EventHandler(this.UpdateStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.updtstockdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stockdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView updtstockdgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.TextBox idbox;
        private System.Windows.Forms.TextBox stockidbox;
        private System.Windows.Forms.ComboBox placeBox;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.DataGridView Stockdgv;
        private System.Windows.Forms.TextBox searchstockBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button homebtn;
        private System.Windows.Forms.Label label5;
    }
}