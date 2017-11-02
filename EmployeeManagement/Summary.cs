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
using System.Diagnostics;

namespace EmployeeManagement
{
    public partial class Summary : Form
    {
        DateTime now = DateTime.Now;
        public SqlConnection con = ConnectionManager.GetConnection();
        public Summary()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //TotalAMount 
            function.labelLoad("select SUM(Total) AS total from ReservedRooms WHERE Checkout='"+now.Date+"'", "total",troom,con);
            function.labelLoad("Select SUM(NetAmount) AS total from Payment Where EventID IS NOT NULL AND date='"+now.Date+"'", "total", thall, con);
            function.labelLoad("select sum(fo.Quantity * fd.UnitPrice) AS Total from FoodOrder fo inner join Food fd on fd.FoodID = fo.FoodID inner join Orders o on o.OrderID=fo.OrderID where o.orderedTime='"+now.Date+"'", "total", tfood, con);
            function.labelLoad("select sum(b.Quantity * ab.price) AS total from BeverageOrders b inner join AvailableBeverage ab on b.BeverageID = ab.BeverageID AND ab.size = b.size inner Join Orders o on o.OrderID = b.OrderID Where o.orderedTime = '"+now.Date+"'", "total", tbar, con);
            function.labelLoad("select SUM(UnitPrice) AS total from Laundry AS total WHERE DeliverDate='"+now.Date+"'", "total", tlaundry, con);
            function.labelLoad("select SUM(Hours)*250 AS total from PoolGame WHERE dayTime='"+now.Date+"'", "total", tpool, con);
            function.labelLoad("select SUM(Hours*150) AS total from Gym WHERE dayTime='"+now.Date+"'", "total", tgym, con);
            function.labelLoad("select SUM(((km-1)*v.amountPerkm)+ v.initialAmount) AS total from VehicleReservation vr,vehicle v,location l where vr.vehicleNumber = v.vehicleNumber AND vr.location = l.PlaceCode AND vr.endDate='"+now.Date+"'", "total", thire, con);

            //AmountPaid
            function.labelLoad("select sum(AmountPaid) AS total from Payment where ReserveID IS NOT NULL AND date='"+now.Date+"'", "total", proom, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where EventID IS NOT NULL AND date='" + now.Date + "'", "total", pevent, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where FoodOrderID IS NOT NULL AND date='" + now.Date + "'", "total", pfood, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where BeveOrderID IS NOT NULL AND date='" + now.Date + "'", "total", pbar, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where LaundryID IS NOT NULL AND date='" + now.Date + "'", "total", plaundry, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where PayrollID IS NOT NULL AND date='" + now.Date + "'", "total", ppool, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where GymID IS NOT NULL AND date='" + now.Date + "'", "total", pgym, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where HireID IS NOT NULL AND date='" + now.Date + "'", "total", phire, con);

            //Discount
            function.labelLoad("select sum(Discount) AS total from Payment where ReserveID IS NOT NULL AND date='" + now.Date + "'", "total", droom, con);
            function.labelLoad("select sum(Discount) AS total from Payment where EventID IS NOT NULL AND date='" + now.Date + "'", "total", devent, con);
            function.labelLoad("select sum(Discount) AS total from Payment where FoodOrderID IS NOT NULL AND date='" + now.Date + "'", "total", dfood, con);
            function.labelLoad("select sum(Discount) AS total from Payment where BeveOrderID IS NOT NULL AND date='" + now.Date + "'", "total", dbar, con);
            function.labelLoad("select sum(Discount) AS total from Payment where LaundryID IS NOT NULL AND date='" + now.Date + "'", "total", dlaundry, con);
            function.labelLoad("select sum(Discount) AS total from Payment where PayrollID IS NOT NULL AND date='" + now.Date + "'", "total", dpool, con);
            function.labelLoad("select sum(Discount) AS total from Payment where GymID IS NOT NULL AND date='" + now.Date + "'", "total", dgym, con);
            function.labelLoad("select sum(Discount) AS total from Payment where HireID IS NOT NULL AND date='" + now.Date + "'", "total", dhire, con);


            //NetAmount
            function.labelLoad("select sum(NetAmount) AS total from Payment where ReserveID IS NOT NULL AND date='" + now.Date + "'", "total", nroom, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where EventID IS NOT NULL AND date='" + now.Date + "'", "total", nevent, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where FoodOrderID IS NOT NULL AND date='" + now.Date + "'", "total", nfood, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where BeveOrderID IS NOT NULL AND date='" + now.Date + "'", "total", nbar, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where LaundryID IS NOT NULL AND date='" + now.Date + "'", "total", nlaundry, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where PayrollID IS NOT NULL AND date='" + now.Date + "'", "total", npool, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where GymID IS NOT NULL AND date='" + now.Date + "'", "total", ngym, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where HireID IS NOT NULL AND date='" + now.Date + "'", "total", nhire, con);


            //Expenses
            function.labelLoad("select sum(NetAmount) AS total from Payment where PayrollID IS NOT NULL AND date='" + now.Date + "'", "total", payrollAmount, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where OtherEx IS NOT NULL AND date='" + now.Date + "'", "total", otherAmount, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where SupplierPayID IS NOT NULL AND date='" + now.Date + "'", "total", supAmount, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where VehMaintID IS NOT NULL AND date='" + now.Date + "'", "total", vehicleAmount, con);

            float expenses = float.Parse(payrollAmount.Text) + float.Parse(otherAmount.Text) + float.Parse(supAmount.Text) + float.Parse(vehicleAmount.Text);
            texpenses.Text = expenses.ToString();

            float NetAmount = float.Parse(nroom.Text) + float.Parse(nevent.Text) + float.Parse(nfood.Text) + float.Parse(nbar.Text) + float.Parse(nlaundry.Text) + float.Parse(npool.Text) + float.Parse(ngym.Text) + float.Parse(dhire.Text);
            namount.Text = NetAmount.ToString();

            float totalAmount = float.Parse(troom.Text) + float.Parse(thall.Text) + float.Parse(tbar.Text) + float.Parse(tfood.Text) + float.Parse(tlaundry.Text) + float.Parse(tpool.Text) + float.Parse(tgym.Text) + float.Parse(thire.Text);
            tamount.Text = totalAmount.ToString();

            float totalPaid = float.Parse(proom.Text) + float.Parse(pevent.Text) + float.Parse(pbar.Text) + float.Parse(pfood.Text) + float.Parse(plaundry.Text) + float.Parse(ppool.Text) + float.Parse(pgym.Text) + float.Parse(phire.Text);
            pamount.Text = totalPaid.ToString();

            float totaldiscount = float.Parse(droom.Text) + float.Parse(devent.Text) + float.Parse(dfood.Text) + float.Parse(dbar.Text) + float.Parse(dlaundry.Text) + float.Parse(dpool.Text) + float.Parse(dgym.Text) + float.Parse(dhire.Text);
            tdiscount.Text = totaldiscount.ToString();

            float balance = totalAmount - (totalPaid + totaldiscount);
             tbalance.Text = balance.ToString();

            float roombal = float.Parse(troom.Text) - (float.Parse(proom.Text)+ float.Parse(droom.Text));
            broom.Text = roombal.ToString();

            float eventbal = float.Parse(thall.Text) - (float.Parse(pevent.Text) + float.Parse(devent.Text));
            bevent.Text = eventbal.ToString();

            float foodbal = float.Parse(tfood.Text) - (float.Parse(pfood.Text) + float.Parse(dfood.Text));
            bfood.Text = foodbal.ToString();

            float barbal = float.Parse(tbar.Text) - (float.Parse(pbar.Text) + float.Parse(dbar.Text));
            bbar.Text = barbal.ToString();

            float launbal = float.Parse(tlaundry.Text) - (float.Parse(plaundry.Text) + float.Parse(dlaundry.Text));
            blaundry.Text = launbal.ToString();

            float poolbal = float.Parse(tpool.Text) - (float.Parse(ppool.Text) + float.Parse(dpool.Text));
            bpool.Text = poolbal.ToString();

            float gymbal = float.Parse(tgym.Text) - (float.Parse(pgym.Text) + float.Parse(dgym.Text));
            bgym.Text = gymbal.ToString();

            float hirebal = float.Parse(thire.Text) - (float.Parse(phire.Text) + float.Parse(dhire.Text));
            bhire.Text = hirebal.ToString();

            float pro = NetAmount + expenses;

            if (pro > 0)
            {
                profit.ForeColor = System.Drawing.Color.Green;
                profit.Text = pro.ToString();
            }
            else
            {
                profit.ForeColor = System.Drawing.Color.Red;
                profit.Text = pro.ToString();
            }
        }

       public static void EachTotalAmountOfIncome(string qry,Label net,Label paid, Label bal,SqlConnection con)
        {
            float sumPaidamount = 0;
            float paidamount;
            float sumBalance = 0;
            float Balance;
            float sumNetamount = 0;
            float netamount;
            try
            {
                String sql = qry;
                con.Open();
                SqlDataAdapter load = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                load.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach(DataRow dr in dt.Rows)
                {
                    if (dr["AmountPaid"].ToString()!="")
                    {
                        netamount = float.Parse(dr["NetAmount"].ToString());
                        sumNetamount = sumNetamount + netamount;
                        paidamount = float.Parse(dr["AmountPaid"].ToString());
                        sumPaidamount = sumPaidamount + paidamount;
                        Balance = float.Parse(dr["Balance"].ToString());
                        sumBalance = sumBalance + Balance;

                    }
                    else
                    {
                        double empty1 = 0;
                        net.Text = empty1.ToString();
                        double empty2 = 0;
                        paid.Text = empty2.ToString();
                        double empty3 = 0;
                        bal.Text = empty3.ToString();
                    }
                }
                net.Text = sumNetamount.ToString();
                paid.Text = sumPaidamount.ToString();
                bal.Text = sumBalance.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            string picker1 = this.dateTimePicker1.Text;
            string picker2 = this.dateTimePicker1.Text;

            //TotalAmount
            function.labelLoad("select SUM(Total) AS total from ReservedRooms WHERE Checkout BETWEEN'" + this.dateTimePicker1.Text + "' AND '"+ this.dateTimePicker2.Text + "'", "total", troom, con);
            function.labelLoad("Select SUM(NetAmount) AS total from Payment Where EventID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", thall, con);
            function.labelLoad("select sum(fo.Quantity * fd.UnitPrice) AS Total from FoodOrder fo inner join Food fd on fd.FoodID = fo.FoodID inner join Orders o on o.OrderID=fo.OrderID where o.orderedTime BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", tfood, con);
            function.labelLoad("select sum(b.Quantity * ab.price) AS total from BeverageOrders b inner join AvailableBeverage ab on b.BeverageID = ab.BeverageID AND ab.size = b.size inner Join Orders o on o.OrderID = b.OrderID Where o.orderedTime BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", tbar, con);
            function.labelLoad("select SUM(UnitPrice) AS total from Laundry AS total WHERE DeliverDate BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", tlaundry, con);
            function.labelLoad("select SUM(Hours)*250 AS total from PoolGame WHERE dayTime BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", tpool, con);
            function.labelLoad("select SUM(Hours*150) AS total from Gym WHERE dayTime BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", tgym, con);
            function.labelLoad("select SUM(((km-1)*v.amountPerkm)+ v.initialAmount) AS total from VehicleReservation vr,vehicle v,location l where vr.vehicleNumber = v.vehicleNumber AND vr.location = l.PlaceCode AND vr.endDate BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", thire, con);

            //PaidAmount
            function.labelLoad("select sum(AmountPaid) AS total from Payment where ReserveID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", proom, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where EventID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", pevent, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where FoodOrderID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", pfood, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where BeveOrderID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", pbar, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where LaundryID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", plaundry, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where PayrollID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", ppool, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where GymID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", pgym, con);
            function.labelLoad("select sum(AmountPaid) AS total from Payment where HireID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", phire, con);


            function.labelLoad("select sum(Discount) AS total from Payment where ReserveID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", droom, con);
            function.labelLoad("select sum(Discount) AS total from Payment where EventID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", devent, con);
            function.labelLoad("select sum(Discount) AS total from Payment where FoodOrderID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", dfood, con);
            function.labelLoad("select sum(Discount) AS total from Payment where BeveOrderID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", dbar, con);
            function.labelLoad("select sum(Discount) AS total from Payment where LaundryID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", dlaundry, con);
            function.labelLoad("select sum(Discount) AS total from Payment where PayrollID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", dpool, con);
            function.labelLoad("select sum(Discount) AS total from Payment where GymID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", dgym, con);
            function.labelLoad("select sum(Discount) AS total from Payment where HireID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", dhire, con);



            function.labelLoad("select sum(NetAmount) AS total from Payment where ReserveID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", nroom, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where EventID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", nevent, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where FoodOrderID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", nfood, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where BeveOrderID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", nbar, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where LaundryID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", nlaundry, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where PayrollID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", npool, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where GymID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", ngym, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where HireID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", nhire, con);

            //Expenses
            function.labelLoad("select sum(NetAmount) AS total from Payment where PayrollID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", payrollAmount, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where OtherEx IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", otherAmount, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where SupplierPayID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", supAmount, con);
            function.labelLoad("select sum(NetAmount) AS total from Payment where VehMaintID IS NOT NULL AND date BETWEEN'" + this.dateTimePicker1.Text + "' AND '" + this.dateTimePicker2.Text + "'", "total", vehicleAmount, con);

            float expenses = float.Parse(payrollAmount.Text) + float.Parse(otherAmount.Text) + float.Parse(supAmount.Text) + float.Parse(vehicleAmount.Text);
            texpenses.Text = expenses.ToString();


            float NetAmount = float.Parse(nroom.Text) + float.Parse(nevent.Text) + float.Parse(nfood.Text) + float.Parse(nbar.Text) + float.Parse(nlaundry.Text) + float.Parse(npool.Text) + float.Parse(ngym.Text) + float.Parse(dhire.Text);
            namount.Text = NetAmount.ToString();

            float totalAmount = float.Parse(troom.Text) + float.Parse(thall.Text) + float.Parse(tbar.Text) + float.Parse(tfood.Text) + float.Parse(tlaundry.Text) + float.Parse(tpool.Text) + float.Parse(tgym.Text) + float.Parse(thire.Text);
            tamount.Text = totalAmount.ToString();

            float totalPaid = float.Parse(proom.Text) + float.Parse(pevent.Text) + float.Parse(pbar.Text) + float.Parse(pfood.Text) + float.Parse(plaundry.Text) + float.Parse(ppool.Text) + float.Parse(pgym.Text) + float.Parse(phire.Text);
            pamount.Text = totalPaid.ToString();

            float totaldiscount = float.Parse(droom.Text) + float.Parse(devent.Text) + float.Parse(dfood.Text) + float.Parse(dbar.Text) + float.Parse(dlaundry.Text) + float.Parse(dpool.Text) + float.Parse(dgym.Text) + float.Parse(dhire.Text);
            tdiscount.Text = totaldiscount.ToString();

            float balance = totalAmount - (totalPaid + totaldiscount);
            tbalance.Text = balance.ToString();

            float roombal = float.Parse(troom.Text) - (float.Parse(proom.Text) + float.Parse(droom.Text));
            broom.Text = roombal.ToString();

            float eventbal = float.Parse(thall.Text) - (float.Parse(pevent.Text) + float.Parse(devent.Text));
            bevent.Text = eventbal.ToString();

            float foodbal = float.Parse(tfood.Text) - (float.Parse(pfood.Text) + float.Parse(dfood.Text));
            bfood.Text = foodbal.ToString();

            float barbal = float.Parse(tbar.Text) - (float.Parse(pbar.Text) + float.Parse(dbar.Text));
            bbar.Text = barbal.ToString();

            float launbal = float.Parse(tlaundry.Text) - (float.Parse(plaundry.Text) + float.Parse(dlaundry.Text));
            blaundry.Text = launbal.ToString();

            float poolbal = float.Parse(tpool.Text) - (float.Parse(ppool.Text) + float.Parse(dpool.Text));
            bpool.Text = poolbal.ToString();

            float gymbal = float.Parse(tgym.Text) - (float.Parse(pgym.Text) + float.Parse(dgym.Text));
            bgym.Text = gymbal.ToString();

            float hirebal = float.Parse(thire.Text) - (float.Parse(phire.Text) + float.Parse(dhire.Text));
            bhire.Text = hirebal.ToString();

            float pro = NetAmount + expenses;
            

            if(pro>0)
            {
                profit.ForeColor = System.Drawing.Color.Green;
                profit.Text = pro.ToString();
            }
            else
            {
                profit.ForeColor = System.Drawing.Color.Red;
                profit.Text = pro.ToString();
            }
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountHome f = new AccountHome();
            f.Show();
            this.Dispose();
        }
    }
}
