using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MobuSmartCity.API.Data;

namespace MobuSmartCity.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Solution")]
    public class SolutionController : Controller
    {
        private IAppRepository _appRepository;
        public SolutionController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public IActionResult GetSolution()
        {
            var solutions = _appRepository.GetSolutions();
            return Ok(solutions);
        }
        [HttpGet("{id}")]
        public IActionResult GetSolutionById(int id)
        {
            var solution = _appRepository.GetSolutionById(id);
            return Ok(solution);
        }
        //TO DO: Id gerekebilir.
        [HttpPut("update")]
        public IActionResult Update([FromBody]Solution solution)
        {
            _appRepository.Update(solution);
            if (_appRepository.Save())
                return Ok();
            return BadRequest("Could not updated the solution");
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody]Solution solution)
        {
            _appRepository.Add(solution);
            if (_appRepository.Save())
                return StatusCode(201);
            return BadRequest("Could not added the solution");
        }
        //TO DO: Delete işlemi gerekebilir.
    }
}