namespace EmployeeManagement
{
    partial class AddSupplier
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
            this.SupID = new System.Windows.Forms.TextBox();
            this.SupContact = new System.Windows.Forms.TextBox();
            this.SupAddress = new System.Windows.Forms.TextBox();
            this.SupName = new System.Windows.Forms.TextBox();
            this.SupAdd = new System.Windows.Forms.Button();
            this.Supplierdgv = new System.Windows.Forms.DataGridView();
            this.Backbtn = new System.Windows.Forms.Button();
            this.Homebtn = new System.Windows.Forms.Button();
            this.ADDSUPGRC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Supplierdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Supplier Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(216, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "ADD NEW SUPPLIER";
            // 
            // SupID
            // 
            this.SupID.Location = new System.Drawing.Point(126, 124);
            this.SupID.Name = "SupID";
            this.SupID.Size = new System.Drawing.Size(200, 20);
            this.SupID.TabIndex = 5;
            // 
            // SupContact
            // 
            this.SupContact.Location = new System.Drawing.Point(126, 232);
            this.SupContact.Name = "SupContact";
            this.SupContact.Size = new System.Drawing.Size(200, 20);
            this.SupContact.TabIndex = 6;
            // 
            // SupAddress
            // 
            this.SupAddress.Location = new System.Drawing.Point(126, 197);
            this.SupAddress.Name = "SupAddress";
            this.SupAddress.Size = new System.Drawing.Size(200, 20);
            this.SupAddress.TabIndex = 7;
            // 
            // SupName
            // 
            this.SupName.Location = new System.Drawing.Point(126, 158);
            this.SupName.Name = "SupName";
            this.SupName.Size = new System.Drawing.Size(200, 20);
            this.SupName.TabIndex = 8;
            // 
            // SupAdd
            // 
            this.SupAdd.Location = new System.Drawing.Point(126, 288);
            this.SupAdd.Name = "SupAdd";
            this.SupAdd.Size = new System.Drawing.Size(75, 23);
            this.SupAdd.TabIndex = 9;
            this.SupAdd.Text = "ADD";
            this.SupAdd.UseVisualStyleBackColor = true;
            this.SupAdd.Click += new System.EventHandler(this.SupAdd_Click);
            // 
            // Supplierdgv
            // 
            this.Supplierdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Supplierdgv.Location = new System.Drawing.Point(349, 124);
            this.Supplierdgv.Name = "Supplierdgv";
            this.Supplierdgv.Size = new System.Drawing.Size(425, 342);
            this.Supplierdgv.TabIndex = 10;
            // 
            // Backbtn
            // 
            this.Backbtn.Location = new System.Drawing.Point(16, 12);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(75, 23);
            this.Backbtn.TabIndex = 11;
            this.Backbtn.Text = "BACK";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Homebtn
            // 
            this.Homebtn.Location = new System.Drawing.Point(97, 12);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Size = new System.Drawing.Size(75, 23);
            this.Homebtn.TabIndex = 12;
            this.Homebtn.Text = "HOME";
            this.Homebtn.UseVisualStyleBackColor = true;
            // 
            // ADDSUPGRC
            // 
            this.ADDSUPGRC.Location = new System.Drawing.Point(223, 288);
            this.ADDSUPGRC.Name = "ADDSUPGRC";
            this.ADDSUPGRC.Size = new System.Drawing.Size(75, 23);
            this.ADDSUPGRC.TabIndex = 13;
            this.ADDSUPGRC.Text = "ADD";
            this.ADDSUPGRC.UseVisualStyleBackColor = true;
            this.ADDSUPGRC.Click += new System.EventHandler(this.ADDSUPGRC_Click);
            // 
            // AddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 478);
            this.Controls.Add(this.ADDSUPGRC);
            this.Controls.Add(this.Homebtn);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.Supplierdgv);
            this.Controls.Add(this.SupAdd);
            this.Controls.Add(this.SupName);
            this.Controls.Add(this.SupAddress);
            this.Controls.Add(this.SupContact);
            this.Controls.Add(this.SupID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddSupplier";
            this.Text = "AddSupplier";
            this.Load += new System.EventHandler(this.AddSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Supplierdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SupID;
        private System.Windows.Forms.TextBox SupContact;
        private System.Windows.Forms.TextBox SupAddress;
        private System.Windows.Forms.TextBox SupName;
        public System.Windows.Forms.Button SupAdd;
        private System.Windows.Forms.DataGridView Supplierdgv;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button Homebtn;
        private System.Windows.Forms.Button ADDSUPGRC;
    }
}