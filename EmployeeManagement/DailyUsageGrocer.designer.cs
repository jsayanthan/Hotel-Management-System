namespace EmployeeManagement
{
    partial class DailyUsageGrocer
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
            this.UnitBox = new System.Windows.Forms.TextBox();
            this.UsageGrocer = new System.Windows.Forms.DataGridView();
            this.UpdateGrocerStock = new System.Windows.Forms.Button();
            this.QuantityBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.GrocerName = new System.Windows.Forms.Label();
            this.GrocerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HomeButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.Availabledgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UsageGrocer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Availabledgv)).BeginInit();
            this.SuspendLayout();
            // 
            // UnitBox
            // 
            this.UnitBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnitBox.Location = new System.Drawing.Point(175, 101);
            this.UnitBox.Name = "UnitBox";
            this.UnitBox.Size = new System.Drawing.Size(121, 20);
            this.UnitBox.TabIndex = 24;
            // 
            // UsageGrocer
            // 
            this.UsageGrocer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsageGrocer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsageGrocer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsageGrocer.Location = new System.Drawing.Point(12, 155);
            this.UsageGrocer.Name = "UsageGrocer";
            this.UsageGrocer.Size = new System.Drawing.Size(579, 363);
            this.UsageGrocer.TabIndex = 21;
            // 
            // UpdateGrocerStock
            // 
            this.UpdateGrocerStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateGrocerStock.Location = new System.Drawing.Point(754, 108);
            this.UpdateGrocerStock.Name = "UpdateGrocerStock";
            this.UpdateGrocerStock.Size = new System.Drawing.Size(114, 23);
            this.UpdateGrocerStock.TabIndex = 20;
            this.UpdateGrocerStock.Text = "UPDATE";
            this.UpdateGrocerStock.UseVisualStyleBackColor = true;
            this.UpdateGrocerStock.Click += new System.EventHandler(this.UpdateGrocerStock_Click);
            // 
            // QuantityBox
            // 
            this.QuantityBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityBox.Location = new System.Drawing.Point(477, 70);
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(114, 20);
            this.QuantityBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Quantity";
            // 
            // UnitLabel
            // 
            this.UnitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(90, 108);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(26, 13);
            this.UnitLabel.TabIndex = 15;
            this.UnitLabel.Text = "Unit";
            // 
            // GrocerName
            // 
            this.GrocerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrocerName.AutoSize = true;
            this.GrocerName.Location = new System.Drawing.Point(90, 72);
            this.GrocerName.Name = "GrocerName";
            this.GrocerName.Size = new System.Drawing.Size(35, 13);
            this.GrocerName.TabIndex = 14;
            this.GrocerName.Text = "Name";
            // 
            // GrocerComboBox
            // 
            this.GrocerComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrocerComboBox.FormattingEnabled = true;
            this.GrocerComboBox.Location = new System.Drawing.Point(175, 69);
            this.GrocerComboBox.Name = "GrocerComboBox";
            this.GrocerComboBox.Size = new System.Drawing.Size(121, 21);
            this.GrocerComboBox.TabIndex = 13;
            this.GrocerComboBox.SelectedIndexChanged += new System.EventHandler(this.GrocerComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 31);
            this.label1.TabIndex = 25;
            this.label1.Text = "DAILY USAGE GROCERY";
            // 
            // HomeButton
            // 
            this.HomeButton.Location = new System.Drawing.Point(93, 12);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(75, 23);
            this.HomeButton.TabIndex = 26;
            this.HomeButton.Text = "HOME";
            this.HomeButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 27;
            this.BackButton.Text = "BACK";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Availabledgv
            // 
            this.Availabledgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Availabledgv.Location = new System.Drawing.Point(597, 155);
            this.Availabledgv.Name = "Availabledgv";
            this.Availabledgv.Size = new System.Drawing.Size(350, 363);
            this.Availabledgv.TabIndex = 28;
            // 
            // DailyUsageGrocer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 530);
            this.Controls.Add(this.Availabledgv);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UnitBox);
            this.Controls.Add(this.UsageGrocer);
            this.Controls.Add(this.UpdateGrocerStock);
            this.Controls.Add(this.QuantityBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.GrocerName);
            this.Controls.Add(this.GrocerComboBox);
            this.Name = "DailyUsageGrocer";
            this.Text = "DailyUsageGrocer";
            this.Load += new System.EventHandler(this.DailyUsageGrocer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsageGrocer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Availabledgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UnitBox;
        private System.Windows.Forms.DataGridView UsageGrocer;
        private System.Windows.Forms.Button UpdateGrocerStock;
        private System.Windows.Forms.TextBox QuantityBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UnitLabel;
        private System.Windows.Forms.Label GrocerName;
        private System.Windows.Forms.ComboBox GrocerComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView Availabledgv;
    }
}