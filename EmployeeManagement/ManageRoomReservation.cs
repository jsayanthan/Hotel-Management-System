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
    public partial class ManageRoomReservation : Form
    {
        float diftotal;
        float finaltotal;
        float oldatotal;
        float oldbalancefrompaymentID;
        SqlConnection con = ConnectionManager.GetConnection();
        public ManageRoomReservation()
        {
            InitializeComponent();
        }    
       
        private void rrgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageRoomReservation_Load(object sender, EventArgs e)
        { 
            chkin.Enabled = false;
            panel1.Enabled = false;

 
             
            countrys.SelectedIndex = 0;
           
            String sql = " select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr.NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode from Customer c, ReservedRooms rr , RoomReservation r where r.ReservationID = rr.ReservationID and r.CustID = c.CustID  ";
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
                rrgrid.DataSource = dv;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
              string rrid = rrIds.Text;
            

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr.NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode from Customer c, ReservedRooms rr , RoomReservation r where    r.CustID = c.CustID and r.ReservationID = '" + rrid + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rrgrid.DataSource = dt;

            panel1.Enabled = true;
            groupBox1.Enabled = true;
            con.Close();

        }

        private void RoomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BedTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void chkin_ValueChanged(object sender, EventArgs e)
        {
            /*
          
              */
            DateTime dt1 = chkin.Value.Date;
            DateTime dt2 = DateTime.Now;

            if (dt1.Date < dt2.Date)
            {
                MessageBox.Show("Invalid Date");
            }

           
        }

        private void chkout_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = chkin.Value.Date;
            DateTime dt2 = chkout.Value.Date;
            DateTime chekinDate = chkin.Value.Date;
            DateTime chekoutDate = chkout.Value.Date;

            TimeSpan ts = chekoutDate - chekinDate;
            int days = ts.Days;

            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Invalid Date");
            }

        

            else if (days==0)
            {
                MessageBox.Show("Check in and Check out dates can't be same!");
            }
            ndays.Text = days.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cid = cIds.Text;

            // string query = "select c.CustID,c.FirstName,c.LastName,c.NIC_OR_Passport,c.Phone , c.Address, c.Country , r.ReservationID,r.RoomID,r.CheckIN,r.CheckOut,r.NoOfAdults , p.PaymentID,p.TotalAmount,p.AmountPaid,p.Discount,p.NetAmount, p.Balance from RoomReservation r, Customer c , Payment p where r.CustID = c.CustID and r.ReservationID = p.PaymentType and  r.ReservationID = '" + rrid + "' "; 


            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode ,p.  PaymentID  from RoomReservation r , Customer c , Payment p ,ReservedRooms rr where  r.CustID=c.CustID and r.ReservationID=p.ReserveID and rr.ReservationID=r.ReservationID  and  c.CustID='" + cid + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            rrgrid.DataSource = dt;

            panel1.Enabled = true;
            groupBox1.Enabled = true;
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = mail.ToString();
           

            //System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            
             if (fname.Text == "")
            {
                MessageBox.Show("Please enter Customer first name");
            }
            else if (!function.isText(fname.Text))
            {
                MessageBox.Show("Invalid Firstname");
            }

            else if (surname.Text == "")
            {
                MessageBox.Show("Please enter Customer Sur name");
            }


            else if (!function.isText(surname.Text))
            {
                MessageBox.Show("Invalid Surname");
            }

            else if (telephone.Text == "")
            {
                MessageBox.Show("Please enter Customer's Telephone Number");
            }


            else if (!function.isNumber(telephone.Text))
            {
                MessageBox.Show("Invalid Telephone Number");
            }
            else if (function.numCount(telephone.Text, 10))
            {
                MessageBox.Show("Telephone number should be in 10 Digits");

            }
            else if (mail.Text == "")
            {
                MessageBox.Show("Please enter Customer's Email Address");
            }
            else if (address.Text == "")
            {
                MessageBox.Show("Please enter Customer's Address");
            }
            else if (PCode.Text == "")
            {
                MessageBox.Show("Please enter Postal code");
            }
            else if (Nic_No.Text == "")
            {
                MessageBox.Show("Please enter Customer's Nic/Passport num");
            }



            else if (!function.IsValid(email))
            {
                MessageBox.Show("Invalid! Please Enter valid Email Address!!");
            }


            else
            {

                string rrid = rrIds.Text;
                string cid = cu.Text;


                String CID = cu.Text;
                String FNAME = fname.Text;
                String LNAME = surname.Text;
                String NIC = Nic_No.Text;
                String MAIL = mail.Text;
                String ADDRESS = address.Text;
                String COUNTRY = countrys.Text;
                String CONTACT = telephone.Text;
                String PostalCode = PCode.Text;

                String Paymenttype = RRID.Text;

                String reserveid = RRID.Text;
                String cusID = cu.Text;
                string chikindate = chkin.Value.Date.ToString();
                string chkoutdate = chkout.Value.Date.ToString();
                string adults = NoOfAdults.SelectedItem.ToString();
                string nday = ndays.Text;
                int ndayint = int.Parse(nday);
                float tota = float.Parse(roomtotal.Text);


                String datec = DateTime.Now.ToString("M/d/yyyy");

                try
                {
                    con.Open();


                    String query1 = "update Customer set FirstName='" + FNAME + "',LastName='" + LNAME + "',NIC_OR_Passport='" + NIC + "',Email='" + MAIL + "',Phone='" + CONTACT + "',Address='" + ADDRESS + "',PostalCode='" + PostalCode + "',Country='" + COUNTRY + "' where CustID='" + cid + "' ";
                    SqlDataAdapter updatedetails1 = new SqlDataAdapter(query1, con);
                    updatedetails1.SelectCommand.ExecuteNonQuery();


                    String str = "Select Total from ReservedRooms where RoomID='" + roomno.Text + "' ";
                    SqlDataAdapter sda = new SqlDataAdapter(str, con);
                    DataSet ds1 = new DataSet();
                    sda.Fill(ds1, "Room");
                    DataTable dt = ds1.Tables["Room"];

                    foreach (DataRow dr in dt.Rows)
                    {
                        oldatotal = float.Parse((dr["Total"]).ToString());


                    }


                    Debug.WriteLine("old is " + oldatotal);

                    String query2 = "update ReservedRooms set CheckIN='" + chikindate + "',CheckOut='" + chkoutdate + "',NoOfAdults='" + adults + "',NumOFDays=" + ndayint + ",Total=" + tota + "where RoomID='" + roomno.Text + "' ";
                    SqlDataAdapter updatedetails2 = new SqlDataAdapter(query2, con);
                    updatedetails2.SelectCommand.ExecuteNonQuery();
                    Debug.WriteLine(query2);

                    float newtotal = float.Parse(roomtotal.Text);
                    Debug.WriteLine("new is " + newtotal);

                    diftotal = newtotal - oldatotal;
                    Debug.WriteLine("difl is " + diftotal);

                    String str1 = "Select Balance from payment  where PaymentID='" + pid.Text + "' ";
                    SqlDataAdapter sda1 = new SqlDataAdapter(str1, con);
                    DataSet ds11 = new DataSet();
                    sda1.Fill(ds11, "Room");

                    DataTable dt1 = ds11.Tables["Room"];

                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        oldbalancefrompaymentID = float.Parse((dr1["Balance"]).ToString());


                    }

                    Debug.WriteLine("oldbalancefrompaymentID is " + oldbalancefrompaymentID);


                    finaltotal = oldbalancefrompaymentID + diftotal;
                    Debug.WriteLine("finaltotal is " + finaltotal);

                    String query3 = "update Payment set ReserveID='" + reserveid + "', Balance= " + finaltotal + " where PaymentID='" + pid.Text + "' ";
                    SqlDataAdapter updatedetails3 = new SqlDataAdapter(query3, con);
                    updatedetails3.SelectCommand.ExecuteNonQuery();
                    Debug.WriteLine(query3);


                    MessageBox.Show("Updated Succesfully!");

                    con.Close();
                    String sql = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr.NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode from Customer c, ReservedRooms rr , RoomReservation r where r.ReservationID = rr.ReservationID and r.CustID = c.CustID ";
                    function.loadTable(sql, rrgrid);


                    //Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want delete this Reservation?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {

                con.Open();
                string roomiddelete = roomno.Text;
                SqlDataAdapter deleteDtails = new SqlDataAdapter("Delete from ReservedRooms where RoomID= '" + roomiddelete + "'", con);
                deleteDtails.SelectCommand.ExecuteNonQuery();
 
                 
                con.Close();


                MessageBox.Show("Deleted the Data!");
                String sql = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr.NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode from Customer c, ReservedRooms rr , RoomReservation r where r.ReservationID = rr.ReservationID and r.CustID = c.CustID ";
                function.loadTable(sql, rrgrid);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Front f = new Front();
            f.Show();
            this.Hide();
        }

        private void NoOfAdults_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            String sql = "Select maxGuest from Room where RoomID='" + roomno.Text + "'";

            SqlDataAdapter sda1 = new SqlDataAdapter(sql, con);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "Table");
            DataTable dt1 = ds1.Tables["Table"];
            foreach (DataRow dr in dt1.Rows)
            {


                int noOfadultsint = int.Parse(NoOfAdults.SelectedItem.ToString());
                int dbmaxgues = int.Parse((dr["maxGuest"].ToString()));



                if (dbmaxgues < noOfadultsint)
                {
                    MessageBox.Show("Above Selected Room's Maximum Guests count is " + dbmaxgues + "  and You have select " + noOfadultsint + " Guests ,So Please check the Possible values");
                    NoOfAdults.SelectedItem = dbmaxgues.ToString();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // pranees.vinith ?



            }

        private void rrgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Enabled = true;
            groupBox1.Enabled = true;
            /* "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut ,
            rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,
            c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode   
            */
            int rowindex = rrgrid.CurrentCell.RowIndex;
            RRID.Text = rrgrid.Rows[rowindex].Cells[0].Value.ToString();
            cu.Text = rrgrid.Rows[rowindex].Cells[1].Value.ToString();
            roomno.Text = rrgrid.Rows[rowindex].Cells[2].Value.ToString();
            label41.Text = rrgrid.Rows[rowindex].Cells[3].Value.ToString();
            Rtype.Text = rrgrid.Rows[rowindex].Cells[4].Value.ToString();


            string chINs = rrgrid.Rows[rowindex].Cells[5].Value.ToString();
            DateTime dt = Convert.ToDateTime(chINs);
            chkin.Text = dt.ToShortDateString();

            string chOuts = rrgrid.Rows[rowindex].Cells[6].Value.ToString();
            DateTime dt1 = Convert.ToDateTime(chOuts);
            chkout.Text = dt1.ToShortDateString();
           

            ndays.Text = rrgrid.Rows[rowindex].Cells[7].Value.ToString();
            roomcost.Text = rrgrid.Rows[rowindex].Cells[8].Value.ToString();
            roomtotal.Text = rrgrid.Rows[rowindex].Cells[9].Value.ToString();
            NoOfAdults.SelectedItem = rrgrid.Rows[rowindex].Cells[10].Value.ToString();
            fname.Text = rrgrid.Rows[rowindex].Cells[11].Value.ToString();
            surname.Text = rrgrid.Rows[rowindex].Cells[12].Value.ToString();
            mail.Text = rrgrid.Rows[rowindex].Cells[13].Value.ToString();
            telephone.Text = rrgrid.Rows[rowindex].Cells[14].Value.ToString();
            Nic_No.Text = rrgrid.Rows[rowindex].Cells[15].Value.ToString();
            address.Text = rrgrid.Rows[rowindex].Cells[16].Value.ToString();
            countrys.Text = rrgrid.Rows[rowindex].Cells[17].Value.ToString();
            PCode.Text = rrgrid.Rows[rowindex].Cells[18].Value.ToString();
          


              

            
        }

        private void ndays_Click(object sender, EventArgs e)
        {
            
        }

        private void ndays_TextChanged(object sender, EventArgs e)
        {
            roomtotal.Text = ((float.Parse(roomcost.Text) * float.Parse (ndays.Text))).ToString();
           

             

            
        }

        private void chkout_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void chkout_MouseLeave(object sender, EventArgs e)
        {
           

        }

        private void chkout_MouseCaptureChanged(object sender, EventArgs e)
        {
           
        }

        private void chkout_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void chkout_DragDrop(object sender, DragEventArgs e)
        {
          
        }

        private void chkout_DragLeave(object sender, EventArgs e)
        {
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            function.ClearAllText(this);

        }
    }

         
     

         
        

       
         

      

       
    
}
     

