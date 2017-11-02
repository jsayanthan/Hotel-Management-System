namespace EmployeeManagement
{
    partial class EditSupplier
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
            this.Label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SupID = new System.Windows.Forms.TextBox();
            this.SupName = new System.Windows.Forms.TextBox();
            this.SupAddress = new System.Windows.Forms.TextBox();
            this.SupContact = new System.Windows.Forms.TextBox();
            this.Updtbtm = new System.Windows.Forms.Button();
            this.Delbtn = new System.Windows.Forms.Button();
            this.EditSup = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchName = new System.Windows.Forms.TextBox();
            this.SearchType = new System.Windows.Forms.ComboBox();
            this.Backbtn = new System.Windows.Forms.Button();
            this.Homebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EditSup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier ID";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(49, 151);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "SupName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Supplier Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "SupContact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(253, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(274, 39);
            this.label5.TabIndex = 4;
            this.label5.Text = "EDIT SUPPLIER";
            // 
            // SupID
            // 
            this.SupID.Location = new System.Drawing.Point(135, 103);
            this.SupID.Name = "SupID";
            this.SupID.Size = new System.Drawing.Size(100, 20);
            this.SupID.TabIndex = 5;
            // 
            // SupName
            // 
            this.SupName.Location = new System.Drawing.Point(135, 148);
            this.SupName.Name = "SupName";
            this.SupName.Size = new System.Drawing.Size(100, 20);
            this.SupName.TabIndex = 6;
            // 
            // SupAddress
            // 
            this.SupAddress.Location = new System.Drawing.Point(135, 206);
            this.SupAddress.Name = "SupAddress";
            this.SupAddress.Size = new System.Drawing.Size(100, 20);
            this.SupAddress.TabIndex = 7;
            // 
            // SupContact
            // 
            this.SupContact.Location = new System.Drawing.Point(135, 253);
            this.SupContact.Name = "SupContact";
            this.SupContact.Size = new System.Drawing.Size(100, 20);
            this.SupContact.TabIndex = 8;
            // 
            // Updtbtm
            // 
            this.Updtbtm.Location = new System.Drawing.Point(52, 321);
            this.Updtbtm.Name = "Updtbtm";
            this.Updtbtm.Size = new System.Drawing.Size(75, 23);
            this.Updtbtm.TabIndex = 9;
            this.Updtbtm.Text = "UPDATE";
            this.Updtbtm.UseVisualStyleBackColor = true;
            this.Updtbtm.Click += new System.EventHandler(this.Updtbtm_Click);
            // 
            // Delbtn
            // 
            this.Delbtn.Location = new System.Drawing.Point(160, 321);
            this.Delbtn.Name = "Delbtn";
            this.Delbtn.Size = new System.Drawing.Size(75, 23);
            this.Delbtn.TabIndex = 10;
            this.Delbtn.Text = "DELETE";
            this.Delbtn.UseVisualStyleBackColor = true;
            this.Delbtn.Click += new System.EventHandler(this.Delbtn_Click);
            // 
            // EditSup
            // 
            this.EditSup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EditSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EditSup.Location = new System.Drawing.Point(280, 151);
            this.EditSup.Name = "EditSup";
            this.EditSup.Size = new System.Drawing.Size(448, 274);
            this.EditSup.TabIndex = 11;
            this.EditSup.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditSup_CellContentDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Search By";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // SearchName
            // 
            this.SearchName.Location = new System.Drawing.Point(475, 125);
            this.SearchName.Name = "SearchName";
            this.SearchName.Size = new System.Drawing.Size(253, 20);
            this.SearchName.TabIndex = 13;
            this.SearchName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SearchType
            // 
            this.SearchType.FormattingEnabled = true;
            this.SearchType.Items.AddRange(new object[] {
            "Supplier Name",
            "SupplierID"});
            this.SearchType.Location = new System.Drawing.Point(476, 81);
            this.SearchType.Name = "SearchType";
            this.SearchType.Size = new System.Drawing.Size(121, 21);
            this.SearchType.TabIndex = 14;
            // 
            // Backbtn
            // 
            this.Backbtn.Location = new System.Drawing.Point(9, 12);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(75, 23);
            this.Backbtn.TabIndex = 15;
            this.Backbtn.Text = "BACK";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            // 
            // Homebtn
            // 
            this.Homebtn.Location = new System.Drawing.Point(90, 12);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Size = new System.Drawing.Size(75, 23);
            this.Homebtn.TabIndex = 16;
            this.Homebtn.Text = "HOME";
            this.Homebtn.UseVisualStyleBackColor = true;
            // 
            // EditSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 463);
            this.Controls.Add(this.Homebtn);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.SearchType);
            this.Controls.Add(this.SearchName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.EditSup);
            this.Controls.Add(this.Delbtn);
            this.Controls.Add(this.Updtbtm);
            this.Controls.Add(this.SupContact);
            this.Controls.Add(this.SupAddress);
            this.Controls.Add(this.SupName);
            this.Controls.Add(this.SupID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.label1);
            this.Name = "EditSupplier";
            this.Text = "EditSupplier";
            this.Load += new System.EventHandler(this.EditSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EditSup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SupID;
        private System.Windows.Forms.TextBox SupName;
        private System.Windows.Forms.TextBox SupAddress;
        private System.Windows.Forms.TextBox SupContact;
        private System.Windows.Forms.Button Updtbtm;
        private System.Windows.Forms.Button Delbtn;
        private System.Windows.Forms.DataGridView EditSup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SearchName;
        private System.Windows.Forms.ComboBox SearchType;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button Homebtn;
    }
}