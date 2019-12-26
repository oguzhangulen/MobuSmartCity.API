using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int CityId { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsAuthorized { get; set; }

        public City City { get; set; }
    }
}
