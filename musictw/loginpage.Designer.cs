namespace musictw
{
    partial class loginpage
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.girissifreTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.girisadTxt = new System.Windows.Forms.TextBox();
            this.grsBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.girissifreTxt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.girisadTxt);
            this.groupBox2.Controls.Add(this.grsBtn);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(440, 446);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giriş";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(46, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kullanıcı adı veya email";
            // 
            // girissifreTxt
            // 
            this.girissifreTxt.Location = new System.Drawing.Point(53, 221);
            this.girissifreTxt.Name = "girissifreTxt";
            this.girissifreTxt.Size = new System.Drawing.Size(224, 27);
            this.girissifreTxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(46, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Şifre";
            // 
            // girisadTxt
            // 
            this.girisadTxt.Location = new System.Drawing.Point(53, 134);
            this.girisadTxt.Name = "girisadTxt";
            this.girisadTxt.Size = new System.Drawing.Size(224, 27);
            this.girisadTxt.TabIndex = 9;
            // 
            // grsBtn
            // 
            this.grsBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.grsBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.grsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grsBtn.Location = new System.Drawing.Point(158, 310);
            this.grsBtn.Name = "grsBtn";
            this.grsBtn.Size = new System.Drawing.Size(119, 54);
            this.grsBtn.TabIndex = 14;
            this.grsBtn.Text = "Giriş";
            this.grsBtn.UseVisualStyleBackColor = false;
            this.grsBtn.Click += new System.EventHandler(this.grsBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(102, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Hesap oluşturmak istiyorum";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            this.label6.MouseEnter += new System.EventHandler(this.label6_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.label6_MouseLeave);
            // 
            // loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.groupBox2);
            this.Name = "loginpage";
            this.Size = new System.Drawing.Size(440, 446);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button grsBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox girissifreTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox girisadTxt;
        internal System.Windows.Forms.GroupBox groupBox2;
    }
}
