using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pey4
{
    public partial class Form24 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet1 = new DataSet();

        DataSet objDataSet = new DataSet();
        DB_Base DataBase = new DB_Base();
        DB_Base DataBase1 = new DB_Base();
        U_Base u_set = new U_Base();

        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            DataBase.Connection_Open();
            DataBase.Fill("SELECT * FROM Tab_Shrkat ORDER BY tmpid ASC", objDataSet, "Tab_Shrkat1", true);
            DataBase.Connection_Close();

            comboBox3.Items.Clear();
            comboBox3.DataSource = objDataSet.Tables["Tab_Shrkat1"];
            comboBox3.DisplayMember = "Groupname";
            comboBox3.ValueMember = "tmpid";

            if (objDataSet.Tables["Tab_Shrkat1"].Rows.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
                call_comboBox3_SelectedIndexChanged();

                PersianCalendar persian = new PersianCalendar();
                if (comboBox2.Items.Count > 0)
                {
                    int y = persian.GetYear(DateTime.Now);

                    for (int q = 0; q <= comboBox2.Items.Count - 1; q++)
                    {
                        comboBox2.SelectedIndex = q;
                        if (comboBox2.Text == y.ToString())
                            break;
                    }
                }

                int m = persian.GetMonth(DateTime.Now);
                comboBox1.SelectedIndex = m - 1;
            }

            DataBase.Connection_Open();
            DataBase.Fill("SELECT * FROM Tab_Shrkat ORDER BY tmpid ASC", objDataSet, "Tab_Shrkat2", true);
            DataBase.Connection_Close();

            comboBox6.Items.Clear();
            comboBox6.DataSource = objDataSet.Tables["Tab_Shrkat2"];
            comboBox6.DisplayMember = "Groupname";
            comboBox6.ValueMember = "tmpid";

            if (objDataSet.Tables["Tab_Shrkat2"].Rows.Count > 0)
            {
                comboBox6.SelectedIndex = 0;
                call_comboBox6_SelectedIndexChanged();

                PersianCalendar persian = new PersianCalendar();
                if (comboBox5.Items.Count > 0)
                {
                    int y = persian.GetYear(DateTime.Now);

                    for (int q = 0; q <= comboBox5.Items.Count - 1; q++)
                    {
                        comboBox5.SelectedIndex = q;
                        if (comboBox5.Text == y.ToString())
                            break;
                    }
                }

                int m = persian.GetMonth(DateTime.Now);
                comboBox4.SelectedIndex = m - 1;
            }
        }

        private void call_comboBox3_SelectedIndexChanged()
        {
            if (comboBox3.Items.Count > 0)
            {
                if (comboBox3.SelectedValue != null)
                {
                    if (comboBox3.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        DataBase1.Connection_Open();
                        DataBase1.Fill("SELECT DISTINCT moh_sal FROM tbl_month WHERE (idgroup=" + comboBox3.SelectedValue.ToString() + ") ORDER BY moh_sal ASC ", objDataSet, "tbl_month1", true);
                        DataBase1.Connection_Close();

                        comboBox2.Items.Clear();
                        if (objDataSet.Tables["tbl_month1"].Rows.Count > 0)
                        {
                            for (int q = 0; q <= objDataSet.Tables["tbl_month1"].Rows.Count - 1; q++)
                            {
                                comboBox2.Items.Add(objDataSet.Tables["tbl_month1"].Rows[q]["moh_sal"].ToString());
                            }
                        }
                        objDataSet.Tables["tbl_month1"].Clear();
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            call_comboBox3_SelectedIndexChanged();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objDataSet1.Clear();

            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM tbl_personel WHERE (idgroup = " + comboBox3.SelectedValue.ToString() + ") AND (idyear = " + comboBox2.Text + ") AND (idmoon = " + Convert.ToString(comboBox1.SelectedIndex + 1) + ")";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;
            objConnection.Open();
            objDataAdapter.Fill(objDataSet1, "tbl_personel");
            objConnection.Close();

            if (objDataSet1.Tables["tbl_personel"].Rows.Count > 0)
            {
                grdAuthorTitles.AutoGenerateColumns = true;

                grdAuthorTitles.DataSource = objDataSet1;
                grdAuthorTitles.DataMember = "tbl_personel";

                DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
                objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
                objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
                grdAuthorTitles.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

                DataGridViewCellStyle objCurrencyCellStyle = new DataGridViewCellStyle();
                objCurrencyCellStyle.Format = "c";
                objCurrencyCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdAuthorTitles.Columns[0].Visible = false;
                grdAuthorTitles.Columns[1].Visible = false;
                grdAuthorTitles.Columns[2].Visible = false;
                grdAuthorTitles.Columns[3].Visible = false;
                grdAuthorTitles.Columns[4].HeaderText = "انتخاب";
                grdAuthorTitles.Columns[5].HeaderText = "کد پرسنل";
                grdAuthorTitles.Columns[6].HeaderText = "نام";
                grdAuthorTitles.Columns[7].HeaderText = "نام خانوادگی";
                grdAuthorTitles.Columns[8].HeaderText = "نام پدر";
                grdAuthorTitles.Columns[9].HeaderText = "جنسیت";
                grdAuthorTitles.Columns[10].HeaderText = "کد ملی";
                grdAuthorTitles.Columns[11].HeaderText = "شماره شناسنامه";

                for (int asd = 12; asd <= grdAuthorTitles.Columns.Count-1; asd++)
                {
                    grdAuthorTitles.Columns[asd].Visible = false;
                }

                objCurrencyCellStyle = null;
                objAlternatingCellStyle = null;
                objAlignRightCellStyle = null;
            }
            else
                MessageBox.Show("اطلاعاتی در این ماه برای انتخاب وجود ندارد", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("آیا تنظیمات را صحیح انجام داده اید. آیا اطمینان دارید؟", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (objDataSet1.Tables["tbl_personel"].Rows.Count > 0)
                {
                    string id_year1, id_moon1, id_group1;
                    string id_year2, id_moon2, id_group2;

                    id_group1 = comboBox3.SelectedValue.ToString();
                    id_year1 = comboBox2.Text;
                    id_moon1 = Convert.ToString(comboBox1.SelectedIndex + 1);

                    id_group2 = comboBox6.SelectedValue.ToString();
                    id_year2 = comboBox5.Text;
                    id_moon2 = Convert.ToString(comboBox4.SelectedIndex + 1);

                    if (radioButton1.Checked == true)
                    {
                        //حالت اول
                        SqlCommand delete1 = new SqlCommand();
                        delete1.Connection = objConnection;
                        delete1.CommandText = "DELETE FROM tbl_personel WHERE (idgroup = " + id_group2 + ") AND (idyear = " + id_year2 + ") AND (idmoon = " + id_moon2 + ")";
                        delete1.CommandType = CommandType.Text;
                        objConnection.Open();
                        delete1.ExecuteNonQuery();
                        objConnection.Close();

                        if (checkBox1.Checked == true)
                        {
                            SqlCommand delete2 = new SqlCommand();
                            delete2.Connection = objConnection;
                            delete2.CommandText = "DELETE FROM Tbl_karkard WHERE (idgroup = " + id_group2 + ") AND (idyear = " + id_year2 + ") AND (idmoon = " + id_moon2 + ")";
                            delete2.CommandType = CommandType.Text;
                            objConnection.Open();
                            delete2.ExecuteNonQuery();
                            objConnection.Close();
                        }

                        if (checkBox2.Checked == true)
                        {
                            SqlCommand delete3 = new SqlCommand();
                            delete3.Connection = objConnection;
                            delete3.CommandText = "DELETE FROM Tbl_hogogpersonel WHERE (idgroup = " + id_group2 + ") AND (idyear = " + id_year2 + ") AND (idmoon = " + id_moon2 + ")";
                            delete3.CommandType = CommandType.Text;
                            objConnection.Open();
                            delete3.ExecuteNonQuery();
                            objConnection.Close();
                        }

                        for (int w = 0; w <= objDataSet1.Tables["tbl_personel"].Rows.Count - 1; w++)
                        {
                            if (objDataSet1.Tables["tbl_personel"].Rows[w]["selectid"].ToString() == "True")
                            {
                                SqlCommand insert1 = new SqlCommand();
                                insert1.Connection = objConnection;
                                insert1.CommandText = "INSERT INTO tbl_personel (idgroup,idyear,idmoon,code,name,family,name_pedar,sex,cod_mely,sh_sh,tahol,tedah_farzand,phon_manzel,phon_sabt,phon_hamra,name_bank,bank_shobeh,sh_hesab,sh_kart,code_posti,mar_tmpid,adress,tozihat,image_byte,maliat_madrak,maliat_onvanShoghl,maliat_serishenasnameh,maliat_vazmaskan,maliat_meliat,maliat_namekeshvar,maliat_nezamvazifeh,maliat_rasteshoghli,code_moafiat_maliat,maliat_vazmashin,code_moafiat_bimeh,bimeh_keshvar,bimeh_shahr,bimeh_mashagel,bimeh_tahsilat,bimeh_reshteh,sh_ghrardad,noe_garardad,hogog_morakhasi,data_tarkkar,data_estekhdam,data_shorogaradad,data_paiangarardad,noe_bimeh,sh_bimeh,modateh_gararda,NoeHoghog,hogog_rozaneh_tavafogh,hogog_rozaneh_ghanoni,uuser,udate,utime,upc,brithdate,list1,maliat_Moafiyat_vam,bimeh_meliat,list2) VALUES (@idgroup,@idyear,@idmoon,@code,@name,@family,@name_pedar,@sex,@cod_mely,@sh_sh,@tahol,@tedah_farzand,@phon_manzel,@phon_sabt,@phon_hamra,@name_bank,@bank_shobeh,@sh_hesab,@sh_kart,@code_posti,@mar_tmpid,@adress,@tozihat,@image_byte,@maliat_madrak,@maliat_onvanShoghl,@maliat_serishenasnameh,@maliat_vazmaskan,@maliat_meliat,@maliat_namekeshvar,@maliat_nezamvazifeh,@maliat_rasteshoghli,@code_moafiat_maliat,@maliat_vazmashin,@code_moafiat_bimeh,@bimeh_keshvar,@bimeh_shahr,@bimeh_mashagel,@bimeh_tahsilat,@bimeh_reshteh,@sh_ghrardad,@noe_garardad,@hogog_morakhasi,@data_tarkkar,@data_estekhdam,@data_shorogaradad,@data_paiangarardad,@noe_bimeh,@sh_bimeh,@modateh_gararda,@NoeHoghog,@hogog_rozaneh_tavafogh,@hogog_rozaneh_ghanoni,@uuser,@udate,@utime,@upc,@brithdate,@list1,@maliat_Moafiyat_vam,@bimeh_meliat,@list2)";
                                insert1.CommandType = CommandType.Text;

                                insert1.Parameters.AddWithValue("@code", objDataSet1.Tables["tbl_personel"].Rows[w]["code"]);
                                insert1.Parameters.AddWithValue("@name", objDataSet1.Tables["tbl_personel"].Rows[w]["name"]);
                                insert1.Parameters.AddWithValue("@family", objDataSet1.Tables["tbl_personel"].Rows[w]["family"]);
                                insert1.Parameters.AddWithValue("@name_pedar", objDataSet1.Tables["tbl_personel"].Rows[w]["name_pedar"]);
                                insert1.Parameters.AddWithValue("@sex", objDataSet1.Tables["tbl_personel"].Rows[w]["sex"]);
                                insert1.Parameters.AddWithValue("@cod_mely", objDataSet1.Tables["tbl_personel"].Rows[w]["cod_mely"]);
                                insert1.Parameters.AddWithValue("@sh_sh", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_sh"]);
                                insert1.Parameters.AddWithValue("@tahol", objDataSet1.Tables["tbl_personel"].Rows[w]["tahol"]);
                                insert1.Parameters.AddWithValue("@tedah_farzand", objDataSet1.Tables["tbl_personel"].Rows[w]["tedah_farzand"]);
                                insert1.Parameters.AddWithValue("@phon_manzel", objDataSet1.Tables["tbl_personel"].Rows[w]["phon_manzel"]);
                                insert1.Parameters.AddWithValue("@phon_sabt", objDataSet1.Tables["tbl_personel"].Rows[w]["phon_sabt"]);
                                insert1.Parameters.AddWithValue("@phon_hamra", objDataSet1.Tables["tbl_personel"].Rows[w]["phon_hamra"]);
                                insert1.Parameters.AddWithValue("@name_bank", objDataSet1.Tables["tbl_personel"].Rows[w]["name_bank"]);
                                insert1.Parameters.AddWithValue("@bank_shobeh", objDataSet1.Tables["tbl_personel"].Rows[w]["bank_shobeh"]);
                                insert1.Parameters.AddWithValue("@sh_hesab", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_hesab"]);
                                insert1.Parameters.AddWithValue("@sh_kart", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_kart"]);
                                insert1.Parameters.AddWithValue("@code_posti", objDataSet1.Tables["tbl_personel"].Rows[w]["code_posti"]);
                                insert1.Parameters.AddWithValue("@mar_tmpid", objDataSet1.Tables["tbl_personel"].Rows[w]["mar_tmpid"]);
                                insert1.Parameters.AddWithValue("@adress", objDataSet1.Tables["tbl_personel"].Rows[w]["adress"]);
                                insert1.Parameters.AddWithValue("@tozihat", objDataSet1.Tables["tbl_personel"].Rows[w]["tozihat"]);
                                insert1.Parameters.AddWithValue("@image_byte", objDataSet1.Tables["tbl_personel"].Rows[w]["image_byte"]);
                                insert1.Parameters.AddWithValue("@maliat_madrak", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_madrak"]);
                                insert1.Parameters.AddWithValue("@maliat_onvanShoghl", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_onvanShoghl"]);
                                insert1.Parameters.AddWithValue("@maliat_serishenasnameh", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_serishenasnameh"]);
                                insert1.Parameters.AddWithValue("@maliat_vazmaskan", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_vazmaskan"]);
                                insert1.Parameters.AddWithValue("@maliat_meliat", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_meliat"]);
                                insert1.Parameters.AddWithValue("@maliat_namekeshvar", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_namekeshvar"]);
                                insert1.Parameters.AddWithValue("@maliat_nezamvazifeh", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_nezamvazifeh"]);
                                insert1.Parameters.AddWithValue("@maliat_rasteshoghli", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_rasteshoghli"]);
                                insert1.Parameters.AddWithValue("@code_moafiat_maliat", objDataSet1.Tables["tbl_personel"].Rows[w]["code_moafiat_maliat"]);
                                insert1.Parameters.AddWithValue("@maliat_vazmashin", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_vazmashin"]);
                                insert1.Parameters.AddWithValue("@code_moafiat_bimeh", objDataSet1.Tables["tbl_personel"].Rows[w]["code_moafiat_bimeh"]);
                                insert1.Parameters.AddWithValue("@bimeh_keshvar", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_keshvar"]);
                                insert1.Parameters.AddWithValue("@bimeh_shahr", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_shahr"]);
                                insert1.Parameters.AddWithValue("@bimeh_mashagel", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_mashagel"]);
                                insert1.Parameters.AddWithValue("@bimeh_tahsilat", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_tahsilat"]);
                                insert1.Parameters.AddWithValue("@bimeh_reshteh", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_reshteh"]);
                                insert1.Parameters.AddWithValue("@bimeh_meliat", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_meliat"]);
                                insert1.Parameters.AddWithValue("@sh_ghrardad", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_ghrardad"]);
                                insert1.Parameters.AddWithValue("@noe_garardad", objDataSet1.Tables["tbl_personel"].Rows[w]["noe_garardad"]);
                                insert1.Parameters.AddWithValue("@hogog_morakhasi", objDataSet1.Tables["tbl_personel"].Rows[w]["hogog_morakhasi"]);
                                insert1.Parameters.AddWithValue("@data_tarkkar", objDataSet1.Tables["tbl_personel"].Rows[w]["data_tarkkar"]);
                                insert1.Parameters.AddWithValue("@data_estekhdam", objDataSet1.Tables["tbl_personel"].Rows[w]["data_estekhdam"]);
                                insert1.Parameters.AddWithValue("@data_shorogaradad", objDataSet1.Tables["tbl_personel"].Rows[w]["data_shorogaradad"]);
                                insert1.Parameters.AddWithValue("@data_paiangarardad", objDataSet1.Tables["tbl_personel"].Rows[w]["data_paiangarardad"]);
                                insert1.Parameters.AddWithValue("@noe_bimeh", objDataSet1.Tables["tbl_personel"].Rows[w]["noe_bimeh"]);
                                insert1.Parameters.AddWithValue("@sh_bimeh", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_bimeh"]);
                                insert1.Parameters.AddWithValue("@modateh_gararda", objDataSet1.Tables["tbl_personel"].Rows[w]["modateh_gararda"]);
                                insert1.Parameters.AddWithValue("@NoeHoghog", objDataSet1.Tables["tbl_personel"].Rows[w]["NoeHoghog"]);
                                insert1.Parameters.AddWithValue("@hogog_rozaneh_tavafogh", objDataSet1.Tables["tbl_personel"].Rows[w]["hogog_rozaneh_tavafogh"]);
                                insert1.Parameters.AddWithValue("@idgroup",Convert.ToInt32(id_group2));
                                insert1.Parameters.AddWithValue("@idyear", Convert.ToInt32(id_year2));
                                insert1.Parameters.AddWithValue("@idmoon", Convert.ToInt32(id_moon2));
                                insert1.Parameters.AddWithValue("@uuser", u_set.u_user());
                                insert1.Parameters.AddWithValue("@udate", u_set.u_date());
                                insert1.Parameters.AddWithValue("@utime", u_set.u_time());
                                insert1.Parameters.AddWithValue("@upc", u_set.u_pc());
                                insert1.Parameters.AddWithValue("@brithdate", objDataSet1.Tables["tbl_personel"].Rows[w]["brithdate"]);
                                insert1.Parameters.AddWithValue("@list1", objDataSet1.Tables["tbl_personel"].Rows[w]["list1"]);
                                insert1.Parameters.AddWithValue("@hogog_rozaneh_ghanoni", objDataSet1.Tables["tbl_personel"].Rows[w]["hogog_rozaneh_ghanoni"]);
                                insert1.Parameters.AddWithValue("@maliat_Moafiyat_vam", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_Moafiyat_vam"]);
                                insert1.Parameters.AddWithValue("@list2", objDataSet1.Tables["tbl_personel"].Rows[w]["list2"]);

                                objConnection.Open();
                                insert1.ExecuteNonQuery();
                                objConnection.Close();
                                
                                DataBase.Connection_Open();
                                DataBase.Fill("SELECT MAX(tmpid) AS rsmax FROM tbl_personel", objDataSet1, "tbl_personel_max", true);
                                DataBase.Connection_Close();

                                //کارکرد
                                if (checkBox1.Checked == true)
                                {
                                    DataBase.Connection_Open();
                                    DataBase.Fill("SELECT * FROM Tbl_karkard WHERE (idgroup = " + id_group1 + ") AND (idyear = " + id_year1 + ") AND (idmoon = " + id_moon1 + ") AND (idpersonal = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")", objDataSet1, "Tbl_karkard", true);
                                    DataBase.Connection_Close();

                                    if (objDataSet1.Tables["Tbl_karkard"].Rows.Count > 0)
                                    {
                                        for (int p = 0; p <= objDataSet1.Tables["Tbl_karkard"].Rows.Count - 1; p++)
                                        {
                                            SqlCommand insert2 = new SqlCommand();
                                            insert2.Connection = objConnection;
                                            insert2.CommandText = "INSERT INTO Tbl_karkard (idgroup, idyear, idmoon, idpersonal, q1, q2, q3, q4, q5, q6,type1) VALUES (@idgroup, @idyear, @idmoon, @idpersonal, @q1, @q2, @q3, @q4, @q5, @q6, @type1)";
                                            insert2.CommandType = CommandType.Text;
                                            insert2.Parameters.AddWithValue("@idgroup", id_group2);
                                            insert2.Parameters.AddWithValue("@idyear", id_year2);
                                            insert2.Parameters.AddWithValue("@idmoon", id_moon2);
                                            insert2.Parameters.AddWithValue("@idpersonal", objDataSet1.Tables["tbl_personel_max"].Rows[0]["rsmax"]);
                                            insert2.Parameters.AddWithValue("@q1", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q1"]);
                                            insert2.Parameters.AddWithValue("@q2", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q2"]);
                                            insert2.Parameters.AddWithValue("@q3", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q3"]);
                                            insert2.Parameters.AddWithValue("@q4", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q4"]);
                                            insert2.Parameters.AddWithValue("@q5", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q5"]);
                                            insert2.Parameters.AddWithValue("@q6", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q6"]);
                                            insert2.Parameters.AddWithValue("@type1", objDataSet1.Tables["Tbl_karkard"].Rows[p]["type1"]);

                                            objConnection.Open();
                                            insert2.ExecuteNonQuery();
                                            objConnection.Close();
                                        }
                                    }
                                    objDataSet1.Tables["Tbl_karkard"].Clear();
                                }

                                //حقوق و مزایا
                                if (checkBox2.Checked == true)
                                {
                                    DataBase.Connection_Open();
                                    DataBase.Fill("SELECT * FROM Tbl_hogogpersonel WHERE (idgroup = " + id_group1 + ") AND (idyear = " + id_year1 + ") AND (idmoon = " + id_moon1 + ") AND (tmpid_personel = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")", objDataSet1, "Tbl_hogogpersonel", true);
                                    DataBase.Connection_Close();
                                    if (objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count > 0)
                                    {
                                        for (int p = 0; p <= objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count - 1; p++)
                                        {
                                            SqlCommand insert2 = new SqlCommand();
                                            insert2.Connection = objConnection;
                                            insert2.CommandText = "INSERT INTO Tbl_hogogpersonel (idgroup, idyear, idmoon, tmpid_personel, tmpid_hogog, list1, list2, money1) VALUES (@idgroup, @idyear, @idmoon, @tmpid_personel, @tmpid_hogog, @list1, @list2, @money1)";
                                            insert2.CommandType = CommandType.Text;
                                            insert2.Parameters.AddWithValue("@idgroup", id_group2);
                                            insert2.Parameters.AddWithValue("@idyear", id_year2);
                                            insert2.Parameters.AddWithValue("@idmoon", id_moon2);
                                            insert2.Parameters.AddWithValue("@tmpid_personel", objDataSet1.Tables["tbl_personel_max"].Rows[0]["rsmax"]);
                                            insert2.Parameters.AddWithValue("@tmpid_hogog", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["tmpid_hogog"]);
                                            insert2.Parameters.AddWithValue("@list1", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["list1"]);
                                            insert2.Parameters.AddWithValue("@list2", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["list2"]);
                                            insert2.Parameters.AddWithValue("@money1", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["money1"]);

                                            objConnection.Open();
                                            insert2.ExecuteNonQuery();
                                            objConnection.Close();
                                        }
                                    }
                                    objDataSet1.Tables["Tbl_hogogpersonel"].Clear();
                                }
                                objDataSet1.Tables["tbl_personel_max"].Clear();
                            }
                        }
                    }


                    if (radioButton2.Checked == true)
                    {
                        DB_Base database = new DB_Base();

                        for (int w = 0; w <= objDataSet1.Tables["tbl_personel"].Rows.Count - 1; w++)
                        {
                            if (objDataSet1.Tables["tbl_personel"].Rows[w]["selectid"].ToString() == "True")
                            {
                                //حالت اول
                                SqlCommand delete1 = new SqlCommand();
                                delete1.Connection = objConnection;
                                delete1.CommandText = "DELETE FROM tbl_personel WHERE (idgroup = " + id_group2 + ") AND (idyear = " + id_year2 + ") AND (idmoon = " + id_moon2 + ") AND (tmpid = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")";
                                delete1.CommandType = CommandType.Text;
                                objConnection.Open();
                                delete1.ExecuteNonQuery();
                                objConnection.Close();

                                SqlCommand insert1 = new SqlCommand();
                                insert1.Connection = objConnection;
                                insert1.CommandText = "INSERT INTO tbl_personel (idgroup,idyear,idmoon,code,name,family,name_pedar,sex,cod_mely,sh_sh,tahol,tedah_farzand,phon_manzel,phon_sabt,phon_hamra,name_bank,bank_shobeh,sh_hesab,sh_kart,code_posti,mar_tmpid,adress,tozihat,image_byte,maliat_madrak,maliat_onvanShoghl,maliat_serishenasnameh,maliat_vazmaskan,maliat_meliat,maliat_namekeshvar,maliat_nezamvazifeh,maliat_rasteshoghli,code_moafiat_maliat,maliat_vazmashin,code_moafiat_bimeh,bimeh_keshvar,bimeh_shahr,bimeh_mashagel,bimeh_tahsilat,bimeh_reshteh,sh_ghrardad,noe_garardad,hogog_morakhasi,data_tarkkar,data_estekhdam,data_shorogaradad,data_paiangarardad,noe_bimeh,sh_bimeh,modateh_gararda,NoeHoghog,hogog_rozaneh_tavafogh,hogog_rozaneh_ghanoni,uuser,udate,utime,upc,brithdate,list1,maliat_Moafiyat_vam,bimeh_meliat,list2) VALUES (@idgroup,@idyear,@idmoon,@code,@name,@family,@name_pedar,@sex,@cod_mely,@sh_sh,@tahol,@tedah_farzand,@phon_manzel,@phon_sabt,@phon_hamra,@name_bank,@bank_shobeh,@sh_hesab,@sh_kart,@code_posti,@mar_tmpid,@adress,@tozihat,@image_byte,@maliat_madrak,@maliat_onvanShoghl,@maliat_serishenasnameh,@maliat_vazmaskan,@maliat_meliat,@maliat_namekeshvar,@maliat_nezamvazifeh,@maliat_rasteshoghli,@code_moafiat_maliat,@maliat_vazmashin,@code_moafiat_bimeh,@bimeh_keshvar,@bimeh_shahr,@bimeh_mashagel,@bimeh_tahsilat,@bimeh_reshteh,@sh_ghrardad,@noe_garardad,@hogog_morakhasi,@data_tarkkar,@data_estekhdam,@data_shorogaradad,@data_paiangarardad,@noe_bimeh,@sh_bimeh,@modateh_gararda,@NoeHoghog,@hogog_rozaneh_tavafogh,@hogog_rozaneh_ghanoni,@uuser,@udate,@utime,@upc,@brithdate,@list1,@maliat_Moafiyat_vam,@bimeh_meliat,@list2)";
                                insert1.CommandType = CommandType.Text;

                                insert1.Parameters.AddWithValue("@code", objDataSet1.Tables["tbl_personel"].Rows[w]["code"]);
                                insert1.Parameters.AddWithValue("@name", objDataSet1.Tables["tbl_personel"].Rows[w]["name"]);
                                insert1.Parameters.AddWithValue("@family", objDataSet1.Tables["tbl_personel"].Rows[w]["family"]);
                                insert1.Parameters.AddWithValue("@name_pedar", objDataSet1.Tables["tbl_personel"].Rows[w]["name_pedar"]);
                                insert1.Parameters.AddWithValue("@sex", objDataSet1.Tables["tbl_personel"].Rows[w]["sex"]);
                                insert1.Parameters.AddWithValue("@cod_mely", objDataSet1.Tables["tbl_personel"].Rows[w]["cod_mely"]);
                                insert1.Parameters.AddWithValue("@sh_sh", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_sh"]);
                                insert1.Parameters.AddWithValue("@tahol", objDataSet1.Tables["tbl_personel"].Rows[w]["tahol"]);
                                insert1.Parameters.AddWithValue("@tedah_farzand", objDataSet1.Tables["tbl_personel"].Rows[w]["tedah_farzand"]);
                                insert1.Parameters.AddWithValue("@phon_manzel", objDataSet1.Tables["tbl_personel"].Rows[w]["phon_manzel"]);
                                insert1.Parameters.AddWithValue("@phon_sabt", objDataSet1.Tables["tbl_personel"].Rows[w]["phon_sabt"]);
                                insert1.Parameters.AddWithValue("@phon_hamra", objDataSet1.Tables["tbl_personel"].Rows[w]["phon_hamra"]);
                                insert1.Parameters.AddWithValue("@name_bank", objDataSet1.Tables["tbl_personel"].Rows[w]["name_bank"]);
                                insert1.Parameters.AddWithValue("@bank_shobeh", objDataSet1.Tables["tbl_personel"].Rows[w]["bank_shobeh"]);
                                insert1.Parameters.AddWithValue("@sh_hesab", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_hesab"]);
                                insert1.Parameters.AddWithValue("@sh_kart", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_kart"]);
                                insert1.Parameters.AddWithValue("@code_posti", objDataSet1.Tables["tbl_personel"].Rows[w]["code_posti"]);
                                insert1.Parameters.AddWithValue("@mar_tmpid", objDataSet1.Tables["tbl_personel"].Rows[w]["mar_tmpid"]);
                                insert1.Parameters.AddWithValue("@adress", objDataSet1.Tables["tbl_personel"].Rows[w]["adress"]);
                                insert1.Parameters.AddWithValue("@tozihat", objDataSet1.Tables["tbl_personel"].Rows[w]["tozihat"]);
                                insert1.Parameters.AddWithValue("@image_byte", objDataSet1.Tables["tbl_personel"].Rows[w]["image_byte"]);
                                insert1.Parameters.AddWithValue("@maliat_madrak", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_madrak"]);
                                insert1.Parameters.AddWithValue("@maliat_onvanShoghl", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_onvanShoghl"]);
                                insert1.Parameters.AddWithValue("@maliat_serishenasnameh", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_serishenasnameh"]);
                                insert1.Parameters.AddWithValue("@maliat_vazmaskan", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_vazmaskan"]);
                                insert1.Parameters.AddWithValue("@maliat_meliat", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_meliat"]);
                                insert1.Parameters.AddWithValue("@maliat_namekeshvar", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_namekeshvar"]);
                                insert1.Parameters.AddWithValue("@maliat_nezamvazifeh", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_nezamvazifeh"]);
                                insert1.Parameters.AddWithValue("@maliat_rasteshoghli", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_rasteshoghli"]);
                                insert1.Parameters.AddWithValue("@code_moafiat_maliat", objDataSet1.Tables["tbl_personel"].Rows[w]["code_moafiat_maliat"]);
                                insert1.Parameters.AddWithValue("@maliat_vazmashin", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_vazmashin"]);
                                insert1.Parameters.AddWithValue("@code_moafiat_bimeh", objDataSet1.Tables["tbl_personel"].Rows[w]["code_moafiat_bimeh"]);
                                insert1.Parameters.AddWithValue("@bimeh_keshvar", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_keshvar"]);
                                insert1.Parameters.AddWithValue("@bimeh_shahr", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_shahr"]);
                                insert1.Parameters.AddWithValue("@bimeh_mashagel", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_mashagel"]);
                                insert1.Parameters.AddWithValue("@bimeh_tahsilat", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_tahsilat"]);
                                insert1.Parameters.AddWithValue("@bimeh_reshteh", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_reshteh"]);
                                insert1.Parameters.AddWithValue("@bimeh_meliat", objDataSet1.Tables["tbl_personel"].Rows[w]["bimeh_meliat"]);
                                insert1.Parameters.AddWithValue("@sh_ghrardad", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_ghrardad"]);
                                insert1.Parameters.AddWithValue("@noe_garardad", objDataSet1.Tables["tbl_personel"].Rows[w]["noe_garardad"]);
                                insert1.Parameters.AddWithValue("@hogog_morakhasi", objDataSet1.Tables["tbl_personel"].Rows[w]["hogog_morakhasi"]);
                                insert1.Parameters.AddWithValue("@data_tarkkar", objDataSet1.Tables["tbl_personel"].Rows[w]["data_tarkkar"]);
                                insert1.Parameters.AddWithValue("@data_estekhdam", objDataSet1.Tables["tbl_personel"].Rows[w]["data_estekhdam"]);
                                insert1.Parameters.AddWithValue("@data_shorogaradad", objDataSet1.Tables["tbl_personel"].Rows[w]["data_shorogaradad"]);
                                insert1.Parameters.AddWithValue("@data_paiangarardad", objDataSet1.Tables["tbl_personel"].Rows[w]["data_paiangarardad"]);
                                insert1.Parameters.AddWithValue("@noe_bimeh", objDataSet1.Tables["tbl_personel"].Rows[w]["noe_bimeh"]);
                                insert1.Parameters.AddWithValue("@sh_bimeh", objDataSet1.Tables["tbl_personel"].Rows[w]["sh_bimeh"]);
                                insert1.Parameters.AddWithValue("@modateh_gararda", objDataSet1.Tables["tbl_personel"].Rows[w]["modateh_gararda"]);
                                insert1.Parameters.AddWithValue("@NoeHoghog", objDataSet1.Tables["tbl_personel"].Rows[w]["NoeHoghog"]);
                                insert1.Parameters.AddWithValue("@hogog_rozaneh_tavafogh", objDataSet1.Tables["tbl_personel"].Rows[w]["hogog_rozaneh_tavafogh"]);
                                insert1.Parameters.AddWithValue("@idgroup", Convert.ToInt32(id_group2));
                                insert1.Parameters.AddWithValue("@idyear", Convert.ToInt32(id_year2));
                                insert1.Parameters.AddWithValue("@idmoon", Convert.ToInt32(id_moon2));
                                insert1.Parameters.AddWithValue("@uuser", u_set.u_user());
                                insert1.Parameters.AddWithValue("@udate", u_set.u_date());
                                insert1.Parameters.AddWithValue("@utime", u_set.u_time());
                                insert1.Parameters.AddWithValue("@upc", u_set.u_pc());
                                insert1.Parameters.AddWithValue("@brithdate", objDataSet1.Tables["tbl_personel"].Rows[w]["brithdate"]);
                                insert1.Parameters.AddWithValue("@list1", objDataSet1.Tables["tbl_personel"].Rows[w]["list1"]);
                                insert1.Parameters.AddWithValue("@hogog_rozaneh_ghanoni", objDataSet1.Tables["tbl_personel"].Rows[w]["hogog_rozaneh_ghanoni"]);
                                insert1.Parameters.AddWithValue("@maliat_Moafiyat_vam", objDataSet1.Tables["tbl_personel"].Rows[w]["maliat_Moafiyat_vam"]);
                                insert1.Parameters.AddWithValue("@list2", objDataSet1.Tables["tbl_personel"].Rows[w]["list2"]);

                                objConnection.Open();
                                insert1.ExecuteNonQuery();
                                objConnection.Close();

                                DataBase.Connection_Open();
                                DataBase.Fill("SELECT MAX(tmpid) AS rsmax FROM tbl_personel", objDataSet1, "tbl_personel_max", true);
                                DataBase.Connection_Close();

                                //کارکرد
                                if (checkBox1.Checked == true)
                                {
                                    SqlCommand delete2 = new SqlCommand();
                                    delete2.Connection = objConnection;
                                    delete2.CommandText = "DELETE FROM Tbl_karkard WHERE (idgroup = " + id_group2 + ") AND (idyear = " + id_year2 + ") AND (idmoon = " + id_moon2 + ") AND (idpersonal = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")";
                                    delete2.CommandType = CommandType.Text;
                                    objConnection.Open();
                                    delete2.ExecuteNonQuery();
                                    objConnection.Close();

                                    DataBase.Connection_Open();
                                    DataBase.Fill("SELECT * FROM Tbl_karkard WHERE (idgroup = " + id_group1 + ") AND (idyear = " + id_year1 + ") AND (idmoon = " + id_moon1 + ") AND (idpersonal = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")", objDataSet1, "Tbl_karkard", true);
                                    DataBase.Connection_Close();

                                    if (objDataSet1.Tables["Tbl_karkard"].Rows.Count > 0)
                                    {
                                        for (int p = 0; p <= objDataSet1.Tables["Tbl_karkard"].Rows.Count - 1; p++)
                                        {
                                            SqlCommand insert2 = new SqlCommand();
                                            insert2.Connection = objConnection;
                                            insert2.CommandText = "INSERT INTO Tbl_karkard (idgroup, idyear, idmoon, idpersonal, q1, q2, q3, q4, q5, q6,type1) VALUES (@idgroup, @idyear, @idmoon, @idpersonal, @q1, @q2, @q3, @q4, @q5, @q6, @type1)";
                                            insert2.CommandType = CommandType.Text;
                                            insert2.Parameters.AddWithValue("@idgroup", id_group2);
                                            insert2.Parameters.AddWithValue("@idyear", id_year2);
                                            insert2.Parameters.AddWithValue("@idmoon", id_moon2);
                                            insert2.Parameters.AddWithValue("@idpersonal", objDataSet1.Tables["tbl_personel_max"].Rows[0]["rsmax"]);
                                            insert2.Parameters.AddWithValue("@q1", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q1"]);
                                            insert2.Parameters.AddWithValue("@q2", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q2"]);
                                            insert2.Parameters.AddWithValue("@q3", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q3"]);
                                            insert2.Parameters.AddWithValue("@q4", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q4"]);
                                            insert2.Parameters.AddWithValue("@q5", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q5"]);
                                            insert2.Parameters.AddWithValue("@q6", objDataSet1.Tables["Tbl_karkard"].Rows[p]["q6"]);
                                            insert2.Parameters.AddWithValue("@type1", objDataSet1.Tables["Tbl_karkard"].Rows[p]["type1"]);

                                            objConnection.Open();
                                            insert2.ExecuteNonQuery();
                                            objConnection.Close();
                                        }
                                    }
                                    objDataSet1.Tables["Tbl_karkard"].Clear();
                                }

                                //حقوق و مزایا
                                if (checkBox2.Checked == true)
                                {
                                    SqlCommand delete3 = new SqlCommand();
                                    delete3.Connection = objConnection;
                                    delete3.CommandText = "DELETE FROM Tbl_hogogpersonel WHERE (idgroup = " + id_group2 + ") AND (idyear = " + id_year2 + ") AND (idmoon = " + id_moon2 + ") AND (tmpid_personel = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")";
                                    delete3.CommandType = CommandType.Text;
                                    objConnection.Open();
                                    delete3.ExecuteNonQuery();
                                    objConnection.Close();

                                    DataBase.Connection_Open();
                                    DataBase.Fill("SELECT * FROM Tbl_hogogpersonel WHERE (idgroup = " + id_group1 + ") AND (idyear = " + id_year1 + ") AND (idmoon = " + id_moon1 + ") AND (tmpid_personel = " + objDataSet1.Tables["tbl_personel"].Rows[w]["tmpid"].ToString() + ")", objDataSet1, "Tbl_hogogpersonel", true);
                                    DataBase.Connection_Close();
                                    if (objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count > 0)
                                    {
                                        for (int p = 0; p <= objDataSet1.Tables["Tbl_hogogpersonel"].Rows.Count - 1; p++)
                                        {
                                            SqlCommand insert2 = new SqlCommand();
                                            insert2.Connection = objConnection;
                                            insert2.CommandText = "INSERT INTO Tbl_hogogpersonel (idgroup, idyear, idmoon, tmpid_personel, tmpid_hogog, list1, list2, money1) VALUES (@idgroup, @idyear, @idmoon, @tmpid_personel, @tmpid_hogog, @list1, @list2, @money1)";
                                            insert2.CommandType = CommandType.Text;
                                            insert2.Parameters.AddWithValue("@idgroup", id_group2);
                                            insert2.Parameters.AddWithValue("@idyear", id_year2);
                                            insert2.Parameters.AddWithValue("@idmoon", id_moon2);
                                            insert2.Parameters.AddWithValue("@tmpid_personel", objDataSet1.Tables["tbl_personel_max"].Rows[0]["rsmax"]);
                                            insert2.Parameters.AddWithValue("@tmpid_hogog", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["tmpid_hogog"]);
                                            insert2.Parameters.AddWithValue("@list1", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["list1"]);
                                            insert2.Parameters.AddWithValue("@list2", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["list2"]);
                                            insert2.Parameters.AddWithValue("@money1", objDataSet1.Tables["Tbl_hogogpersonel"].Rows[p]["money1"]);

                                            objConnection.Open();
                                            insert2.ExecuteNonQuery();
                                            objConnection.Close();
                                        }
                                    }
                                    objDataSet1.Tables["Tbl_hogogpersonel"].Clear();
                                }
                                objDataSet1.Tables["tbl_personel_max"].Clear();
                            }
                        }
                    }

                    MessageBox.Show(" اطلاعات با موفقیت جابجا شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //لیست خالی است
                }
            }
        }

        private void call_comboBox6_SelectedIndexChanged()
        {
            if (comboBox6.Items.Count > 0)
            {
                if (comboBox6.SelectedValue != null)
                {
                    if (comboBox6.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        DataBase1.Connection_Open();
                        DataBase1.Fill("SELECT DISTINCT moh_sal FROM tbl_month WHERE (idgroup=" + comboBox6.SelectedValue.ToString() + ") ORDER BY moh_sal ASC ", objDataSet, "tbl_month2", true);
                        DataBase1.Connection_Close();

                        comboBox5.Items.Clear();
                        if (objDataSet.Tables["tbl_month2"].Rows.Count > 0)
                        {
                            for (int q = 0; q <= objDataSet.Tables["tbl_month2"].Rows.Count - 1; q++)
                            {
                                comboBox5.Items.Add(objDataSet.Tables["tbl_month2"].Rows[q]["moh_sal"].ToString());
                            }
                        }
                        objDataSet.Tables["tbl_month2"].Clear();
                    }
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            call_comboBox6_SelectedIndexChanged();
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
    }
}
