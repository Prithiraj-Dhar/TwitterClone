namespace TwitterClone.Entities;

public sealed class CommentNotification : Notification
{
    public CommentNotification(Guid commentByUserId) : base("comment")
    {
        CommentByUserId = commentByUserId;
    }
    
    public Guid CommentByUserId { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
    }
    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{baseRecord}, CommentByUserId: {CommentByUserId}";
    }
}