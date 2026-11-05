using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        TweetDto? CreateTweet(CreateTweetDto createTweetDto);
        TweetDto? GetTweetById(Guid id);
        TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto);
        bool DeleteTweet(Guid id);
        List<TweetDto> GetTweets(Guid? UserId);
    }
}
