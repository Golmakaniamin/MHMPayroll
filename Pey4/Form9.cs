using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Pey4
{
    public partial class Form9 : Form
    {
        DataSet objDataSet = new DataSet();
        DB_Base database = new DB_Base();

        public string id_year;
        public string id_moon;
        public string id_group;

        public Form9()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string file_name;
            
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text Format (*.txt) |*.txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Title = "ذخیره فایل";

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 2", objDataSet, "Tbl_process", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tab_Shrkat WHERE (tmpid="+id_group+")", objDataSet, "Tab_Shrkat", true);
            database.Connection_Close();

            string[] installs = new string[(objDataSet.Tables["Tbl_process"].Rows.Count + 1)];

            installs[0] = objDataSet.Tables["Tab_Shrkat"].Rows[0]["sh_parvande"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_shobe"].ToString(); 
            installs[0] += "," + id_year;
            installs[0] += "," + id_moon;
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["noeasliepardakhtkonande"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["noefareiepardakhtkonande"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_name"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_family"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_codemelli"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["idposti"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["phone"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["address"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_name"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_family"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_codemelli"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_semat"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_shobe"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_shobe"].ToString();
            installs[0] += ",";
            installs[0] += ",";
            installs[0] += ",";
            installs[0] += "";

            for (int q = 1; q <= objDataSet.Tables["Tbl_process"].Rows.Count; q++)
            {
                installs[q] = objDataSet.Tables["Tbl_process"].Rows[q - 1]["cod_mely"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["name"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["family"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["name_pedar"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["noe_garardad"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["code_posti"].ToString();

                database.Connection_Open();
                database.Fill("SELECT * FROM Maliat_coding WHERE (MCode = 2) AND (SCode = " + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_onvanShoghl"].ToString() + ")", objDataSet, "maliat_onvanShoghl", true);
                database.Connection_Close();
                installs[q] += "," + objDataSet.Tables["maliat_onvanShoghl"].Rows[q - 1]["SDesc"].ToString();
                objDataSet.Tables["maliat_onvanShoghl"].Clear();

                //installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["family"].ToString();

                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_madrak"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_rasteshoghli"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["code_moafiat_maliat"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_meliat"].ToString();

                database.Connection_Open();
                database.Fill("SELECT * FROM Maliat_coding WHERE (MCode = 12) AND (SCode = " + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_namekeshvar"].ToString() + ")", objDataSet, "maliat_namekeshvar", true);
                database.Connection_Close();
                installs[q] += "," + objDataSet.Tables["maliat_namekeshvar"].Rows[q - 1]["SDesc"].ToString();
                objDataSet.Tables["maliat_namekeshvar"].Clear();

                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["noe_bimeh"].ToString();
                installs[q] += ",";
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["sh_bimeh"].ToString();

                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file_name = saveFileDialog.FileName;
                System.IO.File.WriteAllLines(file_name, installs ,Encoding.Unicode);
            }

            objDataSet.Tables["Tbl_process"].Clear();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            string file_name = Application.StartupPath.ToString() + @"\Maliat\" + id_year.ToString() + id_moon.ToString().PadLeft(2, '0');
            if (Directory.Exists(file_name) == false)
            {
                Directory.CreateDirectory(file_name);
            }

            string open_file_name = file_name;

            file_name += @"\" + "WH" + id_year.ToString() + id_moon.ToString().PadLeft(2, '0') + ".TXT";

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 2 AND tbl_personel.list1 = 1 WHERE (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tab_Shrkat WHERE (tmpid=" + id_group + ")", objDataSet, "Tab_Shrkat", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_maliat WHERE (tmpid=1)", objDataSet, "Tbl_maliat", true);
            database.Connection_Close();

            string[] installs = new string[(objDataSet.Tables["Tbl_process"].Rows.Count + 1)];

            installs[0] = objDataSet.Tables["Tab_Shrkat"].Rows[0]["sh_parvande"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_shobe"].ToString();
            installs[0] += "," + id_year;
            installs[0] += "," + id_moon.PadLeft(2, '0');
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["noeasliepardakhtkonande"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["noefareiepardakhtkonande"].ToString();
            installs[0] += ",";
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_name"].ToString() + " " + objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_family"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["name_shobe"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_egtesady"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["idposti"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["phone"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["address"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_codemelli"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_name"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_family"].ToString();
            installs[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_semat"].ToString();
            installs[0] += ",";
            installs[0] += ",";
            installs[0] += ",";
            installs[0] += ",";

            //installs[0] += ",";//آن کد آخریه

            for (int q = 1; q <= objDataSet.Tables["Tbl_process"].Rows.Count; q++)
            {
                installs[q] = objDataSet.Tables["Tbl_process"].Rows[q - 1]["cod_mely"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["name"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["family"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["name_pedar"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["noe_garardad"].ToString();

                if (objDataSet.Tables["Tbl_process"].Rows[q - 1]["code_posti"].ToString() == "-")
                    installs[q] += ",";
                else
                    installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["code_posti"].ToString();

                database.Connection_Open();
                database.Fill("SELECT * FROM Maliat_coding WHERE (MCode = 2) AND (SCode = " + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_onvanShoghl"].ToString() + ")", objDataSet, "maliat_onvanShoghl", true);
                database.Connection_Close();
                installs[q] += "," + objDataSet.Tables["maliat_onvanShoghl"].Rows[0]["SDesc"].ToString();
                objDataSet.Tables["maliat_onvanShoghl"].Clear();

                //سابقه
                database.Connection_Open();
                database.Fill("SELECT * FROM tbl_personel WHERE (tmpid = " + objDataSet.Tables["Tbl_process"].Rows[q - 1]["idpersonal"].ToString() + ")", objDataSet, "tbl_personel", true);
                database.Connection_Close();
                installs[q] += "," + Convert.ToString(Convert.ToInt16(database.u_date().ToString().Substring(0, 4)) - Convert.ToInt16(objDataSet.Tables["tbl_personel"].Rows[0]["data_estekhdam"].ToString().Substring(0, 4)));
                objDataSet.Tables["tbl_personel"].Clear();

                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_madrak"].ToString();
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_rasteshoghli"].ToString();

                database.Connection_Open();
                database.Fill("SELECT * FROM Tbl_moafiat_maliat WHERE (tmpid = " + objDataSet.Tables["Tbl_process"].Rows[q - 1]["code_moafiat_maliat"].ToString()+ ")", objDataSet, "Tbl_moafiat_maliat", true);
                database.Connection_Close();
                installs[q] += "," + objDataSet.Tables["Tbl_moafiat_maliat"].Rows[0]["kod_moafiat"].ToString();
                objDataSet.Tables["Tbl_moafiat_maliat"].Clear();

                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_meliat"].ToString();

                if (objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_meliat"].ToString() != "1")
                {
                    database.Connection_Open();
                    database.Fill("SELECT * FROM Maliat_coding WHERE (MCode = 12) AND (SCode = " + objDataSet.Tables["Tbl_process"].Rows[q - 1]["maliat_namekeshvar"].ToString() + ")", objDataSet, "maliat_namekeshvar", true);
                    database.Connection_Close();
                    installs[q] += "," + objDataSet.Tables["maliat_namekeshvar"].Rows[0]["SDesc"].ToString();
                    objDataSet.Tables["maliat_namekeshvar"].Clear();
                }
                else
                    installs[q] += ",";

                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["noe_bimeh"].ToString();
                installs[q] += ",";//نام بیمه
                installs[q] += "," + objDataSet.Tables["Tbl_process"].Rows[q - 1]["sh_bimeh"].ToString().PadLeft(10, '0');
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["w4"].ToString()), 0).ToString();
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["SUM_mazaya_maliat"].ToString()), 0).ToString();
                installs[q] += ",0";
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["SUM_hogogh_mazaya"].ToString()),0).ToString();
                installs[q] += ",0";
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["SUM_hogogh_mazaya"].ToString()), 0).ToString();
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += ",0";
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["Eydi"].ToString()), 0).ToString();
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["sanavat"].ToString()), 0).ToString();
                installs[q] += "," + (Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[q - 1]["SUM_hogogh_mazaya"]) + Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[q - 1]["Eydi"]) + Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[q - 1]["sanavat"])).ToString();
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["bime2"].ToString()), 0).ToString();

                if (Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[q - 1]["SUM_MASHMOL_MALIAT"]) >= Convert.ToInt64(objDataSet.Tables["Tbl_maliat"].Rows[0]["maliat_ta"]))
                {
                    installs[q] += "," + (Convert.ToInt64(objDataSet.Tables["Tbl_process"].Rows[q - 1]["SUM_MASHMOL_MALIAT"]) - Convert.ToInt64(objDataSet.Tables["Tbl_maliat"].Rows[0]["maliat_ta"])).ToString();
                }
                else
                {
                    installs[q] += ",0";
                }

                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["view_maliat"].ToString()), 0).ToString();
                installs[q] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[q - 1]["view_maliat"].ToString()), 0).ToString();
            }

            System.IO.File.WriteAllLines(file_name, installs, Encoding.Unicode);

            objDataSet.Clear();

            file_name = "";

            file_name = Application.StartupPath.ToString() + @"\Maliat\" + id_year.ToString() + id_moon.ToString().PadLeft(2, '0');
            file_name += @"\" + "WK" + id_year.ToString() + id_moon.ToString().PadLeft(2, '0') + ".TXT";

            database.Connection_Open();
            database.Fill("SELECT ISNULL(SUM(w4)+SUM(w5)+SUM(w6)+SUM(SUM_mazaya_maliat),0) AS S_w4, Count(Tbl_process.idgroup) AS rsnumber, ISNULL(Sum(view_maliat),0) AS S_view_maliat FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 2 AND tbl_personel.list1 = 1 WHERE (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT Sum(SUM_MASHMOL_MALIAT - 4833333) AS sumnumber FROM Tbl_process INNER JOIN tbl_personel ON Tbl_process.idgroup = tbl_personel.idgroup AND Tbl_process.idyear = tbl_personel.idyear AND Tbl_process.idmoon = tbl_personel.idmoon AND Tbl_process.idpersonal = tbl_personel.tmpid AND Tbl_process.type1 = 2 AND tbl_personel.list1 = 1 WHERE ((SUM_MASHMOL_MALIAT - 4833333) > 0) AND (Tbl_process.type1 = 2) AND (Tbl_process.idgroup=" + id_group + ") AND (Tbl_process.idyear=" + id_year + ") AND (Tbl_process.idmoon=" + id_moon + ")", objDataSet, "Tbl_process1", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tab_Shrkat WHERE (tmpid=" + id_group + ")", objDataSet, "Tab_Shrkat", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_maliat WHERE (tmpid=1)", objDataSet, "Tbl_maliat", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM PKH WHERE (no1=2) AND (no2=4)", objDataSet, "PKH", true);
            database.Connection_Close();

            string[] installs1 = new string[(1)];

            installs1[0] = objDataSet.Tables["Tab_Shrkat"].Rows[0]["sh_parvande"].ToString();
            installs1[0] += "," + id_year;
            installs1[0] += "," + id_moon.PadLeft(2, '0');
            installs1[0] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[0]["S_w4"].ToString()), 0).ToString();
            installs1[0] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process1"].Rows[0]["sumnumber"].ToString()), 0).ToString();
            installs1[0] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[0]["S_view_maliat"].ToString()), 0).ToString();
            installs1[0] += ",0";
            installs1[0] += ",0";
            installs1[0] += ",0";
            installs1[0] += ",0"; //حقوق پرداختنی
            installs1[0] += ",0"; //حقوق مزایا ماه گذشته
            installs1[0] += ",0"; //مالیات
            installs1[0] += ",0";
            installs1[0] += ",0";
            installs1[0] += ",0";//بدهی مالیاتی تا ماه گذشته

            string file_name_date = @"DD.dll";
            string[] installs_date = new string[1];
            installs_date = System.IO.File.ReadAllLines(file_name_date, Encoding.Unicode);
            installs1[0] += "," + installs_date[0].Replace("/","");

            installs1[0] += "," + objDataSet.Tables["Tbl_process"].Rows[0]["rsnumber"].ToString();
            installs1[0] += ",";
            installs1[0] += "," + objDataSet.Tables["Tab_Shrkat"].Rows[0]["nahve_maliyat"].ToString();
            if (objDataSet.Tables["PKH"].Rows.Count > 0)
            {
                installs1[0] += "," + objDataSet.Tables["PKH"].Rows[0]["q1"].ToString();
                installs1[0] += "," + objDataSet.Tables["PKH"].Rows[0]["q2"].ToString();
                installs1[0] += "," + objDataSet.Tables["PKH"].Rows[0]["q3"].ToString();
                installs1[0] += "," + objDataSet.Tables["PKH"].Rows[0]["q4"].ToString();
                installs1[0] += "," + objDataSet.Tables["PKH"].Rows[0]["q5"].ToString();
            }
            else
            {
                installs1[0] += ",";
                installs1[0] += ",";
                installs1[0] += ",";
                installs1[0] += ",";
                installs1[0] += ",";
            }

            installs1[0] += "," + Math.Round(Convert.ToDecimal(objDataSet.Tables["Tbl_process"].Rows[0]["S_view_maliat"].ToString()), 0).ToString();

            System.IO.File.WriteAllLines(file_name, installs1, Encoding.Unicode);
            objDataSet.Clear();

            MessageBox.Show("فایل ها در پوشه مخصوص خود ساخته شده است", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
