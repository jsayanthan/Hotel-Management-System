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
    public partial class Submit : Form
    {
        SqlConnection Con = ConnectionManager.GetConnection();
        float totalAmount = 0;
        String qry = "  select CU.CustID ,CU.FirstName ,CU.LastName,CU.NIC_OR_Passport,CU.Email,CU.Phone,CU.Address,CU.PostalCode,CU.Country,EV.EventID,EV.EventType,EV.NumOfGuests,EH.DateOfEvent,EH.TimeOfEvent,EH.HallID ,EL.DecorationName as Light,EF.DecorationName as Flower ,ES.DecorationName as Seat from Customer CU,Events EV , Event_Halls EH ,Event_Lightning EL,Event_Flower EF,Event_Seat ES where CU.CustID=EV.custID and EV.EventID =EH.EventID and EV.EventID =EF.EventID and EV.EventID =EL.EventID and EV.EventID =ES.EventID";
        public Submit()
        {
            
            InitializeComponent();
        }
       
        
        private void View_Load(object sender, EventArgs e)
        {
            NetAmounts.Enabled = false;
            BalanceAmount.Enabled = false;
            Ftime.Enabled = false;
            DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");


            //call the auto increment function 
            customerid.Text = function.getNextID("CustID", "Customer", "CU", Con);
            PaymentID.Text = function.getNextID("PaymentID", "Payment", "PA", Con);
            RID.Text = function.getNextID("EventID", "Events", "EV", Con);
            function.loadTable(qry, dataGridView1);
  

            //load the Lightning comboBox values when the form is load 
            String query1 = "select decorationName from Decorations where decorationName like '%Lightning%'";
            try
            {
                Con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, Con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Decorations");
                DataTable dt1 = ds1.Tables["Decorations"];

                foreach (DataRow dr in dt1.Rows)
                {
                    LIGHT.Items.Add(dr["decorationName"].ToString());
                }
                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //load the FlowerDecoration comboBox values when the form is load 
            String query2 = "select decorationName from Decorations where decorationName like '%Flower%'";
            try
            {
                Con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query2, Con);
                DataSet ds2 = new DataSet();
                sda1.Fill(ds2, "Decorations");
                DataTable dt2 = ds2.Tables["Decorations"];

                foreach (DataRow dr in dt2.Rows)
                {
                    FLOWER.Items.Add(dr["decorationName"].ToString());
                }
                Con.Close();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //load the Seating comboBox values when the form is load 
            String query3 = "select decorationName from Decorations where decorationName like '%Seats%'";
            try
            {
                Con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query3, Con);
                DataSet ds3 = new DataSet();
                sda1.Fill(ds3, "Decorations");
                DataTable dt3 = ds3.Tables["Decorations"];

                foreach (DataRow dr in dt3.Rows)
                {
                    SEAT.Items.Add(dr["decorationName"].ToString());
                }
                Con.Close();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

         
            //load the food time values to comboBox when the is loading
            String query = "select distinct FoodAvailabletime from FoodTimes";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "table");
            DataTable dt = ds.Tables["table"];
            foreach (DataRow dr in dt.Rows)
            {
                Ftime.Items.Add(dr["FoodAvailabletime"].ToString());
            }
            Con.Close();

            //load the BeverageTypeName values to comboBox when the form is loading
            String que = "select distinct BeverageTypename from BeverageType";
            Con.Open();
            SqlDataAdapter BEV = new SqlDataAdapter(que, Con);
            DataSet DS = new DataSet();
            BEV.Fill(DS, "table");
            DataTable DT = DS.Tables["table"];
            foreach (DataRow DR in DT.Rows)
            {
                Dtype.Items.Add(DR["BeverageTypename"].ToString());
            }
            Con.Close();

        }
        void Clear()
        {
            FirstName.Clear();
            lname.Clear();
            nic.Clear();
            mail.Clear();
            address.Clear();
            country.Clear();
            telephone.Clear();
            PCode.Clear();
        }
      
        public void SearchData(String valueToFind)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // validations for Events 
            if (GUEST.Text == "")
            {
                MessageBox.Show("Guest cannot be null value.Please enter the correct value");
            }
            else if(!function.isNumber(GUEST.Text))
            {
                MessageBox.Show("Guest value must be a Digit.Please enter the correct value");
            }
            else if (!function.isText(FirstName.Text))
            {
                MessageBox.Show("First Name must be a character..Please enter the correct value");
            }
            else if (!function.isText(lname.Text))
            {
                MessageBox.Show("Last Name must be a character.Please enter the correct value");
            }
            else if (!function.IsValid(mail.Text))
            {
                MessageBox.Show("Incorrect mail ID.Please enter the correct mailID");
            }
            else if (function.numCount(telephone.Text, 10))
            {
                MessageBox.Show(" Phone number should be in 10 digits. ");
            }
            else if (!function.isText(country.Text))
            {
                MessageBox.Show(" Country Name must be a character");
            }
            else if (!function.isNumber(DiscountAmount.Text))
            {
                MessageBox.Show("Discount should be integer");
            }
            else if (ReceivedAmount.Text == "")
            {
                MessageBox.Show("Received amount cannot be null");
            }
            else if (!function.isNumber(ReceivedAmount.Text))
            {
                MessageBox.Show("Received amount should be in integer");
            }


            else
            {

                String CID = customerid.Text;
                String FNAME = FirstName.Text;
                String LNAME = lname.Text;
                String NIC = nic.Text;
                String MAIL = mail.Text;
                String ADDRESS = address.Text;
                String COUNTRY = country.Text;
                String CONTACT = telephone.Text;
                String PostalCode = PCode.Text;
                String ResID = RID.Text;
                String Guest = GUEST.Text;
                int NoGuest = int.Parse(Guest);
                String Hall = HID.SelectedItem.ToString();
                String Type = TYPE.SelectedItem.ToString();
                String Time = TIME.SelectedItem.ToString();
                String EventLight = LIGHT.SelectedItem.ToString();
                String EventFlower = FLOWER.SelectedItem.ToString();
                String EventSeat = SEAT.SelectedItem.ToString();
                String Pid = PaymentID.Text;
                String Total = TAmount.Text;
                String Paid = ReceivedAmount.Text;
                String Discount = DiscountAmount.Text;
                String NetAmount = NetAmounts.Text;
                String Balance = BalanceAmount.Text;

                try
                {

                    
                    String query = "insert into Customer(CustID,FirstName,LastName,NIC_OR_Passport,Email,Phone,Address,PostalCode,Country) values ('" + CID + "','" + FNAME + "','" + LNAME + "','" + NIC + "','" + MAIL + "','" + CONTACT + "','" + ADDRESS + "','" + PostalCode + "','" + COUNTRY + "')";
                    function.ExecuteQuery(query,Con);

                    String query1 = "insert into Events values ('" + ResID + "','" + CID + "','" + Type + "','" + NoGuest + "','" + this.DATE.Text + "','" + Time + "')";
                    function.ExecuteQuery(query1, Con);

                    String query2= "insert into Event_Halls values ('" + ResID + "','" + Hall + "','" + this.DATE.Text + "','" + Time + "')";
                    function.ExecuteQuery(query2, Con);

                    String query3= " insert into Event_Lightning values ('" + ResID + "','" + EventLight + "')";
                    function.ExecuteQuery(query3, Con);

                    String query4 = " insert into Event_Flower values ('" + ResID + "','" + EventFlower + "')";
                    function.ExecuteQuery(query4, Con);

                    String query5 = " insert into Event_Seat values ('" + ResID + "','" + EventSeat + "')";
                    function.ExecuteQuery(query5, Con);

                    for (int i = 0; i < (AddedFoodItem.Rows.Count - 1); i++)
                    {

                        int qty = int.Parse(AddedFoodItem.Rows[i].Cells[2].Value.ToString());
                        string fid = AddedFoodItem.Rows[i].Cells[0].Value.ToString();


                        String query6 = "INSERT INTO Event_Food VALUES ('" + ResID + "','" + fid + "', " + qty + ") ";
                        function.ExecuteQuery(query6, Con);
                    }

                    for (int i = 0; i < (Added_Drinks.Rows.Count - 1); i++)
                    {
                        int qty = int.Parse(Added_Drinks.Rows[i].Cells[2].Value.ToString());
                        String fid = Added_Drinks.Rows[i].Cells[0].Value.ToString();
                        String Size = Added_Drinks.Rows[i].Cells[4].Value.ToString();


                        String query7 = "INSERT INTO Event_Beverage VALUES ('" + ResID + "','" + fid + "', " + qty + ",'" + Size + "') ";
                        function.ExecuteQuery(query7, Con);
                    }
                    String query8 = " insert into Payment(PaymentID,EventID,TotalAmount,AmountPaid,Discount,NetAmount,Balance) values ('" + Pid + "','" + ResID + "','" + Total + "','" + Paid + "','" + Discount + "','" + NetAmount + "','" + Balance + "')";
                    function.ExecuteQuery(query8, Con);
                    MessageBox.Show(" Details Are Added Successfully");
                    function.ClearAllText(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Go to the next form
            this.Hide();
            Home h1 = new Home();
            h1.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void GUEST_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddedFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if you select the cell of the data gridview then that values automaticaly go to that specific text box 
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];
            customerid.Text = SelectedRow.Cells[0].Value.ToString();
            FirstName.Text = SelectedRow.Cells[1].Value.ToString();
            lname.Text = SelectedRow.Cells[2].Value.ToString();
            nic.Text = SelectedRow.Cells[3].Value.ToString();
            mail.Text = SelectedRow.Cells[4].Value.ToString();
            telephone.Text = SelectedRow.Cells[5].Value.ToString();
            address.Text = SelectedRow.Cells[6].Value.ToString();
            country.Text = SelectedRow.Cells[7].Value.ToString();
            PCode.Text = SelectedRow.Cells[8].Value.ToString();
            
        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Ftime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select the foot type and get the food types according to the food time
            String FoodTime = Ftime.SelectedItem.ToString();
            Ftype.Items.Clear();
            Fname.Items.Clear();

            String query = "select f.FoodTypeName from FoodTypes f, FoodTimes ft where f.FoodTypeID= ft.FoodTypeID and ft.FoodAvailableTime='" + FoodTime + "'";
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "FoodTypes");
                DataTable dt = ds.Tables["FoodTypes"];

                foreach (DataRow dr in dt.Rows)
                {
                    Ftype.Items.Add(dr["FoodTypeName"].ToString());
                }
           
                Con.Close();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ftype_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the value of food names
            String FoodTime = Ftime.SelectedItem.ToString();
            String FoodType = Ftype.SelectedItem.ToString();
            Fname.Items.Clear();
            String query = "select * from Food where Foodtype =(select FoodTypeId from FoodTypes where  FoodTypeName = '" + FoodType + "')";

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "table");
            DataTable dt = ds.Tables["table"];


            foreach (DataRow dr in dt.Rows)
            {
                Fname.Items.Add(dr["FoodName"].ToString());
            }
           Fname.SelectedIndex = 0;
            Con.Close();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Ftime.SelectedItem == null)
            {
                MessageBox.Show("FoodTime cannot be null value");
            }
            else if (Ftype.SelectedItem == null)
            {
                MessageBox.Show("food type is incorrect.Please select the correct type");
            }
            else if (Fname.SelectedItem == null)
            {
                MessageBox.Show("FoodName is incorrect.select the correct foodname");
            }
            else if (Quantity.Text == "")
            {
                MessageBox.Show("Quantity is null.Please enter the quantity");
            }
            else if (!function.isNumber(Quantity.Text))
            {
                MessageBox.Show("should be digit");
            }
            else
            {
                String FoodTime = Ftime.SelectedItem.ToString();
                String FoodType = Ftype.SelectedItem.ToString();
                String FoodName = Fname.SelectedItem.ToString();

                float Quanty = float.Parse(Quantity.Text);
                try
                {

                    String query = "select * from Food where FoodName ='" + FoodName + "'";
                    Debug.WriteLine(query);
                    SqlDataAdapter da = new SqlDataAdapter(query, Con);
                    SqlCommand sc;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Food");
                    DataTable dt = ds.Tables["Food"];

                    foreach (DataRow dr in dt.Rows)
                    {

                        float amountf = float.Parse(TAmount.Text);
                        String Quantty = Quantity.Text;
                        float quat = float.Parse(Quantty);
                        String unitprice = dr["UnitPrice"].ToString();
                        float Uprice = float.Parse(unitprice);
                        float amount = Uprice * quat;

                      
                        string FoodID = dr["FoodID"].ToString();
                        Debug.WriteLine(FoodID);
                        string FoodNames = dr["Foodname"].ToString();
                        string amounts = amount.ToString();
                        bool flag = true;
                        if (AddedFoodItem.Rows.Count > 1)
                        {

                            for (int j = 0; j < AddedFoodItem.Rows.Count - 1; j++)
                            {
                                if (FoodID == AddedFoodItem.Rows[j].Cells[0].Value.ToString())
                                {
                                    MessageBox.Show("you have already added" + FoodID);
                                    flag = false;
                                }
                            }
                            if (flag)
                            {
                                string[] row = { FoodID, FoodNames, Quantty, amounts };
                                AddedFoodItem.Rows.Add(row);
                                TAmount.Text = (amount + amountf).ToString();

                            }
                            flag = true;

                        }
                        else
                        {
                            string[] row = { FoodID, FoodNames, Quantty, amounts };
                            AddedFoodItem.Rows.Add(row);
                            TAmount.Text = (amount + amountf).ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Quantity.Clear();
            }
        }

        private void LIGHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the cost of Light in the comboBox 
            String Dlight = LIGHT.SelectedItem.ToString();
            String query = "select Cost from Decorations where decorationName = '" + Dlight + "'";

            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter(query, Con);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "Decorations");
            DataTable dt1 = ds1.Tables["Decorations"];

            foreach (DataRow dr in dt1.Rows)
            {
                float Value = float.Parse(dr["Cost"].ToString());
                UnitBox.Text = (dr["Cost"].ToString());
                TAmount.Text = (float.Parse(Costhall.Text) + float.Parse(UnitBox.Text) + float.Parse(FlowerUnit.Text) + float.Parse(UnitSeat.Text)).ToString();

            }
            Con.Close();


        }

        private void FLOWER_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the cost of Flower Decoration in the comboBox 
            String Dflower = FLOWER.SelectedItem.ToString();
            String query = "select Cost from Decorations where decorationName = '" + Dflower + "'";

            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter(query, Con);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "Decorations");
            DataTable dt1 = ds1.Tables["Decorations"];

            foreach (DataRow dr in dt1.Rows)
            {
                float Value = float.Parse(dr["Cost"].ToString());
                FlowerUnit.Text = (dr["Cost"].ToString());
                TAmount.Text = (float.Parse(Costhall.Text) + float.Parse(UnitBox.Text) + float.Parse(FlowerUnit.Text) + float.Parse(UnitSeat.Text)).ToString();
            }
            Con.Close();

        }

        private void SEAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the cost of Seats Catergory in the comboBox
            String Dseat = SEAT.SelectedItem.ToString();
            String query = "select Cost from Decorations where decorationName = '" + Dseat + "'";

            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter(query, Con);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "Decorations");
            DataTable dt1 = ds1.Tables["Decorations"];

            foreach (DataRow dr in dt1.Rows)
            {
                float Value = float.Parse(dr["Cost"].ToString());
                UnitSeat.Text = (dr["Cost"].ToString());
                TAmount.Text = (float.Parse(Costhall.Text) + float.Parse(UnitBox.Text) + float.Parse(FlowerUnit.Text) + float.Parse(UnitSeat.Text)).ToString();

            }
            Con.Close();

        }

        private void HID_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GUEST.Text == ""|| !function.isNumber(GUEST.Text))
            {
                MessageBox.Show("Guest cannot be null value and must be a Digit");
            }
            else
            {
               
                String HallType = HID.SelectedItem.ToString();
                String query = "select costperPerson from Halls where HallID = '" + HallType + "'";

                Con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, Con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Halls");
                DataTable dt1 = ds1.Tables["Halls"];

                foreach (DataRow dr in dt1.Rows)
                {
                    String Str = GUEST.Text;
                    int NoGuest = int.Parse(Str);
                    float Value = float.Parse(dr["costperPerson"].ToString());
                    Costhall.Text = (Value * NoGuest).ToString();
                    TAmount.Text = (float.Parse(Costhall.Text) + float.Parse(UnitBox.Text) + float.Parse(FlowerUnit.Text) + float.Parse(UnitSeat.Text)).ToString();

                }
                Con.Close();
            }

        }

        private void Dtype_SelectedIndexChanged(object sender, EventArgs e)
        {

            String Bev_type = Dtype.SelectedItem.ToString();
            Dname.Items.Clear();
            Dsize.Items.Clear();
            String query = "select B.BeverageName from Beverage B, BeverageType bt where B.beverageType= bt.beverageTypeID and bt.beverageTypeName='" + Bev_type + "'";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Beverage");
            DataTable dt = ds.Tables["Beverage"];

            foreach (DataRow dr in dt.Rows)
            {
                Dname.Items.Add(dr["BeverageName"].ToString());
            }
            Con.Close();

        }

        private void Dname_SelectedIndexChanged(object sender, EventArgs e)
        {

            String Drinktype = Dtype.SelectedItem.ToString();
            String Drinkname = Dname.SelectedItem.ToString();
            Dsize.Items.Clear();
            String query = "select size from AvailableBeverage where BeverageID =(select BeverageID from Beverage where  BeverageName = '" + Drinkname + "')";
            Console.Write(query);
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "table");
            DataTable dt = ds.Tables["table"];


            foreach (DataRow dr in dt.Rows)
            {
                Dsize.Items.Add(dr["size"].ToString());

            }

            Con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Dtype.SelectedItem == null)
            {
                MessageBox.Show("Please Select One");
            }
            else if (Dname.SelectedItem == null)
            {
                MessageBox.Show("Dname cannot be null");
            }
            else if (Dsize.SelectedItem == null)
            {
                MessageBox.Show("Incorrect size");
            }
            else if (Dquantity.Text == "")
            {
                MessageBox.Show("null quantity");
            }
            else if (!function.isNumber(Dquantity.Text))
            {
                MessageBox.Show("Should be digit");
            }
            else
            {
                String Drinkname = Dname.SelectedItem.ToString();
                String Drinksize = Dsize.SelectedItem.ToString();

                String query = "select * from Beverage B,AvailableBeverage ab where B.BeverageID=ab.BeverageID and BeverageName='" + Drinkname + "' and size='" + Drinksize + "'  ";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommand cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Beverage");
                DataTable dt = ds.Tables["Beverage"];


           
                foreach (DataRow dr in dt.Rows)
                {

                    float amountf = float.Parse(TAmount.Text);
                    String Quantty = Dquantity.Text;
                    float quat = float.Parse(Quantty);
                    String Price = dr["price"].ToString();
                    float Uprice = float.Parse(Price);
                    float amount = Uprice * quat;
                  
                    string BID = dr["BeverageID"].ToString();
                    string BeverageName = dr["BeverageName"].ToString();
                    string amounts = amount.ToString();
                    String Bsize = Dsize.SelectedItem.ToString();
                    bool flag = true;
                    if (Added_Drinks.Rows.Count > 1)
                    {

                        for (int j = 0; j < Added_Drinks.Rows.Count - 1; j++)
                        {
                            if (BID == Added_Drinks.Rows[j].Cells[0].Value.ToString() && Bsize == Added_Drinks.Rows[j].Cells[4].Value.ToString())
                            {
                                MessageBox.Show("you have already added" + BID);
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            string[] row = { BID, BeverageName, Quantty, amounts, Bsize };
                            Added_Drinks.Rows.Add(row);
                            TAmount.Text = (amount + amountf).ToString();


                        }
                        flag = true;

                    }
                    else
                    {
                        string[] row = { BID, BeverageName, Quantty, amounts, Bsize };
                        Added_Drinks.Rows.Add(row);
                        TAmount.Text = (amount + amountf).ToString();

                    }
                }
                Dquantity.Clear();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Fname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dsize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dquantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddedFoodItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void DiscountAmount_TextChanged(object sender, EventArgs e)
        {
            if (DiscountAmount.Text.Equals("0") || DiscountAmount.Text.Equals(""))
            {

                NetAmounts.Text = TAmount.Text;

            }
            else
            {
                float tamount = float.Parse(TAmount.Text);
                float dis = float.Parse(DiscountAmount.Text);


                NetAmounts.Text = (tamount - ((tamount * (dis / 100)))).ToString();
                BalanceAmount.Text = (tamount - ((tamount * (dis / 100)))).ToString();
            }
        }

        private void ReceivedAmount_TextChanged(object sender, EventArgs e)
        {
            if (ReceivedAmount.Text == "")
            {
                MessageBox.Show("should pay the money");
            }
            else
            {
                float Namount = float.Parse(NetAmounts.Text);
                float Pamount = float.Parse(ReceivedAmount.Text);
                BalanceAmount.Text = (Namount - Pamount).ToString();
            }
        }

        private void TIME_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*if select the time of event then it is automatically get the equal food time. example morning = breakfast*/
            if (TIME.SelectedIndex == 0)  
            {
                Ftime.SelectedIndex = 0;
            }
            else if (TIME.SelectedIndex == 1)
            {
                Ftime.SelectedIndex = 2;
            }
            else if (TIME.SelectedIndex == 2)
            {
                Ftime.SelectedIndex = 1;
            }
            else
            {
                Ftime.SelectedIndex = 1;
            }
            String query4 = "Select HallID from Halls where HallID not in(Select HA.HallID from Halls HA,Event_Halls EH where HA.HallID=EH.HallID and EH.TimeOfEvent='" + TIME.SelectedItem + "' And EH.DateOfEvent='" + this.DATE.Text + "') ";
            try
            {
                HID.Items.Clear();
                Con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query4, Con);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddedFoodItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {   //Delete the datagridview cells value if you don't want 
            if (AddedFoodItem.Columns[e.ColumnIndex].Name == "Delete")
            {
                int rowIndex = AddedFoodItem.CurrentCell.RowIndex;
                float amountf = float.Parse(TAmount.Text);
                String Dprice = AddedFoodItem.Rows[rowIndex].Cells[3].Value.ToString();
                MessageBox.Show("Delete this Item");
                TAmount.Text = (amountf -(float.Parse(Dprice))).ToString();
                AddedFoodItem.Rows.RemoveAt(rowIndex);
            }
        }

        private void Added_Drinks_Click(object sender, EventArgs e)
        {
            
        }

        private void Added_Drinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Delete the datagridview cells value if you don't want 
            if (Added_Drinks.Columns[e.ColumnIndex].Name=="BevDelete")
            {
                int rowIndex = Added_Drinks.CurrentCell.RowIndex;
                float amountf = float.Parse(TAmount.Text);
                String price = Added_Drinks.Rows[rowIndex].Cells[3].Value.ToString();
                float Dprice = float.Parse(price);
                TAmount.Text = (amountf - Dprice).ToString();
                Added_Drinks.Rows.RemoveAt(rowIndex);
            }
        }

        private void HID_SelectedIndexChanged_1(object sender, EventArgs e)
        {    
         
            if (GUEST.Text == "" || !function.isNumber(GUEST.Text))     //validation of number of guest  and calculate the cost of hall
            {
                MessageBox.Show("Guest cannot be Charcter and It must be a Digit");
            }
            else
            {

                String HallType = HID.SelectedItem.ToString();
                String query = "select costperPerson from Halls where HallID = '" + HallType + "'";

                Con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, Con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Halls");
                DataTable dt1 = ds1.Tables["Halls"];

                foreach (DataRow dr in dt1.Rows)
                {
                    String Str = GUEST.Text;
                    int NoGuest = int.Parse(Str);
                    float Value = float.Parse(dr["costperPerson"].ToString());
                    Costhall.Text = (Value * NoGuest).ToString();
                   TAmount.Text = (float.Parse(Costhall.Text) + float.Parse(UnitBox.Text) + float.Parse(FlowerUnit.Text) + float.Parse(UnitSeat.Text)).ToString();

                }
                Con.Close();
            }

        }

        private void TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DATE_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
