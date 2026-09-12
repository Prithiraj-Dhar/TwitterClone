using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TwitterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = new List<Tweet>
            {
                new Tweet("Hello World!")
                {
                    UserId = Guid.NewGuid(), Content = "Hello World!"
                },
                new Tweet("This is a tweet.")
                {
                    UserId = Guid.NewGuid(), Content = "This is a tweet."
                }
                
            };
            
            return Ok(tweets);
        }
    }
}
