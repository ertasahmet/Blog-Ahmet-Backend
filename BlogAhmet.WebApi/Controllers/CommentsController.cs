using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogAhmet.Business.Abstract;
using BlogAhmet.Entities.Concrete;

namespace BlogAhmet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        private ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentService.GetAll();
        }


        [HttpGet("{id}")]
        public Comment Get(int id)
        {

            return _commentService.Get(id);

        }

        [HttpGet]
        [Route("content/{commentcontent}")]
        public IEnumerable<Comment> GetCommentsByContent(string commentcontent)
        {

             return _commentService.GetCommentsByContent(commentcontent);

        }

        [HttpGet]
        [Route("content/not/{commentcontent}")]
        public IEnumerable<Comment> GetCommentsByContentNotConfirmation(string commentcontent)
        {

            return _commentService.GetCommentsByContentNotConfirmation(commentcontent);
        }

        [HttpGet]
        [Route("article/{articleid}")]
        public IEnumerable<Comment> GetCommentsByArticle(int articleid)
        {

            return _commentService.GetCommentsByArticle(articleid);
        }


        [HttpGet]
        [Route("confirmation/{confirmationid}")]
        public IEnumerable<Comment> GetCommentsByConfirmation(int confirmationid)
        {
            if (confirmationid == 1)
            {
                return _commentService.GetCommentsByConfirmation();
            }

            return _commentService.GetCommentsByNotConfirmation();

        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {

            try
            {
                _commentService.Add(comment);

                return new StatusCodeResult(201);
            }
            catch (Exception)
            {

            }

            return BadRequest();

        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comment comment)
        {

            try
            {
                comment.CommentId = id;
                _commentService.Update(comment);
                return Ok(comment);
            }
            catch (Exception)
            {

            }

            return BadRequest();

        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                _commentService.Delete(new Comment { CommentId = id });
                return Ok();
            }
            catch (Exception)
            {

            }

            return BadRequest();

        }



        

    }
}