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
    public partial class Form15 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base database = new DB_Base();

        public Form15()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {
            objDataAdapter.SelectCommand = new SqlCommand();
            objDataAdapter.SelectCommand.Connection = objConnection;
            objDataAdapter.SelectCommand.CommandText = "SELECT * FROM Tbl_calc ORDER BY tmpid";
            objDataAdapter.SelectCommand.CommandType = CommandType.Text;

            objConnection.Open();
            objDataAdapter.Fill(objDataSet, "Tbl_calc");
            objConnection.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            database.objCommand.CommandText = "UPDATE Tbl_calc SET formola1=@formola11  WHERE (tmpid=1)";
            database.objCommand.Parameters.AddWithValue("@formola11", textBox2.Text);

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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Substring(1, textBox2.SelectionStart) + " (B1) " + textBox2.Text.Substring(textBox2.SelectionStart,textBox2.Text.Length);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            textBox2.Text = objDataSet.Tables["Tbl_calc"].Rows[0]["formola1"].ToString();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            textBox2.Text = objDataSet.Tables["Tbl_calc"].Rows[1]["formola1"].ToString();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            textBox2.Text = objDataSet.Tables["Tbl_calc"].Rows[2]["formola1"].ToString();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            textBox2.Text = objDataSet.Tables["Tbl_calc"].Rows[3]["formola1"].ToString();
        }
    }
}
