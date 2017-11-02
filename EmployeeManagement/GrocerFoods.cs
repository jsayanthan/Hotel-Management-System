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

namespace EmployeeManagement
{
    public partial class GrocerFoods : Form
    {
        public static SqlConnection CON = ConnectionManager.GetConnection();
        public GrocerFoods()
        {
            InitializeComponent();
            
            
           
        }

            

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewGrocer grc = new AddNewGrocer();
            this.Hide();
            grc.Show();
        }

        private void GrocerFoods_Load(object sender, EventArgs e)
        {
            

        }

        private void DailyGrocerBtn_Click(object sender, EventArgs e)
        {
            DailyUsageGrocer DUG = new DailyUsageGrocer();
            this.Hide();
            DUG.Show();
        }

        private void UpdateGrocerBtn_Click(object sender, EventArgs e)
        {
            UpdateGrocer UG = new UpdateGrocer();
            this.Hide();
            UG.Show();
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            StockHome sh = new StockHome();
            sh.Show();
            this.Hide();
        }

        private void ViewGRC_Click(object sender, EventArgs e)
        {
            ViewGrocer vg = new ViewGrocer();
            vg.Show();
            this.Hide();
        }
    }
}
