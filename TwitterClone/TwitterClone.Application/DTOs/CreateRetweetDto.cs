using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.DTOs
{
    public class CreateRetweetDto : IValidatableObject
    {
        public required Guid UserId { get; set; }

        public required Guid TweetId { get; set; }

        // Optional: a retweet without a comment is a plain retweet.
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(
            ValidationContext validationContext)
        {
            if (Comment != null && Comment.Length > 280)
            {
                yield return new ValidationResult(
                    "Retweet comment cannot exceed 280 characters.",
                    new[] { nameof(Comment) }
                );
            }
        }
    }
}