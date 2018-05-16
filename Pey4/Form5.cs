using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pey4
{
    public partial class Form5 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DataSet objDataSet1 = new DataSet();
        DataSet objDataSet2 = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base U_set = new U_Base();

        public string id_year;
        public string id_moon;
        public string id_group;

        public string lock1 = "1";

        public DataSet objDataSet = new DataSet();

        public Form5()
        {
            InitializeComponent();
        }

        private void FormLoad()
        {
            string amin_select = "0";

            if (grdAuthorTitles.SelectedRows.Count > 0)
                amin_select = grdAuthorTitles.SelectedRows[0].Index.ToString();

            objDataSet1.Clear();

            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT tmpid,selectid,code,name,family,name_pedar,sex,cod_mely,sh_sh FROM tbl_personel WHERE (idgroup = " + id_group + ") AND (idyear = " + id_year + ") AND (idmoon = " + id_moon + ")";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            objConnection.Open();
            objDataAdapter.Fill(objDataSet1, "tbl_personel");
            objConnection.Close();

            label2.Text = objDataSet1.Tables["tbl_personel"].Rows.Count.ToString();

            grdAuthorTitles.AutoGenerateColumns = true;
            grdAuthorTitles.DataSource = objDataSet1;
            grdAuthorTitles.DataMember = "tbl_personel";

            grdAuthorTitles.Columns[0].Visible = false;
            grdAuthorTitles.Columns[1].HeaderText = "انتخاب";
            grdAuthorTitles.Columns[2].HeaderText = "کد پرسنل";
            grdAuthorTitles.Columns[3].HeaderText = "نام";
            grdAuthorTitles.Columns[4].HeaderText = "نام خانوادگی";
            grdAuthorTitles.Columns[5].HeaderText = "نام پدر";
            grdAuthorTitles.Columns[6].HeaderText = "جنسیت";
            grdAuthorTitles.Columns[7].HeaderText = "کد ملی";
            grdAuthorTitles.Columns[8].HeaderText = "شماره شناسنامه";

            if ((objDataSet1.Tables["tbl_personel"].Rows.Count > 0) && (amin_select != "0"))
                grdAuthorTitles.Rows[Convert.ToInt16(amin_select)].Selected = true;
        }
        
        private void but_serch_Click(object sender, EventArgs e)
        {
            Bind_2_Grid_Good();
        }


        private void Bind_2_Grid_Good()
        {
            string Qry = "";
            string[] Search_Data;
            string search = Txt_Search.Text;
            //int i;

            //bool first = true;
            DB_Base fix = new DB_Base();

            if (Txt_Search.Text.Trim() == "")
            {
                FormLoad();
            }
            else
            {
                //Search_Data = fix.FixPersianString(Txt_Search.Text).Split(' ');
                Search_Data = Txt_Search.Text.Split(' ');

                Qry = "SELECT tmpid,selectid,code,name,family,name_pedar,sex,cod_mely,sh_sh FROM tbl_personel WHERE (";

                //for (i = 0; i < Search_Data.Length; i++)
                //{
                //    if (Search_Data[i].Trim() != "")
                //    {
                //        //if (first == false)
                //        //    Qry += "And";
                //        //Qry += "(";
                //        if (Database.Is_Numeric(Search_Data[i]))
                //        {
                //            Qry += "([code] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([cod_mely] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([sh_sh] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([code_posti] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([sh_bimeh] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([sh_hesab] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([tedah_farzand] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([phon_manzel] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([phon_sabt] like '%" + Search_Data[i] + "%')";
                //            Qry += "Or ([sh_kart] like '%" + Search_Data[i] + "%')";
                //        }
                //        else if (Database.Is_Nominal(Search_Data[i]))
                //            search += Search_Data[i];
                //        //first = false;
                //    }
                //}

                Qry += "(code LIKE '%" + search + "%')";
                Qry += " OR (name LIKE '%" + search + "%')";
                Qry += " OR (family LIKE '%" + search + "%')";
                Qry += " OR (name_pedar LIKE '%" + search + "%')";
                Qry += " OR (sex like '%" + search + "%')";
                Qry += " OR (cod_mely like '%" + search + "%')";
                Qry += " OR (sh_sh like '%" + search + "%')";
                Qry += ")";
                Qry += " AND ((idgroup = " + id_group + ") AND (idyear = " + id_year + ") AND (idmoon = " + id_moon + "))";
                
                //Qry += ")";
                //MessageBox.Show(Qry);

                objDataSet1.Tables["tbl_personel"].Clear();

                Database.Connection_Open();
                Database.Fill(Qry, objDataSet1, "tbl_personel", true);
                Database.Connection_Close();

                grdAuthorTitles.AutoGenerateColumns = true;
                grdAuthorTitles.DataSource = objDataSet1;
                grdAuthorTitles.DataMember = "tbl_personel";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.id_group = id_group.ToString();
            f1.id_year = id_year.ToString();
            f1.id_moon = id_moon.ToString();
            f1.personel_type1 = "1";
            f1.objDataSet = objDataSet1;

            f1.Text = " کارکرد توافقی " + this.Text.Substring(9, this.Text.Length - 9);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form22 f2 = new Form22();
            f2.personel_Code = "-1";
            f2.id_group = id_group.ToString();
            f2.id_year = id_year.ToString();
            f2.id_moon = id_moon.ToString();
            f2.state1 = "1";
            f2.Text = this.Text;
            f2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (objDataSet1.Tables["tbl_personel"].Rows.Count > 0)
            {
                for (int q = 0; q <= objDataSet1.Tables["tbl_personel"].Rows.Count - 1; q++)
                {
                    if (objDataSet1.Tables["tbl_personel"].Rows[q]["selectid"].ToString() == "True")
                    {
                        Form12 f12 = new Form12();
                        f12.id_group = id_group;
                        f12.id_year = id_year;
                        f12.id_moon = id_moon;
                        f12.id_idmen = objDataSet1.Tables["tbl_personel"].Rows[q]["code"].ToString();
                        f12.Text = " تعریف وام برای پرسنل شماره : " + objDataSet1.Tables["tbl_personel"].Rows[q]["code"].ToString() + "  ( " + objDataSet1.Tables["tbl_personel"].Rows[q]["name"].ToString() + " " + objDataSet1.Tables["tbl_personel"].Rows[q]["family"].ToString() + " )";
                        f12.Show();
                    }
                }
            }
       }

        private void Form5_Activated(object sender, EventArgs e)
        {
            //if (lock1 == "1") { FormLoad(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (objDataSet1.Tables["tbl_personel"].Rows.Count > 0)
            {
                for (int q = 0; q <= objDataSet1.Tables["tbl_personel"].Rows.Count - 1; q++)
                {
                    objDataSet1.Tables["tbl_personel"].Rows[q]["selectid"] = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (objDataSet1.Tables["tbl_personel"].Rows.Count > 0)
            {
                for (int q = 0; q <= objDataSet1.Tables["tbl_personel"].Rows.Count - 1; q++)
                {
                    objDataSet1.Tables["tbl_personel"].Rows[q]["selectid"] = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lock1 = "0";
            objDataSet2 = objDataSet1;

            DialogResult dialog = MessageBox.Show("در صورت تایید اطلاعات پرسنل از بین می رود، آیا اطمینان دارید؟", "حذف اطلاعات", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                if (objDataSet2.Tables["tbl_personel"].Rows.Count > 0)
                {
                    for (int q = 0; q <= objDataSet2.Tables["tbl_personel"].Rows.Count - 1; q++)
                    {
                        if (objDataSet2.Tables["tbl_personel"].Rows[q]["selectid"].ToString() == "True")
                        {
                            //جدول پرسنل
                            SqlCommand delete1 = new SqlCommand();
                            delete1.Connection = objConnection;
                            delete1.CommandText = "DELETE FROM tbl_personel WHERE (tmpid = '" + objDataSet2.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + "')";
                            delete1.CommandType = CommandType.Text;
                            objConnection.Open();
                            delete1.ExecuteNonQuery();
                            objConnection.Close();

                            //جدول پروسس
                            SqlCommand delete2 = new SqlCommand();
                            delete2.Connection = objConnection;
                            delete2.CommandText = "DELETE FROM Tbl_process WHERE (idpersonal = '" + objDataSet2.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + "')";
                            delete2.CommandType = CommandType.Text;
                            objConnection.Open();
                            delete2.ExecuteNonQuery();
                            objConnection.Close();

                            //جدول کارکرد
                            SqlCommand delete3 = new SqlCommand();
                            delete3.Connection = objConnection;
                            delete3.CommandText = "DELETE FROM Tbl_karkard WHERE (idpersonal = '" + objDataSet2.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + "')";
                            delete3.CommandType = CommandType.Text;
                            objConnection.Open();
                            delete3.ExecuteNonQuery();
                            objConnection.Close();

                            //جدول حقوق پرسنل
                            SqlCommand delete4 = new SqlCommand();
                            delete4.Connection = objConnection;
                            delete4.CommandText = "DELETE FROM Tbl_hogogpersonel WHERE (tmpid_personel = '" + objDataSet2.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + "')";
                            delete4.CommandType = CommandType.Text;
                            objConnection.Open();
                            delete4.ExecuteNonQuery();
                            objConnection.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("عملیات حذف پرسنل لغو گردید.", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            lock1 = "1";
        }

        public void Form_Load_set_color()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet, "Color_Font_Set", true);
            Database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

            foreach (SplitContainer spc in this.Controls)
            {
                foreach (Control ct in spc.Panel1.Controls)
                {
                    if (ct.GetType() == typeof(Label))
                    {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                        Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[0]["promp"].ToString());
                        ct.Font = newFont;

                        TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                        Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[1]["promp"].ToString());
                        ct.ForeColor = newColor;
                    }

                    if (ct.GetType() == typeof(TextBox))
                    {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                        Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[4]["promp"].ToString());
                        ct.Font = newFont;

                        TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                        Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[5]["promp"].ToString());
                        ct.ForeColor = newColor;
                    }

                    if (ct.GetType() == typeof(Button))
                    {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                        Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[13]["promp"].ToString());
                        ct.Font = newFont;

                        TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                        Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[14]["promp"].ToString());
                        ct.ForeColor = newColor;
                    }
                }
            }
            this.BackColor = newColor0;

            TypeConverter tc2 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont2 = (Font)tc2.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[2]["promp"].ToString());

            TypeConverter tc3 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor3 = (Color)tc3.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[8]["promp"].ToString());

            TypeConverter tc7 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont7 = (Font)tc7.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[7]["promp"].ToString());

            TypeConverter tc8 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor8 = (Color)tc8.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[8]["promp"].ToString());

            TypeConverter tc9 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor9 = (Color)tc9.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[9]["promp"].ToString());

            TypeConverter tc10 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor10 = (Color)tc10.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[10]["promp"].ToString());

            TypeConverter tc11 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor11 = (Color)tc11.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[11]["promp"].ToString());

            TypeConverter tc12 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor12 = (Color)tc12.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[12]["promp"].ToString());

            DataGridViewCellStyle objAlignRightCellStyle1 = new DataGridViewCellStyle();
            objAlignRightCellStyle1.Font = newFont2;
            objAlignRightCellStyle1.BackColor = newColor3;

            DataGridViewCellStyle objAlignRightCellStyle2 = new DataGridViewCellStyle();
            objAlignRightCellStyle2.BackColor = newColor9;
            objAlignRightCellStyle2.ForeColor = newColor10;

            DataGridViewCellStyle objAlignRightCellStyle3 = new DataGridViewCellStyle();
            objAlignRightCellStyle3.BackColor = newColor11;
            objAlignRightCellStyle3.ForeColor = newColor12;

            grdAuthorTitles.Font = newFont7;
            grdAuthorTitles.BackgroundColor = newColor8;
            grdAuthorTitles.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            grdAuthorTitles.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            grdAuthorTitles.DefaultCellStyle = objAlignRightCellStyle3;

            objDataSet.Clear();
        }

        private void Form_sec()
        {
            if (U_set.u_user_sec(9) == 0)
            {
                button1.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
            }

            if (U_set.u_user_sec(16) == 0) 
            { 
                grdAuthorTitles.AllowUserToAddRows = false;
                button2.Visible = false;
            }

            if (U_set.u_user_sec(18) == 0) 
            { 
                grdAuthorTitles.AllowUserToDeleteRows = false;
                button6.Visible = false;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            FormLoad();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form25 f1 = new Form25();
            f1.id_group = id_group.ToString();
            f1.id_year = id_year.ToString();
            f1.id_moon = id_moon.ToString();
            f1.objDataSet = objDataSet1;

            f1.Text = " کارکرد ساعتی " + this.Text.Substring(9, this.Text.Length - 9);
            f1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();
            f1.id_group = id_group.ToString();
            f1.id_year = id_year.ToString();
            f1.id_moon = id_moon.ToString();
            f1.personel_type1 = "2";
            f1.objDataSet = objDataSet1;

            f1.Text = " کارکرد قانونی " + this.Text.Substring(9, this.Text.Length - 9);
            f1.Show();
        }

        private void grdAuthorTitles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (U_set.u_user_sec(17) != 0)
            {
                if (e.RowIndex != -1)
                {
                    Form22 f2 = new Form22();
                    f2.personel_Code = grdAuthorTitles.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    f2.id_group = id_group.ToString();
                    f2.id_year = id_year.ToString();
                    f2.id_moon = id_moon.ToString();
                    f2.state1 = "2";
                    f2.Text = this.Text + " - پرسنل : " + grdAuthorTitles.Rows[e.RowIndex].Cells[3].FormattedValue.ToString() + " " + grdAuthorTitles.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    f2.Show();
                }
            }
        }
    }
}