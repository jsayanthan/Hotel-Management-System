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
using System.Configuration;

namespace EmployeeManagement
{
    public partial class AddNewBeverage : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        string bevetypeID;
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-298AUNB\SQLEXPRESS;Initial Catalog=hotel1;Integrated Security=True");

        //autoincrement
        public static String getNextID(String col, String table, String prefix, SqlConnection con)
        {

            int id = 0;
            String query = "select max (substring(" + col + ",3,len(" + col + "))) as id from " + table;
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {

                    if (dr["id"].ToString() == "")
                        id = 101;
                    else
                        id = int.Parse(dr["id"].ToString()) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return prefix + id;
        }

        public AddNewBeverage()
        {
            InitializeComponent();
        }
        void Clear()
        {
            bevetypeid.Text="BeverageTypeID";
            bevetype.Clear();
            beveid.Text="BeverageID";
            bevename.Clear();
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bevetype.Text == "")
            {
                MessageBox.Show("You should enter the BeverageType");
            }
            else if (!function.isText(bevetype.Text))
            {
                MessageBox.Show(" Enter the valid BeverageType Name!");
            }
            else if (MessageBox.Show("Do you want to Insert this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    String query = " insert into BeverageType(BeverageTypeID,BeverageTypeName) Values('"+bevetypeid.Text+"','" + bevetype.Text + "')";
                    SqlDataAdapter AddBeverageTypeDetails = new SqlDataAdapter(query, con);
                    AddBeverageTypeDetails.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Add Success!");
                    Debug.WriteLine(query);  
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }


                //Loading Beverage Type 
                comboBox1.Items.Clear();
                String query4 = "select BeverageTypeName from BeverageType";
                con.Open();
                SqlDataAdapter sda4 = new SqlDataAdapter(query4, con);
                DataSet ds4 = new DataSet();
                sda4.Fill(ds4, "BeverageType");
                DataTable dt4 = ds4.Tables["BeverageType"];

                foreach (DataRow dr in dt4.Rows)
                {
                    comboBox1.Items.Add(dr["BeverageTypeName"].ToString());
                }
                con.Close();
            }
            beveid.Text = getNextID("BeverageID", "Beverage", "BV", con);
        }

        private void AddNewBeverage_Load(object sender, EventArgs e)
        {

            bevetypeid.Text = getNextID("BeverageTypeID", "BeverageType", "BT", con);

            //Loading Beverage Type Id
            String query4 = "select BeverageTypeName from BeverageType";
    
            con.Open();
            SqlDataAdapter sda4 = new SqlDataAdapter(query4, con);
            DataSet ds4 = new DataSet();
            sda4.Fill(ds4, "BeverageType");
            DataTable dt4 = ds4.Tables["BeverageType"];

            foreach (DataRow dr in dt4.Rows)
            {
                comboBox1.Items.Add(dr["BeverageTypeName"].ToString());
            }
            con.Close();

            String sql = "select t.BeverageTypeID,t.BeverageTypeName,b.BeverageID,b.BeverageName from BeverageType t,Beverage b where BeverageTypeID=BeverageType";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            DataSet ds = new DataSet();
            DataView dv;
            try
            {
 
                con.Open();
                cmd = new SqlCommand(sql, con);
                da.SelectCommand = cmd;
                da.Fill(ds, "Beverage");
                da.Dispose();
                cmd.Dispose();
                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = this.dataGridView1.Rows[index];
            bevetypeid.Text = selectedRow.Cells["BeverageTypeID"].Value.ToString();
            beveid.Text = selectedRow.Cells["BeverageID"].Value.ToString();
            bevetype.Text = selectedRow.Cells["BeverageTypeName"].Value.ToString();
            bevename.Text = selectedRow.Cells["BeverageName"].Value.ToString();

            bevetypeinsert.Enabled = false;
            bevenameinsert.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Select any BeverageTypeID");
            }
            else if(bevename.Text == "")
            {
                MessageBox.Show("You Must Enter the Beverage Name");
            }
            else if (!function.isText(bevename.Text))
            {
                MessageBox.Show("Enter the valid BeverageName! ");
            }
            else if (MessageBox.Show("Do you want to Insert this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                string query4 = "select BeverageTypeID from BeverageType where BeverageTypeName='" + comboBox1.SelectedItem.ToString() + "' ";
                 SqlDataAdapter sda4 = new SqlDataAdapter(query4, con);
                DataSet ds4 = new DataSet();
                sda4.Fill(ds4, "BeverageType");
                DataTable dt4 = ds4.Tables["BeverageType"];
             
                foreach (DataRow dr in dt4.Rows)
                {
                     bevetypeID=(dr["BeverageTypeID"].ToString());
                }
              
                try
                {
                     
                    String query = " insert into Beverage(BeverageID,BeverageName,BeverageType) Values('"+beveid.Text+"','" + bevename.Text + "','"+bevetypeID + "')";
                    SqlDataAdapter AddBeverageNamedetails = new SqlDataAdapter(query, con);
                    AddBeverageNamedetails.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Add Success!");
                    Debug.WriteLine(query);

                    Clear();

                    String sql = "select t.BeverageTypeID,t.BeverageTypeName,b.BeverageID,b.BeverageName from BeverageType t,Beverage b where BeverageTypeID=BeverageType";
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd;
                    DataSet ds = new DataSet();
                    DataView dv;

                    try
                    { 
                        cmd = new SqlCommand(sql, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "Beverage");
                        da.Dispose();
                        cmd.Dispose();
                        dv = ds.Tables[0].DefaultView;
                        dataGridView1.DataSource = dv;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            bevetypeid.Text = getNextID("BeverageTypeID", "BeverageType", "BT", con);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Clear();
            bevetypeid.Text = getNextID("BeverageTypeID", "BeverageType", "BT", con);

            bevetypeinsert.Enabled = true;
            bevenameinsert.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            beveid.Text = getNextID("BeverageID", "Beverage", "BV", con);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Barmanagement Bar = new Barmanagement();
            Bar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BarMain form = new BarMain();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

