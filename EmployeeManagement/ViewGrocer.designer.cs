namespace EmployeeManagement
{
    partial class ViewGrocer
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
            this.Viewgrc = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.BackBTN = new System.Windows.Forms.Button();
            this.HomeBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Viewgrc)).BeginInit();
            this.SuspendLayout();
            // 
            // Viewgrc
            // 
            this.Viewgrc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Viewgrc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Viewgrc.Location = new System.Drawing.Point(12, 113);
            this.Viewgrc.Name = "Viewgrc";
            this.Viewgrc.Size = new System.Drawing.Size(852, 372);
            this.Viewgrc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(79, 79);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(353, 20);
            this.searchbox.TabIndex = 2;
            this.searchbox.TextChanged += new System.EventHandler(this.searchbox_TextChanged);
            this.searchbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // BackBTN
            // 
            this.BackBTN.Location = new System.Drawing.Point(12, 12);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(75, 23);
            this.BackBTN.TabIndex = 3;
            this.BackBTN.Text = "BACK";
            this.BackBTN.UseVisualStyleBackColor = true;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // HomeBTN
            // 
            this.HomeBTN.Location = new System.Drawing.Point(93, 12);
            this.HomeBTN.Name = "HomeBTN";
            this.HomeBTN.Size = new System.Drawing.Size(75, 23);
            this.HomeBTN.TabIndex = 4;
            this.HomeBTN.Text = "HOME";
            this.HomeBTN.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "VIEW GROCERY DETAILS";
            // 
            // ViewGrocer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 497);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HomeBTN);
            this.Controls.Add(this.BackBTN);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Viewgrc);
            this.Name = "ViewGrocer";
            this.Text = "ViewGrocer";
            this.Load += new System.EventHandler(this.ViewGrocer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Viewgrc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Viewgrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button BackBTN;
        private System.Windows.Forms.Button HomeBTN;
        private System.Windows.Forms.Label label2;
    }
}