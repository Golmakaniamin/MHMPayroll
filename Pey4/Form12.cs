using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Pey4
{
    public partial class Form12 : Form
    {
        public string id_group;
        public string id_year;
        public string id_moon;
        public string id_idmen;

        DataSet LoanDataSet = new DataSet();

        DB_Base database = new DB_Base();
        U_Base U_set = new U_Base();

        public Form12()
        {
            InitializeComponent();
        }

        private void ShowLoan()
        {
            database.Connection_Open();
            database.Fill("SELECT * FROM tbl_loan WHERE (receiver = " + id_idmen + ")", LoanDataSet, "tbl_loan", true);
            database.Connection_Close();
            
            dgvLoan.DataSource = LoanDataSet;
            dgvLoan.DataMember = "tbl_loan";
            dgvLoan.AutoGenerateColumns = true;

            dgvLoan.Columns[0].Visible = false;
            dgvLoan.Columns[1].HeaderText = "کد وام";
            dgvLoan.Columns[2].HeaderText = "مبلغ وام";
            dgvLoan.Columns[3].HeaderText = "تاریخ پرداخت وام";
            dgvLoan.Columns[4].Visible = false;
            dgvLoan.Columns[5].HeaderText = "تسویه";
        }

        private void ResetFields()
        {
            txt_loan_code.Text = "";
            txt_loan_price.Text = "";
            mtxt_payment_date.Text = "";
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

            dgvLoan.Font = newFont7;
            dgvLoan.BackgroundColor = newColor8;
            dgvLoan.ColumnHeadersDefaultCellStyle = objAlignRightCellStyle1;
            dgvLoan.AlternatingRowsDefaultCellStyle = objAlignRightCellStyle2;
            dgvLoan.DefaultCellStyle = objAlignRightCellStyle3;

            objDataSet1.Clear();
        }

        private void Form_sec()
        {
            if (U_set.u_user_sec(16) == 0) { dgvLoan.AllowUserToAddRows = false; btn_save.Visible = false; }
            if (U_set.u_user_sec(17) == 0) { dgvLoan.ReadOnly = true; }
            if (U_set.u_user_sec(18) == 0) { dgvLoan.AllowUserToDeleteRows = false; }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();
            Form_sec();

            ShowLoan();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_loan_code.Text == "")
            {
                MessageBox.Show("لطفا کد وام را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_loan_code.Focus();
                return;
            }

            if (txt_loan_price.Text == "")
            {
                MessageBox.Show("لطفا مبلغ وام را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_loan_price.Focus();
                return;
            }

            if (mtxt_payment_date.ToString().IndexOf("_").ToString() != "-1")
            {
                MessageBox.Show("لطفا تاریخ پرداخت وام را وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxt_payment_date.Focus();
                return;
            }

            DB_Base database = new DB_Base();
            database.Connection_Open();
            
            database.objCommand.Parameters.AddWithValue("@loan_code", txt_loan_code.Text);
            database.objCommand.Parameters.AddWithValue("@loan_price", txt_loan_price.Text);
            database.objCommand.Parameters.AddWithValue("@loan_payment_date", mtxt_payment_date.Text);
            database.objCommand.Parameters.AddWithValue("@receiver", id_idmen);

            database.objCommand.CommandText = "INSERT INTO tbl_loan (loan_code, loan_price, loan_payment_date, receiver) VALUES (@loan_code, @loan_price, @loan_payment_date, @receiver)";
            database.objCommand.Connection = database.objConnection;

            if (database.objCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("ثبت با موفقیت انجام شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("خطا در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            database.objCommand.Dispose();
            database.Connection_Close();
            database.objConnection.Dispose();

            ResetFields();
            ShowLoan();
        }

        private void dgvLoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form13 f13 = new Form13();
            f13.loan_code = LoanDataSet.Tables["tbl_loan"].Rows[e.RowIndex]["tmpid"].ToString();
            f13.loan_price = LoanDataSet.Tables["tbl_loan"].Rows[e.RowIndex]["loan_price"].ToString();
            f13.Show();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
            if (LoanDataSet.HasChanges())
            {
                database.Connection_Open();
                objCommandBuilder.DataAdapter.Update(LoanDataSet, "tbl_loan");
                database.Connection_Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد ", "پیام", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LoanDataSet.HasChanges())
            {
                DialogResult result = MessageBox.Show("آیا مایل به ذخیره تغییرات می باشید", "پیام", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(database.objDataAdapter);
                    database.Connection_Open();
                    objCommandBuilder.DataAdapter.Update(LoanDataSet, "tbl_loan");
                    database.Connection_Close();
                    MessageBox.Show("تغییرات با موفقیت انجام شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvLoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_loan_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { mtxt_payment_date.Focus(); }
        }

        private void mtxt_payment_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { txt_loan_price.Focus(); }
        }

        private void txt_loan_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) { btn_save.Focus(); }
        }
    }
}
