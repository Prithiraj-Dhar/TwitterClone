using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void GetTweetLength()
        {
            var MaxTweetLength = _configuration.GetValue<int>("TwitterSettings:MaxLength:TweetContent");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@gmail.com"
                },
                new User()
                {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Email = "jane@gmail.com"
                },
                new User()
                {
                    FirstName = "Bob",
                    LastName = "Smith",
                    Email = "bob@gmail.com"
                }
            };

            return Ok(users);
        }


    }
}
