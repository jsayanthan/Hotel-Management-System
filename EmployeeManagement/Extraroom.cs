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
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace EmployeeManagement
{
   
    public partial class Extraroom : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        string reserveids ;
        string roomids;
        string NoOfAdultss ;
        string NoOfChilds ;
        string rTypes ;
        string bTypes ;
        string nosday ;
        string cost ;
        string tot ;
        string datein ;
        string dateout;
        public int count = 0;
        string removetotal;
        public Extraroom()
        {


            
            InitializeComponent();
        }

        private void Extraroom_Load(object sender, EventArgs e)
        {
            con.Open();
            comboBox1.SelectedIndex = 0;
            RoomIDl.Visible = false;
             /*RoomTypeComboBox.SelectedIndex =2;
            BedTypeCombo.SelectedIndex = 2;
            noOfRooms.SelectedIndex = 0;
            NoOdChild.SelectedIndex = 0;
            NoOfAdults.SelectedIndex = 0; */
            panel2.Enabled = false;
            button5.Visible = false;
                 //Which rooms are available RoomID to RoomIDCombobox
            String sql = "Select * from Room where status='Available' ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Room");
            DataTable dt = ds.Tables["Room"];
            foreach (DataRow dr in dt.Rows)
            {
                RoomIDList.Items.Add(dr["RoomID"]  );
            }


            try
            {
                SqlConnection con = ConnectionManager.GetConnection();
                String str = " select * from Customer where status='Check In' ";
                SqlDataAdapter sda1 = new SqlDataAdapter(str, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Customer");


                DataTable dt1 = ds1.Tables["Customer"];


                foreach (DataRow dr in dt1.Rows)
                {
                    cIds.Items.Add(dr["CustID"]);
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            con.Close();
             
        }

       
        private void button1_Click(object sender, EventArgs e)
        {  

        }

        private void RoomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            BedTypeCombo.Enabled = true;
            int SIndex = RoomTypeComboBox.SelectedIndex;
            if (SIndex == 1)
            {

                
                String sql = "Select * from Room where status='Available' and  RoomType='A/C'";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Room");


                DataTable dt = ds.Tables["Room"];

                RoomIDList.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {


                    RoomIDList.Items.Add(dr["RoomID"]);


                }
            }
            else if (SIndex == 2)
            {
                
                String sql = "Select * from Room where status='Available' and  RoomType='Non A/C'";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Room");


                DataTable dt = ds.Tables["Room"];

                RoomIDList.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {

                    //label11.Text = dr["type"].ToString();
                    RoomIDList.Items.Add(dr["RoomID"]);
                    count++;

                }
            }
            con.Close();
        }

        private void BedTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                int RoomIndex = RoomTypeComboBox.SelectedIndex;
                int BedIndex = RoomTypeComboBox.SelectedIndex;
                if (RoomIndex == 1 && BedIndex == 1)
                {
 
                    String sql = "Select * from Room where status='Available' and  RoomType='A/C' and BedType='Single'";
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Room");


                    DataTable dt = ds.Tables["Room"];

                    RoomIDList.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {


                        RoomIDList.Items.Add(dr["RoomID"]);
                        count++;

                    }
                }
                else if (RoomIndex == 1 && BedIndex == 2)
                {

                  
                    String sql = "Select * from Room where status='Available' and  RoomType='A/C' and BedType='Double'";
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Room");


                    DataTable dt = ds.Tables["Room"];

                    RoomIDList.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {


                        RoomIDList.Items.Add(dr["RoomID"]);
                        count++;

                    }
                }

                else if (RoomIndex == 2 && BedIndex == 1)
                {
                     
                    String sql = "Select * from Room where status='Available' and  RoomType='Non A/C' and BedType='Single'";
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Room");


                    DataTable dt = ds.Tables["Room"];

                    RoomIDList.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {


                        RoomIDList.Items.Add(dr["RoomID"]);


                    }
                }
                else if (RoomIndex == 2 && BedIndex == 2)
                {

                    SqlConnection con = ConnectionManager.GetConnection();
                    String sql = "Select * from Room where status='Available' and  RoomType='Non A/C' and BedType='Double'";
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Room");


                    DataTable dt = ds.Tables["Room"];

                    RoomIDList.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {


                        RoomIDList.Items.Add(dr["RoomID"]);


                    }
                }
            }
        }

        private void chkin_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = chkin.Value.Date;
            DateTime dt2 = DateTime.Now;

            if (dt1.Date < dt2.Date)
            {
                MessageBox.Show("Invalid Date");
            }
            else
            {
                //It's an earlier or equal date
            }


            DateTime chekinDate = chkin.Value.Date;
            DateTime chekoutDate = chkout.Value.Date;

            TimeSpan ts = chekoutDate - chekinDate;
            int days = ts.Days;
            NumOFDays.Text = days.ToString();
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

            NumOFDays.Text = days.ToString();
        }

        private void noOfRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            String counts = RoomIDList.Items.Count.ToString();
            count = int.Parse(counts) + reservedrooms.Rows.Count - 1;
            //MessageBox.Show((reservedrooms.Rows.Count - 1).ToString());
            try
            {

                int RoomcountI = noOfRooms.SelectedIndex + 1;

                if (count < RoomcountI)
                    MessageBox.Show("Rooms not enough");
                else
                    RoomIDList.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NoOfAdults_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (RoomIDList.SelectedIndex < 0)
            {
                MessageBox.Show("Select RoomID first");

            }
            else {

                String sql = "Select maxGuest from Room where RoomID='" + RoomIDList.SelectedItem.ToString() + "'";

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
             

        }

        private void roomcost_TextChanged(object sender, EventArgs e)
        {
            float amountf = float.Parse(roomcost.Text);
            float numOfDaysf = float.Parse(NumOFDays.Text);
            roomtotal.Text = (numOfDaysf * amountf).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RoomTypeComboBox.Text == ""  )
            {
                MessageBox.Show("Select Room Type first");
            }
            else if (BedTypeCombo.Text == "")
            {
                MessageBox.Show("Select Bed Type first");
            }

            else if (noOfRooms.Text == "")
            {
                MessageBox.Show("Select No Of Roms");
            }
            else if (NoOfAdults.Text == "" || NoOdChild.Text == "")
            {
                MessageBox.Show("Select no of members first");
            }
            else if (reservedrooms.Rows.Count >= (noOfRooms.SelectedIndex + 2))
            {
                MessageBox.Show("You can't add extra rooms");
            }
            else
            {
                SqlConnection con = ConnectionManager.GetConnection();
                //con.Open();

                String sql = "Select maxGuest from Room where RoomID='" + RoomIDList.SelectedItem.ToString() + "'";

                SqlDataAdapter sda1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];
                foreach (DataRow dr in dt1.Rows)
                {


                    int noOfadultsint = int.Parse(NoOfAdults.SelectedItem.ToString());
                    int dbmaxgues = int.Parse((dr["maxGuest"].ToString()));

                   // con.Close();

                    if (dbmaxgues < noOfadultsint)
                    {
                        MessageBox.Show("Above Selected Room's Maximum Guests count is " + dbmaxgues + "  and You have select " + noOfadultsint + " Guests ,So Please check the Possible values");
                    }
                    else
                    {
                       

                        string Roomid = RoomIDList.SelectedItem.ToString();
                        int adults = int.Parse(NoOfAdults.SelectedItem.ToString());
                        int child = int.Parse(NoOdChild.SelectedItem.ToString());
                        string btyp = BedTypeCombo.SelectedItem.ToString();
                        String rtyp = RoomTypeComboBox.SelectedItem.ToString();
                        string chikindate = chkin.Value.Date.ToString();
                        string chkoutdate = chkout.Value.Date.ToString();
                        int numofDays = int.Parse(NumOFDays.Text);
                        float costs = float.Parse(roomcost.Text);
                        float Total = float.Parse(roomtotal.Text);
                        chikindate = chkin.Value.Date.ToString();
                        chkoutdate = chkout.Value.Date.ToString();
                        string[] row = { RRID.Text, Roomid, btyp, rtyp, adults.ToString(), child.ToString(), costs.ToString(), numofDays.ToString(), Total.ToString(), chikindate, chkoutdate };
                        reservedrooms.Rows.Add(row);


                        float amountf = float.Parse(roomcost.Text);
                        float numOfDaysf = float.Parse(NumOFDays.Text);
                        roomtotal.Text = ((numOfDaysf * amountf).ToString());


                        Tamount_textbox.Text = (float.Parse(Tamount_textbox.Text) + float.Parse(roomtotal.Text)).ToString();
                        Blance.Text = Tamount_textbox.Text;
                    }


                }

                RoomIDList.Items.RemoveAt(RoomIDList.SelectedIndex);

            }
        }

        private void RoomIDList_MouseClick(object sender, MouseEventArgs e)
        {
            string RoomIDs = RoomIDList.SelectedItem.ToString();
            //ReservedRoomList.Items.Add(RoomIDList.SelectedItem);
            //RoomIDList.Items.Remove(RoomIDList.SelectedItem);



            String sqls = "Select Cost from Room where RoomID='" + RoomIDs + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sqls, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Room");


            DataTable dt = ds.Tables["Room"];

            //RoomIDList.Items.Clear();
            foreach (DataRow dr1 in dt.Rows)
            {

                roomcost.Text = dr1["Cost"].ToString();

            }
        }

        private void NumOFDays_TextChanged(object sender, EventArgs e)
        {
            float amountf = float.Parse(roomcost.Text);
            float numOfDaysf = float.Parse(NumOFDays.Text);
            roomtotal.Text = (numOfDaysf * amountf).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            try
            {
                
                String str = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr.NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country,c.PostalCode from Customer c, ReservedRooms rr , RoomReservation r where r.ReservationID = rr.ReservationID and c.CustID = '" + cIds.Text + "'";
                Debug.WriteLine(str);
                SqlDataAdapter sda = new SqlDataAdapter(str, con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "Room");


                DataTable dt1 = ds1.Tables["Room"];


                foreach (DataRow dr in dt1.Rows)
                {
                    name.Text = (dr["FirstName"].ToString());
                     
                    RRID.Text = (dr["ReservationID"].ToString());
                    cu.Text = (dr["CustID"].ToString());
                    //Debug.WriteLine(dr["CustID"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



            

            /*
            //con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults ,p.  PaymentID   from RoomReservation r , Customer c , Payment p ,ReservedRooms rr where  r.CustID=c.CustID and r.ReservationID=p.ReserveID and rr.ReservationID=r.ReservationID  and  c.CustID='" + cIds.Text + "' ";
           // Debug.WriteLine(cmd.CommandText = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults ,p.  PaymentID   from RoomReservation r , Customer c , Payment p ,ReservedRooms rr where  r.CustID=c.CustID and r.ReservationID=p.ReserveID and rr.ReservationID=r.ReservationID  and  c.CustID='" + cIds.Text + "' ");
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reservegrid.DataSource = dt;
            //con.Close();*/

            string sql= "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults ,p.  PaymentID   from RoomReservation r , Customer c , Payment p ,ReservedRooms rr where  r.CustID=c.CustID and r.ReservationID=p.ReserveID and rr.ReservationID=r.ReservationID  and  c.CustID='" + cu.Text + "' ";
            function.loadTable(sql,reservegrid);
            RRID.Text = function.getNextID("ReservationID", "RoomReservation", "RR", con);
            PID.Text = function.getNextID("PaymentID", "Payment", "PA", con);
        }

        private void Reserve_Click(object sender, EventArgs e)
        {
            if (reservedrooms.Rows.Count == 1)
            {
                MessageBox.Show("Please Reserve atleast one room");
            }
            else {

                String CID = cu.Text;

                String datec = DateTime.Now.ToString("M/d/yyyy");
                String reserveid = RRID.Text;
                String cusID = cu.Text;
                string chikindate = chkin.Value.Date.ToString();
                string chkoutdate = chkout.Value.Date.ToString();
                string adults = NoOfAdults.Text;
                string child = NoOdChild.Text;
                //string roomid = RoomIDList.SelectedItem.ToString();
                String Rtype = RoomTypeComboBox.Text;
                String Btype = BedTypeCombo.Text;
                  String Pid = PID.Text;
                String ReserveID = RRID.Text;
                String Total = Tamount_textbox.Text;
                String Paid = amount_PAid.Text;
                String Discount = discount_textbox.Text;
                String NetAmount = netamount_text.Text;
                String Balance = Blance.Text;


                try
                {

                    // con.Open();


                   


                    for (int i = 0; i < reservedrooms.Rows.Count - 1; i++)
                    {

                        reserveids = reservedrooms.Rows[i].Cells[0].Value.ToString();
                        roomids = reservedrooms.Rows[i].Cells[1].Value.ToString();
                        NoOfAdultss = reservedrooms.Rows[i].Cells[4].Value.ToString();
                        NoOfChilds = reservedrooms.Rows[i].Cells[5].Value.ToString();
                        rTypes = reservedrooms.Rows[i].Cells[3].Value.ToString();
                        bTypes = reservedrooms.Rows[i].Cells[2].Value.ToString();
                        nosday = reservedrooms.Rows[i].Cells[7].Value.ToString();
                        cost = reservedrooms.Rows[i].Cells[6].Value.ToString();
                        tot = reservedrooms.Rows[i].Cells[8].Value.ToString();
                        datein = reservedrooms.Rows[i].Cells[9].Value.ToString();
                        dateout = reservedrooms.Rows[i].Cells[10].Value.ToString();

                        string status = comboBox1.SelectedItem.ToString();


                        string query4 = "insert into RoomReservation  values('" + reserveids + "','" + cu.Text + "'  ,'" + status + "')";
                        Debug.WriteLine(query4);
                        function.ExecuteQuery(query4, con);

                        string query5 = "insert into ReservedRooms (ReservationID,RoomID,NoOfAdults,NoOfChild,rType,bType,RoomCost,NumOFDays,Total,CheckIN,CheckOut) values('" + reserveids + "','" + roomids + "'  ,'" + NoOfAdultss + "','" + NoOfChilds + "','" + rTypes + "','" + bTypes + "','" + cost + "','" + nosday + "','" + tot + "','" + datein + "','" + dateout + "')";
                        Debug.WriteLine(query5);
                        function.ExecuteQuery(query5, con);

                        String querys = "update Room set status='Reserved' where RoomID='" + roomids + "' ";
                        Debug.WriteLine(querys);
                        function.ExecuteQuery(querys, con);

                    }
                   

                    String query3 = "insert into Payment (PaymentID,ReserveID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date)values ('" + Pid + "','" + ReserveID + "','" + Total + "','" + Paid + "','" + Discount + "','" + NetAmount + "','" + Balance + "','" + datec + "')";
                    Debug.WriteLine(query3);
                    function.ExecuteQuery(query3, con);

                    MessageBox.Show("Reservation Successful! ");

                    string sql = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults ,p.  PaymentID   from RoomReservation r , Customer c , Payment p ,ReservedRooms rr where  r.CustID=c.CustID and r.ReservationID=p.ReserveID and rr.ReservationID=r.ReservationID  and  c.CustID='" + cu.Text + "' ";
                    function.loadTable(sql, reservegrid);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            
        }

        private void discount_textbox_TextChanged(object sender, EventArgs e)
        {

            if (!function.isNumber(discount_textbox.Text))
            {
                MessageBox.Show("Discount amount Should be as number");
            }


            else if (discount_textbox.Text.Equals("0") || discount_textbox.Text.Equals(""))
            {

                netamount_text.Text = Tamount_textbox.Text;

            }

            else
            {
                float tamount = float.Parse(Tamount_textbox.Text);
                float dis = float.Parse(discount_textbox.Text);


                netamount_text.Text = (tamount - ((tamount * (dis / 100)))).ToString();
                Blance.Text = (tamount - ((tamount * (dis / 100)))).ToString();
            }
        }

        private void amount_PAid_TextChanged(object sender, EventArgs e)
        {
            if (!function.isNumber(amount_PAid.Text))
            {
                MessageBox.Show("Amount Should be as number");
            }

            else if (amount_PAid.Text != "")
            {
                float ntAmount = float.Parse(netamount_text.Text);
                float amountPaid = float.Parse(amount_PAid.Text);
                Blance.Text = (ntAmount - amountPaid).ToString();
            }
        }

        private void reservedrooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void reservedrooms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void reservedrooms_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void reservedrooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (reservedrooms.Columns[e.ColumnIndex].Name == "Delete")
            {
                int Index = reservedrooms.CurrentCell.RowIndex;

                removetotal = reservedrooms.Rows[Index].Cells[8].Value.ToString();
                RoomIDList.Items.Add(reservedrooms.Rows[Index].Cells[1].Value.ToString());
                Tamount_textbox.Text = (float.Parse(Tamount_textbox.Text) - float.Parse(removetotal)).ToString();
                Blance.Text = Tamount_textbox.Text;
                reservedrooms.Rows.RemoveAt(Index);
                
            }

            else
            {   
                int rowindex = reservedrooms.CurrentCell.RowIndex;
                RoomIDl.Text= reservedrooms.Rows[rowindex].Cells[1].Value.ToString();
                RoomTypeComboBox.SelectedItem = reservedrooms.Rows[rowindex].Cells[3].Value.ToString();
                BedTypeCombo.SelectedItem = reservedrooms.Rows[rowindex].Cells[2].Value.ToString();
                NoOfAdults.SelectedItem = reservedrooms.Rows[rowindex].Cells[4].Value.ToString();
                roomcost.Text = reservedrooms.Rows[rowindex].Cells[6].Value.ToString();
                NumOFDays.Text = reservedrooms.Rows[rowindex].Cells[7].Value.ToString();
                roomtotal.Text = reservedrooms.Rows[rowindex].Cells[8].Value.ToString();
                NoOdChild.SelectedItem = reservedrooms.Rows[rowindex].Cells[5].Value.ToString();


                

                string chINs = reservedrooms.Rows[rowindex].Cells[9].Value.ToString();
                DateTime dt = Convert.ToDateTime(chINs);
                chkin.Text = dt.ToShortDateString();

                string chOuts = reservedrooms.Rows[rowindex].Cells[10].Value.ToString();
                DateTime dt1 = Convert.ToDateTime(chOuts);
                chkout.Text = dt1.ToShortDateString();

                RoomIDList.Visible = false;
                button2.Visible = false;
                RoomTypeComboBox.Enabled = false;
                BedTypeCombo.Enabled = false;
                RoomIDl.Visible = true;
                button5.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Index = reservedrooms.CurrentCell.RowIndex;
            removetotal = reservedrooms.Rows[Index].Cells[8].Value.ToString();
            if (NoOfAdults.Text == "" || NoOdChild.Text == "")
            {
                MessageBox.Show("Select no of members first");
            }
      
            else
            {
                SqlConnection con = ConnectionManager.GetConnection();
                con.Open();

                String sql = "Select maxGuest from Room where RoomID='" + RoomIDl.Text + "'";

                SqlDataAdapter sda1 = new SqlDataAdapter(sql, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];
                foreach (DataRow dr in dt1.Rows)
                {


                    int noOfadultsint = int.Parse(NoOfAdults.SelectedItem.ToString());
                    int dbmaxgues = int.Parse((dr["maxGuest"].ToString()));

                    con.Close();

                    if (dbmaxgues < noOfadultsint)
                    {
                        MessageBox.Show("Above Selected Room's Maximum Guests count is " + dbmaxgues + "  and You have select " + noOfadultsint + " Guests ,So Please check the Possible values");
                    }
                    else
                    {
                        string Roomid = RoomIDl.Text;
                        int adults = int.Parse(NoOfAdults.SelectedItem.ToString());
                        int child = int.Parse(NoOdChild.SelectedItem.ToString());
                        string btyp = BedTypeCombo.SelectedItem.ToString();
                        String rtyp = RoomTypeComboBox.SelectedItem.ToString();
                        string chikindate = chkin.Value.Date.ToString();
                        string chkoutdate = chkout.Value.Date.ToString();
                        int numofDays = int.Parse(NumOFDays.Text);
                        float costs = float.Parse(roomcost.Text);
                        float Total = float.Parse(roomtotal.Text);
                        chikindate = chkin.Value.Date.ToString();
                        chkoutdate = chkout.Value.Date.ToString();
                        string[] row = { RRID.Text, Roomid, btyp, rtyp, adults.ToString(), child.ToString(), costs.ToString(), numofDays.ToString(), Total.ToString(), chikindate, chkoutdate };
                        reservedrooms.Rows.Add(row);


                        float amountf = float.Parse(roomcost.Text);
                        float numOfDaysf = float.Parse(NumOFDays.Text);
                        roomtotal.Text = ((numOfDaysf * amountf).ToString());

                        

                       
                        reservedrooms.Rows.RemoveAt(Index);
                        
                        float tamount = float.Parse(Tamount_textbox.Text);
                        float removetot = float.Parse(removetotal);
                        float latesttotal = float.Parse(roomtotal.Text);

                        Tamount_textbox.Text = ((tamount- removetot)+ latesttotal).ToString();
                        MessageBox.Show(("tamount is "+ Tamount_textbox.Text+"remo "+ reservedrooms.Rows[Index].Cells[8].Value.ToString()+"latest "+roomtotal.Text));
                        Blance.Text = Tamount_textbox.Text;
                    }


                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RoomIDl.Visible = false;
            button5.Visible = false;

            RoomIDList.Visible = true;
            button2.Visible = true;
            RoomTypeComboBox.Enabled = true;
            BedTypeCombo.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Front f = new Front();
            f.Show();
            this.Hide();
        }
    }
}
