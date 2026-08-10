namespace TwitterClone.Entities;

public sealed class FriendRequestNotification : Notification
{
    public FriendRequestNotification(Guid requestedByUserId) : base("friendRequest")
    {
        RequestedByUserId = requestedByUserId;
    }
    
    public Guid RequestedByUserId { get; set; }

    public void AddMessage(string message)
    {
        Message = message;
    }
    
    public override string DescribeRecord()
    {
        var baseRecord = base.DescribeRecord();
        return $"{baseRecord}, RequestedByUserId: {RequestedByUserId}";
    }
}