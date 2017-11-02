namespace EmployeeManagement
{
    partial class PurchaseStock
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
            this.backbtn = new System.Windows.Forms.Button();
            this.homebtn = new System.Windows.Forms.Button();
            this.supcombo = new System.Windows.Forms.ComboBox();
            this.stockcombo = new System.Windows.Forms.ComboBox();
            this.placecombo = new System.Windows.Forms.ComboBox();
            this.quantitybox = new System.Windows.Forms.TextBox();
            this.unitpricebox = new System.Windows.Forms.TextBox();
            this.Supplier = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.updatebtn = new System.Windows.Forms.Button();
            this.purchasedgv = new System.Windows.Forms.DataGridView();
            this.stockdgv = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(10, 12);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 0;
            this.backbtn.Text = "BACK";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // homebtn
            // 
            this.homebtn.Location = new System.Drawing.Point(91, 12);
            this.homebtn.Name = "homebtn";
            this.homebtn.Size = new System.Drawing.Size(75, 23);
            this.homebtn.TabIndex = 1;
            this.homebtn.Text = "HOME";
            this.homebtn.UseVisualStyleBackColor = true;
            // 
            // supcombo
            // 
            this.supcombo.FormattingEnabled = true;
            this.supcombo.Location = new System.Drawing.Point(118, 105);
            this.supcombo.Name = "supcombo";
            this.supcombo.Size = new System.Drawing.Size(121, 21);
            this.supcombo.TabIndex = 2;
            // 
            // stockcombo
            // 
            this.stockcombo.FormattingEnabled = true;
            this.stockcombo.Location = new System.Drawing.Point(118, 132);
            this.stockcombo.Name = "stockcombo";
            this.stockcombo.Size = new System.Drawing.Size(121, 21);
            this.stockcombo.TabIndex = 3;
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
            this.placecombo.Location = new System.Drawing.Point(118, 166);
            this.placecombo.Name = "placecombo";
            this.placecombo.Size = new System.Drawing.Size(121, 21);
            this.placecombo.TabIndex = 4;
            this.placecombo.SelectedIndexChanged += new System.EventHandler(this.placecombo_SelectedIndexChanged);
            // 
            // quantitybox
            // 
            this.quantitybox.Location = new System.Drawing.Point(340, 101);
            this.quantitybox.Name = "quantitybox";
            this.quantitybox.Size = new System.Drawing.Size(121, 20);
            this.quantitybox.TabIndex = 5;
            // 
            // unitpricebox
            // 
            this.unitpricebox.Location = new System.Drawing.Point(340, 135);
            this.unitpricebox.Name = "unitpricebox";
            this.unitpricebox.Size = new System.Drawing.Size(121, 20);
            this.unitpricebox.TabIndex = 6;
            // 
            // Supplier
            // 
            this.Supplier.AutoSize = true;
            this.Supplier.Location = new System.Drawing.Point(18, 108);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(45, 13);
            this.Supplier.TabIndex = 7;
            this.Supplier.Text = "Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "StockType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Unit Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Allocating Area";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(340, 164);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 12;
            this.updatebtn.Text = "UPDATE";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // purchasedgv
            // 
            this.purchasedgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchasedgv.Location = new System.Drawing.Point(12, 198);
            this.purchasedgv.Name = "purchasedgv";
            this.purchasedgv.Size = new System.Drawing.Size(555, 296);
            this.purchasedgv.TabIndex = 13;
            // 
            // stockdgv
            // 
            this.stockdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockdgv.Location = new System.Drawing.Point(573, 198);
            this.stockdgv.Name = "stockdgv";
            this.stockdgv.Size = new System.Drawing.Size(388, 296);
            this.stockdgv.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(281, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(454, 37);
            this.label5.TabIndex = 15;
            this.label5.Text = "PURCHASE STOCK DETAILS";
            // 
            // PurchaseStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 506);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stockdgv);
            this.Controls.Add(this.purchasedgv);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Supplier);
            this.Controls.Add(this.unitpricebox);
            this.Controls.Add(this.quantitybox);
            this.Controls.Add(this.placecombo);
            this.Controls.Add(this.stockcombo);
            this.Controls.Add(this.supcombo);
            this.Controls.Add(this.homebtn);
            this.Controls.Add(this.backbtn);
            this.Name = "PurchaseStock";
            this.Text = "PurchaseStock";
            this.Load += new System.EventHandler(this.PurchaseSock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.purchasedgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button homebtn;
        private System.Windows.Forms.ComboBox supcombo;
        private System.Windows.Forms.ComboBox stockcombo;
        private System.Windows.Forms.ComboBox placecombo;
        private System.Windows.Forms.TextBox quantitybox;
        private System.Windows.Forms.TextBox unitpricebox;
        private System.Windows.Forms.Label Supplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.DataGridView purchasedgv;
        private System.Windows.Forms.DataGridView stockdgv;
        private System.Windows.Forms.Label label5;
    }
}