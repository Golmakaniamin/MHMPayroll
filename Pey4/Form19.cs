using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Pey4
{
    public partial class Form19 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        DataSet objDataSet = new DataSet();
        DB_Base Database = new DB_Base();

        public string id_year;
        public string id_moon;
        public string id_group;

        string open_file_name;

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("بانک ملت - شعبه سه راه باقر خان");
        }

        private void combo_bank_1_sabzkosh()
        {
            string file_name = Application.StartupPath.ToString() + @"\Bank\" + id_year.ToString() + id_moon.ToString().PadLeft(2, '0');
            if (Directory.Exists(file_name) == false)
            {
                Directory.CreateDirectory(file_name);
            }

            open_file_name = file_name;

            file_name += @"\" + "FL" + id_year.ToString() + id_moon.ToString().PadLeft(2, '0') + ".TXT";

            Database.Connection_Open();
            Database.Fill("SELECT Count(tbl_personel.tmpid) AS rsnumber ,SUM(Khales) AS rssum FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 1 AND tbl_personel.list2 = 1 WHERE (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process1", true);
            Database.Connection_Close();

            Database.Connection_Open();
            Database.Fill("SELECT sh_hesab ,Khales FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 1 AND tbl_personel.list2 = 1 WHERE (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process2", true);
            Database.Connection_Close();

            string[] installs = new string[(objDataSet.Tables["Tbl_process2"].Rows.Count + 1)];

            installs[0] = objDataSet.Tables["Tbl_process1"].Rows[0]["rsnumber"].ToString().PadLeft(10, '0');
            installs[0] += "0000000";
            installs[0] += Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process1"].Rows[0]["rssum"].ToString())).ToString();

            for (int q = 1; q <= objDataSet.Tables["Tbl_process2"].Rows.Count; q++)
            {
                installs[q] = objDataSet.Tables["Tbl_process2"].Rows[q - 1]["sh_hesab"].ToString();
                installs[q] += "0000000";
                installs[q] += Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process2"].Rows[q - 1]["Khales"].ToString())).ToString();
            }

            System.IO.File.WriteAllLines(file_name, installs, Encoding.ASCII);
            objDataSet.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (comboBox1.SelectedIndex == 0)
            {
                combo_bank_1_sabzkosh();
                MessageBox.Show("فایل ها در پوشه مخصوص خود ساخته شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ProcessStartInfo start_info = new ProcessStartInfo("explorer.exe", open_file_name);
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = start_info;

            proc.Start();

            button1.Enabled = true;
        }
    }
}
