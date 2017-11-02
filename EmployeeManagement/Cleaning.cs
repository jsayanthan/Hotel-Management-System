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
    public partial class Cleaning : Form
    {
      
           SqlConnection Con = ConnectionManager.GetConnection();
        public Cleaning()
        {
            InitializeComponent();
        }
      
        public void SearchData(String valueToFind)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select* from Cleaning where CONCAT(CleanID,EmpID) LIKE'%" + valueToFind + "%' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintananeHome Fr = new MaintananeHome();
            Fr.Show();
        }

        private void ADD_Click(object sender, EventArgs e)
        {
           try
            {
                String Clean = CleanID.Text;
                    String NOP = NoOfPerson.Text;
                    int NoOfPer = int.Parse(NOP);
                    String type = Type.SelectedItem.ToString();


               // String query2;
                if (radioButton1.Checked )
                {
                    String RoonID = RID.SelectedItem.ToString();

                    String query = "Insert into Cleaning(CleanID,NoOfPerson,dateofcleaning,Type,RoomID) values('" + Clean + "','" + NoOfPer + "','" + this.Date.Text + "','" + type + "','" + RoonID + "')";
                    function.ExecuteQuery(query, Con);
                    Debug.WriteLine(query);
  
                }
                else if (radioButton2.Checked )
                {
                    String HallID = HID.SelectedItem.ToString();
                    String query1 = "Insert into Cleaning(CleanID,NoOfPerson,dateofcleaning,Type,HallID) values('" + Clean + "','" + NoOfPer + "','"+this.Date.Text+"','" + type + "','" + HallID + "')";
                    function.ExecuteQuery(query1, Con);
                    Debug.WriteLine(query1);
                }


                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    String CempID = listBox1.Items[i].ToString();
                    string query2 = "Insert into Cleaner values('" + Clean + "','" + CempID + "')";
                    function.ExecuteQuery(query2, Con);

                    Debug.WriteLine(query2);
                }





                MessageBox.Show("Cleaning details successfully Added");
              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Cleaning_Load(object sender, EventArgs e)
        {
            CleanID.Text = function.getNextID("CleanID", "Cleaning", "CL", Con);
            radioButton1.Checked = true;
            String query4 = "select EmpID from Employee where Position = 'House keaper'";
            try
            {
                Con.Open();
                SqlDataAdapter sda= new SqlDataAdapter(query4, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "Employee");
                DataTable dt1 = ds1.Tables["Employee"];
               
                foreach (DataRow dr in dt1.Rows)
                {
                    EmpID.Items.Add(dr["EmpID"].ToString());
                }
                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
            Date.Text = DateTime.Now.ToString("yyyy-MM-dd");
          

           
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            SearchData(Search.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query= "Delete from Cleaning where CleanID = '" + CleanID.Text + "' ";
            function.ExecuteQuery(query,Con);
            MessageBox.Show("Cleaning details successfully Deleted");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            listBox1.Items.Clear();
            String query4 = "select Empid from Cleaner where CleanID='" + CleanID.Text + "'";
            Debug.WriteLine(query4);
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query4, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "Cleaner");
                DataTable dt1 = ds1.Tables["Cleaner"];

                foreach (DataRow dr in dt1.Rows)
                {
                    listBox1.Items.Add(dr["EmpID"].ToString());
                }
                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];
            CleanID.Text = SelectedRow.Cells[0].Value.ToString();
            NoOfPerson.Text = SelectedRow.Cells[1].Value.ToString();
            String Ent_date = SelectedRow.Cells[2].Value.ToString();
            DateTime dt = Convert.ToDateTime(Ent_date);
            Date.Text = dt.ToShortDateString();
            Type.Text = SelectedRow.Cells[3].Value.ToString();
            RID.SelectedItem = SelectedRow.Cells[4].Value.ToString();
            HID.SelectedItem = SelectedRow.Cells[4].Value.ToString();
            //// Amt.Text = SelectedRow.Cells[4].Value.ToString();
            //String Ent_date = SelectedRow.Cells[3].Value.ToString();
            //DateTime dt = Convert.ToDateTime(Ent_date);
            //Edate.Text = dt.ToShortDateString();
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                HID.Visible = false; 
                RID.Visible = true;
                NoOfPerson.Text = "1";
                NoOfPerson.Enabled = false;
                String query = "Select CL.CleanID,CL.NoOfPerson,Cl.dateofcleaning,Cl.Type,CL.RoomID,CR.Empid from Cleaning CL,Cleaner CR where CL.CleanID=CR.CleanID and CL.NoOfPerson=1";
                function.loadTable(query, dataGridView1);
                String query4 = "select RoomID from Room";
                try
                {
                    Con.Open();
                    SqlDataAdapter sda1 = new SqlDataAdapter(query4, Con);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "Room");
                    DataTable dt1 = ds1.Tables["Room"];

                    foreach (DataRow dr in dt1.Rows)
                    {
                        RID.Items.Add(dr["RoomID"].ToString());
                    }
                    Con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
               
                HID.Visible = true;
                RID.Visible = false;
                NoOfPerson.Text = "2";
                NoOfPerson.Enabled = true;
                String query2 = "Select CL.CleanID,CL.NoOfPerson,Cl.dateofcleaning,Cl.Type,CL.HallID,CR.Empid from Cleaning CL,Cleaner CR where CL.CleanID=CR.CleanID and CL.NoOfPerson>1";
                function.loadTable(query2,dataGridView1);
                String query = "select HallID from Halls";
                try
                {
                    Con.Open();
                    SqlDataAdapter sda1 = new SqlDataAdapter(query, Con);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "Halls");
                    DataTable dt1 = ds1.Tables["Halls"];

                    foreach (DataRow dr in dt1.Rows)
                    {
                        HID.Items.Add(dr["HallID"].ToString());
                    }
                    Con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(EmpID.Text))
            {
                MessageBox.Show("Already add this Employee");
                 listBox1.Items.Remove(EmpID.Text);
            }
            int Tid= listBox1.Items.Count;
            String person = NoOfPerson.Text;
            int Nper = int.Parse(person);
            if (Nper > Tid)
            {
                string empid = EmpID.SelectedItem.ToString();
                listBox1.Items.Add(empid);
                EmpID.Items.RemoveAt(EmpID.SelectedIndex);
                EmpID.SelectedIndex = 0;
                
                    
            }
            else
            {
                MessageBox.Show("Can't add");
            }
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EmpID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query3 = "delete from Cleaner where CleanID='" + CleanID.Text + "'";
            function.ExecuteQuery(query3,Con);
            String Clean = CleanID.Text;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                String CempID = listBox1.Items[i].ToString();
                String query2 = "Insert into Cleaner values('" + Clean + "','" + CempID + "')";
                function.ExecuteQuery(query2, Con);

                Debug.WriteLine(query2);
            }

            if (radioButton1.Checked)
            {
                String query = "update Cleaning set NoOfPerson='" + NoOfPerson.Text + "',dateofcleaning='" + this.Date.Text + "',Type='" + Type.SelectedItem.ToString() + "',RoomID='" + RID.Text + "' where CleanID='" + CleanID.Text + "'";
                function.ExecuteQuery(query, Con);
                Debug.WriteLine(query);

            }
            else
            {
                String query = "update Cleaning set NoOfPerson='" + NoOfPerson.Text + "',dateofcleaning='" + this.Date.Text + "',Type='" + Type.SelectedItem.ToString() + "',HAllID='" + HID.Text + "' where CleanID='" + CleanID.Text + "'";
                function.ExecuteQuery(query, Con);
                Debug.WriteLine(query);
            }
        }
    }
}
