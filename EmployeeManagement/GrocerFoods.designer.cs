namespace EmployeeManagement
{
    partial class GrocerFoods
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
            this.AddGrocerBtn = new System.Windows.Forms.Button();
            this.UpdateGrocerBtn = new System.Windows.Forms.Button();
            this.DailyGrocerBtn = new System.Windows.Forms.Button();
            this.HomeBTN = new System.Windows.Forms.Button();
            this.BackBTN = new System.Windows.Forms.Button();
            this.ViewGRC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddGrocerBtn
            // 
            this.AddGrocerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddGrocerBtn.Location = new System.Drawing.Point(270, 156);
            this.AddGrocerBtn.Name = "AddGrocerBtn";
            this.AddGrocerBtn.Size = new System.Drawing.Size(165, 229);
            this.AddGrocerBtn.TabIndex = 0;
            this.AddGrocerBtn.Text = "ADD GROCERY STOCK";
            this.AddGrocerBtn.UseVisualStyleBackColor = true;
            this.AddGrocerBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateGrocerBtn
            // 
            this.UpdateGrocerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateGrocerBtn.Location = new System.Drawing.Point(482, 156);
            this.UpdateGrocerBtn.Name = "UpdateGrocerBtn";
            this.UpdateGrocerBtn.Size = new System.Drawing.Size(165, 229);
            this.UpdateGrocerBtn.TabIndex = 1;
            this.UpdateGrocerBtn.Text = "UPDATE GROCERY STOCK";
            this.UpdateGrocerBtn.UseVisualStyleBackColor = true;
            this.UpdateGrocerBtn.Click += new System.EventHandler(this.UpdateGrocerBtn_Click);
            // 
            // DailyGrocerBtn
            // 
            this.DailyGrocerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DailyGrocerBtn.Location = new System.Drawing.Point(700, 156);
            this.DailyGrocerBtn.Name = "DailyGrocerBtn";
            this.DailyGrocerBtn.Size = new System.Drawing.Size(165, 229);
            this.DailyGrocerBtn.TabIndex = 2;
            this.DailyGrocerBtn.Text = "UPDATE DAILY USING GROCERY";
            this.DailyGrocerBtn.UseVisualStyleBackColor = true;
            this.DailyGrocerBtn.Click += new System.EventHandler(this.DailyGrocerBtn_Click);
            // 
            // HomeBTN
            // 
            this.HomeBTN.Location = new System.Drawing.Point(95, 12);
            this.HomeBTN.Name = "HomeBTN";
            this.HomeBTN.Size = new System.Drawing.Size(92, 23);
            this.HomeBTN.TabIndex = 4;
            this.HomeBTN.Text = "HOME";
            this.HomeBTN.UseVisualStyleBackColor = true;
            // 
            // BackBTN
            // 
            this.BackBTN.Location = new System.Drawing.Point(14, 12);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(75, 23);
            this.BackBTN.TabIndex = 5;
            this.BackBTN.Text = "BACK";
            this.BackBTN.UseVisualStyleBackColor = true;
            this.BackBTN.Click += new System.EventHandler(this.BackBTN_Click);
            // 
            // ViewGRC
            // 
            this.ViewGRC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ViewGRC.Location = new System.Drawing.Point(60, 156);
            this.ViewGRC.Name = "ViewGRC";
            this.ViewGRC.Size = new System.Drawing.Size(165, 229);
            this.ViewGRC.TabIndex = 6;
            this.ViewGRC.Text = "VIEW GROCERY STOCK";
            this.ViewGRC.UseVisualStyleBackColor = true;
            this.ViewGRC.Click += new System.EventHandler(this.ViewGRC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "GROCERY FOODS DETAILS";
            // 
            // GrocerFoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ViewGRC);
            this.Controls.Add(this.BackBTN);
            this.Controls.Add(this.HomeBTN);
            this.Controls.Add(this.DailyGrocerBtn);
            this.Controls.Add(this.UpdateGrocerBtn);
            this.Controls.Add(this.AddGrocerBtn);
            this.Name = "GrocerFoods";
            this.Text = "GrocerFoods";
            this.Load += new System.EventHandler(this.GrocerFoods_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddGrocerBtn;
        private System.Windows.Forms.Button UpdateGrocerBtn;
        private System.Windows.Forms.Button DailyGrocerBtn;
        private System.Windows.Forms.Button HomeBTN;
        private System.Windows.Forms.Button BackBTN;
        private System.Windows.Forms.Button ViewGRC;
        private System.Windows.Forms.Label label1;
    }
}