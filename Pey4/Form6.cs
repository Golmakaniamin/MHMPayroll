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
    public partial class Form6 : Form
    {
        DataSet objDataSet = new DataSet();

        DB_Base database = new DB_Base();
        U_Base U_set = new U_Base();

        public Form6()
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
            if (U_set.u_user_sec(16) == 0) { dataGridView1.AllowUserToAddRows = false; }
            if (U_set.u_user_sec(17) == 0) { dataGridView1.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { dataGridView1.AllowUserToDeleteRows = false; }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            database.Connection_Open();
            database.Fill("SELECT * FROM [Tbl_login]", objDataSet, "Tbl_login", true);
            database.Connection_Close();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Tbl_login";

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[3].HeaderText = "کلمه عبور";
            dataGridView1.Columns[4].HeaderText = "مدیر سیستم";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (objDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(objDataSet, "Tbl_login");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (objDataSet.HasChanges())
            {
                DialogResult result = MessageBox.Show("آیا مایل به ذخیره تغییرات می باشید", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
                    database.Connection_Open();
                    objCommandBuilder.DataAdapter.Update(objDataSet, "Tbl_login");
                    database.Connection_Close();
                    MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Form32 f32 = new Form32();
                f32.user_code = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                f32.Text = " تعیین سطح دسترسی " + dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                f32.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
