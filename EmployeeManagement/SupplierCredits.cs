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
    public partial class SupplierCredits : Form
    {
        public SupplierCredits()
        {
            InitializeComponent();
        }

        private void SupplierCredits_Load(object sender, EventArgs e)
        {
            string query1 = "select s.SupplierName,s.SupplierID,sc.CreditBal from Supplier s,SupplierCredits sc "
                           + "where s.SupplierID = sc.SupplierID AND sc.CreditBal > 0";
            function.ComboWithKey(Sid, query1, "SupplierID","SupplierName");

            string query = "select s.SupplierName,s.SupplierID,sc.CreditBal from Supplier s,SupplierCredits sc "
                           + "where s.SupplierID = sc.SupplierID AND sc.CreditBal > 0";
            function.loadTableQuery(SupCr, query);

            string query2 = "Select * from supplierPayment order by Date Desc";
            function.loadTableQuery(SupPayment, query2);
            SPid.Enabled = false;
            SPid.Text = function.getNextID("PID", "supplierPayment", "PA");
            ChqDate.Visible = false;
            chqLabel.Visible = false;

            Updtbtn.Enabled = false;
            Delbtn.Enabled = false;

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();
            this.Hide();
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (Sid.SelectedIndex >= 0)
            {
                if (amountBox.Text != "" && function.IsDigit(amountBox.Text))
                {
                    if (PayTypeCombo.SelectedIndex >= 0)
                    {
                        string pid = SPid.Text;
                        string supplier = (((KeyValuePair<String, String>)Sid.SelectedItem).Key);
                        float amount = float.Parse(amountBox.Text);
                        string paytype = PayTypeCombo.SelectedItem.ToString();
                        DateTime paydate = DateTime.Now;
                        string chequeDate = ChqDate.Value.ToString("yyyy-MM-dd");
                        float Supcr = function.getSepCr(supplier) - amount;
                        string paymentID = function.getNextID("PaymentID", "Payment", "PA");

                        string query = "";
                        string SupCRquery = "Update SupplierCredits set CreditBal='" + Supcr + "' where SupplierID = '" + supplier + "' ";
                        if (paytype == "Cash")
                        {
                            query = "insert into supplierPayment(PID,SupplierID,Amount,Date,paymentType)"
                                   + "values('" + pid + "','" + supplier + "','" + amount + "','" + paydate + "','" + paytype + "')";
                        }
                        else
                        {
                            query = "insert into supplierPayment(PID,SupplierID,Amount,Date,paymentType,ChequeDate)"
                                   + "values('" + pid + "','" + supplier + "','" + amount + "','" + paydate + "','" + paytype + "','" + chequeDate + "')";
                        }

                        function.insertQuery(query);
                        function.insertQuery(SupCRquery);

                        string query1 = "select s.SupplierName,s.SupplierID,sc.CreditBal from Supplier s,SupplierCredits sc "
                                       + "where s.SupplierID = sc.SupplierID AND sc.CreditBal > 0";
                        function.loadTableQuery(SupCr, query1);
                        string query2 = "Select * from supplierPayment order by Date Desc";
                        function.loadTableQuery(SupPayment, query2);

                        float payamount = -1 * amount;
                        string paymentqry = "insert into Payment(PaymentID,SupplierPayID,AmountPaid,date)values"
                                            + "('" + paymentID + "','" + pid + "','" + payamount + "','" + paydate + "')";
                        function.insertQuery(paymentqry);


                        SPid.Text = function.getNextID("PID", "supplierPayment", "PA");
                        Sid.SelectedIndex = -1;
                        amountBox.Clear();
                        PayTypeCombo.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("please Select a Payment Type");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Amount");
                    amountBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Select the Supplier");
            }


        }

        private void ChqDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void PayTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PayTypeCombo.SelectedItem.ToString() == "Cheque")
            {
                ChqDate.Visible = true;
                chqLabel.Visible = true;
            }
            else
            {
                ChqDate.Visible = false;
                chqLabel.Visible = false;
            }
        }

        string SupplierID = "";
        float Oldamount = 0;
        private void SupPayment_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = SupPayment.CurrentCell.RowIndex;
            SPid.Text = SupPayment.Rows[row].Cells[0].Value.ToString();
            SupplierID= SupPayment.Rows[row].Cells[1].Value.ToString();
            Sid.Text = SupplierID;
            Oldamount = float.Parse(SupPayment.Rows[row].Cells[2].Value.ToString());
            amountBox.Text = Oldamount.ToString();
            PayTypeCombo.SelectedItem = SupPayment.Rows[row].Cells[4].Value.ToString();
            PayTypeCombo.Enabled = false;

            if (SupPayment.Rows[row].Cells[4].Value.ToString() == "Cheque")
            {
                ChqDate.Value = DateTime.Parse(SupPayment.Rows[row].Cells[5].Value.ToString());
                ChqDate.Enabled = false;
                
                 
            }
            Addbtn.Enabled = false;
            Updtbtn.Enabled = true;
            Delbtn.Enabled = true;





        }

        private void Updtbtn_Click(object sender, EventArgs e)
        {
            if (amountBox.Text != "" && function.IsDigit(amountBox.Text))
            {
                string spid = SPid.Text;
                string supid = Sid.Text;
                string sid = (((KeyValuePair<String, String>)Sid.SelectedItem).Key);
                float value = float.Parse(amountBox.Text);

                if (SupplierID == sid || SupplierID== supid)
                {
                    float supcr = (function.getSepCr(SupplierID) + Oldamount) - value;
                    string query = "update SupplierCredits set CreditBal='" + supcr + "' where SupplierID='" + SupplierID + "' ";
                    string query1 = "update supplierPayment set Amount='" + value + "' where PID='" + spid + "' ";
                    string query2 = "update Payment set AmountPaid='" + value + "' where SupplierPayID='" + spid + "' ";
                    function.insertQuery(query);
                    function.insertQuery(query1);
                    function.insertQuery(query2);
                }
                else
                {
                    float supcr = function.getSepCr(SupplierID) + Oldamount;
                    float supcrnew = function.getSepCr(sid) - value;
                    string query = "update SupplierCredits set CreditBal='" + supcr + "' where SupplierID='" + SupplierID + "' ";
                    string query1 = "update supplierPayment set SupplierID='" + sid + "',Amount='" + value + "' where PID='" + spid + "' ";
                    string query2 = "update SupplierCredits set CreditBal='" + supcrnew + "' where SupplierID='" + sid + "' ";
                    string query3 = "update Payment set AmountPaid='" + value + "' where SupplierPayID='" + spid + "' ";
                    function.insertQuery(query);
                    function.insertQuery(query1);
                    function.insertQuery(query2);
                    function.insertQuery(query3);

                }

                string qry1 = "select s.SupplierName,s.SupplierID,sc.CreditBal from Supplier s,SupplierCredits sc "
                               + "where s.SupplierID = sc.SupplierID AND sc.CreditBal > 0";
                function.loadTableQuery(SupCr, qry1);
                string qry2 = "Select * from supplierPayment order by Date Desc";
                function.loadTableQuery(SupPayment, qry2);



                SPid.Text = function.getNextID("PID", "supplierPayment", "PA");
                Sid.SelectedIndex = -1;
                amountBox.Clear();
                PayTypeCombo.SelectedIndex = 0;

                Addbtn.Enabled = true;
                Updtbtn.Enabled = false;
                Delbtn.Enabled = false;
                PayTypeCombo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid Amount");
            }

            

        }

        private void Delbtn_Click(object sender, EventArgs e)
        {
            string sppid = SPid.Text;
            float supcr = function.getSepCr(SupplierID) + Oldamount;

            string query = "delete from supplierPayment where PID='" + sppid + "'";
            string query1= "update SupplierCredits set CreditBal='" + supcr + "' where SupplierID='" + SupplierID + "' ";
            function.insertQuery(query);
            function.insertQuery(query1);
            string query3 = "Delete from Payment where SupplierPayID = '" + sppid + "' ";
            function.insertQuery(query3);

            string qry1 = "select s.SupplierName,s.SupplierID,sc.CreditBal from Supplier s,SupplierCredits sc "
                           + "where s.SupplierID = sc.SupplierID AND sc.CreditBal > 0";
            function.loadTableQuery(SupCr, qry1);
            string qry2 = "Select * from supplierPayment order by Date Desc";
            function.loadTableQuery(SupPayment, qry2);

            




            SPid.Text = function.getNextID("PID", "supplierPayment", "PA");
            Sid.SelectedIndex = -1;
            amountBox.Clear();
            PayTypeCombo.SelectedIndex = 0;

            Addbtn.Enabled = true;
            Updtbtn.Enabled = false;
            Delbtn.Enabled = false;
            PayTypeCombo.Enabled = true;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SupplierCredits_DoubleClick(object sender, EventArgs e)
        { 
            SPid.Text = function.getNextID("PID", "supplierPayment", "PA");
            Sid.SelectedIndex = -1;
            amountBox.Clear();
            PayTypeCombo.SelectedIndex = 0;

            Addbtn.Enabled = true;
            Updtbtn.Enabled = false;
            Delbtn.Enabled = false;
            PayTypeCombo.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierCrystal sp = new SupplierCrystal();
            sp.Show();
        }
    }
}
