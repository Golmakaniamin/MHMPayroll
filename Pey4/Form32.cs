using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pey4
{
    public partial class Form32 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DB_Base database = new DB_Base();
        DataSet objDataSet = new DataSet();

        public string user_code;

        public Form32()
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

        private void Form32_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();

            database.Connection_Open();
            database.Fill("SELECT Tbl_Login_level.tmpid,Tbl_Login_level.name1,Cast( CASE WHEN Tbl_Login_IN.tmpid IS NULL THEN  0 WHEN Tbl_Login_IN.tmpid IS NOT NULL THEN  1 END AS bit) AS amin FROM Tbl_Login_level LEFT JOIN Tbl_Login_IN ON (Tbl_Login_level.tmpid = Tbl_Login_IN.tmpid_level) AND (Tbl_Login_IN.tmpid_login = " + user_code + ")", objDataSet, "Show_level", true);
            database.Connection_Close();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Show_level";

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "محیط کاربری";
            dataGridView1.Columns[2].HeaderText = "صدور مجوز";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int q = 0; q <= objDataSet.Tables["Show_level"].Rows.Count - 1; q++)
            {
                if (objDataSet.Tables["Show_level"].Rows[q]["amin"].ToString() == "True")
                {
                    database.Connection_Open();
                    database.Fill("SELECT * FROM Tbl_Login_IN WHERE ((tmpid_login = '" + user_code + "') AND (tmpid_level = '" + objDataSet.Tables["Show_level"].Rows[q]["tmpid"].ToString() + "'))", objDataSet, "Count_Show_level", true);
                    database.Connection_Close();

                    if (objDataSet.Tables["Count_Show_level"].Rows.Count == 0)
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.Connection = objConnection;
                        objCommand.CommandText = "INSERT INTO Tbl_Login_IN (tmpid_login,tmpid_level) VALUES (@tmpid_login,@tmpid_level)";
                        objCommand.CommandType = CommandType.Text;
                        objCommand.Parameters.AddWithValue("@tmpid_login", user_code);
                        objCommand.Parameters.AddWithValue("@tmpid_level", objDataSet.Tables["Show_level"].Rows[q]["tmpid"].ToString());

                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }
                    objDataSet.Tables["Count_Show_level"].Clear();
                }

                if (objDataSet.Tables["Show_level"].Rows[q]["amin"].ToString() == "False")
                {
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.Connection = objConnection;
                    objCommand.CommandText = "DELETE FROM Tbl_Login_IN WHERE ((tmpid_login = '" + user_code + "') AND (tmpid_level = '" + objDataSet.Tables["Show_level"].Rows[q]["tmpid"].ToString() + "'))";
                    objCommand.CommandType = CommandType.Text;

                    objConnection.Open();
                    objCommand.ExecuteNonQuery();
                    objConnection.Close();
                }
            }

            MessageBox.Show("اطلاعات با موفقیت به روز شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
