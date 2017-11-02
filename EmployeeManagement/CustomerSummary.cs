using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeManagement
{
    public partial class CustomerSummary : Form
    {
        public SqlConnection con = ConnectionManager.GetConnection();

        public CustomerSummary()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string custinfo = "SELECT * FROM Customer WHERE CustID='" + textBox1.Text + "'";
            if (function.hasData(custinfo, con))
            {
                panel1.Visible = true;
                DataTable dt = function.getinfo(custinfo, con);
                foreach (DataRow dr in dt.Rows)
                {
                    label19.Text = dr["FirstName"].ToString();
                    label18.Text = dr["LastName"].ToString();
                    label17.Text = dr["NIC_OR_Passport"].ToString();
                    label16.Text = dr["Email"].ToString();
                    label15.Text = dr["Phone"].ToString();
                    label14.Text = dr["Address"].ToString();
                    label13.Text = dr["PostalCode"].ToString();
                    label12.Text = dr["Country"].ToString();
                    label21.Text = dr["Status"].ToString();

                }
                //total amount
                function.labelLoad("select SUM(rd.Total) AS total from ReservedRooms rd,RoomReservation rn WHERE rn.ReservationID=rd.ReservationID AND rn.CustID='" + textBox1.Text + "'", "Total", troomAmount, con);
                function.labelLoad(" select SUM(TotalAmount) AS total from payment p, Events e where p.EventID=E.EventID AND e.custID='" + textBox1.Text + "'", "Total", thallAmount, con);
                function.labelLoad(" select sum(fo.Quantity * fd.UnitPrice)AS Total from FoodOrder fo inner join Food fd on fd.FoodID = fo.FoodID inner join Orders o on o.OrderID=fo.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID WHERE rn.CustID='" + textBox1.Text + "'", "Total", tfoodAmount, con);
                function.labelLoad("select sum(b.Quantity * ab.price) AS total from BeverageOrders b inner join AvailableBeverage ab on b.BeverageID = ab.BeverageID and ab.size = b.size inner join Orders o on o.OrderID=b.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID WHERE rn.CustID='" + textBox1.Text + "'", "Total", tbarAmount, con);
                function.labelLoad("select SUM(l.UnitPrice) AS total from Laundry l inner join ReservedRooms rd on rd.RoomID=l.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID where rn.CustID='" + textBox1.Text + "'", "Total", TlaundryAmount, con);
                function.labelLoad("select SUM(Hours*250) AS total from PoolGame pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID where rn.CustID='" + textBox1.Text + "'", "Total", tpoolAmount, con);
                function.labelLoad("select SUM(Hours*150) AS total from gym pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID where rn.CustID='" + textBox1.Text + "'", "Total", tgymAmount, con);
                function.labelLoad("select SUM(((km-1)*v.amountPerkm)+ v.initialAmount) AS total from VehicleReservation vr,vehicle v,location l where vr.vehicleNumber=v.vehicleNumber AND vr.location=l.PlaceCode AND vr.customerId='" + textBox1.Text + "'", "Total", thireAmount, con);

                float totalAmount = float.Parse(troomAmount.Text) + float.Parse(thallAmount.Text) + float.Parse(tfoodAmount.Text) + float.Parse(tbarAmount.Text) + float.Parse(TlaundryAmount.Text) + float.Parse(tpoolAmount.Text) + float.Parse(tgymAmount.Text) + float.Parse(thireAmount.Text);
                tamount.Text = totalAmount.ToString();

                //paid Amount
                function.labelLoad("select SUM(p.Amountpaid) AS total from ReservedRooms rd,RoomReservation rn,payment p WHERE rn.ReservationID=rd.ReservationID AND p.ReserveID=rn.ReservationID AND rn.CustID='" + textBox1.Text + "'", "Total", proomAmount, con);
                function.labelLoad("select SUM(p.Amountpaid) AS total from payment p, Events e where p.EventID=E.EventID AND e.custID='" + textBox1.Text + "'", "Total", peventAmount, con);
                function.labelLoad("select sum(p.Amountpaid)AS Total from FoodOrder fo inner join Food fd on fd.FoodID = fo.FoodID inner join Orders o on o.OrderID=fo.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join Payment p on fo.FoodOrderID=p.FoodOrderID WHERE rn.CustID='" + textBox1.Text + "'", "Total", pfoodAmount, con);
                function.labelLoad("select sum(p.Amountpaid) AS total from BeverageOrders b inner join AvailableBeverage ab on b.BeverageID = ab.BeverageID and ab.size = b.size inner join Orders o on o.OrderID=b.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join Payment p on p.BeveOrderID=b.BeverageID WHERE rn.CustID='" + textBox1.Text + "'", "Total", pbarAmount, con);
                function.labelLoad("select SUM(p.Amountpaid) AS total from Laundry l inner join ReservedRooms rd on rd.RoomID=l.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.laundryID=l.LaundryID where rn.CustID='" + textBox1.Text + "'", "Total", plaundryAmount, con);
                function.labelLoad("select SUM(p.Amountpaid) AS total from PoolGame pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.PoolID=pg.PoolID where rn.CustID='" + textBox1.Text + "'", "Total", ppoolAmount, con);
                function.labelLoad("select SUM(p.Amountpaid) AS total from gym pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.Gymid=pg.Gymid where rn.CustID='" + textBox1.Text + "'", "Total", pgymAmount, con);
                function.labelLoad("select SUM(p.Amountpaid) AS total from VehicleReservation vr,vehicle v,location l,payment p where vr.vehicleNumber=v.vehicleNumber AND vr.hireid=p.hireid AND vr.location=l.PlaceCode AND vr.customerId='" + textBox1.Text + "'", "Total", phireAmount, con);

                float totalPaid = float.Parse(proomAmount.Text) + float.Parse(peventAmount.Text) + float.Parse(pfoodAmount.Text) + float.Parse(pbarAmount.Text) + float.Parse(plaundryAmount.Text) + float.Parse(ppoolAmount.Text) + float.Parse(pgymAmount.Text) + float.Parse(phireAmount.Text);
                pamount.Text = totalPaid.ToString();


                //discount
                function.labelLoad("select SUM(p.discount) AS total from ReservedRooms rd,RoomReservation rn,payment p WHERE rn.ReservationID=rd.ReservationID AND p.ReserveID=rn.ReservationID AND rn.CustID='" + textBox1.Text + "'", "Total", droomAmount, con);
                function.labelLoad("select SUM(p.discount) AS total from payment p, Events e where p.EventID=E.EventID AND e.custID='" + textBox1.Text + "'", "Total", deventAmount, con);
                function.labelLoad("select sum(p.discount)AS Total from FoodOrder fo inner join Food fd on fd.FoodID = fo.FoodID inner join Orders o on o.OrderID=fo.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join Payment p on fo.FoodOrderID=p.FoodOrderID WHERE rn.CustID='" + textBox1.Text + "'", "Total", dfoodAmount, con);
                function.labelLoad("select sum(p.discount) AS total from BeverageOrders b inner join AvailableBeverage ab on b.BeverageID = ab.BeverageID and ab.size = b.size inner join Orders o on o.OrderID=b.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join Payment p on p.BeveOrderID=b.BeverageID WHERE rn.CustID='" + textBox1.Text + "'", "Total", dbarAmount, con);
                function.labelLoad("select SUM(p.discount) AS total from Laundry l inner join ReservedRooms rd on rd.RoomID=l.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.laundryID=l.LaundryID where rn.CustID='" + textBox1.Text + "'", "Total", dlaundryAmount, con);
                function.labelLoad("select SUM(p.discount) AS total from PoolGame pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.PoolID=pg.PoolID where rn.CustID='" + textBox1.Text + "'", "Total", dpoolAmount, con);
                function.labelLoad("select SUM(p.discount) AS total from gym pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.Gymid=pg.Gymid where rn.CustID='" + textBox1.Text + "'", "Total", dgymAmount, con);
                function.labelLoad("select SUM(p.discount) AS total from VehicleReservation vr,vehicle v,location l,payment p where vr.vehicleNumber=v.vehicleNumber AND vr.hireid=p.hireid AND vr.location=l.PlaceCode AND vr.customerId='" + textBox1.Text + "'", "Total", dhireAmount, con);

                float totaldiscount = float.Parse(droomAmount.Text) + float.Parse(deventAmount.Text) + float.Parse(dfoodAmount.Text) + float.Parse(dbarAmount.Text) + float.Parse(dlaundryAmount.Text) + float.Parse(dpoolAmount.Text) + float.Parse(dgymAmount.Text) + float.Parse(dhireAmount.Text);
                tdiscount.Text = totaldiscount.ToString();

                //NetAmount
                function.labelLoad("select SUM(p.NetAmount) AS total from ReservedRooms rd,RoomReservation rn,payment p WHERE rn.ReservationID=rd.ReservationID AND p.ReserveID=rn.ReservationID AND rn.CustID='" + textBox1.Text + "'", "Total", nroomAmount, con);
                function.labelLoad("select SUM(p.NetAmount) AS total from payment p, Events e where p.EventID=E.EventID AND e.custID='" + textBox1.Text + "'", "Total", neventAmount, con);
                function.labelLoad("select sum(p.NetAmount)AS Total from FoodOrder fo inner join Food fd on fd.FoodID = fo.FoodID inner join Orders o on o.OrderID=fo.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join Payment p on fo.FoodOrderID=p.FoodOrderID WHERE rn.CustID='" + textBox1.Text + "'", "Total", nfoodAmount, con);
                function.labelLoad("select sum(p.NetAmount) AS total from BeverageOrders b inner join AvailableBeverage ab on b.BeverageID = ab.BeverageID and ab.size = b.size inner join Orders o on o.OrderID=b.OrderID inner join ReservedRooms rd on rd.RoomID=o.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join Payment p on p.BeveOrderID=b.BeverageID WHERE rn.CustID='" + textBox1.Text + "'", "Total", nbarAmount, con);
                function.labelLoad("select SUM(p.NetAmount) AS total from Laundry l inner join ReservedRooms rd on rd.RoomID=l.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.laundryID=l.LaundryID where rn.CustID='" + textBox1.Text + "'", "Total", nlaundryAmount, con);
                function.labelLoad("select SUM(p.NetAmount) AS total from PoolGame pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.PoolID=pg.PoolID where rn.CustID='" + textBox1.Text + "'", "Total", npoolAmount, con);
                function.labelLoad("select SUM(p.NetAmount) AS total from gym pg inner join ReservedRooms rd on rd.RoomID=pg.RoomID inner join RoomReservation rn on rn.ReservationID=rd.ReservationID inner join payment p on p.Gymid=pg.Gymid where rn.CustID='" + textBox1.Text + "'", "Total", ngymAmount, con);
                function.labelLoad("select SUM(p.NetAmount) AS total from VehicleReservation vr,vehicle v,location l,payment p where vr.vehicleNumber=v.vehicleNumber AND vr.hireid=p.hireid AND vr.location=l.PlaceCode AND vr.customerId='" + textBox1.Text + "'", "Total", nhireAmount, con);


                float NetAmount = float.Parse(nroomAmount.Text) + float.Parse(neventAmount.Text) + float.Parse(nfoodAmount.Text) + float.Parse(nbarAmount.Text) + float.Parse(nlaundryAmount.Text) + float.Parse(npoolAmount.Text) + float.Parse(ngymAmount.Text) + float.Parse(nhireAmount.Text);
                namount.Text = NetAmount.ToString();


                float balance = totalAmount - (totalPaid + totaldiscount);
                tbalance.Text = balance.ToString();

                float roombal = float.Parse(troomAmount.Text) - (float.Parse(proomAmount.Text) + float.Parse(droomAmount.Text));
                label70.Text = roombal.ToString();

                float eventbal = float.Parse(thallAmount.Text) - (float.Parse(peventAmount.Text) + float.Parse(deventAmount.Text));
                label69.Text = eventbal.ToString();

                float foodbal = float.Parse(tfoodAmount.Text) - (float.Parse(pfoodAmount.Text) + float.Parse(dfoodAmount.Text));
                label67.Text = foodbal.ToString();

                float barbal = float.Parse(tbarAmount.Text) - (float.Parse(pbarAmount.Text) + float.Parse(dbarAmount.Text));
                label66.Text = barbal.ToString();

                float launbal = float.Parse(TlaundryAmount.Text) - (float.Parse(plaundryAmount.Text) + float.Parse(dlaundryAmount.Text));
                label58.Text = launbal.ToString();

                float poolbal = float.Parse(tpoolAmount.Text) - (float.Parse(ppoolAmount.Text) + float.Parse(dpoolAmount.Text));
                label56.Text = poolbal.ToString();

                float gymbal = float.Parse(tgymAmount.Text) - (float.Parse(pgymAmount.Text) + float.Parse(dgymAmount.Text));
                label54.Text = gymbal.ToString();

                float hirebal = float.Parse(thireAmount.Text) - (float.Parse(phireAmount.Text) + float.Parse(dhireAmount.Text));
                label26.Text = hirebal.ToString();
            }
            else
            {
                label73.Text = "INVALID CUSTOMER ID";
                label19.Text = "";
                label18.Text = "";
                label17.Text = "";
                label16.Text = "";
                label15.Text = "";
                label14.Text = "";
                label13.Text = "";
                label12.Text = "";
                label21.Text = "";
                panel1.Visible = false;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountHome f = new AccountHome();
            f.Show();
            this.Dispose();
        }
    }
}
