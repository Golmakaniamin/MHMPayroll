using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Diagnostics;

namespace Pey4
{
    public partial class Form17 : Form
    {
        DataSet objDataSet = new DataSet();
        DB_Base DataBase = new DB_Base();
        DB_Base DataBase1 = new DB_Base();

        U_Base U_set = new U_Base();

        public string id_year;
        public string id_moon;
        public string id_group;

        public Form17()
        {
            InitializeComponent();
        }

        private void Form_sec()
        {
            if (U_set.u_user_sec(1) == 0) { اطلاعاتشرکتToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(19) == 0) { اطلاعاتکاربرانToolStripMenuItem1.Visible = false; }
            if (U_set.u_user_sec(2) == 0) { احکامقانونیToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(3) == 0) { مراکزهزینهToolStripMenuItem1.Visible = false; }
            if (U_set.u_user_sec(4) == 0) { کسوراتومزایاToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(5) == 0) { کدینگحسابداریToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(6) == 0) { شرکتهایطرفقراردادToolStripMenuItem.Visible = false; }

            if (U_set.u_user_sec(7) == 0) { روشهایمحاسبهToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(8) == 0) { اطلاعاتپرسنلToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(10) == 0) { پردازشToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(11) == 0) { گزارشاتToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(12) == 0) 
            {
                قانونیToolStripMenuItem1.Visible = false;
                داخللیستToolStripMenuItem1.Visible = false;
                بیمهToolStripMenuItem.Visible = false;
                مالیاتToolStripMenuItem.Visible = false;
                خلاصهبیمهToolStripMenuItem.Visible = false;
                خلاصهمالیاتToolStripMenuItem.Visible = false;
                داخللیستToolStripMenuItem2.Visible = false;
                قانونیToolStripMenuItem.Visible = false; 
            }

            if (U_set.u_user_sec(13) == 0) { پرداختکنندهحقوقToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(14) == 0) { بیندورهToolStripMenuItem.Visible = false; }
            if (U_set.u_user_sec(15) == 0) { ورودکارکردازاکسلToolStripMenuItem1.Visible = false; }

            if (U_set.u_user_sec(20) == 0)
            {
                توافقیToolStripMenuItem1.Visible = false;
                کاملToolStripMenuItem1.Visible = false;
                کاملToolStripMenuItem2.Visible = false;
                توافقیToolStripMenuItem.Visible = false;
            }
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            Form_sec();

            string file_name = Application.StartupPath.ToString();
            file_name += @"\Pey4_BG.Dll";

            string[] installs = new string[1];
            installs = System.IO.File.ReadAllLines(file_name, Encoding.ASCII);

            if (File.Exists(installs[0]) == true)
            {
                if (installs[0] != "")
                {
                    if (Directory.Exists(installs[0]) == false)
                    {
                        pictureBox1.Image = Image.FromFile(installs[0]);
                    }
                }
            }

            DataBase.Connection_Open();
            DataBase.Fill("SELECT * FROM Tab_Shrkat ORDER BY tmpid ASC", objDataSet, "Tab_Shrkat", true);
            DataBase.Connection_Close();

            comboBox3.Items.Clear();
            comboBox3.DataSource = objDataSet.Tables["Tab_Shrkat"];
            comboBox3.DisplayMember = "Groupname";
            comboBox3.ValueMember = "tmpid";

            if (objDataSet.Tables["Tab_Shrkat"].Rows.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
                call_comboBox3_SelectedIndexChanged();

                PersianCalendar persian = new PersianCalendar();
                if (comboBox2.Items.Count > 0)
                {
                    int y = persian.GetYear(DateTime.Now);

                    for (int q = 0; q <= comboBox2.Items.Count - 1; q++)
                    {
                        comboBox2.SelectedIndex = q;
                        if (comboBox2.Text == y.ToString())
                            break;
                    }
                }

                int m = persian.GetMonth(DateTime.Now);
                comboBox1.SelectedIndex = m - 1;
            }
            else
            {
                اطلاعاتپرسنلToolStripMenuItem.Visible = false;
                ورودکارکردازاکسلToolStripMenuItem1.Visible = false;
                پرداختکنندهحقوقToolStripMenuItem.Visible = false;
                روشهایمحاسبهToolStripMenuItem.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lab_date.Text = DataBase.u_date();
            lab_time.Text = DataBase.u_time();
        }

        private void Form17_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private bool set_info_work()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا ماه را انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return(false);
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا سال را انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
                return (false);
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا شرکت را انتخاب نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus();
                return (false);
            }

            id_group = comboBox3.SelectedValue.ToString();
            id_year = comboBox2.Text;
            id_moon = Convert.ToString(comboBox1.SelectedIndex + 1);
            return (true);
        }

        private void call_comboBox3_SelectedIndexChanged()
        {
            if (comboBox3.Items.Count > 0)
            {
                if (comboBox3.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    DataBase1.Connection_Open();
                    DataBase1.Fill("SELECT DISTINCT moh_sal FROM tbl_month WHERE (idgroup=" + comboBox3.SelectedValue.ToString() + ") ORDER BY moh_sal ASC ", objDataSet, "tbl_month", true);
                    DataBase1.Connection_Close();

                    comboBox2.Items.Clear();
                    if (objDataSet.Tables["tbl_month"].Rows.Count > 0)
                    {
                        for (int q = 0; q <= objDataSet.Tables["tbl_month"].Rows.Count - 1; q++)
                        {
                            comboBox2.Items.Add(objDataSet.Tables["tbl_month"].Rows[q]["moh_sal"].ToString());
                        }
                    }
                    else
                    {
                        روشهایمحاسبهToolStripMenuItem.Visible = false;
                        اطلاعاتپرسنلToolStripMenuItem.Visible = false;
                        پرداختکنندهحقوقToolStripMenuItem.Visible = false;
                        ورودکارکردازاکسلToolStripMenuItem1.Visible = false;
                    }
                    objDataSet.Tables["tbl_month"].Clear();
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            call_comboBox3_SelectedIndexChanged();
        }

        private void اطلاعاتشرکتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void اطلاعاتکاربرانToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void احکامقانونیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form23 f23 = new Form23();
            f23.id_group = comboBox3.SelectedValue.ToString();
            f23.Show();
        }

        private void مراکزهزینهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void کسوراتومزایاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Show();
        }

        private void دربارهیماToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox about = new AboutBox();
            //about.Show();
        }

        private void Form17_Activated(object sender, EventArgs e)
        {
            //DataBase.Connection_Open();
            //DataBase.Fill("SELECT * FROM Tab_Shrkat ORDER BY tmpid ASC", objDataSet, "Tab_Shrkat", true);
            //DataBase.Connection_Close();
            //comboBox3.Items.Clear();
            //comboBox3.DataSource = objDataSet.Tables["Tab_Shrkat"];
            //comboBox3.DisplayMember = "Groupname";
            //comboBox3.ValueMember = "tmpid";

            //if (objDataSet.Tables["Tab_Shrkat"].Rows.Count > 0)
            //{
            //    comboBox1.SelectedIndex = 0;

            //    comboBox3.SelectedIndex = 0;
            //    call_comboBox3_SelectedIndexChanged();

            //    if (comboBox2.Items.Count > 0)
            //    {
            //        comboBox2.SelectedIndex = 0;
            //    }
            //}
            //else
            //{
            //    ToolStripMenuItemPersonel.Visible = false;
            //    ToolStripMenuItemReplace.Visible = false;
            //    ToolStripMenuItemPey.Visible = false;
            //    ToolStripMenuItemCalc.Visible = false;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void کاملToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_List_1_Hoghogh";
                f1.selectprint_noe = "T";
                f1.style = "1";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " لیست حقوق توافقی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void مالیاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //لیست مالیات
            if (set_info_work() == true)
            {
                Pey4_CrystalReports.Form4 f = new Pey4_CrystalReports.Form4();
                f.Text = " گزارش لیست مالیات - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f.report_MaliatReport1.RecordSelectionFormula = "({Print_maliat;1.idgroup}=" + id_group + ") AND ({Print_maliat;1.idyear}=" + id_year + ") AND ({Print_maliat;1.idmoon}=" + id_moon + ") AND ({Print_maliat;1.type1}=2)";
                f.Show();
            }
        }

        private void بیمهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //لیست بیمه
            if (set_info_work() == true)
            {
                Pey4_CrystalReports.Form3 f = new Pey4_CrystalReports.Form3();
                f.Text = " گزارش لیست بیمه - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f.report_BimehReport1.RecordSelectionFormula = "({Print_bimeh;1.idgroup}=" + id_group + ") AND ({Print_bimeh;1.idyear}=" + id_year + ") AND ({Print_bimeh;1.idmoon}=" + id_moon + ") AND ({Print_bimeh;1.type1}=2)";
                f.Show();
            }
        }

        private void بیمهToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.id_group = comboBox3.SelectedValue.ToString();
            f18.id_year = comboBox2.Text;
            f18.id_moon = Convert.ToString(comboBox1.SelectedIndex + 1);
            f18.Text = " فایل بیمه - شرکت : " + comboBox3.Text + " - سال : " + f18.id_year + " - ماه : " + comboBox1.Text;
            f18.Show();
        }

        private void بانکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.id_group = comboBox3.SelectedValue.ToString();
            f19.id_year = comboBox2.Text;
            f19.id_moon = Convert.ToString(comboBox1.SelectedIndex + 1);
            f19.Text = " فایل بانک - شرکت : " + comboBox3.Text + " - سال : " + f19.id_year + " - ماه : " + comboBox1.Text;
            f19.Show();
        }

        private void مالیاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.id_group = comboBox3.SelectedValue.ToString();
            f9.id_year = comboBox2.Text;
            f9.id_moon = Convert.ToString(comboBox1.SelectedIndex + 1);
            f9.Text = " فایل مالیات - شرکت : " + comboBox3.Text + " - سال : " + f9.id_year + " - ماه : " + comboBox1.Text;
            f9.Show();
        }

        private void داخللیستToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_List_1_Hoghogh";
                f1.selectprint_noe = "G";
                f1.style = "1";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " لیست حقوق قانونی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void کدینگحسابداریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void کاملToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pey4_CrystalReports.Form5 f = new Pey4_CrystalReports.Form5();

            id_group = comboBox3.SelectedValue.ToString();
            id_year = comboBox2.Text;
            id_moon = Convert.ToString(comboBox1.SelectedIndex + 1);
            f.Text = " سند حسابداری توافقی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;

            ParameterFields paramFields = new ParameterFields(); 
            paramFields.Clear();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
            paramField1.Name = "@idgroup"; 
            paramDiscreteValue1.Value = id_group; 
            paramField1.CurrentValues.Add(paramDiscreteValue1);   
            paramFields.Add(paramField1);

            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
            paramField2.Name = "@idyear"; 
            paramDiscreteValue2.Value = id_year; 
            paramField2.CurrentValues.Add(paramDiscreteValue2);   
            paramFields.Add(paramField2);

            ParameterField paramField3 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
            paramField3.Name = "@idmoon";
            paramDiscreteValue3.Value = id_moon;
            paramField3.CurrentValues.Add(paramDiscreteValue3);
            paramFields.Add(paramField3);

            ParameterField paramField4 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
            paramField4.Name = "@idgroup";
            paramField4.ReportName = "Amin";
            paramDiscreteValue4.Value = id_group;
            paramField4.CurrentValues.Add(paramDiscreteValue4);
            paramFields.Add(paramField4);

            ParameterField paramField5 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
            paramField5.Name = "@idyear";
            paramField5.ReportName = "Amin";
            paramDiscreteValue5.Value = id_year;
            paramField5.CurrentValues.Add(paramDiscreteValue5);
            paramFields.Add(paramField5);

            ParameterField paramField6 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue6 = new ParameterDiscreteValue();
            paramField6.Name = "@idmoon";
            paramField6.ReportName = "Amin";
            paramDiscreteValue6.Value = id_moon;
            paramField6.CurrentValues.Add(paramDiscreteValue6);
            paramFields.Add(paramField6);

            ParameterField paramField7 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue7 = new ParameterDiscreteValue();
            paramField7.Name = "@idgroup";
            paramField7.ReportName = "Amin2";
            paramDiscreteValue7.Value = id_group;
            paramField7.CurrentValues.Add(paramDiscreteValue7);
            paramFields.Add(paramField7);

            ParameterField paramField8 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue8 = new ParameterDiscreteValue();
            paramField8.Name = "@idyear";
            paramField8.ReportName = "Amin2";
            paramDiscreteValue8.Value = id_year;
            paramField8.CurrentValues.Add(paramDiscreteValue8);
            paramFields.Add(paramField8);

            ParameterField paramField9 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue9 = new ParameterDiscreteValue();
            paramField9.Name = "@idmoon";
            paramField9.ReportName = "Amin2";
            paramDiscreteValue9.Value = id_moon;
            paramField9.CurrentValues.Add(paramDiscreteValue9);
            paramFields.Add(paramField9);

            f.paramFields = paramFields; 
            f.Show();
        }

        private void داخللیستToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Pey4_CrystalReports.Form6 f = new Pey4_CrystalReports.Form6();

            id_group = comboBox3.SelectedValue.ToString();
            id_year = comboBox2.Text;
            id_moon = Convert.ToString(comboBox1.SelectedIndex + 1);
            f.Text = " سند حسابداری قانونی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;

            ParameterFields paramFields = new ParameterFields();
            paramFields.Clear();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
            paramField1.Name = "@idgroup";
            paramDiscreteValue1.Value = id_group;
            paramField1.CurrentValues.Add(paramDiscreteValue1);
            paramFields.Add(paramField1);

            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
            paramField2.Name = "@idyear";
            paramDiscreteValue2.Value = id_year;
            paramField2.CurrentValues.Add(paramDiscreteValue2);
            paramFields.Add(paramField2);

            ParameterField paramField3 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
            paramField3.Name = "@idmoon";
            paramDiscreteValue3.Value = id_moon;
            paramField3.CurrentValues.Add(paramDiscreteValue3);
            paramFields.Add(paramField3);

            ParameterField paramField4 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
            paramField4.Name = "@idgroup";
            paramField4.ReportName = "Amin";
            paramDiscreteValue4.Value = id_group;
            paramField4.CurrentValues.Add(paramDiscreteValue4);
            paramFields.Add(paramField4);

            ParameterField paramField5 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
            paramField5.Name = "@idyear";
            paramField5.ReportName = "Amin";
            paramDiscreteValue5.Value = id_year;
            paramField5.CurrentValues.Add(paramDiscreteValue5);
            paramFields.Add(paramField5);

            ParameterField paramField6 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue6 = new ParameterDiscreteValue();
            paramField6.Name = "@idmoon";
            paramField6.ReportName = "Amin";
            paramDiscreteValue6.Value = id_moon;
            paramField6.CurrentValues.Add(paramDiscreteValue6);
            paramFields.Add(paramField6);

            ParameterField paramField7 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue7 = new ParameterDiscreteValue();
            paramField7.Name = "@idgroup";
            paramField7.ReportName = "Amin2";
            paramDiscreteValue7.Value = id_group;
            paramField7.CurrentValues.Add(paramDiscreteValue7);
            paramFields.Add(paramField7);

            ParameterField paramField8 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue8 = new ParameterDiscreteValue();
            paramField8.Name = "@idyear";
            paramField8.ReportName = "Amin2";
            paramDiscreteValue8.Value = id_year;
            paramField8.CurrentValues.Add(paramDiscreteValue8);
            paramFields.Add(paramField8);

            ParameterField paramField9 = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue9 = new ParameterDiscreteValue();
            paramField9.Name = "@idmoon";
            paramField9.ReportName = "Amin2";
            paramDiscreteValue9.Value = id_moon;
            paramField9.CurrentValues.Add(paramDiscreteValue9);
            paramFields.Add(paramField9);

            f.paramFields = paramFields;
            f.Show();
        }

        private void شرکتهایطرفقراردادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form27 f27 = new Form27();
            f27.Show();
        }

        private void جملاتادبیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            f20.Show();
        }

        private void تنظیماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form29 f29 = new Form29();
            f29.Show();
        }

        private void خلاصهبیمهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Pey4_CrystalReports.Form8 f = new Pey4_CrystalReports.Form8();
                f.Text = " خلاصه بیمه - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f.record_sel = "({Print_bimeh1;1.idgroup} = " + id_group + ") AND ({Print_bimeh1;1.idyear} = " + id_year + ") AND ({Print_bimeh1;1.idmoon} = " + id_moon + ")";
                f.Show();
            }
        }

        private void خلاصهمالیاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Pey4_CrystalReports.Form7 f = new Pey4_CrystalReports.Form7();

                f.Text = " خلاصه مالیات - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;

                ParameterFields paramFields = new ParameterFields();
                paramFields.Clear();

                ParameterField paramField1 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                paramField1.Name = "@idgroup";
                paramDiscreteValue1.Value = id_group;
                paramField1.CurrentValues.Add(paramDiscreteValue1);
                paramFields.Add(paramField1);

                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue2 = new ParameterDiscreteValue();
                paramField2.Name = "@idyear";
                paramDiscreteValue2.Value = id_year;
                paramField2.CurrentValues.Add(paramDiscreteValue2);
                paramFields.Add(paramField2);

                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue3 = new ParameterDiscreteValue();
                paramField3.Name = "@idmoon";
                paramDiscreteValue3.Value = id_moon;
                paramField3.CurrentValues.Add(paramDiscreteValue3);
                paramFields.Add(paramField3);

                DataBase.Connection_Open();
                DataBase.Fill("SELECT * FROM Tbl_maliat WHERE (tmpid=1)", objDataSet, "Tbl_maliat", true);
                DataBase.Connection_Close();

                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue4 = new ParameterDiscreteValue();
                paramField4.Name = "@maliat_ta1";
                paramDiscreteValue4.Value = objDataSet.Tables["Tbl_maliat"].Rows[0]["maliat_ta"].ToString();
                paramField4.CurrentValues.Add(paramDiscreteValue4);
                paramFields.Add(paramField4);

                string file_name_date = @"DD.dll";
                string[] installs_date = new string[1];
                installs_date = System.IO.File.ReadAllLines(file_name_date, Encoding.Unicode);
                
                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue5 = new ParameterDiscreteValue();
                paramField5.Name = "@date2";
                paramDiscreteValue5.Value = installs_date[0];
                paramField5.CurrentValues.Add(paramDiscreteValue5);
                paramFields.Add(paramField5);

                f.paramFields = paramFields;
                f.Show();
            }
        }

        private void ماشینحسالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start_info = new ProcessStartInfo(@"C:\WINDOWS\system32\calc.exe");
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = start_info;

            proc.Start();

            // Wait until Notepad exits.
            //proc.WaitForExit();
            //MessageBox.Show("Exit Code: " + proc.ExitCode, "Exit Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void دربارهماToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form30 f30 = new Form30();
            f30.Show();
        }

        private void توافقیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Groupby_List";
                f1.selectprint_noe = "T";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " گزارش دوره ای حقوق توافقی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void قانونیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Groupby_List";
                f1.selectprint_noe = "G";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " گزارش دوره ای حقوق قانونی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void توافقیToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Fish_2_Hoghogh";
                f1.selectprint_noe = "T";
                f1.style = "1";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " فیش حقوقی توافقی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void قانونیToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Fish_2_Hoghogh";
                f1.selectprint_noe = "G";
                f1.style = "1";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " فیش حقوقی قانونی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void قراردادکارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Garardad";
                f1.selectprint_noe = "G";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " قرارداد وزارت کار  - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void طرحجدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void پردازشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Form21 f1 = new Form21();
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " محاسبه حقوق و دستمزد - شرکت : " + comboBox3.Text + " - سال : " + f1.id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void یادداشتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f31 = new Form31();
            f31.Show();
        }

        private void دربارهنرمافزارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aa = new AboutBox1();
            aa.Show();
        }

        private void اطلاعاتپرسنلToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Form5 f1 = new Form5();
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " اطلاعات پرسنل - شرکت : " + comboBox3.Text + " - سال : " + f1.id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void پرداختکنندهحقوقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form26 f1 = new Form26();
            f1.Show();
        }

        private void روشهایمحاسبهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void بیندورهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form24 f24 = new Form24();
            f24.Show();
        }

        private void ورودکارکردازاکسلToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Form28 f28 = new Form28();
                f28.id_group = id_group;
                f28.id_year = id_year;
                f28.id_moon = id_moon;
                f28.Text = " شرکت : " + comboBox3.Text + " - سال : " + f28.id_year + " - ماه : " + comboBox1.Text;
                f28.Show();
            }
        }

        private void توافقیToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Groupby_Moon";
                f1.selectprint_noe = "T";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " گزارش ماهانه توافقی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void قانونیToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Groupby_Moon";
                f1.selectprint_noe = "G";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " گزارش ماهانه قانونی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void توافقیToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Groupby_Moon_Chart";
                f1.selectprint_noe = "T";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " نمودار ماهانه توافقی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }

        private void قانونیToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (set_info_work() == true)
            {
                Print_Priview f1 = new Print_Priview();
                f1.selectprint = "Report_Groupby_Moon_Chart";
                f1.selectprint_noe = "G";
                f1.style = "2";
                f1.id_group = id_group;
                f1.id_year = id_year;
                f1.id_moon = id_moon;
                f1.Text = " نمودار ماهانه قانونی - شرکت : " + comboBox3.Text + " - سال : " + id_year + " - ماه : " + comboBox1.Text;
                f1.Show();
            }
        }
    }
}
