using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pey4_CrystalReports;
using System.IO;

namespace Pey4
{
    public partial class Form21 : Form
    {
        DB_Base database = new DB_Base();
        DB_Base database1 = new DB_Base();

        U_Base U_set = new U_Base();

        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        public string id_year;
        public string id_moon;
        public string id_group;
        DataSet objDataSet = new DataSet();
        DataSet objDataSet0 = new DataSet();

        public Form21()
        {
            InitializeComponent();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void Form21_Load(object sender, EventArgs e)
        {
            maskedTextBox5.Text = U_set.u_date();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_login WHERE (tmpid= 0)", objDataSet, "View_Process_2", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Tbl_login WHERE (tmpid= 0)", objDataSet, "View1_Process_2", true);
            database.Connection_Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox5.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا فیلد تاریخ ثبت روزنامه را تکمیل نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox5.Focus();
                return;
            }

            button2.Enabled = false;

            string file_name = @"DD.dll";
            string[] installs = new string[1];
            installs[0] = maskedTextBox5.Text;
            System.IO.File.WriteAllLines(file_name, installs, Encoding.Unicode);

            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = "DELETE FROM loan_view WHERE (idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ")";
            objCommand.CommandType = CommandType.Text;
            objConnection.Open();
            objCommand.ExecuteNonQuery();
            objConnection.Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM tbl_personel WHERE (idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") ORDER BY tmpid", objDataSet, "tbl_personel", true);
            database.Connection_Close();

            if (objDataSet.Tables["tbl_personel"].Rows.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = objDataSet.Tables["tbl_personel"].Rows.Count - 1;

                string amin = id_year + "/" + id_moon.ToString().PadLeft(2, '0');

                for (int q = 0; q <= objDataSet.Tables["tbl_personel"].Rows.Count - 1; q++)
                {
                    progressBar1.Value = q;

                    //وام
                    string vamt1 = "0";
                    string vamt2 = "0";
                    string vamt3 = "0";

                    database1.Connection_Open();
                    database1.Fill("SELECT a.tmpid, a.loan_price, a.loan_payment_date, a.receiver, b.tmpid AS Expr1, b.loan_code AS Expr2, b.payment_date, b.payment_price, b.payment_status AS Expr3 FROM tbl_loan AS a INNER JOIN tbl_loan_payment AS b ON a.tmpid = b.loan_code WHERE (LEFT(b.payment_date,7) = '" + amin + "') AND (a.receiver = " + objDataSet.Tables["tbl_personel"].Rows[q]["code"].ToString() + ")", objDataSet, "vam", true);
                    database1.Connection_Close();

                    if (objDataSet.Tables["vam"].Rows.Count > 0)
                    {
                        if (objDataSet.Tables["vam"].Rows.Count >= 1)
                        {
                            vamt1 = objDataSet.Tables["vam"].Rows[0]["payment_price"].ToString();

                            SqlCommand objCommand1 = new SqlCommand();
                            objCommand1.Connection = objConnection;
                            objCommand1.CommandText = "UPDATE tbl_loan_payment SET [payment_status]=1 WHERE tmpid=" + objDataSet.Tables["vam"].Rows[0]["Expr1"].ToString();
                            objCommand1.CommandType = CommandType.Text;
                            objConnection.Open();
                            objCommand1.ExecuteNonQuery();
                            objConnection.Close();
                        }

                        if (objDataSet.Tables["vam"].Rows.Count >= 2)
                        {
                            vamt2 = objDataSet.Tables["vam"].Rows[1]["payment_price"].ToString();

                            SqlCommand objCommand1 = new SqlCommand();
                            objCommand1.Connection = objConnection;
                            objCommand1.CommandText = "UPDATE tbl_loan_payment SET [payment_status]=1 WHERE tmpid=" + objDataSet.Tables["vam"].Rows[1]["Expr1"].ToString();
                            objCommand1.CommandType = CommandType.Text;
                            objConnection.Open();
                            objCommand1.ExecuteNonQuery();
                            objConnection.Close();
                        }

                        if (objDataSet.Tables["vam"].Rows.Count >= 3)
                        {
                            vamt3 = objDataSet.Tables["vam"].Rows[2]["payment_price"].ToString();

                            SqlCommand objCommand1 = new SqlCommand();
                            objCommand1.Connection = objConnection;
                            objCommand1.CommandText = "UPDATE tbl_loan_payment SET [payment_status]=1 WHERE tmpid=" + objDataSet.Tables["vam"].Rows[2]["Expr1"].ToString();
                            objCommand1.CommandType = CommandType.Text;
                            objConnection.Open();
                            objCommand1.ExecuteNonQuery();
                            objConnection.Close();
                        }
                    }

                    SqlCommand objCommand2 = new SqlCommand();
                    objCommand2.Connection = objConnection;
                    objCommand2.CommandText = "INSERT INTO loan_view (tmpid,idgroup,idyear,idmoon,vam1,vam2,vam3) VALUES (@tmpid,@idgroup,@idyear,@idmoon,@vam1,@vam2,@vam3)";
                    objCommand2.CommandType = CommandType.Text;
                    objCommand2.Parameters.AddWithValue("@tmpid", objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString());
                    objCommand2.Parameters.AddWithValue("@idgroup", id_group);
                    objCommand2.Parameters.AddWithValue("@idyear", id_year);
                    objCommand2.Parameters.AddWithValue("@idmoon", id_moon);
                    objCommand2.Parameters.AddWithValue("@vam1", vamt1);
                    objCommand2.Parameters.AddWithValue("@vam2", vamt2);
                    objCommand2.Parameters.AddWithValue("@vam3", vamt3);
                    objConnection.Open();
                    objCommand2.ExecuteNonQuery();
                    objConnection.Close();

                    //مالیات
                    database1.Connection_Open();
                    database1.Fill("SELECT * FROM View_calc_maliat WHERE (tmpid=" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + ")", objDataSet, "View1_Process_1_Maliat", true);
                    database1.Connection_Close();

                    database1.Connection_Open();
                    database1.Fill("SELECT * FROM Tbl_maliat ORDER BY maliat_az", objDataSet, "Maliat", true);
                    database1.Connection_Close();

                    int w;
                    Double maliat1 = 0;
                    Double maliat2 = 0;
                    Double maliat3 = 0;
                    
                    if (objDataSet.Tables["Maliat"].Rows.Count > 0)
                    {
                        for (w = objDataSet.Tables["Maliat"].Rows.Count - 1; w >= 0; w--)
                        {
                            //MessageBox.Show(Convert.ToInt64(objDataSet.Tables["View1_Process_1_Maliat"].Rows[0]["SUM_MASHMOL_MALIAT"]).ToString());
                            if ((Convert.ToInt64(objDataSet.Tables["View1_Process_1_Maliat"].Rows[0]["SUM_MASHMOL_MALIAT"]) >= Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[w]["maliat_az"])) && (Convert.ToInt64(objDataSet.Tables["View1_Process_1_Maliat"].Rows[0]["SUM_MASHMOL_MALIAT"]) <= Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[w]["maliat_ta"])))
                            {
                                //مالیات
                                maliat1 = Convert.ToDouble(objDataSet.Tables["View1_Process_1_Maliat"].Rows[0]["SUM_MASHMOL_MALIAT"]);

                                Double q1 = Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[w]["maliat_az"]);
                                Double q2 = maliat1;

                                maliat2 = q2 - q1;
                                maliat3 += (maliat2 * Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[w]["nerkh"])) / 100;

                                for (int f = (w-1); f >= 0; f--)
                                {
                                    q1 = Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[f]["maliat_az"]);
                                    q2 = Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[f]["maliat_ta"]);

                                    maliat2 = q2 - q1;
                                    maliat3 += (maliat2 * Convert.ToInt64(objDataSet.Tables["Maliat"].Rows[f]["nerkh"])) / 100;
                                }
                                break;
                            }
                        }
                    }

                    SqlCommand objCommand3 = new SqlCommand();
                    objCommand3.Connection = objConnection;
                    objCommand3.CommandText = "UPDATE loan_view SET view_maliat=@view_maliat WHERE tmpid = " + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString();
                    objCommand3.CommandType = CommandType.Text;
                    objCommand3.Parameters.AddWithValue("@view_maliat", Math.Round(maliat3));
                    objConnection.Open();
                    objCommand3.ExecuteNonQuery();
                    objConnection.Close();

                    objDataSet.Tables["vam"].Clear();
                    objDataSet.Tables["Maliat"].Clear();
                    objDataSet.Tables["View1_Process_1_Maliat"].Clear();
                }
            }

            //ثبت قانونی

            objDataSet.Tables.Remove("View1_Process_2");

            database.Connection_Open();
            database.Fill("SELECT * FROM View1_Process_2 WHERE ((idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (type1=2))", objDataSet, "View1_Process_2", true);
            database.Connection_Close();

            SqlCommand objCommand10 = new SqlCommand();
            objCommand10.Connection = objConnection;
            objCommand10.CommandText = "DELETE FROM Tbl_process WHERE (idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ")";
            objCommand10.CommandType = CommandType.Text;
            objConnection.Open();
            objCommand10.ExecuteNonQuery();
            objConnection.Close();

            if (objDataSet.Tables["View1_Process_2"].Rows.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = objDataSet.Tables["View1_Process_2"].Rows.Count - 1;

                for (int q = 0; q <= objDataSet.Tables["View1_Process_2"].Rows.Count - 1; q++)
                {
                    progressBar1.Value = q;

                    SqlCommand objCommand2 = new SqlCommand();
                    objCommand2.Connection = objConnection;
                    objCommand2.CommandText = "INSERT INTO Tbl_process (idgroup,idyear,idmoon,idpersonal,w1,w2,w3,w4,w5,w6,vam1,vam2,vam3,SUM_hogogh_mazaya,SUM_MASHMOL_BIMEH,Haghe_bime_personal,moafiat_Haghe_bime_personal,Haghe_bime_bikari,moafiat_Haghe_bime_bikari,Haghe_bime_karfarma,moafiat_Haghe_bime_karfarma,SUM_MASHMOL_MALIAT,moafiat_MASHMOL_MALIAT,view_maliat,ALL_kosorat,Khales,type1,wt1,wt2,wt3,wt4,wt5,wt6,SUM_mazaya,bime2,SUM_mazaya_maliat) VALUES (@idgroup,@idyear,@idmoon,@idpersonal,@w1,@w2,@w3,@w4,@w5,@w6,@vam1,@vam2,@vam3,@SUM_hogogh_mazaya,@SUM_MASHMOL_BIMEH,@Haghe_bime_personal,@moafiat_Haghe_bime_personal,@Haghe_bime_bikari,@moafiat_Haghe_bime_bikari,@Haghe_bime_karfarma,@moafiat_Haghe_bime_karfarma,@SUM_MASHMOL_MALIAT,@moafiat_MASHMOL_MALIAT,@view_maliat,@ALL_kosorat,@Khales,@type1,@wt1,@wt2,@wt3,@wt4,@wt5,@wt6,@SUM_mazaya,@bime2,@SUM_mazaya_maliat)";
                    objCommand2.CommandType = CommandType.Text;
                    objCommand2.Parameters.AddWithValue("@idgroup", objDataSet.Tables["View1_Process_2"].Rows[q]["idgroup"].ToString());
                    objCommand2.Parameters.AddWithValue("@idyear", objDataSet.Tables["View1_Process_2"].Rows[q]["idyear"].ToString());
                    objCommand2.Parameters.AddWithValue("@idmoon", objDataSet.Tables["View1_Process_2"].Rows[q]["idmoon"].ToString());
                    objCommand2.Parameters.AddWithValue("@idpersonal", objDataSet.Tables["View1_Process_2"].Rows[q]["tmpid"].ToString());

                    objCommand2.Parameters.AddWithValue("@w1", objDataSet.Tables["View1_Process_2"].Rows[q]["w1"].ToString());
                    objCommand2.Parameters.AddWithValue("@w2", objDataSet.Tables["View1_Process_2"].Rows[q]["w2"].ToString());
                    objCommand2.Parameters.AddWithValue("@w3", objDataSet.Tables["View1_Process_2"].Rows[q]["w3"].ToString());
                    objCommand2.Parameters.AddWithValue("@w4", objDataSet.Tables["View1_Process_2"].Rows[q]["w4"].ToString());
                    objCommand2.Parameters.AddWithValue("@w5", objDataSet.Tables["View1_Process_2"].Rows[q]["w5"].ToString());
                    objCommand2.Parameters.AddWithValue("@w6", objDataSet.Tables["View1_Process_2"].Rows[q]["w6"].ToString());

                    objCommand2.Parameters.AddWithValue("@vam1", objDataSet.Tables["View1_Process_2"].Rows[q]["vam1"].ToString());
                    objCommand2.Parameters.AddWithValue("@vam2", objDataSet.Tables["View1_Process_2"].Rows[q]["vam2"].ToString());
                    objCommand2.Parameters.AddWithValue("@vam3", objDataSet.Tables["View1_Process_2"].Rows[q]["vam3"].ToString());

                    objCommand2.Parameters.AddWithValue("@SUM_hogogh_mazaya", objDataSet.Tables["View1_Process_2"].Rows[q]["SUM_hogogh_mazaya"].ToString());
                    objCommand2.Parameters.AddWithValue("@SUM_MASHMOL_BIMEH", objDataSet.Tables["View1_Process_2"].Rows[q]["SUM_MASHMOL_BIMEH"].ToString());
                    objCommand2.Parameters.AddWithValue("@Haghe_bime_personal", objDataSet.Tables["View1_Process_2"].Rows[q]["Haghe_bime_personal"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_Haghe_bime_personal", objDataSet.Tables["View1_Process_2"].Rows[q]["moafiat_Haghe_bime_personal"].ToString());
                    objCommand2.Parameters.AddWithValue("@Haghe_bime_bikari", objDataSet.Tables["View1_Process_2"].Rows[q]["Haghe_bime_bikari"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_Haghe_bime_bikari", objDataSet.Tables["View1_Process_2"].Rows[q]["moafiat_Haghe_bime_bikari"].ToString());
                    objCommand2.Parameters.AddWithValue("@Haghe_bime_karfarma", objDataSet.Tables["View1_Process_2"].Rows[q]["Haghe_bime_karfarma"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_Haghe_bime_karfarma", objDataSet.Tables["View1_Process_2"].Rows[q]["moafiat_Haghe_bime_karfarma"].ToString());
                    objCommand2.Parameters.AddWithValue("@SUM_MASHMOL_MALIAT", objDataSet.Tables["View1_Process_2"].Rows[q]["SUM_MASHMOL_MALIAT"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_MASHMOL_MALIAT", objDataSet.Tables["View1_Process_2"].Rows[q]["moafiat_MASHMOL_MALIAT"].ToString());
                    objCommand2.Parameters.AddWithValue("@view_maliat", objDataSet.Tables["View1_Process_2"].Rows[q]["view_maliat"].ToString());
                    objCommand2.Parameters.AddWithValue("@ALL_kosorat", objDataSet.Tables["View1_Process_2"].Rows[q]["ALL_kosorat"].ToString());
                    objCommand2.Parameters.AddWithValue("@Khales", objDataSet.Tables["View1_Process_2"].Rows[q]["Khales"].ToString());
                    objCommand2.Parameters.AddWithValue("@type1", objDataSet.Tables["View1_Process_2"].Rows[q]["type1"].ToString());

                    objCommand2.Parameters.AddWithValue("@wt1", "کل روزهای کارکرد");
                    objCommand2.Parameters.AddWithValue("@wt2", "روزهای کارکرد");
                    objCommand2.Parameters.AddWithValue("@wt3", "حقوق روزانه");
                    objCommand2.Parameters.AddWithValue("@wt4", "حقوق ماهانه");
                    objCommand2.Parameters.AddWithValue("@wt5", "اضافه کار عادی");
                    objCommand2.Parameters.AddWithValue("@wt6", "اضافه کار تعطیلی");

                    objCommand2.Parameters.AddWithValue("@SUM_mazaya", objDataSet.Tables["View1_Process_2"].Rows[q]["SUM_mazaya"].ToString());
                    objCommand2.Parameters.AddWithValue("@bime2", objDataSet.Tables["View1_Process_2"].Rows[q]["bime2"].ToString());
                    objCommand2.Parameters.AddWithValue("@SUM_mazaya_maliat", objDataSet.Tables["View1_Process_2"].Rows[q]["SUM_mazaya_maliat"].ToString());
                    objConnection.Open();
                    objCommand2.ExecuteNonQuery();
                    objConnection.Close();
                }
            }

            //توافقی
            objDataSet.Tables.Remove("View_Process_2");

            database.Connection_Open();
            database.Fill("SELECT * FROM View_Process_2 WHERE ((idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (type1=1))", objDataSet, "View_Process_2", true);
            database.Connection_Close();

            //ثبت
            if (objDataSet.Tables["View_Process_2"].Rows.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = objDataSet.Tables["View_Process_2"].Rows.Count - 1;

                for (int q = 0; q <= objDataSet.Tables["View_Process_2"].Rows.Count - 1; q++)
                {
                    progressBar1.Value = q;

                    SqlCommand objCommand2 = new SqlCommand();
                    objCommand2.Connection = objConnection;
                    objCommand2.CommandText = "INSERT INTO Tbl_process (idgroup,idyear,idmoon,idpersonal,w1,w2,w3,w4,w5,w6,vam1,vam2,vam3,SUM_hogogh_mazaya,SUM_MASHMOL_BIMEH,Haghe_bime_personal,moafiat_Haghe_bime_personal,Haghe_bime_bikari,moafiat_Haghe_bime_bikari,Haghe_bime_karfarma,moafiat_Haghe_bime_karfarma,SUM_MASHMOL_MALIAT,moafiat_MASHMOL_MALIAT,view_maliat,ALL_kosorat,Khales,type1,wt1,wt2,wt3,wt4,wt5,wt6,SUM_mazaya,bime2,SUM_mazaya_maliat) VALUES (@idgroup,@idyear,@idmoon,@idpersonal,@w1,@w2,@w3,@w4,@w5,@w6,@vam1,@vam2,@vam3,@SUM_hogogh_mazaya,@SUM_MASHMOL_BIMEH,@Haghe_bime_personal,@moafiat_Haghe_bime_personal,@Haghe_bime_bikari,@moafiat_Haghe_bime_bikari,@Haghe_bime_karfarma,@moafiat_Haghe_bime_karfarma,@SUM_MASHMOL_MALIAT,@moafiat_MASHMOL_MALIAT,@view_maliat,@ALL_kosorat,@Khales,@type1,@wt1,@wt2,@wt3,@wt4,@wt5,@wt6,@SUM_mazaya,@bime2,@SUM_mazaya_maliat)";
                    objCommand2.CommandType = CommandType.Text;
                    objCommand2.Parameters.AddWithValue("@idgroup", objDataSet.Tables["View_Process_2"].Rows[q]["idgroup"].ToString());
                    objCommand2.Parameters.AddWithValue("@idyear", objDataSet.Tables["View_Process_2"].Rows[q]["idyear"].ToString());
                    objCommand2.Parameters.AddWithValue("@idmoon", objDataSet.Tables["View_Process_2"].Rows[q]["idmoon"].ToString());
                    objCommand2.Parameters.AddWithValue("@idpersonal", objDataSet.Tables["View_Process_2"].Rows[q]["tmpid"].ToString());

                    objCommand2.Parameters.AddWithValue("@w1", objDataSet.Tables["View_Process_2"].Rows[q]["w1"].ToString());
                    objCommand2.Parameters.AddWithValue("@w2", objDataSet.Tables["View_Process_2"].Rows[q]["w2"].ToString());
                    objCommand2.Parameters.AddWithValue("@w3", objDataSet.Tables["View_Process_2"].Rows[q]["w3"].ToString());
                    objCommand2.Parameters.AddWithValue("@w4", objDataSet.Tables["View_Process_2"].Rows[q]["w4"].ToString());
                    objCommand2.Parameters.AddWithValue("@w5", objDataSet.Tables["View_Process_2"].Rows[q]["w5"].ToString());
                    objCommand2.Parameters.AddWithValue("@w6", objDataSet.Tables["View_Process_2"].Rows[q]["w6"].ToString());

                    objCommand2.Parameters.AddWithValue("@vam1", objDataSet.Tables["View_Process_2"].Rows[q]["vam1"].ToString());
                    objCommand2.Parameters.AddWithValue("@vam2", objDataSet.Tables["View_Process_2"].Rows[q]["vam2"].ToString());
                    objCommand2.Parameters.AddWithValue("@vam3", objDataSet.Tables["View_Process_2"].Rows[q]["vam3"].ToString());

                    objCommand2.Parameters.AddWithValue("@SUM_hogogh_mazaya", objDataSet.Tables["View_Process_2"].Rows[q]["SUM_hogogh_mazaya"].ToString());
                    objCommand2.Parameters.AddWithValue("@SUM_MASHMOL_BIMEH", objDataSet.Tables["View_Process_2"].Rows[q]["SUM_MASHMOL_BIMEH"].ToString());
                    objCommand2.Parameters.AddWithValue("@Haghe_bime_personal", objDataSet.Tables["View_Process_2"].Rows[q]["Haghe_bime_personal"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_Haghe_bime_personal", objDataSet.Tables["View_Process_2"].Rows[q]["moafiat_Haghe_bime_personal"].ToString());
                    objCommand2.Parameters.AddWithValue("@Haghe_bime_bikari", objDataSet.Tables["View_Process_2"].Rows[q]["Haghe_bime_bikari"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_Haghe_bime_bikari", objDataSet.Tables["View_Process_2"].Rows[q]["moafiat_Haghe_bime_bikari"].ToString());
                    objCommand2.Parameters.AddWithValue("@Haghe_bime_karfarma", objDataSet.Tables["View_Process_2"].Rows[q]["Haghe_bime_karfarma"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_Haghe_bime_karfarma", objDataSet.Tables["View_Process_2"].Rows[q]["moafiat_Haghe_bime_karfarma"].ToString());
                    objCommand2.Parameters.AddWithValue("@SUM_MASHMOL_MALIAT", objDataSet.Tables["View_Process_2"].Rows[q]["SUM_MASHMOL_MALIAT"].ToString());
                    objCommand2.Parameters.AddWithValue("@moafiat_MASHMOL_MALIAT", objDataSet.Tables["View_Process_2"].Rows[q]["moafiat_MASHMOL_MALIAT"].ToString());
                    objCommand2.Parameters.AddWithValue("@view_maliat", objDataSet.Tables["View_Process_2"].Rows[q]["view_maliat"].ToString());
                    objCommand2.Parameters.AddWithValue("@ALL_kosorat", objDataSet.Tables["View_Process_2"].Rows[q]["ALL_kosorat"].ToString());
                    objCommand2.Parameters.AddWithValue("@Khales", objDataSet.Tables["View_Process_2"].Rows[q]["Khales"].ToString());
                    objCommand2.Parameters.AddWithValue("@type1", objDataSet.Tables["View_Process_2"].Rows[q]["type1"].ToString());

                    objCommand2.Parameters.AddWithValue("@wt1", "کل روزهای کارکرد");
                    objCommand2.Parameters.AddWithValue("@wt2", "روزهای کارکرد");
                    objCommand2.Parameters.AddWithValue("@wt3", "حقوق روزانه");
                    objCommand2.Parameters.AddWithValue("@wt4", "حقوق ماهانه");
                    objCommand2.Parameters.AddWithValue("@wt5", "اضافه کار عادی");
                    objCommand2.Parameters.AddWithValue("@wt6", "اضافه کار تعطیلی");

                    objCommand2.Parameters.AddWithValue("@SUM_mazaya", objDataSet.Tables["View_Process_2"].Rows[q]["SUM_mazaya"].ToString());
                    objCommand2.Parameters.AddWithValue("@bime2", objDataSet.Tables["View_Process_2"].Rows[q]["bime2"].ToString());
                    objCommand2.Parameters.AddWithValue("@SUM_mazaya_maliat", objDataSet.Tables["View_Process_2"].Rows[q]["SUM_mazaya_maliat"].ToString());

                    objConnection.Open();
                    objCommand2.ExecuteNonQuery();
                    objConnection.Close();

                }
            }
            MessageBox.Show("ثبت انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button2.Enabled = true;
            this.Hide();
        }
    }
}



//dataGridView1.AutoGenerateColumns = true;
//dataGridView1.DataSource = objDataSet;
//dataGridView1.DataMember = "View1_Process_2";

//DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
//objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
//objAlignRightCellStyle.Format = "N0";
//dataGridView1.DefaultCellStyle = objAlignRightCellStyle;

//DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
//objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
//dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

//dataGridView1.Columns[0].Visible = false;
//dataGridView1.Columns[1].Visible = false;
//dataGridView1.Columns[2].Visible = false;
//dataGridView1.Columns[3].Visible = false;
//dataGridView1.Columns[4].HeaderText = "کد پرسنل";
//dataGridView1.Columns[5].HeaderText = "نام";
//dataGridView1.Columns[6].HeaderText = "نام خانوادگی";
//dataGridView1.Columns[7].HeaderText = "نام پدر";
//dataGridView1.Columns[8].HeaderText = "کد ملی";
//dataGridView1.Columns[9].HeaderText = "کل روزهای کارکرد";
//dataGridView1.Columns[10].HeaderText = "روزهای کارکرد";
//dataGridView1.Columns[11].HeaderText = "حقوق روزانه";
//dataGridView1.Columns[12].HeaderText = "حقوق ماهانه";
//dataGridView1.Columns[13].HeaderText = "اضافه کار عادی";
//dataGridView1.Columns[14].HeaderText = "اضافه کار تعطیلی";

//for (int q = 15; q <= 44; q++)
//{
//    dataGridView1.Columns[q].HeaderText = dataGridView1.Rows[0].Cells[q + 30].FormattedValue.ToString();
//    if (dataGridView1.Columns[q].HeaderText == "")
//    {
//        dataGridView1.Columns[q].Visible = false;
//    }
//    dataGridView1.Columns[q + 30].Visible = false;
//}

//dataGridView1.Columns[75].HeaderText = "وام اول";
//dataGridView1.Columns[76].HeaderText = "وام دوم";
//dataGridView1.Columns[77].HeaderText = "وام سوم";
//dataGridView1.Columns[78].HeaderText = "جمع مزایا";
//dataGridView1.Columns[79].HeaderText = "جمع حقوق و مزایا";
//dataGridView1.Columns[80].HeaderText = "حقوق مشمول بیمه";
//dataGridView1.Columns[81].HeaderText = "معافیت بیمه سهم پرسنل";
//dataGridView1.Columns[82].HeaderText = "بیمه سهم پرسنل";
//dataGridView1.Columns[83].HeaderText = "معافیت بیمه سهم بیکاری";
//dataGridView1.Columns[84].HeaderText = "بیمه سهم بیکاری";
//dataGridView1.Columns[85].HeaderText = "معافیت بیمه سهم کارفرما";
//dataGridView1.Columns[86].HeaderText = "بیمه سهم کارفرما";
//dataGridView1.Columns[87].HeaderText = "حقوق مشمول مالیات";
//dataGridView1.Columns[88].HeaderText = "معافیت مالیات";
//dataGridView1.Columns[89].HeaderText = "مالیات";
//dataGridView1.Columns[90].HeaderText = "جمع کسورات";
//dataGridView1.Columns[91].HeaderText = "خالص دریافتی";
//dataGridView1.Columns[92].Visible = false;
//dataGridView1.Columns[93].Visible = false;
//dataGridView1.Columns[94].Visible = false;

////dataGridView1.Columns[93].HeaderText = "سنوات";
////dataGridView1.Columns[94].HeaderText = "حق مرخصی";
////dataGridView1.Columns[95].HeaderText = "عیدی";

//objAlternatingCellStyle = null;
//objAlignRightCellStyle = null;




//dataGridView1.AutoGenerateColumns = true;
//dataGridView1.DataSource = objDataSet;
//dataGridView1.DataMember = "View_Process_2";

//DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
//objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
//objAlignRightCellStyle.Format = "N0";
//dataGridView1.DefaultCellStyle = objAlignRightCellStyle;

//DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
//objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
//dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

//dataGridView1.Columns[0].Visible = false;
//dataGridView1.Columns[1].Visible = false;
//dataGridView1.Columns[2].Visible = false;
//dataGridView1.Columns[3].Visible = false;
//dataGridView1.Columns[4].HeaderText = "کد پرسنل";
//dataGridView1.Columns[5].HeaderText = "نام";
//dataGridView1.Columns[6].HeaderText = "نام خانوادگی";
//dataGridView1.Columns[7].HeaderText = "نام پدر";
//dataGridView1.Columns[8].HeaderText = "کد ملی";
//dataGridView1.Columns[9].HeaderText = "کل روزهای کارکرد";
//dataGridView1.Columns[10].HeaderText = "روزهای کارکرد";
//dataGridView1.Columns[11].HeaderText = "حقوق روزانه";
//dataGridView1.Columns[12].HeaderText = "حقوق ماهانه";
//dataGridView1.Columns[13].HeaderText = "اضافه کار عادی";
//dataGridView1.Columns[14].HeaderText = "اضافه کار تعطیلی";

//for (int q = 15; q <= 44; q++)
//{
//    dataGridView1.Columns[q].HeaderText = dataGridView1.Rows[0].Cells[q + 30].FormattedValue.ToString();
//    if (dataGridView1.Columns[q].HeaderText == "")
//    {
//        dataGridView1.Columns[q].Visible = false;
//    }
//    dataGridView1.Columns[q + 30].Visible = false;
//}

//dataGridView1.Columns[75].HeaderText = "وام اول";
//dataGridView1.Columns[76].HeaderText = "وام دوم";
//dataGridView1.Columns[77].HeaderText = "وام سوم";
//dataGridView1.Columns[78].HeaderText = "جمع مزایا";
//dataGridView1.Columns[79].HeaderText = "جمع حقوق و مزایا";
//dataGridView1.Columns[80].HeaderText = "حقوق مشمول بیمه";
//dataGridView1.Columns[81].HeaderText = "معافیت بیمه سهم پرسنل";
//dataGridView1.Columns[82].HeaderText = "بیمه سهم پرسنل";
//dataGridView1.Columns[83].HeaderText = "معافیت بیمه سهم بیکاری";
//dataGridView1.Columns[84].HeaderText = "بیمه سهم بیکاری";
//dataGridView1.Columns[85].HeaderText = "معافیت بیمه سهم کارفرما";
//dataGridView1.Columns[86].HeaderText = "بیمه سهم کارفرما";
//dataGridView1.Columns[87].HeaderText = "حقوق مشمول مالیات";
//dataGridView1.Columns[88].HeaderText = "معافیت مالیات";
//dataGridView1.Columns[89].HeaderText = "مالیات";
//dataGridView1.Columns[90].HeaderText = "جمع کسورات";
//dataGridView1.Columns[91].HeaderText = "خالص دریافتی";
//dataGridView1.Columns[92].Visible = false;
//dataGridView1.Columns[93].Visible = false;
//dataGridView1.Columns[94].Visible = false;

////dataGridView1.Columns[93].HeaderText = "سنوات";
////dataGridView1.Columns[94].HeaderText = "حق مرخصی";
////dataGridView1.Columns[95].HeaderText = "عیدی";

//objAlternatingCellStyle = null;
//objAlignRightCellStyle = null;
