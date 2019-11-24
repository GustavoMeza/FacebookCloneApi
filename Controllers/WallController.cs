using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WallController : ControllerBase
    {
        private readonly PostService _postService;
        private readonly FriendshipService _friendshipService;

        public WallController(PostService postService, FriendshipService friendshipService)
        {
            _postService = postService;
            _friendshipService = friendshipService;
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<List<string>> Get(string id)
        {
            var friends = _friendshipService.GetFriendsOf(id); 
            friends.Add(id);
            var posts = _postService.GetFromAuthors(friends);

            return posts;
        }
    }
}
