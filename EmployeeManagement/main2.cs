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
    public partial class main2 : Form
    {
        public main2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BarMain bm=new BarMain();
            bm.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Front f = new Front();
            f.Show();
            this.Hide();
        }

        private void main2_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            StockHome sh = new StockHome();
            sh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountHome ah = new AccountHome();
            ah.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VehiclesHome vh = new VehiclesHome();
            vh.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FoodHome fh = new FoodHome();
            fh.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MaintananeHome mh = new MaintananeHome();
            mh.Show();
            this.Hide();
        }
    }
}
