using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void GetTweetLength()
        {
            var MaxTweetLength = _configuration.GetValue<int>("TwitterSettings:MaxLength:TweetContent");
        }

        // /api/users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(new List<object>
            {
                 new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "user1",
                },
                 new
                {
                    UserId = Guid.NewGuid(),
                    UserName = "user1",
                },
            });
        }

        // /api/users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUsers()
        {
            return Ok(new
            {
                UserId = Guid.NewGuid(),
                Username = "newuser",
            });
        }

        // /api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] Guid id)
        {
            return Ok(new
            {
                UserId = id,
                UserName = "user" + id.ToString(),
            });
        }

        // /api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUsers([FromRoute] Guid id)
        {
            return Ok(new {
                UserId = id,
                UserName = "updateduser" + id.ToString(),
            });
        }

        // /api/users/{id}/phoneNumber
        [HttpPatch("{id}/phoneNumber")]
        public IActionResult UpdateUserPhoneNumber([FromRoute] Guid id, [FromBody] string phoneNumber)
        {
            return Ok("hello");
        }


        // /api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUserByID([FromRoute] Guid id)
        {
            return Ok(new
            {
                UserID = id,
                Message = "User deleted successfully.",
            });
        }


    }

  
}
