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
    public partial class Form3 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base database = new DB_Base();
        U_Base U_set = new U_Base();

        public string GroupName;
        public string id_group;

        public Form3()
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

        private void Form_sec()
        {
            if (U_set.u_user_sec(16) == 0) { dataGridView1.AllowUserToAddRows = false; }
            if (U_set.u_user_sec(17) == 0) { dataGridView1.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { dataGridView1.AllowUserToDeleteRows = false; }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            this.Text = "سال مالی " + GroupName;

            database.Connection_Open();
            database.Fill("SELECT DISTINCT moh_sal as سال FROM tbl_month WHERE (idgroup = " + id_group.ToString() + ")", objDataSet, "tbl_month", true);
            database.Connection_Close();
            dataGridView1.DataSource = objDataSet.Tables["tbl_month"];
        }

        private void butt_ok_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("سال را وارد نکردید", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                sabt_mah();
                database.Connection_Open();
                database.Fill("SELECT DISTINCT moh_sal as سال FROM tbl_month WHERE (idgroup = " + id_group.ToString() + ")", objDataSet, "tbl_month", true);
                database.Connection_Close();

                dataGridView1.DataSource = objDataSet.Tables["tbl_month"];

                MessageBox.Show("ثبت با موفقیت انجام شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
            }
        }
        private void sabt_mah()
        {
            string[,] installs = new string[13, 4];

            installs[1, 1] = "فروردین";
            installs[1, 2] = "1";
            installs[1, 3] = "31";

            installs[2, 1] = "اردیبهشت";
            installs[2, 2] = "2";
            installs[2, 3] = "31";

            installs[3, 1] = "خرداد";
            installs[3, 2] = "3";
            installs[3, 3] = "31";

            installs[4, 1] = "تیر";
            installs[4, 2] = "4";
            installs[4, 3] = "31";

            installs[5, 1] = "مرداد";
            installs[5, 2] = "5";
            installs[5, 3] = "31";

            installs[6, 1] = "شهریور";
            installs[6, 2] = "6";
            installs[6, 3] = "31";
            
            installs[7, 1] = "مهر";
            installs[7, 2] = "7";
            installs[7, 3] = "30";

            installs[8, 1] = "آبان";
            installs[8, 2] = "8";
            installs[8, 3] = "30";

            installs[9, 1] = "آذر";
            installs[9, 2] = "9";
            installs[9, 3] = "30";

            installs[10, 1] = "دی";
            installs[10, 2] = "10";
            installs[10, 3] = "30";

            installs[11, 1] = "بهمن";
            installs[11, 2] = "11";
            installs[11, 3] = "30";

            installs[12, 1] = "اسفند";
            installs[12, 2] = "12";
            installs[12, 3] = "29";

            for (int q = 1; q <= 12; q++)
            {
                SqlCommand objCommand = new SqlCommand();
                objCommand.Connection = objConnection;
                objCommand.CommandText = "INSERT INTO tbl_month (moh_sal, moh_moh1, moh_moh, moh_tedad, idgroup) VALUES (@moh_sal, @moh_moh1, @moh_moh, @moh_tedad, @idgroup)";
                objCommand.CommandType = CommandType.Text;
                objCommand.Parameters.AddWithValue("@moh_sal", textBox1.Text);
                objCommand.Parameters.AddWithValue("@moh_moh", installs[q, 1]);
                objCommand.Parameters.AddWithValue("@moh_moh1", installs[q, 2]);
                objCommand.Parameters.AddWithValue("@moh_tedad", installs[q, 3]);
                objCommand.Parameters.AddWithValue("@idgroup", id_group.ToString());
                objConnection.Open();
                objCommand.ExecuteNonQuery();
                objConnection.Close();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != (char)8))
                e.KeyChar = (char)0;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objDataSet.Tables["tbl_month"].Rows.Count > 0)
            {
                Form4 f2 = new Form4();
                f2.GroupName = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                f2.id_group = id_group;
                f2.Show();
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { butt_ok.Focus(); }
        }
    }
}
