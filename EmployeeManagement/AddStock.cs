using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class AddStock : Form
    {
        public AddStock()
        {
            InitializeComponent();
        }

        private void AddStock_Load(object sender, EventArgs e)
        {
            string qry = "Select SupplierID,SupplierName from Supplier where status ='Available' ";
            function.ComboWithKey(suppliercombo, qry, "SupplierID", "SupplierName");
            stockidbox.Text = function.getNextID("StockID", "Stock", "ST");

            function.loadTable(addstockdgv, "Stock");
            stockidbox.Enabled = false;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            FixedStock fs = new FixedStock();
            fs.Show();
            this.Hide();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (suppliercombo.SelectedIndex >= 0)
            {
                if (stocknamebox.Text != "" && function.IsName(stocknamebox.Text))
                {
                    if (quantitybox.Text != "" && function.IsDigit(quantitybox.Text))
                    {
                        if (unitpricebox.Text != "" && function.IsDigit(unitpricebox.Text))
                        {
                            if (placecombo.SelectedIndex >= 0)
                            {
                                string supplier = (((KeyValuePair<String, String>)suppliercombo.SelectedItem).Key);
                                string stocksid = stockidbox.Text;
                                string stockname = stocknamebox.Text;
                                int quantity = int.Parse(quantitybox.Text);
                                float unitprice = float.Parse(unitpricebox.Text);
                                string place = placecombo.SelectedItem.ToString();
                                string purchaseStockid = function.getNextID("purchaseID", "purchaseStock", "PS");
                                DateTime date = DateTime.Now;

                                string querystock = "insert into Stock(StockID,StockName,Quantity)values"
                                                    + "('" + stocksid + "','" + stockname + "','" + quantity + "')";
                                function.insertQuery(querystock);

                                string querypurchasestk = "insert into purchaseStock(purchaseID,StockID,Quantity,cost,SupplierID,Date)"
                                                         + "values('" + purchaseStockid + "','" + stocksid + "','" + quantity + "','" + unitprice + "','" + supplier + "','"+date+"')";
                                function.insertQuery(querypurchasestk);

                                float amount = function.getSepCr(supplier) + (quantity * unitprice);
                                string querySupCR = "Update SupplierCredits set CreditBal='" + amount + "' where SupplierID='" + supplier + "' ";

                                function.insertQuery(querySupCR);

                                string queryPerstock = "";
                                string perstockid = "";
                                for (int i = 0; i < quantity; i++)
                                {
                                    perstockid = function.getNextID("PerStockID", "PerStock", "PS");
                                    queryPerstock = "insert into PerStock(PerStockID,stockId,AllocatedPlace)values('" + perstockid + "','" + stocksid + "','" + place + "')";
                                    function.insertQuery(queryPerstock);
                                }

                                function.loadTable(addstockdgv, "Stock");

                                stockidbox.Text = function.getNextID("StockID", "Stock", "ST");
                                suppliercombo.SelectedIndex = -1;
                                stocknamebox.Text = "";
                                quantitybox.Text = "";
                                unitpricebox.Text = "";
                                placecombo.SelectedIndex = -1;



                            }
                            else
                            {
                                MessageBox.Show("Please select the Allocating place");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invlaid price format Input only numeric values");
                            unitpricebox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invlaid Quantity format Input only numeric values");
                        quantitybox.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Invlaid Name format Input only Letters");
                    stocknamebox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Select The Supplier");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
