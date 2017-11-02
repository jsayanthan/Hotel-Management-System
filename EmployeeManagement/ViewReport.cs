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
    public partial class ViewReport : Form
    {
        public static string paymentid;
        public static string expensestype;
        public SqlConnection con = ConnectionManager.GetConnection();
        string sql;
        string q;
        DateTime now = DateTime.Now;
        public ViewReport()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            sql = "SELECT  PaymentID,ReserveID,EventID,FoodOrderID,BeveOrderID,LaundryID,PoolID,GymID,HireID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date  FROM Payment WHERE Date='" + now.Date + "'";  //check date column
            function.tableload(sql, con, dataGridView1, "Payment");
            q = " SELECT PaymentID,VehMaintID,PayrollID,SupplierPayID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE Date='" + now.Date + "' AND AmountPaid<0";
            function.tableload(q, con, dataGridView2, "Payment");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string check = comboBox1.SelectedItem.ToString();
            if (check.Equals("Room"))
            {
                sql = "SELECT PaymentID,ReserveID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE ReserveID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Event"))
            {
                sql = "SELECT PaymentID,EventID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE EventID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Today"))
            {
                sql = "SELECT  * FROM Payment WHERE Date='" + now.Date + "'";
            }
            else if (check.Equals("All"))
            {
                sql = "SELECT  * FROM Payment WHERE Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Restaurant"))
            {
                sql = "SELECT PaymentID,FoodOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE FoodOrderID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Bar"))
            {
                sql = "SELECT PaymentID,BeveOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE BeveOrderID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Laundary"))
            {
                sql = "SELECT PaymentID,LaundryID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE LaundryID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Pool"))
            {
                sql = "SELECT PaymentID,PoolID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE PoolID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Gym"))
            {
                sql = "SELECT PaymentID,GymID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE GymID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if(check.Equals("Hire"))
            {
                sql = "SELECT PaymentID,HireID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE HireID IS NOT NULL AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            try
            {
                //check date column
                function.tableload(sql, con, dataGridView1, "payment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string check = comboBox1.SelectedItem.ToString();
            if (check.Equals("Room"))
            {
                sql = " SELECT PaymentID,ReserveID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE ReserveID IS NOT NULL AND AmountPaid>0";
            }
            else if (check.Equals("Event"))
            {
                sql = " SELECT PaymentID,EventID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE EventID IS NOT NULL AND AmountPaid>0";
            }
            else if (check.Equals("Today"))
            {
                sql = "SELECT  * FROM Payment WHERE Date='" + now.Date + "'AND AmountPaid>0";
            }
            else if (check.Equals("All"))
            {
                sql = "SELECT  * FROM Payment WHERE AmountPaid>0";
            }
            else if (check.Equals("Restaurant"))
            {
                sql = " SELECT PaymentID,FoodOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE FoodOrderID IS NOT NULL AND AmountPaid>0";
            }
            else if (check.Equals("Bar"))
            {
                sql = " SELECT PaymentID,BeveOrderID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE BeveOrderID IS NOT NULL AND AmountPaid>0";
            }
            else if (check.Equals("Laundry"))
            {
                sql = " SELECT PaymentID,LaundryID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE LaundryID IS NOT NULL AND AmountPaid>0";
            }
            else if (check.Equals("Pool"))
            {
                sql = " SELECT PaymentID,PoolID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE PoolID IS NOT NULL AND AmountPaid>0";
            }
            else if (check.Equals("Gym"))
            {
                sql = " SELECT PaymentID,GymID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE GymID IS NOT NULL AND AmountPaid>0";
            }
            else if(check.Equals("Hire"))
            {
                sql = " SELECT PaymentID,HireID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE HireID IS NOT NULL AND AmountPaid>0";
            }
            try
            {
                  //check date column
                function.tableload(sql, con, dataGridView1, "payment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string check = comboBox2.SelectedItem.ToString();
            if (check.Equals("Payroll"))
            {
                sql = " SELECT PaymentID,PayrollID,TotalAmount,AmountPaid,Balance,date FROM payment WHERE PayrollID IS NOT NULL AND AmountPaid<0";
            }
            else if (check.Equals("Vehicle Maintenance"))
            {
                sql = " SELECT PaymentID,VehMaintID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE VehMaintID IS NOT NULL AND AmountPaid<0";
            }
            if (check.Equals("Purchasing"))
            {
                sql = " SELECT PaymentID,SupplierPayID,TotalAmount,AmountPaid,Balance,date FROM payment WHERE SupplierPayID IS NOT NULL AND AmountPaid<0";
            }
            if (check.Equals("Other"))
            {
                sql = " SELECT PaymentID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE OtherEX IS NOT NULL AND AmountPaid<0";
            }
            if (check.Equals("Today"))
            {
                sql = " SELECT PaymentID,VehMaintID,PayrollID,SupplierPayID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE Date='" + now.Date + "' AND AmountPaid<0";
            }
            if (check.Equals("All"))
            {
                sql = " SELECT PaymentID,VehMaintID,PayrollID,SupplierPayID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE AmountPaid<0 ";
            }

            try
            {
                //check date column
                function.tableload(sql, con, dataGridView2, "payment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string check = comboBox2.SelectedItem.ToString();
            if (check.Equals("Payroll"))
            {
                sql = " SELECT PaymentID,PayrollID,TotalAmount,AmountPaid,Balance,date FROM payment WHERE PayrollID IS NOT NULL AND AmountPaid<0 AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            else if (check.Equals("Vehicle Maintenance"))
            {
                sql = " SELECT PaymentID,VehMaintID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date FROM payment WHERE VehMaintID IS NOT NULL AND AmountPaid<0 AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            if (check.Equals("Purchasing"))
            {
                sql = " SELECT PaymentID,SupplierPayID,TotalAmount,AmountPaid,Balance,date FROM payment WHERE SupplierPayID IS NOT NULL AND AmountPaid<0 AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            if (check.Equals("Other"))
            {
                sql = " SELECT PaymentID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE OtherEX IS NOT NULL AND AmountPaid<0 AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            if (check.Equals("Today"))
            {
                sql = " SELECT PaymentID,VehMaintID,PayrollID,SupplierPayID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE AmountPaid<0 AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }
            if (check.Equals("All"))
            {
                sql = " SELECT PaymentID,VehMaintID,PayrollID,SupplierPayID,OtherEX,TotalAmount,AmountPaid,Balance,date FROM payment WHERE AmountPaid<0 AND Date BETWEEN '" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'";
            }

            try
            {
                //check date column
                function.tableload(sql, con, dataGridView2, "payment");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountHome f = new AccountHome();
            f.Show();
            this.Dispose();
        }
    }
}
