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
using System.Configuration;

namespace EmployeeManagement
{
    public partial class RoomAvalblity : Form
    {
        public RoomAvalblity()
        {
            InitializeComponent();
        }

        private void RoomAvalblity_Load(object sender, EventArgs e)
        {
           
            SqlConnection con = ConnectionManager.GetConnection();
            String sql = "select  * from Room where status='Available'";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            DataSet ds = new DataSet();
            DataView dv;

            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                da.SelectCommand = cmd;
                da.Fill(ds, "expenses");
                da.Dispose();
                cmd.Dispose();
                con.Close();
                dv = ds.Tables[0].DefaultView;
                RoomGrid.DataSource = dv;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
