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
using System.Net.Mail;

namespace EmployeeManagement
{
    public partial class pay : Form
    {
        SqlConnection CON = new SqlConnection(@"Data Source=DESKTOP-VPQ80BN;Initial Catalog=Hotel;Integrated Security=True");
        SqlCommand cmd;
        String mail;
        public pay()
        {
            InitializeComponent();
            string Query = "select epf,etf,other,festivalbon,OverTime from percentage";
            function.getcol(epf,"epf",Query,CON);
            function.getcol(etf, "etf", Query, CON);
            function.getcol(festivalbon, "festivalbon", Query, CON);
            function.getcol(overtime, "OverTime", Query, CON);
            function.getcol(otr, "other", Query, CON);

            string qry4 = "select ReferenceID,empID,Name,BasicSalary,JoiningDate,Address,Epf,Etf,Tax,Deduction,OvertimeHour,OvertimeRate,FestivalBonus,OtherAlowance,OtherAlowanceRate,LeaveTaken,LeaveDeduction,PresentDays,AprovedLeave,fromDate,PayrollDate,Allowance,NetSalary,Status from Payroll";

            function.DisplayData(qry4, dataGridView1, CON);

        }

        private void eid_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /***
            DateTime fromdate = from.Value.Date;
           
            DateTime tdate = to.Value.Date; //to get the to date picker date
            int todate = to.Value.Month;  //to get the month
            int currentmonth= DateTime.Now.Month;

           

            if (todate < currentmonth)
            {
                MessageBox.Show("choose the correct date!");
                to.CustomFormat =  "yyyy-" + currentmonth + "-20";
            }
            else if (todate > currentmonth)
            {
                MessageBox.Show("choose the correct date!");
                to.CustomFormat = "yyyy-" + currentmonth + "-20";
            }
    
            else if(todate == currentmonth)
            {
                int monthchange = todate - 1;
                from.CustomFormat =  "yyyy-" + monthchange + "-20";

                
            }
    
          ***/
        }

        private void pay_Load(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Employee frm = new Employee();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float epfdata = float.Parse(epf.Text);
            float etfdata = float.Parse(etf.Text);
            float festBon = float.Parse(festivalbon.Text);

            float ovrtime = float.Parse(overtime.Text);
            float other = float.Parse(otr.Text);
            string Query = "INSERT INTO percentage(epf,etf,other,festivalbon,OverTime)VALUES('" + epfdata + "','" + etfdata + "','" + other + "','" + festBon  + "','" + ovrtime + "')";
            function.adddetails(Query, CON);
            Debug.WriteLine(Query);
            MessageBox.Show("success");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            float festamo = 0;
            if (checkBox1.Checked)   //if checkbox is selected textbox and label will enable
            {
                festbonus.Visible = true;
                label38.Visible = true;

                festamo =float.Parse(festivalbon.Text);
                festbonus.Text = festamo.ToString();


            }
            else
            {
                festbonus.Visible = false;
                label38.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //*******************Deduction Calculation part****************************************************************************************     

            if (edid.Text == string.Empty)
            {
                MessageBox.Show("Employee Id should be given!");
            }
            else {
                int pday = int.Parse(presentdays.Text);
                int aday = int.Parse(apleave.Text);
                int workday = int.Parse(workingdays.Text);
                int bsalary = int.Parse(bsal.Text);
                int leave = workday - (pday + aday);  //find the other leave
                noofleave.Text = leave.ToString();
                float deduct;
                if (leave <= 4)  //if other leave less than 4 eqal to 4 no need to calculate leave dedcution
                {
                    int temp = 0;
                    leaveded.Text = temp.ToString();
                    label28.Visible = true;
                    label28.ForeColor = System.Drawing.Color.Green;
                    label28.Text = "No need to pay the leave deduct";
                    noofleave.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    label28.Visible = true;
                    noofleave.BackColor = System.Drawing.Color.LightCoral;
                    deduct = (bsalary / workday) * leave;  //find the leave deduction by basicsalary divide by workday and multiply by other leave
                    leaveded.Text = deduct.ToString();
                }

                //******************************************************************************************************************
                float epfperc = float.Parse(epf.Text);
                float etfperc = float.Parse(etf.Text);
                float festbonperc = float.Parse(festivalbon.Text);
                float overtimeperc = float.Parse(overtime.Text);
                float otherperc = float.Parse(otr.Text);

                float epfamont = bsalary * epfperc / 100;  //find the EPF amount
                epftext.Text = epfamont.ToString();

                float etfamont = bsalary * etfperc / 100;   //find the ETF amount
                etftext.Text = etfamont.ToString();

                if (bsalary >= 60000)      //if basic salary greater than 60000 employee need to pay the tax 2% amount of his basicsalary
                {
                    label13.Visible = true;
                    tax.Visible = true;
                    float taxamount = (bsalary * 2) / 100;
                    tax.Text = taxamount.ToString();
                }
                else
                {
                    int temp = 0;
                    label13.Visible = false;
                    tax.Visible = false;
                    tax.Text = temp.ToString();
                }

                float taxfinal;
                float Ld = float.Parse(leaveded.Text);
                taxfinal = float.Parse(tax.Text);
                float deduction = epfamont + etfamont + Ld + taxfinal;  //total deduction
                deductiontxt.Text = deduction.ToString();

                //********************Allowance Calculation part*******************************************************************************************
                int othr = 0;
                String query = "select OverTime from Attendance where EmpID='" + edid.Text + "' ";
                if (!function.hasData(query, CON))
                {
                    int temp = 0;
                   // otime.Text = temp.ToString();
                    otamount.Text = temp.ToString();
                }
                else {
                   othr = int.Parse(otime.Text);

                    int otrate = int.Parse(overtime.Text); //140 LKR per hour
                    int otamounts = othr * otrate;
                    otamount.Text = otamounts.ToString();
                    Debug.WriteLine(otamount.Text);
                }


                float alowanceamount;
                float ota = float.Parse(otamount.Text);



                if (checkBox2.Checked && checkBox1.Checked)
                {
                    float fest = float.Parse(festbonus.Text);
                    float othervalue = float.Parse(otheram.Text);
                    alowanceamount = fest + othervalue + ota;
                    alowance.Text = alowanceamount.ToString();

                }

                else if (checkBox1.Checked)
                {
                    float fest = float.Parse(festbonus.Text);
                    alowanceamount = ota + fest;
                    alowance.Text = alowanceamount.ToString();
                }
                else if(checkBox2.Checked)
                {

                    float othervalue = float.Parse(otheram.Text);
                    alowanceamount =  othervalue ;
                    alowance.Text = alowanceamount.ToString();
                }

                else
                {
                    alowanceamount = ota;
                    alowance.Text = alowanceamount.ToString();
                }

                float netsalary = (alowanceamount + bsalary) - deduction;
                netsaltext.Text = netsalary.ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void workingdays_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime todate = to.Value.Date;
                from.Value = todate.AddMonths(-1);  //substract the month by 1 and set that value to the from datepicker
                DateTime fromd = from.Value.Date;
                String fromdate = fromd.ToString("yyyy/MM/20");     //change the date formet
                String tdate = to.Value.ToString("yyyy/MM/20");

                String query5 = "select BasicSalary from Payroll where EmpID='" + edid.Text + "' and PayrollDate='"+ tdate + "' ";
                Debug.WriteLine(query5);
                if (function.hasData(query5, CON))
                {
                   
                    MessageBox.Show("Salary was alredy credited to this Employee");
                    function.ClearAllText(this);
                }
               else {



                    String query = "select concat(FirstName, ' ', LastName) as FullName,Address,BasicSalary,format(JoiningDate,'yyyy-MM-dd') JoiningDate from Employee where EmpID='" + edid.Text + "'";
                    function.getcol(fulname, "FullName", query, CON);
                    function.getcol(address, "Address", query, CON);
                    function.getcol(bsal, "BasicSalary", query, CON);
                    function.getcol(jdate, "JoiningDate", query, CON);

                    string qr = "select count(EmpID) as count from Attendance where EmpID='" + edid.Text + "' and Dates BETWEEN '" + fromdate + "' and '" + tdate + "' ";
                    Debug.WriteLine(qr);
                    function.getcol(presentdays, "count", qr, CON);


                    string qeary1 = "select SUM(OverTime) as sum from Attendance where EmpID='" + edid.Text + "' and Dates BETWEEN '" + fromdate + "' and '" + tdate + "'";
                    Debug.WriteLine(qeary1);
                    function.getcol(otime, "sum", qeary1, CON);

                    string st = "Accepted!";
                    string qeary2 = "select count(*) as count from LeaveManage where ID='" + edid.Text + "' and Status='" + st + "' and too BETWEEN '" + fromdate + "' and '" + tdate + "'";
                    Debug.WriteLine(qeary2);
                    function.getcol(apleave, "count", qeary2, CON);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refno.Text = function.getNextID("ReferenceID", "Payroll", "RE", CON);   //auto increment for Refrence No
        }

        private void button1_Enter(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)   //if checkbox is selected textbox and label will enable
            {
                other.Visible = true;
                otheram.Visible = true;
                label44.Visible = true;
                label45.Visible = true;

                float otherperc = float.Parse(otr.Text);
                float bsalary = float.Parse(bsal.Text);
                float othevalue = (bsalary * otherperc) / 100;

                otheram.Text = othevalue.ToString();

                
            }
            else
            {
                other.Visible = false;
                otheram.Visible = false;
                label44.Visible = false;
                label45.Visible = false;
            }
        }

        private void groupBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (edid.Text == string.Empty)
            {
                MessageBox.Show("Employee Id should be given!");
            }
            else {

                string eid = edid.Text;
                string rid = refno.Text;
                string name = fulname.Text;
                string addre = address.Text;
                String joindate = jdate.Text;
                float basicsalary = float.Parse(bsal.Text);
                float overtimehour = float.Parse(otime.Text);
                float overtimeamount = float.Parse(otamount.Text);
                float festivalbonus = float.Parse(festbonus.Text);
                String otherdetails = other.Text;
                float taxamount = float.Parse(tax.Text);
                float otherdetamount = float.Parse(otheram.Text);
                float epfamount = float.Parse(epftext.Text);
                float etfamount = float.Parse(etftext.Text);
                int leavetaken = int.Parse(noofleave.Text);

                float leavededuct = float.Parse(leaveded.Text);
                DateTime todate = to.Value.Date;

                DateTime fromd = from.Value.Date;
                String fromdate = fromd.ToString("yyyy/MM/20");     //change the date formet
                String paydate = to.Value.ToString("yyyy/MM/20");


                int presentday = int.Parse(presentdays.Text);
                int aproleave = int.Parse(apleave.Text);
                float deductioamount = float.Parse(deductiontxt.Text);
                float alowanceaount = float.Parse(alowance.Text);
                float netsalary = float.Parse(netsaltext.Text);

                float paynetsal = netsalary * -1;
                string stat = "Salary Credited";

                string Query = "INSERT INTO Payroll(ReferenceID,empID,Name,Epf,Etf,Tax,Deduction,Address,JoiningDate,BasicSalary,OvertimeHour,OvertimeRate,FestivalBonus,OtherAlowance,OtherAlowanceRate,LeaveTaken,LeaveDeduction,PresentDays,AprovedLeave,fromDate,PayrollDate,Allowance,NetSalary,Status)VALUES('" + rid + "','" + eid + "','" + name + "','" + epfamount + "','" + etfamount + "','" + taxamount + "','" + deductioamount + "','" + addre + "','" + joindate + "','" + basicsalary + "','" + overtimehour + "','" + overtimeamount + "','" + festivalbonus + "','" + otherdetails + "','" + otherdetamount + "'," + leavetaken + ",'" + leavededuct + "'," + presentday + "," + aproleave + ",'" + fromdate + "','" + paydate + "','" + alowanceaount + "','" + netsalary + "','" + stat + "')";
                function.adddetails(Query, CON);

                string payref = function.getNextID("PaymentID", "Payment", "PA", CON);


                string qry5 = "Insert into Payment (PaymentID,PayrollID,AmountPaid)VALUES('" + payref + "','" + rid + "','" + paynetsal + "')";
                function.adddetails(qry5, CON);


                string qry4 = "select ReferenceID,empID,Name,BasicSalary,JoiningDate,Address,Epf,Etf,Tax,Deduction,OvertimeHour,OvertimeRate,FestivalBonus,OtherAlowance,OtherAlowanceRate,LeaveTaken,LeaveDeduction,PresentDays,AprovedLeave,fromDate,PayrollDate,Allowance,NetSalary,Status from Payroll";
                function.DisplayData(qry4, dataGridView1, CON);


                Debug.WriteLine(Query);
                MessageBox.Show("success");

                string qry6 = "select Address from Employee where EmpID='" + eid + "'";
                function.getVal(mail, qry6, CON);

                string data = @"     HOTEL JHONE MERRY 

                             SALARY DETAILS FOR THIS MONTH" + @" 

                 Refrence No             : " + rid + @" 
                 Employee Name           : " + name + @" 
                 SALARY SLIP             : " + paydate + @" 
             ----------------------------------------------------------" + @" 
             ----------------------------------------------------------" + @" 
                 BASIC SALARY            :" + basicsalary + @"
                 OVERTIME HOUR           :" + overtimehour + @" 
                 OVERTIME RATE           :" + overtimeamount + @"
                 FESTIVAL BONUS          :" + festivalbonus + @"
                 OTHER ALOWANCE          :" + otherdetails + @"
                 AMOUNT                  :" + otherdetamount + @"

           ----------------------------------------------------------" + @" 
                 TOTAL ALOWANCE          :" + alowanceaount + @"
           
           ----------------------------------------------------------" + @" 
 
                                DEDUCTION" + @" 
         
                 EPF AMOUNT              :" + epfamount + @"
                 ETF AMOUNT              :" + etfamount + @"
                 TAX AMOUNT              :" + taxamount + @"
                 lEAVE TAKEN             :" + leavetaken + @"
                 lEAVE DEDUCTION         :" + leavededuct + @"
          ----------------------------------------------------------" + @" 

                 TOTAL DEDUCTION :" + deductioamount + @"
                    
                       NET SALARY :" + netsalary + @",

          ----------------------------------------------------------" + @"  
                                                                  
                                                                
                                                               MANAGER.";


                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("alan94walker@gmail.com");
                    mail.To.Add(mail.ToString());
                    mail.Subject = "Salary Slip";
                    mail.Body = data.ToString();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("alan94walker@gmail.com", "1250Chammakchallo");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MessageBox.Show(data);
                function.ClearAllText(this);
            }
           
        }
        //****************************************************************************************************************************************
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked)
            {
                epf.Enabled = true;

            }
            else
            {
                epf.Enabled = false;
            }
        }

        private void etf_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                festivalbon.Enabled = true;

            }
            else
            {
                festivalbon.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                overtime.Enabled = true;

            }
            else
            {
                overtime.Enabled = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                otr.Enabled = true;

            }
            else
            {
                otr.Enabled = false;
            }
        }

        private void editEPF_Click(object sender, EventArgs e)
        {
            float epfperc = float.Parse(epf.Text);
            float etfperc = float.Parse(etf.Text);
            float festbonperc = float.Parse(festivalbon.Text);
            float overtimeperc = float.Parse(overtime.Text);
            float otherperc = float.Parse(otr.Text);

            string Query = " UPDATE percentage set Epf = '" + epfperc + "'";
            function.adddetails(Query,CON);
            epf.Enabled = false;
            MessageBox.Show("Success");

        }

        private void editETF_Click(object sender, EventArgs e)
        {
            float etfperc = float.Parse(etf.Text);
            float festbonperc = float.Parse(festivalbon.Text);
            float overtimeperc = float.Parse(overtime.Text);
            float otherperc = float.Parse(otr.Text);

            string Query = " UPDATE percentage set epf = '" + etfperc + "'";
            function.adddetails(Query, CON);
            etf.Enabled = false;
            MessageBox.Show("Success");
        }

        private void editBon_Click(object sender, EventArgs e)
        {
            float festbonperc = float.Parse(festivalbon.Text);
            float overtimeperc = float.Parse(overtime.Text);
            float otherperc = float.Parse(otr.Text);

            string Query = " UPDATE percentage set festivalbon = '" + festbonperc + "'";
            function.adddetails(Query, CON);
            festivalbon.Enabled = false;
            MessageBox.Show("Success");
        }

        private void editOT_Click(object sender, EventArgs e)
        {
            float overtimeperc = float.Parse(overtime.Text);
            float otherperc = float.Parse(otr.Text);

            string Query = " UPDATE percentage set OverTime = '" + overtimeperc + "'";
            function.adddetails(Query, CON);
            overtime.Enabled = false;
            MessageBox.Show("Success");
        }

        private void editOther_Click(object sender, EventArgs e)
        {
            float otherperc = float.Parse(otr.Text);

            string Query = " UPDATE percentage set other = '" + otherperc + "'";
            function.adddetails(Query, CON);
            otr.Enabled = false;
            MessageBox.Show("Success");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                etf.Enabled = true;

            }
            else
            {
                etf.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            pay frm = new pay();
            frm.ShowDialog();

           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            //geting the output by payroll month
            try
            {
                DateTime fromd = dateTimePicker2.Value.Date;
                String fromdate = fromd.ToString("yyyy/MM/20");


                string qry4 = "select ReferenceID,empID,Name,BasicSalary,JoiningDate,Address,Epf,Etf,Tax,Deduction,OvertimeHour,OvertimeRate,FestivalBonus,OtherAlowance,OtherAlowanceRate,LeaveTaken,LeaveDeduction,PresentDays,AprovedLeave,fromDate,PayrollDate,Allowance,NetSalary,Status from Payroll where PayrollDate='" + fromdate + "'";
                function.DisplayData(qry4, dataGridView1, CON); 
              

              

             

            }
            catch (Exception ex)
            {
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //refresing the datagridview
            string qry4 = "select ReferenceID,empID,Name,BasicSalary,JoiningDate,Address,Epf,Etf,Tax,Deduction,OvertimeHour,OvertimeRate,FestivalBonus,OtherAlowance,OtherAlowanceRate,LeaveTaken,LeaveDeduction,PresentDays,AprovedLeave,fromDate,PayrollDate,Allowance,NetSalary,Status from Payroll";
            function.DisplayData(qry4, dataGridView1, CON);
        }
    }
    }

