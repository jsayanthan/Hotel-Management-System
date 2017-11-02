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
    public partial class PurchaseStock : Form
    {
        public PurchaseStock()
        {
            InitializeComponent();
        }

        private void PurchaseSock_Load(object sender, EventArgs e)
        {
            String query1 = "Select SupplierID,SupplierName from Supplier where status ='Available'";
            function.ComboWithKey(supcombo, query1, "SupplierID", "SupplierName");

            string query = "select StockID,StockName from Stock";
            function.ComboWithKey(stockcombo, query, "StockID", "StockName");

            function.loadTable(purchasedgv, "purchaseStock");
            function.loadTable(stockdgv, "Stock");
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (supcombo.SelectedIndex >= 0)
            {
                if (stockcombo.SelectedIndex >= 0)
                {
                    if(placecombo.SelectedIndex>=0)
                    {
                        if (quantitybox.Text != "" && function.IsDigit(quantitybox.Text))
                        {
                            if (unitpricebox.Text != "" && function.IsDigit(unitpricebox.Text))
                            {
                                string supplier = (((KeyValuePair<String, String>)supcombo.SelectedItem).Key);
                                string stockid = (((KeyValuePair<String, String>)stockcombo.SelectedItem).Key);
                                int quantity = int.Parse(quantitybox.Text);
                                float unitprice = int.Parse(unitpricebox.Text);
                                string place = placecombo.SelectedItem.ToString();
                                string purchaseStockid = function.getNextID("purchaseID", "purchaseStock", "PS");
                                DateTime date = DateTime.Now;
                                int totalquantity = function.getstockquantity(stockid) + quantity;
                                string querystock = "update Stock set Quantity='" + totalquantity + "' where StockID='" + stockid + "' ";
                                function.insertQuery(querystock);

                                string querypurchasestk = "insert into purchaseStock(purchaseID,StockID,Quantity,cost,SupplierID,Date)"
                                                         + "values('" + purchaseStockid + "','" + stockid + "','" + quantity + "','" + unitprice + "','" + supplier + "','"+date+"')";
                                function.insertQuery(querypurchasestk);

                                float amount = function.getSepCr(supplier) + (quantity * unitprice);
                                string querySupCR = "Update SupplierCredits set CreditBal='" + amount + "' where SupplierID='" + supplier + "' ";

                                function.insertQuery(querySupCR);

                                string queryPerstock = "";
                                string perstockid = "";
                                for (int i = 0; i < quantity; i++)
                                {
                                    perstockid = function.getNextID("PerStockID", "PerStock", "PS");
                                    queryPerstock = "insert into PerStock(PerStockID,stockId,AllocatedPlace)values('" + perstockid + "','" + stockid + "','" + place + "')";
                                    function.insertQuery(queryPerstock);
                                }

                                function.loadTable(purchasedgv, "purchaseStock");
                                function.loadTable(stockdgv, "Stock");

                                supcombo.SelectedIndex = -1;
                                stockcombo.SelectedIndex = -1;
                                quantitybox.Clear();
                                unitpricebox.Clear();
                                placecombo.SelectedIndex = -1;
                            }
                            else
                            {
                                MessageBox.Show("Invalid price format input numeric values");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid quantity Format input numeric values");
                            quantitybox.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select the Allocating area");
                    }
                }
                else
                {
                    MessageBox.Show("Please select the stock type");
                }
            }
            else
            {
                MessageBox.Show("Please Select the supplier");
            }  

        }

        private void placecombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            FixedStock fs = new FixedStock();
            fs.Show();
            this.Hide();
        }
    }
}
