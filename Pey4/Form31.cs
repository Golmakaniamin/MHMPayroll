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
    public partial class Form31 : Form
    {
        DB_Base Database = new DB_Base();
        string file_name = Application.StartupPath.ToString() + @"\Note_me.txt";

        public Form31()
        {
            InitializeComponent();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string[] words1 = richTextBox1.Lines;
            System.IO.File.WriteAllLines(file_name, words1,Encoding.Unicode);

            MessageBox.Show("یادداشت ذخیره شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Form_Load_set_color()
        {
            DataSet objDataSet1 = new DataSet();

            Database.Connection_Open();
            Database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet1, "Color_Font_Set", true);
            Database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet1.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

            foreach (SplitContainer spc in this.Controls)
            {
                foreach (Control ct in spc.Panel2.Controls)
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

            objDataSet1.Clear();
        }

        private void Form31_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();

            string[] words1 = System.IO.File.ReadAllLines(file_name, Encoding.Unicode);
            richTextBox1.Lines = words1;
        }
    }
}
