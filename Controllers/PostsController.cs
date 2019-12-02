using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Collections.Generic;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly PostService _postService;

        public PostsController(PostService postService, AuthService authService)
        {
            _postService = postService;
            _authService = authService;
        }
        
        [HttpGet("UserId/{id:length(24)}")]
        public ActionResult<List<string>> GetWithUserId(string id)
        {
            var posts = _postService.GetFromAuthors(new List<string>{id});

            return posts;
        }
        
        [HttpGet("{id:length(24)}", Name = "GetPost")]
        public ActionResult<Post> Get(string id)
        {
            var post = _postService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Post> Create(Post post)
        {
            var userId = _authService.GetIdentity(HttpContext);
            post.UserId = userId;
            post.CreateTime = DateTime.Now;
            _postService.Create(post);

            return CreatedAtRoute("GetPost", new { id = post.Id.ToString() }, post);
        }
    }
}
