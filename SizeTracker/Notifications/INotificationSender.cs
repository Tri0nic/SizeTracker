namespace SizeTracker.Notifications
{
    public interface INotificationSender
    {
        public void SendNotification(string message);
    }
}
