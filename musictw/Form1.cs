using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicTw.DAL;
using MusicTw.BLL;

namespace musictw
{
    public partial class Form1 : Form
    {
        loginpage loginControl = new loginpage();
        signuppage signupControl = new signuppage();
        profilepage profilepage = new profilepage();
        AnaSayfa anasayfa = new AnaSayfa();
        Secenekler secenekler = new Secenekler();
        GonderiOLusturmaSayfa gonderiOlusturmaSayfa = new GonderiOLusturmaSayfa();
        public Form1()
        {
            InitializeComponent();
            signupControl.GirisYapLinkineTiklandi += GirisYapTiklandi;
            panel3.Controls.Add(loginControl);
            signupControl.Visible = false;
            loginControl.KayitOlLinkineTiklandi += OnKayitOlTiklandi;
            panel3.Controls.Add(signupControl);
            loginControl.Visible = true;
            panel5.Visible = false;
            profilepage.Visible = false;
            loginControl.GirisBasarili += OnGirisBasarili;
            secenekler.ProfileTiklandi += OnProfilTiklandi;
            panel4.Controls.Add(secenekler);
            secenekler.Visible = false;
            profilepage.CikisYapildi += OnCikisBasarili;
            secenekler.AnasayfaTiklandi += OnAnaSayfaTiklandi;
            secenekler.GonderiOlusturTiklandi += OnGonderiSayfaTiklandi;
            gonderiOlusturmaSayfa.GonderiPaylasildi += OnGonderiPaylasildi;




            // signupControl için de "Giriş Yap" linkine tıklama olayı eklenebilir.

            // 5. Başlangıçta hangisinin görüneceğini ayarla.
            // Sadece login ekranı görünsün, signup ekranı gizli kalsın.

        }

        // loginpage "bana tıklandı" diye bağırdığında bu metot çalışır.
        private void OnKayitOlTiklandi(object sender, EventArgs e)
        {
            // Sahnedeki dekorları değiştiriyoruz:
            // Login dekorunu gizle, signup dekorunu göster.
            
            loginControl.Visible = false;
            signupControl.Visible = true;
            signupControl.BringToFront();
        }
        private void GirisYapTiklandi(object sender, EventArgs e)
        {
            // Sahnedeki dekorları değiştiriyoruz:
            // Signup dekorunu gizle, login dekorunu göster.
            
            signupControl.Visible = false;
            loginControl.Visible = true;
            loginControl.BringToFront();
        }
        private void OnCikisBasarili(object sender, EventArgs e)
        {
            AktifOturum.OturumKapat();
            profilepage.Visible = false;
            profilepage.SendToBack();
            loginControl.Visible = true;
            loginControl.BringToFront();
            secenekler.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;
            label1.Visible = true;
            anasayfa.Visible = false;
            

            MessageBox.Show("Başarıyla çıkış yapıldı.");
        }
        private void OnGirisBasarili(object sender, Users kullanici)
        {
          
            AktifOturum.OturumAc(kullanici);
            MessageBox.Show("Hoş geldiniz " + kullanici.username + ", uzun zaman oldu. ");
            string aktifkullaniciAdi = AktifOturum.aktifKullanici.username;
            string biyografi = AktifOturum.aktifKullanici.biyografi;
            loginControl.Visible = false;
            label1.Visible = false;
            panel5.Controls.Add(anasayfa);
            anasayfa.Visible = true;
            panel5.Visible = true;
            panel3.Visible = false;
            anasayfa.BringToFront();
            secenekler.Visible = true;

            //profilepage.BringToFront();
            //profilepage.ProfiliYukle(kullanici);
        }
        private void OnProfilTiklandi(object sender, Users kullanici)
        {
            panel5.Controls.Add(profilepage);
            profilepage.ProfiliYukle(kullanici);
            profilepage.Visible = true;
            profilepage.BringToFront();
            
        }
        private void OnGonderiSayfaTiklandi(object sender, EventArgs e)
        {
            panel5.Controls.Add(new GonderiOLusturmaSayfa());
            
            panel5.Controls.Clear(); // Önceki kontrolleri temizle
            panel5.Controls.Add(gonderiOlusturmaSayfa); // Yeni kullanıcı kontrolünü ekle
            gonderiOlusturmaSayfa.Visible = true;
            gonderiOlusturmaSayfa.BringToFront();
        }
        private void OnAnaSayfaTiklandi(object sender, EventArgs e)
        {
            panel5.Controls.Add(anasayfa);
            anasayfa.Visible = true;
            anasayfa.BringToFront();
        }
        private void OnGonderiPaylasildi(object sender, EventArgs e)
        {
            
            anasayfa.GonderiyiYukle();
        }
    }
}
