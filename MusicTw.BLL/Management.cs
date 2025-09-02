using MusicTw.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MusicTw.BLL
{
    public class Management
    {
        public void kullaniciEkle(Users newUser)
        {
            
            using (var context = new MusicContext())
            {
                var user = context.Users.Any(u => u.username == newUser.username);
                if (user)
                {
                    throw new Exception("Bu kullanıcı adı zaten alınmış");
                    
                }
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
        public Users giris(string kullaniciadi, string password)
        {
            using (var context = new MusicContext())
            {
                var user = context.Users.FirstOrDefault(u => u.username == kullaniciadi && u.passhash == password);
                if(user == null)
                {
                    throw new UnauthorizedAccessException("Kullanıcı adı veya şifre yanlış");
                }
                return user;
            }
        }
        public void GonderiEkle(Gonderiler yeniGonderi)
        {
            using (var context = new MusicContext())
            {
                var gonderidetay = from g in context.Gonderiler
                                   join u in context.Users on g.KullaniciID equals u.userid
                                   select new GonderiAtanAdi
                                   {
                                       ismi = u.username
                                   };
                context.Gonderiler.Add(yeniGonderi);
                context.SaveChanges();
            }            
        }
        //gönderi tarihine göre sıralayıp en son atılan tek gönderiyi getiren metot
        public Gonderiler SonGonderiyiGetir()
        {
            using (var context = new MusicContext())
            {
                // Bu sorgu, Gonderiler tablosunu Users tablosuyla birleştirir,
                // tarihe göre sıralar ve en üstteki tek kaydı getirir.
                var sonGonderi = context.Gonderiler
                                      .Include("Kullanici") // Kullanici bilgilerini de dahil et.
                                      .OrderByDescending(g => g.GonderiTarihi) // Tarihe göre tersten sırala.
                                      .FirstOrDefault(); // Sıralanmış listenin en başındaki ilkini al.

                return sonGonderi;
            }
        }
        

    }

}
