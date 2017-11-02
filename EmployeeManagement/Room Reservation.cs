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

    public partial class RoomReservation : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        public int count = 0;
        string removetotal;

        public RoomReservation()
        {
            InitializeComponent();
            try
            {       //Which rooms are available RoomID to RoomIDCombobox
                    String sql = "Select * from Room where status='Available'  ";
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "Room");
                    DataTable dt = ds.Tables["Room"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        RoomIDList.Items.Add(dr["RoomID"]);
                    }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public void clear()
        {
            fname.Text=""; 
            surname.Text = "";
            telephone.Text = "";
            mail.Text = "";
            address.Text = "";
            PCode.Text = "";
            Nic_No.Text = "";
            Tamount_textbox.Text = "0";
            discount_textbox.Text = "0";
            amount_PAid.Text = "0";
            Blance.Text = "0";
            netamount_text.Text = "0";

            reservedrooms.Rows.Clear();
            reservedrooms.Refresh();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FormLoad
            comboBox1.SelectedIndex = 0;
            RoomIDl.Visible = false;
            /*RoomTypeComboBox.SelectedIndex =2;
           BedTypeCombo.SelectedIndex = 2;
           noOfRooms.SelectedIndex = 0;
           NoOdChild.SelectedIndex = 0;
           NoOfAdults.SelectedIndex = 0; */
             
            button8.Visible = false;
            DateTime datetime = DateTime.Now;
            this.timenow.Text = datetime.ToString();
            RoomIDList.Enabled = false;
            NumOFDays.Enabled = false;
            SqlConnection con = ConnectionManager.GetConnection();
            RRID.Text = function.getNextID("ReservationID", "RoomReservation", "RR", con);
            PID.Text = function.getNextID("PaymentID", "Payment", "PA", con);
            cu.Text = function.getNextID("CustID", "Customer", "CU", con);
            RoomTypeComboBox.SelectedIndex = 0;
            BedTypeCombo.SelectedIndex = 0;
            countrys.SelectedIndex = 0;
            String sql = " select * from Customer c , ReservedRooms rr , RoomReservation r where  r.ReservationID=rr.ReservationID and r.CustID=c.CustID";
            function.loadTable(sql, rrgrid);

            // Math.Round(decimal.Parse(Tamount_textbox.ToString()), 2).ToString();

            
        }
             


        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        { 
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = mail.ToString();
            if (reservedrooms.Rows.Count == 1)
            {
                MessageBox.Show("Please Reserve atleast one room");
            }

            //System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            else if (!function.isNumber(discount_textbox.Text))
            {
                MessageBox.Show("Discount amount Should be as number");
            }

            else if (!function.isNumber(amount_PAid.Text))
            {
                MessageBox.Show("Amount Should be as number");
            }
            else if (fname.Text == "")
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
                String CID = cu.Text;
                String FNAME = fname.Text;
                String LNAME = surname.Text;
                String NIC = Nic_No.Text;
                String MAIL = mail.Text;
                String ADDRESS = address.Text;
                String COUNTRY = countrys.Text;
                String CONTACT = telephone.Text;
                String PostalCode = PCode.Text;
                String Pid = PID.Text;
                String ReserveID = RRID.Text;
                String Total = Tamount_textbox.Text;
                String Paid = amount_PAid.Text;
                String Discount = discount_textbox.Text;
                String NetAmount = netamount_text.Text;
                String Balance = Blance.Text;
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


                try
                {




                    String query1 = "insert into Customer values ('" + CID + "','" + FNAME + "','" + LNAME + "','" + NIC + "','" + MAIL + "','" + CONTACT + "','" + ADDRESS + "','" + PostalCode + "','" + COUNTRY + "','Check In')";
                    function.ExecuteQuery(query1, con);
                    Debug.WriteLine(query1);
                    String query2 = "insert into RoomReservation(ReservationID,CustID,status ) values('" + reserveid + "','" + cusID + "' ,'Un Paid')";
                    function.ExecuteQuery(query2, con);
                    Debug.WriteLine(query2);
                    /*String query3 = "insert into Payment (PaymentID,ReserveID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date)values ('" + Pid + "','" + ReserveID + "','" + Total + "','" + Paid + "','" + Discount + "','" + NetAmount + "','" + Balance + "','" + datec + "')";
                    functions.ExecuteQuery(query3, con);

                    */
                    for (int i = 0; i < reservedrooms.Rows.Count - 1; i++)
                    {


                        string reserveids = reservedrooms.Rows[i].Cells[0].Value.ToString();
                        string roomids = reservedrooms.Rows[i].Cells[1].Value.ToString();
                        string NoOfAdultss = reservedrooms.Rows[i].Cells[4].Value.ToString();
                        string NoOfChilds = reservedrooms.Rows[i].Cells[5].Value.ToString();
                        string rTypes = reservedrooms.Rows[i].Cells[3].Value.ToString();
                        string bTypes = reservedrooms.Rows[i].Cells[2].Value.ToString();
                        string nosday = reservedrooms.Rows[i].Cells[7].Value.ToString();
                        string cost = reservedrooms.Rows[i].Cells[6].Value.ToString();
                        string tot = reservedrooms.Rows[i].Cells[8].Value.ToString();
                        string datein = reservedrooms.Rows[i].Cells[9].Value.ToString();
                        string dateout = reservedrooms.Rows[i].Cells[10].Value.ToString();

                        string query4 = "insert into ReservedRooms (ReservationID,RoomID,NoOfAdults,NoOfChild,rType,bType,RoomCost,NumOFDays,Total,CheckIN,CheckOut) values('" + reserveids + "','" + roomids + "'  ,'" + NoOfAdultss + "','" + NoOfChilds + "','" + rTypes + "','" + bTypes + "','" + cost + "','" + nosday + "','" + tot + "','" + datein + "','" + dateout + "')";
                        function.ExecuteQuery(query4, con);
                        Debug.WriteLine(query4);
                        String querys = "update Room set status='Reserved' where RoomID='" + roomids + "' ";
                        function.ExecuteQuery(querys, con);
                        Debug.WriteLine(querys);

                    }

                    MessageBox.Show("Reservation Successful! ");
                    string mailtext = @"YOUR RESERVATION

Reservation Number :" + ReserveID + @"
Customer Name :" + FNAME + @"
Check -in :" + chikindate + @"
Check -out :" + chkoutdate + @"
Number of Guests  :" + adults + @"
 
Dear " + FNAME + @",
It is our pleasure to confirm your reservation at Hotel JohnMarry where you will experience exceptional accommodations and outstanding service.
                                                                                                                                        - Manager";

                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("alan94walker@gmail.com");
                        mail.To.Add(MAIL);
                        mail.Subject = "Room Reservation Confirmation";
                        mail.Body = mailtext.ToString();

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("alan94walker@gmail.com", "1250Chammakchallo");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    clear();



                    DateTime datetime = DateTime.Now;
                    this.timenow.Text = datetime.ToString();
                    RoomIDList.Enabled = false;
                    NumOFDays.Enabled = false;

                    RRID.Text = function.getNextID("ReservationID", "RoomReservation", "RR", con);
                    PID.Text = function.getNextID("PaymentID", "Payment", "PA", con);
                    cu.Text = function.getNextID("CustID", "Customer", "CU", con);
                    RoomTypeComboBox.SelectedIndex = 0;
                    BedTypeCombo.SelectedIndex = 0;
                    countrys.SelectedIndex = 0;
                    String sql = " select * from Customer c , ReservedRooms rr , RoomReservation r where  r.ReservationID=rr.ReservationID and r.CustID=c.CustID";
                    function.loadTable(sql, rrgrid);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no" + ex.Message);

                }

                finally

                {

                }
            }






        }

        private void button4_Click(object sender, EventArgs e)
        {
            function.ClearAllText(this);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {


        }

        private void RoomIDList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RoomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BedTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
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



            else if (days == 0)
            {
                MessageBox.Show("Check in and Check out dates can't be same!");
            }

 
            NumOFDays.Text = days.ToString();

           /* if (discount_textbox.Text.Equals("0") || discount_textbox.Text.Equals(""))
            {

                netamount_text.Text = Tamount_textbox.Text;

            }
            else
            {
                float tamount = float.Parse(Tamount_textbox.Text);
                float dis = float.Parse(discount_textbox.Text);


                netamount_text.Text = (tamount - ((tamount * (dis / 100)))).ToString();
                Blance.Text = (tamount - ((tamount * (dis / 100)))).ToString();

                if (amount_PAid.Text != "")
                {
                    float ntAmount = float.Parse(netamount_text.Text);
                    float amountPaid = float.Parse(amount_PAid.Text);
                    Blance.Text = (ntAmount - amountPaid).ToString();
                }
            }*/
        }

        private void NumOFDays_TextChanged(object sender, EventArgs e)
        {
            float amountf = float.Parse(roomcost.Text);
            float numOfDaysf = float.Parse(NumOFDays.Text);
            roomtotal.Text = (numOfDaysf * amountf).ToString();
            /*
           
            Tamount_textbox.Text = ((numOfDaysf * amountf) + float.Parse(Tamount_textbox.Text)).ToString();
            netamount_text.Text = Tamount_textbox.Text;
            Blance.Text = Tamount_textbox.Text;*/
        }

        private void RoomTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            BedTypeCombo.Enabled = true;
            int SIndex = RoomTypeComboBox.SelectedIndex;
            if (SIndex == 1)
            {

                SqlConnection con = ConnectionManager.GetConnection();
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
                SqlConnection con = ConnectionManager.GetConnection();
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
        }

        private void BedTypeCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            {
                int RoomIndex = RoomTypeComboBox.SelectedIndex;
                int BedIndex = RoomTypeComboBox.SelectedIndex;
                if (RoomIndex == 1 && BedIndex == 1)
                {

                    SqlConnection con = ConnectionManager.GetConnection();
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

                    SqlConnection con = ConnectionManager.GetConnection();
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

                    SqlConnection con = ConnectionManager.GetConnection();
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

        private void noOfRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            String counts = RoomIDList.Items.Count.ToString();
            count = int.Parse(counts);
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

        private void button7_Click(object sender, EventArgs e)
        {
            RoomAvalblity rs = new RoomAvalblity();

            rs.Show();

            /*
            */
        }

        private void button8_Click(object sender, EventArgs e)
        {

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

        private void Tamount_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RoomIDList_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void amount_PAid_TextChanged(object sender, EventArgs e)
        {     if (!function.isNumber(amount_PAid.Text))
            {
                MessageBox.Show("Amount Should be as number");
            }

            else if(amount_PAid.Text != "")
            {
                float ntAmount = float.Parse(netamount_text.Text);
                float amountPaid = float.Parse(amount_PAid.Text);
                Blance.Text = (ntAmount - amountPaid).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void RoomIDList_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string RoomIDs = RoomIDList.SelectedItem.ToString();
            //ReservedRoomList.Items.Add(RoomIDList.SelectedItem);
            //RoomIDList.Items.Remove(RoomIDList.SelectedItem);


            SqlConnection con = ConnectionManager.GetConnection();
            String sql = "Select Cost from Room where RoomID='" + RoomIDs + "'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Room");


            DataTable dt = ds.Tables["Room"];

            //RoomIDList.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                roomtotal.Text = dr["Cost"].ToString();

            }


            float amountf = float.Parse(roomtotal.Text);
            float numOfDaysf = float.Parse(NumOFDays.Text);
            Tamount_textbox.Text = (numOfDaysf * amountf).ToString();
            netamount_text.Text = Tamount_textbox.Text;
            Blance.Text = Tamount_textbox.Text;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void rrgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Front f = new Front();
            f.Show();
            this.Hide();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void NoOfAdults_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = ConnectionManager.GetConnection();
            con.Open();

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
            con.Close();



        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void rrgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {/*
            int rowindex = RoomGrid.CurrentCell.RowIndex;
            room_id.SelectedItem = RoomGrid.Rows[rowindex].Cells[0].Value.ToString();
            Room_Type.SelectedItem = RoomGrid.Rows[rowindex].Cells[1].Value.ToString();
            Floor_Num.SelectedItem = RoomGrid.Rows[rowindex].Cells[2].Value.ToString();
            Bed_Type.SelectedItem = RoomGrid.Rows[rowindex].Cells[3].Value.ToString();
            Costs.Text = RoomGrid.Rows[rowindex].Cells[4].Value.ToString();
            maxperson.SelectedItem = RoomGrid.Rows[rowindex].Cells[5].Value.ToString();
            Statuscb.SelectedItem = RoomGrid.Rows[rowindex].Cells[6].Value.ToString();
            */
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

            if (NoOfAdults.Text == "" || NoOdChild.Text == "")
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
                con.Open();

                String sql = "Select maxGuest from Room where RoomID='" + RoomIDList.SelectedItem.ToString() + "'";

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
                        string Roomid = RoomIDList.SelectedItem.ToString();
                        int adults = int.Parse(NoOfAdults.SelectedItem.ToString());
                        int child= int.Parse(NoOdChild.SelectedItem.ToString());
                        string btyp = BedTypeCombo.SelectedItem.ToString();
                        String rtyp = RoomTypeComboBox.SelectedItem.ToString();
                        string chikindate = chkin.Value.Date.ToString();
                        string chkoutdate = chkout.Value.Date.ToString();
                        int numofDays = int.Parse(NumOFDays.Text);
                        float costs = float.Parse(roomcost.Text);
                        float Total = float.Parse(roomtotal.Text);
                        chikindate = chkin.Value.Date.ToString();
                         chkoutdate = chkout.Value.Date.ToString();
                        string[] row = { RRID.Text, Roomid,   btyp, rtyp, adults.ToString(), child.ToString(), costs.ToString(), numofDays.ToString(), Total.ToString(), chikindate , chkoutdate };
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

        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void noOfRooms_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.timenow.Text = datetime.ToString();

            RoomIDList.Enabled = false;



            NumOFDays.Enabled = false;
            SqlConnection con = ConnectionManager.GetConnection();
            RRID.Text = function.getNextID("ReservationID", "RoomReservation", "RR", con);
            PID.Text = function.getNextID("PaymentID", "Payment", "PA", con);
            cu.Text = function.getNextID("CustID", "Customer", "CU", con);
            RoomTypeComboBox.SelectedIndex = 0;
            BedTypeCombo.SelectedIndex = 0;
            countrys.SelectedIndex = 0;
            /*BedTypeCombo.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            noOfRooms.Enabled = false;
            RoomIDList.Enabled = false;
            NoOdChild.Enabled = false;
            NoOfAdults.Enabled = false;*/


            String sql = "select r.ReservationID,c.CustID,rr.RoomID , rr.bType, rr.rType, rr.CheckIN, rr.CheckOut , rr.NumOFDays, rr.RoomCost, rr.Total, rr. NoOfAdults , c.FirstName,c.LastName,c.Email,c.Phone,c.NIC_OR_Passport ,c.Address,c.Country  from RoomReservation r , Customer c , Payment p ,ReservedRooms rr where  r.CustID=c.CustID and r.ReservationID=p.ReserveID and rr.ReservationID=r.ReservationID";
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

        private void roomcost_TextChanged(object sender, EventArgs e)
        {
            float amountf = float.Parse(roomcost.Text);
            float numOfDaysf = float.Parse(NumOFDays.Text);
            roomtotal.Text = (numOfDaysf * amountf).ToString();
        }

        private void noOfRooms_SelectedValueChanged(object sender, EventArgs e)
        {
           
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

        private void reservedrooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = reservedrooms.CurrentCell.RowIndex;
             
            NoOfAdults.SelectedItem = reservedrooms.Rows[rowindex].Cells[4].Value.ToString();
            NoOdChild.SelectedItem = reservedrooms.Rows[rowindex].Cells[5].Value.ToString();
            
            roomcost.Text = reservedrooms.Rows[rowindex].Cells[6].Value.ToString();
            NumOFDays.Text = reservedrooms.Rows[rowindex].Cells[7].Value.ToString();
            roomtotal.Text = reservedrooms.Rows[rowindex].Cells[8].Value.ToString();
        }

        private void reservedrooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RoomIDList_SelectedIndexChanged_3(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reservedrooms.Rows.Clear();
            reservedrooms.Refresh();
        }

        private void NoOdChild_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void netamount_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void Blance_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
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

                        Tamount_textbox.Text = ((tamount - removetot) + latesttotal).ToString();
                        MessageBox.Show(("tamount is " + Tamount_textbox.Text + "remo " + reservedrooms.Rows[Index].Cells[8].Value.ToString() + "latest " + roomtotal.Text));
                        Blance.Text = Tamount_textbox.Text;
                    }


                }
            }
        }

        private void reservedrooms_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reservedrooms_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                RoomIDl.Text = reservedrooms.Rows[rowindex].Cells[1].Value.ToString();
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
                button8.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                function.send_SMS(fname.Text, telephone.Text);
                MessageBox.Show("SMS sent succesfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    
    }
}
