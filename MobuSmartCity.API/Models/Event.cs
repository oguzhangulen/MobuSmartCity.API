﻿using System;
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
            //Solution = new Solution();
            //User = new User();
            //City = new City();
        }

        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public long Up { get; set; }

        public City City { get; set; }
        public Solution Solution { get; set; }
        public User User { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
