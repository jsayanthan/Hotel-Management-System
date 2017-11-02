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
using System.Data;
using System.IO;
namespace EmployeeManagement
{
    public partial class viewlev : Form
    {

        SqlConnection CON = new SqlConnection(@"Data Source=DESKTOP-VPQ80BN;Initial Catalog=Hotel;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        public viewlev()
        {
            InitializeComponent();
            DisplayData();
        }
        private void DisplayData()
        {
            CON.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select  * from LeaveManage", CON);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;
            CON.Close();
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult d = MessageBox.Show(" Are yor accept their Leave!", "Confirmation", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                try
                {
                    int i = e.RowIndex;

                    if (i >= 0)
                    {
                        DataGridViewRow r = dataGridView3.Rows[i];

                        String emid = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        String datetoo = dataGridView3.Rows[i].Cells[1].Value.ToString();
                        String datefrom = dataGridView3.Rows[i].Cells[2].Value.ToString();
                        String stat = "Accepted!";
                        CON.Open();
                        string qry = "UPDATE LeaveManage set Status='" + stat + "'  where ID='" + emid + "'and too='" + datetoo + "' and frome='" + datefrom + "'";
                        cmd = new SqlCommand(qry, CON);
                        int NM = cmd.ExecuteNonQuery();
                        CON.Close();
                        DisplayData();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {

                        String emid = dataGridView3.Rows[i].Cells[0].Value.ToString();
                        String datetoo = dataGridView3.Rows[i].Cells[1].Value.ToString();
                        String datefrom = dataGridView3.Rows[i].Cells[2].Value.ToString();
                        String stat = "Rejected!";
                        CON.Open();
                        string qry = "UPDATE LeaveManage set Status='" + stat + "' where ID='" + emid + "'and too='" + datetoo + "' and frome='" + datefrom + "'";
                        cmd = new SqlCommand(qry, CON);
                        int NM = cmd.ExecuteNonQuery();
                        CON.Close();
                        DisplayData();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void viewlev_Load(object sender, EventArgs e)
        {

        }
    }
}
