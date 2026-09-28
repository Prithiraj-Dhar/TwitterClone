using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.DTOs;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly TweetRepository _tweetRepository;
        public TweetsController(TweetRepository tweetRepository) 
        {
            _tweetRepository = tweetRepository;
        }


        // GET /api/tweets?userId={userId}
        [HttpGet]
        public IActionResult GetTweets([FromQuery] Guid? userId)
        {
            var tweet = _tweetRepository.GetTweets();

            return Ok(tweet);
        }

        // GET /api/tweets/{id}
        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetByID(id);

            return Ok(tweet);
        }

        // POST /api/tweets
        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            if (string.IsNullOrWhiteSpace(createTweetDto.content))
            {
                return BadRequest("Content fields are required!");
            }

            var tweet = new Tweet(Guid.NewGuid(), createTweetDto.content); 
            var createdTweet = _tweetRepository.AddTweet(tweet);

            return Ok(createdTweet);
        }

        // PUT /api/tweets/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] CreateTweetDto createTweetDto)
        {
            var tweet = _tweetRepository.GetTweetByID(id);

            if (tweet == null)
            {
                return NotFound();
            }

            tweet.Content = createTweetDto.content;

            _tweetRepository.UpdateTweet(tweet);

            return Ok(tweet);
        }

        // DELETE /api/tweets/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetByID(id);

            if (tweet == null)
            {
                return NotFound();
            }

            var isDeleted = _tweetRepository.DeleteTweet(tweet);

            return Ok(isDeleted);
        }
    }

}


