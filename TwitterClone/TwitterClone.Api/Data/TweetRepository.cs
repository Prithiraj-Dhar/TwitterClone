using TwitterClone.Domain.Entities;
namespace TwitterClone.Api.Data
{
    public class TweetRepository
    {
        private List<Tweet> _tweets { get; set; } = new List<Tweet>();

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            _tweets.RemoveAll(t => t.Id == tweet.Id);
            _tweets.Add(tweet);
            return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }

        public Tweet? GetTweetByID(Guid id)
        {
            return _tweets.FirstOrDefault(tweet => tweet.Id == id);
        }

        public Tweet? GetTweetByUserID(Guid userId)
        {
            return _tweets.FirstOrDefault(tweet => tweet.UserId == userId);
        }

        public List<Tweet> GetTweets()
        {
            return _tweets;
        }

    }
}
