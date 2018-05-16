namespace Pey4
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.lbl_loan = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.lbl_date = new System.Windows.Forms.Label();
            this.txt_loan_code = new System.Windows.Forms.TextBox();
            this.txt_loan_price = new System.Windows.Forms.TextBox();
            this.mtxt_payment_date = new System.Windows.Forms.MaskedTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.dgvLoan = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan)).BeginInit();
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
            // lbl_loan
            // 
            this.lbl_loan.Location = new System.Drawing.Point(415, 31);
            this.lbl_loan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_loan.Name = "lbl_loan";
            this.lbl_loan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_loan.Size = new System.Drawing.Size(81, 20);
            this.lbl_loan.TabIndex = 0;
            this.lbl_loan.Text = "کد وام";
            this.lbl_loan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_price
            // 
            this.lbl_price.Location = new System.Drawing.Point(415, 68);
            this.lbl_price.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_price.Size = new System.Drawing.Size(81, 20);
            this.lbl_price.TabIndex = 1;
            this.lbl_price.Text = "مبلغ وام";
            this.lbl_price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_date
            // 
            this.lbl_date.Location = new System.Drawing.Point(170, 31);
            this.lbl_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_date.Name = "lbl_date";
            this.lbl_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_date.Size = new System.Drawing.Size(81, 20);
            this.lbl_date.TabIndex = 2;
            this.lbl_date.Text = "تاریخ پرداخت وام";
            this.lbl_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_loan_code
            // 
            this.txt_loan_code.Location = new System.Drawing.Point(259, 28);
            this.txt_loan_code.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_loan_code.Name = "txt_loan_code";
            this.txt_loan_code.Size = new System.Drawing.Size(148, 27);
            this.txt_loan_code.TabIndex = 4;
            this.txt_loan_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loan_code_KeyDown);
            // 
            // txt_loan_price
            // 
            this.txt_loan_price.Location = new System.Drawing.Point(259, 65);
            this.txt_loan_price.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_loan_price.Name = "txt_loan_price";
            this.txt_loan_price.Size = new System.Drawing.Size(148, 27);
            this.txt_loan_price.TabIndex = 5;
            this.txt_loan_price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loan_price_KeyDown);
            // 
            // mtxt_payment_date
            // 
            this.mtxt_payment_date.Location = new System.Drawing.Point(14, 28);
            this.mtxt_payment_date.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mtxt_payment_date.Mask = "1300/00/00";
            this.mtxt_payment_date.Name = "mtxt_payment_date";
            this.mtxt_payment_date.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtxt_payment_date.Size = new System.Drawing.Size(148, 27);
            this.mtxt_payment_date.TabIndex = 6;
            this.mtxt_payment_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxt_payment_date_KeyDown);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(14, 68);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(102, 36);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "تعریف وام";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
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
            this.btn_update.Size = new System.Drawing.Size(534, 43);
            this.btn_update.TabIndex = 10;
            this.btn_update.Text = "به روز رسانی";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // dgvLoan
            // 
            this.dgvLoan.AllowUserToAddRows = false;
            this.dgvLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoan.Location = new System.Drawing.Point(10, 10);
            this.dgvLoan.Name = "dgvLoan";
            this.dgvLoan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvLoan.Size = new System.Drawing.Size(534, 231);
            this.dgvLoan.TabIndex = 9;
            this.dgvLoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoan_CellContentClick);
            this.dgvLoan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoan_CellDoubleClick);
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
            this.splitContainer1.Size = new System.Drawing.Size(558, 468);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxt_payment_date);
            this.groupBox1.Controls.Add(this.lbl_loan);
            this.groupBox1.Controls.Add(this.lbl_price);
            this.groupBox1.Controls.Add(this.lbl_date);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txt_loan_code);
            this.groupBox1.Controls.Add(this.txt_loan_price);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 120);
            this.groupBox1.TabIndex = 12;
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
            this.splitContainer2.Panel1.Controls.Add(this.dgvLoan);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_update);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(558, 326);
            this.splitContainer2.SplitterDistance = 255;
            this.splitContainer2.TabIndex = 0;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 468);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form12";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف وام";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form12_FormClosing);
            this.Load += new System.EventHandler(this.Form12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoan)).EndInit();
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

        private System.Windows.Forms.Label lbl_loan;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.TextBox txt_loan_code;
        private System.Windows.Forms.TextBox txt_loan_price;
        private System.Windows.Forms.MaskedTextBox mtxt_payment_date;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridView dgvLoan;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}