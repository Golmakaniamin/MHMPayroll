namespace Pey4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.but_login = new System.Windows.Forms.Button();
            this.but_Exit = new System.Windows.Forms.Button();
            this.tex_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(563, 9);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(142, 28);
            this.comboBox1.TabIndex = 22;
            // 
            // but_login
            // 
            this.but_login.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.but_login.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.but_login.Image = ((System.Drawing.Image)(resources.GetObject("but_login.Image")));
            this.but_login.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_login.Location = new System.Drawing.Point(15, 194);
            this.but_login.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.but_login.Name = "but_login";
            this.but_login.Size = new System.Drawing.Size(105, 49);
            this.but_login.TabIndex = 21;
            this.but_login.Text = "ورود";
            this.but_login.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_login.UseVisualStyleBackColor = false;
            this.but_login.Click += new System.EventHandler(this.but_login_Click);
            // 
            // but_Exit
            // 
            this.but_Exit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.but_Exit.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.but_Exit.Image = ((System.Drawing.Image)(resources.GetObject("but_Exit.Image")));
            this.but_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.but_Exit.Location = new System.Drawing.Point(132, 194);
            this.but_Exit.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            this.but_Exit.Name = "but_Exit";
            this.but_Exit.Size = new System.Drawing.Size(105, 49);
            this.but_Exit.TabIndex = 20;
            this.but_Exit.Text = "خروج";
            this.but_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_Exit.UseVisualStyleBackColor = false;
            this.but_Exit.Click += new System.EventHandler(this.but_Exit_Click);
            // 
            // tex_pass
            // 
            this.tex_pass.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tex_pass.Location = new System.Drawing.Point(563, 50);
            this.tex_pass.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tex_pass.Name = "tex_pass";
            this.tex_pass.Size = new System.Drawing.Size(142, 27);
            this.tex_pass.TabIndex = 19;
            this.tex_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tex_pass_KeyDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(705, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 27);
            this.label2.TabIndex = 18;
            this.label2.Text = "رمز عبور";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(705, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 28);
            this.label1.TabIndex = 17;
            this.label1.Text = "نام کاربری";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::Pey4.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(799, 250);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.but_login);
            this.Controls.Add(this.but_Exit);
            this.Controls.Add(this.tex_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ورود کاربران";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button but_login;
        private System.Windows.Forms.Button but_Exit;
        private System.Windows.Forms.TextBox tex_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

