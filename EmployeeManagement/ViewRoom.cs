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
    public partial class Add_Room : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        
        public Add_Room()
        {
            InitializeComponent();
        }
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-VPQ80BN;Initial Catalog=Hotel;Integrated Security=True");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
               

                 
            
        }

 

        private void AddBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Add_Room_Load(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection con = ConnectionManager.GetConnection();
                String str = "Select RoomID from Room ";
                SqlDataAdapter sda = new SqlDataAdapter(str, con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "Room");


                DataTable dt = ds1.Tables["Room"];


                foreach (DataRow dr in dt.Rows)
                {
                    room_id.Items.Add(dr["RoomID"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Statuscb.SelectedIndex = 0;
            /* Ac_Radiobutoon.Checked = true;
             Single.Checked = true;*/
            String sql = "select  * from Room ";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Single_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = room_id.SelectedItem.ToString();
            string rtype=  Room_Type.Text ;
            string fno=    Floor_Num.Text  ;
            string btype = Bed_Type.Text ;
            string cost = Costs.Text  ;
            string maxpersons = maxperson.Text  ;
            string status = Statuscb.Text ;

            try
            {
                con.Open();
                String query = "update Room set RoomType='" + rtype + "',FloorNo='" + fno + "',BedType='" + btype + "',Cost='" + cost + "',maxGuest='" + maxpersons + "',status='" + status + "' where RoomID='" + id + "' ";

                SqlDataAdapter updatedetails = new SqlDataAdapter(query, con);

                updatedetails.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Succesfully!");
                //Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            String loadtableQuery = "select * from Room";
            function.loadTable(loadtableQuery, RoomGrid);
             


        }

        private void Costs_TextChanged(object sender, EventArgs e)
        {

        }

        private void ABlock_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void room_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = room_id.SelectedItem.ToString();



            string query = "select * from Room where RoomID='" + id + "'";

            con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter(query, con);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "Table");
            DataTable dt1 = ds1.Tables["Table"];
            foreach (DataRow dr in dt1.Rows)
            {
                 Room_Type.SelectedItem = (dr["RoomType"].ToString());
                 Floor_Num.SelectedItem = (dr["FloorNo"].ToString());
                Bed_Type.SelectedItem = (dr["BedType"].ToString());
                Costs.Text = (dr["Cost"].ToString());
                maxperson.SelectedItem = (dr["maxGuest"].ToString());
                Statuscb.SelectedItem = (dr["status"].ToString());
            }

            con.Close();
        }

        private void RoomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = RoomGrid.CurrentCell.RowIndex;
            room_id.SelectedItem = RoomGrid.Rows[rowindex].Cells[0].Value.ToString();
            Room_Type.SelectedItem = RoomGrid.Rows[rowindex].Cells[1].Value.ToString();
            Floor_Num.SelectedItem = RoomGrid.Rows[rowindex].Cells[2].Value.ToString();
            Bed_Type.SelectedItem = RoomGrid.Rows[rowindex].Cells[3].Value.ToString();
            Costs.Text = RoomGrid.Rows[rowindex].Cells[4].Value.ToString();
            maxperson.SelectedItem = RoomGrid.Rows[rowindex].Cells[5].Value.ToString();
            Statuscb.SelectedItem = RoomGrid.Rows[rowindex].Cells[6].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Front f = new Front();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            roomcrystal r = new roomcrystal();
            r.Show();
        }
    }
}
