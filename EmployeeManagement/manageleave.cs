using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeManagement
{
    public partial class manageleave : Form
    {

        SqlConnection CON = new SqlConnection(@"Data Source=DESKTOP-VPQ80BN;Initial Catalog=Hotel;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        public manageleave()
        {
            InitializeComponent();
        }


        public void Clear()
        {
            //CLEAR THE COMPONANTS 
            eid.Text = string.Empty;
             pos.Text = string.Empty;
              shift.Text = String.Empty;
               resone.Text = string.Empty;
                to.Text = null;
                  date.Text = null;

        }

        private void submit_Click(object sender, EventArgs e)
        {
            string edid = eid.Text;
             String ps = pos.Text;
              string shf = shift.Text;
               string rsn = resone.Text;
                DateTime too = to.Value.Date;
                 DateTime frm = date.Value.Date;
                  String todate = too.ToString();
                    String fromdate = frm.ToString();
            

            if (eid.Text == string.Empty || pos.Text == string.Empty || shift.Text == string.Empty || resone.Text == string.Empty)
             {
                MessageBox.Show("All The Details Should Be Given!");
             }
                else if(todate.Equals(fromdate))
                 {
                   MessageBox.Show("Dates Are Wrong!! Choose Deffrent Dates ");
                 }
            else if (too<frm)
            {
                MessageBox.Show("Dates Are Wrong!! Choose Deffrent Dates ");
            }

            else {
              try
              {
                    CON.Open();
                string Query = "INSERT INTO LeaveManage(ID,too,frome,Shifts,Position,Reson)VALUES('" + edid + "','" + too + "','" + frm + "','" + shf + "','" + ps + "','" + rsn + "')";
                      cmd = new SqlCommand(Query, CON);
                       int N = cmd.ExecuteNonQuery();
                         CON.Close();
                          MessageBox.Show("Leave sumbition Success!");
                           Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void eid_TextChanged(object sender, EventArgs e)
        {
           
            
            
    }

        private void eid_Leave(object sender, EventArgs e)
        {
       
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee frm = new Employee();      
            frm.ShowDialog();
        }

        private void View_Click(object sender, EventArgs e)
        {
           
            viewlev vi = new viewlev();     
            vi.ShowDialog();
        }
       

        private void eid_MouseLeave(object sender, EventArgs e)
        {
            //set the data in to text box
            String query = "select Shifts,Position from Employee where EmpID='" + eid.Text + "'";
            try
            {
                function.getcol(shift, "Shifts", query, CON);
                function.getcol(pos, "Position", query, CON);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            DateTime too = to.Value.Date;
            DateTime frm = date.Value.Date;
            DateTime current = DateTime.Now;
            String cur = current.ToString();
            String todate = too.ToString();
            String fromdate = frm.ToString();


           
             if (frm <=current)
            {
                MessageBox.Show("Dates Are Wrong!! Choose Deffrent Dates ");
            }
        }

        private void to_ValueChanged(object sender, EventArgs e)
        {
            DateTime too = to.Value.Date;
            DateTime frm = date.Value.Date;
            DateTime current = DateTime.Now;
            String cur = current.ToString();
            String todate = too.ToString();
            String fromdate = frm.ToString();


            if (too < frm)
            {
                MessageBox.Show("Dates Are Wrong!! Choose Deffrent Dates ");
            }
           
        }

        private void manageleave_Load(object sender, EventArgs e)
        {

        }
    }
    }
