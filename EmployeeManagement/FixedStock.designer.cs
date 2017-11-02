namespace EmployeeManagement
{
    partial class FixedStock
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
            this.addstock = new System.Windows.Forms.Button();
            this.updtstockbtn = new System.Windows.Forms.Button();
            this.purchasebtn = new System.Windows.Forms.Button();
            this.Backbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addstock
            // 
            this.addstock.Location = new System.Drawing.Point(146, 123);
            this.addstock.Name = "addstock";
            this.addstock.Size = new System.Drawing.Size(147, 221);
            this.addstock.TabIndex = 0;
            this.addstock.Text = "ADD NEW STOCK";
            this.addstock.UseVisualStyleBackColor = true;
            this.addstock.Click += new System.EventHandler(this.addstock_Click);
            // 
            // updtstockbtn
            // 
            this.updtstockbtn.Location = new System.Drawing.Point(711, 123);
            this.updtstockbtn.Name = "updtstockbtn";
            this.updtstockbtn.Size = new System.Drawing.Size(147, 221);
            this.updtstockbtn.TabIndex = 1;
            this.updtstockbtn.Text = "UPDATE STOCK";
            this.updtstockbtn.UseVisualStyleBackColor = true;
            this.updtstockbtn.Click += new System.EventHandler(this.updtstockbtn_Click);
            // 
            // purchasebtn
            // 
            this.purchasebtn.Location = new System.Drawing.Point(434, 123);
            this.purchasebtn.Name = "purchasebtn";
            this.purchasebtn.Size = new System.Drawing.Size(147, 221);
            this.purchasebtn.TabIndex = 2;
            this.purchasebtn.Text = "PURCHASE STOCK";
            this.purchasebtn.UseVisualStyleBackColor = true;
            this.purchasebtn.Click += new System.EventHandler(this.purchasebtn_Click);
            // 
            // Backbtn
            // 
            this.Backbtn.Location = new System.Drawing.Point(10, 12);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(75, 23);
            this.Backbtn.TabIndex = 3;
            this.Backbtn.Text = "BACK";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "HOME";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 37);
            this.label1.TabIndex = 5;
            this.label1.Text = "FIXED STOCK DETAILS";
            // 
            // FixedStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.purchasebtn);
            this.Controls.Add(this.updtstockbtn);
            this.Controls.Add(this.addstock);
            this.Name = "FixedStock";
            this.Text = "FixedStock";
            this.Load += new System.EventHandler(this.FixedStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addstock;
        private System.Windows.Forms.Button updtstockbtn;
        private System.Windows.Forms.Button purchasebtn;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}