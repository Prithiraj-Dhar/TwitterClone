using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private readonly TwitterCloneDbContext _context;
        public RetweetRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Retweet AddRetweet(Retweet retweet)
        {
            _context.Retweets.Add(retweet);
            _context.SaveChanges();

            return retweet;
        }

        public Retweet UpdateRetweet(Retweet retweet)
        {
            _context.Retweets.Where(r => r.Id == retweet.Id);
            _context.Retweets.Update(retweet);
            _context.SaveChanges();
            return retweet;
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            _context.Retweets.Remove(retweet);
            _context.SaveChanges();

            return true;
        }

        public int DeleteRetweetsByUserId(Guid userId)
        {
            var tweets = _context.Retweets.Where(r => r.UserId == userId).ToList();

            if(tweets.Count == 0)
            {
                return 0;
            }
            _context.Retweets.RemoveRange(tweets);
            _context.SaveChanges();

            return tweets.Count;
        }

        public int DeleteRetweetsByTweetId(Guid tweetId)
        {
            var tweets = _context.Retweets.Where(r => r.TweetId == tweetId).ToList();

            if (tweets.Count == 0)
            {
                return 0;
            }
            _context.Retweets.RemoveRange(tweets);
            _context.SaveChanges();

            return tweets.Count;
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _context.Retweets.SingleOrDefault(r => r.Id == id);
        }

        public List<Retweet> GetRetweets(Guid? userId, Guid? tweetId)
        {
            return _context.Retweets
                .Where(r => (userId == null || r.UserId == userId) &&
                            (tweetId == null || r.TweetId == tweetId))
                .ToList();
        }
    }
}