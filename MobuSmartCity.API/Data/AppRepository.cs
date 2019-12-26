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
                .Include(s=>s.User)
                .Include(s=>s.Event)
                .ToList();
        }

        public Comments GetCommentsById(int commentId)
        {
            return _context.Comments
                .Include(s => s.User)
                .FirstOrDefault(a=>a.Id==commentId);
        }

        public Event GetEventById(int eventId)
        {
            return _context.Event
                .Include(s=>s.Comments)
                .Include(s=>s.City)
                .Include(s=>s.Solution)
                .Include(s=>s.User)
                .FirstOrDefault(s => s.Id == eventId);
        }

        public List<Event> GetEvents()
        {
            return _context.Event
                .Include(s => s.Comments)
                .Include(s => s.City)
                .Include(s => s.Solution)
                .Include(s => s.User)
                .ToList();

        }

        public Solution GetSolutionById(int solutionId)
        {
            return _context.Solution
                .Include(s => s.User)
                .Include(s => s.Event)
                .FirstOrDefault(s => s.Id == solutionId);
        }

        public List<Solution> GetSolutions()
        {
            return _context.Solution
                .Include(s => s.User)
                .Include(s => s.Event)
                .ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
