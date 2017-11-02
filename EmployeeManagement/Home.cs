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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update u1 = new Update();
            u1.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Submit s1 = new Submit();
            s1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Close();
        }
    }
}
