using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class LOGIN : Form
    {
        SqlConnection CON = ConnectionManager.GetConnection();
        public static string uname="";
        public static string pswd = "";
        public static string usertype = "";
        public LOGIN()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            uname = Usernamebox.Text;
            pswd = passwordbox.Text;
            try
            {
                string query = "select * from users where username='" + uname + "' AND password='" + pswd + "'";
                CON.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, CON);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    usertype = (dr["usertype"].ToString());
                }
                CON.Close();

                //MessageBox.Show(usertype);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (usertype != "")
            {
                main2 m = new main2();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid user name or passowrd");
            }

            Usernamebox.Clear();
            passwordbox.Clear();
        

            

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Usernamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usernamebox_Click(object sender, EventArgs e)
        {
            Usernamebox.Clear();
        }

        private void passwordbox_Click(object sender, EventArgs e)
        {
            passwordbox.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
