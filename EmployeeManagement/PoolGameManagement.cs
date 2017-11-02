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
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace EmployeeManagement
{
    public partial class PoolGameManagement : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();


        // Autoincrement
        public static String getNextID(String col, String table, String prefix, SqlConnection con)
        {

            int id = 0;
            String query = "select max (substring(" + col + ",3,len(" + col + "))) as id from " + table;
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["id"].ToString() == "")
                        id = 101;
                    else
                        id = int.Parse(dr["id"].ToString()) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return prefix + id;
        }


        
        public PoolGameManagement()
        {
            InitializeComponent();
        }

        void Clear()
        {
            //cusid.Clear();
            //poolid.Text="PoolID";
            hours.Clear();
            amount.Clear();
            comboBox1.Text = "";
            paymentid.Text="PaymentID";
            outstandpaid.Clear();
            outstandbalance.Clear();
            discount.Text="0";
            netamount.Text="0";
            amountpaid.Text="0";
            balance.Text="0";
            totalamount.Text="0";
            roomid.Text = "RoomID";
            cusname.Text = "Customer Name";
            cusphone.Text = "Customer Contact";
        }

        private void back_Click(object sender, EventArgs e)
        {
            BarMain form = new BarMain();
            form.Show();
            this.Hide();
        }

        private void add_Click(object sender, EventArgs e)
        { 
        }

       private void search_Click(object sender, EventArgs e)
       {
           
        }

        private void delete_Click(object sender, EventArgs e)
        {

            String PoolIDs = PoolID.Text;
            String PaymentID = paymentid.Text;

            if (MessageBox.Show("Do you want to DELETE this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();                 
                    SqlDataAdapter deleteDetails = new SqlDataAdapter("delete from Payment where PoolID = '"+PoolIDs+"' and PaymentID='" +PaymentID+ "'", con);
                    deleteDetails.SelectCommand.ExecuteNonQuery();

                    SqlDataAdapter DeleteDetails = new SqlDataAdapter("delete from PoolGame where PoolID = '" + PoolID + "'", con);
                    DeleteDetails.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("Delete Success!");
                    Clear();

                    String sql = "select c.PaymentID,b.PoolID,c.TotalAmount,c.Discount,c.NetAmount,c.AmountPaid,c.Balance,b.DayTime from PoolGame b, Payment c where b.PoolID = c.PoolID";
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd;
                    DataSet ds = new DataSet();
                    DataView dv;
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "PoolGame");
                        da.Dispose();
                        cmd.Dispose();
                        con.Close();
                        dv = ds.Tables[0].DefaultView;
                        dataGridView1.DataSource = dv;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

         
        }

        private void poolid_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PoolGameManagement_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label15.Text = DateTime.Now.ToLongTimeString();
            label10.Text = DateTime.Now.ToLongDateString();

            label12.Text = DateTime.Now.ToShortDateString().ToString();


            label2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            roomid.Visible = false;
            cusname.Visible = false;
            cusphone.Visible = false;
            rid.Visible = false;
            Search.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Enabled = false;
            groupBox1.Visible = false;


            String sql = "select c.PaymentID,b.PoolID,c.TotalAmount,c.Discount,c.NetAmount,c.AmountPaid,c.Balance,b.DayTime from PoolGame b, Payment c where b.PoolID = c.PoolID ";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            DataSet ds = new DataSet();
            DataView dv;
            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                da.SelectCommand = cmd;
                da.Fill(ds, "Gym");
                da.Dispose();
                cmd.Dispose();
                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }


            try
            {
                String str = " select * from room where status='Reserved' ";
                SqlDataAdapter sda1 = new SqlDataAdapter(str, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Customer");


                DataTable dt1 = ds1.Tables["Customer"];


                foreach (DataRow dr in dt1.Rows)
                {
                    rid.Items.Add(dr["RoomID"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            add.Enabled = true;
            back.Enabled = true;
            delete.Enabled = false;
            button2.Enabled = true;

        }

        private void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void clear_Click(object sender, EventArgs e)
        {
          
        }

        private void poolroomid_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void hours_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void search_Click_1(object sender, EventArgs e)
        {
            if (rid.Text == "")
            {
                MessageBox.Show("Please enter the RoomID then Show Customer Details!");
            }
            else
            {
                try
                {
                    String CustomerID = rid.Text;

                    con.Open();
                    String sql = ("Select a.RoomID,c.FirstName,c.Phone from Customer c,RoomReservation r,  ReservedRooms a where c.CustID='" + CustomerID + "' and r.CustID=c.CustID and r.ReservationID=a.ReservationID");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    cusname.Text = sdr["FirstName"].ToString();
                    cusphone.Text = sdr["Phone"].ToString();
                    roomid.Text = sdr["RoomID"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void hours_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
         
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void hours_TextChanged_1(object sender, EventArgs e)
        {
          

        }

        private void hours_MouseClick(object sender, MouseEventArgs e)
        {
            //Calculate Total Amount
            if (hours.Text == "")
            {
                MessageBox.Show("Please enter the Hours then Calculate Balance!");
            }
            else if (!function.isNumber(hours.Text))
            {
                MessageBox.Show("Hours should be integer value");
            }
            else
            {
                float hour = 250;  //per one hour
                float TotalAmount = 0;

                string Hour = hours.Text;
                float UseHour = float.Parse(Hour);

                TotalAmount = (hour * UseHour);
                amount.Text = TotalAmount.ToString();
                //totalamount.Text = amount.Text;
            }
        }

        private void outstandpaid_MouseClick(object sender, MouseEventArgs e)
        {
            if (outstandpaid.Text == "")
            {
                MessageBox.Show("Please enter the AmountOfPaid then Calculate Balance!");
            }
           else if (!function.isNumber(hours.Text))
            {
                MessageBox.Show("AmountOfPaid should be integer value");
            }
            else
            {
                String balance = totalamount.Text;
                float Balance = float.Parse(balance);

                String PaidOfAmount = outstandpaid.Text;
                float PaidAmount = float.Parse(PaidOfAmount);

                outstandbalance.Text = (PaidAmount - Balance).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            //customertype select
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the CustomerType!");
            }
            else
            {

                if (comboBox1.SelectedIndex == 0)

                {
                    label2.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    roomid.Visible = true;
                    cusname.Visible = true;
                    cusphone.Visible = true;
                    rid.Visible = true;
                    //search.Visible = true;
                    groupBox2.Visible = true;
                    amountpaid.Enabled = false;
                    balance.Enabled = true;               
                }
                else
                {
                    label2.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    roomid.Visible = false;
                    cusname.Visible = false;
                    cusphone.Visible = false;
                    rid.Visible = false;
                    //search.Visible = false;
                    groupBox2.Visible = false;
                    amountpaid.Enabled = true;
                    balance.Enabled = false;
                }
                groupBox1.Visible = true;
                groupBox3.Visible = true;

                PoolID.Text = getNextID("PoolID", "PoolGame", "PO", con);
                paymentid.Text = getNextID("PaymentID", "Payment", "PA", con);
            }
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {

            if (!function.isNumber(discount.Text))
            {
                MessageBox.Show("Discount should be number value");
            }
            else
            {
                String TAmount = amount.Text;
                float TotalAmount = float.Parse(TAmount);
                String discunt = discount.Text;
                float Discount = float.Parse(discunt);

                float DiscountAmount = (TotalAmount - (TotalAmount * (Discount / 100)));

                netamount.Text = totalamount.Text;

                if (comboBox1.SelectedIndex == 0)
                {
                    netamount.Text = DiscountAmount.ToString();
                    balance.Text = DiscountAmount.ToString();
                }
                else
                {
                    netamount.Text = DiscountAmount.ToString();
                    amountpaid.Text = DiscountAmount.ToString();
                }
            
            }
        }

        private void amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (amountpaid.Text == "" || amountpaid.Text == "0")
            {
                balance.Text = netamount.Text;
            }
            else if (!function.isNumber(amountpaid.Text))
            {
                MessageBox.Show("Amount should be number value");
            }
            else
            {
                balance.Text = (float.Parse(netamount.Text) - float.Parse(amountpaid.Text)).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void discount_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void add_Click_1(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any CustomerType then click Insert button");
            }
            else if (!function.isNumber(discount.Text))
            {
                MessageBox.Show("Discount should be number value ");
            }
            else if (!function.isNumber(amountpaid.Text))
            {
                MessageBox.Show("AmountPaid should be number value");
            }
            else if (balance.Text == "")
            {
                MessageBox.Show("You must Enter the Balance! ");
            }
            else if (!function.isNumber(balance.Text))
            {
                MessageBox.Show("Balance should be number value ");
            }
            else
            {

                String poolids = PoolID.Text;
                String RoomID = roomid.Text;
                String PaymentID = paymentid.Text;
                String Amount = amount.Text;
                float Amnt = float.Parse(Amount);
                String amounts = amountpaid.Text;
                float PaidAmunt = float.Parse(amounts);
                String Amounts = balance.Text;
                float BalanceAmnts = float.Parse(Amounts);
                String Dicnt = discount.Text;
                float Discount = float.Parse(Dicnt);
                String NetAmnt = netamount.Text;
                float NetAmount = float.Parse(NetAmnt);
                //dateTimePicker1.Value.Date.ToString()

                if (MessageBox.Show("Do you want to Insert this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        try
                        {

                            String query = " insert into PoolGame (PoolID,RoomID,DayTime,Hours,status) Values('" + poolids + "','" + RoomID + "','" + label12.Text + "','"+hours.Text+"','Un Paid')";
                            SqlDataAdapter AddpoolDetails = new SqlDataAdapter(query, con);
                            AddpoolDetails.SelectCommand.ExecuteNonQuery();

                            MessageBox.Show("Add Success!");
                            Clear();

                            String sql = "select  * from PoolGame ";
                            SqlDataAdapter da = new SqlDataAdapter();
                            SqlCommand cmd;
                            DataSet ds = new DataSet();
                            DataView dv;

                            try
                            {

                                cmd = new SqlCommand(sql, con);
                                da.SelectCommand = cmd;
                                da.Fill(ds, "Gym");
                                da.Dispose();
                                cmd.Dispose();

                                dv = ds.Tables[0].DefaultView;
                                dataGridView1.DataSource = dv;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {

                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {

                        }
                    }

                    else if (comboBox1.SelectedIndex == 1)
                    {
                        try
                        {
                            String query = " insert into PoolGame (PoolID, DayTime,Hours,status) Values('" + poolids + "','" + label12.Text + "','"+hours.Text+"','Un Paid')";
                            SqlDataAdapter AddpoolDetails = new SqlDataAdapter(query, con);
                            AddpoolDetails.SelectCommand.ExecuteNonQuery();


                            query = " insert into Payment(PaymentID,TotalAmount,AmountPaid,Balance,Discount,NetAmount,PoolID,date) Values('" + PaymentID + "'," + Amnt + "," + PaidAmunt + "," + BalanceAmnts + ",'" + Discount + "','" + NetAmount + "','" + poolids + "','" + label12.Text + "')";
                            SqlDataAdapter Addpooldetails = new SqlDataAdapter(query, con);
                            Addpooldetails.SelectCommand.ExecuteNonQuery();
                            Debug.WriteLine(query);

                            MessageBox.Show("Add Success!");
                            Clear();

                            String sql = "select c.PaymentID,b.PoolID,c.TotalAmount,c.Discount,c.NetAmount,c.AmountPaid,c.Balance,b.DayTime from PoolGame b, Payment c where b.PoolID = c.PoolID ";
                            SqlDataAdapter da = new SqlDataAdapter();
                            SqlCommand cmd;
                            DataSet ds = new DataSet();
                            DataView dv;

                            try
                            {

                                cmd = new SqlCommand(sql, con);
                                da.SelectCommand = cmd;
                                da.Fill(ds, "Gym");
                                da.Dispose();
                                cmd.Dispose();

                                dv = ds.Tables[0].DefaultView;
                                dataGridView1.DataSource = dv;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {

                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                           
                        }
                    }

                }
            }
            con.Close();
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            con.Open();
            String poolid = PoolID.Text;
            String PaymentID = paymentid.Text;

            if (MessageBox.Show("Do you want to DELETE this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    SqlDataAdapter deleteDetails = new SqlDataAdapter("delete from Payment where  PaymentID='" + PaymentID + "'", con);
                    deleteDetails.SelectCommand.ExecuteNonQuery();

                    SqlDataAdapter DeleteDetails = new SqlDataAdapter("delete from PoolGame where PoolID = '" + poolid + "'", con);
                    DeleteDetails.SelectCommand.ExecuteNonQuery();

                    MessageBox.Show("Delete Success!");
                    Clear();

                    String sql = "select c.PaymentID,b.PoolID,c.TotalAmount,c.Discount,c.NetAmount,c.AmountPaid,c.Balance,b.DayTime from PoolGame b, Payment c where b.PoolID = c.PoolID ";
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd;
                    DataSet ds = new DataSet();
                    DataView dv;
                    try
                    {

                        cmd = new SqlCommand(sql, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "Gym");
                        da.Dispose();
                        cmd.Dispose();
                        dv = ds.Tables[0].DefaultView;
                        dataGridView1.DataSource = dv;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_3(object sender, EventArgs e)
        {

            Clear();
            //customer type select
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the CustomerType!");
            }
            else
            {

                if (comboBox1.SelectedIndex == 0)
                {
                    label2.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    roomid.Visible = true;
                    cusname.Visible = true;
                    cusphone.Visible = true;
                    rid.Visible = true;
                    Search.Visible = true;
                    discount.Enabled = false;
                    groupBox1.Visible = true;
                    groupBox2.Enabled = true;
                    groupBox4.Enabled = true;
                    groupBox3.Visible = false;
                    status.SelectedIndex = 0;

                    String sql = "select * from PoolGame";
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd;
                    DataSet ds = new DataSet();
                    DataView dv;
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "PoolGame");
                        da.Dispose();
                        cmd.Dispose();
                        dv = ds.Tables[0].DefaultView;
                        dataGridView1.DataSource = dv;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    label2.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    roomid.Visible = false;
                    cusname.Visible = false;
                    cusphone.Visible = false;
                    rid.Visible = false;
                    Search.Visible = false;
                    discount.Enabled = true;
                    groupBox1.Visible = false;
                    groupBox4.Visible = true;
                    groupBox3.Visible = true;
                    groupBox2.Visible = true;
                    groupBox2.Enabled = true;
                    groupBox4.Enabled = true;
                    status.Enabled = true;
                    status.SelectedIndex = 1;

                    String sql = "select c.PaymentID,b.PoolID,c.TotalAmount,c.Discount,c.NetAmount,c.AmountPaid,c.Balance,b.DayTime from PoolGame b, Payment c where b.PoolID = c.PoolID ";
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd;
                    DataSet ds = new DataSet();
                    DataView dv;
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand(sql, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "PoolGame");
                        da.Dispose();
                        cmd.Dispose();
                        dv = ds.Tables[0].DefaultView;
                        dataGridView1.DataSource = dv;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }


                PoolID.Text = getNextID("PoolID", "PoolGame", "PO", con);
                paymentid.Text = getNextID("PaymentID", "Payment", "PA", con);

            }


        }

        private void Search_Click_2(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            amount.Enabled = false;
            netamount.Enabled = false;
            balance.Enabled = false;
            amountpaid.Enabled = false;
            status.Enabled = false;

            if (rid.Text == "")
            {
                MessageBox.Show("Please enter the CustomerID then Search Customer Details!");
            }
            else
            {
                try
                {
                    String RoomID = rid.Text;

                    con.Open();
                    String sql = ("Select a.RoomID,c.FirstName,c.Phone from Customer c,RoomReservation r,  ReservedRooms a where a.RoomID='" + RoomID + "' and r.CustID=c.CustID and r.ReservationID=a.ReservationID");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();
                    cusname.Text = sdr["FirstName"].ToString();
                    cusphone.Text = sdr["Phone"].ToString();
                    roomid.Text = sdr["RoomID"].ToString();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                groupBox4.Enabled = true;
                amount.Enabled = false;
                netamount.Enabled = false;
                balance.Enabled = false;
                amountpaid.Enabled = false;
                status.Enabled = false;

                if (rid.Text == "")
                {
                    MessageBox.Show("Please enter the CustomerID then Search Customer Details!");
                }
                else
                {
                    try
                    {
                        String RoomID = rid.Text;

                        con.Open();
                        String sql = ("Select a.RoomID,c.FirstName,c.Phone from Customer c,RoomReservation r,  ReservedRooms a where a.RoomID='" + RoomID + "' and r.CustID=c.CustID and r.ReservationID=a.ReservationID");
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        cusname.Text = sdr["FirstName"].ToString();
                        cusphone.Text = sdr["Phone"].ToString();
                        roomid.Text = sdr["RoomID"].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            }

        private void hours_TextChanged_2(object sender, EventArgs e)
        {
            if (hours.Text == "")
            {
                hours.Text = "1";
            }
            else if (!function.isNumber(hours.Text))
            {
                MessageBox.Show("Hours should be integer value");
            }
            else
            {
                float hour = 150;  //per one hour
                float TotalAmount = 0;
                String Hour = hours.Text;
                float UseHour = float.Parse(Hour);

                TotalAmount = (hour * UseHour);
                amount.Text = TotalAmount.ToString();
                netamount.Text = TotalAmount.ToString();
                balance.Text = TotalAmount.ToString();
                totalamount.Text = TotalAmount.ToString();
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void discount_TextChanged_1(object sender, EventArgs e)
        {
            if (hours.Text == "")
            {
                MessageBox.Show("Enter Hours");
            }
            else if (discount.Text == "" || discount.Text == "0")
            {
                netamount.Text = amount.Text;
                balance.Text = amount.Text;
            }
            else if (!function.isNumber(discount.Text))
            {
                MessageBox.Show("Discount should be number value");
            }
            else
            {
                String TAmount = amount.Text;
                float TotalAmount = float.Parse(TAmount);
                String discunt = discount.Text;
                float Discount = float.Parse(discunt);

                float DiscountAmount = (TotalAmount - (TotalAmount * (Discount / 100)));

                netamount.Text = totalamount.Text;

                if (comboBox1.SelectedIndex == 0)
                {
                    netamount.Text = DiscountAmount.ToString();
                    balance.Text = DiscountAmount.ToString();
                }
                else
                {
                    netamount.Text = DiscountAmount.ToString();
                    amountpaid.Text = DiscountAmount.ToString();
                }

            }
        }

        private void amountpaid_TextChanged_1(object sender, EventArgs e)
        {
            if (amountpaid.Text == "" || amountpaid.Text == "0")
            {
                balance.Text = netamount.Text;
            }
            else if (!function.isNumber(amountpaid.Text))
            {
                MessageBox.Show("Amount should be number value");
            }
            else
            {
                balance.Text = (float.Parse(netamount.Text) - float.Parse(amountpaid.Text)).ToString();
            }
        }

        private void outstandpaid_TextChanged(object sender, EventArgs e)
        {
            if (outstandpaid.Text == "")
            {
                outstandpaid.Text = "0";
            }
            else if (!function.isNumber(outstandpaid.Text))
            {
                MessageBox.Show("Amount should be Number value");
            }
            else
            {
                String balance = totalamount.Text;
                float Balance = float.Parse(balance);
                String PaidOfAmount = outstandpaid.Text;
                float PaidAmount = float.Parse(PaidOfAmount);

                outstandbalance.Text = (PaidAmount - Balance).ToString();
            }
        }

        private void cusid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void back_Click_1(object sender, EventArgs e)
        {
            BarMain form = new BarMain();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            add.Enabled = false;
            back.Enabled = true;
            delete.Enabled = true;
            button2.Enabled = true;
            groupBox1.Visible = false;
            groupBox4.Visible = true;



            if (comboBox1.SelectedIndex == 0)
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow1 = this.dataGridView1.Rows[index];
                PoolID.Text = selectedRow1.Cells["PoolID"].Value.ToString();
                rid.SelectedItem = selectedRow1.Cells["RoomID"].Value.ToString();
                label12.Text = selectedRow1.Cells["DayTime"].Value.ToString();
                hours.Text = selectedRow1.Cells["Hours"].Value.ToString();
                status.SelectedItem = selectedRow1.Cells["status"].Value.ToString();

            }
            else if (comboBox1.SelectedIndex == 1)
            {

                int index = e.RowIndex;
                DataGridViewRow selectedRow = this.dataGridView1.Rows[index];
                paymentid.Text = selectedRow.Cells["PaymentID"].Value.ToString();
                PoolID.Text = selectedRow.Cells["PoolID"].Value.ToString();
                amount.Text = selectedRow.Cells["TotalAmount"].Value.ToString();
                discount.Text = selectedRow.Cells["Discount"].Value.ToString();
                netamount.Text = selectedRow.Cells["NetAmount"].Value.ToString();
                amountpaid.Text = selectedRow.Cells["AmountPaid"].Value.ToString();
                balance.Text = selectedRow.Cells["Balance"].Value.ToString();
                //dateTimePicker1.Text = selectedRow.Cells["DayTime"].Value.ToString();
            }
        }
    }
}
