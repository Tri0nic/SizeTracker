using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using SizeTracker;
using SizeTracker.Interfaces;
using SizeTracker.Notification;
using SizeTracker.Notifications.FactoryNotifications;
using SizeTracker.Parsers;
using SizeTracker.Parsers.FactoryParser;
using System.Net;
using System.Net.Http.Headers;

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