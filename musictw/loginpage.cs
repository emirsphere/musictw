using MusicTw.BLL;
using MusicTw.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace musictw
{
    public partial class loginpage : UserControl
    {
        
        public loginpage()
        {
            InitializeComponent();
        }
        
        public event EventHandler KayitOlLinkineTiklandi;
        private void label6_Click(object sender, EventArgs e)
        {
            KayitOlLinkineTiklandi?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler<Users> GirisBasarili;
        private void grsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciadi = girisadTxt.Text;
                string password = girissifreTxt.Text;
                Management management = new Management();
                Users girisyapankullanici = management.giris(kullaniciadi, password);
                if (girisyapankullanici == null || kullaniciadi == null)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                    return;
                }

                GirisBasarili?.Invoke(this, girisyapankullanici);//bu kodun çalışma mantığı: eğer GirisBasarili olayına abone olunmuşsa, bu olayı tetikle ve girisyapankullanici nesnesini olaya ilet.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş yapılırken bir hata oluştu: " + ex.Message);
                return;
            }
        }
      
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(68, 68, 68);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }
    }
}
