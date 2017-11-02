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
    public partial class Front : Form
    {
       
        public Front()
        {
            
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
     
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void Front_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomReservation rr = new RoomReservation();
            rr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageRoomReservation rs = new ManageRoomReservation();
            rs.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Add_Room ad = new Add_Room();
            ad.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Extraroom ex = new Extraroom();
            ex.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckOut c = new CheckOut();
            c.Show();
            this.Hide();
        }
    }
}
