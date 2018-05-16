namespace Pey4
{
    partial class Form21
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form21));
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(12, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(627, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "پردازش";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 95);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(627, 27);
            this.progressBar1.TabIndex = 6;
            // 
            // maskedTextBox5
            // 
            this.maskedTextBox5.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold);
            this.maskedTextBox5.Location = new System.Drawing.Point(426, 9);
            this.maskedTextBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maskedTextBox5.Mask = "1300/00/00";
            this.maskedTextBox5.Name = "maskedTextBox5";
            this.maskedTextBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBox5.Size = new System.Drawing.Size(120, 27);
            this.maskedTextBox5.TabIndex = 276;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold);
            this.label43.Location = new System.Drawing.Point(554, 9);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(89, 27);
            this.label43.TabIndex = 277;
            this.label43.Text = "تاریخ ثبت روزنامه";
            // 
            // Form21
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 130);
            this.Controls.Add(this.maskedTextBox5);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form21";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form21_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox5;
        private System.Windows.Forms.Label label43;
    }
}