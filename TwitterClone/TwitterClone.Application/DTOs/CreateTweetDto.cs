namespace TwitterClone.Application.DTOs
{
    public class CreateTweetDto
    {
        public required Guid UserId { get; set; }
        public required string content { get; set; }
    }
}
