using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MusicTw.DAL
{
    public class MusicContext : DbContext
    {
        public MusicContext() : base("name=MusicContext")
        {
            Database.SetInitializer<MusicContext>(null);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Gonderiler> Gonderiler { get; set; }
    }
}