using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pey4
{
    public partial class Form1 : Form
    {
        DataSet objDataSet = new DataSet();

        DB_Base DataBase = new DB_Base();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int amin2 = DataBase.Look_base();
            if (amin2 != 0)
            {
                MessageBox.Show("عدم شناسایی قفل " + amin2.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            DataBase.Connection_Open();
            DataBase.Fill("SELECT tmpid ,(log_Name + ' ' + log_Family) as myname FROM Tbl_login", objDataSet, "Tbl_login", true);
            DataBase.Connection_Close();

            comboBox1.DataSource = objDataSet.Tables["Tbl_login"];
            comboBox1.DisplayMember = "myname";
            comboBox1.ValueMember = "tmpid";
        }

        private void but_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void but_login_Click(object sender, EventArgs e)
        {
            DataBase.Connection_Open();
            DataBase.Fill("SELECT * FROM Tbl_login WHERE (tmpid='" + comboBox1.SelectedValue.ToString() + "')", objDataSet, "Tbl_login_sel", true);
            DataBase.Connection_Close();

            if ((tex_pass.Text == objDataSet.Tables["Tbl_login_sel"].Rows[0]["log_Password"].ToString()) && (tex_pass.Text != ""))
            {
                string file_name = @"C:\AUTOEXEC.dll";
                string[] installs = new string[1];
                installs[0] = comboBox1.SelectedValue.ToString();
                System.IO.File.WriteAllLines(file_name, installs, Encoding.Unicode);

                Form17 f = new Form17();
                f.lab_name.Text = comboBox1.Text;
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("رمز عبور صحیح نمی باشد");
                tex_pass.Text = "";
                tex_pass.Focus();
            }
            objDataSet.Tables["Tbl_login_sel"].Clear();
        }

        private void tex_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { but_login.Focus(); }
        }
    }
}