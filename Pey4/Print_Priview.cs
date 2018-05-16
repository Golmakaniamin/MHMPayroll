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
    public partial class Print_Priview : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        DB_Base Database = new DB_Base();

        public string selectprint;
        public string selectprint_noe;

        public string id_year;
        public string id_moon;
        public string id_group;

        public string style;

        private void noe_style(string style1)
        {
            if (style1 == "1")
            {
                checkBox3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = false;
            }
        }

        public Print_Priview()
        {
            InitializeComponent();
        }

        private void Form31_Load(object sender, EventArgs e)
        {
            noe_style(style);

            Database.Connection_Open();
            Database.Fill("SELECT tmpid, name_makaz FROM Tbl_markaz", objDataSet, "Tbl_markaz", true);
            Database.Connection_Close();

            comboBox1.DataSource  = objDataSet.Tables["Tbl_markaz"];
            comboBox1.DisplayMember = "name_makaz";
            comboBox1.ValueMember = "tmpid";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("لطفا از کد پرسنلی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("لطفا تا کد پرسنلی را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    return;
                }
            }

            if (checkBox3.Checked == true)
            {
                if (maskedTextBox1.ToString().IndexOf("_").ToString() != "-1")
                {
                    MessageBox.Show("لطفا از تاریخ را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                    return;
                }
                if (maskedTextBox2.ToString().IndexOf("_").ToString() != "-1")
                {
                    MessageBox.Show("لطفا تا تاریخ را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox2.Focus();
                    return;
                }
            }

            if (checkBox2.Checked == true)
            {
                if ((comboBox1.SelectedIndex == -1))
                {
                    MessageBox.Show("لطفا مرکز هزینه را انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox1.Focus();
                    return;
                }
            }

            button1.Enabled = false;

            //2
            //دوره ای
            if (selectprint == "Report_Groupby_List")
            {
                string amin1 = "";

                if (selectprint_noe == "T")
                   amin1 = "({Print_Process;1.idgroup}=" + id_group + ") AND ({Print_Process;1.type1}=1) AND ({Print_Process;1.list2}=true)";
                else if (selectprint_noe == "G")
                   amin1 = "({Print_Process;1.idgroup}=" + id_group + ") AND ({Print_Process;1.type1}=2) AND ({Print_Process;1.list1}=true)";

                if (checkBox1.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.code} >= '" + textBox1.Text + "') AND ({Print_Process;1.code} <= '" + textBox2.Text + "')";
                }

                if (checkBox2.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.tmpid(1)}=" + comboBox1.SelectedValue + ")";
                }

                if (checkBox3.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.idyear} >= " + maskedTextBox1.Text.ToString().Substring(0, 4) + ") AND ({Print_Process;1.idyear} <= " + maskedTextBox2.Text.ToString().Substring(0, 4) + ")";
                    amin1 += " AND ({Print_Process;1.idmoon} >= " + maskedTextBox1.Text.ToString().Substring(5, 2) + ") AND ({Print_Process;1.idmoon} <= " + maskedTextBox2.Text.ToString().Substring(5, 2) + ")";
                }
                
                Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
                f.selkar = "Report_Groupby_List";
                f.recore_sel = amin1;
                f.sarbarg = selectprint_noe;
                f.Show();
            }

            //3
            //فیش جدید
            if (selectprint == "Report_Fish_2_Hoghogh")
            {
                string amin1 = "";

                if (selectprint_noe == "T")
                    amin1 = "({Print_salary;1.idgroup}=" + id_group + ")AND ({Print_salary;1.idyear}=" + id_year + ") AND ({Print_salary;1.idmoon}=" + id_moon + ") AND ({Print_salary;1.type1}=1) AND ({Print_salary;1.list2}=true)";
                else if (selectprint_noe == "G")
                    amin1 = "({Print_salary;1.idgroup}=" + id_group + ")AND ({Print_salary;1.idyear}=" + id_year + ") AND ({Print_salary;1.idmoon}=" + id_moon + ") AND ({Print_salary;1.type1}=2) AND ({Print_salary;1.list1}=true)";

                if (checkBox1.Checked == true)
                {
                    amin1 += " AND ({Print_salary;1.code} >= '" + textBox1.Text + "') AND ({Print_salary;1.code} <= '" + textBox2.Text + "')";
                }

                if (checkBox2.Checked == true)
                {
                    amin1 += " AND ({Print_salary;1.tmpid(1)}=" + comboBox1.SelectedValue + ")";
                }

                if (checkBox3.Checked == true)
                {
                    amin1 += " AND ({Print_salary;1.idyear} >= " + maskedTextBox1.Text.ToString().Substring(0, 4) + ") AND ({Print_salary;1.idyear} <= " + maskedTextBox2.Text.ToString().Substring(0, 4) + ")";
                    amin1 += " AND ({Print_salary;1.idmoon} >= " + maskedTextBox1.Text.ToString().Substring(5, 2) + ") AND ({Print_salary;1.idmoon} <= " + maskedTextBox2.Text.ToString().Substring(5, 2) + ")";
                }

                Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
                f.selkar = "Report_Fish_2_Hoghogh";
                f.recore_sel = amin1;
                f.sarbarg = selectprint_noe;
                f.Show();
            }

            //4
            //قرارداد کار
            if (selectprint == "Report_Garardad")
            {
                string amin1 = "({Print_Process;1.idgroup}=" + id_group + ")AND ({Print_Process;1.idyear}=" + id_year + ") AND ({Print_Process;1.idmoon}=" + id_moon + ") AND ({Print_list;1.type1}=2) AND ({Print_list;1.list1}=true)";

                if (checkBox1.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.code} >= '" + textBox1.Text + "') AND ({Print_Process;1.code} <= '" + textBox2.Text + "')";
                }

                if (checkBox2.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.tmpid}=" + comboBox1.SelectedValue + ")";
                }

                Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
                f.selkar = "Report_Garardad";
                f.recore_sel = amin1;
                f.Show();
            }

            //5
            //لیست حقوق
            if (selectprint == "Report_List_1_Hoghogh")
            {
                string amin1 = "";

                if (selectprint_noe == "T")
                    amin1 = "({Print_list;1.idgroup}=" + id_group + ")AND ({Print_list;1.idyear}=" + id_year + ") AND ({Print_list;1.idmoon}=" + id_moon + ") AND ({Print_list;1.type1}=1) AND ({Print_list;1.list2}=true)";
                else if (selectprint_noe == "G")
                    amin1 = "({Print_list;1.idgroup}=" + id_group + ")AND ({Print_list;1.idyear}=" + id_year + ") AND ({Print_list;1.idmoon}=" + id_moon + ") AND ({Print_list;1.type1}=2) AND ({Print_list;1.list1}=true)";

                if (checkBox1.Checked == true)
                {
                    amin1 += " AND ({Print_list;1.code} >= '" + textBox1.Text + "') AND ({Print_list;1.code} <= '" + textBox2.Text + "')";
                }

                if (checkBox2.Checked == true)
                {
                    amin1 += " AND ({Print_list;1.tmpid(1)}=" + comboBox1.SelectedValue + ")";
                }

                Pey4_CrystalReports.Form2 f = new Pey4_CrystalReports.Form2();
                f.report_List_Hoghogh1.RecordSelectionFormula = amin1;
                f.sarbarg = selectprint_noe;
                f.Show();
            }

            //6
            //دوره ای
            if (selectprint == "Report_Groupby_Moon")
            {
                string amin1 = "";

                if (selectprint_noe == "T")
                    amin1 = "({Print_Process;1.idgroup}=" + id_group + ") AND ({Print_Process;1.type1}=1) AND ({Print_Process;1.list2}=true)";
                else if (selectprint_noe == "G")
                    amin1 = "({Print_Process;1.idgroup}=" + id_group + ") AND ({Print_Process;1.type1}=2) AND ({Print_Process;1.list1}=true)";

                if (checkBox1.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.code} >= '" + textBox1.Text + "') AND ({Print_Process;1.code} <= '" + textBox2.Text + "')";
                }

                if (checkBox2.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.tmpid(1)}=" + comboBox1.SelectedValue + ")";
                }

                if (checkBox3.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.idyear} >= " + maskedTextBox1.Text.ToString().Substring(0, 4) + ") AND ({Print_Process;1.idyear} <= " + maskedTextBox2.Text.ToString().Substring(0, 4) + ")";
                    amin1 += " AND ({Print_Process;1.idmoon} >= " + maskedTextBox1.Text.ToString().Substring(5, 2) + ") AND ({Print_Process;1.idmoon} <= " + maskedTextBox2.Text.ToString().Substring(5, 2) + ")";
                }

                Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
                f.selkar = "Report_Groupby_Moon";
                f.recore_sel = amin1;
                f.sarbarg = selectprint_noe;
                f.Show();
            }

            //7
            //نمودار
            if (selectprint == "Report_Groupby_Moon_Chart")
            {
                string amin1 = "";

                if (selectprint_noe == "T")
                    amin1 = "({Print_Process;1.idgroup}=" + id_group + ") AND ({Print_Process;1.type1}=1) AND ({Print_Process;1.list2}=true)";
                else if (selectprint_noe == "G")
                    amin1 = "({Print_Process;1.idgroup}=" + id_group + ") AND ({Print_Process;1.type1}=2) AND ({Print_Process;1.list1}=true)";

                if (checkBox1.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.code} >= '" + textBox1.Text + "') AND ({Print_Process;1.code} <= '" + textBox2.Text + "')";
                }

                if (checkBox2.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.tmpid(1)}=" + comboBox1.SelectedValue + ")";
                }

                if (checkBox3.Checked == true)
                {
                    amin1 += " AND ({Print_Process;1.idyear} >= " + maskedTextBox1.Text.ToString().Substring(0, 4) + ") AND ({Print_Process;1.idyear} <= " + maskedTextBox2.Text.ToString().Substring(0, 4) + ")";
                    amin1 += " AND ({Print_Process;1.idmoon} >= " + maskedTextBox1.Text.ToString().Substring(5, 2) + ") AND ({Print_Process;1.idmoon} <= " + maskedTextBox2.Text.ToString().Substring(5, 2) + ")";
                }

                Pey4_CrystalReports.AllPrint f = new Pey4_CrystalReports.AllPrint();
                f.selkar = "Report_Groupby_Moon_Chart";
                f.recore_sel = amin1;
                f.sarbarg = selectprint_noe;
                f.Show();
            }

            button1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.Enabled == false)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (label2.Enabled == false)
            {
                label2.Enabled = true;
                textBox1.Enabled = true;
                label3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Focus();
            }
            else
            {
                label2.Enabled = false;
                textBox1.Enabled = false;
                label3.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { textBox2.Focus(); }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { button1.Focus(); }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (label5.Enabled == false)
            {
                label5.Enabled = true;
                maskedTextBox1.Enabled = true;
                label4.Enabled = true;
                maskedTextBox2.Enabled = true;
                maskedTextBox1.Focus();
            }
            else
            {
                label5.Enabled = false;
                maskedTextBox1.Enabled = false;
                label4.Enabled = false;
                maskedTextBox2.Enabled = false;
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { maskedTextBox2.Focus(); }
        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { button1.Focus(); }
        }
    }
}
