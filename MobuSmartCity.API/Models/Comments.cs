using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
