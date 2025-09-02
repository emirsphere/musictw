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
    public partial class AnaSayfa : UserControl
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        public void GonderiyiYukle()
        {
            Management management = new Management();
            var gosterilecekgonderi = management.SonGonderiyiGetir();
            gosterilecekGonderiLbl.Text = gosterilecekgonderi.Metin;
            gonderiAtanLbl.Text = gosterilecekgonderi.Kullanici.username;

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            Management management = new Management();
            var gosterilecekgonderi = management.SonGonderiyiGetir();
            gosterilecekGonderiLbl.Text = gosterilecekgonderi.Metin;
            gonderiAtanLbl.Text = gosterilecekgonderi.Kullanici.username;
        }
    }
}
