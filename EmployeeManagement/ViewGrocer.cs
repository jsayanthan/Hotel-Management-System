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
    public partial class ViewGrocer : Form
    {
        SqlConnection CON = ConnectionManager.GetConnection();
        public ViewGrocer()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("GrocerFoods");
        private void ViewGrocer_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from GrocerFoods";
                CON.Open();
                
                SqlDataAdapter sda = new SqlDataAdapter(query, CON);
                sda.Fill(dt);
                Viewgrc.DataSource = dt;

                function.loadrowcolour(Viewgrc,5);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            GrocerFoods gf = new GrocerFoods();
            this.Hide();
            gf.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Name like '%{0}%' ", searchbox.Text);
                Viewgrc.DataSource = dv.ToTable();

                function.loadrowcolour(Viewgrc,5);
            
            

        }
    }
}
