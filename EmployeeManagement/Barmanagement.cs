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
using System.Configuration;

namespace EmployeeManagement
{
    public partial class Barmanagement : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-298AUNB\SQLEXPRESS;Initial Catalog=hotel1;Integrated Security=True");
        SqlConnection con = ConnectionManager.GetConnection();

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

        public Barmanagement()
        {
            InitializeComponent();
        }

        void Clear()
        {
            
            beveid.Text="BeverageID";
            type.Text = "";
            name.Text = "";
            size.Text = "";
            quantity.Clear();
            price.Clear();
        }

        private void Barmanagement_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label15.Text = DateTime.Now.ToLongTimeString();
            label16.Text = DateTime.Now.ToLongDateString();

            //Loading comboBox Size
            String query = "select distinct size from AvailableBeverage ";
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "AvailableBeverage");
                DataTable dt = ds.Tables["AvailableBeverage"];

                foreach (DataRow dr in dt.Rows)
                {
                    size.Items.Add(dr["size"].ToString());
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


            //Loading comboBox Beverage Type Name
            String query2 = "select distinct BeverageTypeName  from BeverageType ";
            con.Open();
            SqlDataAdapter sda2 = new SqlDataAdapter(query2, con);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2, "BeverageType");
            DataTable dt2 = ds2.Tables["BeverageType"];

            foreach (DataRow DR1 in dt2.Rows)
            {
                type.Items.Add(DR1["BeverageTypeName"].ToString());
            }
            con.Close();


            String sql = "select b.BeverageID,t.BeverageTypeName,b.BeverageName,a.size,a.quantuty,a.price  from BeverageType t,Beverage b,AvailableBeverage a where t.BeverageTypeID=b.BeverageType and b.BeverageID=a.BeverageID";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd;
            DataSet ds3 = new DataSet();
            DataView dv;
            try
            {
                
                con.Open();
                cmd = new SqlCommand(sql, con);
                da.SelectCommand = cmd;
                da.Fill(ds3, "Beverage");
                da.Dispose();
                cmd.Dispose();
                dv = ds3.Tables[0].DefaultView;
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

            add.Enabled = true;
            button7.Enabled = true;
            delete.Enabled = false;
            clear.Enabled = true;
            update.Enabled = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            BarMain form = new BarMain();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if(type.SelectedIndex < 0 )
            {
                MessageBox.Show("Please select any BeverageType then click Insert button");
            }
            else if(name.SelectedIndex < 0)
            {
                MessageBox.Show("Please select any BeverageName then click Insert button");
            }
            else if (size.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Size then click Insert button");
            }
            else if(quantity.Text == "")
            {
                MessageBox.Show(" You must Enter the Quantity! ");
            }
            else if (!function.isNumber(quantity.Text) )
            {
                MessageBox.Show("Quantity should be integer value");
            }
            else if(price.Text == "" )
            {
                MessageBox.Show("You must Enter the Price! ");
            }
            else if( !function.isNumber(price.Text) )
            {
                MessageBox.Show("Price should be number value ");
            }
            else if (MessageBox.Show("Do you want to Insert this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                String BeverageId = beveid.Text;
                //String Size = size.SelectedItem.ToString();
                String QUantity = quantity.Text;
                int Quantity = int.Parse(QUantity);
                String pric = price.Text;
                float Price = float.Parse(pric);

                try
                {
                   
                    String query ="insert into AvailableBeverage(BeverageID,size,quantuty,price) values('" + BeverageId + "','" + size.SelectedItem.ToString() + "'," + Quantity + "," + Price + ")";
                    SqlDataAdapter AddAvailableBeverageDetails = new SqlDataAdapter(query, con);
                    AddAvailableBeverageDetails.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Add Success!");

                    String sql = "select b.BeverageID,t.BeverageTypeName,b.BeverageName,a.size,a.quantuty,a.price  from BeverageType t,Beverage b,AvailableBeverage a where t.BeverageTypeID=b.BeverageType and b.BeverageID=a.BeverageID";
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand cmd;
                    DataSet ds = new DataSet();
                    DataView dv;

                    try
                    {
                       
                        cmd = new SqlCommand(sql, con);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "AvailableBeverage");
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
        }

        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            if (quantity.Text == "")
            {
                MessageBox.Show("You must Enter the Quantity! ");
            }
            else if (!function.isNumber(quantity.Text))
            {
                MessageBox.Show("Quantity should be integer value");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("You must Enter the Price! ");
            }
            else if (!function.isNumber(price.Text))
            {
                MessageBox.Show("Price should be number value ");
            }
            else
            {
                String QUantity = quantity.Text;
                int Quantity = int.Parse(QUantity);
                String pric = price.Text;
                float Price = float.Parse(pric);

                if (MessageBox.Show("Do you want to UPDATE this Data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                       
                        String query = "update  AvailableBeverage  set quantuty = '" + Quantity + "', price='" + Price + "' where  BeverageID ='" + beveid.Text + "' and  size='" + size.SelectedItem.ToString() + "'";
                        SqlDataAdapter Updategedetails = new SqlDataAdapter(query, con);
                        Updategedetails.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Update Success!");
                        Clear();


                        String sql = "select b.BeverageID,t.BeverageTypeName,b.BeverageName,a.size,a.quantuty,a.price  from BeverageType t,Beverage b,AvailableBeverage a where t.BeverageTypeID=b.BeverageType and b.BeverageID=a.BeverageID";
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
                            con.Close();
                            dv = ds.Tables[0].DefaultView;
                            dataGridView1.DataSource = dv;
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter deletedetails= new SqlDataAdapter("delete from AvailableBeverage where BeverageID='" + beveid.Text + "' and size = '"+size.Text+"'", con);
            deletedetails.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Delete Success!");
            con.Close();
            Clear();
    
            String sql = "select b.BeverageID,t.BeverageTypeName,b.BeverageName,a.size,a.quantuty,a.price  from BeverageType t,Beverage b,AvailableBeverage a where t.BeverageTypeID=b.BeverageType and b.BeverageID=a.BeverageID";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;
            DataGridViewRow selectedRow = this.dataGridView1.Rows[index];
            type.Text = selectedRow.Cells["BeverageTypeName"].Value.ToString();
            name.Text = selectedRow.Cells["BeverageName"].Value.ToString();
            beveid.Text = selectedRow.Cells["BeverageID"].Value.ToString();
            size.Text = selectedRow.Cells["size"].Value.ToString();
            quantity.Text = selectedRow.Cells["quantuty"].Value.ToString();
            price.Text = selectedRow.Cells["price"].Value.ToString();

            add.Enabled = false;
            button7.Enabled = true;
            delete.Enabled = true;
            clear.Enabled = true;
            update.Enabled = true;
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewBeverage AddBeverage = new AddNewBeverage();
            AddBeverage.Show();
            this.Hide();
        }

        private void name_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void type_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String BeverageType = type.SelectedItem.ToString();
            name.Items.Clear();
            String query = "select * from Beverage where BeverageType =(select BeverageTypeId from BeverageType where  BeverageTypeName = '" + BeverageType + "')";
            Console.Write(query);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "table");
            DataTable dt = ds.Tables["table"];

            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    name.Items.Add(dr["BeverageName"].ToString());

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

        private void name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String query = "Select BeverageID from Beverage where BeverageName='" + name.SelectedItem.ToString() + "' ";
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    beveid.Text = dr["BeverageID"].ToString();
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

        private void size_SelectedIndexChanged(object sender, EventArgs e)
        {
           // label8.Text = getNextID("BeverageID", "Beverage", "BV", con);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
