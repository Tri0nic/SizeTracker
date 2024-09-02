using SizeTracker.Notifications.FactoryNotifications;
using SizeTracker.Parsers.FactoryParser;

namespace SizeTracker
{
    public class ApplicationRunner
    {
        private readonly ISiteParserFactory _siteParserFactory;
        private readonly NotificationSenderFactory _notificationSenderFactory;

        public ApplicationRunner(ISiteParserFactory parserFactory, NotificationSenderFactory notificationSenderFactory)
        {
            _siteParserFactory = parserFactory;
            _notificationSenderFactory = notificationSenderFactory;
        }

        public void Run()
        {
            Console.WriteLine("Введите ссылку на одежду:");
            var clothingUrl = Console.ReadLine(); //TODO: сделать проверку на корректность

            Console.WriteLine("Введите нужный размер:");
            var size = Console.ReadLine(); //TODO: сделать проверку на корректность

            Console.WriteLine("Введите способ отправки уведомления: 1 - Email, 2 - Telegram, 3 - Оба");
            var choosedSendersNumber = Console.ReadLine(); //TODO: сделать проверку на корректность

            var parser = _siteParserFactory.ChooseParser(clothingUrl);

            var notificationSender = _notificationSenderFactory.CreateNotificationSender(choosedSendersNumber);

            var isSizeAvailable = false;

            while (!isSizeAvailable)
            {
                isSizeAvailable = parser.IsSizeAvailable(clothingUrl, size);

                if (isSizeAvailable)
                {
                    var message = $"Размер {size} доступен на сайте по ссылке {clothingUrl}.";
                    notificationSender.SendNotification(message);
                }
                else
                {
                    Console.WriteLine($"Размер {size} недоступен на сайте. Продолжаем проверку...");
                    Thread.Sleep(30000);
                }
            }
        }

    }
}
