namespace TwitterClone.Entities;

public sealed class LikeNotification : Notification
{
    public LikeNotification(Guid likeByUserId) : base("like")
    {
        LikeByUserId = likeByUserId;
    }
    
    public Guid LikeByUserId { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
    }
    
    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{baseRecord}, LikeByUserId: {LikeByUserId}";
    }
}