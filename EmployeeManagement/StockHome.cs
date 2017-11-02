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
    public partial class StockHome : Form
    {
        public StockHome()
        {
            InitializeComponent();
        }

        private void GrocersBTN_Click(object sender, EventArgs e)
        {
            GrocerFoods GF = new GrocerFoods();
            GF.Show();
            this.Hide(); 
        }

        private void SupplierBTN_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();
            this.Hide();
        }

        private void Stockbtn_Click(object sender, EventArgs e)
        {
            FixedStock fs = new FixedStock();
            fs.Show();
            this.Hide();
        
        }

        private void StockHome_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }
    }
}
