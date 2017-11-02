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
using System.Globalization;
using System.Diagnostics;

namespace EmployeeManagement
{
    public partial class Laundry : Form
    {
        String query = "select*from Laundry";
        SqlConnection Con = ConnectionManager.GetConnection();
       


        public Laundry()
        {
            InitializeComponent();
             
        }

       

        public String Payment;
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintananeHome Fr = new MaintananeHome();
            Fr.Show();
        }


        public void Laundry_Load(object sender, EventArgs e)
        {
            RID.Text = function.getNextID("LaundryID", "Laundry", "LA", Con);
            Wash.SelectedIndex = 0;
            Sta.SelectedIndex = 0;
            Edate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            function.loadTable(query,dataGridView1);
            UPrice.Enabled = false;

            String query4 = "select * from Room where status='Reserved'";
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query4, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "Room");
                DataTable dt1 = ds1.Tables["Room"];

                foreach (DataRow dr in dt1.Rows)
                {
                    RNo.Items.Add(dr["RoomID"].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }

        }

        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {


                if (RNo.Text == "" || Nitems.Text == "" || Res.Text == "")
                {
                    MessageBox.Show("Enter the values");

                }

                else
                {
                  
                    String Laundry = RID.Text;
                    String RoomNo = RNo.Text;
                    String NOI = Nitems.Text;
                    int NoOfItems = int.Parse(NOI);
                    String Washtype = Wash.SelectedItem.ToString();
                    String Status = Sta.SelectedItem.ToString();
                    String Amount = UPrice.Text;
                    float amount = float.Parse(Amount);
                    String Receiver = Res.Text;

                    String query = "Insert into Laundry(LaundryID,RoomID,Weight,EntryDate,DeliverDate,UnitPrice,WashType,Receiver,LaundryStatus,Status) values('" + Laundry + "', '" + RoomNo + "', '" + NoOfItems + "', '" + this.Edate.Text + "', '" + this.Ddate.Text + "','" + UPrice.Text + "', '" + Washtype + "','" + Receiver + "', '" + Status + "','Un Paid')";
                    function.ExecuteQuery(query, Con);
                    Debug.WriteLine(query);
                    MessageBox.Show("Laundry details added succesfully");
                    RID.Text = function.getNextID("LaundryID", "Laundry", "LA", Con);
                    function.loadTable(query, dataGridView1);
                    Clear_Data();



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Laundry_Load(Laundry laundry)
        {
            throw new NotImplementedException();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Wash_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str = Nitems.Text;
                int nitemsf = int.Parse(str);

                if (Wash.SelectedIndex == 1)
                {

                    UPrice.Text =  200.ToString();
                }
                else if (Wash.SelectedIndex == 2)
                {
                    UPrice.Text = ( 300).ToString();
                }
                else if (Wash.SelectedIndex == 3)
                {
                    UPrice.Text = ( 250).ToString();
                }
                else if (Wash.SelectedIndex == 4)
                {
                    UPrice.Text = (400).ToString();
                }
                else if (Wash.SelectedIndex == 5)
                {
                    UPrice.Text = ( 290).ToString();
                }
                else if (Wash.SelectedIndex == 6)
                {
                    UPrice.Text = ( 320).ToString();
                }
                else if (Wash.SelectedIndex == 7)
                {
                    UPrice.Text = ( 150).ToString();
                }
                else if (Wash.SelectedIndex == 8)
                {
                    UPrice.Text = ( 220).ToString();
                }
                else if (Wash.SelectedIndex == 9)
                {
                    UPrice.Text = ( 360).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        public void SearchData(String valueToFind)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select LA.LaundryID,LA.RoomID,LA.Weight,LA.EntryDate,LA.DeliverDate,LA.WashType,LA.Status,LA.Receiver,PA.TotalAmount from Laundry LA,Payment PA where LA.LaundryID=PA.LaundryID and CONCAT(LA.LaundryID,LA.RoomID) LIKE'%" + valueToFind + "%' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Con.Close();
        }
        public void Clear_Data()
        {
            RID.Text = "";
            RNo.Text = "";
            Nitems.Text = "";
            Wash.SelectedItem="0" ;
            Sta.SelectedItem = "0";
            UPrice.Text = "";
            Res.Text = "";
           
        }
        private void Edate_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];
            RID.Text = SelectedRow.Cells[0].Value.ToString();
            RNo.Text = SelectedRow.Cells[1].Value.ToString();
            Nitems.Text = SelectedRow.Cells[2].Value.ToString();
            String Ent_date = SelectedRow.Cells[3].Value.ToString();
            DateTime dt = Convert.ToDateTime(Ent_date);
            Edate.Text = dt.ToShortDateString();
            String Del_date = SelectedRow.Cells[4].Value.ToString();
            DateTime dt1 = Convert.ToDateTime(Del_date);
            Ddate.Text = dt1.ToString();
            UPrice.Text = SelectedRow.Cells[5].Value.ToString();
            Wash.SelectedItem = SelectedRow.Cells[6].Value.ToString();
            Res.Text = SelectedRow.Cells[7].Value.ToString();
            Sta.SelectedItem = SelectedRow.Cells[8].Value.ToString();
        }

        private void Ddate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = Ddate.Value.Date;
            DateTime dt2 = Convert.ToDateTime(Edate.Text);
            Edate.Text = dt2.ToShortDateString();

            if (dt1> dt2)
            {
             
            }
            else
            {
                MessageBox.Show("Invalid date");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               String query2 = "Delete from Laundry where LaundryID='" + RID.Text + "'";
                function.ExecuteQuery(query2, Con);
                MessageBox.Show("Laundry details Deleted succesfully");
                RID.Text = function.getNextID("LaundryID", "Laundry", "LA", Con);
                function.loadTable(query, dataGridView1);
                Clear_Data();
            }
            catch
            {

            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                String query1 = "update Laundry set RoomID='"+RNo.Text+"',Weight='" + Nitems.Text + "',EntryDate='" + Edate.Text + "',DeliverDate='" +this.Ddate.Text+ "',WashType='" + Wash.SelectedItem.ToString() + "',Status='" + Sta.SelectedItem.ToString() + "',Receiver='" +Res.Text+ "' where LaundryID='" + RID.Text + "'";
                function.ExecuteQuery(query1, Con);
                MessageBox.Show("Laundry details Update succesfully");
                RID.Text = function.getNextID("LaundryID", "Laundry", "LA", Con);
                function.loadTable(query, dataGridView1);
                RID.Text = function.getNextID("LaundryID", "Laundry", "LA", Con);
                function.loadTable(query, dataGridView1);
                Clear_Data();




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
          
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            String qry= "select*from Laundry where CONCAT(LaundryID,RoomID) LIKE'%" + Search.Text + "%' ";
            function.loadTable(qry, dataGridView1);
        }

        private void RNo_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void RNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nitems.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            laundrycrustal l = new laundrycrustal();
            l.Show();
        }
    }
}
