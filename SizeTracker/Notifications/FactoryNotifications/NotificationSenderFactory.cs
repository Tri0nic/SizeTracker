using SizeTracker.Notification;
using SizeTracker.Notifications.CompositeNotification;

namespace SizeTracker.Notifications.FactoryNotifications
{
    public class NotificationSenderFactory
    {
        public INotificationSender CreateNotificationSender(string choice)
        {
            var compositeSender = new CompositeNotificationSender();

            switch (choice)
            {
                case "1":
                    compositeSender.AddSender(new EmailNotificationSender());
                    break;
                case "2":
                    compositeSender.AddSender(new TelegramNotificationSender());
                    break;
                case "3":
                    compositeSender.AddSender(new EmailNotificationSender());
                    compositeSender.AddSender(new TelegramNotificationSender());
                    break;
                default:
                    throw new ArgumentException("Неверный выбор");
            }

            return compositeSender;
        }
    }
}
