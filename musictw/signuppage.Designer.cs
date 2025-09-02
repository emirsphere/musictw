namespace musictw
{
    partial class signuppage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.newuserBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kullaniciadTxt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.passwordTxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.emailTxt);
            this.groupBox1.Controls.Add(this.newuserBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.kullaniciadTxt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 446);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giriş";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(36, 406);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Zaten bir hesabım var giriş yapmak istiyorum";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            this.label5.MouseEnter += new System.EventHandler(this.label5_MouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(25, 273);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(224, 27);
            this.passwordTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(21, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "email";
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(25, 163);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(224, 27);
            this.emailTxt.TabIndex = 5;
            // 
            // newuserBtn
            // 
            this.newuserBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.newuserBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.newuserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newuserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newuserBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newuserBtn.Location = new System.Drawing.Point(148, 337);
            this.newuserBtn.Name = "newuserBtn";
            this.newuserBtn.Size = new System.Drawing.Size(119, 54);
            this.newuserBtn.TabIndex = 4;
            this.newuserBtn.Text = "Kaydol";
            this.newuserBtn.UseVisualStyleBackColor = false;
            this.newuserBtn.Click += new System.EventHandler(this.newuserBtn_Click);
            this.newuserBtn.MouseEnter += new System.EventHandler(this.newuserBtn_MouseEnter);
            this.newuserBtn.MouseLeave += new System.EventHandler(this.newuserBtn_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(21, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şifre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(21, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı adı";
            // 
            // kullaniciadTxt
            // 
            this.kullaniciadTxt.Location = new System.Drawing.Point(25, 76);
            this.kullaniciadTxt.Name = "kullaniciadTxt";
            this.kullaniciadTxt.Size = new System.Drawing.Size(224, 27);
            this.kullaniciadTxt.TabIndex = 0;
            // 
            // signuppage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "signuppage";
            this.Size = new System.Drawing.Size(440, 446);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Button newuserBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kullaniciadTxt;
    }
}
