using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace EmployeeManagement
{
    class AutoGenerateID
    {
        
        public string AutoGenerateCode(string dbColName ,string DefVal, string dbTable )
        {
            SqlConnection con = ConnectionManager.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("select ISNULL(Max("+ dbColName + "),'"+DefVal+"') from "+ dbTable + "" , con);
            string ID = cmd.ExecuteScalar().ToString();
            con.Close();
            return ID;
        }
    }
}
