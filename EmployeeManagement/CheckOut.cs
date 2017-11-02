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
using System.Net.Mail;

namespace EmployeeManagement
{
    public partial class CheckOut : Form
    {
        SqlConnection Con = ConnectionManager.GetConnection();
        String ReserveID;
        String GymID;
        public CheckOut()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public String Payment;
        private void CheckOut_Load(object sender, EventArgs e)
        {
          Payment=  function.getNextID("PaymentID", "Payment", "PA", Con);
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
                    RoomNo.Items.Add(dr["RoomID"].ToString());
                  
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Gym_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float Lamount = float.Parse(Laundry.Text);
            float REamount = float.Parse(Res.Text);
            float Ramount = float.Parse(Room.Text);
            float Bamount = float.Parse(Beverage.Text);
            float Gamount = float.Parse(Gym.Text);
            float Pamount = float.Parse(Pool.Text);
            float Pvehicle = float.Parse(Vehicle.Text);
            TAmount.Text = (Gamount + Ramount + Lamount + REamount + Pamount+ Bamount+ Pvehicle).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void AmountPaid_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Room.Text != "")
            {
                String query = "insert into Payment (PaymentID,ReserveID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + ReserveID + "','" + Room.Text + "','" + Room.Text + "',0,0,0)";
                function.ExecuteQuery(query, Con);
                Debug.WriteLine(query);
                String query9 = " update Room set status = 'Available'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query9, Con);
                Debug.WriteLine(query9);

            }

            if (Gym.Text != "")
            {
                String query2 = "select * from Gym where RoomID='"+RoomNo.SelectedItem+"'";
                SqlDataAdapter da = new SqlDataAdapter(query2, Con);
                SqlCommand sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "Gym");
                DataTable dt = ds.Tables["Gym"];
                foreach (DataRow dr in dt.Rows)
                {
                    Payment = function.getNextID("PaymentID", "Payment", "PA", Con);
                    String UniHours = dr["Hours"].ToString();
                    float UHours = float.Parse(UniHours);
                    float amount = UHours * 150;
                    string GymID = dr["GymID"].ToString();
                    string amounts = amount.ToString();
                    String query = "insert into Payment (PaymentID,GymID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + GymID + "','" + amounts + "','" + amounts + "',0,0,0)";
                    function.ExecuteQuery(query, Con);
                    Debug.WriteLine(query);

                }
                String query3 = " update gym set status = 'Paid'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query3, Con);
                Debug.WriteLine(query3);
            }
            if (Laundry.Text != "")
            {
                String query = "select * from Laundry where RoomID='" + RoomNo.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommand sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "Laundry");
                DataTable dt = ds.Tables["Laundry"];
                foreach (DataRow dr in dt.Rows)
                {
                    Payment = function.getNextID("PaymentID", "Payment", "PA", Con);
                    String wgt = dr["Weight"].ToString();
                    float Weight = float.Parse(wgt);
                    String price = dr["UnitPrice"].ToString();
                    float Uprice = float.Parse(price);
                    float amount = Uprice * Weight;
                    string LaundryID = dr["LaundryID"].ToString();
                    string amounts = amount.ToString();
                    String query1= "insert into Payment (PaymentID,LaundryID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + LaundryID + "','" + amounts + "','" + amounts + "',0,0,0)";
                    function.ExecuteQuery(query1, Con);
                    Debug.WriteLine(query1);
                }
                String query2 = " update Laundry set Status = 'Paid'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query2, Con);
                Debug.WriteLine(query2);
            }
            if (Pool.Text!="")
            {
                String query = "select* from PoolGame where RoomID = '" + RoomNo.SelectedItem + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommand sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "PoolGame");
                DataTable dt = ds.Tables["PoolGame"];
                foreach (DataRow dr in dt.Rows)
                {
                    Payment = function.getNextID("PaymentID", "Payment", "PA", Con);
                    String UniHours = dr["Hours"].ToString();
                    float UHours = float.Parse(UniHours);
                    float amount = UHours * 250;
                    string PoolID = dr["PoolID"].ToString();
                    string amounts = amount.ToString();
                    String query1 = "insert into Payment (PaymentID,PoolID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + PoolID + "','" + amounts + "','" + amounts + "',0,0,0)";
                    function.ExecuteQuery(query1, Con);
                    Debug.WriteLine(query1);

                }
                String query3 = " update PoolGame set status = 'Paid'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query3, Con);
                Debug.WriteLine(query3);
            }
            if (Beverage.Text != "")
            {
                String query = "select * From BeverageOrders BO,AvailableBeverage AB,Orders OD where BO.BeverageID=AB.BeverageID and BO.size=AB.size and BO.OrderID=OD.OrderID and OD.RoomID='"+RoomNo.SelectedItem+"'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommand sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    Payment = function.getNextID("PaymentID", "Payment", "PA", Con);
                    String Quantity = dr["Quantity"].ToString();
                    float Quant = float.Parse(Quantity);
                    String Price = dr["price"].ToString();
                    float Bprice = float.Parse(Price);
                    float amount = Quant * Bprice;
                    string BevID = dr["BeverageOrderID"].ToString();
                    string amounts = amount.ToString();
                    String query1 = "insert into Payment (PaymentID,BeveOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + BevID + "','" + amounts + "','" + amounts + "',0,0,0)";
                    function.ExecuteQuery(query1, Con);
                    Debug.WriteLine(query1);
                }
                String query3 = " update Orders set staus = 'Paid'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query3, Con);
                Debug.WriteLine(query3);
            }
            if (Res.Text != "")
            {
                String query = " select*from FoodOrder FO,Orders OD,Food FD where FO.OrderID=OD.OrderID and FO.FoodID=FD.FoodID and OD.RoomID='"+RoomNo.SelectedItem+"'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommand sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    Payment = function.getNextID("PaymentID", "Payment", "PA", Con);
                    String Quantity = dr["Quantity"].ToString();
                    float Quant = float.Parse(Quantity);
                    String Price = dr["UnitPrice"].ToString();
                    float Bprice = float.Parse(Price);
                    float amount = Quant * Bprice;
                    string FoodID = dr["FoodOrderID"].ToString();
                    string amounts = amount.ToString();
                    String query1 = "insert into Payment (PaymentID,FoodOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + FoodID + "','" + amounts + "','" + amounts + "',0,0,0)";
                    function.ExecuteQuery(query1, Con);
                    Debug.WriteLine(query1);
                }
                String query3 = " update Orders set staus = 'Paid'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query3, Con);
                Debug.WriteLine(query3);
            }
            if (Vehicle.Text != "")
            {
                String query = "  select * from location LO,vehicle VE,vehicleReservation VR where LO.PlaceCode=VR.location and VR.vehicleNumber=VE.vehicleNumber and RoomID='"+RoomNo.SelectedItem+"'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommand sc;
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    Payment = function.getNextID("PaymentID", "Payment", "PA", Con);
                    String Vehicle = dr["km"].ToString();
                    float Vkm = float.Parse(Vehicle);
                    String Price = dr["amountPerkm"].ToString();
                    float Vprice = float.Parse(Price);
                    String Initial = dr["initialAmount"].ToString();
                    float InitialAmount = float.Parse(Initial);
                    float amount =(( Vkm-1 )* Vprice)+ InitialAmount;
                    string Hire = dr["HireID"].ToString();
                    string amounts = amount.ToString();
                    String query1 = "insert into Payment (PaymentID,HireID,TotalAmount,AmountPaid,Discount,NetAmount,Balance)values('" + Payment + "','" + Hire + "','" + amounts + "','" + amounts + "',0,0,0)";
                    function.ExecuteQuery(query1, Con);
                    Debug.WriteLine(query1);
                }
                String query3 = " update vehicleReservation set status = 'Paid'where RoomID = '" + RoomNo.SelectedItem + "'";
                function.ExecuteQuery(query3, Con);
                Debug.WriteLine(query3);
            }
           
            MessageBox.Show("Done");
            String Name = Namebox.Text;
            String Roomin = RoomNo.SelectedItem.ToString();
            string CMail = Mail.Text;
            string PhoneNo = Phone.Text;
            String CheckInDate = Checkin.Text;
            String CheckOutDate = Date.Text;
            String RoomAmount = Room.Text;
            String Food = Res.Text;
            String BevAmt = Beverage.Text;
            String LanAmt = Laundry.Text;
            String gmAmt = Gym.Text;
            String poolAmt = Pool.Text;
            String vechileAmt = Vehicle.Text;
            String TotalAmount = TAmount.Text;

            string data = @"     HOTEL JHONE MERRY 

                             FINAL RECEIPT OF CHECKOUT" + @" 

                 Refrence No             : " + ReserveID + @" 
                 Employee Name           : " + Name + @" 
                 Room No                 : " + Roomin + @" 
                 Mail Address            : " + CMail + @" 
                 Phone No                : " + PhoneNo + @" 
                 CheckIn Date            : " + CheckInDate + @" 
                 CheckOut Date           : " + CheckOutDate + @" 
             ----------------------------------------------------------" + @" 
             ----------------------------------------------------------" + @" 
                 ROOMAMOUNT              :" + RoomAmount + @"
                 RESTAURANTS             :" + Food + @" 
                 BEVERAGE                :" + BevAmt + @"
                 LAUNDRY                 :" + LanAmt + @"
                 GYM                     :" + gmAmt + @"
                 POOLGAME                :" + poolAmt + @"
                 VEHICLERENT             :" + vechileAmt + @"

           ----------------------------------------------------------" + @" 
                 TOTAL AMOUNT            :" + TotalAmount + @"
           
           ----------------------------------------------------------" + @" 

                   

          ----------------------------------------------------------" + @"  
                                                                  MANAGER.";


            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("alan94walker@gmail.com");
                mail.To.Add(CMail);
                mail.Subject = "Check Out Details";
                mail.Body = data.ToString();

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("alan94walker@gmail.com", "1250Chammakchallo");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            MessageBox.Show(data);
            function.ClearAllText(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Front Fr = new Front();
            Fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Con.Open();

            String query8 = "select* from ReservedRooms RM,RoomReservation RR,Customer CU where RM.ReservationID=RR.ReservationID and RR.CustID=CU.CustID and RM.RoomID='"+RoomNo.SelectedItem+"'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query8, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Namebox.Text = (dr["FirstName"]+" "+ dr["LastName" ]).ToString();
                    String Ent_date = (dr["CheckOut"].ToString());
                    DateTime dt = Convert.ToDateTime(Ent_date);
                    Checkin.Text = dt.ToShortDateString();
                    Mail.Text = (dr["Email"].ToString());
                    Phone.Text = (dr["Phone"].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            String query = "select * from ReservedRooms where RoomID='"+RoomNo.SelectedItem+"'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Room.Text = (dr["Total"].ToString());
                     ReserveID= (dr["ReservationID"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String query1 = "Select SUM(Weight*UnitPrice) as 'Balance' from Laundry where RoomID='" + RoomNo.SelectedItem + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query1, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Laundry.Text = (dr["Balance"].ToString());
                    if (Laundry.Text == "")
                    {
                        Laundry.Text = "0";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String query2 = "select SUM(BO.Quantity*AB.price) as 'Balance' From BeverageOrders BO,AvailableBeverage AB,Orders OD where BO.BeverageID=AB.BeverageID and BO.size=AB.size and BO.OrderID=OD.OrderID and OD.RoomID='" + RoomNo.SelectedItem + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query2, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Beverage.Text = (dr["Balance"].ToString());
                    if (Beverage.Text == "")
                    {
                        Beverage.Text = "0";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String query3 = "select Sum(Hours*150 ) as 'Balance' from Gym where RoomID='"+RoomNo.SelectedItem+"'group by RoomID";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query3, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Gym.Text = (dr["Balance"].ToString());
                    if (Gym.Text == "")
                    {
                        Gym.Text = "0";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String query4 = "select Sum(Hours*250 ) as 'Balance' from PoolGame where RoomID='" + RoomNo.SelectedItem + "' group by RoomID";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query4, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Pool.Text = (dr["Balance"].ToString());
                    if (Pool.Text == "")
                    {
                        Pool.Text = "0";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String query5 = "select SUM(((LO.km-1)*VE.amountPerkm)+VE.initialAmount ) as 'Total' from location LO,vehicle VE,vehicleReservation VR where LO.PlaceCode=VR.location and VR.vehicleNumber=VE.vehicleNumber and RoomID='" + RoomNo.SelectedItem + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query5, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Vehicle.Text = (dr["Total"].ToString());
                    if (Vehicle.Text == "")
                    {
                        Vehicle.Text = "0";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            String query6 = "Select checkOut from ReservedRooms where RoomID='" + RoomNo.SelectedItem + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query6, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    String Ent_date = (dr["CheckOut"].ToString());
                    DateTime dt = Convert.ToDateTime(Ent_date);
                    Date.Text = dt.ToShortDateString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            String query7 = "select SUM(FO.Quantity*FD.UnitPrice )  as 'Balance'from FoodOrder FO,Orders OD,Food FD where FO.OrderID=OD.OrderID and FO.FoodID=FD.FoodID and OD.RoomID='" + RoomNo.SelectedItem + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query7, Con);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1, "table");
                DataTable dt1 = ds1.Tables["table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    Res.Text = (dr["Balance"].ToString());
                    if (Res.Text == "")
                    {
                        Res.Text = "0";
                    }
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

        private void Mail_Click(object sender, EventArgs e)
        {

        }
    }
}
