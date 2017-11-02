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

   
    public partial class Attendence : Form
    {
        SqlConnection CON = new SqlConnection(@"Data Source=DESKTOP-VPQ80BN;Initial Catalog=Hotel;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;

        public Attendence()
        {
            InitializeComponent();
            DisplayData();
        }
        public void Clear2()
        {
            //CLEAR THE COMPONANTS 
            eid.Text = string.Empty;
            pos.Text = string.Empty;
            sft.Text = String.Empty;
            name.Text = string.Empty;
            inntime.Text = null;
            dat.Text = null;

        }
        public void Clear()
        {
            //CLEAR THE COMPONANTS 
            eiod.Text = string.Empty;
            name1.Text = string.Empty;
            intm.Text = null;
            outime.Text = null;
            wdu.Text = null;
            min.Text = null;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Employee frm = new Employee();
            frm.ShowDialog();
        }

        private void eid_MouseLeave(object sender, EventArgs e)
        {
            
            try
            {
 
                String query = "select FirstName,Shifts,Position from Employee where EmpID='" + eid.Text + "'";
                function.getcol(name, "FirstName", query, CON);
                function.getcol(sft, "Shifts", query, CON);
                function.getcol(pos, "Position", query, CON);
          
          }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CON.Close();

        }

        private void gettime_Click(object sender, EventArgs e)
        {
           
            dat.Text = DateTime.Now.ToString("d/M/yyyy");

            inntime.Text = DateTime.Now.ToString("HH:mm:ss tt");
            gettime.Enabled = false;   //to avoid the dublication of the button will disabled after geting time and date
            
            
        }

        private void submit_Click(object sender, EventArgs e)
        {

             string edid = eid.Text;
               String ps = pos.Text;
                string shf = sft.Text;
                  DateTime inn = DateTime.Parse(inntime.Text);
                   DateTime dt = DateTime.Parse(dat.Text);
          
                      string fn = name.Text;
                        string attStatus = "Present";

            if (eid.Text == string.Empty || pos.Text == string.Empty || sft.Text == string.Empty || inntime.Text == string.Empty || dat.Text == string.Empty || name.Text == string.Empty)
            {
                MessageBox.Show("All Values Should Be Given!");
            }
            else
            {
                
                try
                {
                   
                    String query = "select Dates,EmpID from Attendance where EmpID='" + eid.Text + "' and Dates = '"+dt+"'";
                    if (!function.hasData(query, CON))
                    {

                        string Query = "INSERT INTO Attendance(EmpID,Name,InTime,Shifts,Position,Dates,AttendanceStatus)VALUES('" + edid + "','" + fn + "','" + inn + "','" + shf + "','" + ps + "','" + dt + "','" + attStatus + "')";
                        function.adddetails(Query,CON);
                        Debug.WriteLine(Query);
                        MessageBox.Show("submission Success!");
                        Clear2();
                        gettime.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Choose The Correct Employee!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                CON.Close();
                DisplayData();
            }
        }

        private void eiod_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                

                outime.Text = DateTime.Now.ToString("HH:mm:ss");
                String startTime = outime.Text = DateTime.Now.ToString("HH:mm:ss");
                String endTime = intm.Text.ToString();          //for working hours

                TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                wdu.Text = duration.ToString("hh");
                min.Text = duration.ToString("mm");

                button3.Enabled = false;

                int wdhour = int.Parse(wdu.Text.ToString());
                if (wdhour <= 9)
                {
                    OT.Text = "0";
                }
                else if (wdhour > 9)
                {
                    int oth = wdhour - 9;
                    OT.Text = oth.ToString();
                }

            
           
        }

        private void eiod_MouseLeave_1(object sender, EventArgs e)
        {
            try
            {
                

                String query = "select Name,InTime from Attendance where EmpID='" + eiod.Text + "'";
                function.getcol(name1,"Name", query, CON);
                function.getcol(intm, "InTime", query, CON);
                
               }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Clear2();
            gettime.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

           
            function.ClearAllText(this);
            button3.Enabled = true;
        }

        private void DisplayData()
        {
            CON.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select  * from Attendance", CON);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            CON.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime outtime = DateTime.Parse(outime.Text);
            DateTime intime = DateTime.Parse(intm.Text);

            String wdud = wdu.Text;
            String wmin = min.Text;
            
            
             try
            {


                String query = "select OutTime from Attendance where EmpID='" + eiod.Text + "' and Dates = '" + DateTime.Now.ToString("d/M/yyyy") + "'";
                Debug.WriteLine(query);
                if (function.getVal("OutTime", query, CON) =="")
                   {
                    
                    CON.Open();
                    string Query = " UPDATE Attendance set OutTime = '" + outtime + "',duration = '" + wdud + ':' + wmin + "',OverTime='" + OT.Text + "' where EmpID = '" + eiod.Text + "' and Dates = '" + DateTime.Now.ToString("d/M/yyyy") + "'";
                    Debug.WriteLine(Query);
                    cmd = new SqlCommand(Query, CON);
                    int N = cmd.ExecuteNonQuery();
                    
                    CON.Close();
                    MessageBox.Show("submission Success!");
                   Clear2();

                    DisplayData();
                    button3.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Choose The Correct Employee!");
                   


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                

                string Query = "select * from Attendance where Dates = '" + this.dateTimePicker2.Text + "' ";
                function.DisplayData(Query,dataGridView1,CON);

                string stat = "Present";
                string qry = "select count(EmpID) as count from Attendance where AttendanceStatus='" + stat + "' and Dates = '" + this.dateTimePicker2.Text + "' ";

                function.getcount(noOfpresent, "count", qry, CON);  //count the working employees
                label43.Visible = true;
                noOfpresent.Visible = true;

            }
            catch (Exception ex)
            {
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            DisplayData();
            label43.Visible = false;
            noOfpresent.Visible = false;
        }

        private void Attendence_Load(object sender, EventArgs e)
        {
           
        }

        private void name1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
