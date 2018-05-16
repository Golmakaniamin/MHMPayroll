using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Pey4
{
    public partial class Form29 : Form
    {
        public Form29()
        {
            InitializeComponent();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Format (*.jpg) |*.jpg| PNG Format (*.png) |*.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "انتخاب عکس";

            string ImageName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists == true)
                {
                    ImageName = openFileDialog1.FileName;
                }
            }

            string file_name = Application.StartupPath.ToString();
            file_name += @"\Pey4_BG.Dll";

            string[] installs = new string[1];
            installs[0] = ImageName;
            
            System.IO.File.WriteAllLines(file_name, installs, Encoding.ASCII);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color_Font_Set f1 = new Color_Font_Set();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start_info = new ProcessStartInfo("Regsvr32",Application.StartupPath.ToString() + @"\W2D_D2W.dll");
            start_info.UseShellExecute = false;
            start_info.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = start_info;

            proc.Start();
        }
    }
}
