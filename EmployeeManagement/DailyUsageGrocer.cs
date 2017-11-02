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

namespace EmployeeManagement
{
    public partial class DailyUsageGrocer : Form
    {
        public static SqlConnection CON = ConnectionManager.GetConnection();
        public DailyUsageGrocer()
        {
            InitializeComponent();
            
        }

        private void DailyUsageGrocer_Load(object sender, EventArgs e)
        {
            String query = "Select Name from GrocerFoods";
            function.LoadComboBox(query, GrocerComboBox, "Name");

            string qry2 = "select * from DailyUseGrocerFoods order by Date Desc ";
            function.loadTableQuery(UsageGrocer, qry2);

            string qry1 = "select Name,AvailableQuantity,preOderLevel from GrocerFoods";
            function.loadTableQuery(Availabledgv, qry1);
            function.loadrowcolour(Availabledgv,1);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GrocerFoods gf = new GrocerFoods();
            this.Hide();
            gf.Show();
            
        }

        private void GrocerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string name = GrocerComboBox.SelectedItem.ToString();
                string query = "select unit from GrocerFoods where Name='" + name + "'";
                //Debug.WriteLine(query);
                CON.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, CON);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    UnitBox.Text = (dr["unit"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CON.Close();
            }
        }

        private void UpdateGrocerStock_Click(object sender, EventArgs e)
        {
            if (GrocerComboBox.SelectedIndex >= 0)
            {
                if (function.IsDigit(QuantityBox.Text) && QuantityBox.Text != "")
                {
                    string name = GrocerComboBox.SelectedItem.ToString();
                    string unit = UnitBox.Text;
                    float quantity = float.Parse(QuantityBox.Text);
                    DateTime date = DateTime.Now;

                    float qty = 0f;
                    string query = "select AvailableQuantity from GrocerFoods where Name='" + name + "'";
                    //Debug.WriteLine(query);
                    CON.Open();
                    SqlDataAdapter sda1 = new SqlDataAdapter(query, CON);
                    DataSet ds1 = new DataSet();
                    sda1.Fill(ds1, "Table");
                    DataTable dt1 = ds1.Tables["Table"];

                    foreach (DataRow dr in dt1.Rows)
                    {
                        qty = float.Parse((dr["AvailableQuantity"].ToString()));
                    }
                    CON.Close();

                    float quanty = qty - quantity;
                    if (quanty > 0)
                    {
                        string DailyUseQuery = "insert into DailyUseGrocerFoods(Name,unit,Quantity,Date)values('" + name + "','" + unit + "','" + quantity + "','" + date + "')";
                        String updateGrocerQuery = "update GrocerFoods set AvailableQuantity='" + quanty + "' where Name='" + name + "' ";

                        function.insertQuery(DailyUseQuery);
                        function.insertQuery(updateGrocerQuery);

                        string qry2 = "select * from DailyUseGrocerFoods order by Date Desc ";
                        function.loadTableQuery(UsageGrocer, qry2);

                        string qry1 = "select Name,AvailableQuantity,preOderLevel from GrocerFoods";
                        function.loadTableQuery(Availabledgv, qry1);
                        function.loadrowcolour(Availabledgv, 1);

                        GrocerComboBox.SelectedIndex = 0;
                        UnitBox.Clear();
                        QuantityBox.Clear();
                    }
                    else
                    {

                        MessageBox.Show("Sorry you don't have sufficient Stock, you have only " + qty + " units ");
                        QuantityBox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Quantity type Input a numeric value");
                    QuantityBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Select the Grocery");
            }

            
            


        }
    }
}
