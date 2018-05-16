using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pey4
{
    public partial class Form14 : Form
    {
        DB_Base database = new DB_Base();
        DataSet objDataSet = new DataSet();
        public Form14()
        {
            InitializeComponent();
        }

        

        private void butt_ok_Click(object sender, EventArgs e)
        {
            DB_Base database = new DB_Base();
            database.Connection_Open();
            database.objCommand.Parameters.AddWithValue("@azafkari_adi",textBox9.Text);
            database.objCommand.Parameters.AddWithValue("@azafkari_tatily", textBox8.Text);
            database.objCommand.Parameters.AddWithValue("@nobat_kar", textBox7.Text);
            database.objCommand.Parameters.AddWithValue("@sab_kari", textBox6.Text);
            database.objCommand.Parameters.AddWithValue("@mamoriat", textBox5.Text);
            database.objCommand.Parameters.AddWithValue("@sat_rozaneh", textBox4.Text);
            database.objCommand.Parameters.AddWithValue("@sat_haftgi", textBox3.Text);
            database.objCommand.Parameters.AddWithValue("@sat_mahaneh", textBox2.Text);
            database.objCommand.Parameters.AddWithValue("@sat_sakht",textBox1.Text);
             database.objCommand.Parameters.AddWithValue("@udate", Persia.Calendar.ConvertToPersian(DateTime.Now).Simple.ToString());
            database.objCommand.Parameters.AddWithValue("@utime", DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString());
            database.objCommand.Parameters.AddWithValue("@upc", ".");
           // database.objCommand.Parameters.AddWithValue("@uId", tex_codper.Text);
          //  database.objCommand.Parameters.AddWithValue("@uGrop", label16.Text);
              //  database.objCommand.Parameters.AddWithValue("@uuser", label16.Text);
          database.objCommand.CommandText = "INSERT INTO [Tbl_zarib] ([azafkari_adi],[azafkari_tatily],[nobat_kar],[sab_kari],[mamoriat],[sat_rozaneh],[sat_haftgi],[sat_mahaneh],[sat_sakht],[udate],[utime],[upc]) values (@azafkari_adi,@azafkari_tatily,@nobat_kar,@sab_kari,@mamoriat,@sat_rozaneh,@sat_haftgi,@sat_mahaneh,@sat_sakht,@udate,@utime,@upc)";
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
            delete();
        }

        private void bu_new_Click(object sender, EventArgs e)
        {
            delete();
        }
        private void delete()
        {
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            textBox9.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        }
    }

