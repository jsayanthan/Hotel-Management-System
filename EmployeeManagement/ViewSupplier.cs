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
using System.Diagnostics;

namespace EmployeeManagement
{
    public partial class ViewSupplier : Form
    {
        SqlConnection CON = ConnectionManager.GetConnection();
        public ViewSupplier()
        {
            InitializeComponent();
        }

        private void ViewSup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSupplier es = new EditSupplier();
            es.Show();
            this.Hide();
            
        }

        DataTable dt = new DataTable("Supplier");
        private void ViewSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from Supplier";
                CON.Open();

                SqlDataAdapter sda = new SqlDataAdapter(query, CON);
                sda.Fill(dt);
                ViewSup.DataSource = dt;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("SupplierName like '%{0}%' ", SearchBox.Text);
            ViewSup.DataSource = dv.ToTable();

            
        }
    }
}
