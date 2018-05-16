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
    public partial class Form25 : Form
    {
        DB_Base database = new DB_Base();
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();

        public string id_year;
        public string id_moon;
        public string id_group;

        public string personel_tmpid;
        public string personel_name;
        public DataSet objDataSet;

        string combo1_id1 = "0";
        int datagridview1_idpersonel = 0;

        public Form25()
        {
            InitializeComponent();
        }

        public void Form_Load_set_color()
        {
            DataSet objDataSet1 = new DataSet();

            database.Connection_Open();
            database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet1, "Color_Font_Set", true);
            database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());
            this.BackColor = newColor0;

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont = (Font)tc.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[13]["promp"].ToString());
            Btn_Save.Font = newFont;

            TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor = (Color)tc1.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[14]["promp"].ToString());
            Btn_Save.ForeColor = newColor;

            TypeConverter tc13 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont13 = (Font)tc13.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[0]["promp"].ToString());
            checkBox1.Font = newFont13;

            TypeConverter tc14 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor14 = (Color)tc14.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[1]["promp"].ToString());
            checkBox1.ForeColor = newColor14;

            TypeConverter tc2 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont2 = (Font)tc2.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[2]["promp"].ToString());

            TypeConverter tc3 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor3 = (Color)tc3.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[8]["promp"].ToString());

            TypeConverter tc7 = TypeDescriptor.GetConverter(typeof(Font));
            Font newFont7 = (Font)tc7.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[7]["promp"].ToString());

            TypeConverter tc8 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor8 = (Color)tc8.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[8]["promp"].ToString());

            TypeConverter tc9 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor9 = (Color)tc9.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[9]["promp"].ToString());

            TypeConverter tc10 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor10 = (Color)tc10.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[10]["promp"].ToString());

            TypeConverter tc11 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor11 = (Color)tc11.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[11]["promp"].ToString());

            TypeConverter tc12 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor12 = (Color)tc12.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[12]["promp"].ToString());

            DataGridViewCellStyle objAlignRightCellStyle1 = new DataGridViewCellStyle();
            objAlignRightCellStyle1.Font = newFont2;
            objAlignRightCellStyle1.BackColor = newColor3;

            DataGridViewCellStyle objAlignRightCellStyle2 = new DataGridViewCellStyle();
            objAlignRightCellStyle2.BackColor = newColor9;
            objAlignRightCellStyle2.ForeColor = newColor10;

            DataGridViewCellStyle objAlignRightCellStyle3 = new DataGridViewCellStyle();
            objAlignRightCellStyle3.BackColor = newColor11;
            objAlignRightCellStyle3.ForeColor = newColor12;

            dataGridView1.Font = newFont7;
            dataGridView1.BackgroundColor = newColor8;
            dataGridView1.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridView1.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridView1.DefaultCellStyle = objAlignRightCellStyle3;

            dataGridView2.Font = newFont7;
            dataGridView2.BackgroundColor = newColor8;
            dataGridView2.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dataGridView2.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dataGridView2.DefaultCellStyle = objAlignRightCellStyle3;

            objDataSet1.Clear();
        }

        private void Form25_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            String Alltxtor;

            if (objDataSet.Tables["tbl_personel"].Rows.Count > 0)
            {
                Alltxtor = "";
                for (int q = 0; q <= objDataSet.Tables["tbl_personel"].Rows.Count - 1; q++)
                {
                    if (objDataSet.Tables["tbl_personel"].Rows[q]["selectid"].ToString() == "True")
                    {
                        database.Connection_Open();
                        database.Fill("SELECT * FROM Tbl_karkard WHERE (idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (idpersonal=" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + ")", objDataSet, "textexistTbl_karkard", true);
                        database.Connection_Close();

                        if (objDataSet.Tables["textexistTbl_karkard"].Rows.Count.ToString() == "0")
                        {
                            SqlCommand objCommand = new SqlCommand();
                            objCommand.Connection = objConnection;
                            objCommand.CommandText = "INSERT INTO Tbl_karkard (idgroup,idyear,idmoon,idpersonal) VALUES (@idgroup,@idyear,@idmoon,@idpersonal)";
                            objCommand.CommandType = CommandType.Text;
                            objCommand.Parameters.AddWithValue("@idgroup", id_group);
                            objCommand.Parameters.AddWithValue("@idyear", id_year);
                            objCommand.Parameters.AddWithValue("@idmoon", id_moon);
                            objCommand.Parameters.AddWithValue("@idpersonal", objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString());
                            objConnection.Open();
                            objCommand.ExecuteNonQuery();
                            objConnection.Close();

                            objDataSet.Tables["textexistTbl_karkard"].Clear();
                        }


                        Alltxtor += " (tmpid=" + objDataSet.Tables["tbl_personel"].Rows[q]["tmpid"].ToString() + ") OR ";
                    }
                }

                if (Alltxtor.Length > 0)
                {
                    Alltxtor = Alltxtor.Substring(1, Alltxtor.Length - 4);

                    database.Connection_Open();
                    database.Fill("SELECT tmpid ,code ,name ,family ,name_pedar FROM tbl_personel WHERE ((idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (NoeHoghog IN (3,4)) AND (" + Alltxtor + "))", objDataSet, "Tbl_karkardfill", true);
                    database.Connection_Close();

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = objDataSet;
                    dataGridView1.DataMember = "Tbl_karkardfill";

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "کد پرسنل";
                    dataGridView1.Columns[2].HeaderText = "نام";
                    dataGridView1.Columns[3].HeaderText = "نام خانوادگی";
                    dataGridView1.Columns[4].HeaderText = "نام پدر";
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                database.Connection_Open();
                database.Fill("SELECT * FROM Tbl_Sherkat_vabaste ORDER BY name", objDataSet, "Tbl_Sherkat_vabaste", true);
                database.Connection_Close();

                dataGridView2.Columns.Clear();

                DataGridViewComboBoxColumn combo1 = new DataGridViewComboBoxColumn();
                combo1.HeaderText = "نام شرکت";
                combo1.DataSource = objDataSet.Tables["Tbl_Sherkat_vabaste"];
                combo1.DisplayMember = "name";
                combo1.ValueMember = "tmpid";
                dataGridView2.Columns.Add(combo1);

                datagridview1_idpersonel = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());

                database.Connection_Open();
                database.Fill("SELECT *,(SELECT name FROM Tbl_Sherkat_vabaste WHERE tmpid=Tbl_Time_Karkard.idsherkat) AS namesherkat FROM Tbl_Time_Karkard WHERE ((idgroup=" + id_group + ") AND (idyear=" + id_year + ") AND (idmoon=" + id_moon + ") AND (personeltmpid=" + dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString() + "))", objDataSet, "Tbl_Time_Karkard", true);
                database.Connection_Close();

                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = objDataSet;
                dataGridView2.DataMember = "Tbl_Time_Karkard";

                DataGridViewCellStyle objAlignRightCellStyle1 = new DataGridViewCellStyle();
                objAlignRightCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
                objAlignRightCellStyle1.Format = "T";
                objAlignRightCellStyle1.NullValue = "00:00:00";

                DataGridViewCellStyle objAlignRightCellStyle2 = new DataGridViewCellStyle();
                objAlignRightCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
                objAlignRightCellStyle2.Format = "N0";
                objAlignRightCellStyle2.NullValue = "0";

                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].Visible = false;
                dataGridView2.Columns[3].Visible = false;
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;

                dataGridView2.Columns[7].HeaderText = "حقوق ساعتی";
                dataGridView2.Columns[7].DefaultCellStyle = objAlignRightCellStyle2;

                dataGridView2.Columns[8].HeaderText = "تاریخ (روز)";

                dataGridView2.Columns[9].HeaderText = "ساعت شروع";
                dataGridView2.Columns[9].DefaultCellStyle = objAlignRightCellStyle1;

                dataGridView2.Columns[10].HeaderText = "ساعت خاتمه";
                dataGridView2.Columns[10].DefaultCellStyle = objAlignRightCellStyle1;

                dataGridView2.Columns[11].HeaderText = "مدت کارکرد";
                dataGridView2.Columns[11].DefaultCellStyle = objAlignRightCellStyle1;

                dataGridView2.Columns[12].HeaderText = "جمع حقوق";
                dataGridView2.Columns[12].DefaultCellStyle = objAlignRightCellStyle2;

                dataGridView2.Columns[13].HeaderText = "نام شرکت";

                objAlignRightCellStyle1 = null;
                objAlignRightCellStyle2 = null;
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (objDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(objDataSet, "Tbl_Time_Karkard");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 0)
            {
                ComboBox cmbBox = e.Control as ComboBox;
                cmbBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            }

        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedValue != null)
            {
                string sId = ((ComboBox)sender).SelectedValue.ToString();
                string sName = ((ComboBox)sender).Text.ToString();

                combo1_id1 = sId;
            }
        }

        private void dataGridView2_Calc1(int inte)
        {
            if (Convert.ToInt16(combo1_id1.ToString()) >= 0 && dataGridView2.ColumnCount >= 2)
            {
                dataGridView2["idgroup", inte].Value = id_group;
                dataGridView2["idyear", inte].Value = id_year;
                dataGridView2["idmoon", inte].Value = id_moon;
                dataGridView2["personeltmpid", inte].Value = datagridview1_idpersonel;
                dataGridView2["idsherkat", inte].Value = combo1_id1;

                DateTime startTime, endTime;
                if ((dataGridView2["stime", inte].Value.ToString() != "") && (dataGridView2["etime", inte].Value.ToString() != ""))
                {
                    startTime = Convert.ToDateTime(dataGridView2["stime", inte].Value);
                    endTime = Convert.ToDateTime(dataGridView2["etime", inte].Value);
                    var timeDiff = new TimeSpan(endTime.Ticks - startTime.Ticks);
                    dataGridView2["Alltime", inte].Value = timeDiff.Hours.ToString().PadLeft(2, '0') + ":" + timeDiff.Minutes.ToString().PadLeft(2, '0') + ":" + timeDiff.Seconds.ToString().PadLeft(2, '0');

                    if (dataGridView2["money1", inte].Value.ToString() != "")
                    {
                        dataGridView2["summoney", inte].Value = ((timeDiff.Hours * Convert.ToInt64(dataGridView2["money1", inte].Value)) + ((Convert.ToInt64(dataGridView2["money1", inte].Value) / 60) * timeDiff.Minutes)).ToString();
                    }
                }
            }
        }

        private void dataGridView2_Calc2(int inte)
        {
            if (Convert.ToInt16(combo1_id1.ToString()) >= 0 && dataGridView2.ColumnCount >= 2)
            {
                dataGridView2["idgroup", inte].Value = id_group;
                dataGridView2["idyear", inte].Value = id_year;
                dataGridView2["idmoon", inte].Value = id_moon;
                dataGridView2["personeltmpid", inte].Value = datagridview1_idpersonel;
                dataGridView2["idsherkat", inte].Value = combo1_id1;


                if (dataGridView2["Alltime", inte].Value.ToString() != "")
                {
                    string q1 = dataGridView2["Alltime", inte].Value.ToString();
                    string q_h = q1.Substring(0, q1.IndexOf(':'));
                    string q_m = q1.Substring((q1.IndexOf(':') + 1), (q1.Length - q1.IndexOf(':') - 1));

                    if (dataGridView2["money1", inte].Value.ToString() != "")
                    {
                        dataGridView2["summoney", inte].Value = ((Convert.ToInt64(q_h) * Convert.ToInt64(dataGridView2["money1", inte].Value)) + ((Convert.ToInt64(dataGridView2["money1", inte].Value) / 60) * Convert.ToInt64(q_m))).ToString();
                    }
                }
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (checkBox1.Checked == true)
                dataGridView2_Calc1(e.RowIndex);
            else
                dataGridView2_Calc2(e.RowIndex);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
