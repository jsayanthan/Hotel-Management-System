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
namespace EmployeeManagement
{
    public partial class addFood_Details : Form
    {
        SqlConnection con = ConnectionManager.GetConnection();
        String Food = "FT";
        string FoodID = "FO";

        public addFood_Details()
        {
            InitializeComponent();
        }

        void fillcombo()
        {
            try
            {
                con.Open();
                string qry = "SELECT distinct FoodTypeName FROM FoodTypes";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                comFoodType.Items.Clear();

                while (dr.Read())
                {
                    comFoodType.Items.Add(dr.GetValue(0).ToString());

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
        }

        private void addFood_Details_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();

            GenarateAutoID();
            FoodGenarateAutoID();
            disp_data();
            disp2_data();
            fillcombo();
            txtDelete.Enabled = false;
            txtClear.Enabled = true;
            btnFoodDelete.Enabled = false;
            btnFoodClear.Enabled = true;
            label12.Visible = false;

            comFoodType.Enabled = true;
            Food_NameTxt.Enabled = false;
            txtUnitePrice.Enabled = false;

        }


        private void GenarateAutoID()
        {

            string TableColumnName = "FoodTypeID";
            string DefaultColvalue = "FT100";
            string dbTableName = "FoodTypes";
            AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = _autogeneratecode.AutoGenerateCode(TableColumnName, DefaultColvalue, dbTableName);
            string[] sepID = _getID.Split('T');
            int i = Convert.ToInt32(sepID[1]);
            i++;
            label2.Text = Food + i;




        }
        private void FoodGenarateAutoID()
        {


            string TableColumnName = "FoodID";
            string DefaultColvalue = "FO100";
            string dbTableName = "Food";
            AutoGenerateID _autogeneratecode = new AutoGenerateID();
            string _getID = _autogeneratecode.AutoGenerateCode(TableColumnName, DefaultColvalue, dbTableName);
            string[] sepID = _getID.Split('O');
            int i = Convert.ToInt32(sepID[1]);
            i++;
            label11.Text = FoodID + i;



        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            FoodHome openForm = new FoodHome();
            openForm.Show();
            Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAdd.Text == "ADD")
                {
                    if (txtFoodType.Text == "")
                    {
                        MessageBox.Show("enter the Food Type ");
                    }
                    else
                    {
                        {
                            con.Open();

                            SqlCommand cm = new SqlCommand("insert into FoodTypes values('" + label2.Text + "','" + txtFoodType.Text + "')", con);
                            cm.ExecuteNonQuery();
                            con.Close();
                            disp_data();
                            MessageBox.Show("Successfully Added");
                            ClearTextBox();
                            GenarateAutoID();
                            fillcombo();
                        }
                    }

                }
                else
                {
                    if (txtFoodType.Text == txtFoodType.Text)
                    {
                        MessageBox.Show("Enter The Different Type");
                        txtFoodType.Clear();
                    }

                    else
                    {
                        if (MessageBox.Show("Are U want Update Data", "Update Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            con.Open();
                            SqlCommand cm = new SqlCommand("update  FoodTypes set FoodTypeName='" + txtFoodType.Text + "'  where FoodTypeID= '" + label2.Text + "'", con);
                            cm.ExecuteNonQuery();
                            con.Close();
                            disp_data();
                            MessageBox.Show("Successfully Upadated");
                            ClearTextBox();
                            GenarateAutoID();
                            txtAdd.Text = "ADD";

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearTextBox()
        {
            txtFoodType.Text = "";

        }
        private void Clear2TextBox()
        {
            Food_NameTxt.Text = "";
            txtUnitePrice.Text = "";
            comFoodType.Text = "-Select Food Type-";
            comFoodType.Enabled = true;
            Food_NameTxt.Enabled = false;
            txtUnitePrice.Enabled = false;
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cm = new SqlCommand("select * from FoodTypes", con);
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();

        }
        public void disp2_data()
        {
            con.Open();
            SqlCommand cm = new SqlCommand("select Food.FoodID,Food.FoodName,Food.UnitPrice,FoodTypes.FoodTypeName from Food left join FoodTypes on Food.FoodType=FoodTypes.FoodTypeID", con);
            cm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnFoodAdd_Click(object sender, EventArgs e)
        {

            try
            {

                if (btnFoodAdd.Text == "ADD")
                {
                    if (comFoodType.Text == "-Select FoodType-")
                    {
                        MessageBox.Show("Select the Food Type");
                    }
                    else if (Food_NameTxt.Text == "")
                    {
                        MessageBox.Show("Enter the Food Name");
                    }
                    else if (txtUnitePrice.Text == "")
                    {
                        MessageBox.Show("Enter the Unit Price");
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cm = new SqlCommand("insert into Food values('" + label11.Text + "','" + Food_NameTxt.Text + "','" + txtUnitePrice.Text + "','" + label12.Text + "')", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        disp2_data();
                        MessageBox.Show("Successfully Added");
                        Clear2TextBox();
                        FoodGenarateAutoID();
                        comFoodType.Text = "-Selece Food Type-";

                    }

                }

                else
                {
                    if (Food_NameTxt.Text == Food_NameTxt.Text)
                    {
                        MessageBox.Show("enter The different Food Name ");
                    }
                    else if (txtUnitePrice.Text == txtUnitePrice.Text)
                    {
                        MessageBox.Show("enter The different Food Unit Price ");
                    }
                    else
                    {
                        if (MessageBox.Show("Are U want Update Data", "Update Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            con.Open();
                            SqlCommand cm = new SqlCommand("update  Food set FoodName='" + Food_NameTxt.Text + "', UnitPrice='" + txtUnitePrice.Text + "'  where FoodID= '" + label11.Text + "'", con);
                            cm.ExecuteNonQuery();
                            con.Close();
                            disp2_data();
                            MessageBox.Show("Successfully Upadated");
                            Clear2TextBox();
                            FoodGenarateAutoID();
                            btnFoodAdd.Text = "ADD";
                            comFoodType.Text = "-Selece Food Type-";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            label11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Food_NameTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUnitePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comFoodType.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            btnFoodDelete.Enabled = false;
            btnFoodClear.Enabled = false;
            btnFoodAdd.Enabled = false;
            comFoodType.Enabled = false;
            Food_NameTxt.Enabled = false;
            txtUnitePrice.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFoodClear_Click(object sender, EventArgs e)
        {
            Clear2TextBox();
            btnFoodAdd.Enabled = true;
            btnFoodAdd.Text = "ADD";
            FoodGenarateAutoID();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFoodType_TextChanged(object sender, EventArgs e)
        {
            if (function.isText(txtFoodType.Text) || txtFoodType.Text=="")

            {

            }
            else
            {
                {
                    MessageBox.Show("Invalid food Type format Re-Enter");
                    txtFoodType.Clear();
                }

            }
            // txtFoodType.Text = txtFoodType.Text.ToUpper();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are U want Del Data", "Delete Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cm = new SqlCommand("delete from FoodTypes where FoodTypeID='" + label2.Text + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    disp_data();
                    MessageBox.Show("Successfully Deleted");
                    ClearTextBox();
                    txtAdd.Text = "ADD";
                    GenarateAutoID();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtFoodType.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtDelete.Enabled = false;
            txtClear.Enabled = false;
            txtAdd.Enabled = false;

        }

        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                label2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtFoodType.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtAdd.Text = "UPDATE";
                txtDelete.Enabled = true;
                txtClear.Enabled = true;
                txtAdd.Enabled = true;
            }
        }
        private void txtClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            txtAdd.Enabled = true;
            txtAdd.Text = "ADD";
            GenarateAutoID();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            txtAdd.Enabled = true;
            txtAdd.Text = "ADD";
            GenarateAutoID();
            ClearTextBox();
            btnFoodAdd.Enabled = true;
            btnFoodAdd.Text = "ADD";
            FoodGenarateAutoID();
            Clear2TextBox();

        }

        private void addFood_Details_MouseClick(object sender, MouseEventArgs e)
        {
            txtAdd.Enabled = true;
            txtAdd.Text = "ADD";
            GenarateAutoID();
        }

        private void comFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string qry = "SELECT distinct FoodTypeID FROM FoodTypes where FoodTypeName='" + comFoodType.Text + "'";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();


                while (dr.Read())
                {
                    label12.Text = (dr.GetValue(0).ToString());

                }
                dr.Close();
                label12.Visible = false;
                comFoodType.Enabled = true;
                Food_NameTxt.Enabled = true;
                txtUnitePrice.Enabled = true;

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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                label11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Food_NameTxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtUnitePrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comFoodType.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                btnFoodAdd.Text = "UPDATE";
                btnFoodDelete.Enabled = true;
                btnFoodClear.Enabled = true;
                btnFoodAdd.Enabled = true;
                comFoodType.Enabled = false;
                Food_NameTxt.Enabled = true;
                txtUnitePrice.Enabled = true;
            }
        }

        private void btnFoodDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are U want Del Data", "Delete Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cm = new SqlCommand("delete from Food where FoodID='" + label11.Text + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    disp2_data();
                    MessageBox.Show("Successfully Deleted");
                    Clear2TextBox();
                    comFoodType.Text = "-Select Type-";
                    FoodGenarateAutoID();
                    btnFoodAdd.Text = "ADD";
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (function.isText(Food_NameTxt.Text)|| Food_NameTxt.Text == "")
            {
                    
            }
            
            else
            
                {
                    MessageBox.Show("Invalid food Name format Re-Enter");
                    Food_NameTxt.Clear();
                }



        }

        private void groupBox1_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtAdd.Enabled = true;
            txtAdd.Text = "ADD";
            GenarateAutoID();
            ClearTextBox();
            btnFoodAdd.Enabled = true;
            btnFoodAdd.Text = "ADD";
            FoodGenarateAutoID();
            Clear2TextBox();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtAdd.Enabled = true;
            txtAdd.Text = "ADD";
            GenarateAutoID();
            ClearTextBox();
            btnFoodAdd.Enabled = true;
            btnFoodAdd.Text = "ADD";
            FoodGenarateAutoID();
            Clear2TextBox();

        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            txtAdd.Enabled = true;
            txtAdd.Text = "ADD";
            GenarateAutoID();
            ClearTextBox();
            btnFoodAdd.Enabled = true;
            btnFoodAdd.Text = "ADD";
            FoodGenarateAutoID();
            Clear2TextBox();

        }

        private void txtUnitePrice_TextChanged(object sender, EventArgs e)
        {
            if(function.isNumber(txtUnitePrice.Text)|| txtUnitePrice.Text=="")
            {

            }

            else

            {
                MessageBox.Show("Invalid Unit Price format Re-Enter");
                txtUnitePrice.Clear();
            }
        }

        private void Searchtype_TextChanged(object sender, EventArgs e)
        {
            String query = "select FD.FoodID,FD.FoodName,FD.UnitPrice,FT.FoodTypeName from Food FD,FoodTypes FT where FD.FoodType=FT.FoodTypeID and FT.FoodTypeName like '%"+Searchtype.Text+"%'";
            function.loadTable(query, dataGridView1);
        }
    }
}
