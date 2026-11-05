using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IRetweetRepository _retweetRepository;


        public TweetService(
            ITweetRepository tweetRepository,
            IUserRepository userRepository,
            ILikeRepository likeRepository,
            IBookmarkRepository bookmarkRepository,
            IRetweetRepository retweetRepository)
        {
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
            _likeRepository = likeRepository;
            _bookmarkRepository = bookmarkRepository;
            _retweetRepository = retweetRepository;
        }
        public TweetDto? CreateTweet(CreateTweetDto createTweetDto)
        {
            if (!IsValidContent(createTweetDto.content))
            {
                return null;
            }

            var user = _userRepository.GetUserById(createTweetDto.UserId);

            if(user == null)
            {
                return null;
            }

            var createdTweet = _tweetRepository.AddTweet(new Tweet(user.Id, createTweetDto.content.Trim()));

            return createdTweet.ToDto();
        }

        public bool DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if(tweet == null)
            {
                return false;
            }

            // Likes, bookmarks and retweets can't outlive the tweet they point at.
            _likeRepository.DeleteLikesByTweetId(id);
            _bookmarkRepository.DeleteBookmarksByTweetId(id);
            _retweetRepository.DeleteRetweetsByTweetId(id);

            return _tweetRepository.DeleteTweet(tweet);

        }

        public TweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            return tweet?.ToDto();
        }

        public List<TweetDto> GetTweets(Guid? UserId)
        {
            var tweets = UserId.HasValue ? _tweetRepository.GetTweetsByUserId(UserId.Value) : _tweetRepository.GetTweets();

            // newest first 
            return tweets.OrderByDescending(t => t.CreatedAt).Select(t => t.ToDto()).ToList();
        }

        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto)
        {
            if (!IsValidContent(updateTweetDto.content))
            {
                return null;
            }

            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return null;
            }

            tweet.Content = updateTweetDto.content.Trim();
            tweet.MarkAsModified();

            return tweet.ToDto();
        }

        private static bool IsValidContent(string content)
        {
            return !string.IsNullOrWhiteSpace(content) && content.Length <= Tweet.MaxContentLength;
        }
    }
}
