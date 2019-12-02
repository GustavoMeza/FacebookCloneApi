using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService, AuthService authService)
        {
            _commentService = commentService;
            _authService = authService;
        }

        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public ActionResult<Comment> Get(string id)
        {
            var comment = _commentService.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpGet("forPost/{id:length(24)}")]
        public ActionResult<List<string>> GetWithPostId(string id) =>
            _commentService.GetWithPostId(id);

        [HttpPost]
        [Authorize]
        public ActionResult<Comment> Create(Comment comment)
        {
            comment.UserId = _authService.GetIdentity(HttpContext);
            comment.CreateTime = DateTime.Now;
            _commentService.Create(comment);

            return CreatedAtRoute("GetComment", new { id = comment.Id.ToString() }, comment);
        }
    }
}
