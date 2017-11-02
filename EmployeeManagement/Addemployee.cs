using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;
namespace EmployeeManagement
{
    public partial class Addemployee : Form
    {
       SqlConnection CON = new SqlConnection(@"Data Source=DESKTOP-VPQ80BN;Initial Catalog=Hotel;Integrated Security=True");
        SqlCommand cmd;
        
       
        public Addemployee()
        {
            InitializeComponent();

            DisplayData();
            string stat = "Working";
            string qry = "select count(EmpID) as count from Employee where status='" + stat + "' ";
            function.getcount(noOfemployee, "count", qry, CON);  //count the working employees

            
            //int count = dataGridView3.Rows.Count;
            //foreach (DataGridViewRow row in dataGridView3.Rows)
            //{
            //    if(dataGridView3.Rows.Count-1 > row.Index)
            //    { 
            //    if (row.Cells[16].Value.ToString()=="Resigned")
            //    {
            //        Debug.WriteLine(row.Cells[16].Value);
            //        row.DefaultCellStyle.BackColor = Color.Red;
                    
            //        Debug.WriteLine(row.DefaultCellStyle.BackColor);
            //    }
            //    }
            //}
           

        }
        public void Clear2()
        {
            
            empid.Text = string.Empty;
             Nic.Text = string.Empty;
              fon.Text = null;
               frname.Text = string.Empty;
                lrname.Text = string.Empty;
                 basc.Text = null;
                  ages.Text = null;
                   nice.Text= string.Empty;
                    dbo.Text = null;
                     jndate.Text = null;
                      addrs.Text = string.Empty;
                        asc.Text = string.Empty;
                         bnknam.Text = string.Empty;
                          branchn.Text = string.Empty;
                           
                              label42.Visible =false;
                                pos.Text = "---Select Position---";
                                 sft.Text = "---Select  Shift---";
                                 
            

        }


        public void Clear()
        {
            //CLEAR THE COMPONANTS AFTER ADDING EVERY EMPLOYEE
            eid.Text = string.Empty;
             Nic.Text = string.Empty;
              phone.Text = null;
               fname.Text = string.Empty;
                 lname.Text = string.Empty;
                   basicSal.Text = null;
                    age.Text = null;
                       dob.Text = null;
                        jdate.Text = null;
                         address.Text = string.Empty;
                           male.Checked = false;
                             female.Checked = false;
                               seType.Text = "---Select Position---";
                                 comShft.Text = "---Select  Shift---";
                                   accNo.Text = string.Empty;
                                    bankName.Text = string.Empty;
                                      branchName.Text = string.Empty;
                                  pictureBox1.ImageLocation = null;
                                         url.Text = String.Empty;
       }
        String Gender;

        DataTable dt;


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Addemployee_Load(object sender, EventArgs e)
        {
            eid.Text = function.getNextID("EmpID", "Employee","EM",CON);

            string stat = "Working";
            string qry = "select count(EmpID) as count from Employee where status='" + stat + "' ";

            function.getcount(noOfemployee,"count",qry,CON);  //count the working employees

            function.loadcolor(dataGridView3);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee frm = new Employee();      //for back button
            frm.ShowDialog();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation != null)
            {


                byte[] imageBt = null;
                 FileStream fstream = new FileStream(this.url.Text, FileMode.Open, FileAccess.Read); //hold the image and read the Bytes
                  BinaryReader br = new BinaryReader(fstream);
                   imageBt = br.ReadBytes((int)fstream.Length);

                  string edid = this.eid.Text;
                 String fname = this.fname.Text;
                string llname = lname.Text;
               DateTime db = dob.Value.Date;

               DateTime jd = jdate.Value.Date;
                  int phn = int.Parse(phone.Text);
                   int ag = int.Parse(age.Text);
                    string selected = this.seType.GetItemText(this.seType.SelectedItem);
                     string shift = this.comShft.GetItemText(this.comShft.SelectedItem);
                      string status = "Working";




                if (this.fname.Text == string.Empty || this.lname.Text == string.Empty || basicSal.Text == string.Empty || address.Text == string.Empty||age.Text==string.Empty||phone.Text==string.Empty)
                {

                    MessageBox.Show("All the details should be given!");


                }
                

                else if (selected.Equals("---Select Position---"))
                {
                    MessageBox.Show("position should be given!");
                }



                else if (selected.Equals("--- Select  Shift---"))
                {
                    MessageBox.Show("shift should be given!");
                }


                else {
                    try
                    {

                        CON.Open();

                        string Query = "INSERT INTO Employee(EmpID,FirstName,LastName,DateOfBirth,Age,NIC,Gender,Telephone,BasicSalary,JoiningDate,Address,Shifts,Position,Image,status)VALUES('" + edid + "','" + fname + "','" + llname + "','" + db + "'," + ag + ",'" + Nic.Text + "','" + Gender + "'," + phn + ",'" + basicSal.Text + "','" + jd + "','" + address.Text + "','" + shift + "','" + selected + "',@img,'" + status + "')";  //IMG is parameter for image
                        Debug.WriteLine(Query);
                        cmd = new SqlCommand(Query, CON);
                        cmd.Parameters.Add(new SqlParameter("@img", imageBt));
                        cmd.ExecuteNonQuery();
                       
                        CON.Close();
                        string qry1 = "INSERT INTO BankDetails(EmpID,accountNo,BankName,BranchName)VALUES('" + eid.Text + "','" + accNo.Text + "','" + bankName.Text + "','" + branchName.Text + "')";
                        function.adddetails(qry1,CON);
                        Debug.WriteLine(qry1);


                        
                        MessageBox.Show("New Employee Successfully Added!");
                        string stat = "Working";
                        string qry = "select count(EmpID) as count from Employee where status='" + stat + "' ";

                        function.getcount(noOfemployee, "count", qry, CON);  //count the working employees
                        DisplayData();    //to load the new data to the table
                        Clear();   //call the clear function after insert the new employee
                        eid.Text = function.getNextID("EmpID", "Employee", "EM", CON);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Image shold be given!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";   //Filter Files According to the Formet
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dlg.FileName.ToString();    //copy the path of the picture
                pictureBox1.ImageLocation = picLoc;  //provide the path to picture box
                url.Text = picLoc;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            this.url.Text = String.Empty;
        }

        private void search_Click(object sender, EventArgs e)
        {

            CON.Open();
            SqlDataAdapter adpt = new SqlDataAdapter("select * from Employee WHERE EmpID LIKE '" + serch.Text + "%' OR FirstName LIKE '" + serch.Text + "%' ", CON);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView3.DataSource = dt;
            CON.Close();
        }
        //Display Data in DataGridView  
        private void DisplayData()
        {
            CON.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select e.EmpID,e.FirstName,e.LastName,e.DateOfBirth,e.Age,e.NIC,e.Gender,e.Telephone,e.BasicSalary,e.JoiningDate,e.Address AS Email,e.Shifts,e.Position,b.accountNo,b.BankName,b.BranchName,e.status from Employee e INNER JOIN BankDetails b ON e.EmpID=b.EmpID ", CON);
            adapt.Fill(dt);
            dataGridView3.DataSource = dt;

            CON.Close();
            //DisplayData();
            function.loadcolor(dataGridView3);
        }

        private void male_CheckedChanged_1(object sender, EventArgs e)
        {
            if (male.Checked)
            {
                Gender = "Male";
            }
        }

        private void female_CheckedChanged_1(object sender, EventArgs e)
        {
            if (female.Checked)
            {
                Gender = "Female";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = null;
            Clear2();
            
            DisplayData();
           
            
        }

        private void serch_TextChanged(object sender, EventArgs e)
        {

            
            CON.Open();
            SqlDataAdapter adpt = new SqlDataAdapter("select e.EmpID,e.FirstName,e.LastName,e.DateOfBirth,e.Age,e.NIC,e.Gender,e.Telephone,e.BasicSalary,e.JoiningDate,e.Address As Email,e.Shifts,e.Position,b.accountNo,b.BankName,b.BranchName,e.status from Employee e INNER JOIN BankDetails b ON e.EmpID=b.EmpID  WHERE e.EmpID LIKE '" + serch.Text + "%' OR e.FirstName LIKE '" + serch.Text + "%' ", CON);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView3.DataSource = dt;
            CON.Close();
          
            function.loadcolor(dataGridView3);
        }

        //dataGridView1 RowHeaderMouseClick Event  


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           


        }



        private void updateBut_Click(object sender, EventArgs e)
        {
            
           
            int phn = int.Parse(fon.Text);
             float bsal = float.Parse(basc.Text);
              String empi = empid.Text.ToString();
               string adds = addrs.Text.ToString();
                string selected = this.pos.GetItemText(this.seType.SelectedItem).ToString();
                 string shift = this.sft.GetItemText(this.comShft.SelectedItem).ToString();
                  int accnou = int.Parse(asc.Text);
                   string bnknm = bnknam.Text.ToString();
                    string brnam = branchn.Text.ToString();
                      DateTime db = dbo.Value.Date;

            if (this.addrs.Text == string.Empty || this.frname.Text == string.Empty || lrname.Text == string.Empty || nice.Text == string.Empty || addrs.Text == string.Empty || asc.Text == string.Empty)
            {

                MessageBox.Show("All the details shold be given!");


            }


            else if (selected.Equals("---Select Position---"))
            {
                MessageBox.Show("position shold be given!");
            }



            else if (selected.Equals("--- Select  Shift---"))
            {
                MessageBox.Show("shift should be given!");
            }

            else {
                try
                {

                    CON.Open();
                    string Query = "UPDATE Employee set FirstName='" + frname.Text + "',LastName='" + lrname.Text + "',DateOfBirth='" + db + "',NIC='" + nice.Text + "',Telephone=" + phn + ",BasicSalary='" + bsal + "',Address='" + adds + "',Shifts='" + shift + "',Position='" + selected + "' where EmpID='" + empi + "'";
                    cmd = new SqlCommand(Query, CON);

                    int N = cmd.ExecuteNonQuery();

                    string qry = "UPDATE BankDetails set accountNo=" + accnou + " ,BankName='" + bnknm + "',BranchName='" + brnam + "' where EmpID='" + empi + "'";
                    cmd = new SqlCommand(qry, CON);
                    int NM = cmd.ExecuteNonQuery();




                    CON.Close();
                    Clear2();
                    MessageBox.Show("Details Successfully Updated!");
                    DisplayData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string statu = "Resigned";
            String empi = empid.Text.ToString();
            try
            {

                CON.Open();
                

                string Query =" UPDATE Employee set status = '" + statu + "' where EmpID = '" + empi + "'";  
                cmd = new SqlCommand(Query, CON);
               int N = cmd.ExecuteNonQuery();

                CON.Close();
                 label42.Visible = true;
                
                MessageBox.Show("Resinged!!");
                string stat = "Working";
                string qry = "select count(EmpID) as count from Employee where status='" + stat + "' ";
                function.getcount(noOfemployee, "count", qry, CON);  //count the working employees
                Clear2();
                DisplayData();
                
                function.loadcolor(dataGridView3);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void load_Click(object sender, EventArgs e)
        {

        }

        private void serch_MouseLeave(object sender, EventArgs e)
        {
            

        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                int i = e.RowIndex;

                if (i >= 0)
                {
                      DataGridViewRow r = dataGridView3.Rows[i];
                      CON.Open();
                          String qry = "select Image from Employee where EmpID='" + r.Cells[0].Value + "" + "'";
                            cmd = new SqlCommand(qry, CON);
                               SqlDataReader myReader;

                                  myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        empid.Text = r.Cells[0].Value + "";
                         frname.Text = r.Cells[1].Value + "";
                           lrname.Text = r.Cells[2].Value + "";
                             dbo.Text = r.Cells[3].Value + "";
                                int agh = int.Parse(r.Cells[4].Value + "");
                                  ages.Text = agh.ToString();
                               nice.Text = r.Cells[5].Value + "";
                              gen.Text = r.Cells[6].Value + "";
                            int phones = int.Parse(r.Cells[7].Value + "");
                          fon.Text = phones.ToString();
                        float bas = float.Parse(r.Cells[8].Value + "");
                          basc.Text = bas.ToString();
                            jndate.Text = r.Cells[9].Value + "";
                              addrs.Text = r.Cells[10].Value + "";
                               sft.Text = r.Cells[11].Value + "";
                                pos.Text = r.Cells[12].Value + "";
                                 int acc = int.Parse(r.Cells[13].Value + "");
                                   asc.Text = acc.ToString();
                                    bnknam.Text = r.Cells[14].Value + "";
                                      branchn.Text = r.Cells[15].Value + "";

                        //for show the resigned employee
                        if (!r.Cells[16].Value.Equals("Working"))
                        {
                            label42.Visible = true;
                              Resign.Enabled = false;
                                updateBut.Enabled = false;
                            dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                        }
                           else
                            {
                               label42.Visible = false;
                                 Resign.Enabled = true;
                                   updateBut.Enabled = true;

                            }
                        byte[] imgg = (byte[])(myReader["Image"]);
                          if (imgg == null)
                            pictureBox2.Image = null;
                              else
                               {
                                 MemoryStream mstream = new MemoryStream(imgg);
                                   pictureBox2.Image = System.Drawing.Image.FromStream(mstream);
                                 }


                    }

                  CON.Close();
                }     

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dob_ValueChanged(object sender, EventArgs e)
        {
            function.getAge(dob, age);
            
        }

        private void dbo_ValueChanged(object sender, EventArgs e)
        {

            function.getAge(dbo, ages);

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


      
        private void jdate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void fname_Leave(object sender, EventArgs e)
        {
            
            
             
        }

        private void lname_Leave(object sender, EventArgs e)
         {
                    
        }

        private void fname_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void phone_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void phone_Validated(object sender, EventArgs e)
        {
                     
        }

        private void Nic_BackColorChanged(object sender, EventArgs e)
        {
              
        }

        private void Nic_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void Nic_Validated(object sender, EventArgs e)
        {
                     function.nicveryfy(Nic.Text.ToString(),nc, Add); //validating add employee class's nic number with calling the function
                       

        }

        private void phone_Validated_1(object sender, EventArgs e)
        {
            function.numvarify(phone, plab, Add);        //validating Add employee class's phone number with calling the function
        }

        private void nice_Validated(object sender, EventArgs e)
        {
            function.nicveryfy(nice.Text.ToString(), phonup, Add); //validating update interface's nic number
        }

        private void fon_Validated(object sender, EventArgs e)
        {
            function.numvarify(fon, nicup, Add);   //validating update interface's phone number
        }

        private void age_Validated(object sender, EventArgs e)
        {
          
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            DisplayData();
            function.loadcolor(dataGridView3);
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void accNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void accNo_Validated(object sender, EventArgs e)
        {
            
        }
    }
}