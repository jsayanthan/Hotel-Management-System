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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net.Mail;

namespace EmployeeManagement
{
    public partial class VehicleReservation : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();
        DateTime now = DateTime.Now;
        string placecode;
        string m;
        string customerid;
        string initialAmount;
        string perkm;
        string km;
        string emailid;
        public VehicleReservation()
        {
            InitializeComponent();
        }

        private void MakeReservation_Load(object sender, EventArgs e)
        {
            label11.Text = function.getNextID("hireID", "vehicleReservation", "VR", con);
            function.tableload("SELECT * FROM vehicleReservation WHERE status='unpaid'", con, dataGridView1, "vehicleReservation");
            DataTable dt1 = function.getcomboBox("SELECT place FROM location", con);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["place"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add this hire?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (label8.Text.Equals("No Infomation") || label8.Text.Equals(""))
                {
                    MessageBox.Show("Can Not Make Reservation");
                }
                else
                {
                    if ((comboBox1.SelectedItem == null) || (comboBox2.SelectedItem == null) || (comboBox3.SelectedItem == null) || (comboBox4.SelectedItem == null))
                    {
                        MessageBox.Show("Please Fill The Combobox");
                    }
                    else
                    {
                        DataTable dt = function.getcomboBox("SELECT time,placeCode FROM location WHERE place='" + comboBox1.SelectedItem.ToString() + "' ", con);
                        foreach (DataRow dr in dt.Rows)
                        {
                            m = dr["time"].ToString();
                            placecode = dr["placeCode"].ToString();
                        }
                        int min = int.Parse(m);
                        string h = "INSERT INTO vehicleReservation(hireId,vehicleNumber,customerID,roomID,startDate,endDate,location,status) VALUES('" + label11.Text + "','" + comboBox4.SelectedItem.ToString() + "','" + customerid + "','" + textBox1.Text + "','" + this.dateTimePicker1.Text + "','" + dateTimePicker1.Value.AddMinutes(min) + "','" + placecode.ToString() + "','unpaid' )";
                        Debug.WriteLine(h);
                        function.executesqlquerey("INSERT INTO vehicleReservation(hireId,vehicleNumber,customerID,roomID,startDate,endDate,location,status) VALUES('" + label11.Text + "','" + comboBox4.SelectedItem.ToString() + "','" + customerid + "','" + textBox1.Text + "','" + this.dateTimePicker1.Text + "','" + dateTimePicker1.Value.AddMinutes(min) + "','" + placecode.ToString() + "','unpaid' )", con);
                        //string sql = "INSERT INTO Payment (PaymentID,HireID,TotalAmount,AmountPaid,Discount,NetAmount,Balance,date)values ('"+Functions.getNextID("PaymentID","payment","PA",con) +"','"+label11.Text+"','"+label12.Text+ "',0,0,'" + label12.Text + "','" + label12.Text + "','"+now.Date+"')  ";
                        //Debug.WriteLine(sql);
                        //Functions.executesqlquerey(sql, con);
                        label11.Text = function.getNextID("hireID", "vehicleReservation", "VR", con);
                        function.tableload("SELECT * FROM vehicleReservation WHERE status='unpaid'", con, dataGridView1, "vehicleReservation");
                        MessageBox.Show("Reserved Succesfull!");

                        string data = @"     HOTEL JHONE MERRY 

                            Vehicle Reservation Success  
                                                                  
                                                                
                                                               MANAGER.";


                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("alan94walker@gmail.com");
                            mail.To.Add(email.Text);
                            mail.Subject = "Vehicle Reservation Confirmation";
                            mail.Body = data.ToString();

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("alan94walker@gmail.com", "1250Chammakchallo");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        comboBox4.Text = "";
                        

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this hire?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                function.executesqlquerey("DELETE FROM vehicleReservation WHERE hireID='" + label11.Text + "'", con);
                function.tableload("SELECT * FROM vehicleReservation WHERE status='unpaid'", con, dataGridView1, "vehicleReservation");
                label11.Text = function.getNextID("hireID", "vehicleReservation", "VR", con);
                MessageBox.Show("Succes!");
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            if (index>-1)
            {
                string qry = "SELECT C.FirstName, C.LastName FROM vehicleReservation R,Customer C WHERE R.hireID='" + selectedRow.Cells[0].Value.ToString() + "'AND C.CustID=R.customerID";
                label11.Text = selectedRow.Cells[0].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString();
                textBox1.Text = selectedRow.Cells[3].Value.ToString();
                DataTable t=function.getcomboBox(qry,con);
                Debug.WriteLine(qry);
                foreach (DataRow dr in t.Rows)
                {
                    label8.Text = dr["FirstName"].ToString();
                    label13.Text = dr["LastName"].ToString();
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = function.getcomboBox("SELECT time FROM location WHERE place='" + comboBox1.SelectedItem.ToString() + "' ", con);
            foreach (DataRow dr in d.Rows)
            {
                m = dr["time"].ToString();
            }
            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null)
            {

            }
            else
            {
                comboBox4.Items.Clear();
                string query = "SELECT v.vehicleNumber FROM vehicle AS v LEFT JOIN(SELECT r.vehicleNumber FROM vehicleReservation AS r WHERE r.enddate >='" + dateTimePicker1.Value + "'  AND r.startdate <= '" + dateTimePicker1.Value.AddMinutes(int.Parse(m)) + "')  AS r ON v.vehicleNumber = r.vehicleNumber WHERE r.vehicleNumber IS NULL AND v.category = '" + comboBox3.SelectedItem.ToString() + "' AND v.status = 'Available' AND vehicleType='"+comboBox2.SelectedItem.ToString()+"'";
                Debug.WriteLine(query);
                DataTable dt = function.getcomboBox(query, con);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox4.Items.Add(dr["vehicleNumber"].ToString());
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = function.getcomboBox("SELECT time FROM location WHERE place='" + comboBox1.SelectedItem.ToString() + "' ", con);
            foreach (DataRow dr in d.Rows)
            {
                m = dr["time"].ToString();
            }
            if (comboBox1.SelectedItem == null || comboBox3.SelectedItem == null)
            {

            }
            else
            {
                comboBox4.Items.Clear();
                string query = "SELECT v.vehicleNumber FROM vehicle AS v LEFT JOIN(SELECT r.vehicleNumber FROM vehicleReservation AS r WHERE r.enddate >='" + dateTimePicker1.Value + "'  AND r.startdate <= '" + dateTimePicker1.Value.AddMinutes(int.Parse(m)) + "')  AS r ON v.vehicleNumber = r.vehicleNumber WHERE r.vehicleNumber IS NULL AND v.category = '" + comboBox3.SelectedItem.ToString() + "' AND v.status = 'Available' AND vehicleType='" + comboBox2.SelectedItem.ToString() + "'";
                Debug.WriteLine(query);
                DataTable dt = function.getcomboBox(query, con);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox4.Items.Add(dr["vehicleNumber"].ToString());
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = function.getcomboBox("SELECT time FROM location WHERE place='" + comboBox1.SelectedItem.ToString() + "' ", con);
            foreach (DataRow dr in d.Rows)
            {
                m = dr["time"].ToString();
            }
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {

            }
            else
            {
                comboBox4.Items.Clear();
                string query = "SELECT v.vehicleNumber FROM vehicle AS v LEFT JOIN(SELECT r.vehicleNumber FROM vehicleReservation AS r WHERE r.enddate >='" + dateTimePicker1.Value + "'  AND r.startdate <= '" + dateTimePicker1.Value.AddMinutes(int.Parse(m)) + "')  AS r ON v.vehicleNumber = r.vehicleNumber WHERE r.vehicleNumber IS NULL AND v.category = '" + comboBox3.SelectedItem.ToString() + "' AND v.status = 'Available' AND vehicleType='" + comboBox2.SelectedItem.ToString() + "'";
                Debug.WriteLine(query);
                DataTable dt = function.getcomboBox(query, con);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox4.Items.Add(dr["vehicleNumber"].ToString());
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == null)
            {

            }
            else
            {
                string query = "SELECT DISTINCT C.CustID,C.FirstName,C.LastName,c.email FROM Customer C, RoomReservation RO, ReservedRooms R, Room WHERE R.ReservationID=Ro.ReservationID AND Ro.CustID=C.CustID AND R.CheckIN <='" + dateTimePicker1.Value + "'AND R.CheckOut>='" + dateTimePicker1.Value + "' AND R.RoomID='" + textBox1.Text + "'AND Room.RoomID=R.RoomID AND room.status='RESERVED'";
                Debug.WriteLine(query);
                DataTable dt = function.getcomboBox(query, con);
                if (function.hasData(query, con))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        label8.ForeColor = System.Drawing.Color.Green;
                        label13.ForeColor = System.Drawing.Color.Green;
                        label8.Text = dr["FirstName"].ToString();
                        label13.Text = dr["LastName"].ToString();
                        customerid = dr["CustID"].ToString();
                        email.Text = dr["email"].ToString();
                    }
                }
                else
                {
                    label8.ForeColor = System.Drawing.Color.Red;
                    label13.ForeColor = System.Drawing.Color.Red;
                    label8.Text = "No Infomation";
                    label13.Text = "";
                    email.Text = "";
                }
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                Debug.WriteLine("Good");
            }
            else
            {
                string query = "SELECT DISTINCT C.CustID,C.FirstName, C.LastName,c.email FROM Customer C, RoomReservation RO, ReservedRooms R, Room WHERE R.ReservationID=Ro.ReservationID AND Ro.CustID=C.CustID AND R.CheckIN <='" + dateTimePicker1.Value + "'AND R.CheckOut>='" + dateTimePicker1.Value + "' AND R.RoomID='" + textBox1.Text + "'AND Room.RoomID=R.RoomID AND room.status='RESERVED'";
                DataTable dt = function.getcomboBox(query, con);
                if (function.hasData(query, con))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        label8.ForeColor = System.Drawing.Color.Green;
                        label13.ForeColor = System.Drawing.Color.Green;
                        label8.Text = dr["FirstName"].ToString();
                        label13.Text = dr["LastName"].ToString();
                        customerid = dr["CustID"].ToString();
                        email.Text = dr["email"].ToString();
                    }
                }
                else
                {
                    label8.ForeColor = System.Drawing.Color.Red;
                    label13.ForeColor = System.Drawing.Color.Red;
                    label8.Text = "No Infomation";
                    label13.Text = "";
                    email.Text = "";
                }
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update this hire?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((comboBox1.SelectedItem == null) || (comboBox2.SelectedItem == null) || (comboBox3.SelectedItem == null) || (comboBox4.SelectedItem == null))
                {
                    MessageBox.Show("Please Fill The Combobox");
                }
                else
                {
                    DataTable d = function.getcomboBox("SELECT time FROM location WHERE place='" + comboBox1.SelectedItem.ToString() + "' ", con);
                    foreach (DataRow dr in d.Rows)
                    {
                        m = dr["time"].ToString();
                    }

                    DataTable c = function.getcomboBox("SELECT customerID FROM vehicleReservation WHERE hireID='" + label13.Text + "'", con);
                    foreach (DataRow dr in c.Rows)
                    {
                        customerid = dr["customerID"].ToString();
                    }
                    DataTable dt = function.getcomboBox("SELECT time,placeCode FROM location WHERE place='" + comboBox1.SelectedItem.ToString() + "' ", con);
                    foreach (DataRow dr in dt.Rows)
                    {
                        placecode = dr["placeCode"].ToString();
                    }
                    int min = int.Parse(m);
                    string qry = "UPDATE vehicleReservation SET vehicleNumber='" + comboBox4.SelectedItem.ToString() + "',location='" + placecode + "',startDate='" + dateTimePicker1.Value.ToString() + "',endDate='" + dateTimePicker1.Value.AddMinutes(min).ToString() + "' WHERE hireID='" + label11.Text + "'";
                    Debug.WriteLine(qry);
                    function.executesqlquerey(qry, con);
                    //string sql = "UPDATE payment SET TotalAmount='"+label12.Text+"',NetAmount='"+ label12.Text+"',Balance='"+ label12.Text+"',date='"+now.Date+ "' WHERE HireID='"+label11.Text+"' ";
                    //Debug.WriteLine(sql);
                    //Functions.executesqlquerey(sql, con);
                    function.tableload("SELECT * FROM vehicleReservation WHERE status='unpaid'", con, dataGridView1, "vehicleReservation");
                    MessageBox.Show("Succes!");

                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string qry = "select initialAmount,amountPerkm from vehicle where vehicle number='"+comboBox4.SelectedItem.ToString()+"'";
            //Functions.getcomboBox(qry, con);

            if (textBox1.Text == null)
            {
                Debug.WriteLine("Good");
            }
            else
            {
                string query = "SELECT initialAmount,amountPerkm from vehicle WHERE vehiclenumber='" + comboBox4.SelectedItem.ToString() + "'";
                Debug.WriteLine(query);
                DataTable dt = function.getcomboBox(query, con);
                if (function.hasData(query, con))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        initialAmount = dr["initialAmount"].ToString();
                        perkm= dr["amountPerkm"].ToString();
                    }

                }
                string q = "SELECT km from location WHERE place='"+comboBox1.SelectedItem.ToString()+"'";
                Debug.WriteLine(q);
                DataTable d = function.getcomboBox(q, con);
                if (function.hasData(q, con))
                {
                    foreach (DataRow dr in d.Rows)
                    {

                        km = (dr["km"]).ToString();
                        Debug.WriteLine(km);
                        float ia = float.Parse(initialAmount);
                        float pk = float.Parse(perkm);
                        float KM = float.Parse(km);
                        float tot = ia + (KM - 1) * pk;
                        label12.Text = tot.ToString();

                    }

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VehiclesHome h = new VehiclesHome();
            h.Show();
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vehiclecrystal v = new vehiclecrystal();
            v.Show();
        }
    }
}
