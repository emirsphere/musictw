using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace MusicTw.DAL
{
    [Table("Gonderiler")]
    public class Gonderiler
    {
        [Key] public int GonderiID { get; set; }
        public int KullaniciID { get; set; }
        public string Metin { get; set; }
        public DateTime GonderiTarihi { get; set; } = DateTime.Now;
        [ForeignKey("KullaniciID")]
        public virtual Users Kullanici { get; set; }
    }
}
