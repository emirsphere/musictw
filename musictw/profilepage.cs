using MusicTw.DAL;
using MusicTw.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace musictw
{
    public partial class profilepage : UserControl
    {
        public profilepage()
        {
            InitializeComponent();
        }

        private void profilepage_Load(object sender, EventArgs e)
        {

        }
        
        public void ProfiliYukle(Users gosterilecekKullanici)
        {
            // Kontrol: Gelen kullanıcı null mu?
            if (gosterilecekKullanici == null) return;

            // UserControl, KENDİ KONTROLLERİNİ KENDİSİ günceller.
            // Form1'in, bu kontrollerin adını veya tipini bilmesine gerek kalmaz.
            this.profilAd.Text = gosterilecekKullanici.username;
            this.lblBiyografi.Text = gosterilecekKullanici.biyografi;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string icerik = textBox1.Text;
                if (string.IsNullOrWhiteSpace(icerik))
                {
                    MessageBox.Show("Gönderi içeriği boş olamaz.");
                    return;
                }
                var yeniGonderi = new Gonderiler()
                {
                    Metin = icerik,
                    KullaniciID = AktifOturum.aktifKullanici.userid

                };
                Management management = new Management();
                management.GonderiEkle(yeniGonderi);
                MessageBox.Show("Gönderiniz başarıyla paylaşıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public event EventHandler CikisYapildi;
        private void cikisBtn_Click(object sender, EventArgs e)
        {
            CikisYapildi?.Invoke(this, EventArgs.Empty);
        }
    }
}
