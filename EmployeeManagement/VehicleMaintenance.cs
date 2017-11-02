using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace EmployeeManagement
{
    public partial class VehicleMaintenance : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();
        string sql = "select * from vehicle_maintenances ORDER BY maintenanceID DESC ";
        DateTime now = DateTime.Now;
        public VehicleMaintenance()
        {
            InitializeComponent();
        }

        private void Maintenance_Load(object sender, EventArgs e)
        {
            mid.Text = function.getNextID("maintenanceID", "vehicle_maintenances", "VM", con);
            function.tableload(sql, con, dataGridView3, "vehicle_maintenances");
            DataTable dt = function.getcomboBox("SELECT vehicleNumber from vehicle", con);
            foreach (DataRow dr in dt.Rows)
            {
                ve_no.Items.Add(dr["vehicleNumber"].ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add this vehicle maintenances info?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((function.Regexp(@"^[A-Za-z]+$", descriptions, pictureBox1)) && (function.Regexp(@"[^a-z]\d*\.\d{2}", amounts, pictureBox2)))
                {
                    float a = float.Parse(amounts.Text);
                    function.executesqlquerey("INSERT INTO vehicle_maintenances(maintenanceID, vehicleNumber, Date, description, amount) VALUES('" + mid.Text + "', '" + ve_no.SelectedItem.ToString() + "', '" + this.dateTimePicker1.Text + "','" + descriptions.Text + "','" + float.Parse(amounts.Text) * -1 + "')", con);
                    function.executesqlquerey("UPDATE vehicle SET status = '" + comboBox3.SelectedItem.ToString() + "' WHERE vehicleNumber = '" + ve_no.SelectedItem.ToString() + "' ", con);
                    function.tableload("SELECT * FROM vehicle_maintenances ORDER BY maintenanceID DESC ", con, dataGridView3, "vehicle_maintenances");
                    function.tableload(sql, con, dataGridView3, "vehicle_maintenances");
                    string paymentsql = "INSERT INTO payment(paymentID,VehMaintID,amountPaid,TotalAmount,Discount,NetAmount,balance,date) VALUES('" + function.getNextID("PaymentID", "Payment", "PA", con) + "','" + mid.Text + "','" + float.Parse(amounts.Text) * -1 + "','" + float.Parse(amounts.Text) * -1 + "',0,'" + float.Parse(amounts.Text) * -1 + "',0,'" + now.Date + "')";
                    Debug.WriteLine(paymentsql);
                    function.executesqlquerey(paymentsql, con);
                    function.tableload(sql, con, dataGridView3, "vehicle_maintenances");
                    MessageBox.Show("Succes!");
                    mid.Text = function.getNextID("maintenanceID", "vehicle_maintenances", "VM", con);
                    comboBox3.Text = "";
                    ve_no.Text = "";
                    function.ClearAllText(this);
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update this vehicle maintenances info?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((function.Regexp(@"^[A-Za-z]+$", descriptions, pictureBox1)) && (function.Regexp(@"[^a-z]\d*\.\d{2}", amounts, pictureBox2)))
                {
                    string sql = "UPDATE vehicle_maintenances SET vehicleNumber='" + ve_no.Text + "',date='" + dateTimePicker1.Text + "',description='" + descriptions.Text + "',amount='" + amounts.Text + "' WHERE maintenanceID='" + mid.Text + "' ";
                    function.executesqlquerey(sql, con);
                    Debug.WriteLine(sql);
                    function.executesqlquerey("UPDATE vehicle SET status = '" + comboBox3.SelectedItem.ToString() + "' WHERE vehicleNumber = '" + ve_no.SelectedItem.ToString() + "' ", con);
                    function.executesqlquerey("UPDATE payment SET amountPaid='" + float.Parse(amounts.Text) * -1 + "',TotalAmount='" + float.Parse(amounts.Text) * -1 + "',NetAmount='" + float.Parse(amounts.Text) * -1 + "' WHERE VehMaintID='" + mid.Text + "'", con);
                    MessageBox.Show("Succes!");
                    comboBox3.Text = "";
                    ve_no.Text = "";
                    function.ClearAllText(this);
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this vehicle maintenances info?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string qry = "DELETE FROM vehicle_maintenances WHERE maintenanceID='" + mid.Text + "'";
                Debug.WriteLine(qry);
                function.executesqlquerey(qry, con);
                function.tableload(sql, con, dataGridView3, "vehicle_maintenances");
                mid.Text = function.getNextID("maintenanceID", "vehicle_maintenances", "VM", con);
                MessageBox.Show("Succes!");
                comboBox3.Text = "";
                ve_no.Text = "";
                function.ClearAllText(this);
                pictureBox1.Image = null;
                pictureBox2.Image = null;
            }

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow selectedRow = dataGridView3.Rows[index];
                mid.Text = selectedRow.Cells[0].Value.ToString();
                descriptions.Text = selectedRow.Cells[3].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells[2].Value.ToString();
                amounts.Text = selectedRow.Cells[4].Value.ToString();
                ve_no.Text= selectedRow.Cells[1].Value.ToString();
                string sql = "SELECT status FROM vehicle WHERE vehicleNumber='"+ve_no.Text+"' ";
                Debug.WriteLine(sql);
                DataTable dt=function.getcomboBox(sql, con);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox3.Text=dr["status"].ToString();
                }

            }
        }

        private void descriptions_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[A-Za-z]+$", descriptions, pictureBox1);
        }

        private void amounts_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"[^a-z]\d*\.\d{2}", amounts, pictureBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string q = "SELECT * FROM vehicle_maintenances WHERE description LIKE '" + '%' + textBox1.Text + '%' + "'";
            Debug.WriteLine(q);
            function.tableload(q, con, dataGridView3, "vehicle_maintenances");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VehiclesHome h = new VehiclesHome();
            h.Show();
            this.Dispose();
        }
    }
}
