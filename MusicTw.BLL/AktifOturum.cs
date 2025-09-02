using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicTw.DAL;

namespace MusicTw.BLL
{
    public static class AktifOturum
    {
        public static Users aktifKullanici { get; private set; }
        public static void OturumAc(Users kullanici)
        {
            aktifKullanici = kullanici ?? throw new ArgumentNullException("Kullanıcı nesnesi null olamaz");        
        }
        public static void OturumKapat()
        {
            aktifKullanici = null;
        }
    }
}
