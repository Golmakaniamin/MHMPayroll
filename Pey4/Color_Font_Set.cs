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
    public partial class Color_Font_Set : Form
    {
        DB_Base database = new DB_Base();
        DataSet objDataSet = new DataSet();

        public Color_Font_Set()
        {
            InitializeComponent();
        }

        private void Color_Font_Set_Load(object sender, EventArgs e)
        {
            database.Connection_Open();
            database.Fill("SELECT * FROM Color_Font_Set", objDataSet, "Color_Font_Set", true);
            database.Connection_Close();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Color_Font_Set";

            DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
            objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle objCurrencyCellStyle = new DataGridViewCellStyle();
            objCurrencyCellStyle.Format = "c";
            objCurrencyCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "شرح";
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            objCurrencyCellStyle = null;
            objAlternatingCellStyle = null;
            objAlignRightCellStyle = null;

            for (int q = 0; q <= dataGridView1.RowCount-1; q++)
            {
                if (dataGridView1.Rows[q].Cells["noe"].FormattedValue.ToString() == "1")
                {
                    TypeConverter tc2 = TypeDescriptor.GetConverter(typeof(Font));
                    Font newFont2 = (Font)tc2.ConvertFromString(dataGridView1.Rows[q].Cells["promp"].FormattedValue.ToString());

                    dataGridView1.Rows[q].Cells["name"].Style.Font = newFont2;
                }

                if (dataGridView1.Rows[q].Cells["noe"].FormattedValue.ToString() == "2")
                {
                    TypeConverter tc3 = TypeDescriptor.GetConverter(typeof(Color));
                    Color newColor3 = (Color)tc3.ConvertFromString(dataGridView1.Rows[q].Cells["promp"].FormattedValue.ToString());

                    dataGridView1.Rows[q].Cells["name"].Style.BackColor = newColor3;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (objDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(objDataSet, "Color_Font_Set");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString() == "1")
                {
                    TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Font));
                    Font newFont1 = (Font)tc1.ConvertFromString(dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());

                    FontDialog myDialog = new FontDialog();
                    myDialog.Font = newFont1;
                    if (myDialog.ShowDialog() == DialogResult.OK)
                    {
                        Font font = myDialog.Font;
                        
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                        string fontString = tc.ConvertToString(font);
                        objDataSet.Tables["Color_Font_Set"].Rows[e.RowIndex]["promp"] = fontString;

                        Font newFont = (Font)tc.ConvertFromString(fontString);
                        dataGridView1.Rows[e.RowIndex].Cells[2].Style.Font = newFont;
                    }
                }

                if (dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString() == "2")
                {
                    TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                    Color newColor1 = (Color)tc1.ConvertFromString(dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());

                    ColorDialog myDialog = new ColorDialog();
                    myDialog.Color = newColor1;
                    if (myDialog.ShowDialog() == DialogResult.OK)
                    {
                        Color color = myDialog.Color;

                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Color));
                        string colorString = tc.ConvertToString(color);
                        objDataSet.Tables["Color_Font_Set"].Rows[e.RowIndex]["promp"] = colorString;

                        Color newColor = (Color)tc.ConvertFromString(colorString);
                        dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = newColor;
                    }
                }
            }
        }
    }
}

