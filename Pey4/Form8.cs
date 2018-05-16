using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Pey4
{
    public partial class Form8 : Form
    {
        public string GroupName;
        public string id_group;

        SqlConnection objConnection = new SqlConnection(DB_Base.ConStr);
        DB_Base Database = new DB_Base();
        DataSet objDataSet = new DataSet();

        public Form8()
        {
            InitializeComponent();
        }

        private void delet()
        {
            //te_phon.Text = "";
            //te_shmely.Text = "";
            //tex_1.Text = "";
            //tex_2.Text = "";
            //tex_3.Text = "";
            //tex_4.Text = "";
            //tex_5.Text = "";
            //tex_addrs.Text = "";
            //tex_family.Text = "";
            //tex_kodagte.Text = "";
            //tex_kodkar.Text = "";
            //tex_maliat.Text = "";
            //tex_mtn.Text = "";
            //tex_namekar.Text = "";
            //tex_noshark.Text = "";
            //tex_parv.Text = "";
            //tex_post.Text = "";
            //tex_shobimeh.Text = "";
            //tex_tfn.Text = "";
            //tex_tfn.Text = "";
            //text_mely.Text = "";
            //tex_sherkat.Text = "";
            //tex_sherkat.Focus();
        }

        private void butt_ok_Click(object sender, EventArgs e)
        {
            MemoryStream stream = new MemoryStream();
            pictureBoxLogo.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] picbyte = stream.ToArray();

            SqlCommand command = new SqlCommand();
            command.Connection = objConnection;
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE Tab_Shrkat SET name_shrkat=@name_shrkat, mahale_sabt=@mahale_sabt, noe_shrkat=@noe_shrkat, phone=@phone, sabt=@sabt, idposti=@idposti, address=@address, image_byte=@image_byte, kod_kargah=@kod_kargah, radif_peyman=@radif_peyman, nameshobe_bime=@nameshobe_bime, name_kargah=@name_kargah, kod_shemely=@kod_shemely, nerkhe_bime=@nerkhe_bime, sh_parvande=@sh_parvande, kod_shobe=@kod_shobe, noeasliepardakhtkonande=@noeasliepardakhtkonande, noefareiepardakhtkonande=@noefareiepardakhtkonande, name_shobe=@name_shobe, nahve_maliyat=@nahve_maliyat, pardakht_name=@pardakht_name, pardakht_family=@pardakht_family, pardakht_codemelli=@pardakht_codemelli, kod_egtesady=@kod_egtesady, nahve_pardakht=@nahve_pardakht, emza1_name=@emza1_name, emza1_family=@emza1_family, emza1_codemelli=@emza1_codemelli, emza1_semat=@emza1_semat, kod_TFN=@kod_TFN, kod_TIN=@kod_TIN, uuser=@uuser, udate=@udate, utime=@utime, upc=@upc  WHERE (tmpid = " + id_group.ToString() + ")";

            command.Parameters.AddWithValue("@name_shrkat", textBox1.Text);
            command.Parameters.AddWithValue("@mahale_sabt", textBox2.Text);
            command.Parameters.AddWithValue("@noe_shrkat", textBox3.Text);
            command.Parameters.AddWithValue("@phone", textBox4.Text);
            command.Parameters.AddWithValue("@sabt", textBox5.Text);
            command.Parameters.AddWithValue("@idposti", textBox6.Text);
            command.Parameters.AddWithValue("@address", textBox7.Text);
            command.Parameters.AddWithValue("@image_byte", picbyte);

            command.Parameters.AddWithValue("@kod_kargah", textBox8.Text);
            command.Parameters.AddWithValue("@radif_peyman", textBox9.Text);
            command.Parameters.AddWithValue("@nameshobe_bime", textBox10.Text);
            command.Parameters.AddWithValue("@name_kargah", textBox11.Text);
            command.Parameters.AddWithValue("@kod_shemely", textBox12.Text);
            command.Parameters.AddWithValue("@nerkhe_bime", textBox13.Text);

            command.Parameters.AddWithValue("@sh_parvande", textBox14.Text);
            command.Parameters.AddWithValue("@kod_shobe", textBox15.Text);
            command.Parameters.AddWithValue("@noeasliepardakhtkonande", db_Combo1.SelectedValue);
            command.Parameters.AddWithValue("@noefareiepardakhtkonande", db_Combo2.SelectedValue);
            command.Parameters.AddWithValue("@name_shobe", textBox16.Text);
            command.Parameters.AddWithValue("@nahve_maliyat", db_Combo3.SelectedValue);
            command.Parameters.AddWithValue("@pardakht_name", textBox17.Text);
            command.Parameters.AddWithValue("@pardakht_family", textBox18.Text);
            command.Parameters.AddWithValue("@pardakht_codemelli", textBox19.Text);
            command.Parameters.AddWithValue("@kod_egtesady", textBox20.Text);
            command.Parameters.AddWithValue("@nahve_pardakht", db_Combo4.SelectedValue);
            command.Parameters.AddWithValue("@emza1_name", textBox21.Text);
            command.Parameters.AddWithValue("@emza1_family", textBox22.Text);
            command.Parameters.AddWithValue("@emza1_codemelli", textBox23.Text);
            command.Parameters.AddWithValue("@emza1_semat", textBox24.Text);
            command.Parameters.AddWithValue("@kod_TFN", textBox25.Text);
            command.Parameters.AddWithValue("@kod_TIN", textBox26.Text);

            command.Parameters.AddWithValue("@uuser", ".");
            command.Parameters.AddWithValue("@udate", Database.u_date());
            command.Parameters.AddWithValue("@utime", Database.u_time());
            command.Parameters.AddWithValue("@upc", Database.u_pc());

            objConnection.Open();
            command.ExecuteNonQuery();
            objConnection.Close();
            command.Dispose();

            MessageBox.Show(" اطلاعات با موفقیت ثبت شد ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        public void Form_Load_set_color()
        {
            Database.Connection_Open();
            Database.Fill("SELECT * FROM Color_Font_Set ORDER BY tmpid", objDataSet, "Color_Font_Set", true);
            Database.Connection_Close();

            TypeConverter tc0 = TypeDescriptor.GetConverter(typeof(Color));
            Color newColor0 = (Color)tc0.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[6]["promp"].ToString());

            foreach (Control ct in this.Controls)
            {
                if (ct.GetType() == typeof(GroupBox))
                {
                    foreach (Control Gt1 in ct.Controls)
                    {
                        if (Gt1.GetType() == typeof(Label))
                        {
                            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                            Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[0]["promp"].ToString());
                            Gt1.Font = newFont;

                            TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                            Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[1]["promp"].ToString());
                            Gt1.ForeColor = newColor;
                        }

                        if ((Gt1.GetType() == typeof(TextBox)) || (Gt1.GetType() == typeof(ComboBox)) || (Gt1.GetType() == typeof(Db_Combo)) || (Gt1.GetType() == typeof(MaskedTextBox)))
                        {
                            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                            Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[4]["promp"].ToString());
                            Gt1.Font = newFont;

                            TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                            Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[5]["promp"].ToString());
                            Gt1.ForeColor = newColor;
                        }

                        if (Gt1.GetType() == typeof(Button))
                        {
                            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                            Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[13]["promp"].ToString());
                            Gt1.Font = newFont;

                            TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                            Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[14]["promp"].ToString());
                            Gt1.ForeColor = newColor;
                        }

                    }
                }
                if (ct.GetType() == typeof(Button))
                {
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Font));
                    Font newFont = (Font)tc.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[13]["promp"].ToString());
                    ct.Font = newFont;

                    TypeConverter tc1 = TypeDescriptor.GetConverter(typeof(Color));
                    Color newColor = (Color)tc1.ConvertFromString(objDataSet.Tables["Color_Font_Set"].Rows[14]["promp"].ToString());
                    ct.ForeColor = newColor;
                }
            }

            this.BackColor = newColor0;

            objDataSet.Clear();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            Form_Load_set_color();

            this.Text = "اطلاعات " + GroupName;

            db_Combo1.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 5) ORDER BY SCode", "SDesc", "SCode");
            db_Combo2.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 6) ORDER BY SCode", "SDesc", "SCode");
            db_Combo3.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 7) ORDER BY SCode", "SDesc", "SCode");
            db_Combo4.Bind_Data1("SELECT SCode, SDesc FROM Maliat_coding WHERE (MCode = 9) ORDER BY SCode", "SDesc", "SCode");

            objDataSet.Clear();
            Database.Connection_Open();
            Database.Fill("SELECT * FROM [Tab_Shrkat] WHERE (tmpid = " + id_group.ToString() + ")", objDataSet, "Tab_Shrkat", true);
            Database.Connection_Close();

            textBox1.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["name_shrkat"].ToString();
            textBox2.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["mahale_sabt"].ToString();
            textBox3.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["noe_shrkat"].ToString();
            textBox4.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["phone"].ToString();
            textBox5.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["sabt"].ToString();
            textBox6.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["idposti"].ToString();
            textBox7.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["address"].ToString();
            textBox8.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_kargah"].ToString();
            textBox9.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["radif_peyman"].ToString();
            textBox10.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["nameshobe_bime"].ToString();
            textBox11.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["name_kargah"].ToString();
            textBox12.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_shemely"].ToString();
            textBox13.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["nerkhe_bime"].ToString();
            textBox14.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["sh_parvande"].ToString();
            textBox15.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_shobe"].ToString();
            textBox16.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["name_shobe"].ToString();
            textBox17.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_name"].ToString();
            textBox18.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_family"].ToString();
            textBox19.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["pardakht_codemelli"].ToString();
            textBox20.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_egtesady"].ToString();
            textBox21.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_name"].ToString();
            textBox22.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_family"].ToString();
            textBox23.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_codemelli"].ToString();
            textBox24.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["emza1_semat"].ToString();
            textBox25.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_TFN"].ToString();
            textBox26.Text = objDataSet.Tables["Tab_Shrkat"].Rows[0]["kod_TIN"].ToString();

            db_Combo1.SelectedValue = objDataSet.Tables["Tab_Shrkat"].Rows[0]["noeasliepardakhtkonande"].ToString();
            db_Combo2.SelectedValue = objDataSet.Tables["Tab_Shrkat"].Rows[0]["noefareiepardakhtkonande"].ToString();
            db_Combo3.SelectedValue = objDataSet.Tables["Tab_Shrkat"].Rows[0]["nahve_maliyat"].ToString();
            db_Combo4.SelectedValue = objDataSet.Tables["Tab_Shrkat"].Rows[0]["nahve_pardakht"].ToString();

            if ((objDataSet.Tables["Tab_Shrkat"].Rows[0]["image_byte"] != null) && (objDataSet.Tables["Tab_Shrkat"].Rows[0]["image_byte"].ToString() != ""))
            {
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])(objDataSet.Tables["Tab_Shrkat"].Rows[0]["image_byte"]);
                MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                pictureBoxLogo.Image = Image.FromStream(stmBLOBData);

                pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            openFileDialogImage.Filter = "JPG Format (*.jpg) |*.jpg| PNG Format (*.png) |*.png";
            openFileDialogImage.FilterIndex = 1;
            openFileDialogImage.Title = "انتخاب لوگو برای شرکت";

            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialogImage.CheckFileExists == true)
                {
                    string ImageName = openFileDialogImage.FileName;
                    pictureBoxLogo.ImageLocation = ImageName;
                    pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
    }
}