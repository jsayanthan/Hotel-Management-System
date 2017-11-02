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
    public partial class Addlocations : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();
        string sql = "select * from location ";
        public Addlocations()
        {
            InitializeComponent();
        }

        private void Addlocations_Load(object sender, EventArgs e)
        {
            function.tableload(sql, con, dataGridView1, "location");
            label7.Text=function.getNextID("placecode","location","PC",con);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add this location?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((function.Regexp(@"^[A-Za-z]+$", textBox1, pictureBox1)) && (function.Regexp(@"^[0-9]*$", textBox2, pictureBox2)) && (function.Regexp(@"^[0-9]*$", textBox3, pictureBox3)))
                {
                    float a = float.Parse(textBox2.Text);
                    float m = a * 60;
                    Debug.WriteLine("INSERT INTO location(placecode,place,km,time) VALUES('" + label7.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + m + "')");
                    function.executesqlquerey("INSERT INTO location(placecode,place,km,time) VALUES('" + label7.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + m + "')", con);
                    function.tableload(sql, con, dataGridView1, "location");
                    label7.Text = function.getNextID("placecode", "location", "PC", con);
                    MessageBox.Show("Succes!");
                    function.ClearAllText(this);
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > -1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                label7.Text = selectedRow.Cells[0].Value.ToString();
                textBox1.Text = selectedRow.Cells[1].Value.ToString();
                textBox2.Text =selectedRow.Cells[3].Value.ToString();
                textBox3.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update this location?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((function.Regexp(@"^[A-Za-z]+$", textBox1, pictureBox1)) && (function.Regexp(@"^[0-9]*$", textBox2, pictureBox2)) && (function.Regexp(@"^[0-9]*$", textBox3, pictureBox3)))
                {
                    function.executesqlquerey("UPDATE location SET km='" + textBox3.Text + "',time='" + textBox2.Text + "',PLACE='" + textBox1.Text + "' WHERE placecode='" + label7.Text + "'", con);
                    function.tableload(sql, con, dataGridView1, "location");
                    label7.Text = function.getNextID("placecode", "location", "PC", con);
                    MessageBox.Show("Succes!");
                    function.ClearAllText(this);
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this location?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                function.executesqlquerey("DELETE FROM location WHERE place ='" + textBox1.Text + "'", con);
                function.tableload(sql, con, dataGridView1, "location");
                label7.Text = function.getNextID("placecode", "location", "PC", con);
                MessageBox.Show("Succes!");
                function.ClearAllText(this);
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                pictureBox3.Image = null;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[A-Za-z]+$", textBox1, pictureBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[0-9]*$", textBox2, pictureBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            function.Regexp(@"^[0-9]*$", textBox3, pictureBox3);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string qry = "SELECT * FROM location WHERE place LIKE'"+'%'+textBox4.Text+'%'+"' ";
            function.tableload(qry, con, dataGridView1, "location");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VehiclesHome h = new VehiclesHome();
            h.Show();
            this.Dispose();
        }
    }
}
