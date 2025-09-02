namespace musictw
{
    partial class Secenekler
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.profilBtn = new System.Windows.Forms.Button();
            this.gonderiOlusturLbl = new System.Windows.Forms.Label();
            this.anasayLbl = new System.Windows.Forms.Label();
            this.gonderiOlusturBtn = new System.Windows.Forms.Button();
            this.profilimLbl = new System.Windows.Forms.Label();
            this.anasayfaBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.profilBtn);
            this.panel1.Controls.Add(this.gonderiOlusturLbl);
            this.panel1.Controls.Add(this.anasayLbl);
            this.panel1.Controls.Add(this.gonderiOlusturBtn);
            this.panel1.Controls.Add(this.profilimLbl);
            this.panel1.Controls.Add(this.anasayfaBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 58);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // profilBtn
            // 
            this.profilBtn.BackgroundImage = global::musictw.Properties.Resources.profil_removebg_preview__1_;
            this.profilBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profilBtn.Location = new System.Drawing.Point(442, 3);
            this.profilBtn.Name = "profilBtn";
            this.profilBtn.Size = new System.Drawing.Size(53, 53);
            this.profilBtn.TabIndex = 1;
            this.profilBtn.UseVisualStyleBackColor = true;
            this.profilBtn.Click += new System.EventHandler(this.profilBtn_Click);
            // 
            // gonderiOlusturLbl
            // 
            this.gonderiOlusturLbl.AutoSize = true;
            this.gonderiOlusturLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gonderiOlusturLbl.Location = new System.Drawing.Point(39, 18);
            this.gonderiOlusturLbl.Name = "gonderiOlusturLbl";
            this.gonderiOlusturLbl.Size = new System.Drawing.Size(183, 29);
            this.gonderiOlusturLbl.TabIndex = 5;
            this.gonderiOlusturLbl.Text = "Gönderi Oluştur";
            this.gonderiOlusturLbl.Click += new System.EventHandler(this.gonderiOlusturLbl_Click);
            // 
            // anasayLbl
            // 
            this.anasayLbl.AutoSize = true;
            this.anasayLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anasayLbl.Location = new System.Drawing.Point(722, 18);
            this.anasayLbl.Name = "anasayLbl";
            this.anasayLbl.Size = new System.Drawing.Size(119, 29);
            this.anasayLbl.TabIndex = 2;
            this.anasayLbl.Text = "Ana Sayfa";
            this.anasayLbl.Click += new System.EventHandler(this.anasayLbl_Click);
            // 
            // gonderiOlusturBtn
            // 
            this.gonderiOlusturBtn.BackgroundImage = global::musictw.Properties.Resources.ekleme_removebg_preview;
            this.gonderiOlusturBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gonderiOlusturBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gonderiOlusturBtn.Location = new System.Drawing.Point(391, 3);
            this.gonderiOlusturBtn.Name = "gonderiOlusturBtn";
            this.gonderiOlusturBtn.Size = new System.Drawing.Size(53, 53);
            this.gonderiOlusturBtn.TabIndex = 4;
            this.gonderiOlusturBtn.UseVisualStyleBackColor = true;
            this.gonderiOlusturBtn.Click += new System.EventHandler(this.gonderiOlusturBtn_Click);
            // 
            // profilimLbl
            // 
            this.profilimLbl.AutoSize = true;
            this.profilimLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.profilimLbl.Location = new System.Drawing.Point(501, 18);
            this.profilimLbl.Name = "profilimLbl";
            this.profilimLbl.Size = new System.Drawing.Size(95, 29);
            this.profilimLbl.TabIndex = 3;
            this.profilimLbl.Text = "Profilim";
            this.profilimLbl.Click += new System.EventHandler(this.profilimLbl_Click);
            // 
            // anasayfaBtn
            // 
            this.anasayfaBtn.BackgroundImage = global::musictw.Properties.Resources.images_removebg_preview;
            this.anasayfaBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.anasayfaBtn.Location = new System.Drawing.Point(340, 3);
            this.anasayfaBtn.Name = "anasayfaBtn";
            this.anasayfaBtn.Size = new System.Drawing.Size(53, 53);
            this.anasayfaBtn.TabIndex = 0;
            this.anasayfaBtn.UseVisualStyleBackColor = true;
            this.anasayfaBtn.Click += new System.EventHandler(this.anasayfaBtn_Click);
            // 
            // Secenekler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Secenekler";
            this.Size = new System.Drawing.Size(852, 58);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button profilBtn;
        private System.Windows.Forms.Label gonderiOlusturLbl;
        private System.Windows.Forms.Label anasayLbl;
        private System.Windows.Forms.Button gonderiOlusturBtn;
        private System.Windows.Forms.Label profilimLbl;
        private System.Windows.Forms.Button anasayfaBtn;
    }
}
