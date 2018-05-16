using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Pey4
{
    class U_Base
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public string u_date()
        {
            Database.Connection_Open();
            Database.Fill("SELECT GETDATE() AS Expr1, DATEPART(HOUR, GETDATE()) AS Expr2, DATEPART(MINUTE, GETDATE()) AS Expr3, DATEPART(SECOND, GETDATE()) AS Expr4", objDataSet, "Server_Date1", true);
            Database.Connection_Close();

            int y, m, d;
            PersianCalendar pr = new PersianCalendar();
            string amin = objDataSet.Tables["Server_Date1"].Rows[0]["Expr1"].ToString();

            d = pr.GetDayOfMonth(Convert.ToDateTime(amin));
            m = pr.GetMonth(Convert.ToDateTime(amin));
            y = pr.GetYear(Convert.ToDateTime(amin));

            string date;
            date = y.ToString().PadLeft(2, '0') + "/" + m.ToString().PadLeft(2, '0') + "/" + d.ToString().PadLeft(2, '0');
            return (date);
        }

        public string u_time()
        {
            Database.Connection_Open();
            Database.Fill("SELECT GETDATE() AS Expr1, DATEPART(HOUR, GETDATE()) AS Expr2, DATEPART(MINUTE, GETDATE()) AS Expr3, DATEPART(SECOND, GETDATE()) AS Expr4", objDataSet, "Server_Date1", true);
            Database.Connection_Close();

            string time;
            time = objDataSet.Tables["Server_Date1"].Rows[0]["Expr2"].ToString().PadLeft(2, '0') + ":" + objDataSet.Tables["Server_Date1"].Rows[0]["Expr3"].ToString().PadLeft(2, '0') + ":" + objDataSet.Tables["Server_Date1"].Rows[0]["Expr4"].ToString().PadLeft(2, '0');
            return (time);
        }

        public string u_pc()
        {
            string Coumpute_name1 = "";
            Coumpute_name1 = WindowsIdentity.GetCurrent().Name.ToString();
            return (Coumpute_name1);
        }

        public string u_user()
        {
            string User_name1 = "";
            string file_name = @"C:\AUTOEXEC.dll";
            string[] installs = new string[1];
            installs = System.IO.File.ReadAllLines(file_name, Encoding.Unicode);
            User_name1 = installs[0];

            Database.Connection_Open();
            Database.Fill("SELECT (log_Name + ' ' + log_Family) AS name1 FROM Tbl_login WHERE (tmpid = " + User_name1 + ")", objDataSet, "Select_C_user", true);
            Database.Connection_Close();

            return (objDataSet.Tables["Select_C_user"].Rows[0]["name1"].ToString());
        }

        public int u_user_sec(int tmpid_level)
        {
            string file_name = @"C:\AUTOEXEC.dll";
            string[] installs = new string[1];
            installs = System.IO.File.ReadAllLines(file_name, Encoding.Unicode);

            string user_code = installs[0];

            Database.Connection_Open();
            Database.Fill("SELECT * FROM Tbl_Login_IN WHERE ((tmpid_login = '" + user_code + "') AND (tmpid_level = '" + tmpid_level + "'))", objDataSet, "Tbl_Login_IN", true);
            Database.Connection_Close();

            return (objDataSet.Tables["Tbl_Login_IN"].Rows.Count);
        }

        public void u_amal_register(string amal1)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "INSERT INTO User_Amal (amal,uuser,udate,utime,upc) VALUES (@amal,@uuser,@udate,@utime,@upc)";
            objCommand.Parameters.AddWithValue("@amal", amal1);
            objCommand.Parameters.AddWithValue("@uuser", u_user());
            objCommand.Parameters.AddWithValue("@udate", u_date());
            objCommand.Parameters.AddWithValue("@utime", u_time());
            objCommand.Parameters.AddWithValue("@upc", u_pc());
            
            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objConnection.Close();
        }
    }
}
