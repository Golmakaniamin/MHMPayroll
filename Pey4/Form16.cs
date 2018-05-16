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

    public partial class Form16 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        DataSet objDataSet = new DataSet();

        DB_Base database = new DB_Base();
        U_Base U_set = new U_Base();

        public Form16()
        {
            InitializeComponent();
        }

        private void delete()
        {
            textBox1.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";

            textBox3.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox3.Text = "";
            else
                textBox3.Text = "0";
        }

        private void Grid_Amin()
        {
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "کسورات و مزایا";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "نوع";
            dataGridView1.Columns[5].HeaderText = "عنوان";
            dataGridView1.Columns[6].HeaderText = "مبلغ (ریال)";
            dataGridView1.Columns[7].HeaderText = "مالیات";
            dataGridView1.Columns[8].HeaderText = "بیمه";
            dataGridView1.Columns[9].HeaderText = "درصد بیمه سهم کارفرما";
            dataGridView1.Columns[10].HeaderText = "درصد بیمه سهم بیکاری";
            dataGridView1.Columns[11].HeaderText = "درصد بیمه سهم پرسنل";
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].HeaderText = "کد حسابداری";
            dataGridView1.Columns[17].Visible = false;
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

        private void Form_sec()
        {
            if (U_set.u_user_sec(16) == 0) { dataGridView1.AllowUserToAddRows = false; }
            if (U_set.u_user_sec(17) == 0) { dataGridView1.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { dataGridView1.AllowUserToDeleteRows = false; }
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_hogog", objDataSet, "Tbl_hogog", true);
            database.Connection_Close();
            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Tbl_hogog";
            Grid_Amin();

            textBox3.Text = "0";
            textBox7.Text = "0";
            textBox6.Text = "0";
        }

        //private void Bind_2_Grid_Good()
        //{
        //    string Qry = "";
        //    string[] Search_Data;
        //    int i;
        //    bool first = true;

        //    if (textBox5.Text.Trim() == "")
        //        Qry = "SELECT [tmpid]as[ردیف],[hogog]AS[حقوق],[shahr]as[عنوان],[mablag]as[مبلغ],[maliat]as[مالیات],[maliat_darsad]as[درصد مالیات],[bimeh_karfarma]as[بیمه کارفرما],[karfarma_darsad]as[درصد بیمه کارفرما],[bimeh_personel]as[بیمه پرسنل],[personel_dasad]as[درصد بیمه پرسنل],[bimeh_bikari]as[بیمه بیکاری],[bikari_darsad]as[درصد بیمه بیکاری],[noe]as[نوع] FROM [Tbl_hogog]";

        //    else
        //    {
        //        Search_Data = textBox5.Text.Split(' ');

        //        Qry = "SELECT [tmpid]as[ردیف],[hogog]AS[حقوق],[shahr]as[عنوان],[mablag]as[مبلغ],[maliat]as[مالیات],[maliat_darsad]as[درصد مالیات],[bimeh_karfarma]as[بیمه کارفرما],[karfarma_darsad]as[درصد بیمه کارفرما],[bimeh_personel]as[بیمه پرسنل],[personel_dasad]as[درصد بیمه پرسنل],[bimeh_bikari]as[بیمه بیکاری],[bikari_darsad]as[درصد بیمه بیکاری],[noe]as[نوع] FROM [Tbl_hogog] WHERE (";

        //        for (i = 0; i < Search_Data.Length; i++)
        //        {
        //            if (Search_Data[i].Trim() != "")
        //            {
        //                if (first == false)
        //                    Qry += "And";
        //                Qry += "(";
        //                if (database.Is_Numeric(Search_Data[i]))
        //                {
        //                    Qry += "([tmpid] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([hogog] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([shahr] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([mablag] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([personel_dasad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([maliat_darsad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([karfarma_darsad] like '%" + Search_Data[i] + "%')";
        //                   Qry += "Or ([bikari_darsad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([noe] like '%" + Search_Data[i] + "%')";

        //                }
        //                else
        //                {
        //                    Qry += "([tmpid] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([hogog] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([shahr] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([mablag] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([personel_dasad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([maliat_darsad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([karfarma_darsad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([bikari_darsad] like '%" + Search_Data[i] + "%')";
        //                    Qry += "Or ([noe] like '%" + Search_Data[i] + "%')";
        //                }
        //                Qry += ")";
        //                first = false;
        //            }
        //        }
        //        Qry += ")";

        //    }
        //    database.Connection_Open();
        //    database.Fill(Qry, objDataSet, "Tbl_hogog", true);
        //    database.Connection_Close();
        //    dataGridView1.DataSource = objDataSet.Tables["Tbl_hogog"];

        //}


        //private void but_serch_Click(object sender, EventArgs e)
        //{
        //   // Bind_2_Grid_Good();
        //    String[] arrserarch;
        //    arrserarch = new String[22];

        //    String[] arrserarch1;
        //    arrserarch1 = new String[22];

        //    if (comboBox1.Text != "")
        //    {
        //        arrserarch[1] = " (hogog ='" + comboBox1.Text + "') AND ";
        //        arrserarch1[1] = " ({Tbl_hogog.hogog} Like '" + comboBox1.Text + "') AND ";
        //    }

        //    if (comboBox3.Text != "")
        //    {
        //        arrserarch[2] = " (noe = '" + comboBox3.Text + "') AND ";
        //        arrserarch1[2] = " ({Tbl_hogog.noe} Like  '" + comboBox3.Text + "') AND ";
        //    }


        //    if (textBox1.Text != "")
        //    {
        //        arrserarch[3] = " (shahr= '" + textBox1.Text + "') AND ";
        //        arrserarch1[3] = " ({Tbl_hogog.shahr} = '" + textBox1.Text + "') AND ";
        //    }

        //    if (textBox4.Text != "")
        //    {
        //        arrserarch[4] = " (mablag= '" + textBox4.Text + "') AND ";
        //        arrserarch1[4] = " ({Tbl_hogog.mablag} = '" + textBox4.Text + "') AND ";
        //    }

        //    arrserarch[0] = arrserarch[1] + arrserarch[2] + arrserarch[3] + arrserarch[4] + arrserarch[5] + arrserarch[6];
        //    arrserarch1[0] = arrserarch1[1] + arrserarch1[2] + arrserarch1[3] + arrserarch1[4] + arrserarch1[5] + arrserarch1[6];

        //    objDataSet.Clear();
        //    if (arrserarch[0] == "")
        //    {
        //        database.Connection_Open();
        //        database.Fill("SELECT * FROM Tbl_hogog", objDataSet, "Tbl_hogog", true);
        //        database.Connection_Close();
        //        dataGridView1.DataSource = objDataSet.Tables["Tbl_hogog"];
        //    }
        //    else
        //    {
        //        arrserarch[0] = arrserarch[0].Substring(1, arrserarch[0].Length - 5);
        //        arrserarch1[0] = arrserarch1[0].Substring(1, arrserarch1[0].Length - 5);

        //        database.Connection_Open();
        //        database.Fill("SELECT * FROM Tbl_hogog WHERE " + arrserarch[0], objDataSet, "Tbl_hogog", true);
        //        database.Connection_Close();
        //        dataGridView1.DataSource = objDataSet.Tables["Tbl_hogog"];
        //    }
        //}

        private void butt_ok_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نوع کسورات و مزایا را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا نوع را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus();
                return;
            }

            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا عنوان را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا مبلغ را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا کد حسابداری را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا بیمه کارفرما را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            if (textBox7.Text == "")
            {
                MessageBox.Show("لطفا بیمه پرسنل را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
                return;
            }

            if (textBox6.Text == "")
            {
                MessageBox.Show("لطفا بیمه بیکاری را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
                return;
            }

            if (label3.Text == "ADD")
            {
                SqlCommand insert1 = new SqlCommand();
                insert1.Connection = objConnection;
                objConnection.Open();

                insert1.CommandText = "INSERT INTO [Tbl_hogog] ([hogog],[shahr],[mablag],[noe],[maliat],[bimeh_karfarma],[karfarma_darsad],[personel_dasad],[bikari_darsad],[uuser],[udate],[utime],[upc],IDnoe,idAccounting) Values (@hogog,@shahr,@mablag,@noe,@maliat,@bimeh_karfarma,@karfarma_darsad,@personel_dasad,@bikari_darsad,@uuser,@udate,@utime,@upc,@IDnoe,@idAccounting)";
                insert1.CommandType = CommandType.Text;

                insert1.Parameters.AddWithValue("@hogog", comboBox1.Text);
                insert1.Parameters.AddWithValue("@shahr", textBox1.Text);
                insert1.Parameters.AddWithValue("@mablag", textBox4.Text);
                insert1.Parameters.AddWithValue("@IDnoe", comboBox3.SelectedIndex);
                insert1.Parameters.AddWithValue("@noe", comboBox3.Text);
                insert1.Parameters.AddWithValue("@maliat", checkBox1.Checked);
                insert1.Parameters.AddWithValue("@bimeh_karfarma", checkBox2.Checked);
                insert1.Parameters.AddWithValue("@karfarma_darsad", textBox3.Text);
                insert1.Parameters.AddWithValue("@bikari_darsad", textBox7.Text);
                insert1.Parameters.AddWithValue("@personel_dasad", textBox6.Text);
                insert1.Parameters.AddWithValue("@idAccounting", textBox2.Text);

                insert1.Parameters.AddWithValue("@uuser", "");
                insert1.Parameters.AddWithValue("@udate", database.u_date());
                insert1.Parameters.AddWithValue("@utime", database.u_time());
                insert1.Parameters.AddWithValue("@upc", database.u_pc());

                if (insert1.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("ثبت با موفقیت انجام شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                insert1.Dispose();
                objConnection.Close();
                delete();
            }

            if (label3.Text == "EDIT")
            {
                SqlCommand insert1 = new SqlCommand();
                insert1.Connection = objConnection;
                objConnection.Open();

                insert1.CommandText = "UPDATE Tbl_hogog SET hogog=@hogog ,shahr=@shahr ,mablag=@mablag ,noe=@noe ,maliat=@maliat ,bimeh_karfarma=@bimeh_karfarma ,karfarma_darsad=@karfarma_darsad ,personel_dasad=@personel_dasad ,bikari_darsad=@bikari_darsad ,uuser=@uuser ,udate=@udate ,utime=@utime ,upc=@upc ,IDnoe=@IDnoe ,idAccounting=@idAccounting WHERE (tmpid = '" + label6.Text + "')";
                insert1.CommandType = CommandType.Text;

                insert1.Parameters.AddWithValue("@hogog", comboBox1.Text);
                insert1.Parameters.AddWithValue("@shahr", textBox1.Text);
                insert1.Parameters.AddWithValue("@mablag", textBox4.Text);
                insert1.Parameters.AddWithValue("@IDnoe", comboBox3.SelectedIndex);
                insert1.Parameters.AddWithValue("@noe", comboBox3.Text);
                insert1.Parameters.AddWithValue("@maliat", checkBox1.Checked);
                insert1.Parameters.AddWithValue("@bimeh_karfarma", checkBox2.Checked);
                insert1.Parameters.AddWithValue("@karfarma_darsad", textBox3.Text);
                insert1.Parameters.AddWithValue("@bikari_darsad", textBox7.Text);
                insert1.Parameters.AddWithValue("@personel_dasad", textBox6.Text);
                insert1.Parameters.AddWithValue("@idAccounting", textBox2.Text);

                insert1.Parameters.AddWithValue("@uuser", "");
                insert1.Parameters.AddWithValue("@udate", database.u_date());
                insert1.Parameters.AddWithValue("@utime", database.u_time());
                insert1.Parameters.AddWithValue("@upc", database.u_pc());

                if (insert1.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("اطلاعات با موفقیت ویرایش شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                insert1.Dispose();
                objConnection.Close();
                delete();
            }

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_hogog", objDataSet, "Tbl_hogog", true);
            database.Connection_Close();

            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Tbl_hogog";
            Grid_Amin();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox3.Text = "";
            else
                textBox3.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (objDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(objDataSet, "Tbl_hogog");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if ((e.Row.Index == 0) || (e.Row.Index == 1))
            {
                e.Cancel = true;
            }

        }

        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objDataSet.HasChanges())
            {
                DialogResult result = MessageBox.Show("آیا مایل به ذخیره تغییرات می باشید", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
                    database.Connection_Open();
                    objCommandBuilder.DataAdapter.Update(objDataSet, "Tbl_hogog");
                    database.Connection_Close();
                    MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "ADD";
            delete();
            comboBox1.Focus();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                label3.Text = "EDIT";
                label6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();

                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();

                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();

                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();

                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[16].FormattedValue.ToString();

                checkBox1.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString());
                checkBox2.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString());
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { comboBox3.Focus(); }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox1.Focus(); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox4.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox3.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox7.Focus(); }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox6.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { butt_ok.Focus(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}





