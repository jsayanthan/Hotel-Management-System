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
    public partial class BarMain : Form
    {
      
        public BarMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Barmanagement Bar = new Barmanagement();
            Bar.Show();
            this.Hide();
        }

        private void gymmanagement_Click(object sender, EventArgs e)
        {
            GymManagement Gym = new GymManagement();
            Gym.Show();
            this.Hide();
        }

        private void poolgamemanagement_Click(object sender, EventArgs e)
        {
            PoolGameManagement PoolGame = new PoolGameManagement();
            PoolGame.Show();
            this.Hide();
        }

        private void beverageorder_Click(object sender, EventArgs e)
        {
            BeverageOrders BeverageOrder = new BeverageOrders();
            BeverageOrder.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }

        private void BarMain_Load(object sender, EventArgs e)
        {

        }
    }
}
