using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly LikeService _likeService;

        public LikesController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public ActionResult<List<Like>> Get() =>
            _likeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetLike")]
        public ActionResult<Like> Get(string id)
        {
            var like = _likeService.Get(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }
        
        [HttpGet("forPost/{id:length(24)}")]
        public ActionResult<List<string>> GetForPostId(string id) => 
            _likeService.GetWithPostId(id);

        [HttpPost]
        public ActionResult<Like> Create(Like like)
        {
            if(_likeService.IsDuplicate(like)) {
                return NotFound();
            }

            _likeService.Create(like);

            return CreatedAtRoute("GetLike", new { id = like.Id.ToString() }, like);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Like likeIn)
        {
            var like = _likeService.Get(id);

            if (like == null)
            {
                return NotFound();
            }

            _likeService.Update(id, likeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var like = _likeService.Get(id);

            if (like == null)
            {
                return NotFound();
            }

            _likeService.Remove(like.Id);

            return NoContent();
        }
    }
}
