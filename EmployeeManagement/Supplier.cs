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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewSupplier vs = new ViewSupplier();
            vs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSupplier ads = new AddSupplier();
            ads.Show();
            this.Hide();
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            StockHome sh = new StockHome();
            sh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditSupplier es = new EditSupplier();
            es.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SupplierCredits sc = new SupplierCredits();
            sc.Show();
            this.Hide();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }
    }
}
