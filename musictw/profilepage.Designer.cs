namespace musictw
{
    partial class profilepage
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
            this.profilAd = new System.Windows.Forms.Label();
            this.takipciLabel = new System.Windows.Forms.Label();
            this.takipLabel = new System.Windows.Forms.Label();
            this.takipciSayiLabel = new System.Windows.Forms.Label();
            this.takipSayiLabel = new System.Windows.Forms.Label();
            this.lblBiyografi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cikisBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // profilAd
            // 
            this.profilAd.AutoSize = true;
            this.profilAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.profilAd.Location = new System.Drawing.Point(239, 40);
            this.profilAd.Name = "profilAd";
            this.profilAd.Size = new System.Drawing.Size(92, 32);
            this.profilAd.TabIndex = 1;
            this.profilAd.Text = "label1";
            // 
            // takipciLabel
            // 
            this.takipciLabel.AutoSize = true;
            this.takipciLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.takipciLabel.Location = new System.Drawing.Point(531, 80);
            this.takipciLabel.Name = "takipciLabel";
            this.takipciLabel.Size = new System.Drawing.Size(57, 20);
            this.takipciLabel.TabIndex = 2;
            this.takipciLabel.Text = "takipçi";
            // 
            // takipLabel
            // 
            this.takipLabel.AutoSize = true;
            this.takipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.takipLabel.Location = new System.Drawing.Point(631, 80);
            this.takipLabel.Name = "takipLabel";
            this.takipLabel.Size = new System.Drawing.Size(44, 20);
            this.takipLabel.TabIndex = 3;
            this.takipLabel.Text = "takip";
            // 
            // takipciSayiLabel
            // 
            this.takipciSayiLabel.AutoSize = true;
            this.takipciSayiLabel.Location = new System.Drawing.Point(532, 53);
            this.takipciSayiLabel.Name = "takipciSayiLabel";
            this.takipciSayiLabel.Size = new System.Drawing.Size(44, 16);
            this.takipciSayiLabel.TabIndex = 4;
            this.takipciSayiLabel.Text = "label1";
            // 
            // takipSayiLabel
            // 
            this.takipSayiLabel.AutoSize = true;
            this.takipSayiLabel.Location = new System.Drawing.Point(632, 53);
            this.takipSayiLabel.Name = "takipSayiLabel";
            this.takipSayiLabel.Size = new System.Drawing.Size(44, 16);
            this.takipSayiLabel.TabIndex = 5;
            this.takipSayiLabel.Text = "label1";
            // 
            // lblBiyografi
            // 
            this.lblBiyografi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBiyografi.Location = new System.Drawing.Point(242, 81);
            this.lblBiyografi.Name = "lblBiyografi";
            this.lblBiyografi.Size = new System.Drawing.Size(228, 126);
            this.lblBiyografi.TabIndex = 9;
            this.lblBiyografi.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(245, 191);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 189);
            this.textBox1.TabIndex = 11;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(680, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 106);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(145, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 65);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cikisBtn
            // 
            this.cikisBtn.Location = new System.Drawing.Point(739, 40);
            this.cikisBtn.Name = "cikisBtn";
            this.cikisBtn.Size = new System.Drawing.Size(98, 32);
            this.cikisBtn.TabIndex = 13;
            this.cikisBtn.Text = "Çıkış";
            this.cikisBtn.UseVisualStyleBackColor = true;
            this.cikisBtn.Click += new System.EventHandler(this.cikisBtn_Click);
            // 
            // profilepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.cikisBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblBiyografi);
            this.Controls.Add(this.takipSayiLabel);
            this.Controls.Add(this.takipciSayiLabel);
            this.Controls.Add(this.takipLabel);
            this.Controls.Add(this.takipciLabel);
            this.Controls.Add(this.profilAd);
            this.Controls.Add(this.pictureBox1);
            this.Name = "profilepage";
            this.Size = new System.Drawing.Size(864, 649);
            this.Load += new System.EventHandler(this.profilepage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label profilAd;
        public System.Windows.Forms.Label takipciLabel;
        public System.Windows.Forms.Label takipLabel;
        private System.Windows.Forms.Label takipciSayiLabel;
        private System.Windows.Forms.Label takipSayiLabel;
        private System.Windows.Forms.Label lblBiyografi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cikisBtn;
    }
}
