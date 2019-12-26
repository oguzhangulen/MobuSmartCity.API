using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobuSmartCity.API.Data;

namespace MobuSmartCity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/City")]
    public class CityController : Controller
    {
        private IAppRepository _appRepository;
        public CityController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public IActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            return Ok(cities);
        }
        [HttpGet("{id}")]
        public IActionResult GetCityById(int cityId)
        {
            var city = _appRepository.GetCityById(cityId);
            return Ok(city);
        }
    }
}