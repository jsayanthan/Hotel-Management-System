namespace EmployeeManagement { 
    partial class BarMain
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
            this.barmanagement = new System.Windows.Forms.Button();
            this.gymmanagement = new System.Windows.Forms.Button();
            this.poolgamemanagement = new System.Windows.Forms.Button();
            this.beverageorder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // barmanagement
            // 
            this.barmanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barmanagement.Location = new System.Drawing.Point(41, 323);
            this.barmanagement.Name = "barmanagement";
            this.barmanagement.Size = new System.Drawing.Size(215, 69);
            this.barmanagement.TabIndex = 0;
            this.barmanagement.Text = "Bar Management";
            this.barmanagement.UseVisualStyleBackColor = true;
            this.barmanagement.Click += new System.EventHandler(this.button1_Click);
            // 
            // gymmanagement
            // 
            this.gymmanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymmanagement.Location = new System.Drawing.Point(628, 326);
            this.gymmanagement.Name = "gymmanagement";
            this.gymmanagement.Size = new System.Drawing.Size(215, 67);
            this.gymmanagement.TabIndex = 1;
            this.gymmanagement.Text = "Gym Management";
            this.gymmanagement.UseVisualStyleBackColor = true;
            this.gymmanagement.Click += new System.EventHandler(this.gymmanagement_Click);
            // 
            // poolgamemanagement
            // 
            this.poolgamemanagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poolgamemanagement.Location = new System.Drawing.Point(922, 326);
            this.poolgamemanagement.Name = "poolgamemanagement";
            this.poolgamemanagement.Size = new System.Drawing.Size(215, 66);
            this.poolgamemanagement.TabIndex = 2;
            this.poolgamemanagement.Text = "PoolGame Management";
            this.poolgamemanagement.UseVisualStyleBackColor = true;
            this.poolgamemanagement.Click += new System.EventHandler(this.poolgamemanagement_Click);
            // 
            // beverageorder
            // 
            this.beverageorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beverageorder.Location = new System.Drawing.Point(342, 326);
            this.beverageorder.Name = "beverageorder";
            this.beverageorder.Size = new System.Drawing.Size(215, 66);
            this.beverageorder.TabIndex = 3;
            this.beverageorder.Text = "Beverages Orders";
            this.beverageorder.UseVisualStyleBackColor = true;
            this.beverageorder.Click += new System.EventHandler(this.beverageorder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bar and  other services ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(1140, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BarMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1303, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.beverageorder);
            this.Controls.Add(this.poolgamemanagement);
            this.Controls.Add(this.gymmanagement);
            this.Controls.Add(this.barmanagement);
            this.Name = "BarMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BarMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button barmanagement;
        private System.Windows.Forms.Button gymmanagement;
        private System.Windows.Forms.Button poolgamemanagement;
        private System.Windows.Forms.Button beverageorder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

