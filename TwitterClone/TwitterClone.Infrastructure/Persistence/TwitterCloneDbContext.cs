using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public class TwitterCloneDbContext : DbContext
    {
        public TwitterCloneDbContext(DbContextOptions<TwitterCloneDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<Retweet> Retweets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(TwitterCloneDbContext).Assembly);

            modelBuilder.Entity<Notification>()
                .HasDiscriminator<string>("NotificationType")
                .HasValue<LikeNotification>("Like")
                .HasValue<MentionNotification>("Mention")
                .HasValue<FriendRequestNotification>("FriendRequest")
                .HasValue<SystemNotification>("System")
                .HasValue<CommentNotification>("Comment");
        }
    }
}

//dotnet ef migrations add InitialCreate --project TwitterClone.Infrastructure --startup-project TwitterClone.Api --output-dir Persistence/Migrations

//dotnet ef database update --project TwitterClone.Infrastructure --startup-project TwitterClone.Api
