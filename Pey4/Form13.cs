using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;

using System.Text;
using System.Windows.Forms;

namespace Pey4
{
    public partial class Form13 : Form
    {
        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        DataSet loan_peymentDataSet = new DataSet();

        DB_Base database = new DB_Base();
        U_Base U_set = new U_Base();

        public string loan_code;
        public string loan_price;
        
        public Form13()
        {
            InitializeComponent();
        }

        private void ShowLoan_payment()
        {
            database.Connection_Open();
            database.Fill("SELECT * FROM tbl_loan_payment WHERE (loan_code = " + loan_code + ")", loan_peymentDataSet, "tbl_loan_payment", true);
            database.Connection_Close();
            
            dgvLoan_payment.DataSource = loan_peymentDataSet;
            dgvLoan_payment.DataMember = "tbl_loan_payment";
            dgvLoan_payment.AutoGenerateColumns = true;

            dgvLoan_payment.Columns[0].Visible = false;
            dgvLoan_payment.Columns[1].HeaderText = "کد وام";
            dgvLoan_payment.Columns[2].HeaderText = "تاریخ قسط";
            dgvLoan_payment.Columns[3].HeaderText = "مبلغ";
            dgvLoan_payment.Columns[4].HeaderText = "وضعیت پرداخت";
        }

        private void ResetFields()
        {
            mtxt_first_payment_date.Text = "";
            txt_payment_count.Text = "";
            txt_month_between.Text = "";
            txt_equal_payment.Text = "";
            txt_nonequal_payment.Text = "";
        }

        private string payment_date(string date, int numberdate)
        {
            string payment_date;
            int d, m, y;

            DateTime dt = Convert.ToDateTime(date);
            
            d = dt.Day;
            m = dt.Month + numberdate;
            y = dt.Year;

            int tmpm1;
            int tmpm2;

            if (m >= 12)
            {
                tmpm1 = m % 12;
                tmpm2 = m / 12;

                if (tmpm1 == 0)
                {
                    tmpm1 = 12;
                    tmpm2 = tmpm2 - 1;
                }
                
                m = tmpm1;
                y += tmpm2;
            }

            payment_date = y.ToString() + "/" + m.ToString().PadLeft(2,'0') + "/" + d.ToString().PadLeft(2,'0');
            return (payment_date);
        }

        public void Form_Load_set_color()
        {
            DataSet objDataSet1 = new DataSet();

            database.Connection_Open();
            database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet1, "Color_Font_Set", true);
            database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

            foreach (SplitContainer spc in this.Controls)
            {
                foreach (Control ct in spc.Panel1.Controls)
                {
                    if (ct.GetType() == typeof(Button))
                    {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                        Font newFont = (Font)tc.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[13]["promp"].ToString());
                        ct.Font = newFont;

                        TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                        Color newColor = (Color)tc1.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[14]["promp"].ToString());
                        ct.ForeColor = newColor;
                    }
                }
            }
            this.BackColor = newColor0;

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

            dgvLoan_payment.Font = newFont7;
            dgvLoan_payment.BackgroundColor = newColor8;
            dgvLoan_payment.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dgvLoan_payment.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dgvLoan_payment.DefaultCellStyle = objAlignRightCellStyle3;

            objDataSet1.Clear();
        }

        private void Form_sec()
        {
            if (U_set.u_user_sec(16) == 0) { dgvLoan_payment.AllowUserToAddRows = false; btn_save.Visible = false; }
            if (U_set.u_user_sec(17) == 0) { dgvLoan_payment.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { dgvLoan_payment.AllowUserToDeleteRows = false; }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            ShowLoan_payment();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (mtxt_first_payment_date.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا تاریخ اولین قسط را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxt_first_payment_date.Focus();
                return;
            }

            if (txt_payment_count.Text == "")
            {
                MessageBox.Show("لطفا تعداد اقساط را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_payment_count.Focus();
                return;
            }

            if (txt_month_between.Text == "")
            {
                MessageBox.Show("لطفا ماه های میان بازپرداخت را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_month_between.Focus();
                return;
            }

            if (txt_equal_payment.Text == "")
            {
                MessageBox.Show("لطفا قسط مساوی را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_equal_payment.Focus();
                return;
            }

            if (txt_nonequal_payment.Text == "")
            {
                MessageBox.Show("لطفا قسط نامساوی را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nonequal_payment.Focus();
                return;
            }

            if (loan_peymentDataSet.Tables["tbl_loan_payment"].Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("در صورت تایید، اطلاعات قبلی از بین می رود", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlCommand delete = new SqlCommand();
                    delete.Connection = objConnection;
                    delete.CommandText = "DELETE FROM tbl_loan_payment WHERE (loan_code = " + Convert.ToInt16(loan_code) + ")";
                    delete.CommandType = CommandType.Text;
                    objConnection.Open();
                    delete.ExecuteNonQuery();
                    objConnection.Close();
                }
            }

            int i = 0;
            for (i = 0; i < Convert.ToInt16(txt_payment_count.Text) - 1; i++)
            {
                SqlCommand objCommand1 = new SqlCommand();
                objCommand1.Connection = objConnection;
                objCommand1.CommandText = "INSERT INTO tbl_loan_payment (loan_code,payment_date,payment_price) VALUES (@loan_code,@payment_date,@payment_price)";
                objCommand1.CommandType = CommandType.Text;
                objCommand1.Parameters.AddWithValue("@loan_code", loan_code);
                objCommand1.Parameters.AddWithValue("@payment_date", payment_date(mtxt_first_payment_date.Text, Convert.ToInt16(i * Convert.ToInt16(txt_month_between.Text))));
                objCommand1.Parameters.AddWithValue("@payment_price", txt_equal_payment.Text);
                objConnection.Open();
                objCommand1.ExecuteNonQuery();
                objConnection.Close();
            }
            SqlCommand objCommand2 = new SqlCommand();
            objCommand2.Connection = objConnection;
            objCommand2.CommandText = "INSERT INTO tbl_loan_payment (loan_code,payment_date,payment_price) VALUES (@loan_code,@payment_date,@payment_price)";
            objCommand2.CommandType = CommandType.Text;
            objCommand2.Parameters.AddWithValue("@loan_code", loan_code);
            objCommand2.Parameters.AddWithValue("@payment_date", payment_date(mtxt_first_payment_date.Text, Convert.ToInt16(i * Convert.ToInt16(txt_month_between.Text))));
            objCommand2.Parameters.AddWithValue("@payment_price", txt_nonequal_payment.Text);
            objConnection.Open();
            objCommand2.ExecuteNonQuery();
            objConnection.Close();

            ResetFields();
            ShowLoan_payment();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (loan_peymentDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(loan_peymentDataSet, "tbl_loan_payment");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form13_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loan_peymentDataSet.HasChanges())
            {
                DialogResult result = MessageBox.Show("آیا مایل به ذخیره تغییرات می باشید", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
                    database.Connection_Open();
                    objCommandBuilder.DataAdapter.Update(loan_peymentDataSet, "tbl_loan_payment");
                    database.Connection_Close();
                    MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void mtxt_first_payment_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { txt_payment_count.Focus(); }
        }

        private void txt_payment_count_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { txt_month_between.Focus(); }
        }

        private void txt_month_between_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { txt_equal_payment.Focus(); }
        }

        private void txt_equal_payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { txt_nonequal_payment.Focus(); }
        }

        private void txt_nonequal_payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { btn_save.Focus(); }
        }
    }
}
