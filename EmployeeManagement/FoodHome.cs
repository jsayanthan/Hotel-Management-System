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
using System.Diagnostics;
using System.Globalization;


namespace EmployeeManagement
{
    public partial class FoodHome : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        public FoodHome()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void fillcombo()
        {
            try
            {
                con.Open();
                string qry = "SELECT distinct FoodTypeName FROM FoodTypes";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();

                comboFoodType.Items.Clear();
                while (dr.Read())
                {
                    comboFoodType.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return;
        }
       /* void fill1combo()
        {
            try
            {
                con.Open();
                string qry = "SELECT distinct FoodName FROM Food";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();

                Food_Name.Items.Clear();
                while (dr.Read())
                {
                    Food_Name.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }*/
        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            timer1.Start();
            label8.Text = DateTime.Now.ToLongTimeString();
            label4.Text = DateTime.Now.ToLongDateString();
            fillcombo();
            //fill1combo();
            disp2_data();
            UPDATE.Enabled = false;
            ADD.Enabled = true;
            DELETE.Enabled = false;
            CLEAR.Enabled = true;
            enabletrueall();

        }

        void enabletrueall()
        {
            comboFoodType.Enabled = true;
            Food_Name.Enabled = false;
            Unit_price.Enabled = false;
            crt_Date_textBox.Enabled = false;
            crt_Date_textBox.Enabled = false;
            comboBox1.Enabled = false;
            Quantity.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            addFood_Details openForm = new addFood_Details();
            openForm.Show();
            Visible = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void ODERS_Click(object sender, EventArgs e)
        {
            Oders openForm = new Oders();
            openForm.Show();
            Visible = false;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }
        public void disp2_data()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("select s.FoodID,s.Date,f.FoodTypeName,e.FoodName,e.UnitPrice,s.Time,s.QuantityAvailable from DailyFoods s inner join Food e on s.FoodID=e.FoodID inner join FoodTypes f on f.FoodTypeID=e.FoodType", con);
                cm.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void ADD_Click(object sender, EventArgs e)
        {
            try

            {
                if (comboFoodType.Text == "-Select Food Type-")
                {
                    MessageBox.Show("Select The  Food type");
                }
                else if (Food_Name.Text == "-Select Food Name-")
                {
                    MessageBox.Show("Select The  Food Name");
                }
                else if (comboBox1.Text == "-Select Food Time-")
                {
                    MessageBox.Show("Select Food Time");
                }
                else if (Quantity.Text == "")
                {
                    MessageBox.Show("Enter The Quantity");
                }

                    
                    else
                    {
                        con.Open();
                    //DateTime txtMyDate = Convert.ToDateTime(crt_Date_textBox.Text);
                    SqlCommand cm = new SqlCommand("insert into DailyFoods(FoodID,Date,Time,QuantityAvailable) values('" + Food_ID.Text + "','" + crt_Date_textBox.Text + "','" + comboBox1.Text + "','" + Quantity.Text + "')", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        disp2_data();
                        MessageBox.Show("Successfully Added");
                        ClearTextBox();
                        fillcombo();
                        comboFoodType.Text = "-Select Food Type-";
                        // GenarateAutoID();
                        enabletrueall();
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

       

        private void Food_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcombo();

            try
            {
                con.Open();
                string qry = "select e.FoodID,e.UnitPrice,f.FoodTypeName from Food e inner join FoodTypes f on  e.FoodType = f.FoodTypeID   WHERE e.FoodName='" + Food_Name.Text + "'";
                SqlDataReader sr= new SqlCommand(qry, con).ExecuteReader();

               

                while (sr.Read())
                {
                    Food_ID.Text = (sr.GetValue(0).ToString());
                    Unit_price.Text = (sr.GetValue(1).ToString());
                    //comboFoodType.Text = (sr.GetValue(2).ToString());
                     
                }
                
                sr.Close();
                
                comboFoodType.Enabled = true;
                Food_Name.Enabled = true;
                Unit_price.Enabled = false;
                crt_Date_textBox.Enabled = false;
                comboBox1.Enabled = true;
                Quantity.Enabled = false;
                DateTime idate = DateTime.Now;
                crt_Date_textBox.Text = idate.ToString("MM/dd/yyyy");
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

        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                if (Quantity.Text == Quantity.Text)
                {
                    MessageBox.Show("Enter The different Quantity");
                    Quantity.Clear();
                }
                else
                {

                    if (MessageBox.Show("Are U want Update Data", "Update Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cm = new SqlCommand("update  DailyFoods set QuantityAvailable='" + Quantity.Text + "', Time='" + comboBox1.Text + "'  where FoodID= '" + Food_ID.Text + "'  and Date= '" + crt_Date_textBox.Text + "' and Time= '" + comboBox1.Text + "'", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        disp2_data();
                        MessageBox.Show("Successfully Upadated");
                        ClearTextBox();
                        enabletrueall();


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                
                if (dataGridView1.CurrentRow.Index != -1)
                {

                    Food_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    // DateTime dt = DateTime.ParseExact(dataGridView1.CurrentRow.Cells[1].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //dateTimePicker1.Value = dt;
                    crt_Date_textBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    comboFoodType.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    Food_Name.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    Unit_price.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    Quantity.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    DELETE.Enabled = true;
                    UPDATE.Enabled = true;
                    ADD.Enabled = false;
                    CLEAR.Enabled = true;
                }
                enablefalseitems();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
            
        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Are U want Del Data", "Delete Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cm = new SqlCommand("delete from DailyFoods where FoodID= '" + Food_ID.Text + "' and Date= '" + crt_Date_textBox.Text + "' and Time='"+ comboBox1.Text + "' ", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    disp2_data();
                    MessageBox.Show("Successfully Deleted");
                    ClearTextBox();
                    enabletrueall();
                    //comFoodType.Text = "-Select Type-";
                    //FoodGenarateAutoID();
                    //btnFoodAdd.Text = "ADD";
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearTextBox()
        {
            Food_ID.Text = "";
            Food_Name.Text = "-Select Food Name-";
            comboFoodType.Text = "";
            Unit_price.Text = "";
            comboBox1.Text = "-Select Food Time-";
            Quantity.Text = "";
            comboFoodType.Text = "-Select Food Type-";
            crt_Date_textBox.Text = "";
            comboFoodType.Enabled = true;
            Food_Name.Enabled = false;
            Unit_price.Enabled = false;
            crt_Date_textBox.Enabled = false;
            crt_Date_textBox.Enabled = false;
            comboBox1.Enabled = false;
            Quantity.Enabled = false;
            ADD.Enabled = true;
            CLEAR.Enabled = true;
            ADD.Enabled = true;
            DELETE.Enabled = false;
            UPDATE.Enabled = false;
            fillcombo();

        }
        private void CLEAR_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void comboFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                string qry = "SELECT e.FoodName FROM Food e inner join FoodTypes f on e.FoodType = f.FoodTypeID where FoodTypeName='" + comboFoodType.Text + "'";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                Food_Name.Items.Clear();

                while (dr.Read())
                {
                    Food_Name.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                comboFoodType.Enabled = true;
                Food_Name.Enabled = true;
                Unit_price.Enabled = false;
                crt_Date_textBox.Enabled = false;
                crt_Date_textBox.Enabled = false;
                comboBox1.Enabled = false;
                Quantity.Enabled = false;
                

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

        private void Unit_price_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        void enablefalseitems()
        {
            comboFoodType.Enabled = false;
            Food_Name.Enabled = false;
            Unit_price.Enabled = false;
            crt_Date_textBox.Enabled = false;
            crt_Date_textBox.Enabled = false;
            comboBox1.Enabled = true;
            Quantity.Enabled = true;
        }
        void enabletrue()
        {
            comboFoodType.Enabled = true;
            Food_Name.Enabled = true;
            Unit_price.Enabled = true;
            crt_Date_textBox.Enabled = true;
            crt_Date_textBox.Enabled = true;
            comboBox1.Enabled = true;
            Quantity.Enabled = true;
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ADD.Enabled = true;
            CLEAR.Enabled = true;
            ClearTextBox();
            enabletrueall();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            ADD.Enabled = true;
            CLEAR.Enabled = true;
            ClearTextBox();
            enabletrueall();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboFoodType_SelectedValueChanged(object sender, EventArgs e)
        {
          
        }

        private void Quanitity_TextChanged(object sender, EventArgs e)
        {
            if (function.isNumber(Quantity.Text) || Quantity.Text == "")
            {

            }

            else

            {
                MessageBox.Show("Invalid Food Quantity format Re-Enter");
                Quantity.Clear();
            }
        }

        private void Unit_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void Date_TextChanged(object sender, EventArgs e)
        {
            String query = "select s.FoodID,s.Date,f.FoodTypeName,e.FoodName,e.UnitPrice,s.Time,s.QuantityAvailable from DailyFoods s inner join Food e on s.FoodID = e.FoodID inner join FoodTypes f on f.FoodTypeID = e.FoodType and CONCAT(s.Time, e.FoodName) like'%"+Search.Text+"%'";
            function.loadTable(query,dataGridView1);
        }

        private void HOME_Click(object sender, EventArgs e)
        {
            main2 m = new main2();
            m.Show();
            this.Hide();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if ((Convert.ToInt32(Myrow.Cells[6].Value) <= 50) && (Convert.ToInt32(Myrow.Cells[6].Value) > 0))// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }
                else if ((Convert.ToInt32(Myrow.Cells[6].Value) > 50) && (Convert.ToInt32(Myrow.Cells[6].Value) <= 100))
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (Convert.ToInt32(Myrow.Cells[6].Value) > 100)
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
    }
}
