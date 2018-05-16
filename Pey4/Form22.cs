using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Pey4
{
    public partial class Form22 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DataSet objDataSet1 = new DataSet();
        DataSet objDataSet2 = new DataSet();
        DataSet objDataSet3 = new DataSet();
        DataSet newuser_ds = new DataSet();

        DB_Base database = new DB_Base();
        DB_Base Database = new DB_Base();

        U_Base U_set = new U_Base();

        public string personel_Code;
        public string id_year;
        public string id_moon;
        public string id_group;
        public string state1;
      
        public Form22()
        {
            InitializeComponent();
        }

        public void Form_Load_set_color()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet, "Color_Font_Set", true);
            Database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab.GetType() == typeof(TabPage))
                    tab.BackColor = newColor0;

                foreach (Control clt in tab.Controls)
                {
                    foreach (Control ct in clt.Controls)
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

                        if ((ct.GetType() == typeof(TextBox)) || (ct.GetType() == typeof(ComboBox)) || (ct.GetType() == typeof(Db_Combo)) || (ct.GetType() == typeof(MaskedTextBox)))
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
            objAlignRightCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            objAlignRightCellStyle3.Format = "N0";
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
            if (U_set.u_user_sec(16) == 0) { grdAuthorTitles.AllowUserToAddRows = false; }
            if (U_set.u_user_sec(17) == 0) { grdAuthorTitles.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { grdAuthorTitles.AllowUserToDeleteRows = false; }
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            DB_Base database = new DB_Base();

            db_Combo1.Bind_Data1("SELECT tmpid, name_makaz FROM Tbl_markaz", "name_makaz", "tmpid");

            if (state1 == "2")
            {
                database.Connection_Open();
                database.Fill("SELECT * FROM [tbl_personel] WHERE (tmpid = " + personel_Code + ")", objDataSet, "Tbl_personelfill", true);
                database.Connection_Close();

                textBox1.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["code"].ToString();
                textBox2.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["name"].ToString();
                textBox3.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["family"].ToString();
                textBox4.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["name_pedar"].ToString();
                textBox9.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["cod_mely"].ToString();
                textBox10.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["sh_sh"].ToString();
                textBox11.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["tedah_farzand"].ToString();
                textBox12.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["phon_manzel"].ToString();
                textBox13.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["phon_sabt"].ToString();
                textBox14.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["phon_hamra"].ToString();
                textBox15.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["name_bank"].ToString();
                textBox16.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["bank_shobeh"].ToString();
                textBox17.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["sh_hesab"].ToString();
                textBox18.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["sh_kart"].ToString();
                textBox19.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["code_posti"].ToString();
                maskedTextBox5.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["brithdate"].ToString();
                textBox20.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["adress"].ToString();
                textBox21.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["tozihat"].ToString();

                if (objDataSet.Tables["Tbl_personelfill"].Rows[0]["image_byte"].ToString() != "")
                {
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(objDataSet.Tables["Tbl_personelfill"].Rows[0]["image_byte"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                    pictureBox.Image = Image.FromStream(stmBLOBData);
                }

                textBox24.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_madrak"].ToString();
                textBox25.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_onvanShoghl"].ToString();
                textBox26.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_serishenasnameh"].ToString();
                textBox27.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_vazmaskan"].ToString();
                textBox28.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_meliat"].ToString();
                textBox29.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_namekeshvar"].ToString();
                textBox31.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_rasteshoghli"].ToString();
                textBox32.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["code_moafiat_maliat"].ToString();
                textBox33.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_vazmashin"].ToString();
                textBox30.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_Moafiyat_vam"].ToString();

                textBox34.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["code_moafiat_bimeh"].ToString();
                textBox35.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["bimeh_keshvar"].ToString();
                textBox36.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["bimeh_shahr"].ToString();
                textBox38.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["bimeh_mashagel"].ToString();
                textBox39.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["bimeh_tahsilat"].ToString();
                textBox40.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["bimeh_reshteh"].ToString();

                textBox22.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["sh_ghrardad"].ToString();
                textBox41.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["noe_garardad"].ToString();
                textBox8.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["hogog_morakhasi"].ToString();

                maskedTextBox2.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["data_tarkkar"].ToString();
                maskedTextBox1.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["data_estekhdam"].ToString();
                maskedTextBox3.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["data_shorogaradad"].ToString();
                maskedTextBox4.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["data_paiangarardad"].ToString();

                textBox42.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["noe_bimeh"].ToString();
                textBox5.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["sh_bimeh"].ToString();
                textBox23.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["modateh_gararda"].ToString();
                comboBox4.SelectedIndex = Convert.ToInt32(objDataSet.Tables["Tbl_personelfill"].Rows[0]["NoeHoghog"].ToString()) - 1;
                checkBox1.Checked = Convert.ToBoolean(objDataSet.Tables["Tbl_personelfill"].Rows[0]["list2"]);
                checkBox2.Checked = Convert.ToBoolean(objDataSet.Tables["Tbl_personelfill"].Rows[0]["list1"]);
                textBox6.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["hogog_rozaneh_tavafogh"].ToString();
                textBox7.Text = objDataSet.Tables["Tbl_personelfill"].Rows[0]["hogog_rozaneh_ghanoni"].ToString();

                db_Combo2.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 1) AND (SCode=" + textBox24.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo3.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 2) AND (SCode=" + textBox25.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo4.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 3) AND (SCode=" + textBox26.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo5.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 18) AND (SCode=" + textBox27.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo6.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 11) AND (SCode=" + textBox28.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo7.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 12) AND (SCode=" + textBox29.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo8.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 10) AND (SCode=" + textBox31.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo9.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 19) AND (SCode=" + textBox33.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                db_Combo10.Bind_Data1("SELECT tmpid, name_moafiat FROM Tbl_moafiat_maliat WHERE (tmpid=" + textBox32.Text + ")", "name_moafiat", "tmpid");
                db_Combo11.Bind_Data1("SELECT tmpid, name_moafiat FROM Tbl_moafiat_bimeh WHERE (tmpid=" + textBox34.Text + ")", "name_moafiat", "tmpid");
                db_Combo12.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_1 WHERE (Code=" + textBox35.Text + ") ORDER BY Desc1", "Desc1", "Code");
                db_Combo13.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_City WHERE (Code=" + textBox36.Text + ") ORDER BY Desc1", "Desc1", "Code");
                db_Combo14.Bind_Data1("SELECT Job_Code, Job_Desc FROM Bimeh_tab_job WHERE (Job_Code='" + textBox38.Text + "')", "Job_Desc", "Job_Code");
                db_Combo15.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_Education WHERE (Code=" + textBox39.Text + ") ORDER BY Desc1", "Desc1", "Code");
                db_Combo16.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_Field WHERE (Code=" + textBox40.Text + ") ORDER BY Desc1", "Desc1", "Code");

                db_Combo18.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 15) AND (SCode=" + textBox41.Text + ") ORDER BY SCode", "SDesc", "SCode");
                db_Combo19.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 16) AND (SCode=" + textBox42.Text + ") ORDER BY SCode", "SDesc", "SCode");

                if (objDataSet.Tables["Tbl_personelfill"].Rows[0]["sex"].ToString() == "مرد")
                { comboBox2.SelectedIndex = 0; }
                else
                { comboBox2.SelectedIndex = 1; }

                if (objDataSet.Tables["Tbl_personelfill"].Rows[0]["tahol"].ToString() == "متاهل")
                { comboBox1.SelectedIndex = 1; }
                else
                { comboBox1.SelectedIndex = 0; }

                if (objDataSet.Tables["Tbl_personelfill"].Rows[0]["bimeh_meliat"].ToString() == "ایرانی")
                { comboBox3.SelectedIndex = 0; }
                else
                { comboBox3.SelectedIndex = 1; }

                if (objDataSet.Tables["Tbl_personelfill"].Rows[0]["maliat_nezamvazifeh"].ToString() == "معاف")
                { comboBoxSoldier.SelectedIndex = 0; }
                else
                { comboBoxSoldier.SelectedIndex = 1; }

                db_Combo1.SelectedValue = objDataSet.Tables["Tbl_personelfill"].Rows[0]["mar_tmpid"].ToString();

            }
            else if( state1 == "1")
            {
                groupBoxGharardad.Enabled = false;
                groupBoxMazaya.Enabled = false;
            }

            button3.Visible = false;

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


            objDataSet3.Clear();
            textBox2.AutoCompleteCustomSource.Clear();
            database.Connection_Open();
            database.Fill("SELECT DISTINCT name FROM [tbl_personel]", objDataSet3, "tbl_personelfill", true);
            database.Connection_Close();
            string[] installs = new string[objDataSet3.Tables["tbl_personelfill"].Rows.Count];
            for (int q = 0; q <= objDataSet3.Tables["tbl_personelfill"].Rows.Count - 1; q++)
            {
                installs[q] = objDataSet3.Tables["tbl_personelfill"].Rows[q]["name"].ToString();
            }
            textBox2.AutoCompleteCustomSource.AddRange(installs);

            objDataSet3.Clear();
            textBox3.AutoCompleteCustomSource.Clear();
            database.Connection_Open();
            database.Fill("SELECT DISTINCT family FROM [tbl_personel]", objDataSet3, "tbl_personelfill", true);
            database.Connection_Close();
            string[] installs1 = new string[objDataSet3.Tables["tbl_personelfill"].Rows.Count];
            for (int q = 0; q <= objDataSet3.Tables["tbl_personelfill"].Rows.Count - 1; q++)
            {
                installs1[q] = objDataSet3.Tables["tbl_personelfill"].Rows[q]["family"].ToString();
            }
            textBox3.AutoCompleteCustomSource.AddRange(installs1);

            objDataSet3.Clear();
            textBox4.AutoCompleteCustomSource.Clear();
            database.Connection_Open();
            database.Fill("SELECT DISTINCT name_pedar FROM [tbl_personel]", objDataSet3, "tbl_personelfill", true);
            database.Connection_Close();
            string[] installs2 = new string[objDataSet3.Tables["tbl_personelfill"].Rows.Count];
            for (int q = 0; q <= objDataSet3.Tables["tbl_personelfill"].Rows.Count - 1; q++)
            {
                installs2[q] = objDataSet3.Tables["tbl_personelfill"].Rows[q]["name_pedar"].ToString();
            }
            textBox4.AutoCompleteCustomSource.AddRange(installs2);
        }

        private void sa_del_2()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox1.Text = "";
            textBox8.Text = "";
            textBox6.Text = "";
            maskedTextBox2.Text = "";
        }

        private void butt_ok_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا فیلد کد پرسنلی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا فیلد نام را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا فیلد نام خانوادگی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا فیلد نام پدر را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }

            if (comboBox2.Text == "")
            {
                MessageBox.Show("لطفا فیلد جنسیت را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
                return;
            }

            if (textBox9.Text == "")
            {
                MessageBox.Show("لطفا فیلد کد ملی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox9.Focus();
                return;
            }

            if (textBox10.Text == "")
            {
                MessageBox.Show("لطفا فیلد شماره شناسنامه را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox10.Focus();
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("لطفا فیلد وضعیت تاهل تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }

            if (textBox11.Text == "")
            {
                MessageBox.Show("لطفا فیلد تعداد فرزندان را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox11.Focus();
                return;
            }

            if (textBox12.Text == "")
            {
                textBox12.Text = "-";
            }

            if (textBox13.Text == "")
            {
                textBox13.Text = "-";
            }

            if (textBox14.Text == "")
            {
                textBox14.Text = "-";
            }

            if (textBox15.Text == "")
            {
                textBox15.Text = "-";
            }

            if (textBox16.Text == "")
            {
                textBox16.Text = "-";
            }

            if (textBox17.Text == "")
            {
                textBox17.Text = "-";
            }

            if (textBox18.Text == "")
            {
                textBox18.Text = "-";
            }

            if (textBox19.Text == "")
            {
                MessageBox.Show("لطفا فیلد کد پستی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox19.Focus();
                return;
            }

            if (db_Combo1.Text == "")
            {
                MessageBox.Show("لطفا فیلد مرکز هزینه را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db_Combo1.Focus();
                return;
            }

            if (maskedTextBox5.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا فیلد تاریخ تولد را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox5.Focus();
                return;
            }

            if (textBox20.Text == "")
            {
                textBox20.Text = "-";
            }

            if (textBox21.Text == "")
            {
                textBox21.Text = "-";
            }

            if ((textBox24.Text == "") || (db_Combo2.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد مدرک تحصیلی را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox24.Focus();
                return;
            }

            if ((textBox25.Text == "") || (db_Combo3.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد عنوان شغل را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox25.Focus();
                return;
            }

            if ((textBox26.Text == "") || (db_Combo4.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد سری شناسنامه را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox26.Focus();
                return;
            }

            if ((textBox27.Text == "") || (db_Combo5.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد وضعیت مسکن را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox27.Focus();
                return;
            }

            if ((textBox28.Text == "") || (db_Combo6.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد ملیت را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox28.Focus();
                return;
            }

            if ((textBox29.Text == "") || (db_Combo7.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد نام کشور را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox29.Focus();
                return;
            }

            if (comboBoxSoldier.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا فیلد وضعیت نظام وظیفه را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxSoldier.Focus();
                return;
            }

            if ((textBox31.Text == "") || (db_Combo8.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد رسته شغلی را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox31.Focus();
                return;
            }

            if ((textBox32.Text == "") || (db_Combo10.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد معافیت مالیات را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox32.Focus();
                return;
            }

            if ((textBox33.Text == "") || (db_Combo9.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد وضعیت اتومبیل را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox33.Focus();
                return;
            }

            if (textBox30.Text == "")
            {
                textBox30.Text = "0";
            }

            if ((textBox34.Text == "") || (db_Combo11.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد معافیت بیمه را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox34.Focus();
                return;
            }

            if ((textBox35.Text == "") || (db_Combo12.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد کشور را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox35.Focus();
                return;
            }

            if ((textBox36.Text == "") || (db_Combo13.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد محل صدور را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox36.Focus();
                return;
            }

            if ((textBox38.Text == "") || (db_Combo14.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد مشاغل را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox38.Focus();
                return;
            }

            if ((textBox39.Text == "") || (db_Combo15.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد تحصیلات را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox39.Focus();
                return;
            }

            if ((textBox40.Text == "") || (db_Combo16.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد رشته تحصیلی را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox40.Focus();
                return;
            }

            DB_Base database = new DB_Base();

            MemoryStream stream=new MemoryStream();
            pictureBox.Image.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] picbyte = stream.ToArray();

            string imagename = openFileDialogImage.FileName;
            
            if (state1 == "1")
            {
                database.objCommand.CommandText = "INSERT INTO tbl_personel (idgroup,idyear,idmoon,code,name,family,name_pedar,sex,cod_mely,sh_sh,tahol,tedah_farzand,phon_manzel,phon_sabt,phon_hamra,name_bank,bank_shobeh,sh_hesab,sh_kart,code_posti,mar_tmpid,adress,tozihat,image_byte,maliat_madrak,maliat_onvanShoghl,maliat_serishenasnameh,maliat_vazmaskan,maliat_meliat,maliat_namekeshvar,maliat_nezamvazifeh,maliat_rasteshoghli,code_moafiat_maliat,maliat_vazmashin,code_moafiat_bimeh,bimeh_keshvar,bimeh_shahr,bimeh_mashagel,bimeh_tahsilat,bimeh_reshteh,uuser,udate,utime,upc,brithdate,bimeh_meliat,maliat_Moafiyat_vam,list1,list2) VALUES (@idgroup,@idyear,@idmoon,@code,@name,@family,@name_pedar,@sex,@cod_mely,@sh_sh,@tahol,@tedah_farzand,@phon_manzel,@phon_sabt,@phon_hamra,@name_bank,@bank_shobeh,@sh_hesab,@sh_kart,@code_posti,@mar_tmpid,@adress,@tozihat,@image_byte,@maliat_madrak,@maliat_onvanShoghl,@maliat_serishenasnameh,@maliat_vazmaskan,@maliat_meliat,@maliat_namekeshvar,@maliat_nezamvazifeh,@maliat_rasteshoghli,@code_moafiat_maliat,@maliat_vazmashin,@code_moafiat_bimeh,@bimeh_keshvar,@bimeh_shahr,@bimeh_mashagel,@bimeh_tahsilat,@bimeh_reshteh,@uuser,@udate,@utime,@upc,@brithdate,@bimeh_meliat,@maliat_Moafiyat_vam,@list1,@list2)";

                database.objCommand.Parameters.AddWithValue("@idgroup",Convert.ToInt32(id_group));
                database.objCommand.Parameters.AddWithValue("@idyear", Convert.ToInt32(id_year));
                database.objCommand.Parameters.AddWithValue("@idmoon", Convert.ToInt32(id_moon));
                database.objCommand.Parameters.AddWithValue("@code", textBox1.Text);
                database.objCommand.Parameters.AddWithValue("@name", textBox2.Text);
                database.objCommand.Parameters.AddWithValue("@family", textBox3.Text);
                database.objCommand.Parameters.AddWithValue("@name_pedar", textBox4.Text);
                database.objCommand.Parameters.AddWithValue("@sex", comboBox2.Text);
                database.objCommand.Parameters.AddWithValue("@cod_mely", textBox9.Text);
                database.objCommand.Parameters.AddWithValue("@sh_sh", textBox10.Text);
                database.objCommand.Parameters.AddWithValue("@tahol", comboBox1.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_meliat", comboBox3.Text);
                database.objCommand.Parameters.AddWithValue("@tedah_farzand", textBox11.Text);
                database.objCommand.Parameters.AddWithValue("@phon_manzel", textBox12.Text);
                database.objCommand.Parameters.AddWithValue("@phon_sabt", textBox13.Text);
                database.objCommand.Parameters.AddWithValue("@phon_hamra", textBox14.Text);
                database.objCommand.Parameters.AddWithValue("@name_bank", textBox15.Text);
                database.objCommand.Parameters.AddWithValue("@bank_shobeh", textBox16.Text);
                database.objCommand.Parameters.AddWithValue("@sh_hesab", textBox17.Text);
                database.objCommand.Parameters.AddWithValue("@sh_kart", textBox18.Text);
                database.objCommand.Parameters.AddWithValue("@code_posti", textBox19.Text);
                database.objCommand.Parameters.AddWithValue("@mar_tmpid", db_Combo1.SelectedValue);
                database.objCommand.Parameters.AddWithValue("@adress", textBox20.Text);
                database.objCommand.Parameters.AddWithValue("@tozihat", textBox21.Text);
                database.objCommand.Parameters.AddWithValue("@image_byte", picbyte);
                database.objCommand.Parameters.AddWithValue("@maliat_madrak", textBox24.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_onvanShoghl", textBox25.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_serishenasnameh", textBox26.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_vazmaskan", textBox27.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_meliat", textBox28.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_namekeshvar", textBox29.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_nezamvazifeh", comboBoxSoldier.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_rasteshoghli", textBox31.Text);
                database.objCommand.Parameters.AddWithValue("@code_moafiat_maliat", textBox32.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_vazmashin", textBox33.Text);
                database.objCommand.Parameters.AddWithValue("@code_moafiat_bimeh", textBox34.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_keshvar", textBox35.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_shahr", textBox36.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_mashagel", textBox38.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_tahsilat", textBox39.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_reshteh", textBox40.Text);
                database.objCommand.Parameters.AddWithValue("@uuser", ".");
                database.objCommand.Parameters.AddWithValue("@udate", database.u_date());
                database.objCommand.Parameters.AddWithValue("@utime", database.u_time());
                database.objCommand.Parameters.AddWithValue("@upc", database.u_pc());
                database.objCommand.Parameters.AddWithValue("@brithdate", maskedTextBox5.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_Moafiyat_vam", textBox30.Text);
                database.objCommand.Parameters.AddWithValue("@list1", "1");
                database.objCommand.Parameters.AddWithValue("@list2", "1");

                database.Connection_Open();
                database.objCommand.Connection = database.objConnection;

                if (database.objCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("اطلاعات با موفقیت ثبت شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DB_Base database1 = new DB_Base();
                    database1.Connection_Open();
                    database1.Fill("SELECT MAX(tmpid) as rsmax FROM tbl_personel", newuser_ds, "tbl_personel", true);
                    database1.Connection_Close();

                    personel_Code = newuser_ds.Tables["tbl_personel"].Rows[0]["rsmax"].ToString();

                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = objConnection;
                    objCommand.CommandText = "INSERT INTO Tbl_karkard (idgroup,idyear,idmoon,idpersonal,type1) VALUES (@idgroup,@idyear,@idmoon,@idpersonal,@type1)";
                    objCommand.CommandType = CommandType.Text;
                    objCommand.Parameters.AddWithValue("@idgroup", id_group);
                    objCommand.Parameters.AddWithValue("@idyear", id_year);
                    objCommand.Parameters.AddWithValue("@idmoon", id_moon);
                    objCommand.Parameters.AddWithValue("@idpersonal", personel_Code);
                    objCommand.Parameters.AddWithValue("@type1", 1);
                    objConnection.Open();
                    objCommand.ExecuteNonQuery();
                    objConnection.Close();

                    SqlCommand objCommand1 = new SqlCommand();
                    objCommand1.Connection = objConnection;
                    objCommand1.CommandText = "INSERT INTO Tbl_karkard (idgroup,idyear,idmoon,idpersonal,type1) VALUES (@idgroup,@idyear,@idmoon,@idpersonal,@type1)";
                    objCommand1.CommandType = CommandType.Text;
                    objCommand1.Parameters.AddWithValue("@idgroup", id_group);
                    objCommand1.Parameters.AddWithValue("@idyear", id_year);
                    objCommand1.Parameters.AddWithValue("@idmoon", id_moon);
                    objCommand1.Parameters.AddWithValue("@idpersonal", personel_Code);
                    objCommand1.Parameters.AddWithValue("@type1", 2);
                    objConnection.Open();
                    objCommand1.ExecuteNonQuery();
                    objConnection.Close();

                    state1 = "2";
                    groupBoxGharardad.Enabled = true;
                    groupBoxMazaya.Enabled = true;
                }
                else
                {
                    MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                database.objCommand.Dispose();
                database.Connection_Close();
                database.objConnection.Dispose();
            }

            else if (state1 == "2")
            {

                database.objCommand.CommandText = "UPDATE tbl_personel SET code=@code, name=@name, family=@family, name_pedar=@name_pedar, sex=@sex, cod_mely=@cod_mely, sh_sh=@sh_sh, tahol=@tahol, tedah_farzand=@tedah_farzand, phon_manzel=@phon_manzel, phon_sabt=@phon_sabt, phon_hamra=@phon_hamra, name_bank=@name_bank, bank_shobeh=@bank_shobeh, sh_hesab=@sh_hesab, sh_kart=@sh_kart, code_posti=@code_posti, mar_tmpid=@mar_tmpid, adress=@adress, tozihat=@tozihat, image_byte=@image_byte, maliat_madrak=@maliat_madrak, maliat_onvanShoghl=@maliat_onvanShoghl, maliat_serishenasnameh=@maliat_serishenasnameh, maliat_vazmaskan=@maliat_vazmaskan, maliat_meliat=@maliat_meliat, maliat_namekeshvar=@maliat_namekeshvar, maliat_nezamvazifeh=@maliat_nezamvazifeh, maliat_rasteshoghli=@maliat_rasteshoghli, code_moafiat_maliat=@code_moafiat_maliat, maliat_vazmashin=@maliat_vazmashin, code_moafiat_bimeh=@code_moafiat_bimeh, bimeh_keshvar=@bimeh_keshvar, bimeh_shahr=@bimeh_shahr, bimeh_mashagel=@bimeh_mashagel, bimeh_tahsilat=@bimeh_tahsilat, bimeh_reshteh=@bimeh_reshteh, uuser=@uuser, udate=@udate, utime=@utime, upc=@upc, brithdate=@brithdate, bimeh_meliat=@bimeh_meliat, maliat_Moafiyat_vam=@maliat_Moafiyat_vam  WHERE (tmpid='" + personel_Code + "')";

                database.objCommand.Parameters.AddWithValue("@code", textBox1.Text);
                database.objCommand.Parameters.AddWithValue("@name", textBox2.Text);
                database.objCommand.Parameters.AddWithValue("@family", textBox3.Text);
                database.objCommand.Parameters.AddWithValue("@name_pedar", textBox4.Text);
                database.objCommand.Parameters.AddWithValue("@sex", comboBox2.Text);
                database.objCommand.Parameters.AddWithValue("@cod_mely", textBox9.Text);
                database.objCommand.Parameters.AddWithValue("@sh_sh", textBox10.Text);
                database.objCommand.Parameters.AddWithValue("@tahol", comboBox1.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_meliat", comboBox3.Text);
                database.objCommand.Parameters.AddWithValue("@tedah_farzand", textBox11.Text);
                database.objCommand.Parameters.AddWithValue("@phon_manzel", textBox12.Text);
                database.objCommand.Parameters.AddWithValue("@phon_sabt", textBox13.Text);
                database.objCommand.Parameters.AddWithValue("@phon_hamra", textBox14.Text);
                database.objCommand.Parameters.AddWithValue("@name_bank", textBox15.Text);
                database.objCommand.Parameters.AddWithValue("@bank_shobeh", textBox16.Text);
                database.objCommand.Parameters.AddWithValue("@sh_hesab", textBox17.Text);
                database.objCommand.Parameters.AddWithValue("@sh_kart", textBox18.Text);
                database.objCommand.Parameters.AddWithValue("@code_posti", textBox19.Text);
                database.objCommand.Parameters.AddWithValue("@mar_tmpid", db_Combo1.SelectedValue);
                database.objCommand.Parameters.AddWithValue("@adress", textBox20.Text);
                database.objCommand.Parameters.AddWithValue("@tozihat", textBox21.Text);
                database.objCommand.Parameters.AddWithValue("@image_byte", picbyte);
                database.objCommand.Parameters.AddWithValue("@maliat_madrak", textBox24.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_onvanShoghl", textBox25.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_serishenasnameh", textBox26.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_vazmaskan", textBox27.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_meliat", textBox28.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_namekeshvar", textBox29.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_nezamvazifeh", comboBoxSoldier.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_rasteshoghli", textBox31.Text);
                database.objCommand.Parameters.AddWithValue("@code_moafiat_maliat", textBox32.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_vazmashin", textBox33.Text);
                database.objCommand.Parameters.AddWithValue("@code_moafiat_bimeh", textBox34.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_keshvar", textBox35.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_shahr", textBox36.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_mashagel", textBox38.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_tahsilat", textBox39.Text);
                database.objCommand.Parameters.AddWithValue("@bimeh_reshteh", textBox40.Text);
                database.objCommand.Parameters.AddWithValue("@uuser", ".");
                database.objCommand.Parameters.AddWithValue("@udate", database.u_date());
                database.objCommand.Parameters.AddWithValue("@utime", database.u_time());
                database.objCommand.Parameters.AddWithValue("@upc", database.u_pc());
                database.objCommand.Parameters.AddWithValue("@brithdate", maskedTextBox5.Text);
                database.objCommand.Parameters.AddWithValue("@maliat_Moafiyat_vam", textBox30.Text);
                
                database.Connection_Open();
                database.objCommand.Connection = database.objConnection;

                if (database.objCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("اطلاعات با موفقیت به روز شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                database.objCommand.Dispose();
                database.Connection_Close();
                database.objConnection.Dispose();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            amin_button2();

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET [select1]=@select11";
            objCommand.CommandType = CommandType.Text;
            objCommand.Parameters.AddWithValue("@select11", "0");
            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objConnection.Close();

            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM [Tbl_hogog] ORDER BY tmpid";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;

            objConnection.Open();
            objDataAdapter.Fill(objDataSet1, "Tbl_hogog");
            objDataSet1.Tables["Tbl_hogog"].Clear();
            objDataAdapter.Fill(objDataSet1, "Tbl_hogog");
            objConnection.Close();

            for (int q = 0; q <= objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count - 1; q++)
            {
                for (int w = 0; w <= objDataSet1.Tables["Tbl_hogog"].Rows.Count - 1; w++)
                {
                    if (objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q]["tmpid_hogog"].ToString() == objDataSet1.Tables["Tbl_hogog"].Rows[w]["tmpid"].ToString())
                    {
                        objDataSet1.Tables["Tbl_hogog"].Rows[w]["select1"] = 1;
                        break;
                    }
                }
            }


            grdAuthorTitles.AutoGenerateColumns = true;
            grdAuthorTitles.DataSource = null;
            grdAuthorTitles.DataMember = null;

            grdAuthorTitles.DataSource = objDataSet1;
            grdAuthorTitles.DataMember = "Tbl_hogog";

            grdAuthorTitles.Columns[0].Visible = false;
            grdAuthorTitles.Columns[1].HeaderText = "انتخاب";
            grdAuthorTitles.Columns[2].HeaderText = "کسورات و مزایا";
            grdAuthorTitles.Columns[3].Visible = false;
            grdAuthorTitles.Columns[4].HeaderText = "نوع";
            grdAuthorTitles.Columns[5].HeaderText = "عنوان";
            grdAuthorTitles.Columns[6].HeaderText = "مبلغ (ریال)";
            grdAuthorTitles.Columns[7].HeaderText = "مالیات";
            grdAuthorTitles.Columns[8].HeaderText = "بیمه";
            grdAuthorTitles.Columns[9].HeaderText = "درصد بیمه سهم کارفرما";
            grdAuthorTitles.Columns[10].HeaderText = "درصد بیمه سهم بیکاری";
            grdAuthorTitles.Columns[11].HeaderText = "درصد بیمه سهم پرسنل";
            grdAuthorTitles.Columns[12].Visible = false;
            grdAuthorTitles.Columns[13].Visible = false;
            grdAuthorTitles.Columns[14].Visible = false;
            grdAuthorTitles.Columns[15].Visible = false;
            grdAuthorTitles.Columns[16].HeaderText = "کد حسابداری";

            button4.Visible = false;
            button2.Visible = false;

            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int r;
            for (int w = 0; w <= objDataSet1.Tables["Tbl_hogog"].Rows.Count - 1; w++)
            {
                if (objDataSet1.Tables["Tbl_hogog"].Rows[w]["select1"].ToString() == "True")
                {
                    r = 0;
                    for (int q = 0; q <= objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count - 1; q++)
                    {
                        if (objDataSet1.Tables["Tbl_hogog"].Rows[w]["tmpid"].ToString() == objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q]["tmpid_hogog"].ToString())
                        {
                            r = 1;
                            break;
                        }
                    }
                    if (r == 0)
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.Connection = objConnection;
                        objCommand.CommandText = "INSERT INTO Tbl_hogogpersonel (idgroup,idyear,idmoon,tmpid_personel,tmpid_hogog,list1,list2,money1) VALUES (@idgroup,@idyear,@idmoon,@tmpid_personel,@tmpid_hogog,@list1,@list2,@money1)";
                        objCommand.CommandType = CommandType.Text;
                        objCommand.Parameters.AddWithValue("@idgroup", id_group);
                        objCommand.Parameters.AddWithValue("@idyear", id_year);
                        objCommand.Parameters.AddWithValue("@idmoon", id_moon);
                        objCommand.Parameters.AddWithValue("@tmpid_personel", personel_Code);
                        objCommand.Parameters.AddWithValue("@tmpid_hogog", objDataSet1.Tables["Tbl_hogog"].Rows[w]["tmpid"].ToString());
                        objCommand.Parameters.AddWithValue("@list1", "1");
                        objCommand.Parameters.AddWithValue("@list2", "1");

                        if (objDataSet1.Tables["Tbl_hogog"].Rows[w]["tmpid"].ToString() == "1")
                        {
                            if (Convert.ToInt32(textBox11.Text) >= 2)
                                objCommand.Parameters.AddWithValue("@money1", Convert.ToDouble(objDataSet1.Tables["Tbl_hogog"].Rows[w]["mablag"].ToString()) * 2);
                            else if (Convert.ToInt32(textBox11.Text) == 1)
                                objCommand.Parameters.AddWithValue("@money1", objDataSet1.Tables["Tbl_hogog"].Rows[w]["mablag"]);
                            else
                                objCommand.Parameters.AddWithValue("@money1", 0);
                        }

                        else if (objDataSet1.Tables["Tbl_hogog"].Rows[w]["tmpid"].ToString() == "2")
                        {
                            if (comboBox1.Text == "متاهل")
                                objCommand.Parameters.AddWithValue("@money1", Convert.ToDouble(objDataSet1.Tables["Tbl_hogog"].Rows[w]["mablag"].ToString()) * 2);
                            else
                                objCommand.Parameters.AddWithValue("@money1", objDataSet1.Tables["Tbl_hogog"].Rows[w]["mablag"]);
                        }

                        else
                        {
                            objCommand.Parameters.AddWithValue("@money1", objDataSet1.Tables["Tbl_hogog"].Rows[w]["mablag"]);
                        }
                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }
                }
            }

            button4.Visible = true;
            button2.Visible = true;

            button3.Visible = false;

            amin_active();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            amin_button2();
        }

        private void amin_button2()
        {
            if (objDataSet1.HasChanges())
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(objDataAdapter);
                if (objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count > 0)
                {
                    for (int q = 0; q <= objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count - 1; q++)
                    {
                        if (objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q].RowState.ToString() == "Modified")
                        {
                            SqlCommand objCommand = new SqlCommand();
                            objCommand.Connection = objConnection;
                            objCommand.CommandText = "UPDATE Tbl_hogogpersonel SET [list1]=@list11, [list2]=@list12, [money1]=@money11 WHERE (tmpid='" + objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q]["Tbl_hogogpersoneltmpid"].ToString() + "')";
                            objCommand.CommandType = CommandType.Text;
                            objCommand.Parameters.AddWithValue("@list11", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q]["list1"]);
                            objCommand.Parameters.AddWithValue("@list12", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q]["list2"]);
                            objCommand.Parameters.AddWithValue("@money11", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q]["money1"]);
                            objConnection.Open();
                            objCommand.ExecuteNonQuery();
                            objConnection.Close();
                        }

                        if (objDataSet1.Tables["Tbl_hogogpersonel"].Rows[q].RowState.ToString() == "Deleted")
                        {
                            SqlCommand objCommand = new SqlCommand();
                            objCommand.Connection = objConnection;
                            objCommand.CommandText = "DELETE FROM Tbl_hogogpersonel WHERE (tmpid='" + objDataSet1.Tables["Tbl_hogogpersonel1"].Rows[q]["Tbl_hogogpersoneltmpid"].ToString() + "')";
                            objCommand.CommandType = CommandType.Text;
                            objConnection.Open();
                            objCommand.ExecuteNonQuery();
                            objConnection.Close();
                        }
                    }
                }
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void amin_active()
        {
            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT Tbl_hogog.hogog ,Tbl_hogog.shahr ,Tbl_hogog.noe ,Tbl_hogogpersonel.list1 ,Tbl_hogogpersonel.list2 ,Tbl_hogogpersonel.money1 ,Tbl_hogog.maliat ,Tbl_hogog.bimeh_karfarma ,Tbl_hogog.karfarma_darsad ,Tbl_hogog.bikari_darsad ,Tbl_hogog.personel_dasad, Tbl_hogog.tmpid, Tbl_hogogpersonel.tmpid As Tbl_hogogpersoneltmpid, Tbl_hogogpersonel.tmpid_hogog, Tbl_hogogpersonel.idgroup, Tbl_hogogpersonel.idyear, Tbl_hogogpersonel.idmoon  FROM Tbl_hogogpersonel INNER JOIN Tbl_hogog ON Tbl_hogogpersonel.tmpid_hogog = Tbl_hogog.tmpid WHERE (Tbl_hogogpersonel.tmpid_personel=" + personel_Code + ") AND (Tbl_hogogpersonel.idgroup=" + id_group + ") AND (Tbl_hogogpersonel.idyear=" + id_year + ") AND (Tbl_hogogpersonel.idmoon=" + id_moon + ")";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;

            objConnection.Open();

            if (objDataSet1.Tables["Tbl_hogogpersonel"] != null)
                objDataSet1.Tables["Tbl_hogogpersonel"].Clear();
            objDataAdapter.Fill(objDataSet1, "Tbl_hogogpersonel");

            if (objDataSet1.Tables["Tbl_hogogpersonel1"] != null)
                objDataSet1.Tables["Tbl_hogogpersonel1"].Clear();
            objDataAdapter.Fill(objDataSet1, "Tbl_hogogpersonel1");

            objConnection.Close();

            grdAuthorTitles.AutoGenerateColumns = true;
            grdAuthorTitles.DataSource = null;
            grdAuthorTitles.DataMember = null;

            grdAuthorTitles.DataSource = objDataSet1;
            grdAuthorTitles.DataMember = "Tbl_hogogpersonel";

            grdAuthorTitles.Columns[0].HeaderText = "کسورات و مزایا";
            grdAuthorTitles.Columns[1].HeaderText = "عنوان";
            grdAuthorTitles.Columns[2].HeaderText = "نوع";
            grdAuthorTitles.Columns[3].HeaderText = "لیست";
            grdAuthorTitles.Columns[4].HeaderText = "توافقی";
            grdAuthorTitles.Columns[5].HeaderText = "مبلغ";
            grdAuthorTitles.Columns[6].HeaderText = "مالیات";
            grdAuthorTitles.Columns[7].HeaderText = "بیمه";
            grdAuthorTitles.Columns[8].HeaderText = "درصد بیمه سهم کارفرما";
            grdAuthorTitles.Columns[9].HeaderText = "درصد بیمه سهم بیکاری";
            grdAuthorTitles.Columns[10].HeaderText = "درصد بیمه سهم پرسنل";
            grdAuthorTitles.Columns[11].Visible = false;
            grdAuthorTitles.Columns[12].Visible = false;
            grdAuthorTitles.Columns[13].Visible = false;
            grdAuthorTitles.Columns[14].Visible = false;
            grdAuthorTitles.Columns[15].Visible = false;
            grdAuthorTitles.Columns[16].Visible = false;
        }

        private void Form22_Activated(object sender, EventArgs e)
        {
            amin_active();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox22.Text == "")
            {
                MessageBox.Show("لطفا فیلد شماره قرارداد را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox22.Focus();
                return;
            }

            if ((textBox41.Text == "") || (db_Combo18.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد نوع قرارداد را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox41.Focus();
                return;
            }

            if (textBox8.Text == "")
            {
                MessageBox.Show("لطفا فیلد مرخصی سالانه را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
                return;
            }

            if (maskedTextBox2.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا فیلد تاریخ ترک کار را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Focus();
                return;
            }

            if (maskedTextBox1.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا فیلد تاریخ استخدام را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }

            if (maskedTextBox3.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا فیلد تاریخ شروع قرارداد را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox3.Focus();
                return;
            }

            if (maskedTextBox4.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا فیلد تاریخ پایان قرارداد را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox4.Focus();
                return;
            }

            if ((textBox42.Text == "") || (db_Combo19.SelectedIndex == -1))
            {
                MessageBox.Show("لطفا فیلد نوع بیمه را صحیح انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox42.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا فیلد شماره بیمه را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
                return;
            }

            if (textBox23.Text == "")
            {
                MessageBox.Show("لطفا فیلد مدت قرارداد را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox23.Focus();
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا فیلد حقوق توافقی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("لطفا فیلد حقوق قانونی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
                return;
            }

            DB_Base database = new DB_Base();
            database.Connection_Open();

            database.objCommand.CommandText = "UPDATE tbl_personel SET sh_ghrardad=@sh_ghrardad, noe_garardad=@noe_garardad, hogog_morakhasi=@hogog_morakhasi, data_tarkkar=@data_tarkkar, data_estekhdam=@data_estekhdam, data_shorogaradad=@data_shorogaradad, data_paiangarardad=@data_paiangarardad, noe_bimeh=@noe_bimeh, sh_bimeh=@sh_bimeh, modateh_gararda=@modateh_gararda, NoeHoghog=@NoeHoghog, hogog_rozaneh_tavafogh=@hogog_rozaneh_tavafogh, hogog_rozaneh_ghanoni=@hogog_rozaneh_ghanoni, list1=@list1, list2=@list2 WHERE (tmpid=" + personel_Code + ")";
            database.objCommand.Parameters.AddWithValue("@sh_ghrardad", textBox22.Text);
            database.objCommand.Parameters.AddWithValue("@noe_garardad", textBox41.Text);
            database.objCommand.Parameters.AddWithValue("@hogog_morakhasi", textBox8.Text);
            database.objCommand.Parameters.AddWithValue("@data_tarkkar", maskedTextBox2.Text);
            database.objCommand.Parameters.AddWithValue("@data_estekhdam", maskedTextBox1.Text);
            database.objCommand.Parameters.AddWithValue("@data_shorogaradad", maskedTextBox3.Text);
            database.objCommand.Parameters.AddWithValue("@data_paiangarardad", maskedTextBox4.Text);
            database.objCommand.Parameters.AddWithValue("@noe_bimeh", textBox42.Text);
            database.objCommand.Parameters.AddWithValue("@sh_bimeh", textBox5.Text);
            database.objCommand.Parameters.AddWithValue("@modateh_gararda", textBox23.Text);
            database.objCommand.Parameters.AddWithValue("@list1", checkBox2.Checked);
            database.objCommand.Parameters.AddWithValue("@list2", checkBox1.Checked);
            database.objCommand.Parameters.AddWithValue("@NoeHoghog", comboBox4.SelectedIndex + 1);
            database.objCommand.Parameters.AddWithValue("@hogog_rozaneh_tavafogh", textBox6.Text);
            database.objCommand.Parameters.AddWithValue("@hogog_rozaneh_ghanoni", textBox7.Text);

            database.objCommand.Connection = database.objConnection;

            if (database.objCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("ثبت با موفقیت انجام شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            database.objCommand.Dispose();
            database.Connection_Close();
            database.objConnection.Dispose();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            openFileDialogImage.Filter = "JPG Format (*.jpg) |*.jpg| PNG Format (*.png) |*.png";
            openFileDialogImage.FilterIndex = 1;
            openFileDialogImage.Title = "انتخاب عکس";

            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialogImage.CheckFileExists == true)
                {
                    string ImageName = openFileDialogImage.FileName;
                    pictureBox.ImageLocation = ImageName;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objDataSet1.HasChanges())
            {
                DialogResult result = MessageBox.Show("آیا مایل به ذخیره تغییرات می باشید", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    amin_button2();
                }
            }
        }

        private void db_Combo2_Enter(object sender, EventArgs e)
        {
            db_Combo2.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 1) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                if (textBox24.Text == "") { textBox24.Text = "1"; }
                db_Combo2.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 1) AND (SCode="+ textBox24.Text +") ORDER BY SDesc", "SDesc", "SCode");
                textBox25.Focus();
            }
        }

        private void db_Combo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo2.SelectedIndex >= 0)
              if (db_Combo2.SelectedValue.ToString() != "System.Data.DataRowView")
                textBox24.Text = db_Combo2.SelectedValue.ToString();
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox25.Text == "") { textBox25.Text = "1"; }
                db_Combo3.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 2) AND (SCode=" + textBox25.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox26.Focus();
            }
        }

        private void db_Combo3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo3.SelectedIndex >= 0)
                if (db_Combo3.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox25.Text = db_Combo3.SelectedValue.ToString();
        }

        private void db_Combo3_Enter(object sender, EventArgs e)
        {
            db_Combo3.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 2) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox26.Text == "") { textBox26.Text = "1"; }
                db_Combo4.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 3) AND (SCode=" + textBox26.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox27.Focus();
            }
        }

        private void db_Combo4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo4.SelectedIndex >= 0)
                if (db_Combo4.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox26.Text = db_Combo4.SelectedValue.ToString();
        }

        private void db_Combo4_Enter(object sender, EventArgs e)
        {
            db_Combo4.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 3) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox27_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox27.Text == "") { textBox27.Text = "1"; }
                db_Combo5.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 18) AND (SCode=" + textBox27.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox28.Focus();
            }
        }

        private void db_Combo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo5.SelectedIndex >= 0)
                if (db_Combo5.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox27.Text = db_Combo5.SelectedValue.ToString();
        }

        private void db_Combo5_Enter(object sender, EventArgs e)
        {
            db_Combo5.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 18) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox28_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox28.Text == "") { textBox28.Text = "1"; }
                db_Combo6.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 11) AND (SCode=" + textBox28.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox29.Focus();
            }
        }

        private void db_Combo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo6.SelectedIndex >= 0)
                if (db_Combo6.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox28.Text = db_Combo6.SelectedValue.ToString();
        }

        private void db_Combo6_Enter(object sender, EventArgs e)
        {
            db_Combo6.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 11) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox29_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox29.Text == "") { textBox29.Text = "1"; }
                db_Combo7.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 12) AND (SCode=" + textBox29.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                comboBoxSoldier.Focus();
            }
        }

        private void db_Combo7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo7.SelectedIndex >= 0)
                if (db_Combo7.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox29.Text = db_Combo7.SelectedValue.ToString();
        }

        private void db_Combo7_Enter(object sender, EventArgs e)
        {
            db_Combo7.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 12) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox31.Text == "") { textBox31.Text = "1"; }
                db_Combo8.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 10) AND (SCode=" + textBox31.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox32.Focus();
            }
        }

        private void db_Combo8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo8.SelectedIndex >= 0)
                if (db_Combo8.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox31.Text = db_Combo8.SelectedValue.ToString();
        }

        private void db_Combo8_Enter(object sender, EventArgs e)
        {
            db_Combo8.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 10) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox32_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox32.Text == "") { textBox32.Text = "1"; }
                db_Combo10.Bind_Data1("SELECT tmpid, name_moafiat FROM Tbl_moafiat_maliat WHERE (tmpid=" + textBox32.Text + ")", "name_moafiat", "tmpid");
                textBox33.Focus();
            }
        }

        private void db_Combo10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo10.SelectedIndex >= 0)
                if (db_Combo10.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox32.Text = db_Combo10.SelectedValue.ToString();
        }

        private void db_Combo10_Enter(object sender, EventArgs e)
        {
            db_Combo10.Bind_Data1("SELECT tmpid, name_moafiat FROM Tbl_moafiat_maliat", "name_moafiat", "tmpid");
        }

        private void textBox33_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox33.Text == "") { textBox33.Text = "1"; }
                db_Combo9.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 19) AND (SCode=" + textBox33.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox34.Focus();
            }
        }

        private void db_Combo9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo9.SelectedIndex >= 0)
                if (db_Combo9.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox33.Text = db_Combo9.SelectedValue.ToString();
        }

        private void db_Combo9_Enter(object sender, EventArgs e)
        {
            db_Combo9.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 19) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void textBox34_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox34.Text == "") { textBox34.Text = "1"; }
                db_Combo11.Bind_Data1("SELECT tmpid, name_moafiat FROM Tbl_moafiat_bimeh WHERE (tmpid=" + textBox34.Text + ")", "name_moafiat", "tmpid");
                textBox35.Focus();
            }
        }

        private void db_Combo11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo11.SelectedIndex >= 0)
                if (db_Combo11.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox34.Text = db_Combo11.SelectedValue.ToString();
        }

        private void db_Combo11_Enter(object sender, EventArgs e)
        {
            db_Combo11.Bind_Data1("SELECT tmpid, name_moafiat FROM Tbl_moafiat_bimeh", "name_moafiat", "tmpid");
        }

        private void textBox35_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox35.Text == "") { textBox35.Text = "1"; }
                db_Combo12.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_1 WHERE (Code=" + textBox35.Text + ") ORDER BY Desc1", "Desc1", "Code");
                textBox36.Focus();
            }
        }

        private void db_Combo12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo12.SelectedIndex >= 0)
                if (db_Combo12.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox35.Text = db_Combo12.SelectedValue.ToString();
        }

        private void db_Combo12_Enter(object sender, EventArgs e)
        {
            db_Combo12.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_1 ORDER BY Desc1", "Desc1", "Code");
        }

        private void textBox36_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox36.Text == "") { textBox36.Text = "1"; }
                db_Combo13.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_City WHERE (Code=" + textBox36.Text + ") ORDER BY Desc1", "Desc1", "Code");
                textBox38.Focus();
            }
        }

        private void db_Combo13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo13.SelectedIndex >= 0)
                if (db_Combo13.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox36.Text = db_Combo13.SelectedValue.ToString();
        }

        private void db_Combo13_Enter(object sender, EventArgs e)
        {
            db_Combo13.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_City ORDER BY Desc1", "Desc1", "Code");
        }

        private void textBox38_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox38.Text == "") { textBox38.Text = "1"; }
                db_Combo14.Bind_Data1("SELECT Job_Code, Job_Desc FROM Bimeh_tab_job WHERE (Job_Code='" + textBox38.Text + "')", "Job_Desc", "Job_Code");
                textBox39.Focus();
            }
        }

        private void db_Combo14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo14.SelectedIndex >= 0)
                if (db_Combo14.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox38.Text = db_Combo14.SelectedValue.ToString();
        }

        private void db_Combo14_Enter(object sender, EventArgs e)
        {
            db_Combo14.Bind_Data1("SELECT Job_Code, Job_Desc FROM Bimeh_tab_job ORDER BY Job_Desc", "Job_Desc", "Job_Code");
        }

        private void textBox39_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox39.Text == "") { textBox39.Text = "1"; }
                db_Combo15.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_Education WHERE (Code=" + textBox39.Text + ") ORDER BY Desc1", "Desc1", "Code");
                textBox40.Focus();
            }
        }

        private void db_Combo15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo15.SelectedIndex >= 0)
                if (db_Combo15.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox39.Text = db_Combo15.SelectedValue.ToString();
        }

        private void db_Combo15_Enter(object sender, EventArgs e)
        {
            db_Combo15.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_Education ORDER BY Desc1", "Desc1", "Code");
        }

        private void textBox40_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox40.Text == "") { textBox40.Text = "1"; }
                db_Combo16.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_Field WHERE (Code=" + textBox40.Text + ") ORDER BY Desc1", "Desc1", "Code");
                butt_ok.Focus();
            }
        }

        private void db_Combo16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo16.SelectedIndex >= 0)
                if (db_Combo16.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox40.Text = db_Combo16.SelectedValue.ToString();
        }

        private void db_Combo16_Enter(object sender, EventArgs e)
        {
            db_Combo16.Bind_Data1("SELECT Code, Desc1 FROM Bimeh_Field ORDER BY Desc1", "Desc1", "Code");
        }

        private void textBox41_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox41.Text == "") { textBox41.Text = "1"; }
                db_Combo18.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 15) AND (SCode=" + textBox41.Text + ") ORDER BY SCode", "SDesc", "SCode");
                textBox8.Focus();
            }
        }

        private void db_Combo18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo18.SelectedIndex >= 0)
                if (db_Combo18.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox41.Text = db_Combo18.SelectedValue.ToString();
        }

        private void db_Combo18_Enter(object sender, EventArgs e)
        {
            db_Combo18.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 15) ORDER BY SCode", "SDesc", "SCode");
        }

        private void textBox42_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox42.Text == "") { textBox42.Text = "1"; }
                db_Combo19.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 16) AND (SCode=" + textBox42.Text + ") ORDER BY SCode", "SDesc", "SCode");
                textBox5.Focus();
            }
        }

        private void db_Combo19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo19.SelectedIndex >= 0)
                if (db_Combo19.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox42.Text = db_Combo19.SelectedValue.ToString();
        }

        private void db_Combo19_Enter(object sender, EventArgs e)
        {
            db_Combo19.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 16) ORDER BY SCode", "SDesc", "SCode");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox3.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox4.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { comboBox2.Focus(); }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox9.Focus(); }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox10.Focus(); }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { comboBox1.Focus(); }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox11.Text = "0";
                    textBox12.Focus();
                }
                else
                {
                    textBox11.Focus();
                }
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox12.Focus(); }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox13.Focus(); }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox14.Focus(); }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox15.Focus(); }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox16.Focus(); }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox17.Focus(); }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox18.Focus(); }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox19.Focus(); }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { db_Combo1.Focus(); }
        }

        private void db_Combo1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox5.Focus(); }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox21.Focus(); }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox24.Focus(); }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox41.Focus(); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox2.Focus(); }
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox1.Focus(); }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox3.Focus(); }
        }

        private void maskedTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox4.Focus(); }
        }

        private void maskedTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox42.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox23.Focus(); }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox6.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { button1.Focus(); }
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox39_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox40_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox20.Focus(); }
        }

        private void comboBoxSoldier_KeyDown(object sender, KeyEventArgs e)
        {
            textBox31.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != 8) && (e.KeyChar != 13)) e.Handled = !char.IsDigit(e.KeyChar); 
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox6.Focus();
            }
            else
            {
                textBox6.Text = "0";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox7.Focus();
            }
            else
            {
                textBox7.Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string amin1 = "({Print_Process;1.idgroup}=" + id_group + ")AND ({Print_Process;1.idyear}=" + id_year + ") AND ({Print_Process;1.idmoon}=" + id_moon + ")";
            amin1 += " AND ({Print_Process;1.code} = '" + textBox1.Text + "')";

            Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
            f.selkar = "Report_Garardad";
            f.recore_sel = amin1;
            f.Show();
        }
    }
}
