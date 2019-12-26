using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Models
{
    public class Solution
    {
        public int Id { get; set; }
        public DateTime SolutionDate { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public bool IsSolution { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }
    }
}
