using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WildlifeTracker.Services;

namespace WildlifeTracker.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController(IOnlineUsersService onlineUsers) : ControllerBase
    {
        /// <summary>  
        /// Retrieves the list of online users.  
        /// </summary>  
        /// <remarks>  
        /// This endpoint returns a list of usernames currently marked as online.  
        /// </remarks>  
        /// <returns>A list of online users.</returns>  
        /// <response code="200">Returns the list of online users.</response>  
        [HttpGet("online")]
        public ActionResult GetOnlineUsers()
        {
            return this.Ok(onlineUsers.GetOnlineUsers());
        }
    }
}
