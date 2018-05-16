using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pey4
{
    public partial class Form26 : Form
    {
        DataSet objDataSet = new DataSet();

        public Form26()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form26_Load(object sender, EventArgs e)
        {
            DB_Base database = new DB_Base();

            database.Connection_Open();
            database.Fill("SELECT * FROM [PKH] WHERE (no1 = 1)", objDataSet, "PKH1_1", true);
            database.Connection_Close();

            if (objDataSet.Tables["PKH1_1"].Rows[0]["no2"].ToString() == "1")
                radioButton1.Checked = true;
            else if (objDataSet.Tables["PKH1_1"].Rows[0]["no2"].ToString() == "2")
                radioButton2.Checked = true;
            else if (objDataSet.Tables["PKH1_1"].Rows[0]["no2"].ToString() == "3")
                radioButton3.Checked = true;
            else if (objDataSet.Tables["PKH1_1"].Rows[0]["no2"].ToString() == "4")
                radioButton4.Checked = true;

            textBox1.Text = objDataSet.Tables["PKH1_1"].Rows[0]["q1"].ToString();
            maskedTextBox1.Text = objDataSet.Tables["PKH1_1"].Rows[0]["q2"].ToString();
            textBox2.Text = objDataSet.Tables["PKH1_1"].Rows[0]["q3"].ToString();
            textBox3.Text = objDataSet.Tables["PKH1_1"].Rows[0]["q4"].ToString();
            textBox4.Text = objDataSet.Tables["PKH1_1"].Rows[0]["q5"].ToString();
            textBox5.Text = objDataSet.Tables["PKH1_1"].Rows[0]["q5"].ToString();

            database.Connection_Open();
            database.Fill("SELECT * FROM [PKH] WHERE (no1 = 2)", objDataSet, "PKH1_2", true);
            database.Connection_Close();

            if (objDataSet.Tables["PKH1_2"].Rows[0]["no2"].ToString() == "1")
                radioButton5.Checked = true;
            else if (objDataSet.Tables["PKH1_2"].Rows[0]["no2"].ToString() == "2")
                radioButton6.Checked = true;
            else if (objDataSet.Tables["PKH1_2"].Rows[0]["no2"].ToString() == "3")
                radioButton7.Checked = true;
            else if (objDataSet.Tables["PKH1_2"].Rows[0]["no2"].ToString() == "4")
                radioButton8.Checked = true;

            textBox6.Text = objDataSet.Tables["PKH1_2"].Rows[0]["q1"].ToString();
            maskedTextBox2.Text = objDataSet.Tables["PKH1_2"].Rows[0]["q2"].ToString();
            textBox7.Text = objDataSet.Tables["PKH1_2"].Rows[0]["q3"].ToString();
            textBox8.Text = objDataSet.Tables["PKH1_2"].Rows[0]["q4"].ToString();
            textBox9.Text = objDataSet.Tables["PKH1_2"].Rows[0]["q5"].ToString();
            textBox10.Text = objDataSet.Tables["PKH1_2"].Rows[0]["q5"].ToString();

        }

        private void butt_ok_Click(object sender, EventArgs e)
        {
            DB_Base database1 = new DB_Base();
            database1.Connection_Open();

            database1.objCommand.CommandText = "UPDATE PKH SET no2=@no2, q1=@q1, q2=@q2, q3=@q3, q4=@q4, q5=@q5, q6=@q6 WHERE (no1=1)";
            database1.objCommand.Connection = database1.objConnection;

            if (radioButton1.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "1");
            }
            else if (radioButton2.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "2");
            }
            else if (radioButton3.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "3");
            }
            else if (radioButton4.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "4");
            }

            database1.objCommand.Parameters.AddWithValue("@q1", textBox1.Text);
            database1.objCommand.Parameters.AddWithValue("@q2", maskedTextBox1.Text);
            database1.objCommand.Parameters.AddWithValue("@q3", textBox2.Text);
            database1.objCommand.Parameters.AddWithValue("@q4", textBox3.Text);
            database1.objCommand.Parameters.AddWithValue("@q5", textBox4.Text);
            database1.objCommand.Parameters.AddWithValue("@q6", textBox5.Text);

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
            DB_Base database1 = new DB_Base();
            database1.Connection_Open();

            database1.objCommand.CommandText = "UPDATE PKH SET no2=@no2, q1=@q1, q2=@q2, q3=@q3, q4=@q4, q5=@q5, q6=@q6 WHERE (no1=2)";
            database1.objCommand.Connection = database1.objConnection;

            if (radioButton5.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "1");
            }
            else if (radioButton6.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "2");
            }
            else if (radioButton7.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "3");
            }
            else if (radioButton8.Checked == true)
            {
                database1.objCommand.Parameters.AddWithValue("@no2", "4");
            }

            database1.objCommand.Parameters.AddWithValue("@q1", textBox6.Text);
            database1.objCommand.Parameters.AddWithValue("@q2", maskedTextBox2.Text);
            database1.objCommand.Parameters.AddWithValue("@q3", textBox7.Text);
            database1.objCommand.Parameters.AddWithValue("@q4", textBox8.Text);
            database1.objCommand.Parameters.AddWithValue("@q5", textBox9.Text);
            database1.objCommand.Parameters.AddWithValue("@q6", textBox10.Text);

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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox2.Text == "") { textBox2.Text = "1"; }
                db_Combo1.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 8) AND (SCode=" + textBox2.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox3.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (textBox7.Text == "") { textBox7.Text = "1"; }
                db_Combo2.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 8) AND (SCode=" + textBox2.Text + ") ORDER BY SDesc", "SDesc", "SCode");
                textBox8.Focus();
            }
        }

        private void db_Combo1_Enter(object sender, EventArgs e)
        {
            db_Combo1.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 8) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void db_Combo2_Enter(object sender, EventArgs e)
        {
            db_Combo2.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 8) ORDER BY SDesc", "SDesc", "SCode");
        }

        private void db_Combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo1.SelectedIndex >= 0)
                if (db_Combo1.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox2.Text = db_Combo1.SelectedValue.ToString();
        }

        private void db_Combo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (db_Combo2.SelectedIndex >= 0)
                if (db_Combo2.SelectedValue.ToString() != "System.Data.DataRowView")
                    textBox7.Text = db_Combo2.SelectedValue.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox1.Focus(); }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox2.Focus(); }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox4.Focus(); }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox5.Focus(); }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { butt_ok.Focus(); }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox2.Focus(); }
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox7.Focus(); }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox10.Focus(); }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox9.Focus(); }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { button1.Focus(); }
        }
    }
}
