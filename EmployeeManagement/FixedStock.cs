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
    public partial class FixedStock : Form
    {
        public FixedStock()
        {
            InitializeComponent();
        }

        private void addstock_Click(object sender, EventArgs e)
        {
            AddStock ads = new AddStock();
            ads.Show();
            this.Hide();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            StockHome sh = new StockHome();
            sh.Show();
            this.Hide();
        }

        private void updtstockbtn_Click(object sender, EventArgs e)
        {
            UpdateStock us = new UpdateStock();
            us.Show();
            this.Hide();
        }

        private void FixedStock_Load(object sender, EventArgs e)
        {

        }

        private void purchasebtn_Click(object sender, EventArgs e)
        {
            PurchaseStock ps = new PurchaseStock();
            ps.Show();
            this.Hide();
        }
    }
}
