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
    public partial class AccountHome : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();
        DateTime now = DateTime.Now;
        public AccountHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OtherExpences expenses_form = new OtherExpences();
            expenses_form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OtherExpences petty_cash = new OtherExpences();
            petty_cash.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Summary summary = new Summary();
            summary.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewReport View_report = new ViewReport();
            View_report.Show();
            this.Hide();

        }

        private void Form1_Load(object sender,EventArgs e)
        {
            label15.Text = now.Date.ToString();
            function.labelLoad("SELECT SUM(NetAmount)AS Total from Payment WHERE NetAmount>0 AND date='"+now.Date+"'","Total",total,con);
            function.labelLoad("SELECT SUM(NetAmount)AS Total from Payment WHERE NetAmount<0 AND date='" + now.Date + "'", "Total", exp, con);
            pro.Text = (float.Parse(total.Text) + float.Parse(exp.Text)).ToString();

            function.labelLoad("SELECT SUM(NetAmount)AS Total from Payment WHERE NetAmount>0 AND date BETWEEN'" + now.Date + "' AND '"+now.Date.AddDays(-30)+"'", "Total", label12, con);
            function.labelLoad("SELECT SUM(NetAmount)AS Total from Payment WHERE NetAmount>0 AND date BETWEEN'" + now.Date + "' AND '" + now.Date.AddDays(-30) + "'", "Total", label13, con);
            label14.Text = (float.Parse(label12.Text) + float.Parse(label13.Text)).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerSummary f = new CustomerSummary();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chart ch = new Chart();
            ch.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }
    }
}
