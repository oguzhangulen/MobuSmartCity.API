using MobuSmartCity.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobuSmartCity.API.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        bool Save();

        List<Comments> GetComments();
        Comments GetCommentsById(int commentId);
        List<Event> GetEvents();
        Event GetEventById(int eventId);
        List<Solution> GetSolutions();
        Solution GetSolutionById(int solutionId);
        List<City> GetCities();
        City GetCityById(int cityId);


    }
}
