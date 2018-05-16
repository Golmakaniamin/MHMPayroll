using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Pey4
{
    public partial class Form18 : Form
    {
        W2D_D2W.ClsDos2Win D2W = new W2D_D2W.ClsDos2Win();
        W2D_D2W.ClsWin2Dos W2D = new W2D_D2W.ClsWin2Dos();

        DataSet objDataSet = new DataSet();
        DB_Base database = new DB_Base();

        public string id_year;
        public string id_moon;
        public string id_group;

        public Form18()
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
                foreach (Control ct in spc.Panel1.Controls)
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

        private void Form18_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file_name = Application.StartupPath.ToString() + @"\Bimeh\";

            OleDbConnection objConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_name + ";Extended Properties=dBASE IV;");
            OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            DataSet objDataSet = new DataSet();

            objDataSet.Clear();

            objDataAdapter.SelectCommand = new OleDbCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM DSKWOR00";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            objConnection.Open();
            objDataAdapter.Fill(objDataSet, "DSKWOR00");
            objConnection.Close();

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "DSKWOR00";

            if (objDataSet.HasChanges())
            {
                OleDbCommandBuilder cb = new OleDbCommandBuilder(objDataAdapter);
                if (objDataSet.Tables["DSKWOR00"].Rows.Count > 0)
                {
                    objConnection.Open();
                    cb.DataAdapter.Update(objDataSet, "DSKWOR00");
                    objConnection.Close();
                }
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //string file_name = Application.StartupPath.ToString() + @"\Bimeh\";

            //OleDbConnection objConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_name + ";Extended Properties=dBASE IV;");
            //OleDbDataAdapter objDataAdapter = new OleDbDataAdapter();
            //DataSet objDataSet = new DataSet();

            //OleDbCommand objCommand = new OleDbCommand();
            //objCommand.Connection = objConnection;
            //objCommand.CommandText = "INSERT INTO DSKWOR00 (DSW_ID ,DSW_YY ,DSW_MM ,DSW_LISTNO ,DSW_ID1 ,DSW_FNAME ,DSW_LNAME ,DSW_DNAME ,DSW_IDNO ,DSW_IDPLC ,DSW_IDATE ,DSW_BDATE ,DSW_SEX ,DSW_NAT ,DSW_OCP ,DSW_SDATE ,DSW_EDATE ,DSW_DD ,DSW_ROOZ ,DSW_MAH ,DSW_MAZ ,DSW_MASH ,DSW_TOTL ,DSW_BIME ,DSW_PRATE ,DSW_JOB ,PER_NATCOD) VALUES (@DSW_ID ,@DSW_YY ,@DSW_MM ,@DSW_LISTNO ,@DSW_ID1 ,@DSW_FNAME ,@DSW_LNAME ,@DSW_DNAME ,@DSW_IDNO ,@DSW_IDPLC ,@DSW_IDATE ,@DSW_BDATE ,@DSW_SEX ,@DSW_NAT ,@DSW_OCP ,@DSW_SDATE ,@DSW_EDATE ,@DSW_DD ,@DSW_ROOZ ,@DSW_MAH ,@DSW_MAZ ,@DSW_MASH ,@DSW_TOTL ,@DSW_BIME ,@DSW_PRATE ,@DSW_JOB ,@PER_NATCOD)";
            //objCommand.CommandType = CommandType.Text;
            //objCommand.Parameters.AddWithValue("@DSW_ID", "0");
            //objCommand.Parameters.AddWithValue("@DSW_YY", "0");
            //objCommand.Parameters.AddWithValue("@DSW_MM", "0");
            //objCommand.Parameters.AddWithValue("@DSW_LISTNO", "0");
            //objCommand.Parameters.AddWithValue("@DSW_ID1", "0");
            //objCommand.Parameters.AddWithValue("@DSW_FNAME", "0");
            //objCommand.Parameters.AddWithValue("@DSW_LNAME", "0");
            //objCommand.Parameters.AddWithValue("@DSW_DNAME", "0");
            //objCommand.Parameters.AddWithValue("@DSW_IDNO", "0");
            //objCommand.Parameters.AddWithValue("@DSW_IDPLC", "0");
            //objCommand.Parameters.AddWithValue("@DSW_IDATE", "0");
            //objCommand.Parameters.AddWithValue("@DSW_BDATE", "0");
            //objCommand.Parameters.AddWithValue("@DSW_SEX", "0");
            //objCommand.Parameters.AddWithValue("@DSW_NAT", "0");
            //objCommand.Parameters.AddWithValue("@DSW_OCP", "0");
            //objCommand.Parameters.AddWithValue("@DSW_SDATE", "0");
            //objCommand.Parameters.AddWithValue("@DSW_EDATE", "0");
            //objCommand.Parameters.AddWithValue("@DSW_DD", "0");
            //objCommand.Parameters.AddWithValue("@DSW_ROOZ", "0");
            //objCommand.Parameters.AddWithValue("@DSW_MAH", "0");
            //objCommand.Parameters.AddWithValue("@DSW_MAZ", "0");
            //objCommand.Parameters.AddWithValue("@DSW_MASH", "0");
            //objCommand.Parameters.AddWithValue("@DSW_TOTL", "0");
            //objCommand.Parameters.AddWithValue("@DSW_BIME", "0");
            //objCommand.Parameters.AddWithValue("@DSW_PRATE", "0");
            //objCommand.Parameters.AddWithValue("@DSW_JOB", "0");
            //objCommand.Parameters.AddWithValue("@PER_NATCOD", "0");
            //objConnection.Open();
            //try
            //{
            //    objCommand.ExecuteNonQuery();
            //}
            //catch
            //{
            //}
            //objConnection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            if (Directory.Exists(textBox1.Text) == true)
            {
                string file_name = Application.StartupPath.ToString() + @"\Bimeh\";

                File.Copy(file_name + @"\AminNull\DSKKAR00.DBF", file_name + @"\DSKKAR00.DBF",true);
                File.Copy(file_name + @"\AminNull\DSKWOR00.DBF", file_name + @"\DSKWOR00.DBF", true);

                OleDbConnection objConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_name + ";Extended Properties=dBASE IV;");

                database.Connection_Open();
                database.Fill("SELECT * FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 2 AND tbl_personel.list1 = 1 WHERE (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process_Fill", true);
                database.Connection_Close();

                database.Connection_Open();
                database.Fill("SELECT * FROM Tab_Shrkat WHERE (tmpid=" + id_group + ")", objDataSet, "Tab_Shrkat", true);
                database.Connection_Close();

                if (objDataSet.Tables["Tbl_process_Fill"].Rows.Count > 0)
                {
                    for (int q = 0; q <= objDataSet.Tables["Tbl_process_Fill"].Rows.Count - 1; q++)
                    {
                        OleDbCommand objCommand = new OleDbCommand();
                        objCommand.Connection = objConnection;
                        objCommand.CommandText = "INSERT INTO DSKWOR00 (DSW_ID ,DSW_YY ,DSW_MM ,DSW_LISTNO ,DSW_ID1 ,DSW_FNAME ,DSW_LNAME ,DSW_DNAME ,DSW_IDNO ,DSW_IDPLC ,DSW_IDATE ,DSW_BDATE ,DSW_SEX ,DSW_NAT ,DSW_OCP ,DSW_SDATE ,DSW_EDATE ,DSW_DD ,DSW_ROOZ ,DSW_MAH ,DSW_MAZ ,DSW_MASH ,DSW_TOTL ,DSW_BIME ,DSW_PRATE ,DSW_JOB ,PER_NATCOD) VALUES (@DSW_ID ,@DSW_YY ,@DSW_MM ,@DSW_LISTNO ,@DSW_ID1 ,@DSW_FNAME ,@DSW_LNAME ,@DSW_DNAME ,@DSW_IDNO ,@DSW_IDPLC ,@DSW_IDATE ,@DSW_BDATE ,@DSW_SEX ,@DSW_NAT ,@DSW_OCP ,@DSW_SDATE ,@DSW_EDATE ,@DSW_DD ,@DSW_ROOZ ,@DSW_MAH ,@DSW_MAZ ,@DSW_MASH ,@DSW_TOTL ,@DSW_BIME ,@DSW_PRATE ,@DSW_JOB ,@PER_NATCOD)";
                        objCommand.CommandType = CommandType.Text;
                        objCommand.Parameters.AddWithValue("@DSW_ID", objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_kargah"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_YY", id_year.ToString().Substring(2, 2));
                        objCommand.Parameters.AddWithValue("@DSW_MM", id_moon);
                        objCommand.Parameters.AddWithValue("@DSW_LISTNO", "2");
                        objCommand.Parameters.AddWithValue("@DSW_ID1", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["sh_bimeh"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_FNAME", W2D.Win2Dos(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["name"].ToString().Replace("ی", "ي")));
                        objCommand.Parameters.AddWithValue("@DSW_LNAME", W2D.Win2Dos(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["family"].ToString().Replace("ی", "ي")));
                        objCommand.Parameters.AddWithValue("@DSW_DNAME", W2D.Win2Dos(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["name_pedar"].ToString().Replace("ی", "ي")));
                        objCommand.Parameters.AddWithValue("@DSW_IDNO", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["sh_sh"].ToString());

                        //محل صدور
                        database.Connection_Open();
                        database.Fill("SELECT Code, Desc1 FROM Bimeh_City WHERE (Code=" + objDataSet.Tables["Tbl_process_Fill"].Rows[q]["bimeh_shahr"].ToString() + ")", objDataSet, "bimeh_shahr", true);
                        database.Connection_Close();
                        objCommand.Parameters.AddWithValue("@DSW_IDPLC", W2D.Win2Dos(objDataSet.Tables["bimeh_shahr"].Rows[0]["Desc1"].ToString().Replace("ی", "ي")));
                        objDataSet.Tables["bimeh_shahr"].Clear();

                        objCommand.Parameters.AddWithValue("@DSW_IDATE", "0");
                        objCommand.Parameters.AddWithValue("@DSW_BDATE", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["brithdate"].ToString().Substring(2, 8));
                        objCommand.Parameters.AddWithValue("@DSW_SEX", W2D.Win2Dos(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["sex"].ToString().Replace("ی", "ي")));
                        objCommand.Parameters.AddWithValue("@DSW_NAT", W2D.Win2Dos(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["bimeh_meliat"].ToString().Replace("ی", "ي")));

                        database.Connection_Open();
                        database.Fill("SELECT Job_Code, Job_Desc FROM Bimeh_tab_job WHERE (Job_Code='" + objDataSet.Tables["Tbl_process_Fill"].Rows[q]["bimeh_mashagel"].ToString() + "')", objDataSet, "bimeh_mashagel", true);
                        database.Connection_Close();
                        objCommand.Parameters.AddWithValue("@DSW_OCP", W2D.Win2Dos(objDataSet.Tables["bimeh_mashagel"].Rows[0]["Job_Desc"].ToString().Replace("ی", "ي")));
                        objDataSet.Tables["bimeh_mashagel"].Clear();

                        if (objDataSet.Tables["Tbl_process_Fill"].Rows[q]["data_estekhdam"].ToString().Substring(2, 8) == @"00/00/00")
                        { objCommand.Parameters.AddWithValue("@DSW_SDATE", ""); }
                        else
                        { objCommand.Parameters.AddWithValue("@DSW_SDATE", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["data_estekhdam"].ToString().Substring(2, 8)); }

                        if (objDataSet.Tables["Tbl_process_Fill"].Rows[q]["data_tarkkar"].ToString().Substring(2, 8) == @"00/00/00")
                        { objCommand.Parameters.AddWithValue("@DSW_EDATE", ""); }
                        else
                        { objCommand.Parameters.AddWithValue("@DSW_EDATE", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["data_tarkkar"].ToString().Substring(2, 8)); }

                        objCommand.Parameters.AddWithValue("@DSW_DD", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["w2"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_ROOZ", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["w3"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_MAH", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["w4"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_MAZ", (Convert.ToInt64(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["SUM_mazaya"]) + Convert.ToInt64(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["w5"]) + Convert.ToInt64(objDataSet.Tables["Tbl_process_Fill"].Rows[q]["w6"])));
                        objCommand.Parameters.AddWithValue("@DSW_MASH", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["SUM_MASHMOL_BIMEH"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_TOTL", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["SUM_MASHMOL_BIMEH"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_BIME", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["Haghe_bime_personal"].ToString());
                        objCommand.Parameters.AddWithValue("@DSW_PRATE", "0");
                        objCommand.Parameters.AddWithValue("@DSW_JOB", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["bimeh_mashagel"].ToString());
                        objCommand.Parameters.AddWithValue("@PER_NATCOD", objDataSet.Tables["Tbl_process_Fill"].Rows[q]["cod_mely"].ToString());

                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }


                    objDataSet.Clear();

                    database.Connection_Open();
                    database.Fill("SELECT ISNULL(Sum(w2),0) AS S_w2, ISNULL(Sum(w3),0) AS S_w3, ISNULL(Sum(w4),0) AS S_w4, ISNULL(Sum(w5),0) AS S_w5, ISNULL(Sum(w6),0) AS S_w6, ISNULL(Sum(SUM_mazaya),0) AS S_SUM_mazaya, ISNULL(Sum(SUM_MASHMOL_BIMEH),0) AS S_SUM_MASHMOL_BIMEH, ISNULL(Sum(Haghe_bime_personal),0) AS S_Haghe_bime_personal, ISNULL(Sum(Haghe_bime_karfarma),0) AS S_Haghe_bime_karfarma, ISNULL(Sum(Haghe_bime_bikari),0) AS S_Haghe_bime_bikari, ISNULL(Count(tbl_personel.tmpid),0) AS rsnumber, ISNULL(Sum(view_maliat),0) AS S_view_maliat FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 2 AND tbl_personel.list1 = 1 WHERE (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process", true);
                    database.Connection_Close();

                    database.Connection_Open();
                    database.Fill("SELECT * FROM Tab_Shrkat WHERE (tmpid=" + id_group + ")", objDataSet, "Tab_Shrkat", true);
                    database.Connection_Close();

                    database.Connection_Open();
                    database.Fill("SELECT * FROM Tbl_maliat WHERE (tmpid=1)", objDataSet, "Tbl_maliat", true);
                    database.Connection_Close();

                    OleDbCommand objCommand1 = new OleDbCommand();
                    objCommand1.Connection = objConnection;
                    objCommand1.CommandText = "INSERT INTO DSKKAR00 (DSK_ID ,DSK_NAME ,DSK_FARM ,DSK_KIND ,DSK_YY ,DSK_MM ,DSK_LISTNO ,DSK_DISC ,DSK_NUM ,DSK_TDD ,DSK_TROOZ ,DSK_TMAH ,DSK_TMAZ ,DSK_TMASH ,DSK_TTOTL ,DSK_TBIME ,DSK_TKOSO ,DSK_BIC ,DSK_RATE ,DSK_PRATE ,DSK_BIMH ,MON_PYM ,DSK_ADRS) VALUES (@DSK_ID ,@DSK_NAME ,@DSK_FARM ,@DSK_KIND ,@DSK_YY ,@DSK_MM ,@DSK_LISTNO ,@DSK_DISC ,@DSK_NUM ,@DSK_TDD ,@DSK_TROOZ ,@DSK_TMAH ,@DSK_TMAZ ,@DSK_TMASH ,@DSK_TTOTL ,@DSK_TBIME ,@DSK_TKOSO ,@DSK_BIC ,@DSK_RATE ,@DSK_PRATE ,@DSK_BIMH ,@MON_PYM ,@DSK_ADRS)";
                    objCommand1.CommandType = CommandType.Text;
                    objCommand1.Parameters.AddWithValue("@DSK_ID", objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_kargah"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_NAME", W2D.Win2Dos(objDataSet.Tables["Tab_Shrkat"].Rows[0]["name_shrkat"].ToString()));
                    objCommand1.Parameters.AddWithValue("@DSK_FARM", W2D.Win2Dos(objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_name"].ToString() + " " + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_family"].ToString()));
                    objCommand1.Parameters.AddWithValue("@DSK_KIND", "0");
                    objCommand1.Parameters.AddWithValue("@DSK_YY", id_year.ToString().Substring(2, 2));
                    objCommand1.Parameters.AddWithValue("@DSK_MM", id_moon);
                    objCommand1.Parameters.AddWithValue("@DSK_LISTNO", "2");
                    objCommand1.Parameters.AddWithValue("@DSK_DISC", "");
                    objCommand1.Parameters.AddWithValue("@DSK_NUM", objDataSet.Tables["Tbl_process"].Rows[0]["rsnumber"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TDD", objDataSet.Tables["Tbl_process"].Rows[0]["S_w2"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TROOZ", objDataSet.Tables["Tbl_process"].Rows[0]["S_w3"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TMAH", objDataSet.Tables["Tbl_process"].Rows[0]["S_w4"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TMAZ", (Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[0]["S_SUM_mazaya"]) + Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[0]["S_w5"]) + Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[0]["S_w6"])));
                    objCommand1.Parameters.AddWithValue("@DSK_TMASH", objDataSet.Tables["Tbl_process"].Rows[0]["S_SUM_MASHMOL_BIMEH"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TTOTL", objDataSet.Tables["Tbl_process"].Rows[0]["S_SUM_MASHMOL_BIMEH"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TBIME", objDataSet.Tables["Tbl_process"].Rows[0]["S_Haghe_bime_personal"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_TKOSO", objDataSet.Tables["Tbl_process"].Rows[0]["S_Haghe_bime_karfarma"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_BIC", objDataSet.Tables["Tbl_process"].Rows[0]["S_Haghe_bime_bikari"].ToString());
                    objCommand1.Parameters.AddWithValue("@DSK_RATE", "23");
                    objCommand1.Parameters.AddWithValue("@DSK_PRATE", "0");
                    objCommand1.Parameters.AddWithValue("@DSK_BIMH", "0");
                    objCommand1.Parameters.AddWithValue("@MON_PYM", "");
                    objCommand1.Parameters.AddWithValue("@DSK_ADRS", W2D.Win2Dos(objDataSet.Tables["Tab_Shrkat"].Rows[0]["address"].ToString()));

                    objConnection.Open();
                    objCommand1.ExecuteNonQuery();
                    objConnection.Close();

                    objDataSet.Clear();

                    File.Copy(file_name + @"\DSKKAR00.DBF", textBox1.Text + "DSKKAR00.DBF", true);
                    File.Copy(file_name + @"\DSKWOR00.DBF", textBox1.Text + "DSKWOR00.DBF", true);
                    MessageBox.Show("فایل ها در مسیر ساخته شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("پرسنلی در این ماه وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("مسیر مشخص شده وجود ندارد", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button4.Enabled = true;
        }
    }
}
