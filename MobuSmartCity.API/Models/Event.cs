using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Models
{
    public class Event
    {
        public Event()
        {
            Comments = new List<Comments>();
        }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        [ForeignKey("Solution")]
        public int SolutionId { get; set; }
        public int CityId { get; set; }
        public long Up { get; set; }

        public City City { get; set; }
        public Solution Solution { get; set; }
        public User User { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
