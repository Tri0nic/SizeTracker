namespace SizeTracker.Notifications.CompositeNotification
{
    internal class CompositeNotificationSender : INotificationSender
    {

        private readonly List<INotificationSender> _notificationSenders = new List<INotificationSender>();

        public void AddSender(INotificationSender sender)
        {
            _notificationSenders.Add(sender);
        }

        public void SendNotification(string message)
        {
            foreach (var notification in _notificationSenders)
            {
                notification.SendNotification(message);
            }
        }
    }
}
