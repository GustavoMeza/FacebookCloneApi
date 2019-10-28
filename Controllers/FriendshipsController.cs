using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FriendshipsController : ControllerBase
    {
        private readonly FriendshipService _friendshipService;

        public FriendshipsController(FriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpGet]
        public ActionResult<List<Friendship>> Get() =>
            _friendshipService.Get();

        [HttpGet("{id:length(24)}", Name = "GetFriendship")]
        public ActionResult<Friendship> Get(string id)
        {
            var friendship = _friendshipService.Get(id);

            if (friendship == null)
            {
                return NotFound();
            }

            return friendship;
        }

        [HttpPost]
        public ActionResult<Friendship> Create(Friendship friendship)
        {
            _friendshipService.Create(friendship);

            return CreatedAtRoute("GetFriendship", new { id = friendship.Id.ToString() }, friendship);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Friendship friendshipIn)
        {
            var friendship = _friendshipService.Get(id);

            if (friendship == null)
            {
                return NotFound();
            }

            _friendshipService.Update(id, friendshipIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var friendship = _friendshipService.Get(id);

            if (friendship == null)
            {
                return NotFound();
            }

            _friendshipService.Remove(friendship.Id);

            return NoContent();
        }
    }
}
