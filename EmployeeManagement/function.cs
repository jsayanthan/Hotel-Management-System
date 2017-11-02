using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net.Mail;
using System.IO.Ports;
using System.Threading;

namespace EmployeeManagement


{
    class function
    {

        public static SqlConnection con = ConnectionManager.GetConnection();

        public static void getAge(DateTimePicker dt, TextBox tet)
        {
            if (dt.Value.Year == DateTime.Today.Year)   //if selected date is current date age will be 0.
            {
                tet.Text = null;  // if the selected date equal to current date textbox will clear
            }
            else    //else print the age in the TextBox
            {

                int Age = DateTime.Today.Year - dt.Value.Year; // CurrentYear - BirthDate

                
                if (Age > 18)
                {
                    tet.Text = Age.ToString();
                    

                }
                else
                {
                    MessageBox.Show("Under Eightien Employees Can't Apply!! ");
                    

                }
                
            }
        }

        public static String getNextID(String col, String table, String prefix,SqlConnection con)
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
        public static void  numvarify(TextBox col,Label nc,Button buf)
        {
            Regex phoneNumpattern = new Regex(@"(?<!\d)\d{10}$");
            if (phoneNumpattern.IsMatch(col.Text))
            {
                nc.Visible = false;
                
            }
            else
            {
                nc.Visible = true;
                buf.Enabled = false;
                
            }
        }
        


        public static void nicveryfy(String nc,Label lab,Button bu)
        {
            
            if ((nc.Count(char.IsDigit) == 9) && // only 9 digits
                (nc.EndsWith("v", StringComparison.OrdinalIgnoreCase)
                 || nc.EndsWith("V", StringComparison.OrdinalIgnoreCase))) //a letter at the end 'v' or 'V'
                
            {
                //Valid
                lab.Visible = false;
                bu.Enabled = true;
            }
            else
            {
                lab.Visible = true;
                bu.Enabled = false;
            }
        }

        public static Boolean adddetails(String query, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                sda.SelectCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public static bool hasData(String query, SqlConnection con)
        {
            int count = 0;
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    count++;
                }
                if (count > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public static String getVal(String colname, String query, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[colname].ToString() != "")
                        return dr[colname].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }
            return "";
        }

        public static void DisplayData(String quary, DataGridView dataGridView, SqlConnection con)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(quary, con);
            adapt.Fill(dt);
            dataGridView.DataSource = dt;
            con.Close();
        }


        public static String getcol(TextBox text, String colname, String query, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                   text.Text= dr[colname].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }
            return "";
        }

        public static void getcount(Label text, String colname, String query, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[colname].ToString() != "")
                    {
                        text.Text = dr[colname].ToString();
                    }
                    else
                    {
                        double empty = 0;
                        text.Text = empty.ToString();
                    }
                }
                con.Close();


            }

            catch (Exception ex)
            {

            }
        }
        public static void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        public static void loadcolor(DataGridView dgv)
        {
            if(dgv.RowCount.Equals(null)==false)
                {
                   for(int i=0;i<dgv.RowCount-1;i++)
                {
                    string status = dgv.Rows[i].Cells[16].Value.ToString();
                    if(status=="Resigned")
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
               }

        }

        public static void loadTable(string query, DataGridView dvg)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                dvg.DataSource = dt;
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static bool isNumber(string values)
        {
            Regex r = new Regex(@"^[0-9]+$");
            if (r.IsMatch(values))
                return true;
            return false;

        }

        public static bool isText(string values)
        {
            Regex r = new Regex(@"^[a-zA-Z]+$");
            if (r.IsMatch(values))
                return true;
            return false;

        }

        public static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool numCount(string text, int num)
        {

            if (text.Trim().Length != num)
                return true;
            return false;
        }

        public static void ExecuteQuery(String query, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

        }


        public static void compareArrays(String[][] arr_new, String[][] arr_old)
        {
            for (int j = 0; j < arr_new.Count(); j++)
            {
                for (int k = 0; k < arr_old.Count(); k++)
                {
                    Debug.WriteLine("Welcome");
                    if (arr_new[j].Length == 2)
                    {
                        Debug.WriteLine("Byee");
                        if (arr_new[j][0] == arr_old[k][0] && arr_new[j][1] == arr_old[k][1])
                        {
                            arr_new[j][0] = "";
                            arr_old[k][0] = "";
                            arr_new[j][1] = "";
                            arr_old[k][1] = "";
                            break;
                        }
                    }
                    else if (arr_new[j].Length == 3)
                    {
                        Debug.WriteLine("Hii");
                        if (arr_new[j][0] == arr_old[k][0] && arr_new[j][1] == arr_old[k][1] && arr_new[j][2] == arr_old[k][2])
                        {
                            arr_new[j][0] = "";
                            arr_old[k][0] = "";
                            arr_new[j][1] = "";
                            arr_old[k][1] = "";
                            arr_new[j][2] = "";
                            arr_old[k][2] = "";
                            break;
                        }
                    }
                }
            }
        }


        public static List<String[]> getList(String col1_name, String col2_name, String query, SqlConnection con)
        {
            List<String[]> list = new List<String[]>();
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[col1_name].ToString() != "")
                    {
                        list.Add(new String[2] { dr[col1_name].ToString(), dr[col2_name].ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }
            return list;
        }

        public static string getPort()
        {
            string port = null;
            try
            {
                if (con.State.ToString() == "Closed")
                {
                    con.Open();
                }

                SqlCommand newCmd = con.CreateCommand();
                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "select Port from Settings";

                port = newCmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return port;
        }

        public static int getPortSpeed()
        {
            int port = 0;
            try
            {
                if (con.State.ToString() == "Closed")
                {
                    con.Open();
                }
                SqlCommand newCmd3 = con.CreateCommand();

                newCmd3.Connection = con;
                newCmd3.CommandType = CommandType.Text;
                newCmd3.CommandText = "select Port from Settings";
                port = Convert.ToInt32(newCmd3.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return port;

        }

        public static void send_SMS(string na, string pn)
        {  //should validate


            string portName = getPort();
            int portSpeed = getPortSpeed();
            string phoneNo = pn;



            string message = "Hi " + na + " Your Reservation is Confirmed .";

            SerialPort serialPort = new SerialPort(portName, portSpeed);
            Thread.Sleep(1000);
            serialPort.Open();
            Thread.Sleep(1000);
            serialPort.Write("AT+CMGF=1\r");
            Thread.Sleep(1000);
            serialPort.Write("AT+CMGS=\"" + phoneNo + "\"\r\n");
            Thread.Sleep(1000);
            serialPort.Write(message + "\x1A");
            Thread.Sleep(1000);
            serialPort.Close();


        }

        //adil
        public static void loadTableQuery(DataGridView dgv, string query)
        {
            try
            {

                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                dgv.DataSource = dt;
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

        public static void loadrowcolour(DataGridView dgv, int a)
        {
            try
            {
                if ((dgv.RowCount.Equals(null)) == false)
                {
                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        float value = float.Parse(dgv.Rows[i].Cells[a].Value.ToString());
                        float pol = float.Parse(dgv.Rows[i].Cells[a + 1].Value.ToString());
                        if (value < pol)
                        {
                            dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void insertQuery(string query)
        {
            try
            {

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();

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

        public static Boolean IsName(String str)
        {
            if (!Regex.IsMatch(str, @"^[A-Za-z]+$"))
            {
                return false;

            }
            else
            {
                return true;
            }
        }


        public static Boolean IsDigit(String str)
        {
            if (!Regex.IsMatch(str, @"^[0-9]+$"))
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        public static void LoadComboBox(string query, ComboBox combo, String colName)
        {
            try
            {
                combo.Items.Clear();
                con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    combo.Items.Add(dr[colName].ToString());
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


        public static void LoadComboBox1(string query, ComboBox combo, String colName)
        {
            try
            {
                combo.Items.Clear();
                con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    combo.Items.Add(dr[colName].ToString());
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

        public static float getSepCr(string supid)
        {
            float supCrAmount = 0;
            try
            {

                String supcr = "Select CreditBal from SupplierCredits where SupplierID ='" + supid + "' ";
                con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(supcr, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    supCrAmount = float.Parse((dr["CreditBal"].ToString()));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return supCrAmount;

        }

        public static int getstockquantity(string stockid)
        {
            int supCrAmount = 0;
            try
            {

                String supcr = "Select Quantity from Stock where StockID ='" + stockid + "' ";
                con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(supcr, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    supCrAmount = int.Parse((dr["Quantity"].ToString()));
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return supCrAmount;

        }

        public static void ComboWithKey(ComboBox combo, string query, string key, string value)
        {
            try
            {
                combo.Items.Clear();
                con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(query, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    combo.Items.Add(new KeyValuePair<String, String>(dr[key].ToString(), dr[value].ToString()));
                    combo.ValueMember = "Key";
                    combo.DisplayMember = "Value";

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

        public static String getNextID(String col, String table, String prefix)
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

        public static void loadTable(DataGridView dgv, string table)
        {
            try
            {
                String query = "select * from " + table;
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                dgv.DataSource = dt;
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


        //anjay

        public static Boolean Regex1(String re, TextBox tb, PictureBox pb)
        {
            Regex reg = new Regex(re);
            if ((reg.IsMatch(tb.Text)))
            {
                pb.Image = Properties.Resources.valid;
                return true;
            }
            else
            {
                pb.Image = Properties.Resources.invalid;
                return false;
            }
        }

        public static void executesqlquerey(string sql, SqlConnection con)
        {
            try
            {
                con.Open();
                SqlDataAdapter qry = new SqlDataAdapter(sql, con);
                qry.SelectCommand.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void tableload(string sql, SqlConnection con, DataGridView dgb, string tablename)
        {
            try
            {
                String qry = sql;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd;
                DataSet ds = new DataSet();
                DataView dv;
                cmd = new SqlCommand(sql, con);
                da.SelectCommand = cmd;
                da.Fill(ds, tablename);
                da.Dispose();
                cmd.Dispose();
                con.Close();
                dv = ds.Tables[0].DefaultView;
                dgb.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void get(string qry, Label name, SqlConnection con)
        {
            try
            {
                String sql = qry;
                con.Open();
                SqlDataAdapter load = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                load.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["sum"].ToString() != "")
                    {
                        name.Text = dr["sum"].ToString();
                    }
                    else
                    {
                        double empty = 0;
                        name.Text = empty.ToString();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable getinfo(string sql, SqlConnection con)
        {
            String query = sql;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public static void labelLoad(string qry, string colName, Label label, SqlConnection con)
        {
            float amount = 0;
            try
            {
                String sql = qry;
                con.Open();
                SqlDataAdapter load = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                load.Fill(ds, "table");
                DataTable dt = ds.Tables["table"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[colName].ToString() != "")
                    {
                        label.Text = dr[colName].ToString();
                    }
                    else
                    {
                        double empty1 = 0;
                        label.Text = empty1.ToString();
                    }
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

        public static DataTable getcomboBox(string sql, SqlConnection con)
        {
            String query = sql;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        public static Boolean Regexp(String re, TextBox tb, PictureBox pb)
        {
            Regex reg = new Regex(re);
            if ((reg.IsMatch(tb.Text)))
            {
                pb.Image = Properties.Resources.valid;
                return true;
            }
            else
            {
                pb.Image = Properties.Resources.invalid;
                return false;
            }

        }


        //sayanthan
        public static int getstockquantity1(string foodID)
        {
            int quantity = 0;
            try
            {

                string supcr = "Select QuantityAvailable from DailyFoods where FoodID ='" + foodID + "' ";
                con.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter(supcr, con);
                DataSet ds1 = new DataSet();
                sda1.Fill(ds1, "Table");
                DataTable dt1 = ds1.Tables["Table"];

                foreach (DataRow dr in dt1.Rows)
                {
                    quantity = int.Parse((dr["QuantityAvailable"].ToString()));
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
            return quantity;

        }



    }//main


}
