using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pey4
{
    public partial class Form2 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        public DataSet objDataSet = new DataSet();

        DB_Base database = new DB_Base();
        U_Base U_set = new U_Base();

        public string id_year;
        public string id_moon;
        public string id_group;

        public string personel_tmpid;
        public string personel_name;
        public string personel_type1;

        public Form2()
        {
            InitializeComponent();
        }

        public void Form_Load_set_color()
        {
            DataSet objDataSet1 = new DataSet();

            database.Connection_Open();
            database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet1, "Color_Font_Set", true);
            database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

            foreach (SplitContainer spc in this.Controls)
            {
                foreach (Control ct in spc.Panel2.Controls)
                {
                    if (ct.GetType() == typeof(Button))
                    {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                        Font newFont = (Font)tc.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[13]["promp"].ToString());
                        ct.Font = newFont;

                        TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                        Color newColor = (Color)tc1.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[14]["promp"].ToString());
                        ct.ForeColor = newColor;
                    }
                }
            }
            this.BackColor = newColor0;

            TypeConverter tc2 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont2 = (Font)tc2.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[2]["promp"].ToString());

            TypeConverter tc3 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor3 = (Color)tc3.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[8]["promp"].ToString());

            TypeConverter tc7 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont7 = (Font)tc7.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[7]["promp"].ToString());

            TypeConverter tc8 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor8 = (Color)tc8.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[8]["promp"].ToString());

            TypeConverter tc9 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor9 = (Color)tc9.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[9]["promp"].ToString());

            TypeConverter tc10 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor10 = (Color)tc10.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[10]["promp"].ToString());

            TypeConverter tc11 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor11 = (Color)tc11.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[11]["promp"].ToString());

            TypeConverter tc12 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor12 = (Color)tc12.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[12]["promp"].ToString());

            DataGridViewCellStyle objAlignRightCellStyle1 = new DataGridViewCellStyle();
            objAlignRightCellStyle1.Font = newFont2;
            objAlignRightCellStyle1.BackColor = newColor3;

            DataGridViewCellStyle objAlignRightCellStyle2 = new DataGridViewCellStyle();
            objAlignRightCellStyle2.BackColor = newColor9;
            objAlignRightCellStyle2.ForeColor = newColor10;

            DataGridViewCellStyle objAlignRightCellStyle3 = new DataGridViewCellStyle();
            objAlignRightCellStyle3.BackColor = newColor11;
            objAlignRightCellStyle3.ForeColor = newColor12;

            dataGridView1.Font = newFont7;
            dataGridView1.BackgroundColor = newColor8;
            dataGridView1.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridView1.DefaultCellStyle = objAlignRightCellStyle3;

            objDataSet1.Clear();
        }

        private void Form_sec()
        {
            if (U_set.u_user_sec(16) == 0) { dataGridView1.AllowUserToAddRows = false;}
            if (U_set.u_user_sec(17) == 0) { dataGridView1.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { dataGridView1.AllowUserToDeleteRows = false; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            String Alltxtor;
            
            if (objDataSet.Tables["tbl_personel"].Rows.Count > 0)
            {
                Alltxtor = "";
                for (int q = 0; q <= objDataSet.Tables["tbl_personel"].Rows.Count-1; q++)
                {
                    if (objDataSet.Tables["tbl_personel"].Rows[q]["selectid"].ToString() == "True")
                    {
                        database.Connection_Open();
                        database.Fill("SELECT * FROM Tbl_karkard WHERE (idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (type1=" + personel_type1 + ") AND (idpersonal=" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + ")", objDataSet, "textexistTbl_karkard", true);
                        database.Connection_Close();

                        if (objDataSet.Tables["textexistTbl_karkard"].Rows.Count.ToString() == "0")
                        {
                            SqlCommand objCommand = new SqlCommand();
                            objCommand.Connection = objConnection;
                            objCommand.CommandText = "INSERT INTO Tbl_karkard (idgroup,idyear,idmoon,idpersonal,type1) VALUES (@idgroup,@idyear,@idmoon,@idpersonal,@type1)";
                            objCommand.CommandType = CommandType.Text;
                            objCommand.Parameters.AddWithValue("@idgroup", id_group);
                            objCommand.Parameters.AddWithValue("@idyear", id_year);
                            objCommand.Parameters.AddWithValue("@idmoon", id_moon);
                            objCommand.Parameters.AddWithValue("@idpersonal", objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString());
                            objCommand.Parameters.AddWithValue("@type1", personel_type1);
                            objConnection.Open();
                            objCommand.ExecuteNonQuery();
                            objConnection.Close();

                            objDataSet.Tables["textexistTbl_karkard"].Clear();
                        }

                        Alltxtor += " (a.idpersonal=" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + ") OR ";
                    }
                }

                if (Alltxtor.Length > 0)
                {
                    Alltxtor = Alltxtor.Substring(1, Alltxtor.Length - 4);

                    database.Connection_Open();
                    database.Fill("SELECT b.code ,b.name ,b.family ,b.name_pedar ,b.cod_mely ,a.q1 ,a.q6 ,a.q2 ,a.q3 ,a.q4 ,a.q5 ,a.tmpid FROM Tbl_karkard AS a INNER JOIN tbl_personel AS b ON a.idpersonal = b.tmpid AND a.idgroup = b.idgroup WHERE ((a.idgroup=" + id_group + ") AND (a.idyear=" + id_year + ") AND (a.idmoon=" + id_moon + ") AND (a.type1=" + personel_type1 + ") AND (b.NoeHoghog IN (1,2)) AND (" + Alltxtor + "))", objDataSet, "Tbl_karkardfill", true);
                    database.Connection_Close();

                    database.Connection_Open();
                    database.Fill("SELECT * FROM Tbl_karkard AS a WHERE ((a.idgroup=" + id_group + ") AND (a.idyear=" + id_year + ") AND (a.idmoon=" + id_moon + ") AND (a.type1=" + personel_type1 + ") AND (" + Alltxtor + "))", objDataSet, "Tbl_karkardmain", true);
                    database.Connection_Close();

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = objDataSet;
                    dataGridView1.DataMember = "Tbl_karkardfill";

                    dataGridView1.Columns[0].HeaderText = "کد پرسنل";
                    dataGridView1.Columns[1].HeaderText = "نام";
                    dataGridView1.Columns[2].HeaderText = "نام خانوادگی";
                    dataGridView1.Columns[3].HeaderText = "نام پدر";
                    dataGridView1.Columns[4].HeaderText = "کد ملی";
                    dataGridView1.Columns[5].HeaderText = "مرخصی بدون حقوق";
                    dataGridView1.Columns[6].HeaderText = "مرخصی با حقوق";
                    dataGridView1.Columns[7].HeaderText = "ساعات اضافه کار عادی";
                    dataGridView1.Columns[8].HeaderText = "ساعات اضافه کار تعطیلی";
                    dataGridView1.Columns[9].HeaderText = "ساعات تاخیر ورود";
                    dataGridView1.Columns[10].HeaderText= "ساعات تعجیل خروج";
                    dataGridView1.Columns[11].Visible = false;
                }
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (objDataSet.HasChanges())
            {
                for (int q = 0; q <= objDataSet.Tables["Tbl_karkardfill"].Rows.Count - 1; q++)
                {
                    //if (objDataSet.Tables["Tbl_karkardfill"].Rows[q].RowState.ToString() == "Modified")
                    if (objDataSet.Tables["Tbl_karkardfill"].Rows[q].RowState.ToString() != "Deleted")
                    {
                        objDataSet.Tables["Tbl_karkardmain"].Rows[q]["q1"] = objDataSet.Tables["Tbl_karkardfill"].Rows[q]["q1"];
                        objDataSet.Tables["Tbl_karkardmain"].Rows[q]["q2"] = objDataSet.Tables["Tbl_karkardfill"].Rows[q]["q2"];
                        objDataSet.Tables["Tbl_karkardmain"].Rows[q]["q3"] = objDataSet.Tables["Tbl_karkardfill"].Rows[q]["q3"];
                        objDataSet.Tables["Tbl_karkardmain"].Rows[q]["q4"] = objDataSet.Tables["Tbl_karkardfill"].Rows[q]["q4"];
                        objDataSet.Tables["Tbl_karkardmain"].Rows[q]["q5"] = objDataSet.Tables["Tbl_karkardfill"].Rows[q]["q5"];
                        objDataSet.Tables["Tbl_karkardmain"].Rows[q]["q6"] = objDataSet.Tables["Tbl_karkardfill"].Rows[q]["q6"];
                    }
                }

                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(objDataSet, "Tbl_karkardmain");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void butt_ok_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string amin1 = "({Print_Karkard;1.idgroup}=" + id_group + ") AND ({Print_Karkard;1.idyear}=" + id_year + ") AND ({Print_Karkard;1.idmoon}=" + id_moon + ") AND ({Print_Karkard;1.type1}=" + personel_type1 + ")";

            Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
            f.selkar = "Report_Karkard";
            f.recore_sel = amin1;

            if (personel_type1 == "1")
                f.sarbarg = "T";
            else
                f.sarbarg = "G";

            f.Show();
        }
    }
}
