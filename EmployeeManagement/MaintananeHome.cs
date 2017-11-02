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
    public partial class MaintananeHome : Form
    {
        public MaintananeHome()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Laundry La = new Laundry();
            La.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cleaning Cl = new Cleaning();
            Cl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CheckOut CO = new CheckOut();
            CO.Show();
        }

        private void MaintananeHome_Load(object sender, EventArgs e)
        {

        }
    }
}
