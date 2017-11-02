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
using System.Text.RegularExpressions;

namespace EmployeeManagement
{
    public partial class UpdateStock : Form
    {
        SqlConnection CON = ConnectionManager.GetConnection();
        public UpdateStock()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("PerStock");
        private void UpdateStock_Load(object sender, EventArgs e)
        {
            idbox.Enabled = false;
            stockidbox.Enabled = false;
            updatebtn.Enabled = false;
            Deletebtn.Enabled = false;

            //GrocerFoods.loadTable(updtstockdgv, "PerStock");
            function.loadTable(Stockdgv, "Stock");

            try
            {
                string query2 = "select * from  PerStock";
                CON.Open();

                SqlDataAdapter sda = new SqlDataAdapter(query2, CON);
                dt.Clear();
                sda.Fill(dt);
                updtstockdgv.DataSource = dt;
                CON.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            FixedStock fx = new FixedStock();
            fx.Show();
            this.Hide();
        }

        private void searchstockBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("PerStockID like '%{0}%' ", searchstockBox.Text);
           
        }

        private void updtstockdgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = updtstockdgv.CurrentCell.RowIndex;
            string perstockid = updtstockdgv.Rows[row].Cells[0].Value.ToString();
            string stockid = updtstockdgv.Rows[row].Cells[1].Value.ToString();
            string place = updtstockdgv.Rows[row].Cells[2].Value.ToString();

            idbox.Text = perstockid;
            stockidbox.Text = stockid;
            placeBox.SelectedText = place;

            updatebtn.Enabled = true;
            Deletebtn.Enabled = true;

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string perstockid = idbox.Text;
            string place = placeBox.SelectedItem.ToString();

            string query = "update PerStock set AllocatedPlace='" + place + "' where PerStockID ='" + perstockid + "' ";
            function.insertQuery(query);

            updatebtn.Enabled = false;
            Deletebtn.Enabled = false;

            //GrocerFoods.loadTable(updtstockdgv, "PerStock");
            function.loadTable(Stockdgv, "Stock");

            try
            {
                string query2 = "select * from  PerStock";
                CON.Open();

                SqlDataAdapter sda = new SqlDataAdapter(query2, CON);
                dt.Clear();
                sda.Fill(dt);
                updtstockdgv.DataSource = dt;
                CON.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            placeBox.SelectedIndex = -1;
            idbox.Clear();
            stockidbox.Clear();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            string perstockid = idbox.Text;
            string stockid = stockidbox.Text;
            string place = placeBox.SelectedText;
            int quantity = function.getstockquantity(stockid)-1;

            string query = "Delete from PerStock where PerStockID ='" + perstockid + "' ";
            function.insertQuery(query);

            string query1 = "update Stock set Quantity='" + quantity + "' where StockID='" + stockid + "' ";
            function.insertQuery(query1);

            updatebtn.Enabled = false;
            Deletebtn.Enabled = false;

            //GrocerFoods.loadTable(updtstockdgv, "PerStock");
            function.loadTable(Stockdgv, "Stock");

            try
            {
                string query2 = "select * from  PerStock";
                CON.Open();

                SqlDataAdapter sda = new SqlDataAdapter(query2, CON);
                dt.Clear();
                sda.Fill(dt);
                updtstockdgv.DataSource = dt;
                CON.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            placeBox.SelectedIndex = -1;
            idbox.Clear();
            stockidbox.Clear();

        }
    }
}
