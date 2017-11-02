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
    public partial class Update : Form
    {
        SqlConnection Con = ConnectionManager.GetConnection();
        float totalAmount = 0;
        String qry= "select EV.EventID,EV.EventType,EV.NumOfGuests,EH.DateOfEvent,EH.TimeOfEvent,EH.HallID ,CU.CustID ,CU.FirstName ,CU.LastName,CU.NIC_OR_Passport,CU.Email,CU.Phone,CU.Address,CU.PostalCode,CU.Country,EL.DecorationName as Light,EF.DecorationName as Flower ,ES.DecorationName as Seat,PA.PaymentID,PA.TotalAmount,PA.AmountPaid,PA.Discount,PA.NetAmount,PA.Balance from Customer CU,Events EV , Event_Halls EH ,Event_Lightning EL,Event_Flower EF,Event_Seat ES,Payment PA where CU.CustID=EV.custID and EV.EventID =EH.EventID and EV.EventID =EF.EventID and EV.EventID =EL.EventID and EV.EventID =ES.EventID and EV.EventID =PA.EventID ";


        public Update()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Go to the home page
            this.Hide();
            Home h1 = new Home();
            h1.Show();
        }

        private void EventDate_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Validations 
            if (GUEST.Text == "")
            {
                MessageBox.Show("Please Enter The GuestNumber");
            }
            else if (!function.isNumber(GUEST.Text))
            {
                MessageBox.Show("please enter the correct form");
            }
            else if (!function.isText(FirstName.Text))
            {
                MessageBox.Show("First not in the  correct form");
            }
            else if (!function.isText(lname.Text))
            {
                MessageBox.Show("lastname not in the correct form");
            }
            else if (!function.isText(country.Text))
            {
                MessageBox.Show("country not in  the correct form");
            }
            else if (!function.IsValid(mail.Text))
            {
                MessageBox.Show("Incorrect mail format");
            }
            else if (function.numCount(telephone.Text, 10))
            {
                MessageBox.Show(" Phone number should be in 10 digits ");
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
                String query = "update Events set EventType='" + TYPE.SelectedItem.ToString() + "',NumOfGuests='" + GUEST.Text + "',DateOfEvent='" + DATE.Text + "',TimeOfEvent='" + TIME.SelectedItem.ToString() + "'where EventID='" + RID.Text + "'";
                function.ExecuteQuery(query, Con);

                String query1 = "update Event_Lightning set DecorationName='" + LIGHT.SelectedItem.ToString() + "'  where EventID='" + RID.Text + "'";
                function.ExecuteQuery(query1, Con);

                String query2 = "update Event_Flower set DecorationName='" + FLOWER.SelectedItem.ToString() + "'  where EventID='" + RID.Text + "'";
                function.ExecuteQuery(query2, Con);

                String query3 = "update Event_Seat set DecorationName='" + SEAT.SelectedItem.ToString() + "'  where EventID='" + RID.Text + "'";
                function.ExecuteQuery(query3, Con);

                String query4 = "update Customer set FirstName='" + FirstName.Text + "',LastName='" + lname.Text + "',NIC_OR_Passport='" + nic.Text + "',Email='" + mail.Text + "',Phone='" + telephone.Text + "',Address='" + address.Text + "',PostalCode='" + PCode.Text + "',Country='" + country.Text + "'  where CustID='" + customerid.Text + "'";
                function.ExecuteQuery(query4, Con);

                String EventID = RID.Text;
                String FoodID = "";
                List<String[]> list_new;
                List<String[]> list_old;
                String[][] arr_old_subjects;
                String[][] arr_new_subjects;

                list_new = new List<String[]>();
                list_old = new List<String[]>();

                //Create an array of old subjects related to grade
                query = "select FD.FoodID, '" + EventID + "' as EventID, FD.FoodName,EVF.Quantity,(EVF.Quantity*FD.UnitPrice) as amount from Event_Food EVF,Food FD where EVF.FoodID=FD.FoodID and EVF.EventID='" + RID.Text + "'";
                list_old = function.getList("FoodID", "EventID", query, Con);
                arr_old_subjects = list_old.ToArray();

                //Create an array of new subjects related to grade
                string fid = "";
                for (int i = 0; i < (AddedFoodItem.Rows.Count - 1); i++)
                {
                    fid = AddedFoodItem.Rows[i].Cells[1].Value.ToString();
                    list_new.Add(new String[2] { fid, EventID });
                }
                arr_new_subjects = list_new.ToArray();


                //Compare both old & new arrays
                function.compareArrays(arr_new_subjects, arr_old_subjects);

                for (int i = 0; i < (AddedFoodItem.Rows.Count - 1); i++)
                {
                    int qty = int.Parse(AddedFoodItem.Rows[i].Cells[3].Value.ToString());
                    string FID = AddedFoodItem.Rows[i].Cells[1].Value.ToString();


                    //Update the tables according to the new and old data
                    for (int j = 0; j < arr_new_subjects.Length; j++)
                    {
                        if (arr_new_subjects[j][0] == FID)
                        {
                            if (arr_new_subjects[j][0] != "" && arr_new_subjects[j][1] != "")
                            {
                                query = "INSERT INTO Event_Food VALUES ('" + RID.Text + "','" + FID + "', " + qty + ") ";
                                function.ExecuteQuery(query, Con);
                                Debug.WriteLine(query);
                            }
                        }
                    }
                }
                for (int j = 0; j < arr_old_subjects.Length; j++)
                {
                    if (arr_old_subjects[j][0] != "" && arr_old_subjects[j][1] != "")
                    {

                        query = "delete from Event_Food where EventID = '" + arr_old_subjects[j][1] + "' and FoodID = '" + arr_old_subjects[j][0] + "'";
                        function.ExecuteQuery(query, Con);
                        Debug.WriteLine(query);
                    }
                }

                String ResID = RID.Text;
                String BeverageID = "";
                List<String[]> Blist_new;
                List<String[]> Blist_old;
                String[][] Barr_old_subjects;
                String[][] Barr_new_subjects;

                Blist_new = new List<String[]>();
                Blist_old = new List<String[]>();

                //Create an array of old subjects related to grade
                query = "select BE.BeverageID,'" + ResID + "' as EventID,BE.BeverageName,EB.Quantity,(EB.Quantity*AB.price) as Amount,EB.Size from AvailableBeverage AB,Event_Beverage EB,Beverage BE where AB.BeverageID=EB.BeverrageID and  AB.BeverageID=BE.BeverageID and AB.size=EB.Size and EB.EventID='" + RID.Text + "'";
                Blist_old = function.getList("BeverageID", "EventID", query, Con);
                Barr_old_subjects = Blist_old.ToArray();

                //Create an array of new subjects related to grade
                string bid = "";
                for (int i = 0; i < (Added_Drinks.Rows.Count - 1); i++)
                {
                    bid = Added_Drinks.Rows[i].Cells[1].Value.ToString();
                    Blist_new.Add(new String[2] { bid, EventID });
                }
                Barr_new_subjects = Blist_new.ToArray();


                //Compare both old & new arrays
                function.compareArrays(Barr_new_subjects, Barr_old_subjects);

                for (int i = 0; i < (Added_Drinks.Rows.Count - 1); i++)
                {

                    int qty = int.Parse(Added_Drinks.Rows[i].Cells[3].Value.ToString());
                    string FID = Added_Drinks.Rows[i].Cells[1].Value.ToString();
                    String Size = Added_Drinks.Rows[i].Cells[5].Value.ToString();


                    //Update the tables according to the new and old data
                    for (int j = 0; j < Barr_new_subjects.Length; j++)
                    {
                        if (Barr_new_subjects[j][0] == FID)
                        {
                            if (Barr_new_subjects[j][0] != "" && Barr_new_subjects[j][1] != "")
                            {
                                query = "INSERT INTO Event_Beverage VALUES ('" + RID.Text + "','" + FID + "', " + qty + ",'" + Size + "') ";
                                function.ExecuteQuery(query, Con);
                                Debug.WriteLine(query);



                            }
                        }
                    }
                }
                for (int j = 0; j < Barr_old_subjects.Length; j++)
                {

                    if (Barr_old_subjects[j][0] != "" && Barr_old_subjects[j][1] != "")
                    {
                        query = "delete from Event_Beverage where EventID = '" + Barr_old_subjects[j][1] + "' and BeverrageID = '" + Barr_old_subjects[j][0] + "'";
                        function.ExecuteQuery(query, Con);
                        Debug.WriteLine(query);
                    }

                }


                String query5 = "update Payment set TotalAmount='" + TAmount.Text + "',AmountPaid='" + ReceivedAmount.Text + "',Discount='" + DiscountAmount.Text + "',NetAmount='" + NetAmounts.Text + "',Balance='" + BalanceAmount.Text + "'  where PaymentID='" + PaymentID.Text + "'";
                function.ExecuteQuery(query5, Con);
                function.loadTable(qry, UpdateDataGridView);
                MessageBox.Show("successfully updated");

                function.ClearAllText(this);
            }

          }

          /*public void Search_data(string valuetofind)
          {
              Con.Open();
              SqlCommand cmd = Con.CreateCommand();
              cmd.CommandType = CommandType.Text;
              cmd.CommandText = "select EV.EventID,EV.EventType,EV.NumOfGuests,EH.DateOfEvent,EH.TimeOfEvent,EH.HallID ,CU.CustID ,CU.FirstName ,CU.LastName,CU.NIC_OR_Passport,CU.Email,CU.Phone,CU.Address,CU.PostalCode,CU.Country,EL.DecorationName as Light,EF.DecorationName as Flower ,ES.DecorationName as Seat,PA.PaymentID,PA.TotalAmount,PA.AmountPaid,PA.Discount,PA.NetAmount,PA.Balance from Customer CU,Events EV , Event_Halls EH ,Event_Lightning EL,Event_Flower EF,Event_Seat ES,Payment PA where CU.CustID=EV.custID and EV.EventID =EH.EventID and EV.EventID =EF.EventID and EV.EventID =EL.EventID and EV.EventID =ES.EventID and EV.EventID =PA.EventID  and CONCAT(CU.CustID,EV.EventID) LIKE'%" + valuetofind+"%'";
              cmd.ExecuteNonQuery();
              DataTable dt = new DataTable();
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              da.Fill(dt);
              UpdateDataGridView.DataSource = dt;

              Con.Close();


          }*/
          private void Update_Load(object sender, EventArgs e)
          {
            FDupdate.Visible = false;
            New.Visible = false;
            Bnew.Visible = false;
            BevUpdate.Visible = false;
            function.loadTable(qry, UpdateDataGridView);
            NetAmounts.Enabled = false;
            BalanceAmount.Enabled = false;
            DATE.Text = DateTime.Now.ToString("yyyy-MM-dd");

            String query4 = "select HallID from Halls ";
            try
            {
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
                // Ftype.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void Ftime_SelectedIndexChanged(object sender, EventArgs e)
        {

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



            Con.Close();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Ftime.SelectedItem == null)
            {
                MessageBox.Show("FoodTime Null");
            }
            else if (Ftype.SelectedItem == null)
            {
                MessageBox.Show("food type incorrect");
            }
            else if (Fname.SelectedItem == null)
            {
                MessageBox.Show("FoodName incorrect");
            }
            else if (Quantity.Text == "")
            {
                MessageBox.Show("Null quantity");
            }
            else if (!function.isNumber(Quantity.Text))
            {
                MessageBox.Show("should be degit");
            }
            else
            {
                try
                {
                    String FoodTime = Ftime.SelectedItem.ToString();
                    String FoodType = Ftype.SelectedItem.ToString();
                    String FoodName = Fname.SelectedItem.ToString();
                    float Quanty = float.Parse(Quantity.Text);
                    String query = "select * from Food where FoodName ='" + FoodName + "'";
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
                        string FoodNames = dr["FoodName"].ToString();
                        string amounts = amount.ToString();

                        bool flag = true;
                        if (AddedFoodItem.Rows.Count > 1)
                        {

                            for (int k = 0; k < AddedFoodItem.Rows.Count - 1; k++)
                            {
                                if (FoodID == AddedFoodItem.Rows[k].Cells[1].Value.ToString())
                                {
                                    MessageBox.Show("you have already added" + FoodID);
                                    flag = false;
                                }
                            }
                            if (flag)
                            {
                                DataTable dt1 = AddedFoodItem.DataSource as DataTable;
                                int j = dt1.Rows.Count;
                                string[] row = { FoodID, FoodNames, Quantty, amounts };
                                dt1.Rows.Add(row);
                                AddedFoodItem.DataSource = dt1;
                                TAmount.Text = (amount + amountf).ToString();

                            }
                            flag = true;

                        }
                        else
                        {
                            DataTable dt1 = AddedFoodItem.DataSource as DataTable;
                            int j = dt1.Rows.Count;
                            string[] row = { FoodID, FoodNames, Quantty, amounts };
                            dt1.Rows.Add(row);
                            AddedFoodItem.DataSource = dt1;
                            TAmount.Text = (amount + amountf).ToString();
                        }
                    }



                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Dtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load  the Beverage Name if we select the BeverageType
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
            //Load the beverage size
            String Drinktype = Dtype.SelectedItem.ToString();
            String Drinkname = Dname.SelectedItem.ToString();
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

        private void Dname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Beverage Size Loading
            String Drinktype = Dtype.SelectedItem.ToString();
            String Drinkname = Dname.SelectedItem.ToString();
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
                MessageBox.Show("Incorrect name");
            }
            else if (Dname.SelectedItem == null)
            {
                MessageBox.Show("Beverage Name null");
            }
            else if (Dsize.SelectedItem == null)
            {
                MessageBox.Show("Incorrect size");
            }
            else if (Dquantity.Text == "")
            {
                MessageBox.Show(" quantity is Empty");
            }
            else if (!function.isNumber(Dquantity.Text))
            {
                MessageBox.Show(" Quantity Should be a digit");
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
                    DataTable dt1 = Added_Drinks.DataSource as DataTable;

                    bool flag = true;
                    if (Added_Drinks.Rows.Count > 1)
                    {

                        for (int j = 0; j < Added_Drinks.Rows.Count - 1; j++)
                        {
                            if (BID == Added_Drinks.Rows[j].Cells[1].Value.ToString() && Bsize == Added_Drinks.Rows[j].Cells[5].Value.ToString())
                            {
                                MessageBox.Show("you have already added" + BID);
                                flag = false;
                            }
                        }
                        if (flag)
                        {
                            int j = dt1.Rows.Count;
                            string[] row = { BID, BeverageName, Quantty, amounts, Bsize };
                            dt1.Rows.Add(row);
                            Added_Drinks.DataSource = dt1;
                            TAmount.Text = (amount + amountf).ToString();
                        }
                        flag = true;

                    }
                    else
                    {
                        int j = dt1.Rows.Count;
                        string[] row = { BID, BeverageName, Quantty, amounts, Bsize };
                        dt1.Rows.Add(row);
                        Added_Drinks.DataSource = dt1;
                        TAmount.Text = (amount + amountf).ToString();
                    }
                }
            }
        }

        private void LIGHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the cost of the Lightning
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
                totalAmount = totalAmount + Value;
                TAmount.Text = (totalAmount.ToString());

            }
            Con.Close();

        }

        private void FLOWER_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the cost of the Flower
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
                totalAmount = totalAmount + Value;
                TAmount.Text = (totalAmount.ToString());
            }
            Con.Close();

        }

        private void SEAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the cost of the Seat

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
                totalAmount = totalAmount + Value;
                TAmount.Text = (totalAmount.ToString());
            }
            Con.Close();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {  
            //search by customerID or EventID
            //Search_data(search.Text);
            string qry= "select EV.EventID,EV.EventType,EV.NumOfGuests,EH.DateOfEvent,EH.TimeOfEvent,EH.HallID ,CU.CustID ,CU.FirstName ,CU.LastName,CU.NIC_OR_Passport,CU.Email,CU.Phone,CU.Address,CU.PostalCode,CU.Country,EL.DecorationName as Light,EF.DecorationName as Flower ,ES.DecorationName as Seat,PA.PaymentID,PA.TotalAmount,PA.AmountPaid,PA.Discount,PA.NetAmount,PA.Balance from Customer CU,Events EV , Event_Halls EH ,Event_Lightning EL,Event_Flower EF,Event_Seat ES,Payment PA where CU.CustID=EV.custID and EV.EventID =EH.EventID and EV.EventID =EF.EventID and EV.EventID =EL.EventID and EV.EventID =ES.EventID and EV.EventID =PA.EventID  and CONCAT(CU.CustID,EV.EventID) LIKE'%" + search.Text + "%'";
            function.loadTable(qry, UpdateDataGridView);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // click the cell of data gridview values and get the values to text box 
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = UpdateDataGridView.Rows[index];
            RID.Text = SelectedRow.Cells[0].Value.ToString();
            TYPE.SelectedItem = SelectedRow.Cells[1].Value.ToString();
            GUEST.Text = SelectedRow.Cells[2].Value.ToString();
            String Ent_date = SelectedRow.Cells[3].Value.ToString();
            DateTime dt = Convert.ToDateTime(Ent_date);
            DATE.Text = dt.ToShortDateString();
            TIME.Text = SelectedRow.Cells[4].Value.ToString();
            HID.SelectedItem = SelectedRow.Cells[5].Value.ToString();
            customerid.Text = SelectedRow.Cells[6].Value.ToString();
            FirstName.Text = SelectedRow.Cells[7].Value.ToString();
            lname.Text = SelectedRow.Cells[8].Value.ToString();
            nic.Text = SelectedRow.Cells[9].Value.ToString();
            mail.Text = SelectedRow.Cells[10].Value.ToString();
            telephone.Text = SelectedRow.Cells[11].Value.ToString();
            address.Text = SelectedRow.Cells[12].Value.ToString();
            PCode.Text = SelectedRow.Cells[13].Value.ToString();
            country.Text = SelectedRow.Cells[14].Value.ToString();
            LIGHT.SelectedItem = SelectedRow.Cells[15].Value.ToString();
            FLOWER.SelectedItem = SelectedRow.Cells[16].Value.ToString();
            SEAT.SelectedItem = SelectedRow.Cells[17].Value.ToString();
            PaymentID.Text = SelectedRow.Cells[18].Value.ToString();
            TAmount.Text = SelectedRow.Cells[19].Value.ToString();
            DiscountAmount.Text = SelectedRow.Cells[21].Value.ToString();
            NetAmounts.Text = SelectedRow.Cells[22].Value.ToString();
            ReceivedAmount.Text = SelectedRow.Cells[20].Value.ToString();
            BalanceAmount.Text = SelectedRow.Cells[23].Value.ToString();

            String Query= "select FD.FoodID,FD.FoodName,EVF.Quantity,(EVF.Quantity*FD.UnitPrice) as amount from Event_Food EVF,Food FD where EVF.FoodID=FD.FoodID and EVF.EventID='" + RID.Text + "'";
            function.loadTable(Query, AddedFoodItem);

            String Query1= "select BE.BeverageID,BE.BeverageName,EB.Quantity,(EB.Quantity*AB.price) as Amount,EB.Size from AvailableBeverage AB,Event_Beverage EB,Beverage BE where AB.BeverageID=EB.BeverrageID and  AB.BeverageID=BE.BeverageID and AB.size=EB.Size and EB.EventID='" + RID.Text + "'";
            function.loadTable(Query1, Added_Drinks);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Fname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DrinksType_Enter(object sender, EventArgs e)
        {

        }

        private void AddedFoodItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddedFoodItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cell click of gridview of foodItems 
            FDupdate.Visible = true;
            New.Visible = true;
            Ftime.Enabled = false;
            Ftype.Enabled = false;
            Fname.Enabled = false;
            int index = AddedFoodItem.CurrentCell.RowIndex;
            Fname.Text = AddedFoodItem.Rows[index].Cells[2].Value.ToString();
            Quantity.Text = AddedFoodItem.Rows[index].Cells[3].Value.ToString();
            if (AddedFoodItem.Columns[e.ColumnIndex].Name == "Delete")
            {
                int rowIndex = AddedFoodItem.CurrentCell.RowIndex;
                float amountf = float.Parse(TAmount.Text);
                String Dprice = AddedFoodItem.Rows[rowIndex].Cells[4].Value.ToString();
                MessageBox.Show(Dprice.ToString());
                TAmount.Text = (amountf - (float.Parse(Dprice))).ToString();
                AddedFoodItem.Rows.RemoveAt(rowIndex);
            }
           
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete rows in datagridview of food
            int Index = AddedFoodItem.CurrentCell.RowIndex;
            String FID = AddedFoodItem.Rows[Index].Cells[1].Value.ToString();
            String query = "delete from Event_Food where EventID = '" + RID.Text + "' and FoodID = '" + FID+ "'";
            function.ExecuteQuery(query, Con);

        }

        private void button7_Click(object sender, EventArgs e)
        {

            //delete rows in datagridview of Beverage
            float amountf = float.Parse(TAmount.Text);
            float Dprice = float.Parse(Convert.ToString(Added_Drinks.SelectedCells[4].Value));
            int rowIndex = Added_Drinks.CurrentCell.RowIndex;
            Added_Drinks.Rows.RemoveAt(rowIndex);
            TAmount.Text = (amountf - Dprice).ToString();
        }

        private void FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete Query
            String query = "delete from Payment where EventID='" + RID.Text + "' ";
            function.ExecuteQuery(query, Con);
            Debug.WriteLine(query);

            String query1 = "delete from Events where EventID='" + RID.Text + "' ";
            function.ExecuteQuery(query1, Con);
            Debug.WriteLine(query1);
            function.loadTable(qry, UpdateDataGridView);
            MessageBox.Show("Successfully deleted");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void DiscountAmount_TextChanged(object sender, EventArgs e)
        {
            //Calculate Discount
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
            //Calculate balance Amount 
            if (ReceivedAmount.Text == "")
            {
                MessageBox.Show("Receive Amount is null.Please pay the amount");
            }
            else
            {
                float Namount = float.Parse(NetAmounts.Text);
                float Pamount = float.Parse(ReceivedAmount.Text);
                BalanceAmount.Text = (Namount - Pamount).ToString();
            }
        }

        private void Added_Drinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview of Beverages 
            Bnew.Visible = true;
            BevUpdate.Visible = true;
            Dtype.Enabled = false;
            Dname.Enabled = false;
            Dsize.Enabled = false;
            int index = Added_Drinks.CurrentCell.RowIndex;
            Dname.Text = Added_Drinks.Rows[index].Cells[2].Value.ToString();
            Dquantity.Text = Added_Drinks.Rows[index].Cells[3].Value.ToString();
            Dsize.Text = Added_Drinks.Rows[index].Cells[5].Value.ToString();
            if (Added_Drinks.Columns[e.ColumnIndex].Name == "BevDelete")
            {
                int rowIndex = Added_Drinks.CurrentCell.RowIndex;
                float amountf = float.Parse(TAmount.Text);
                String price = Added_Drinks.Rows[rowIndex].Cells[4].Value.ToString();
                float Dprice = float.Parse(price);
                TAmount.Text = (amountf - Dprice).ToString();
                Added_Drinks.Rows.RemoveAt(rowIndex);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Food Update in Data GridView
            int Index = AddedFoodItem.CurrentCell.RowIndex;
            float amountf = float.Parse(TAmount.Text);
            String a = AddedFoodItem.Rows[Index].Cells[4].Value.ToString();
            TAmount.Text = (amountf - float.Parse(a)).ToString();
            MessageBox.Show(TAmount.Text.ToString());
            String FID = AddedFoodItem.Rows[Index].Cells[1].Value.ToString();
            String query = "delete from Event_Food where EventID = '" + RID.Text + "' and FoodID = '" + FID + "'";
            function.ExecuteQuery(query, Con);
            foreach (DataGridViewCell oneCell in AddedFoodItem.SelectedCells)
            {
                if (oneCell.Selected)
                    AddedFoodItem.Rows.RemoveAt(oneCell.RowIndex);
            }


            String FoodName = Fname.Text.ToString();
            float Quanty = float.Parse(Quantity.Text);
            String query1 = "select * from Food where FoodName ='" + FoodName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query1, Con);
            SqlCommand sc;
            DataSet ds = new DataSet();
            da.Fill(ds, "Food");
            DataTable dt = ds.Tables["Food"];
            foreach (DataRow dr in dt.Rows)
            {
                float amountfD = float.Parse(TAmount.Text);
                String Quantty = Quantity.Text;
                float quat = float.Parse(Quantity.Text);
                String unitprice = dr["UnitPrice"].ToString();
                float Uprice = float.Parse(unitprice);
                float amount = Uprice * quat;
                string FoodID = dr["FoodID"].ToString();
                string FoodNames = dr["FoodName"].ToString();
                string amounts = amount.ToString();
                DataTable dt1 = AddedFoodItem.DataSource as DataTable;
                int j = dt1.Rows.Count;
                string[] row = { FoodID, FoodNames, Quantty, amounts };
                dt1.Rows.Add(row);
                TAmount.Text = (amount + amountfD).ToString();
                MessageBox.Show("updated");

                        

            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            Fname.Text = "";
            Quantity.Text = "";
            Ftime.Enabled = true;
            Ftype.Enabled = true;
            New.Visible = false;
            FDupdate.Visible = false;
            Fname.Enabled = true;
        }

        private void BevUpdate_Click(object sender, EventArgs e)
        {
            // Beverage updated Event
            int Index = Added_Drinks.CurrentCell.RowIndex;
            float amountf = float.Parse(TAmount.Text);
            String a = Added_Drinks.Rows[Index].Cells[4].Value.ToString();
            TAmount.Text = (amountf - float.Parse(a)).ToString();
            MessageBox.Show(TAmount.Text.ToString());
            String BID = Added_Drinks.Rows[Index].Cells[1].Value.ToString();
            String query = "delete from Event_Beverage where EventID = '" + RID.Text + "' and BeverrageID = '" + BID + "'";
            function.ExecuteQuery(query, Con);
            foreach (DataGridViewCell oneCell in Added_Drinks.SelectedCells)
            {
                if (oneCell.Selected)
                    Added_Drinks.Rows.RemoveAt(oneCell.RowIndex);
            }
            MessageBox.Show("Updated");

            String query1 = "select * from Beverage B,AvailableBeverage ab where B.BeverageID=ab.BeverageID and BeverageName='" + Dname.Text + "' and size='" + Dsize.Text + "'  ";
            SqlDataAdapter da = new SqlDataAdapter(query1, Con);
            SqlCommand cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Beverage");
            DataTable dt = ds.Tables["Beverage"];

            foreach (DataRow dr in dt.Rows)
            {

                float amountfd = float.Parse(TAmount.Text);
                String Quantty = Dquantity.Text;
                float quat = float.Parse(Quantty);
                String Price = dr["price"].ToString();
                float Uprice = float.Parse(Price);
                float amount = Uprice * quat;
                string bid = dr["BeverageID"].ToString();
                string BeverageName = dr["BeverageName"].ToString();
                string amounts = amount.ToString();
                String Bsize = Dsize.Text.ToString();
                DataTable dt1 = Added_Drinks.DataSource as DataTable;
                int j = dt1.Rows.Count;
                string[] row = { bid, BeverageName, Quantty, amounts, Bsize };
                dt1.Rows.Add(row);
                Added_Drinks.DataSource = dt1;
                TAmount.Text = (amount + amountfd).ToString();
            }
        }

        private void Bnew_Click(object sender, EventArgs e)
        {
            //Beverage New  Adding in the updated form
            Dtype.Text = "";
            Dname.Text = "";
            Dsize.Text = "";
            Dquantity.Text = "";
            Dtype.Enabled = true;
            Dname.Enabled = true;
            Dsize.Enabled = true;
            Bnew.Visible = false;
            BevUpdate.Visible = false;
        }

        private void TIME_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Equal to  Events time and  food time
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
        }

        private void HID_SelectedIndexChanged(object sender, EventArgs e)
        {
            //validate Number of Guest and get the cost of a hall
            if (GUEST.Text == "" || !function.isNumber(GUEST.Text))
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
                }
                Con.Close();
            }

        }

        private void GUEST_TextChanged(object sender, EventArgs e)
        {

        }

        private void TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DATE_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BalanceAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Added_Drinks_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void Dsize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            EventCrystal ec = new EventCrystal();
            ec.Show();
        }
    }
}
