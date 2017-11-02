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
    
    public partial class AddNewGrocer : Form
    {
        SqlConnection CON = ConnectionManager.GetConnection();

        AddSupplier asd = new AddSupplier();
        public AddNewGrocer()
        {
            InitializeComponent();
            
            
        }

        private void AddNewGrocer_Load(object sender, EventArgs e)
        {
            String query = "Select SupplierID,SupplierName from Supplier where status ='Available'";
            function.ComboWithKey(SupCombo, query, "SupplierID", "SupplierName");
            //GrocerFoods.LoadComboBox(query, SupCombo, "SupplierID");
            function.loadTable(NewGrocer, "GrocerFoods");
            function.loadrowcolour(NewGrocer,5);
            gfIDBox.Enabled = false;
            gfIDBox.Text= function.getNextID("GrocerFoodID", "GrocerFoods", "GF");

            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GrocerFoods gf = new GrocerFoods();
            this.Hide();
            gf.Show();
            
        }

        private void AddGrocerStock_Click(object sender, EventArgs e)
        {
            if (SupCombo.SelectedIndex >=0)
            {
                if (function.IsName(NameBox.Text) && NameBox.Text != "")
                {
                    if (UnitcomboBox.SelectedIndex >= 0)
                    {
                        if (function.IsDigit(UnitPriceBox.Text) && UnitPriceBox.Text != "")
                        {
                            if (function.IsDigit(QuantityBox.Text) && QuantityBox.Text != "")
                            {
                                if (function.IsDigit(POL.Text) && POL.Text != "")
                                {
                                    string GFID = function.getNextID("GrocerFoodID", "GrocerFoods", "GF");
                                    String Name = NameBox.Text;
                                    string unit = UnitcomboBox.SelectedItem.ToString();
                                    float unitprice = float.Parse(UnitPriceBox.Text);
                                    float quantity = float.Parse(QuantityBox.Text);
                                    float pol = float.Parse(POL.Text);
                                    string supplier = (((KeyValuePair<String,String>)SupCombo.SelectedItem).Key);
                                    DateTime date = DateTime.Now;

                                    float SupCr = function.getSepCr(supplier) + (unitprice * quantity);
                                    string pgf = function.getNextID("PurchaseID", "PurchaseGrocerFoods", "PG");



                                    //inserting new grocery details to Database
                                    string query = "insert into GrocerFoods(GrocerFoodID,Name,unit,AvgUnitPrice,CurrentPrice,"
                                                   + "AvailableQuantity,preOderLevel)values('" + GFID + "','" + Name + "','" + unit + "','" + unitprice + "',"
                                                   + "'" + unitprice + "','" + quantity + "','" + pol + "')";

                                    string PurchaseQuery = "insert into PurchaseGrocerFoods(PurchaseID,Name,unit,UnitPrice,Quantity,Date,Supplier)"
                                                           + "values('" + pgf + "','" + Name + "','" + unit + "','" + unitprice + "','" + quantity + "',"
                                                           + "'" + date + "','" + supplier + "')";

                                    string SupCRquery = "Update SupplierCredits set CreditBal='" + SupCr + "' where SupplierID = '" + supplier + "' ";
                                    function.insertQuery(query);
                                    function.insertQuery(PurchaseQuery);
                                    function.insertQuery(SupCRquery);

                                    //To Reload the Data Table
                                    function.loadTable(NewGrocer, "GrocerFoods");
                                    function.loadrowcolour(NewGrocer, 5);

                                    NameBox.Clear();
                                    UnitcomboBox.SelectedIndex = -1;
                                    UnitPriceBox.Clear();
                                    QuantityBox.Clear();
                                    POL.Clear();
                                    SupCombo.SelectedIndex = -1;

                                    gfIDBox.Text = function.getNextID("GrocerFoodID", "GrocerFoods", "GF");
                                }
                                else
                                {
                                    MessageBox.Show("Invlaid re-order Value input only numeric values");
                                    POL.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invlaid Quantity Value input only numeric values");
                                QuantityBox.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invlaid price Value input only numeric values");
                            UnitPriceBox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select the Unit");
                    }
                }
                else
                {
                    MessageBox.Show("Invlaid Name value input only letters");
                    NameBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Select the Supplier");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddSupplier asd = new AddSupplier(0);
            asd.Show();
            this.Hide();

            
        }
    }
}
