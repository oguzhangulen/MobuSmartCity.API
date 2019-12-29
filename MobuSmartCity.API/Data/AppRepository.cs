using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MobuSmartCity.API.Models;

namespace MobuSmartCity.API.Data
{
    //TO DO: Fonksiyonlar Asenkron çalışacak
    public class AppRepository : IAppRepository
    {
        private DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public List<City> GetCities()
        {
            return _context.City.ToList();
        }

        public City GetCityById(int cityId)
        {
            return _context.City.FirstOrDefault(s => s.Id == cityId);
        }

        public List<Comments> GetComments()
        {
            return _context.Comments
                .ToList();
        }

        public Comments GetCommentsById(int commentId)
        {
            var temp = _context.Comments
                .FirstOrDefault(s => s.Id == commentId);

            temp.User = _context.User.Where(s => s.Id == temp.UserId).FirstOrDefault();
            return temp;
        }

        public Event GetEventById(int eventId)
        {
            var temp = _context.Event
                .Include(s => s.Solution)
                .Include(s => s.Comments)
                .FirstOrDefault(s => s.Id == eventId);

            temp.User = _context.User.Where(s => s.Id == temp.UserId).FirstOrDefault();
            temp.City = GetCityById(temp.CityId);
            return temp;
        }

        public List<Event> GetEvents()
        {
            var temp = _context.Event
                .Include(s => s.Solution)
                .Include(s => s.Comments)
                .ToList();
            foreach (var item in temp)
            {
                item.User = _context.User.Where(s => s.Id == item.UserId).FirstOrDefault();
                item.City = GetCityById(item.CityId);
            }
            return temp;

        }

        public Solution GetSolutionById(int solutionId)
        {
            return _context.Solution
                .FirstOrDefault(s => s.Id == solutionId);
        }

        public List<Solution> GetSolutions()
        {
            return _context.Solution
                .ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
