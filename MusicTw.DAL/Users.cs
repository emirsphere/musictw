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
    [Table("Users")]
    public class Users
    {
        public string username { get; set; }
        public string passhash { get; set; }
        public string email { get; set; }
        [Key] public int userid { get; set; }
        public SqlDateTime registdate { get; set; }
        public string biyografi { get; set; }

        public virtual ICollection<Gonderiler> Gonderiler { get; set; }// bu kodun şu şekilde çalışır: bir kullanıcının birden fazla gönderisi olabilir
    }
}
