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

namespace EmployeeManagement
{
    public partial class UpdateGrocer : Form
    {
        public static SqlConnection CON = ConnectionManager.GetConnection();
        public UpdateGrocer()
        {
            InitializeComponent();
            
        }

        private void UpdateGrocer_Load(object sender, EventArgs e)
        {
            string query = "Select Name from GrocerFoods";
            function.LoadComboBox(query, GrocerComboBox, "Name");

            string query1 = "Select SupplierID,SupplierName from Supplier where status ='Available'";
            function.ComboWithKey(SupCombo, query1, "SupplierID", "SupplierName");

            string query2 = "Select * from PurchaseGrocerFoods order by Date Desc";
            function.loadTableQuery(UpdtGrocer, query2);

            string qry1 = "select Name,AvailableQuantity,preOderLevel from GrocerFoods";
            function.loadTableQuery(availabledgv, qry1);
            function.loadrowcolour(availabledgv, 1);


        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GrocerFoods gf = new GrocerFoods();
            this.Hide();
            gf.Show();
        }

        private void GrocerComboBox_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void GrocerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GrocerComboBox.SelectedItem.ToString();
            string query = "select unit from GrocerFoods where Name='" + name + "'";
            
            CON.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter(query, CON);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1, "Table");
            DataTable dt1 = ds1.Tables["Table"];

            foreach (DataRow dr in dt1.Rows)
            {
                UnitBox.Text = (dr["unit"].ToString());
            }
            CON.Close();
        }

        private void Quantity_MouseLeave(object sender, EventArgs e)
        {
            if (UnitPriceBox.Text != "" && QuantityBox.Text != "")
            {
                float price = float.Parse(UnitPriceBox.Text);
                float quantity = float.Parse(QuantityBox.Text);
                float amount = price * quantity;
                AmountBox.Text = amount.ToString();
            }
        }

        private void UpdateGrocerStock_Click(object sender, EventArgs e)
        {
            if (GrocerComboBox.SelectedIndex >=0)
            {
                if (function.IsDigit(UnitPriceBox.Text) && UnitPriceBox.Text != "")
                {
                    if (function.IsDigit(QuantityBox.Text) && QuantityBox.Text != "")
                    {
                        if (SupCombo.SelectedIndex >=0)
                        {
                            string pgf = function.getNextID("PurchaseID", "PurchaseGrocerFoods", "PG");
                            string name = GrocerComboBox.SelectedItem.ToString();
                            string unit = UnitBox.Text;
                            float unitprice = float.Parse(UnitPriceBox.Text);
                            float quantity = float.Parse(QuantityBox.Text);
                            string supplier = (((KeyValuePair<String, String>)SupCombo.SelectedItem).Key);
                            DateTime date = DateTime.Now;
                            float SupCr = function.getSepCr(supplier) + (unitprice * quantity);

                            float Avgprice = 0f;
                            float qty = 0f;
                            string query = "select AvgUnitPrice,AvailableQuantity from GrocerFoods where Name='" + name + "'";

                            CON.Open();
                            SqlDataAdapter sda1 = new SqlDataAdapter(query, CON);
                            DataSet ds1 = new DataSet();
                            sda1.Fill(ds1, "Table");
                            DataTable dt1 = ds1.Tables["Table"];

                            foreach (DataRow dr in dt1.Rows)
                            {
                                Avgprice = float.Parse((dr["AvgUnitPrice"].ToString()));
                                qty = float.Parse((dr["AvailableQuantity"].ToString()));

                            }
                            CON.Close();

                            Avgprice = ((Avgprice * qty) + (unitprice * quantity)) / (quantity + qty);
                            qty = quantity + qty;


                            string PurchaseQuery = "insert into PurchaseGrocerFoods(PurchaseID,Name,unit,UnitPrice,Quantity,Date,Supplier)values('" + pgf + "','" + name + "','" + unit + "','" + unitprice + "','" + quantity + "','" + date + "','" + supplier + "')";
                            string updateGrocerQuery = "update GrocerFoods set AvgUnitPrice='" + Avgprice + "',CurrentPrice='" + unitprice + "',AvailableQuantity='" + qty + "' where Name='" + name + "' ";
                            string SupCRquery = "Update SupplierCredits set CreditBal='" + SupCr + "' where SupplierID = '" + supplier + "' ";
                            Debug.WriteLine(SupCRquery);
                            function.insertQuery(PurchaseQuery);
                            function.insertQuery(updateGrocerQuery);
                            function.insertQuery(SupCRquery);

                            string query2 = "Select * from PurchaseGrocerFoods order by Date Desc";
                            function.loadTableQuery(UpdtGrocer, query2);

                            string qry1 = "select Name,AvailableQuantity,preOderLevel from GrocerFoods";
                            function.loadTableQuery(availabledgv, qry1);
                            function.loadrowcolour(availabledgv, 1);

                            GrocerComboBox.SelectedItem = "";
                            UnitBox.Clear();
                            UnitPriceBox.Clear();
                            QuantityBox.Clear();
                            AmountBox.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please Select the Supplier");
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Invalid Quantity type Input Numeric Value only");
                        QuantityBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Invlaid unit value input only letters");
                    UnitPriceBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Select the Grocery");
            }

            



        }
    }
}
