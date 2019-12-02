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

        [HttpPost]
        public ActionResult<Friendship> Create(Friendship friendship)
        {

            _friendshipService.Create(friendship);

            return CreatedAtRoute("GetFriendship", new { id = friendship.Id.ToString() }, friendship);
        }
    }
}
