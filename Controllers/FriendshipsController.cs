using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FriendshipsController : ControllerBase
    {
        private readonly FriendshipService _friendshipService;
        private readonly AuthService _authService;

        public FriendshipsController(FriendshipService friendshipService, AuthService authService)
        {
            _friendshipService = friendshipService;
            _authService = authService;
        }

        [HttpPost(Name="GetFriendship")]
        [Authorize]
        public ActionResult<Friendship> Create(Friendship friendship)
        {
            var userId = _authService.GetIdentity(HttpContext);
            if(userId != friendship.UserAId && userId != friendship.UserBId) {
                return Unauthorized();
            }
            if(friendship.UserAId == friendship.UserBId) {
                return ValidationProblem("Self friendship is not allowed");
            }
            if(_friendshipService.IsDuplicate(friendship)) {
                return ValidationProblem("Friendship duplicate");
            }

            _friendshipService.Create(friendship);

            return CreatedAtRoute("GetFriendship", new { id = friendship.Id.ToString() }, friendship);
        }
    }
}
