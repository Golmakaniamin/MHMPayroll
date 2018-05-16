using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace Pey4
{
    class Db_Combo : System.Windows.Forms.ComboBox
    {
        System.Data.DataSet objDataSet = new System.Data.DataSet();
        public Db_Combo()
        {
        }

        public Db_Combo(string Qry, string DisplayMember, string ValueMember)
        {
            Bind_Data1(Qry, DisplayMember, ValueMember);
        }

        public void Bind_Data1(string Qry, string DisplayMember, string ValueMember)
        {
            DB_Base DataBase = new DB_Base();

            DataBase.Connection_Open();
            DataBase.Fill(Qry, objDataSet, "MyTble", true);
            DataBase.Connection_Close();

            this.DataSource = objDataSet.Tables["MyTble"];
            this.DisplayMember = DisplayMember;
            this.ValueMember = ValueMember;
        }
    }
}