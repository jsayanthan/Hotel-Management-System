using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    public partial class Chart : Form
    {
        DateTime now = DateTime.Now;
        string room;
        string events;
        string food;
        string bar;
        string laundory;
        string poolgame;
        string gym;
        string hire;
        string vmain;
        string other;
        string payroll;
        string sup;
        public SqlConnection con = ConnectionManager.GetConnection();
        public Chart()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Chart_Load(object sender, EventArgs e)
        {
            DataTable dt1 = function.getinfo("select SUM(NetAmount) AS Total from Payment Where ReserveID is NOT NULL", con);
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    room = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    room = empty1.ToString();
                }
            }

            //DataTable dt =Functions.labelLoad("select SUM(Total) AS total from ReservedRooms WHERE Checkout='" + now.Date + "'", "total", room, con);
            DataTable dt2 = function.getinfo("select SUM(NetAmount) AS Total from Payment Where EventID is NOT NULL", con);
            foreach (DataRow dr in dt2.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    events = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    events = empty1.ToString();
                }
            }
            DataTable dt3 = function.getinfo("select SUM(NetAmount) AS Total from Payment Where FoodOrderID is NOT NULL", con);
            foreach (DataRow dr in dt3.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    food = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    food = empty1.ToString();
                }
            }
            DataTable dt4 = function.getinfo("select SUM(NetAmount) AS Total from Payment Where BeveOrderID is NOT NULL", con);
            foreach (DataRow dr in dt4.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    bar = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    bar = empty1.ToString();
                }
            }
            DataTable dt5 = function.getinfo("select SUM(NetAmount) AS total from Payment Where LaundryID is NOT NULL", con);
            foreach (DataRow dr in dt5.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    laundory = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    laundory = empty1.ToString();
                }
            }
            DataTable dt6 = function.getinfo("select SUM(NetAmount) AS total from Payment Where PoolID is NOT NULL", con);
            foreach (DataRow dr in dt6.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    poolgame = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    poolgame = empty1.ToString();
                }
            }
            DataTable dt7 = function.getinfo("select SUM(NetAmount) AS Total from Payment Where GymID is NOT NULL", con);
            foreach (DataRow dr in dt7.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    gym = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    gym = empty1.ToString();
                }
            }
            DataTable dt8 = function.getinfo("select SUM(NetAmount) AS Total from Payment Where HireID is NOT NULL", con);
            foreach (DataRow dr in dt8.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    hire = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    hire = empty1.ToString();
                }
            }
            float r = float.Parse(room);
            int et = int.Parse(events);
            int f = int.Parse(food);
            float b = float.Parse(bar);
            float l = float.Parse(laundory);
            float p = float.Parse(poolgame);
            float g = float.Parse(gym);
            float h = float.Parse(hire);

            this.chart1.Series["PAYMENT"].Points.AddXY("ROOM", r);
            this.chart1.Series["PAYMENT"].Points.AddXY("EVENT", et);
            this.chart1.Series["PAYMENT"].Points.AddXY("FOOD", f);
            this.chart1.Series["PAYMENT"].Points.AddXY("BAR", b);
            this.chart1.Series["PAYMENT"].Points.AddXY("LAUNDRY", l);
            this.chart1.Series["PAYMENT"].Points.AddXY("POOLGAME", p);
            this.chart1.Series["PAYMENT"].Points.AddXY("GYM", g);
            this.chart1.Series["PAYMENT"].Points.AddXY("HIRE", h);


            //expenses
            DataTable e1 = function.getinfo("select SUM(NetAmount) AS total from Payment Where VehMaintID iS not null", con);
            foreach (DataRow dr in e1.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    vmain = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    vmain = empty1.ToString();
                }
            }

            DataTable e2 = function.getinfo("Select SUM(NetAmount)as Total from Payment where PayrollID is not null", con);
            foreach (DataRow dr in e2.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    payroll = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    payroll = empty1.ToString();
                }
            }

            DataTable e3 = function.getinfo("select SUM(NetAmount)as Total from Payment WHere OtherEx Is not null", con);
            foreach (DataRow dr in e3.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    other = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    other = empty1.ToString();
                }
            }

            DataTable e4 = function.getinfo("Select SUM(NetAmount) AS total from Payment WHERE SupplierPayID is not null", con);
            foreach (DataRow dr in e4.Rows)
            {
                if (dr["Total"].ToString() != "")
                {
                    sup = dr["Total"].ToString();
                }
                else
                {
                    double empty1 = 0;
                    sup = empty1.ToString();
                }
            }

            float v = float.Parse(vmain);
            int po = int.Parse(payroll);
            int o = int.Parse(other);
            float su = float.Parse(sup);

            this.chart2.Series["EXP"].Points.AddXY("VEHICLE", v);
            this.chart2.Series["EXP"].Points.AddXY("PAYROLL", po);
            this.chart2.Series["EXP"].Points.AddXY("OTHER", o);
            this.chart2.Series["EXP"].Points.AddXY("SUPPLIER ", su);
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            AccountHome ah = new AccountHome();
            ah.Show();
            this.Hide();
        }
    }
}
