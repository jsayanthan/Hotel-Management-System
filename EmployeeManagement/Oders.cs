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
using System.Diagnostics;
using System.Net.Mail;

namespace EmployeeManagement
{
    public partial class Oders : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        string orderid = "OR";
        string Forderid = "FD";
        string paymentID = "PA";

        public Oders()
        {
            InitializeComponent();
        }

        void fillcombo()
        {
            try
            {
                con.Open();/*1*/
                string qry = "SELECT distinct f.FoodTypeName FROM FoodTypes f inner join  Food a on f.FoodTypeID=a.FoodType inner join DailyFoods b on a.FoodID=b.FoodID where b.Time='"+FoodTime.Text+ "' OR  b.Time='" + FoodTime1.Text + "'";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                comFoodType.Items.Clear();

                while (dr.Read())
                {
                    comFoodType.Items.Add(dr.GetValue(0).ToString());
                }
                //ssageBox.Show(comFoodType.Items.Count.ToString());
                //fillcombo_FoodName();
               //f (comFoodType.Items.Count == 0)
               //
                   //essageBox.Show("No Food Available now");
               //
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("121"+ex.Message);
            }
            finally
            {
                con.Close();/*1*/
            }
        }
       /*  void fillcombo_FoodName()
         {
             try
             {
                 con.Open();
                 string qry = "SELECT distinct f.FoodName FROM Food f inner join DailyFoods b on f.FoodID=b.FoodID where b.Time='" + FoodTime.Text + "'";
                 SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                comFoodName.Items.Clear();

                 while (dr.Read())
                 {
                     comFoodName.Items.Add(dr.GetValue(0).ToString());
                 }
                 dr.Close();
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
        private void GenarateAutoOrderID()
        {

            string TableColumnName = "OrderID";
            string DefaultColvalue = "OR100";
            string dbTableName = "Orders";
            AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = _autogeneratecode.AutoGenerateCode(TableColumnName, DefaultColvalue, dbTableName);
            string[] sepID = _getID.Split('R');
            int i = Convert.ToInt32(sepID[1]);
            i++;
           
            if (Rest_Order.Checked)
            {
                OrID.Text = orderid + i;
            }
            if (OutsideOrder.Checked)
            {
                outORID.Text = orderid + i;
            }
        }
        private void GenarateAutoPaymentID()
        {

            string TableColumnName = "PaymentID";
            string DefaultColvalue = "PA100";
            string dbTableName = "Payment";
            AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = _autogeneratecode.AutoGenerateCode(TableColumnName, DefaultColvalue, dbTableName);
            string[] sepID = _getID.Split('A');
            int i = Convert.ToInt32(sepID[1]);
            i++;
            PaymentID.Text = paymentID + i;
        }

        private void GenarateAutoFoodOrderID()
        {

            string TableColumnName = "FoodOrderID";
            string DefaultColvalue = "FD100";
            string dbTableName = "FoodOrder";
            AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = _autogeneratecode.AutoGenerateCode(TableColumnName, DefaultColvalue, dbTableName);
            string[] sepID = _getID.Split('D');
            int i = Convert.ToInt32(sepID[1]);
            i++;
                FoodOrderID.Text = Forderid + i;
   
               
            


        }
        private void AutoFoodOrderID()
        {
        //      string TableColumnName = "FoodOrderID";
            string DefaultColvalue = "FD100";
            string dbTableName = Convert.ToString(FoodOrderID.Text);
            //AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = dbTableName;
            string[] sepID = _getID.Split('D');
            int i = Convert.ToInt32(sepID[1]);
            i++;
            FoodOrderID.Text = Forderid + i;


        }
       /* public void disp2_data()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("select s.FoodID,s.Date,f.FoodTypeName,e.FoodName,e.UnitPrice,s.Time,s.QuantityAvailable from DailyFoods s inner join Food e on s.FoodID=e.FoodID inner join FoodTypes f on f.FoodTypeID=e.FoodType", con);
                cm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        private void GenarateAutoIDoutorder()
        {

            string TableColumnName = "OrderID";
            string DefaultColvalue = "OR100";
            string dbTableName = "Orders";
            AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = _autogeneratecode.AutoGenerateCode(TableColumnName, DefaultColvalue, dbTableName);
            string[] sepID = _getID.Split('R');
            int i = Convert.ToInt32(sepID[1]);
            i++;
            outORID.Text = orderid + i;




        }
        void fillcombo_RoomID()
        {
            try
            {
                con.Open();/*2*/
                string qry = "SELECT distinct RoomID FROM Room where status= 'Reserved'";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();

                ComRoomID.Items.Clear();
                while (dr.Read())
                {
                    ComRoomID.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("213"+ex.Message);
            }
            finally
            {
                con.Close();/*2*/
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            FoodHome openForm = new FoodHome();
            openForm.Show();
            Visible = false;
        }
        DataTable table = new DataTable();
        private void Oders_Load(object sender, EventArgs e)
        {
            

            timer1.Start();
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();
            Outside_Order.Visible = false;
            email.Visible = false;
            Restaurant_Orders.Visible = false;
            //fillcombo_FoodName();
            //fillcombo();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            resetOrder();
            if (Rest_Order.Checked)
            {
                Restaurant_Orders.Visible = true;
                Outside_Order.Visible = false;
                fillcombo_RoomID();
                clearoderFood();
            }
            GenarateAutoFoodOrderID();
            GenarateAutoPaymentID();
            filcombotime1();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void HOME_Click(object sender, EventArgs e)
        {

        }

        private void comFoodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();/*3*/
                string qry = "select e.FoodID,e.UnitPrice,f.FoodTypeName from Food e inner join FoodTypes f on  e.FoodType = f.FoodTypeID   WHERE e.FoodName='" + comFoodName.Text + "'";
               
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                


                while (dr.Read())
                {
                    
                    FoodID.Text = (dr.GetValue(0).ToString());
                    Unit_Price.Text = (dr.GetValue(1).ToString());
                    comFoodType.Text = (dr.GetValue(2).ToString());
                   
                }

                dr.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("WEWR"+ex.Message);
            }
            finally
            {
                con.Close();/*3*/
            }
            ComRoomID.Enabled = true;
            CustName.Enabled = false;
            CustPhone.Enabled = false;
            odrDateTextBox.Enabled = false;
            odrTimeTextBox.Enabled = false;
            OrID.Enabled = false;
            comFoodType.Enabled = true;
            comFoodName.Enabled = true;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = true;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
        }

        private void comFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                
                con.Open(); /*4*/
                string qry = "SELECT distinct e.FoodName FROM DailyFoods d  inner join Food e on e.FoodID=d.FoodID inner join FoodTypes f on e.FoodType = f.FoodTypeID  where (f.FoodTypeName='" + comFoodType.Text + "' and d.time='" + FoodTime.Text+ "' and d.QuantityAvailable>0) OR (f.FoodTypeName='" + comFoodType.Text + "' and d.time='" + FoodTime1.Text + "' and  d.QuantityAvailable>0)";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                comFoodName.Items.Clear();
                
                while (dr.Read())
                {
                    comFoodName.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("SGRG"+ex.Message);
            }
            finally
            {
                con.Close();/*4*/
            }

            ComRoomID.Enabled = true;
            CustName.Enabled = false;
            CustPhone.Enabled = false;
            odrDateTextBox.Enabled = false;
            odrTimeTextBox.Enabled = false;
            OrID.Enabled = false;
            comFoodType.Enabled = true;
            comFoodName.Enabled = true;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = false;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void fillFoodTime()
        {
            TimeSpan start = new TimeSpan(07, 0, 0);
            TimeSpan end = new TimeSpan(11, 0, 0);
            TimeSpan OTstart = new TimeSpan(11, 0, 0);
            TimeSpan OTend = new TimeSpan(12, 0, 0);
            TimeSpan LunchStart = new TimeSpan(12, 0, 0);
            TimeSpan Lunchend = new TimeSpan(15, 0, 0);
            TimeSpan starteven = new TimeSpan(15, 0, 0);
            TimeSpan endeven = new TimeSpan(19, 0, 0);
            TimeSpan startdinner = new TimeSpan(19, 0, 0);
            TimeSpan enddinner = new TimeSpan(22, 0, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now >= start) && (now < end))
            {
                FoodTime.Items.Add("Breakfast");
                FoodTime.Items.Add("Others");

            }
            else if ((now >= OTstart) && (now < OTend))
            {
                FoodTime.Items.Add("Others");

            }
            else if ((now >= LunchStart) && (now < Lunchend))
            {
                FoodTime.Items.Add("Lunch");
                FoodTime.Items.Add("Others");

            }
            else if ((now >= starteven) && (now < endeven))
            {
                FoodTime.Items.Add("Others");

            }
            else if ((now >= startdinner) && (now < enddinner))
            {
                FoodTime.Items.Add("Dinner");
                FoodTime.Items.Add("Others");

            }
            else
            {
                MessageBox.Show("no Food available now");
                FoodTime.Items.Clear();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fillcombo_RoomID();
            Restaurant_Orders.Visible = true;
            Outside_Order.Visible = false;
            GenarateAutoFoodOrderID();
            resetOrder();


        }
        void filcombotime1()
        {
            
            TimeSpan start = new TimeSpan(07, 0, 0);
            TimeSpan end = new TimeSpan(11, 0, 0);
            TimeSpan OTstart = new TimeSpan(11, 0, 0);
            TimeSpan OTend = new TimeSpan(12, 0, 0);
            TimeSpan LunchStart = new TimeSpan(12, 0, 0);
            TimeSpan Lunchend = new TimeSpan(15, 0, 0);
            TimeSpan starteven = new TimeSpan(15, 0, 0);
            TimeSpan endeven = new TimeSpan(19, 0, 0);
            TimeSpan startdinner = new TimeSpan(19, 0, 0);
            TimeSpan enddinner = new TimeSpan(22, 0, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now >= start) && (now < end))
            {
                FoodTime1.Items.Add("Breakfast");
                FoodTime1.Items.Add("Others");

            }
            else if ((now >= OTstart) && (now < OTend))
            {
                FoodTime1.Items.Add("Others");

            }
            else if ((now >= LunchStart) && (now < Lunchend))
            {
                FoodTime1.Items.Add("Lunch");
                FoodTime1.Items.Add("Others");

            }
            else if ((now >= starteven) && (now < endeven))
            {
                FoodTime1.Items.Add("Others");

            }
            else if ((now >= startdinner) && (now < enddinner))
            {
                FoodTime1.Items.Add("Dinner");
                FoodTime1.Items.Add("Others");

            }
            else
            {
                MessageBox.Show("no Food available now");
                FoodTime1.Items.Clear();
            }
        }
        private void OutsideOrder_CheckedChanged(object sender, EventArgs e)
        {
            resetOrder();
            Outside_Order.Visible = true;
            Restaurant_Orders.Visible = false;
            DateTime idate = DateTime.Now;
            outORdate.Text = idate.ToString("dd/MM/yyyy");
            outORtime.Text = idate.ToString("hh:mm tt");
            GenarateAutoOrderID();
            paymentStatus.Visible = false;
            label22.Visible = false;
        }

        private void ComRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();/*5*/
                string qry = "select CONCAT( c.FirstName,' ', c.LastName) ,c.Phone, c.Email from Customer c inner join RoomReservation r on  c.CustID = r.CustID inner join ReservedRooms i on i.ReservationID=r.ReservationID inner join Room s on s.RoomID=i.RoomID WHERE s.RoomID='" + ComRoomID.Text + "'";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();

                FoodTime.Items.Clear();

                while (dr.Read())
                {
                    CustName.Text = (dr.GetValue(0).ToString());
                    // Unit_price.Text = (dr.GetValue(1).ToString());
                    CustPhone.Text = (dr.GetValue(1).ToString());
                    email.Text = (dr.GetValue(2).ToString());
                }

                dr.Close();
                DateTime idate = DateTime.Now;
                odrDateTextBox.Text = idate.ToString("dd/MM/yyyy");
                odrTimeTextBox.Text = idate.ToString("hh:mm tt");
                GenarateAutoOrderID();
                fillFoodTime();

            }
            catch (Exception ex)
            {
                MessageBox.Show("FTE"+ex.Message);
            }
            finally
            {
                con.Close();/*5*/
            }
            ComRoomID.Enabled = true;
            CustName.Enabled = false;
            CustPhone.Enabled = false;
            odrDateTextBox.Enabled = false;
            odrTimeTextBox.Enabled = false;
            OrID.Enabled = false;
            FoodTime.Enabled = true;
            comFoodType.Enabled = false;
            comFoodName.Enabled = false;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = false;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
           


        }
        void culsubTot()
        {
            try
            {
                int qty;
                float subtotal;
                float unitPrice;
                qty = Convert.ToInt32(QuantitytextBox.Text);

                unitPrice = float.Parse(Unit_Price.Text);
                subtotal = (qty * unitPrice);
                SubTotaltextBox.Text = System.Convert.ToString(subtotal);

                //SubTotaltextBox.Text = String.Format("{0:C}", Double.Parse(SubTotaltextBox.Text));
            }
            catch (Exception ex)
            {
               
            }
           
        }
        private void QuantitytextBox_MouseLeave(object sender, EventArgs e)
        {



        }

        private void oderdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine("Hiii");
            if (oderdataGridView.Columns[e.ColumnIndex].Name == "delete")
            {
                if (MessageBox.Show("Are U want Delete Data", "Update Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    addOrderBindingSource.RemoveCurrent();
                    culordesubTot();
                }
            }
          

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        void culordesubTot()
        {
            double sum = 0;
            for (int i = 0; i < oderdataGridView.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(oderdataGridView.Rows[i].Cells[6].Value);
            }
            Order_sub_Total.Text = System.Convert.ToString(sum);
        }
        private void txtAdd_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("Hiii");
            if (txtAdd.Text == "ADD")
            {
                if (comFoodType.Text == "-Select Food Type-")
                {
                    MessageBox.Show("Select The Food Type");

                }
                else if (comFoodName.Text == "-Select Food Name-")
                {
                    MessageBox.Show("Select The Food Name");
                }
                else if (QuantitytextBox.Text == "")
                {
                    MessageBox.Show("Enter the quantity");
                }
                else
                {
                    bool flag = true;
                    if (oderdataGridView.Rows.Count > 1)
                    {

                        for (int j = 0; j < oderdataGridView.Rows.Count - 1; j++)
                        {
                            if (FoodID.Text == oderdataGridView.Rows[j].Cells[1].Value.ToString())
                            {
                                MessageBox.Show("You have already add this Food" );
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            addOrderBindingSource.Add(new addOrder() { FoodID = FoodID.Text, Food_Type = comFoodType.Text, Food_Name = comFoodName.Text, Unit_Price = Unit_Price.Text, Quantity = QuantitytextBox.Text, Sub_Total = SubTotaltextBox.Text, FoodOrderID = FoodOrderID.Text, FoodTime = FoodTime.Text });
                            //oderdataGridView.Rows.Add(row);
                            //TAmount.Text = (amount + amountf).ToString();

                        }
                        flag = true;

                    }
                    else
                    {

                        addOrderBindingSource.Add(new addOrder() { FoodID = FoodID.Text, Food_Type = comFoodType.Text, Food_Name = comFoodName.Text, Unit_Price = Unit_Price.Text, Quantity = QuantitytextBox.Text, Sub_Total = SubTotaltextBox.Text, FoodOrderID = FoodOrderID.Text, FoodTime = FoodTime.Text });
                        //oderdataGridView.Rows.Add(row);
                        // TAmount.Text = (amount + amountf).ToString();
                    }
                    //addOrderBindingSource.Add(new addOrder() { FoodID = FoodID.Text, Food_Type = comFoodType.Text, Food_Name = comFoodName.Text, Unit_Price = Unit_Price.Text, Quantity = QuantitytextBox.Text, Sub_Total = SubTotaltextBox.Text, FoodOrderID = FoodOrderID.Text, FoodTime = FoodTime.Text });
                    GenarateAutoFoodOrderID();
                    AutoFoodOrderID();
                    culordesubTot();
                    clearoderFood();
                    ComRoomID.Enabled = true;
                    CustName.Enabled = false;
                    CustPhone.Enabled = false;
                    odrDateTextBox.Enabled = false;
                    odrTimeTextBox.Enabled = false;
                    OrID.Enabled = false;
                    comFoodType.Enabled = true;
                    comFoodName.Enabled = true;
                    Unit_Price.Enabled = false;
                    QuantitytextBox.Enabled = true;
                    SubTotaltextBox.Enabled = false;
                    Order_sub_Total.Enabled = false;
                    DiscountPercent.Enabled = true;
                    DiscountAmount.Enabled = false;
                    Total_Amount.Enabled = false;
                    Amount_paid.Enabled = true;
                    Balance.Enabled = false;



                }
            }
            else
            {
                
                    addOrderBindingSource.RemoveCurrent();
                    if (MessageBox.Show("Are U want Update Data", "Update Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        addOrderBindingSource.Add(new addOrder() { FoodID = FoodID.Text, Food_Type = comFoodType.Text, Food_Name = comFoodName.Text, Unit_Price = Unit_Price.Text, Quantity = QuantitytextBox.Text, Sub_Total = SubTotaltextBox.Text, FoodOrderID = FoodOrderID.Text, FoodTime = FoodTime.Text });


                        txtAdd.Text = "ADD";
                    AutoFoodOrderID();
                    culordesubTot();
                    clearoderFood();
                    ComRoomID.Enabled = true;
                    CustName.Enabled = false;
                    CustPhone.Enabled = false;
                    odrDateTextBox.Enabled = false;
                    odrTimeTextBox.Enabled = false;
                    OrID.Enabled = false;
                    comFoodType.Enabled = true;
                    comFoodName.Enabled = true;
                    Unit_Price.Enabled = false;
                    QuantitytextBox.Enabled = true;
                    SubTotaltextBox.Enabled = false;
                    Order_sub_Total.Enabled = false;
                    DiscountPercent.Enabled = true;
                    DiscountAmount.Enabled = false;
                    Total_Amount.Enabled = false;
                    Amount_paid.Enabled = true;
                    Balance.Enabled = false;
                }
            
           
        }
        void resetOrder()
        {
            ComRoomID.Enabled = true;
            CustName.Enabled = true;
            CustPhone.Enabled = true;
            odrDateTextBox.Enabled = false;
            odrTimeTextBox.Enabled = false;
            OrID.Enabled = false;
            FoodTime.Enabled = false;
            comFoodType.Enabled = false;
            comFoodName.Enabled = false;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = false;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
            
            ComRoomID.Text = "-Select FoodID-";
            CustName.Text = "";
            CustPhone.Text = "";
            odrDateTextBox.Text = "";
            odrTimeTextBox.Text = "";
            OrID.Text = "";
            comFoodType.Text = "-Select Food Type-";
            comFoodName.Text = "-Select Food Name-";
            FoodTime.Text = "-Select Time-";
            Unit_Price.Text = "";
            QuantitytextBox.Text = "";
            SubTotaltextBox.Text = "";
            Order_sub_Total.Text = "";
            DiscountPercent.Text = "";
            DiscountAmount.Text = "";
            Total_Amount.Text = "";
            Amount_paid.Text = "";
            Balance.Text = "";
            outORID.Text = "";
            outORtime.Text = "";
            outORdate.Text = "";
            outORdate.Text = "-Select Time-";
            outORdate.Enabled = false;
            outORtime.Enabled = false;
            FoodID.Visible = false;
            FoodOrderID.Visible = false;
            PaymentID.Visible = false;
            oderdataGridView.Rows.Clear();

        }
        
        
        
        private void disscount_Click(object sender, EventArgs e)
        {

        }

        private void DiscountPercent_MouseLeave(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {


        }

        private void outORID_MouseClick(object sender, MouseEventArgs e)
        {
            GenarateAutoIDoutorder();
             DateTime idate = DateTime.Now;
             outORdate.Text = idate.ToString("dd/MM/yyyy");
            outORtime.Text = idate.ToString("HH:mm:ss");
             
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        void clearoderFood()
        {
            comFoodType.Text = "-Select Food Type-";
            comFoodName.Text = "-Select Food Name-";
     
            Unit_Price.Text = "";
            QuantitytextBox.Text = "";
            SubTotaltextBox.Text = "";

        }
        private void QuantitytextBox_Click(object sender, EventArgs e)
        {

        }

        private void QuantitytextBox_Enter(object sender, EventArgs e)
        {

        }

        private void QuantitytextBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void QuantitytextBox_TextChanged(object sender, EventArgs e)
        {
            if (function.isNumber(QuantitytextBox.Text) || QuantitytextBox.Text == "")
            {

            }

            else

            {
                MessageBox.Show("Invalid Quantity format Re-Enter");
                QuantitytextBox.Clear();
            }
            if (Unit_Price.Text != "" && QuantitytextBox.Text != "")
            {
                int a = Convert.ToInt32(QuantitytextBox.Text);
                con.Open();
                string qry = "select QuantityAvailable from DailyFoods  WHERE FoodID='" + FoodID.Text + "'";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                dr.Read();
                int d = dr.GetInt32(0);

                con.Close();
                if (a > d)
                {

                    MessageBox.Show("Only  " + d + "  Quantity Available");
                    QuantitytextBox.Clear();
                }
                else
                {
                    culsubTot();
                }
            }
            /*  else
              {
                  SubTotaltextBox.Clear();
              }*/

            if ((DiscountPercent.Text == ""))
            {
                Total_Amount.Text = Order_sub_Total.Text;
                DiscountAmount.Text = "0";

            }
        }

        private void Unit_Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void DiscountPercent_TextChanged(object sender, EventArgs e)
        {

            try
            {
                {
                    if (function.isNumber(DiscountPercent.Text) || DiscountPercent.Text == "")
                    {

                    }

                    else

                    {
                        MessageBox.Show("Invalid Quantity format Re-Enter");
                        DiscountPercent.Clear();
                    }

                    if ((DiscountPercent.Text == ""))
                    {
                        Total_Amount.Text = Order_sub_Total.Text;
                        DiscountAmount.Text = "0";

                    }

                 

                   else if (Convert.ToDouble(DiscountPercent.Text) > 100 || Convert.ToDouble(DiscountPercent.Text) < 0)
                    {
                        MessageBox.Show("Re-Enter The Discount Percentage Betbeen 0 and 100 ");
                        DiscountPercent.Clear();

                    }

                    
                    else
                    {
                        double OrderSubTot;
                        double Discount;
                        double DisAmount;
                        double totalAmount;

                        OrderSubTot = float.Parse(Order_sub_Total.Text);
                        Discount = Convert.ToDouble(DiscountPercent.Text);
                        DisAmount = (OrderSubTot * (Discount / 100));
                        DiscountAmount.Text = System.Convert.ToString(DisAmount);
                        DisAmount = double.Parse(DiscountAmount.Text);
                        totalAmount = (OrderSubTot - DisAmount);
                        Total_Amount.Text = System.Convert.ToString(totalAmount);


                        //SubTotaltextBox.Text = String.Format("{0:C}", Double.Parse(SubTotaltextBox.Text));
                    }
                    

                } }
            catch (Exception ex)
            {

            }
        }

        private void Amount_paid_TextChanged(object sender, EventArgs e)
        {

            if (function.isNumber(Amount_paid.Text) || Amount_paid.Text == "")
            {

            }

            else

            {
                MessageBox.Show("Invalid Quantity format Re-Enter");
                Amount_paid.Clear();
            }
            if (Total_Amount.Text != "" && Amount_paid.Text != "")
            {
                float totalamount;
                float amountpaid;
                float balance;
                totalamount = float.Parse(Total_Amount.Text);
                amountpaid = float.Parse(Amount_paid.Text);
                balance = (totalamount - amountpaid);
                Balance.Text = System.Convert.ToString(balance);
            }
        }

        private void txtClear_Click(object sender, EventArgs e)
        {

            comFoodType.Text = "-Select Food Type-";
            comFoodName.Text = "-Select Food Name-";
            Unit_Price.Text = "";
            QuantitytextBox.Text = "";
            SubTotaltextBox.Text = "";
            comFoodType.Enabled = true;
            comFoodName.Enabled = false;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = false;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
        }

        private void oderdataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (oderdataGridView.CurrentRow.Index != -1)
            {
                FoodID.Text= oderdataGridView.CurrentRow.Cells[1].Value.ToString();
                comFoodType.Text = oderdataGridView.CurrentRow.Cells[2].Value.ToString();
                comFoodName.Text = oderdataGridView.CurrentRow.Cells[3].Value.ToString();
                Unit_Price.Text = oderdataGridView.CurrentRow.Cells[4].Value.ToString();
                QuantitytextBox.Text = oderdataGridView.CurrentRow.Cells[5].Value.ToString();
                SubTotaltextBox.Text = oderdataGridView.CurrentRow.Cells[6].Value.ToString();
                FoodOrderID.Text= oderdataGridView.CurrentRow.Cells[7].Value.ToString();
                txtAdd.Text = "UPDATE";
                // txtDelete.Enabled = true;
                //txtClear.Enabled = true;
                txtAdd.Enabled = true;
            }
            
        }

        private void Cancel_Orders_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage2);

            txtReceipt.AppendText("\t\t\t"+"              E-RECEIPT FOR FOOD ORDER ");
            txtReceipt.AppendText("\t\t\t" + "============================================================================= "+Environment.NewLine);
            txtReceipt.AppendText("  "+ Environment.NewLine );


            txtReceipt.AppendText("\t"+"Name:-" + "\t " + CustName.Text+"\t" +"Phone NO:-"+ CustPhone.Text+ "\t"+"Ref_NO:-"+ OrID .Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine+"\t"+"Order_Date:-" + "\t " + odrDateTextBox.Text + "\t" + "Order_Time:-" + odrTimeTextBox.Text + Environment.NewLine);

            txtReceipt.AppendText(Environment.NewLine + "\t" + "  Food Type  " + "\t" + "   Food Name    " +"\t\t" + "   Unite Price   " +"\t"+ "   Quantity  "+"\t"+"  Suub Total  " + Environment.NewLine);
           
            for (int i = 0; i < oderdataGridView.Rows.Count - 1; i++)
            {
                string FoodType = oderdataGridView.Rows[i].Cells[2].Value.ToString();
                string FoodName = oderdataGridView.Rows[i].Cells[3].Value.ToString();
                double  unitPrice= Double.Parse(oderdataGridView.Rows[i].Cells[4].Value.ToString());
                int quantity = int.Parse(oderdataGridView.Rows[i].Cells[5].Value.ToString());
                double subtotal = double.Parse(oderdataGridView.Rows[i].Cells[6].Value.ToString());
                txtReceipt.AppendText(Environment.NewLine +"\t"+ "  " + FoodType + "\t" + FoodName + "\t" + "  \t   " + unitPrice + "\t" + " \t " + quantity + "\t" + " \t" + subtotal + Environment.NewLine);


            }
            txtReceipt.AppendText(Environment.NewLine + "\t" + "Order Sub Total:-" + "\t " + Order_sub_Total.Text  + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t" + "Discount Amount:-" + "  " + DiscountAmount.Text + Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t" + "Net Amount:-" + "\t " + Total_Amount.Text+ Environment.NewLine);
            txtReceipt.AppendText(Environment.NewLine + "\t" + "Customer Email:-" + "\t " + email.Text + Environment.NewLine);
            //txtReceipt.AppendText("\t" + "===================================================================================== ");
            txtReceipt.AppendText("\t\t\t" + "              HAVE A NICE DAY WITH HOTEL JOHN MARY ");


            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("alan94walker@gmail.com");
                mail.To.Add(email.Text);
                mail.Subject = "Restaurent Order";
                mail.Body = txtReceipt.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("alan94walker@gmail.com", "1250Chammakchallo");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {

           // Debug.WriteLine("HIIIIIIIIIIIIIIII");



            try

            {
                
                con.Open();/*6*/
                if (Rest_Order.Checked)
                {

                    if (Order_sub_Total.Text == "")
                    {
                        MessageBox.Show("Fill All Details");
                    }

                    else
                    {

                        string sql = "insert into Orders values('" + OrID.Text + "','" + ComRoomID.Text + "','" + odrTimeTextBox.Text + "','" + paymentStatus.Text + "','" + odrDateTextBox.Text + "')";
                        Debug.WriteLine(sql);
                        SqlCommand cm1 = new SqlCommand(sql, con);
                        cm1.ExecuteNonQuery();




                        string qry;

                        for (int i = 0; i < oderdataGridView.Rows.Count - 1; i++)
                        {
                            string foodOrderID = oderdataGridView.Rows[i].Cells[7].Value.ToString();
                            string foodId = oderdataGridView.Rows[i].Cells[1].Value.ToString();
                            int quantity = int.Parse(oderdataGridView.Rows[i].Cells[5].Value.ToString());
                            string FoodTime = oderdataGridView.Rows[i].Cells[8].Value.ToString();
                           int newqty = function.getstockquantity(foodId)-quantity;
                            sql = "insert into FoodOrder(FoodOrderID,OrderId,FoodID,Quantity,FoodTime) values('" + foodOrderID + "','" + OrID.Text + "','" + foodId + "','" + quantity + "','" + FoodTime + "')";
                            Debug.WriteLine(sql);
                            SqlCommand cm = new SqlCommand(sql, con);

                            qry = "update DailyFoods set QuantityAvailable='" + newqty + "' where FoodID='" + foodId + "' AND Date='"+ odrDateTextBox.Text + "' AND Time='"+FoodTime+"' ";
                            SqlCommand cm5 = new SqlCommand(qry, con);
                            cm5.ExecuteNonQuery();
                           

                            cm.ExecuteNonQuery();


                        }

                        
                        

                        /*sql= "insert into Payment(PaymentID,FoodOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date) values('" + PaymentID.Text + "','" + OrID.Text + "'," + Order_sub_Total.Text + "," + Amount_paid.Text + "," + DiscountAmount.Text + "," + Total_Amount.Text + "," + Balance.Text + ",'" + odrDateTextBox.Text + "')";
                           Debug.WriteLine(sql);
                           SqlCommand cm4 = new SqlCommand(sql, con);
                           cm4.ExecuteNonQuery();*/
                        /* SqlCommand cm3 = new SqlCommand("update DailyFoods d set QuantityAvailable=QuantityAvailable-(select q.Quantity from FoodOrder q where q.FoodTime=d.Time) WHERE d.FoodID= q.FoodID", con);
                         cm3.ExecuteNonQuery();*/
                        MessageBox.Show("Successfully Added");

                        resetOrder();
                    }
                }

                else if (OutsideOrder.Checked)
                {

                   

                     if (Order_sub_Total.Text == "")
                    {
                        MessageBox.Show("Fill All Details");
                    }

                    

                    else
                    {
                        SqlCommand cm1 = new SqlCommand("insert into Orders(OrderID,orderedTime,staus,orderedDate) values('" + outORID.Text + "','" + outORtime.Text + "' ,'Paid','" + outORdate.Text + "')", con);

                        cm1.ExecuteNonQuery();




                        for (int i = 0; i < oderdataGridView.Rows.Count - 1; i++)
                        {
                            string foodOrderID = oderdataGridView.Rows[i].Cells[7].Value.ToString();
                            string foodId = oderdataGridView.Rows[i].Cells[1].Value.ToString();
                            string quantity = oderdataGridView.Rows[i].Cells[5].Value.ToString();
                            string FoodTime = oderdataGridView.Rows[i].Cells[8].Value.ToString();


                            SqlCommand cm = new SqlCommand("insert into FoodOrder values('" + foodOrderID + "','" + outORID.Text + "','" + foodId + "','" + quantity + "','" + FoodTime + "')", con);

                            cm.ExecuteNonQuery();


                        }


                        SqlCommand cm4 = new SqlCommand("insert into Payment(PaymentID,FoodOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date) values('" + PaymentID.Text + "','" + outORID.Text + "'," + Order_sub_Total.Text + "," + Total_Amount.Text + "," + DiscountAmount.Text + "," + Total_Amount.Text + ", 0 ,'" + outORdate.Text + "')", con);
                        cm4.ExecuteNonQuery();

                        MessageBox.Show("Successfully Added");
                        //SqlCommand cm3 = new SqlCommand("update DailyFoods d set QuantityAvailable=QuantityAvailable-(select Quantity q from FoodOrder) WHERE d.FoodID= q.FoodID", con);
                        //cm3.ExecuteNonQuery();
                        resetOrder();
                    }
                }
            }
             catch (Exception ex)
            {
                MessageBox.Show("jsdjasgjf"+ex.Message);
            }
            finally
            {
                con.Close();/*6*/
            }
        
        }

        private void Oders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void FoodTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcombo();
            //fillcombo_FoodName();
            ComRoomID.Enabled = true;
            CustName.Enabled = false;
            CustPhone.Enabled = false;
            odrDateTextBox.Enabled = false;
            odrTimeTextBox.Enabled = false;
            OrID.Enabled = false;
            FoodTime.Enabled = true;
            comFoodType.Enabled = true;
            comFoodName.Enabled = true;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = false;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
            comFoodType.Text = "-Select food Type-";
           //f (comFoodType.Items.Count == 1)
            //
               //essageBox.Show("No Food Available now");
            //

        }

        private void FoodTime1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcombo();
            //essageBox.Show(comFoodType.Items.Count.ToString());
            //fillcombo_FoodName();
           

               
        

            ComRoomID.Enabled = true;
            CustName.Enabled = false;
            CustPhone.Enabled = false;
            odrDateTextBox.Enabled = false;
            odrTimeTextBox.Enabled = false;
            OrID.Enabled = false;
            FoodTime.Enabled = true;
            comFoodType.Enabled = true;
            comFoodName.Enabled = true;
            Unit_Price.Enabled = false;
            QuantitytextBox.Enabled = false;
            SubTotaltextBox.Enabled = false;
            Order_sub_Total.Enabled = false;
            DiscountPercent.Enabled = false;
            DiscountAmount.Enabled = false;
            Total_Amount.Enabled = false;
            Amount_paid.Enabled = false;
            Balance.Enabled = false;
            comFoodType.Text = "-Select food Type-";
        }

        private void outORID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Restaurant_Orders_Enter(object sender, EventArgs e)
        {

        }
       
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

          
            
            try
            {
                con.Open();/*7*/
                string qry = " select * from Orders where OrderID in (select OrderID from FoodOrder) order by OrderID DESC ";
                SqlDataAdapter da = new SqlDataAdapter(qry,con);
                DataTable dt = new DataTable();
               
                da.Fill(dt);
                dataGridView2.DataSource = dt;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            finally
            {
                con.Close();/*7*/
            }



        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow.Cells[1].Value.ToString() != "")
                {
                    Debug.WriteLine((dataGridView2.CurrentRow.Cells[1].Value));
                    if (dataGridView2.CurrentRow.Index != -1)
                    {
                        Rest_Order.Checked = true;
                        OrID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                        // DateTime dt = DateTime.ParseExact(dataGridView1.CurrentRow.Cells[1].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //dateTimePicker1.Value = dt;
                        ComRoomID.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                        odrTimeTextBox.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                        paymentStatus.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                        odrDateTextBox.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                        // comboBox1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                        // Quantity.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                        //DELETE.Enabled = true;
                        //UPDATE.Enabled = true;
                        //ADD.Enabled = false;
                        //CLEAR.Enabled = true;
                       
                    }
                    //enablefalseitems();
                    
                }
                else
                {
                    Debug.WriteLine("hffgf");
                    OutsideOrder.Checked = true;
                    Outside_Order.Visible = true;
                    Restaurant_Orders.Visible = false;
                    OrID.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    // DateTime dt = DateTime.ParseExact(dataGridView1.CurrentRow.Cells[1].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //dateTimePicker1.Value = dt;
                    // ComRoomID.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    outORtime.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    paymentStatus.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                    outORdate.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                    // comboBox1.Text = dataGridView
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TOTAL_Click(object sender, EventArgs e)
        {
              
               
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage3);

            try
            {
                con.Open();/*7*/
                string qry = " select * from Orders where OrderID in (select OrderID from FoodOrder) order by OrderID DESC ";
                SqlDataAdapter da = new SqlDataAdapter(qry, con);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView2.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();/*7*/
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            resetOrder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Restaurentcrystal r = new Restaurentcrystal();
            r.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }


