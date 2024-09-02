using SizeTracker.Notifications;

namespace SizeTracker.Notification
{
    internal class EmailNotificationSender : INotificationSender
    {
        public void SendNotification(string message)
        {
            // Логика отправки email-сообщения
            Console.WriteLine(message);
            Console.WriteLine("Уведомление отправлено на email");
        }
    }
}
