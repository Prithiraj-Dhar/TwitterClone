using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly TwitterCloneDbContext _context;
        public LikeRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Like AddLike(Like like)
        {
            _context.Likes.Add(like);

            return like;
        }

        public bool DeleteLike(Like like)
        {
            _context.Likes.Remove(like);
            return true;
        }

        public int DeleteLikesByUserId(Guid userId)
        {
            var likes =  _context.Likes.Where(l => l.UserId == userId).ToList();

            if (likes.Count == 0)
            {
                return 0;
            }

            _context.Likes.RemoveRange(likes);

            return likes.Count;
        }

        public int DeleteLikesByTweetId(Guid tweetId)
        {
            var likes = _context.Likes.Where(l => l.TweetId == tweetId).ToList();

            if (likes.Count == 0)
            {
                return 0;
            }

            _context.Likes.RemoveRange(likes);

            return likes.Count;
        }

        public Like? GetLikeById(Guid id)
        {
            return _context.Likes.SingleOrDefault(l => l.Id == id);
        }

        public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _context.Likes.FirstOrDefault(l => l.UserId == userId && l.TweetId == tweetId);
        }

        public List<Like> GetLikes(Guid? userId, Guid? tweetId)
        {
            return _context.Likes
                .Where(l => (userId == null || l.UserId == userId) &&
                            (tweetId == null || l.TweetId == tweetId))
                .ToList();
        }
    }
}