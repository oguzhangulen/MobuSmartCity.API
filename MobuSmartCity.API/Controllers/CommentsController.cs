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
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private IAppRepository _appRepository;
        public CommentsController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public IActionResult GetComments()
        {
            var comments = _appRepository.GetComments();
            return Ok(comments);
        }
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int commentId)
        {
            var comment = _appRepository.GetCommentsById(commentId);
            return Ok(comment);
        }
        [HttpPost("add")]
        public IActionResult AddComment([FromBody]Comments comment)
        {
            _appRepository.Add(comment);
            if (_appRepository.Save())
            {
                return Ok(comment);
            }
            return BadRequest("Could not add the comment");
        }
        [HttpPost("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = GetCommentById(id);
            _appRepository.Delete(comment);
            if(_appRepository.Save())
            {
                return Ok();
            }
            return BadRequest("Could not delete the comment");
        }
    }
}