namespace EmployeeManagement
{
    partial class manageleave
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
            this.submit = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.reson = new System.Windows.Forms.Panel();
            this.pos = new System.Windows.Forms.TextBox();
            this.shift = new System.Windows.Forms.TextBox();
            this.resone = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.eid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.View = new System.Windows.Forms.Button();
            this.reson.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request Leave";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(315, 473);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 70;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(426, 473);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 71;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(196, 473);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 72;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // reson
            // 
            this.reson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reson.Controls.Add(this.pos);
            this.reson.Controls.Add(this.shift);
            this.reson.Controls.Add(this.resone);
            this.reson.Controls.Add(this.label5);
            this.reson.Controls.Add(this.date);
            this.reson.Controls.Add(this.label4);
            this.reson.Controls.Add(this.label3);
            this.reson.Controls.Add(this.to);
            this.reson.Controls.Add(this.eid);
            this.reson.Controls.Add(this.label12);
            this.reson.Controls.Add(this.label10);
            this.reson.Controls.Add(this.label2);
            this.reson.Location = new System.Drawing.Point(120, 90);
            this.reson.Name = "reson";
            this.reson.Size = new System.Drawing.Size(422, 363);
            this.reson.TabIndex = 73;
            // 
            // pos
            // 
            this.pos.Enabled = false;
            this.pos.Location = new System.Drawing.Point(182, 229);
            this.pos.Name = "pos";
            this.pos.Size = new System.Drawing.Size(152, 20);
            this.pos.TabIndex = 83;
            // 
            // shift
            // 
            this.shift.Enabled = false;
            this.shift.Location = new System.Drawing.Point(182, 175);
            this.shift.Name = "shift";
            this.shift.Size = new System.Drawing.Size(152, 20);
            this.shift.TabIndex = 82;
            // 
            // resone
            // 
            this.resone.Location = new System.Drawing.Point(182, 278);
            this.resone.Name = "resone";
            this.resone.Size = new System.Drawing.Size(184, 65);
            this.resone.TabIndex = 81;
            this.resone.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 80;
            this.label5.Text = "Reason";
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(182, 74);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(99, 20);
            this.date.TabIndex = 79;
            this.date.Value = new System.DateTime(2017, 4, 1, 0, 0, 0, 0);
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 78;
            this.label4.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 76;
            this.label3.Text = "Position";
            // 
            // to
            // 
            this.to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.to.Location = new System.Drawing.Point(182, 117);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(99, 20);
            this.to.TabIndex = 74;
            this.to.Value = new System.DateTime(2017, 4, 1, 0, 0, 0, 0);
            this.to.ValueChanged += new System.EventHandler(this.to_ValueChanged);
            // 
            // eid
            // 
            this.eid.Location = new System.Drawing.Point(182, 21);
            this.eid.Name = "eid";
            this.eid.Size = new System.Drawing.Size(184, 20);
            this.eid.TabIndex = 73;
            this.eid.TextChanged += new System.EventHandler(this.eid_TextChanged);
            this.eid.Leave += new System.EventHandler(this.eid_Leave);
            this.eid.MouseLeave += new System.EventHandler(this.eid_MouseLeave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(58, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 18);
            this.label12.TabIndex = 72;
            this.label12.Text = "Shift";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(58, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 71;
            this.label10.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(56, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 70;
            this.label2.Text = "Employee ID";
            // 
            // View
            // 
            this.View.Location = new System.Drawing.Point(558, 90);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(75, 43);
            this.View.TabIndex = 74;
            this.View.Text = "View";
            this.View.UseVisualStyleBackColor = true;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // manageleave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.View);
            this.Controls.Add(this.reson);
            this.Controls.Add(this.back);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label1);
            this.Name = "manageleave";
            this.Text = "manageleave";
            this.Load += new System.EventHandler(this.manageleave_Load);
            this.reson.ResumeLayout(false);
            this.reson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel reson;
        private System.Windows.Forms.RichTextBox resone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker to;
        private System.Windows.Forms.TextBox eid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pos;
        private System.Windows.Forms.TextBox shift;
        private System.Windows.Forms.Button View;
    }
}