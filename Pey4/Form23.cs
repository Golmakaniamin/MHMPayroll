using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pey4
{
    public partial class Form23 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();
        U_Base U_set = new U_Base();

        public string id_group;

        public Form23()
        {
            InitializeComponent();
        }

        public void Form_Load_set_color()
        {
            DataSet objDataSet1 = new DataSet();

            Database.Connection_Open();
            Database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet1, "Color_Font_Set", true);
            Database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

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

            dataGridViewZarayeb.Font = newFont7;
            dataGridViewZarayeb.BackgroundColor = newColor8;
            dataGridViewZarayeb.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridViewZarayeb.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridViewZarayeb.DefaultCellStyle = objAlignRightCellStyle3;

            dataGridViewMaliat.Font = newFont7;
            dataGridViewMaliat.BackgroundColor = newColor8;
            dataGridViewMaliat.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridViewMaliat.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridViewMaliat.DefaultCellStyle = objAlignRightCellStyle3;

            dataGridViewMoafiat.Font = newFont7;
            dataGridViewMoafiat.BackgroundColor = newColor8;
            dataGridViewMoafiat.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridViewMoafiat.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridViewMoafiat.DefaultCellStyle = objAlignRightCellStyle3;

            dataGridView1.Font = newFont7;
            dataGridView1.BackgroundColor = newColor8;
            dataGridView1.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridView1.DefaultCellStyle = objAlignRightCellStyle3;

            objDataSet1.Clear();
        }

        private void Form_sec()
        {
            if (U_set.u_user_sec(16) == 0) 
            {
                dataGridViewZarayeb.AllowUserToAddRows = false;
                dataGridViewMaliat.AllowUserToAddRows = false;
                dataGridViewMoafiat.AllowUserToAddRows = false;
                dataGridView1.AllowUserToAddRows = false; 
            }

            if (U_set.u_user_sec(17) == 0) 
            {
                dataGridViewZarayeb.ReadOnly = false;
                dataGridViewMaliat.ReadOnly = false;
                dataGridViewMoafiat.ReadOnly = false;
                dataGridView1.ReadOnly = false; 
            }

            if (U_set.u_user_sec(18) == 0) 
            {
                dataGridViewZarayeb.AllowUserToDeleteRows = false;
                dataGridViewMaliat.AllowUserToDeleteRows = false;
                dataGridViewMoafiat.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToDeleteRows = false; 
            }
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            Database.Connection_Open();
            
            Database.Fill("SELECT * FROM Tbl_moafiat_maliat", objDataSet, "Tbl_moafiat_maliat", true);
            Database.Fill("SELECT * FROM Tbl_moafiat_bimeh", objDataSet, "Tbl_moafiat_bimeh", true);
            Database.Fill("SELECT * FROM Tbl_zarib1", objDataSet, "Tbl_zarib1", true);
            Database.Fill("SELECT * FROM Tbl_maliat", objDataSet, "Tbl_maliat", true);
            Database.Fill("SELECT * FROM Tbl_bimeh WHERE (tmpid = 1)", objDataSet, "Tbl_bimeh1", true);
            
            Database.Connection_Close();

            //جدول معافیت مالیات
            dataGridViewMoafiat.DataSource = objDataSet;
            dataGridViewMoafiat.DataMember = "Tbl_moafiat_maliat";

            dataGridViewMoafiat.Columns[0].Visible = false;
            dataGridViewMoafiat.Columns[1].HeaderText = "کد معافیت";
            dataGridViewMoafiat.Columns[2].HeaderText = "نام معافیت";
            dataGridViewMoafiat.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewMoafiat.Columns[3].HeaderText = "مبلغ";
            dataGridViewMoafiat.Columns[4].HeaderText = "درصد";

            //جدول معافیت بیمه
            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Tbl_moafiat_bimeh";

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "کد معافیت";
            dataGridView1.Columns[2].HeaderText = "نام معافیت";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[3].HeaderText = "درصد معافیت بیمه کارفرما";
            dataGridView1.Columns[4].HeaderText = "درصد معافیت بیمه بیکاری";
            dataGridView1.Columns[5].HeaderText = "درصد معافیت بیمه پرسنل";

            //جدول ضرایب
            dataGridViewZarayeb.AutoGenerateColumns = true;
            dataGridViewZarayeb.DataSource = objDataSet;
            dataGridViewZarayeb.DataMember = "Tbl_zarib1";

            dataGridViewZarayeb.Columns[0].HeaderText = "کد";
            dataGridViewZarayeb.Columns[1].HeaderText = "شرح";
            dataGridViewZarayeb.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewZarayeb.Columns[1].Width = 200;
            dataGridViewZarayeb.Columns[2].HeaderText = "درصد";
            dataGridViewZarayeb.Columns[3].HeaderText = "مخزج";

            //جدول مالیات
            dataGridViewMaliat.AutoGenerateColumns = true;
            dataGridViewMaliat.DataSource = objDataSet;
            dataGridViewMaliat.DataMember = "Tbl_maliat";

            dataGridViewMaliat.Columns[0].Visible = false;
            dataGridViewMaliat.Columns[1].HeaderText = "از";
            dataGridViewMaliat.Columns[2].HeaderText = "تا";
            dataGridViewMaliat.Columns[3].HeaderText = "مالیات";

            //حقوق قانونی
            textBox1.Text = objDataSet.Tables["Tbl_bimeh1"].Rows[0]["sagf_hogog_mashmol"].ToString();
            textBox2.Text = objDataSet.Tables["Tbl_bimeh1"].Rows[0]["bimeh_karfarma"].ToString();
            textBox3.Text = objDataSet.Tables["Tbl_bimeh1"].Rows[0]["bimeh_bikari"].ToString();
            textBox4.Text = objDataSet.Tables["Tbl_bimeh1"].Rows[0]["bimeh_karkonan"].ToString();
            textBox5.Text = objDataSet.Tables["Tbl_bimeh1"].Rows[0]["sagf_Eydi"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //درصد بیمه کارفرما، بیکاری و پرسنل
            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا فیلد درصد بیمه سهم کارفرما را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا فیلد درصد بیمه سهم بیکاری را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا فیلد درصد بیمه سهم پرسنل را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET karfarma_darsad=" + textBox2.Text + " WHERE (bimeh_karfarma = '1')";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlExceptionErr)
            {
                MessageBox.Show(SqlExceptionErr.Message);
            }
            objConnection.Close();

            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET karfarma_darsad=0 WHERE (bimeh_karfarma = '0') ";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlExceptionErr)
            {
                MessageBox.Show(SqlExceptionErr.Message);
            }
            objConnection.Close();

            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET bikari_darsad=" + textBox3.Text + " WHERE (bimeh_bikari = '1')";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlExceptionErr)
            {
                MessageBox.Show(SqlExceptionErr.Message);
            }
            objConnection.Close();

            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET bikari_darsad=0 WHERE (bimeh_bikari = '0') ";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlExceptionErr)
            {
                MessageBox.Show(SqlExceptionErr.Message);
            }
            objConnection.Close();

            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET personel_dasad=" + textBox4.Text + " WHERE (bimeh_personel = '1')";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlExceptionErr)
            {
                MessageBox.Show(SqlExceptionErr.Message);
            }
            objConnection.Close();

            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_hogog SET personel_dasad=0 WHERE (bimeh_personel = '0') ";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            try
            {
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlExceptionErr)
            {
                MessageBox.Show(SqlExceptionErr.Message);
            }
            objConnection.Close();

            DB_Base database1 = new DB_Base();
            database1.objCommand.CommandText = "UPDATE Tbl_bimeh SET bimeh_karfarma=@bimeh_karfarma, bimeh_bikari=@bimeh_bikari, bimeh_karkonan=@bimeh_karkonan WHERE (tmpid = 1)";
            database1.objCommand.Parameters.AddWithValue("@bimeh_karfarma", textBox2.Text);
            database1.objCommand.Parameters.AddWithValue("@bimeh_bikari", textBox3.Text);
            database1.objCommand.Parameters.AddWithValue("@bimeh_karkonan", textBox4.Text);

            database1.Connection_Open();
            database1.objCommand.Connection = database1.objConnection;

            if (database1.objCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("ثبت با موفقیت انجام شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            database1.objCommand.Dispose();
            database1.Connection_Close();
            database1.objConnection.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //معافیت مالیات
            if (objDataSet.HasChanges())
            {
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = objConnection;
                objDataAdapter.SelectCommand.CommandText = "SELECT * FROM Tbl_moafiat_maliat";
                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder scb = new SqlCommandBuilder(objDataAdapter);
                objConnection.Open();
                scb.DataAdapter.Update(objDataSet, "Tbl_moafiat_maliat");
                objConnection.Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("تغییری در داده ها به وجود نیامده است ", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //معافیت بیمه
            if (objDataSet.HasChanges())
            {
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = objConnection;
                objDataAdapter.SelectCommand.CommandText = "SELECT * FROM Tbl_moafiat_bimeh";
                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder scb = new SqlCommandBuilder(objDataAdapter);
                objConnection.Open();
                scb.DataAdapter.Update(objDataSet, "Tbl_moafiat_bimeh");
                objConnection.Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("تغییری در داده ها به وجود نیامده است ", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //جدول ضرایب
            if (objDataSet.HasChanges())
            {
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = objConnection;
                objDataAdapter.SelectCommand.CommandText = "SELECT * FROM Tbl_zarib1";
                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder scb = new SqlCommandBuilder(objDataAdapter);
                objConnection.Open();
                scb.DataAdapter.Update(objDataSet, "Tbl_zarib1");
                objConnection.Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("تغییری در داده ها به وجود نیامده است ", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //جدول مالیات
            if (objDataSet.HasChanges())
            {
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.Connection = objConnection;
                objDataAdapter.SelectCommand.CommandText = "SELECT * FROM Tbl_maliat";
                objDataAdapter.SelectCommand.CommandType = CommandType.Text;
                SqlCommandBuilder scb = new SqlCommandBuilder(objDataAdapter);
                objConnection.Open();
                scb.DataAdapter.Update(objDataSet, "Tbl_maliat");
                objConnection.Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("تغییری در داده ها به وجود نیامده است ", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //حقوق مشمول بیمه و عیدی
            if (textBox1.Text == "")
            {
                MessageBox.Show("لطفا فیلد سقف حقوق مشمول بیمه را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }

            if (textBox5.Text == "")
            {
                MessageBox.Show("لطفا فیلد سقف عیدی را وارد نمایید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "UPDATE Tbl_bimeh SET sagf_hogog_mashmol=@sagf_hogog_mashmol, sagf_Eydi=@sagf_Eydi WHERE (tmpid = 1)";
            objCommand.Parameters.AddWithValue("@sagf_hogog_mashmol", textBox1.Text);
            objCommand.Parameters.AddWithValue("@sagf_Eydi", textBox5.Text);

            objConnection.Open();

            if (objCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("ثبت با موفقیت انجام شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            objConnection.Close();
        }
    }
}