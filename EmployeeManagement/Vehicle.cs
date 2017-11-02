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
    public partial class Vehicle : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();
        string sql = "select * from vehicle ORDER BY vehicleID DESC ";
        public Vehicle()
        {
            InitializeComponent();
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            id.Text = function.getNextID("vehicleID", "vehicle", "VE", con);
            function.tableload(sql, con, dataGridView1, "vehicle");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add this vehicle?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (function.Regexp(@"^(([A-Z]{2})\-{1}([A-Z]{2,3})\-{1}(\d{4}))$", vehicle_number, pictureBox1) && (function.Regexp(@"^[a-zA-Z0-9]*$", engine_number, pictureBox2)) && (function.Regexp(@"^[a-zA-Z0-9]*$", Chassis_number, pictureBox3)) && (function.Regexp(@"^[A-Za-z]+$", textBox2, pictureBox4)) && (function.Regexp(@"^[0-9]*$", textBox1, pictureBox5)) && (function.Regexp(@"^[0-9]*$", textBox3, pictureBox6)))
                {

                    string qry = "INSERT INTO vehicle(vehicleID,vehicleNumber,engineNumber,chassisNumber,vehicleType,brand,model,initialAmount,amountPerkm,status,category) VALUES('" + id.Text + "','" + vehicle_number.Text + "','" + engine_number.Text + "','" + Chassis_number.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + status.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "')";
                    Debug.WriteLine(qry);
                    function.executesqlquerey(qry, con);
                    function.tableload(sql, con, dataGridView1, "vehicle");
                    id.Text = function.getNextID("vehicleID", "vehicle", "VE", con);
                    MessageBox.Show("Succes!");
                    comboBox4.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    status.Text = "";
                    function.ClearAllText(this);
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update this vehicle?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (function.Regexp(@"^(([A-Z]{2})\-{1}([A-Z]{2,3})\-{1}(\d{4}))$", vehicle_number, pictureBox1) && (function.Regexp(@"^[a-zA-Z0-9]*$", engine_number, pictureBox2)) && (function.Regexp(@"^[a-zA-Z0-9]*$", Chassis_number, pictureBox3)) && (function.Regexp(@"^[A-Za-z]+$", textBox2, pictureBox4)) && (function.Regexp(@"^[0-9]*$", textBox1, pictureBox5)) && (function.Regexp(@"^[0-9]*$", textBox3, pictureBox6)))
                {
                    string qry = "UPDATE vehicle SET vehicleNumber='" + vehicle_number.Text + "',engineNumber='" + engine_number.Text + "',chassisNumber='" + Chassis_number.Text + "',vehicleType='" + comboBox1.SelectedItem.ToString() + "',status='" + status.SelectedItem.ToString() + "',brand='" + comboBox4.SelectedItem.ToString() + "',model='" + textBox1.Text + "',initialAmount='" + textBox1.Text + "',amountPerkm='" + textBox3.Text + "' WHERE vehicleID='" + id.Text + "'";
                    function.executesqlquerey(qry, con);
                    function.tableload(sql, con, dataGridView1, "vehicle");
                    MessageBox.Show("Succes!");
                    comboBox4.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    status.Text = "";
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                    function.ClearAllText(this);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete this vehicle?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string qry = "DELETE FROM vehicle WHERE vehicleID ='" + id.Text + "'";
                function.executesqlquerey(qry, con);
                function.tableload(sql, con, dataGridView1, "vehicle");
                MessageBox.Show("Succes!");
                comboBox4.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                status.Text = "";
                function.ClearAllText(this);
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                pictureBox6.Image = null;
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > -1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                id.Text = selectedRow.Cells[0].Value.ToString();
                vehicle_number.Text = selectedRow.Cells[1].Value.ToString();
                engine_number.Text = selectedRow.Cells[2].Value.ToString();
                Chassis_number.Text = selectedRow.Cells[3].Value.ToString();
                comboBox1.Text = selectedRow.Cells[4].Value.ToString();
                comboBox4.Text = selectedRow.Cells[5].Value.ToString();
                textBox2.Text = selectedRow.Cells[6].Value.ToString();
                textBox1.Text = selectedRow.Cells[7].Value.ToString();
                textBox3.Text = selectedRow.Cells[8].Value.ToString();
                status.Text = selectedRow.Cells[10].Value.ToString();
                comboBox2.Text = selectedRow.Cells[9].Value.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string q="SELECT * FROM vehicle WHERE brand LIKE '"+'%'+textBox4.Text+'%'+"'";
            Debug.WriteLine(q);
            function.tableload(q, con, dataGridView1, "vehicle");
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[0-9]*$", textBox3, pictureBox6);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[0-9]*$", textBox1, pictureBox5);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[A-Za-z]+$", textBox2, pictureBox4);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Chassis_number_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[a-zA-Z0-9]*$", Chassis_number, pictureBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void engine_number_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[a-zA-Z0-9]", engine_number, pictureBox2);
        }

        private void vehicle_number_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^(([A-Z]{2})\-{1}([A-Z]{2,3})\-{1}(\d{4}))$", vehicle_number, pictureBox1);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            foreach(Control ctl in Parent.Controls)
            {
                if(ctl.GetType()==typeof(TextBox))
                {
                    ctl.Text = "";
                }
            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            VehiclesHome h = new VehiclesHome();
            h.Show();
            this.Dispose();
        }
    }
}
