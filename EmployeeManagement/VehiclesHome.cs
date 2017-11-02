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
    public partial class VehiclesHome : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();
        DateTime now = DateTime.Now;
        public VehiclesHome()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM vehicleReservation WHERE startDate BETWEEN'" + now.Date + "'AND '"+now.Date.AddMinutes(2880)+"'";
            Debug.WriteLine(sql);
            function.tableload(sql, con, dataGridView1, "reservation");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VehicleReservation mr = new VehicleReservation();
            mr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VehicleMaintenance m = new VehicleMaintenance();
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vehicle v = new Vehicle();
            v.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Addlocations al = new Addlocations();
            al.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }
    }
}
