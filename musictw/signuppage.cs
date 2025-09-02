using musictw;
using MusicTw.BLL;
using MusicTw.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace musictw
{
    public partial class signuppage : UserControl
    {
        public signuppage()
        {
            InitializeComponent();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(68, 68, 68);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void newuserBtn_MouseEnter(object sender, EventArgs e)
        {
            newuserBtn.BackColor = Color.FromArgb(62, 95, 95);
        }

        private void newuserBtn_MouseLeave(object sender, EventArgs e)
        {
            newuserBtn.BackColor = Color.DarkSlateGray;
        }

        public event EventHandler GirisYapLinkineTiklandi;
        private void label5_Click(object sender, EventArgs e)
        {
            GirisYapLinkineTiklandi?.Invoke(this, EventArgs.Empty);
        }

        private void newuserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new Users
                {
                    username = kullaniciadTxt.Text,
                    email = emailTxt.Text,
                    passhash = passwordTxt.Text
                };
                if (string.IsNullOrEmpty(newUser.username) || string.IsNullOrEmpty(newUser.email) || string.IsNullOrEmpty(newUser.passhash))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun");
                    return;
                }
                
                Management management = new Management();
                management.kullaniciEkle(newUser);
                MessageBox.Show("Hesabınız başarıyla oluşturuldu");
            }


            catch (Exception ex)
            {
                {
                    MessageBox.Show("Hesap oluşturulurken bir hata oluştu: " + ex.Message);
                    return;
                }
            }
        }
    }
}



