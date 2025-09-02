namespace musictw
{
    partial class GonderiOLusturmaSayfa
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
            this.gonderiRichTxt = new System.Windows.Forms.RichTextBox();
            this.sarkiAdiTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paylasBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gonderiRichTxt
            // 
            this.gonderiRichTxt.BackColor = System.Drawing.Color.DarkSlateGray;
            this.gonderiRichTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gonderiRichTxt.EnableAutoDragDrop = true;
            this.gonderiRichTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gonderiRichTxt.ForeColor = System.Drawing.Color.Gainsboro;
            this.gonderiRichTxt.Location = new System.Drawing.Point(189, 164);
            this.gonderiRichTxt.Name = "gonderiRichTxt";
            this.gonderiRichTxt.Size = new System.Drawing.Size(480, 304);
            this.gonderiRichTxt.TabIndex = 0;
            this.gonderiRichTxt.Text = "";
            this.gonderiRichTxt.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // sarkiAdiTxt
            // 
            this.sarkiAdiTxt.BackColor = System.Drawing.Color.DarkSlateGray;
            this.sarkiAdiTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sarkiAdiTxt.ForeColor = System.Drawing.Color.Gainsboro;
            this.sarkiAdiTxt.Location = new System.Drawing.Point(189, 117);
            this.sarkiAdiTxt.Name = "sarkiAdiTxt";
            this.sarkiAdiTxt.Size = new System.Drawing.Size(329, 27);
            this.sarkiAdiTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(321, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gönderi Paylaş";
            // 
            // paylasBtn
            // 
            this.paylasBtn.BackColor = System.Drawing.Color.Maroon;
            this.paylasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.paylasBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.paylasBtn.Location = new System.Drawing.Point(373, 492);
            this.paylasBtn.Name = "paylasBtn";
            this.paylasBtn.Size = new System.Drawing.Size(115, 54);
            this.paylasBtn.TabIndex = 3;
            this.paylasBtn.Text = "Paylaş";
            this.paylasBtn.UseVisualStyleBackColor = false;
            this.paylasBtn.Click += new System.EventHandler(this.paylasBtn_Click);
            // 
            // GonderiOLusturmaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.paylasBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sarkiAdiTxt);
            this.Controls.Add(this.gonderiRichTxt);
            this.Name = "GonderiOLusturmaSayfa";
            this.Size = new System.Drawing.Size(864, 649);
            this.Load += new System.EventHandler(this.GonderiOLusturmaSayfa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox gonderiRichTxt;
        private System.Windows.Forms.TextBox sarkiAdiTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button paylasBtn;
    }
}
