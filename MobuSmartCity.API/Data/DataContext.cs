using Microsoft.EntityFrameworkCore;
using MobuSmartCity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Solution> Solution { get; set; }
    }
}
