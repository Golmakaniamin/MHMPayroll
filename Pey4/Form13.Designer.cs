namespace Pey4
{
    partial class Form13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form13));
            this.txt_month_between = new System.Windows.Forms.TextBox();
            this.lbl_month = new System.Windows.Forms.Label();
            this.mtxt_first_payment_date = new System.Windows.Forms.MaskedTextBox();
            this.txt_nonequal_payment = new System.Windows.Forms.TextBox();
            this.txt_equal_payment = new System.Windows.Forms.TextBox();
            this.txt_payment_count = new System.Windows.Forms.TextBox();
            this.lbl_n_payment = new System.Windows.Forms.Label();
            this.lbl_e_payment = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.dgvLoan_payment = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan_payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_month_between
            // 
            this.txt_month_between.Location = new System.Drawing.Point(255, 54);
            this.txt_month_between.Name = "txt_month_between";
            this.txt_month_between.Size = new System.Drawing.Size(148, 27);
            this.txt_month_between.TabIndex = 7;
            this.txt_month_between.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_month_between_KeyDown);
            // 
            // lbl_month
            // 
            this.lbl_month.AutoSize = true;
            this.lbl_month.Location = new System.Drawing.Point(410, 54);
            this.lbl_month.Name = "lbl_month";
            this.lbl_month.Size = new System.Drawing.Size(103, 20);
            this.lbl_month.TabIndex = 2;
            this.lbl_month.Text = "ماه های میان بازپرداخت";
            // 
            // mtxt_first_payment_date
            // 
            this.mtxt_first_payment_date.Location = new System.Drawing.Point(255, 19);
            this.mtxt_first_payment_date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mtxt_first_payment_date.Mask = "1300/00/00";
            this.mtxt_first_payment_date.Name = "mtxt_first_payment_date";
            this.mtxt_first_payment_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtxt_first_payment_date.Size = new System.Drawing.Size(148, 27);
            this.mtxt_first_payment_date.TabIndex = 5;
            this.mtxt_first_payment_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxt_first_payment_date_KeyDown);
            // 
            // txt_nonequal_payment
            // 
            this.txt_nonequal_payment.Location = new System.Drawing.Point(255, 89);
            this.txt_nonequal_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_nonequal_payment.Name = "txt_nonequal_payment";
            this.txt_nonequal_payment.Size = new System.Drawing.Size(148, 27);
            this.txt_nonequal_payment.TabIndex = 9;
            this.txt_nonequal_payment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nonequal_payment_KeyDown);
            // 
            // txt_equal_payment
            // 
            this.txt_equal_payment.Location = new System.Drawing.Point(7, 60);
            this.txt_equal_payment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_equal_payment.Name = "txt_equal_payment";
            this.txt_equal_payment.Size = new System.Drawing.Size(148, 27);
            this.txt_equal_payment.TabIndex = 8;
            this.txt_equal_payment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_equal_payment_KeyDown);
            // 
            // txt_payment_count
            // 
            this.txt_payment_count.Location = new System.Drawing.Point(7, 23);
            this.txt_payment_count.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_payment_count.Name = "txt_payment_count";
            this.txt_payment_count.Size = new System.Drawing.Size(148, 27);
            this.txt_payment_count.TabIndex = 6;
            this.txt_payment_count.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_payment_count_KeyDown);
            // 
            // lbl_n_payment
            // 
            this.lbl_n_payment.AutoSize = true;
            this.lbl_n_payment.Location = new System.Drawing.Point(451, 92);
            this.lbl_n_payment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_n_payment.Name = "lbl_n_payment";
            this.lbl_n_payment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_n_payment.Size = new System.Drawing.Size(62, 20);
            this.lbl_n_payment.TabIndex = 4;
            this.lbl_n_payment.Text = "قسط نامساوی";
            this.lbl_n_payment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_e_payment
            // 
            this.lbl_e_payment.AutoSize = true;
            this.lbl_e_payment.Location = new System.Drawing.Point(191, 60);
            this.lbl_e_payment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_e_payment.Name = "lbl_e_payment";
            this.lbl_e_payment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_e_payment.Size = new System.Drawing.Size(56, 20);
            this.lbl_e_payment.TabIndex = 3;
            this.lbl_e_payment.Text = "قسط مساوی";
            this.lbl_e_payment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_date
            // 
            this.lbl_date.AutoSize = true;
            this.lbl_date.Location = new System.Drawing.Point(438, 23);
            this.lbl_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_date.Size = new System.Drawing.Size(75, 20);
            this.lbl_date.TabIndex = 0;
            this.lbl_date.Text = "تاریخ اولین قسط";
            this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(191, 26);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_count.Size = new System.Drawing.Size(56, 20);
            this.lbl_count.TabIndex = 1;
            this.lbl_count.Text = "تعداد اقساط";
            this.lbl_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_update.Font = new System.Drawing.Font("B Titr", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_update.Image = ((System.Drawing.Image)(resources.GetObject("btn_update.Image")));
            this.btn_update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_update.Location = new System.Drawing.Point(10, 10);
            this.btn_update.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(518, 47);
            this.btn_update.TabIndex = 12;
            this.btn_update.Text = "به روز رسانی";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // dgvLoan_payment
            // 
            this.dgvLoan_payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoan_payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoan_payment.Location = new System.Drawing.Point(10, 10);
            this.dgvLoan_payment.Name = "dgvLoan_payment";
            this.dgvLoan_payment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvLoan_payment.Size = new System.Drawing.Size(518, 349);
            this.dgvLoan_payment.TabIndex = 11;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(7, 95);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(241, 45);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "تعریف اقساط";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(542, 619);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxt_first_payment_date);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.lbl_count);
            this.groupBox1.Controls.Add(this.lbl_date);
            this.groupBox1.Controls.Add(this.lbl_e_payment);
            this.groupBox1.Controls.Add(this.txt_month_between);
            this.groupBox1.Controls.Add(this.lbl_n_payment);
            this.groupBox1.Controls.Add(this.lbl_month);
            this.groupBox1.Controls.Add(this.txt_payment_count);
            this.groupBox1.Controls.Add(this.txt_equal_payment);
            this.groupBox1.Controls.Add(this.txt_nonequal_payment);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvLoan_payment);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_update);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(542, 448);
            this.splitContainer2.SplitterDistance = 373;
            this.splitContainer2.TabIndex = 0;
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 619);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form13";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جزییات اقساط";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form13_FormClosing);
            this.Load += new System.EventHandler(this.Form13_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan_payment)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_month_between;
        private System.Windows.Forms.Label lbl_month;
        private System.Windows.Forms.MaskedTextBox mtxt_first_payment_date;
        private System.Windows.Forms.TextBox txt_nonequal_payment;
        private System.Windows.Forms.TextBox txt_equal_payment;
        private System.Windows.Forms.TextBox txt_payment_count;
        private System.Windows.Forms.Label lbl_n_payment;
        private System.Windows.Forms.Label lbl_e_payment;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridView dgvLoan_payment;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}