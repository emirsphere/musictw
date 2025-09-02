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
    public partial class Secenekler : UserControl
    {
        public Secenekler()
        {
            InitializeComponent();
            panel1.Controls.Add(gonderiOlusturBtn);
            panel1.Controls.Add(profilBtn);
            panel1.Controls.Add(anasayfaBtn);
            panel1.Controls.Add(gonderiOlusturLbl);
            panel1.Controls.Add(profilimLbl);
            panel1.Controls.Add(anasayLbl);
            profilimLbl.Visible = false;
            gonderiOlusturLbl.Visible = false;
            profilimLbl.Visible = false;
            anasayLbl.Visible = true;
            anasayfaBtn.Location = new Point(242, 3);
            anasayLbl.Location = new Point(301, 16);
            gonderiOlusturBtn.Location = new Point(434, 3);
            gonderiOlusturLbl.Visible = false;
            profilBtn.Location = new Point(485, 3);


        }
        public event EventHandler AnasayfaTiklandi;
        private void anasayfaBtn_Click(object sender, EventArgs e)
        {
            AnasayfaTiklandi?.Invoke(this, EventArgs.Empty);
            profilimLbl.Visible = false;
            anasayLbl.Visible = true;
            anasayfaBtn.Location = new Point(242, 3);
            anasayLbl.Location = new Point(301, 16);
            gonderiOlusturBtn.Location = new Point(434, 3);
            gonderiOlusturLbl.Visible = false;
            profilBtn.Location = new Point(485, 3);
        }
        public event EventHandler GonderiOlusturTiklandi;
        private void gonderiOlusturBtn_Click(object sender, EventArgs e)
        {
            GonderiOlusturTiklandi?.Invoke(this, EventArgs.Empty);
            profilimLbl.Visible = false;
            gonderiOlusturLbl.Visible = true;
            gonderiOlusturBtn.Location = new Point(290, 2);
            gonderiOlusturLbl.Location = new Point(352, 18);
            anasayfaBtn.Location = new Point(242, 3);
            anasayLbl.Visible = false;
            profilBtn.Location = new Point(541, 3);
        }
        public event EventHandler<Users> ProfileTiklandi;
        private void profilBtn_Click(object sender, EventArgs e)
        {
            ProfileTiklandi?.Invoke(this, AktifOturum.aktifKullanici);
            anasayLbl.Visible = false;
            profilimLbl.Visible = true;
            gonderiOlusturLbl.Visible = false;
            anasayLbl.Visible = false;
            gonderiOlusturBtn.Location = new Point(391, 3);
            anasayfaBtn.Location = new Point(340, 3);
            profilimLbl.Visible = true;
            profilBtn.Location = new Point(442, 3);
            profilimLbl.Location = new Point(501, 18);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gonderiOlusturLbl_Click(object sender, EventArgs e)
        {

        }

        private void anasayLbl_Click(object sender, EventArgs e)
        {

        }

        private void profilimLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
