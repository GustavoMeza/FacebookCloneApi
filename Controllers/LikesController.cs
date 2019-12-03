using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly LikeService _likeService;

        public LikesController(LikeService likeService, AuthService authService)
        {
            _authService = authService;
            _likeService = likeService;
        }
        
        [HttpGet("forPost/{id:length(24)}", Name="GetLike")]
        public ActionResult<List<string>> GetForPostId(string id) => 
            _likeService.GetWithPostId(id);

        [HttpPost]
        [Authorize]
        public ActionResult<Like> Create(Like like)
        {
            var userId = _authService.GetIdentity(HttpContext);

            like.UserId = userId;

            if(_likeService.IsDuplicate(like)) {
                return NotFound();
            }

            _likeService.Create(like);

            return CreatedAtRoute("GetLike", new { id = like.Id.ToString() }, like);
        }
    }
}
