namespace EmployeeManagement
{
    partial class StockHome
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
            this.GrocersBTN = new System.Windows.Forms.Button();
            this.SupplierBTN = new System.Windows.Forms.Button();
            this.Stockbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GrocersBTN
            // 
            this.GrocersBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrocersBTN.Location = new System.Drawing.Point(142, 145);
            this.GrocersBTN.Name = "GrocersBTN";
            this.GrocersBTN.Size = new System.Drawing.Size(129, 203);
            this.GrocersBTN.TabIndex = 0;
            this.GrocersBTN.Text = "GROCERY";
            this.GrocersBTN.UseVisualStyleBackColor = true;
            this.GrocersBTN.Click += new System.EventHandler(this.GrocersBTN_Click);
            // 
            // SupplierBTN
            // 
            this.SupplierBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SupplierBTN.Location = new System.Drawing.Point(358, 145);
            this.SupplierBTN.Name = "SupplierBTN";
            this.SupplierBTN.Size = new System.Drawing.Size(129, 203);
            this.SupplierBTN.TabIndex = 1;
            this.SupplierBTN.Text = "SUPPLIER";
            this.SupplierBTN.UseVisualStyleBackColor = true;
            this.SupplierBTN.Click += new System.EventHandler(this.SupplierBTN_Click);
            // 
            // Stockbtn
            // 
            this.Stockbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Stockbtn.Location = new System.Drawing.Point(579, 145);
            this.Stockbtn.Name = "Stockbtn";
            this.Stockbtn.Size = new System.Drawing.Size(129, 203);
            this.Stockbtn.TabIndex = 2;
            this.Stockbtn.Text = "FIXED STOCK";
            this.Stockbtn.UseVisualStyleBackColor = true;
            this.Stockbtn.Click += new System.EventHandler(this.Stockbtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "HOME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StockHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Stockbtn);
            this.Controls.Add(this.SupplierBTN);
            this.Controls.Add(this.GrocersBTN);
            this.Name = "StockHome";
            this.Text = "StockHome";
            this.Load += new System.EventHandler(this.StockHome_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GrocersBTN;
        private System.Windows.Forms.Button SupplierBTN;
        private System.Windows.Forms.Button Stockbtn;
        private System.Windows.Forms.Button button1;
    }
}