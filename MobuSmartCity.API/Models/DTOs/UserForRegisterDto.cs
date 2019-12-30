using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Models.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
