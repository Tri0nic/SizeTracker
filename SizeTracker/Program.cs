using SizeTracker;
using SizeTracker.Notifications.FactoryNotifications;
using SizeTracker.Parsers.FactoryParser;
class Program
{
    static async Task Main()
    {
        var parserFactory = new SiteParserFactory();
        var notificationSenderFactory = new NotificationSenderFactory();

        var appRunner = new ApplicationRunner(parserFactory, notificationSenderFactory);

        appRunner.Run();
    }
}