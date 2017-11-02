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

namespace EmployeeManagement
{
    public partial class EditSupplier : Form
    {
        SqlConnection CON = ConnectionManager.GetConnection();
        public EditSupplier()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("Supplier");
        private void EditSupplier_Load(object sender, EventArgs e)
        {
            SearchType.SelectedIndex = 0;
            SupID.Enabled = false;
            Updtbtm.Enabled = false;
            Delbtn.Enabled = false;

            try
            {
                string query2 = "select SupplierID,SupplierName,Address,Contact from Supplier "
                                        + "where status='Available' ";
                CON.Open();

                SqlDataAdapter sda = new SqlDataAdapter(query2, CON);
                dt.Clear();
                sda.Fill(dt);
                EditSup.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CON.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            if (SearchType.SelectedItem.ToString() == "Supplier Name")
            {
                dv.RowFilter = string.Format("SupplierName like '%{0}%' ", SearchName.Text); 
            }
            else
            {
                dv.RowFilter = string.Format("SupplierID like 'SP{0}%' ", SearchName.Text);
            }
            EditSup.DataSource = dv.ToTable();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void EditSup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = EditSup.CurrentCell.RowIndex;
            string supid = EditSup.Rows[row].Cells[0].Value.ToString();
            string supname = EditSup.Rows[row].Cells[1].Value.ToString();
            string supaddress = EditSup.Rows[row].Cells[2].Value.ToString();
            string supcontact = EditSup.Rows[row].Cells[3].Value.ToString();
            SupID.Text = supid;
            SupName.Text = supname;
            SupAddress.Text = supaddress;
            SupContact.Text = supcontact;

            Updtbtm.Enabled = true;
            Delbtn.Enabled = true;

        }
        

        private void Updtbtm_Click(object sender, EventArgs e)
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

                        string query = "update Supplier set SupplierName='" +supname+ "',Address='"+supaddress+"',Contact='"+supcontact+"' where SupplierID='" + supid + "' ";

                        function.insertQuery(query);


                        try
                        {
                            string query2 = "select SupplierID,SupplierName,Address,Contact from Supplier "
                                                    + "where status='Available' ";
                            CON.Open();

                            SqlDataAdapter sda = new SqlDataAdapter(query2, CON);
                            dt.Clear();
                            sda.Fill(dt);
                            EditSup.DataSource = dt;
                            CON.Close();



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        SupID.Clear();
                        SupName.Clear();
                        SupAddress.Clear();
                        SupContact.Clear();

                        Updtbtm.Enabled = false;
                        Delbtn.Enabled = false;

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

        private void Delbtn_Click(object sender, EventArgs e)
        {
            string supid = SupID.Text;
            float supcr = function.getSepCr(supid);
            if (supcr <= 0)
            {
                string query = "Update Supplier set status='Unavailable' where SupplierID = '" + supid + "'";

                function.insertQuery(query);
            }
            else
            {
                MessageBox.Show("Can't delete While Supplier Having Credit Balance");
            }

            string query2 = "select SupplierID,SupplierName,Address,Contact from Supplier "
                                   + "where status='Available' ";
            function.loadTableQuery(EditSup, query2);

            SupID.Clear();
            SupName.Clear();
            SupAddress.Clear();
            SupContact.Clear();

                Updtbtm.Enabled = false;
                Delbtn.Enabled = false;
            

        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();
            this.Hide();
        }
    }
}
