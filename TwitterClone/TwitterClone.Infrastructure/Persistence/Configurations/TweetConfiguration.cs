using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {

        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.ToTable("tweets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.Content)
                .HasMaxLength(Tweet.MaxContentLength)
                .IsRequired();


            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasIndex(t => t.UserId).IsUnique();
        }
    }
}
