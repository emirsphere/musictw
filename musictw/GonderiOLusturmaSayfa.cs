using MusicTw.BLL;
using MusicTw.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace musictw
{
    public partial class GonderiOLusturmaSayfa : UserControl
    {
        public GonderiOLusturmaSayfa()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public event EventHandler GonderiPaylasildi;
        private void paylasBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string icerik = gonderiRichTxt.Text;
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
                GonderiPaylasildi?.Invoke(this, EventArgs.Empty);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GonderiOLusturmaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
