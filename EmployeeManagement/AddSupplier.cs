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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
            SupID.Enabled = false;
            ADDSUPGRC.Visible = false;
        }

        public AddSupplier(int i)
        {
            InitializeComponent();
            SupID.Enabled = false;
            SupAdd.Visible = false;
            Backbtn.Visible = false;
            Homebtn.Visible = false;
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            SupID.Text= function.getNextID("SupplierID", "Supplier", "SP");

            string query2 = "select SupplierID,SupplierName,Address,Contact from Supplier "
                                       + "where status='Available' ";
            function.loadTableQuery(Supplierdgv, query2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();
            this.Hide();
        }

        private void SupAdd_Click(object sender, EventArgs e)
        {
            if(SupName.Text !="" && function.IsName(SupName.Text))
            {
                if (SupAddress.Text !="")
                {
                    if (SupContact.Text !="" && function.IsDigit(SupContact.Text))
                    {
                        string supid = SupID.Text.ToString();
                        string supname = SupName.Text.ToString();
                        string supaddress = SupAddress.Text.ToString();
                        string supcontact = SupContact.Text.ToString();

                        string query = "insert into Supplier(SupplierID,SupplierName,Address,Contact,status)values('" + supid + "','" + supname + "','" + supaddress + "','" + supcontact + "','Available')";
                        string query1 = "insert into SupplierCredits(SupplierID,CreditBal)values('" + supid + "','" + 0 + "')";
                        function.insertQuery(query);
                        function.insertQuery(query1);

                        string query2= "select SupplierID,SupplierName,Address,Contact from Supplier "
                                       +"where status='Available' ";
                        function.loadTableQuery(Supplierdgv, query2);
                        SupID.Text = function.getNextID("SupplierID", "Supplier", "SP");
                        SupName.Clear();
                        SupAddress.Clear();
                        SupContact.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Please type the Contact Correctly");
                        SupContact.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please type the Address Correctly");
                    SupAddress.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please type the Name Correctly");
                SupName.Clear();
                
            }



        }

        private void ADDSUPGRC_Click(object sender, EventArgs e)
        {
            if (SupName.Text != "" && function.IsName(SupName.Text))
            {
                if (SupAddress.Text != "")
                {
                    if (SupContact.Text != "" && function.IsDigit(SupContact.Text))
                    {
                        string supid = SupID.Text.ToString();
                        string supname = SupName.Text.ToString();
                        string supaddress = SupAddress.Text.ToString();
                        string supcontact = SupContact.Text.ToString();
                        string sts = "Available";

                        string query = "insert into Supplier(SupplierID,SupplierName,Address,Contact,status)values('" + supid + "','" + supname + "','" + supaddress + "','" + supcontact + "','"+sts+"')";
                        string query1 = "insert into SupplierCredits(SupplierID,CreditBal)values('" + supid + "',0)";
                        function.insertQuery(query);
                        function.insertQuery(query1);

                        AddNewGrocer ang = new AddNewGrocer();
                        
                        ang.Show();
                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Please type the Contact Correctly");
                        SupContact.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please type the Address Correctly");
                    SupAddress.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please type the Name Correctly");
                SupName.Clear();

            }
        }
    }
}
