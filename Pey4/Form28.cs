using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Pey4
{
    public partial class Form28 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();
        DB_Base database = new DB_Base();

        OleDbConnection connection = new OleDbConnection();
        DataSet objDataSet1 = new DataSet();

        public string id_year;
        public string id_moon;
        public string id_group;

        string ImageName;

        public Form28()
        {
            InitializeComponent();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            database.Connection_Open();
            database.Fill("SELECT * FROM Excel_read_karkard", objDataSet, "Excel_read_karkard", true);
            database.Connection_Close();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = objDataSet;
            dataGridView1.DataMember = "Excel_read_karkard";
            DataGridViewCellStyle objAlignRightCellStyle = new DataGridViewCellStyle();
            objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewCellStyle objAlternatingCellStyle = new DataGridViewCellStyle();
            objAlternatingCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle;

            DataGridViewCellStyle objCurrencyCellStyle = new DataGridViewCellStyle();
            objCurrencyCellStyle.Format = "c";
            objCurrencyCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "نام فیلد";
            dataGridView1.Columns[2].HeaderText = "نام ستون کادر بالا";

            objCurrencyCellStyle = null;
            objAlternatingCellStyle = null;
            objAlignRightCellStyle = null;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (objDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(objDataSet, "Excel_read_karkard");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XLS Format (*.xls) |*.xls";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "انتخاب فایل اکسل";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists == true)
                {
                    objDataSet1.Clear();

                    ImageName = openFileDialog1.FileName;
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ImageName + "; Extended Properties=Excel 8.0";
                    StringBuilder strbuilder = new StringBuilder();
                    strbuilder.Append("SELECT * FROM [" + textBox3.Text + "$A1:" + textBox1.Text + textBox2.Text + "]");
                    OleDbDataAdapter adapter = new OleDbDataAdapter(strbuilder.ToString(), connection);
                    adapter.Fill(objDataSet1);
                    DataView dv = new DataView(objDataSet1.Tables[0]);
                    dataGridView2.DataSource = dv;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            database.Connection_Open();
            database.Fill("SELECT tmpid,selectid,code,name,family,name_pedar,sex,cod_mely,sh_sh FROM tbl_personel WHERE (idgroup = " + id_group + ") AND (idyear = " + id_year + ") AND (idmoon = " + id_moon + ")", objDataSet, "tbl_personel", true);
            database.Connection_Close();

            database.Connection_Open();
            database.Fill("SELECT * FROM Excel_read_karkard ORDER BY tmpid", objDataSet, "Excel_read_karkard", true);
            database.Connection_Close();

            if (objDataSet.Tables["tbl_personel"].Rows.Count > 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = objDataSet.Tables["tbl_personel"].Rows.Count - 1;

                for (int q = 0; q <= objDataSet.Tables["tbl_personel"].Rows.Count - 1; q++)
                {
                    progressBar1.Value = q;

                    database.Connection_Open();
                    database.Fill("SELECT * FROM Tbl_karkard WHERE (idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (type1=1) AND (idpersonal=" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + ")", objDataSet, "textexistTbl_karkard", true);
                    database.Connection_Close();

                    if (objDataSet.Tables["textexistTbl_karkard"].Rows.Count.ToString() == "0")
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.Connection = objConnection;
                        objCommand.CommandText = "INSERT INTO Tbl_karkard (idgroup,idyear,idmoon,idpersonal,type1) VALUES (@idgroup,@idyear,@idmoon,@idpersonal,@type1)";
                        objCommand.CommandType = CommandType.Text;
                        objCommand.Parameters.AddWithValue("@idgroup", id_group);
                        objCommand.Parameters.AddWithValue("@idyear", id_year);
                        objCommand.Parameters.AddWithValue("@idmoon", id_moon);
                        objCommand.Parameters.AddWithValue("@idpersonal", objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString());
                        objCommand.Parameters.AddWithValue("@type1", 1);
                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }

                    objDataSet.Tables["textexistTbl_karkard"].Clear();

                    objDataSet1.Clear();
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + ImageName + "; Extended Properties=Excel 8.0";
                    StringBuilder strbuilder = new StringBuilder();
                    strbuilder.Append("SELECT * FROM [" + textBox3.Text + "$A1:" + textBox1.Text + textBox2.Text + "] WHERE (" + objDataSet.Tables["Excel_read_karkard"].Rows[0]["name2"].ToString() + " = '" + objDataSet.Tables["tbl_personel"].Rows[q]["code"].ToString() + "')");
                    OleDbDataAdapter adapter = new OleDbDataAdapter(strbuilder.ToString(), connection);
                    adapter.Fill(objDataSet1);

                    if (objDataSet1.Tables[0].Rows.Count > 0)
                    {
                        SqlCommand objCommand = new SqlCommand();
                        objCommand.Connection = objConnection;
                        objCommand.CommandText = "UPDATE Tbl_karkard SET q1=@q1, q6=@q6 ,q2=@q2 ,q3=@q3 ,q4=@q4 ,q5=@q5 WHERE (idgroup = '" + id_group + "') AND (idyear = '" + id_year + "') AND (idmoon = '" + id_moon + "') AND (idpersonal = '" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + "') AND (type1=1)";

                        objCommand.CommandType = CommandType.Text;
                        if (objDataSet.Tables["Excel_read_karkard"].Rows[1]["name2"].ToString() == "-")
                            objCommand.Parameters.AddWithValue("@q1", 0);
                        else
                        {
                            double qt1 = 0;
                            string temp1 = objDataSet1.Tables[0].Rows[0][objDataSet.Tables["Excel_read_karkard"].Rows[1]["name2"].ToString()].ToString();

                            if (temp1.IndexOf(":").ToString() != "-1")
                            {
                                qt1 = Convert.ToDouble(temp1.Substring(0, Convert.ToInt32(temp1.IndexOf(":").ToString())));
                                qt1 = qt1 + Math.Round((Convert.ToDouble(temp1.Substring((Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1), (temp1.Length - (Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1)))) / 60), 2);
                            }
                            else
                            {
                                qt1 = Convert.ToDouble(temp1);
                            }
                            objCommand.Parameters.AddWithValue("@q1", qt1);
                        }

                        if (objDataSet.Tables["Excel_read_karkard"].Rows[2]["name2"].ToString() == "-")
                            objCommand.Parameters.AddWithValue("@q6", 0);
                        else
                        {
                            double qt1 = 0;
                            string temp1 = objDataSet1.Tables[0].Rows[0][objDataSet.Tables["Excel_read_karkard"].Rows[2]["name2"].ToString()].ToString();

                            if (temp1.IndexOf(":").ToString() != "-1")
                            {
                                qt1 = Convert.ToDouble(temp1.Substring(0, Convert.ToInt32(temp1.IndexOf(":").ToString())));
                                qt1 = qt1 + Math.Round((Convert.ToDouble(temp1.Substring((Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1), (temp1.Length - (Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1)))) / 60), 2);
                            }
                            else
                            {
                                qt1 = Convert.ToDouble(temp1);
                            }
                            objCommand.Parameters.AddWithValue("@q6", qt1);
                        }

                        if (objDataSet.Tables["Excel_read_karkard"].Rows[3]["name2"].ToString() == "-")
                            objCommand.Parameters.AddWithValue("@q2", 0);
                        else
                        {
                            double qt1 = 0;
                            string temp1 = objDataSet1.Tables[0].Rows[0][objDataSet.Tables["Excel_read_karkard"].Rows[3]["name2"].ToString()].ToString();

                            if (temp1.IndexOf(":").ToString() != "-1")
                            {
                                qt1 = Convert.ToDouble(temp1.Substring(0, Convert.ToInt32(temp1.IndexOf(":").ToString())));
                                qt1 = qt1 + Math.Round((Convert.ToDouble(temp1.Substring((Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1), (temp1.Length - (Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1)))) / 60), 2);
                            }
                            else
                            {
                                qt1 = Convert.ToDouble(temp1);
                            }
                            objCommand.Parameters.AddWithValue("@q2", qt1);
                        }

                        if (objDataSet.Tables["Excel_read_karkard"].Rows[4]["name2"].ToString() == "-")
                            objCommand.Parameters.AddWithValue("@q3", 0);
                        else
                        {
                            double qt1 = 0;
                            string temp1 = objDataSet1.Tables[0].Rows[0][objDataSet.Tables["Excel_read_karkard"].Rows[4]["name2"].ToString()].ToString();

                            if (temp1.IndexOf(":").ToString() != "-1")
                            {
                                qt1 = Convert.ToDouble(temp1.Substring(0, Convert.ToInt32(temp1.IndexOf(":").ToString())));
                                qt1 = qt1 + Math.Round((Convert.ToDouble(temp1.Substring((Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1), (temp1.Length - (Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1)))) / 60), 2);
                            }
                            else
                            {
                                qt1 = Convert.ToDouble(temp1);
                            }
                            objCommand.Parameters.AddWithValue("@q3", qt1);
                        }

                        if (objDataSet.Tables["Excel_read_karkard"].Rows[5]["name2"].ToString() == "-")
                            objCommand.Parameters.AddWithValue("@q4", 0);
                        else
                        {
                            double qt1 = 0;
                            string temp1 = objDataSet1.Tables[0].Rows[0][objDataSet.Tables["Excel_read_karkard"].Rows[5]["name2"].ToString()].ToString();

                            if (temp1.IndexOf(":").ToString() != "-1")
                            {
                                qt1 = Convert.ToDouble(temp1.Substring(0, Convert.ToInt32(temp1.IndexOf(":").ToString())));
                                qt1 = qt1 + Math.Round((Convert.ToDouble(temp1.Substring((Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1), (temp1.Length - (Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1)))) / 60), 2);
                            }
                            else
                            {
                                qt1 = Convert.ToDouble(temp1);
                            }
                            objCommand.Parameters.AddWithValue("@q4", qt1);
                        }

                        if (objDataSet.Tables["Excel_read_karkard"].Rows[6]["name2"].ToString() == "-")
                            objCommand.Parameters.AddWithValue("@q5", 0);
                        else
                        {
                            double qt1 = 0;
                            string temp1 = objDataSet1.Tables[0].Rows[0][objDataSet.Tables["Excel_read_karkard"].Rows[6]["name2"].ToString()].ToString();

                            if (temp1.IndexOf(":").ToString() != "-1")
                            {
                                qt1 = Convert.ToDouble(temp1.Substring(0, Convert.ToInt32(temp1.IndexOf(":").ToString())));
                                qt1 = qt1 + Math.Round((Convert.ToDouble(temp1.Substring((Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1), (temp1.Length - (Convert.ToInt32(temp1.IndexOf(":").ToString()) + 1)))) / 60), 2);
                            }
                            else
                            {
                                qt1 = Convert.ToDouble(temp1);
                            }
                            objCommand.Parameters.AddWithValue("@q5", qt1);
                        }

                        objConnection.Open();
                        objCommand.ExecuteNonQuery();
                        objConnection.Close();
                    }
                }
            }
        }
    }
}
