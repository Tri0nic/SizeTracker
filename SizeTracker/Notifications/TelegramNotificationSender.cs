using SizeTracker.Notifications;

namespace SizeTracker.Notification
{
    internal class TelegramNotificationSender : INotificationSender
    {
        public void SendNotification(string message)
        {
            // Логика отправки telegram-сообщения
            Console.WriteLine(message);
            Console.WriteLine("Уведомление отправлено в telegram");
        }
    }
}
