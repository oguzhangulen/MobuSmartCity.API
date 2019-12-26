using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobuSmartCity.API.Data;
using MobuSmartCity.API.Models;

namespace MobuSmartCity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        //TO DO: Controller async çalışabilir.
        private IAppRepository _appRepository;
        public EventController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public IActionResult GetEvents()
        {
            var events = _appRepository.GetEvents();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var @event = _appRepository.GetEventById(id);
            return Ok(@event);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody]Event @event)
        {
            _appRepository.Add(@event);
            if (_appRepository.Save())
                return StatusCode(201);
            return BadRequest("Could not add the Event");
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody]Event @event)
        {
            _appRepository.Update(@event);
            if (_appRepository.Save())
            {
                return StatusCode(200);
            }
            return BadRequest("Could not update the event");
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody]Event @event)
        {
            _appRepository.Delete(@event);
            if (_appRepository.Save())
            {
                return StatusCode(200);
            }
            return BadRequest("Could not delete the Event");
        }
    }
}