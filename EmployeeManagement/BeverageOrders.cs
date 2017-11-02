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

namespace EmployeeManagement
{
    public partial class BeverageOrders : Form
    {
        
        float amount = 0;
        string removetotal;
        string BeID = "BO";
        string BeveOrderID;
        SqlConnection con = ConnectionManager.GetConnection();
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-298AUNB\SQLEXPRESS;Initial Catalog=hotel1;Integrated Security=True");

        public ComboBox Restaurant_Customer { get; private set; }
        public static void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
           
        }
        //autoincrement
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
        void autoID()
        {
            string value = Convert.ToString(label20.Text);
            string[] sepID = value.Split('O');
            int i = Convert.ToInt32(sepID[1]);
            i++;
            label20.Text = BeID + i;
        }
        private void AutoInc()
        {
            label20.Text = getNextID("BeverageOrderID", "BeverageOrders", "BO", con);
                string auto = label20.Text;
            string[] id = auto.Split('O');
            int i = int.Parse(id[1]);
            i++;
            string BeveOrderID = "BO"+i.ToString();
            label20.Text = BeveOrderID.ToString();
            MessageBox.Show(BeveOrderID);

        }
        public BeverageOrders()
        {
            InitializeComponent();
        }

        void Clear()
        {
            customertype.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            orderid.Text="OrderID";
            paymentid.Text = "PaymentID";
            type.Text = "";
            name.Text = "";
            
            beveid.Text = "BeverageID";
            quantity.Text="0";
            tamount.Text="0";
            outstandamountpaid.Text = "0";
            outstandbalance.Text = "0";
            discount.Text = "0";
            netamount.Text = "0";
            amountpaid.Text = "0";
            balance.Text = "0";
            totalamount.Text = "0";
            roomid.Text = "CustomerID";
            cusname.Text = "Customer Name";
            cusphone.Text = "Customer Contact";
            AddedfoodDgridview.Rows.Clear();

        }

        private void search_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoID();
            //Add button
            if (customertype.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any CustomerType!");
            }
            else if (type.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any BeverageType!");
            }
            else if (name.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any BeverageName!");
            }
            else if (bevesize.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any Size!");
            }
            else if (quantity.Text == "")
            {
                MessageBox.Show("You must Enter the Quantity!");
            }
            else if (!function.isNumber(quantity.Text))
            {
                MessageBox.Show("Quantity should be Integer value");
            }
            else
            { 

            String Beveragetype = type.SelectedItem.ToString();
            String BeverageName = name.SelectedItem.ToString();
            String BeverageSize = bevesize.SelectedItem.ToString();

                String query = "select price from  AvailableBeverage   where  BeverageID =  '"+beveid.Text+"' and size='"+BeverageSize+"' ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Beverages");
                DataTable dt = ds.Tables["Beverages"];

                    foreach (DataRow dr in dt.Rows)
                    {                      
                        float amountf = float.Parse(tamount.Text);
                        String Quanty = quantity.Text;
                        float quat = float.Parse(Quanty);
                        String Unitprice = dr["price"].ToString();
                        float Uprice = float.Parse(Unitprice);
                        amount = Uprice * quat;

                        tamount.Text = (amount + amountf).ToString();
                   
                    // totalamount.Text = (amount + amountf).ToString();

                    String BeverageID = beveid.Text;
                         String BevOrderID = label20.Text;
                         String BeverageName1 = name.SelectedItem.ToString();
                         String quanty = quantity.Text; 
                         String size = bevesize.SelectedItem.ToString();


                    // String amounts = amount.ToString();


                    
                    bool flag = true;
                    if (AddedfoodDgridview.Rows.Count > 1)
                    {

                        for (int k = 0; k < AddedfoodDgridview.Rows.Count - 1; k++)
                        {
                            if (BeverageID == AddedfoodDgridview.Rows[k].Cells[0].Value.ToString() && size== AddedfoodDgridview.Rows[k].Cells[3].Value.ToString())
                            {
                                MessageBox.Show("you have already added" + BeverageID);
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            DataTable dt1 = AddedfoodDgridview.DataSource as DataTable;
                            //int j = dt1.Rows.Count;
                            String[] row1 = { BeverageID, BevOrderID, BeverageName1, size,quanty,unit.Text,amounts.Text };
                            AddedfoodDgridview.Rows.Add(row1);
                            AddedfoodDgridview.DataSource = dt1; 
                           

                        }
                        flag = true;

                    }
                    else
                    {
                        DataTable dt1 = AddedfoodDgridview.DataSource as DataTable;
                       //int j = dt1.Rows.Count;
                        String[] row1 = { BeverageID, BevOrderID, BeverageName1, size, quanty, unit.Text, amounts.Text };
                        AddedfoodDgridview.Rows.Add(row1);
                        AddedfoodDgridview.DataSource = dt1;
                         
                    }
                                      
                }        
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BeverageOrders_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            label15.Text = DateTime.Now.ToLongTimeString();
            label16.Text = DateTime.Now.ToLongDateString();

            //Loading comboBox Size
            String query = "select distinct size from AvailableBeverage ";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "AvailableBeverage");
            DataTable dt = ds.Tables["AvailableBeverage"];

            foreach (DataRow dr in dt.Rows)
            {
                bevesize.Items.Add(dr["size"].ToString());
            }
            con.Close();


            //Loading comboBox Beverage Type Name
            String query2 = "select distinct BeverageTypeName  from BeverageType ";
            con.Open();
            SqlDataAdapter sda2 = new SqlDataAdapter(query2, con);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2, "BeverageType");
            DataTable dt2 = ds2.Tables["BeverageType"];

            foreach (DataRow DR1 in dt2.Rows)
            {
                type.Items.Add(DR1["BeverageTypeName"].ToString());
            }
            con.Close();

             

            try
            {
                SqlConnection con = ConnectionManager.GetConnection();
                String str = " select * from room where status='Reserved' ";
                SqlDataAdapter sda1 = new SqlDataAdapter(str, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Customer");


                DataTable dt1 = ds1.Tables["Customer"];


                foreach (DataRow dr in dt1.Rows)
                {
                    comboBox1.Items.Add(dr["RoomID"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            button3.Enabled = true;
            button5.Enabled = true;
            
            update.Enabled = false;
            clear.Enabled = true;
            //delet.Enabled = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            BarMain form = new BarMain();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //insert button 
            if (customertype.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any CustomerType!");
            }
            else if (type.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any BeverageType!");
            }
            else if (name.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any BeverageName!");
            }
            else if (bevesize.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select any Size!");
            }
            else if (quantity.Text == "")
            {
                MessageBox.Show("You must Enter the Quantity!");
            }
            else if (!function.isNumber(quantity.Text))
            {
                MessageBox.Show("Quantity should be Integer value");
            }
            else if (discount.Text == "")
            {
                MessageBox.Show("You must Enter the Discount!");
            }
            else if (!function.isNumber(discount.Text))
            {
                MessageBox.Show("Discount should be number value ");
            }
            else if (amountpaid.Text == "")
            {
                MessageBox.Show("You must Enter the AmountOfPaid!");
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


                String CustomerType = customertype.SelectedItem.ToString();
                // String BeverageOrderID = Beveorderid.Text;
                String BeverageID = beveid.Text;
                String OrderID = orderid.Text;
                String RoomID = roomid.Text;
                String PaymentID = paymentid.Text;
                String BeverageType = type.SelectedItem.ToString();
                String BeverageName = name.SelectedItem.ToString();
                String Size = bevesize.SelectedItem.ToString();
                String Quantity = quantity.Text;
                float Qunty = float.Parse(Quantity);
                String TAmount = tamount.Text;
                float TotalAmount = float.Parse(TAmount);
                String AmtPaid = amountpaid.Text;
                float AmountPaid = float.Parse(AmtPaid);
                String Balan = balance.Text;
                float Balance = float.Parse(Balan);
                String Dicunt = discount.Text;
                float Discount = float.Parse(Dicunt);
                String NAmount = netamount.Text;
                float NetAmount = float.Parse(NAmount);
                // dateTimePicker1.Value.Date.ToString()

                if (MessageBox.Show("Do you want to Insert this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (customertype.SelectedIndex == 0)
                    {
                        con.Open();

                        String query = "insert into Orders(OrderID,orderedTime,RoomID,staus) values('" + OrderID + "','" + label15.Text + "','" + roomid.Text + "','" + status.SelectedItem + "')";
                        SqlDataAdapter AddBeveragedetails = new SqlDataAdapter(query, con);
                        AddBeveragedetails.SelectCommand.ExecuteNonQuery();
                        Debug.WriteLine(query);
                        foreach (DataGridViewRow dr in AddedfoodDgridview.Rows)
                        {
                            AddedfoodDgridview.AllowUserToAddRows = false;
                            String BeveID = dr.Cells[0].Value.ToString();
                              string BeveOrderId = dr.Cells[1].Value.ToString();
                            String BeveQuantity = dr.Cells[4].Value.ToString();
                            String size = dr.Cells[3].Value.ToString();
                            String query1 = "insert into BeverageOrders(BeverageOrderID,OrderID,Quantity,BeverageID,size) values('" + BeveOrderId + "','" + OrderID + "'," + BeveQuantity + ",'" + BeveID + "','" + Size + "')";
                            SqlDataAdapter addBeverageDetails = new SqlDataAdapter(query1, con);
                            addBeverageDetails.SelectCommand.ExecuteNonQuery();
                            Debug.WriteLine(query1);
                        }

                            MessageBox.Show("Added succesfully");
                        con.Close();
                        Clear();
                        
                        //dataGridView2.AllowUserToAddRows = false;
                        String sql = "Select a.RoomID,c.FirstName, bo.BeverageID,bo.BeverageOrderID,bo.OrderID,bo.Quantity,bo.size from Customer c,RoomReservation r,  ReservedRooms a, Room rm, Orders o , BeverageOrders bo where   r.CustID=c.CustID and r.ReservationID=a.ReservationID and a.RoomID=rm.RoomID and o.RoomID=a.RoomID and bo.OrderID=o.OrderID";
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
                    }

            else if (customertype.SelectedIndex == 1)
                    {
                        try
                        {
                            con.Open();

                            String query = "insert into Orders(OrderID,staus) values('" + OrderID + "', '" + status.SelectedItem + "')";
                            SqlDataAdapter AddBeveragedetails = new SqlDataAdapter(query, con);
                            AddBeveragedetails.SelectCommand.ExecuteNonQuery();
                            Debug.WriteLine(query);
                            //dataGridView2.AllowUserToAddRows = false;

                            foreach (DataGridViewRow dr in AddedfoodDgridview.Rows)
                            {
                                AddedfoodDgridview.AllowUserToAddRows = false;
                                String BeveID = dr.Cells[0].Value.ToString();
                                String BeveOrderId = dr.Cells[1].Value.ToString();
                                String BeveQuantity = dr.Cells[4].Value.ToString();
                                String size = dr.Cells[3].Value.ToString();
                                String query1 = "insert into BeverageOrders(BeverageOrderID,OrderID,Quantity,BeverageID,size) values('" + BeveOrderId + "','" + OrderID + "'," + BeveQuantity + ",'" + BeveID + "','" + size + "')";
                                SqlDataAdapter addBeverageDetails = new SqlDataAdapter(query1, con);
                                addBeverageDetails.SelectCommand.ExecuteNonQuery();
                                Debug.WriteLine(query1);
                            }
                            
                            String query2 = "insert into Payment(PaymentID,BeveOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date) values('" + PaymentID + "','" + orderid.Text + "', '" + tamount.Text + "','" + AmountPaid + "','" + Discount + "','" + NetAmount + "','" + Balance + "',getDate())";
                            SqlDataAdapter AddBeverageDetails = new SqlDataAdapter(query2, con);
                            AddBeverageDetails.SelectCommand.ExecuteNonQuery();
                             
                            Debug.WriteLine(query2);
                            MessageBox.Show("Added succesfully");
                            
                            Clear();
                            String sql1 = "select  DISTINCT  c.PaymentID,a.OrderID,c.TotalAmount,c.AmountPaid,c.Balance,b.OrderedTime  from BeverageOrders a,Orders b, Payment c where a.OrderID=b.OrderID and c.BeveOrderID=b.OrderID";
                            SqlDataAdapter da1 = new SqlDataAdapter();
                            SqlCommand cmd1;
                            DataSet ds1 = new DataSet();
                            DataView dv1;

                            try
                            {

                                cmd1 = new SqlCommand(sql1, con);
                                da1.SelectCommand = cmd1;
                                da1.Fill(ds1, "Gym");
                                da1.Dispose();
                                cmd1.Dispose();

                                dv1 = ds1.Tables[0].DefaultView;
                                dataGridView1.DataSource = dv1;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            con.Close();
                        }





                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }
                }

             }
       }

        private void Clear(BeverageOrders beverageOrders)
        {
            throw new NotImplementedException();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            /* String OrderID = orderid.Text;
             //String BeveOrderID = Beveorderid.Text;
             String PaymentID = paymentid.Text;

             if (MessageBox.Show("Do you want to DELETE this Datas?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 try
                 {
                     con.Open();

                     String query2 = "Delete from Payment where PaymentID = '" + PaymentID + "' and BeveOrderID='"+orderid.Text+"'";
                     SqlDataAdapter deleteBeverageOrderdetails = new SqlDataAdapter(query2, con);
                     deleteBeverageOrderdetails.SelectCommand.ExecuteNonQuery();

                     String query1 = "Delete from BeverageOrders where BeverageOrderID = '" + BeveOrderID + "' and OrderID='" + OrderID + "' ";
                     SqlDataAdapter deleteBeverageOrderDetails = new SqlDataAdapter(query1, con);
                     deleteBeverageOrderDetails.SelectCommand.ExecuteNonQuery();
                     Debug.WriteLine(query1);

                     String query = "Delete from Orders where OrderID = '" + OrderID + "'";
                     SqlDataAdapter DeleteBeverageOrderDetails = new SqlDataAdapter(query, con);
                     DeleteBeverageOrderDetails.SelectCommand.ExecuteNonQuery();

                     MessageBox.Show("Deleted the Data!");
                     this.Clear();


                     String sql = "select c.PaymentID,b.OrderID,b.RoomID,a.BeverageID,a.Quantity,c.TotalAmount,c.AmountPaid,c.Balance,b.OrderedTime  from BeverageOrders a,Orders b, Payment c where  b.OrderID = a.OrderID and a.BeverageOrderID=c.BeveOrderID";
                     SqlDataAdapter da = new SqlDataAdapter();
                     SqlCommand cmd;
                     DataSet ds3 = new DataSet();
                     DataView dv;
                     try
                     {

                         con.Open();
                         cmd = new SqlCommand(sql, con);
                         da.SelectCommand = cmd;
                         da.Fill(ds3, "BeverageOrder");
                         da.Dispose();
                         cmd.Dispose();
                         dv = ds3.Tables[0].DefaultView;
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
        }*/
        }

        private void update_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void orderid_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerid_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
           // button1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = this.dataGridView1.Rows[index];
            paymentid.Text = selectedRow.Cells["PaymentID"].Value.ToString();
             orderid.Text = selectedRow.Cells["OrderID"].Value.ToString();
            roomid.Text = selectedRow.Cells["RoomID"].Value.ToString();
            beveid.Text = selectedRow.Cells["BeverageID"].Value.ToString();
             quantity.Text = selectedRow.Cells["quantity"].Value.ToString();
            tamount.Text = selectedRow.Cells["TotalAmount"].Value.ToString();
            amountpaid.Text = selectedRow.Cells["AmountPaid"].Value.ToString();
            balance.Text = selectedRow.Cells["Balance"].Value.ToString();
            label15.Text = selectedRow.Cells["OrderedTime"].Value.ToString();

            groupBox1.Visible = true;
            groupBox4.Visible = true;
            button3.Enabled = false;
            button5.Enabled = true;
            
            update.Enabled = false;
            clear.Enabled = true;
            //delet.Enabled = false;
            groupBox4.Visible = true;
            groupBox1.Visible = true;
        }

        private void update_Click_1(object sender, EventArgs e)
        {
            

            }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void search_Click_1(object sender, EventArgs e)
        {
            //search customer details
           
        }

        private void customertype_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            if (type.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select any BeverageType!");
            }
            else
            {
              
                String BeverageType = type.SelectedItem.ToString();
                name.Items.Clear();
                String query = "select BeverageName from Beverage where BeverageType =(select BeverageTypeId from BeverageType where  BeverageTypeName = '" + BeverageType + "')";
              
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        name.Items.Add(dr["BeverageName"].ToString());

                    }
                    if (name.Items.Count==0)
                    {
                        MessageBox.Show("This Beverage type has no Beverages");
                        name.Text = "";
                    }
                    else
                        name.SelectedIndex = 0;
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

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (name.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select any BeverageName!");
            }
            else
            {

                String query = "Select a.size ,a.BeverageID from Beverage b, AvailableBeverage a where b.BeverageID=a.BeverageID and    b.BeverageName='" + name .SelectedItem.ToString()+ "'";

                try
                {
                    bevesize.Items.Clear();
                   SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "table");
                    DataTable dt = ds.Tables["table"];

                    foreach (DataRow dr in dt.Rows)
                    {
                        beveid.Text = dr["BeverageID"].ToString();
                        bevesize.Items.Add(dr["size"]).ToString();

                    }
                    if (bevesize.Items.Count == 0)
                    {
                        MessageBox.Show("This Beverage type has no Beverages");
                        name.Text = "";
                    }
                    else
                    bevesize.SelectedIndex=0;
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String BeverageSize = bevesize.SelectedItem.ToString();

            String query = "select price from  AvailableBeverage   where  BeverageID =  '" + beveid.Text + "' and size='" + BeverageSize + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommand cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Beverages");
            DataTable dt = ds.Tables["Beverages"];

            foreach (DataRow dr in dt.Rows)
            {
                unit.Text = dr["price"].ToString();
                
            }

        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox10_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            outstandbalance.Text = (float.Parse(totalamount.Text) - float.Parse(outstandamountpaid.Text)).ToString();
        }

        private void delet_Click(object sender, EventArgs e)
        {
           
         }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void update_Click_2(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void outstandamountpaid_MouseClick(object sender, MouseEventArgs e)
        {
            // calculate outgoing balance
            if (outstandamountpaid.Text == "")
            {
                MessageBox.Show("Please enter the AmountOfPaid then Calculate Balance!");
            }
            else if (!function.isNumber(outstandamountpaid.Text))
            {
                MessageBox.Show("Enter the  number value");
            }
            else
            {
                String balance = totalamount.Text;
                float Balance = float.Parse(balance);
                String PaidOfAmount = outstandamountpaid.Text;
                float PaidAmount = float.Parse(PaidOfAmount);

                outstandbalance.Text = (PaidAmount - Balance).ToString();
            }
        }

        private void Time(object sender, EventArgs e)
        {

        }

        private void discount_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void discount_Click(object sender, EventArgs e)
        {
            
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void amountpaid_TextChanged(object sender, EventArgs e)
        {

           
            }

        private void customertype_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (customertype.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the CustomerType!");
            }
            else
            {

                if (customertype.SelectedIndex == 0)
                {
                    label13.Visible = true;
                    label14.Visible = true;
                    roomid.Visible = true;
                    cusname.Visible = true;
                    cusphone.Visible = true;
                    label3.Visible = true;
                    label12.Visible = true;
                    comboBox1.Visible = true;
                    search.Visible = true;
                    groupBox2.Visible = true;
                    amountpaid.Enabled = false;
                    balance.Enabled = true;

                    String sql = "  Select a.RoomID,c.FirstName, bo.BeverageID,bo.BeverageOrderID,bo.OrderID,bo.Quantity,bo.size from Customer c,RoomReservation r,  ReservedRooms a, Room rm, Orders o , BeverageOrders bo where   r.CustID=c.CustID and r.ReservationID=a.ReservationID and a.RoomID=rm.RoomID and o.RoomID=a.RoomID and bo.OrderID=o.OrderID";
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
                    button3.Enabled = true;
                    button5.Enabled = true;

                    update.Enabled = false;
                    clear.Enabled = true;

                }
                else
                {
                    label13.Visible = false;
                    label14.Visible = false;
                    roomid.Visible = false;
                    cusname.Visible = false;
                    cusphone.Visible = false;
                    label3.Visible = false;
                    label12.Visible = false;
                    comboBox1.Visible = false;
                    search.Visible = false;
                    groupBox2.Visible = false;
                    amountpaid.Enabled = true;
                    balance.Enabled = false;


                    try
                    {
                        SqlConnection con = ConnectionManager.GetConnection();
                        String str = " select * from room where status='Reserved' ";
                        SqlDataAdapter sda1 = new SqlDataAdapter(str, con);
                        DataSet ds1 = new DataSet();
                        sda1.Fill(ds1, "Customer");


                        DataTable dt1 = ds1.Tables["Customer"];

                        comboBox1.Items.Clear();
                        foreach (DataRow dr in dt1.Rows)
                        {

                            comboBox1.Items.Add(dr["RoomID"]);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                    button3.Enabled = true;
                    button5.Enabled = true;

                    update.Enabled = false;
                    clear.Enabled = true;

                    String sql = "select  DISTINCT  c.PaymentID,a.OrderID,c.TotalAmount,c.AmountPaid,c.Balance,b.OrderedTime  from BeverageOrders a,Orders b, Payment c where a.OrderID=b.OrderID and c.BeveOrderID=b.OrderID"; 
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


                }


                orderid.Text = getNextID("OrderID", "Orders", "OR", con);
                label20.Text = getNextID("BeverageOrderID", "BeverageOrders", "BO", con);
                paymentid.Text = getNextID("PaymentID", "Payment", "PA", con);

                groupBox1.Visible = true;
                groupBox3.Visible = true;
                groupBox4.Visible = true;
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int Index = AddedfoodDgridview.CurrentCell.RowIndex;
            removetotal = AddedfoodDgridview.Rows[Index].Cells[6].Value.ToString();

            if (AddedfoodDgridview.Columns[e.ColumnIndex].Name == "Deletes")
            {    
                removetotal = AddedfoodDgridview.Rows[Index].Cells[6].Value.ToString();
                tamount.Text = (float.Parse(tamount.Text) - float.Parse(removetotal)).ToString();
                AddedfoodDgridview.Rows.RemoveAt(Index);

            }

             
            else
            { 
               
                DataGridViewRow selectedRow = this.AddedfoodDgridview.Rows[Index];
                beveid.Text = selectedRow.Cells[0].Value.ToString();
                BeveOrderID = selectedRow.Cells[1].Value.ToString();
                name.Text = selectedRow.Cells[2].Value.ToString();
                quantity.Text = selectedRow.Cells[4].Value.ToString();
                bevesize.Text = selectedRow.Cells[3].Value.ToString();
                unit.Text = selectedRow.Cells[5].Value.ToString();
                amounts.Text = selectedRow.Cells[6].Value.ToString();

                button3.Enabled = true;
                button5.Enabled = true;
                 
                update.Enabled = true;
                 
                clear.Enabled = true;
            } 
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            if (quantity.Text == "")
            {
                MessageBox.Show("You must Enter the Quantity!");
            }
            else if (bevesize.Text == "")
            {
                MessageBox.Show("Error");
            }
            else if (!function.isNumber(quantity.Text))
            {
                MessageBox.Show("Quantity should be Integer value");
            }

            else
            {
                
                String BeverageSize = bevesize.SelectedItem.ToString();

                String query = "select price from  AvailableBeverage   where  BeverageID =  '" + beveid.Text + "' and size='" + BeverageSize + "' ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                SqlCommand cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Beverages");
                DataTable dt = ds.Tables["Beverages"];

                foreach (DataRow dr in dt.Rows)
                {
                    float amountf = float.Parse(tamount.Text);
                    String Quanty = quantity.Text;
                    float quat = float.Parse(Quanty);
                    String Unitprice = dr["price"].ToString();
                    float Uprice = float.Parse(Unitprice);
                    amount = Uprice * quat;
                    amounts.Text = amount.ToString();
                     tamount.Text= amount.ToString();


                }
            }
        }

        private void netamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Click_3(object sender, EventArgs e)
        {
            int Index = AddedfoodDgridview.CurrentCell.RowIndex;
            String BeverageID = beveid.Text;
            String BevOrderID = BeveOrderID;
            String BeverageName1 = name.SelectedItem.ToString();
            String quanty = quantity.Text;
            String size = bevesize.SelectedItem.ToString();
            AddedfoodDgridview.Rows.RemoveAt(Index);
            //DataTable dt1 = AddedfoodDgridview.DataSource as DataTable;
            // int j = dt1.Rows.Count;
            String[] row1 = { BeverageID, BevOrderID, BeverageName1, size, quanty, unit.Text, amounts.Text };
            AddedfoodDgridview.Rows.Add(row1);
            //AddedfoodDgridview.DataSource = dt1;

            float tamounts = float.Parse(tamount.Text);
            float removetot = float.Parse(removetotal);
            float latesttotal = float.Parse(amounts.Text);

            tamount.Text = ((tamounts - removetot) + latesttotal).ToString();
          

        }

        private void delet_Click_1(object sender, EventArgs e)
        {
           
        }

        private void discount_TextChanged_1(object sender, EventArgs e)
        {

            if (discount.Text == "" || discount.Text == "0")
            {
                netamount.Text = tamount.Text;
            }
            else if (!function.isNumber(discount.Text))
            {
                MessageBox.Show("Discount should be number value");
            }
            else
            {
                String TAmount = tamount.Text;
                float TotalAmount = float.Parse(TAmount);
                String discunt = discount.Text;
                float Discount = float.Parse(discunt);

                float DiscountAmount = (TotalAmount - (TotalAmount * (Discount / 100)));

                if (customertype.SelectedIndex == 0)
                {
                    netamount.Text = DiscountAmount.ToString();
                    balance.Text = DiscountAmount.ToString();
               
                }
                else
                {
                    netamount.Text = DiscountAmount.ToString();
                    amountpaid.Text = DiscountAmount.ToString();
                   // netamount.Text = totalamount.Text;
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

        private void balance_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void unit_Click(object sender, EventArgs e)
        {
            
        }

        private void unit_TextChanged(object sender, EventArgs e)
        {
            if (unit.Text == "")
            {
                MessageBox.Show("Not Available in this Size");

            }
            else
                amounts.Text = (float.Parse(unit.Text) * float.Parse(quantity.Text)).ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        


            try
            {
                 
                String RoomID = comboBox1.SelectedItem.ToString();

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
            //add.Enabled = true;
            //back.Enabled = true;
            // delete.Enabled = false;
            //button2.Enabled = true;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            BeverageCrystal bv = new BeverageCrystal();
            bv.Show();
        }
    }
}
