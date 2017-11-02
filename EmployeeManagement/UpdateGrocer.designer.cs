namespace EmployeeManagement
{
    partial class UpdateGrocer
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
            this.GrocerComboBox = new System.Windows.Forms.ComboBox();
            this.GrocerName = new System.Windows.Forms.Label();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UnitPriceBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.QuantityBox = new System.Windows.Forms.TextBox();
            this.UpdateGrocerStock = new System.Windows.Forms.Button();
            this.UpdtGrocer = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.UnitBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SupCombo = new System.Windows.Forms.ComboBox();
            this.Homebtn = new System.Windows.Forms.Button();
            this.availabledgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.UpdtGrocer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availabledgv)).BeginInit();
            this.SuspendLayout();
            // 
            // GrocerComboBox
            // 
            this.GrocerComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrocerComboBox.FormattingEnabled = true;
            this.GrocerComboBox.Location = new System.Drawing.Point(153, 77);
            this.GrocerComboBox.Name = "GrocerComboBox";
            this.GrocerComboBox.Size = new System.Drawing.Size(121, 21);
            this.GrocerComboBox.TabIndex = 0;
            this.GrocerComboBox.SelectedIndexChanged += new System.EventHandler(this.GrocerComboBox_SelectedIndexChanged);
            this.GrocerComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GrocerComboBox_MouseClick);
            // 
            // GrocerName
            // 
            this.GrocerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrocerName.AutoSize = true;
            this.GrocerName.Location = new System.Drawing.Point(68, 80);
            this.GrocerName.Name = "GrocerName";
            this.GrocerName.Size = new System.Drawing.Size(35, 13);
            this.GrocerName.TabIndex = 1;
            this.GrocerName.Text = "Name";
            // 
            // UnitLabel
            // 
            this.UnitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(68, 116);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(26, 13);
            this.UnitLabel.TabIndex = 2;
            this.UnitLabel.Text = "Unit";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "UnitPrice";
            // 
            // UnitPriceBox
            // 
            this.UnitPriceBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnitPriceBox.Location = new System.Drawing.Point(405, 74);
            this.UnitPriceBox.Name = "UnitPriceBox";
            this.UnitPriceBox.Size = new System.Drawing.Size(118, 20);
            this.UnitPriceBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Quantity";
            // 
            // QuantityBox
            // 
            this.QuantityBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QuantityBox.Location = new System.Drawing.Point(608, 74);
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(121, 20);
            this.QuantityBox.TabIndex = 7;
            this.QuantityBox.MouseLeave += new System.EventHandler(this.Quantity_MouseLeave);
            // 
            // UpdateGrocerStock
            // 
            this.UpdateGrocerStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateGrocerStock.Location = new System.Drawing.Point(763, 116);
            this.UpdateGrocerStock.Name = "UpdateGrocerStock";
            this.UpdateGrocerStock.Size = new System.Drawing.Size(114, 23);
            this.UpdateGrocerStock.TabIndex = 8;
            this.UpdateGrocerStock.Text = "UPDATE";
            this.UpdateGrocerStock.UseVisualStyleBackColor = true;
            this.UpdateGrocerStock.Click += new System.EventHandler(this.UpdateGrocerStock_Click);
            // 
            // UpdtGrocer
            // 
            this.UpdtGrocer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdtGrocer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UpdtGrocer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UpdtGrocer.Location = new System.Drawing.Point(19, 158);
            this.UpdtGrocer.Name = "UpdtGrocer";
            this.UpdtGrocer.Size = new System.Drawing.Size(568, 365);
            this.UpdtGrocer.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Amount";
            // 
            // AmountBox
            // 
            this.AmountBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AmountBox.Location = new System.Drawing.Point(405, 109);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(118, 20);
            this.AmountBox.TabIndex = 11;
            // 
            // UnitBox
            // 
            this.UnitBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnitBox.Location = new System.Drawing.Point(153, 109);
            this.UnitBox.Name = "UnitBox";
            this.UnitBox.Size = new System.Drawing.Size(121, 20);
            this.UnitBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 31);
            this.label4.TabIndex = 26;
            this.label4.Text = "UPDATE GROCERY STOCK";
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.Location = new System.Drawing.Point(12, 21);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 28;
            this.BackButton.Text = "BACK";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Supplier";
            // 
            // SupCombo
            // 
            this.SupCombo.FormattingEnabled = true;
            this.SupCombo.Location = new System.Drawing.Point(608, 109);
            this.SupCombo.Name = "SupCombo";
            this.SupCombo.Size = new System.Drawing.Size(121, 21);
            this.SupCombo.TabIndex = 30;
            // 
            // Homebtn
            // 
            this.Homebtn.Location = new System.Drawing.Point(93, 21);
            this.Homebtn.Name = "Homebtn";
            this.Homebtn.Size = new System.Drawing.Size(75, 23);
            this.Homebtn.TabIndex = 31;
            this.Homebtn.Text = "HOME";
            this.Homebtn.UseVisualStyleBackColor = true;
            // 
            // availabledgv
            // 
            this.availabledgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availabledgv.Location = new System.Drawing.Point(593, 158);
            this.availabledgv.Name = "availabledgv";
            this.availabledgv.Size = new System.Drawing.Size(343, 365);
            this.availabledgv.TabIndex = 32;
            // 
            // UpdateGrocer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 535);
            this.Controls.Add(this.availabledgv);
            this.Controls.Add(this.Homebtn);
            this.Controls.Add(this.SupCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UnitBox);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UpdtGrocer);
            this.Controls.Add(this.UpdateGrocerStock);
            this.Controls.Add(this.QuantityBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UnitPriceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UnitLabel);
            this.Controls.Add(this.GrocerName);
            this.Controls.Add(this.GrocerComboBox);
            this.Name = "UpdateGrocer";
            this.Text = "UpdateGrocer";
            this.Load += new System.EventHandler(this.UpdateGrocer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UpdtGrocer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availabledgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GrocerComboBox;
        private System.Windows.Forms.Label GrocerName;
        private System.Windows.Forms.Label UnitLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UnitPriceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox QuantityBox;
        private System.Windows.Forms.Button UpdateGrocerStock;
        private System.Windows.Forms.DataGridView UpdtGrocer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.TextBox UnitBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SupCombo;
        private System.Windows.Forms.Button Homebtn;
        private System.Windows.Forms.DataGridView availabledgv;
    }
}

