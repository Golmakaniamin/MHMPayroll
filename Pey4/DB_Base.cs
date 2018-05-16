using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace Pey4
{
    class DB_Base
    {
        public static bool Look_Con0 = true;
        public static bool Look_Con1 = false;
        public static string Look_Con2 = "192.168.1.24";
        public static string Look_Con3 = "43D5A168893115F11956E36829741";
        public static string Look_Con4 = "v25f192510******";
        public static string Look_Con5 = "MHMGroup";
        public static string Look_Con6 = "2110-9004-8120";

        ////localhost sqlexpress
        //public static string Constr0 = @"AMINVAIO\SQLEXPRESS2005";
        //public static string Constr1 = "pey4";
        //public static Boolean Constr2 = false;
        //public static string Constr3 = "Amin_Pey4";
        //public static string Constr4 = "123456";

        ////Mostaghel sqlexpress
        //public static string Constr0 = @"SERVER\SQLEXPRESS";
        //public static string Constr1 = "pey4";
        //public static Boolean Constr2 = false;
        //public static string Constr3 = "Amin_Pey4";
        //public static string Constr4 = "123456789";

        //server negin
        //negin_q2w3e4
        public static string Constr0 = @"acc4\SQLEXPRESS";
        public static string Constr1 = "Pey4";
        public static Boolean Constr2 = false;
        public static string Constr3 = "Amin_Pey4";
        public static string Constr4 = "123456";

        ////laptop negin
        ////negin_q2w3e4
        //public static string Constr0 = @"LocalHost\SQLEXPRESS";
        //public static string Constr1 = "Pey4";
        //public static Boolean Constr2 = false;
        //public static string Constr3 = "Amin_Pey4";
        //public static string Constr4 = "123456";

        ////Karkhone negin
        ////negin_q2w3e4
        //public static string Constr0 = @"NEGINTEX-EB030A\SQLEXPRESS";
        //public static string Constr1 = "Pey4";
        //public static Boolean Constr2 = false;
        //public static string Constr3 = "pey4_mali";
        //public static string Constr4 = "123456";

        ////server sabzKosh
        ////st4
        //public static string Constr0 = @"st4\SQLEXPRESS";
        //public static string Constr1 = "Pey4";
        //public static Boolean Constr2 = false;
        //public static string Constr3 = "Pey4_sabz_kosh";
        //public static string Constr4 = "123456";

        ////server sanayenimehadi
        ////server-karbord
        //public static string Constr0 = @"server-karbord\SQLEXPRESS";
        //public static string Constr1 = "pey4";
        //public static Boolean Constr2 = false;
        //public static string Constr3 = "Amin_Pey4";
        //public static string Constr4 = "17830294";

        public static string ConStr = "Data Source=" + Constr0 + ";Initial Catalog=" + Constr1 + ";Persist Security Info=" + Constr2 + ";User ID=" + Constr3 + ";Password=" + Constr4 + "";

        public SqlConnection objConnection = new SqlConnection();
        public SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        public SqlCommand objCommand = new SqlCommand();

        public void Connection_Open()
        {
            //try
            //{
                objConnection.Open();
            //}
            //catch
            //{
            //    System.Windows.Forms.MessageBox.Show("خطا در اتصال پایگاه داده");
            //    Environment.Exit(1);
            //}
        }

        public void Connection_Close()
        {
           objConnection.Close();
        }

        public DB_Base()
        {
            objDataAdapter.SelectCommand = new SqlCommand();
            objConnection.ConnectionString = ConStr;
            objDataAdapter.SelectCommand.Connection = objConnection;
            objCommand.Connection = objConnection;
        }

        public int Fill(string Qry, DataSet objDataSet, string TableName, bool ClearTable)
        {
            objDataAdapter.SelectCommand.CommandText = Qry;
            if (ClearTable == true)
                if (objDataSet.Tables[TableName] != null)
                    objDataSet.Tables[TableName].Clear();
            return (objDataAdapter.Fill(objDataSet, TableName));
        }

        public int ExecuteNonQuery(string Qry)
        {
            objCommand.CommandText = Qry;
            return (objCommand.ExecuteNonQuery());
        }

        public object ExecuteScalar(string Qry)
        {
            objCommand.CommandText = Qry;
            return (objCommand.ExecuteScalar());
        }

        public bool Is_Numeric(string Number)
        {
            int i;
            for (i = 0; i < Number.Length; i++)
                if ((Number[i] > '9') || (Number[i] < '0'))
                    return (false);
            return (true);
        }

        public bool Is_Nominal(string Word)
        {
            string unicode = null;
            for (int i = 0; i < Word.Length; i++)
            {
                unicode = string.Format("{0:x4}", (int)Word[i]);
                switch (unicode)
                {
                    case "0627":  //ا
                    case "0622":  //آ
                    case "0628":  //ب
                    case "067E":  //پ
                    case "062A":  //ت
                    case "062B":  //ث
                    case "062C":  //ج
                    case "0686":  //چ
                    case "062D":  //ح
                    case "062E":  //خ
                    case "062F":  //د
                    case "0630":  //ذ
                    case "0631":  //ر
                    case "0632":  //ز
                    case "0698":  //ژ
                    case "0633":  //س
                    case "0634":  //ش
                    case "0635":  //ص
                    case "0636":  //ض
                    case "0637":  //ط
                    case "0638":  //ظ
                    case "0639":  //ع
                    case "063A":  //غ
                    case "0641":  //ف
                    case "0642":  //ق
                    case "0643":  //ک
                    case "06AF":  //گ
                    case "0644":  //ل
                    case "0645":  //م
                    case "0646":  //ن
                    case "0648":  //و
                    case "0647":  //ه
                    case "064A":  //ی عربی
                    case "0649":  //ی
                    case "06CC":  //ی فارسی
                        return true;
                }
            }
            return false;
        }

        public string u_date()
        {
            int y, m, d;
            PersianCalendar pr = new PersianCalendar();
            d = pr.GetDayOfMonth(DateTime.Now);
            m = pr.GetMonth(DateTime.Now);
            y = pr.GetYear(DateTime.Now);
            String date;
            date = y.ToString().PadLeft(2, '0') + "/" + m.ToString().PadLeft(2, '0')+ "/" + d.ToString().PadLeft(2, '0');
            return (date);
        }

        public string u_time()
        {
            String time;
            time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            return (time);
        }

        public string u_pc()
        {
            String Coumpute_name1;
            Coumpute_name1 = System.Windows.Forms.SystemInformation.ComputerName.ToString();
            return (Coumpute_name1);
        }

        public int Look_base()
        {
            TINYLib.Tiny amin = new TINYLib.Tiny();
            if (Look_Con0 == true)
            {
                if (Look_Con1 == true)
                {
                    amin.ServerIP = Look_Con2;
                    amin.NetWorkINIT = Look_Con1;
                }
                else
                {
                    amin.Initialize = true;
                }
                if (amin.TinyErrCode == 0)
                {
                    amin.UserPassWord = Look_Con3;
                    amin.SpecialID = Look_Con4;
                    amin.ShowTinyInfo = true;

                    if (amin.TinyErrCode == 0)
                        if (amin.DataPartition == Look_Con5)
                            if (amin.SerialNumber == Look_Con6)
                                return (0);
                            else
                                return (amin.TinyErrCode);
                        else
                            return (amin.TinyErrCode);
                    else
                        return (amin.TinyErrCode);
                }
                else
                    return (amin.TinyErrCode);
            }
            else
            {
                return (0);
            }
        }

        public string FixPersianString(string text)
        {

            if (text == null)
                return null;

            text = text.Replace("\u0660", "\u06F0"); // ۰
            text = text.Replace("\u0661", "\u06F1"); // ۱
            text = text.Replace("\u0662", "\u06F2"); // ۲
            text = text.Replace("\u0663", "\u06F3"); // ۳
            text = text.Replace("\u0664", "\u06F4"); // ۴
            text = text.Replace("\u0665", "\u06F5"); // ۵
            text = text.Replace("\u0666", "\u06F6"); // ۶
            text = text.Replace("\u0667", "\u06F7"); // ۷
            text = text.Replace("\u0668", "\u06F8"); // ۸
            text = text.Replace("\u0669", "\u06F9"); // ۹
            text = text.Replace("\u0643", "\u06A9"); // ک
            text = text.Replace("\u0649", "\u06CC"); // ی
            text = text.Replace("\u064A", "\u06CC"); // ی
            text = text.Replace("\u06C0", "\u0647\u0654"); // هٔ

            return text;
        }
    }
}
