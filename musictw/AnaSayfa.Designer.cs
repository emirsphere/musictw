namespace musictw
{
    partial class AnaSayfa
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
            this.anasayfaLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gosterilecekGonderiLbl = new System.Windows.Forms.Label();
            this.gonderiAtanLbl = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // anasayfaLbl
            // 
            this.anasayfaLbl.AutoSize = true;
            this.anasayfaLbl.BackColor = System.Drawing.Color.CadetBlue;
            this.anasayfaLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.anasayfaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anasayfaLbl.ForeColor = System.Drawing.Color.White;
            this.anasayfaLbl.Location = new System.Drawing.Point(3, 13);
            this.anasayfaLbl.Name = "anasayfaLbl";
            this.anasayfaLbl.Size = new System.Drawing.Size(145, 32);
            this.anasayfaLbl.TabIndex = 1;
            this.anasayfaLbl.Text = "Ana Sayfa";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gosterilecekGonderiLbl);
            this.panel2.Controls.Add(this.gonderiAtanLbl);
            this.panel2.Location = new System.Drawing.Point(154, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 573);
            this.panel2.TabIndex = 2;
            // 
            // gosterilecekGonderiLbl
            // 
            this.gosterilecekGonderiLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gosterilecekGonderiLbl.Location = new System.Drawing.Point(55, 83);
            this.gosterilecekGonderiLbl.Name = "gosterilecekGonderiLbl";
            this.gosterilecekGonderiLbl.Size = new System.Drawing.Size(475, 447);
            this.gosterilecekGonderiLbl.TabIndex = 1;
            this.gosterilecekGonderiLbl.Text = "label1";
            // 
            // gonderiAtanLbl
            // 
            this.gonderiAtanLbl.AutoSize = true;
            this.gonderiAtanLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gonderiAtanLbl.Location = new System.Drawing.Point(18, 19);
            this.gonderiAtanLbl.Name = "gonderiAtanLbl";
            this.gonderiAtanLbl.Size = new System.Drawing.Size(79, 29);
            this.gonderiAtanLbl.TabIndex = 0;
            this.gonderiAtanLbl.Text = "label1";
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.anasayfaLbl);
            this.Name = "AnaSayfa";
            this.Size = new System.Drawing.Size(864, 649);
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label anasayfaLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label gonderiAtanLbl;
        private System.Windows.Forms.Label gosterilecekGonderiLbl;
    }
}
