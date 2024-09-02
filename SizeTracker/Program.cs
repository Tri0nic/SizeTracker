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
        //ISiteParserFactory parser;
        ////var notificationSender = new SendNotification();
        //
        //var applicationRunner = new ApplicationRunner(parser,);
        //applicationRunner.Run();

        // Настройка DI-контейнера
        //var serviceProvider = new ServiceCollection()
        //    .AddSingleton<ISiteParserFactory, SiteParserFactory>() // Регистрация фабрики парсеров
        //    .AddSingleton<NotificationSenderFactory>() // Регистрация фабрики отправителей уведомлений
        //    .AddTransient<ApplicationRunner>() // Регистрация ApplicationRunner
        //    .BuildServiceProvider();
        //
        //// Получение ApplicationRunner из контейнера
        //var applicationRunner = serviceProvider.GetService<ApplicationRunner>();
        //applicationRunner.Run();

        // Создание конкретных реализаций зависимостей
        ISiteParserFactory parserFactory = new SiteParserFactory(); // Реализация ISiteParserFactory
        NotificationSenderFactory notificationSenderFactory = new NotificationSenderFactory(); // Реализация NotificationSenderFactory

        // Создание экземпляра ApplicationRunner с передачей зависимостей
        var appRunner = new ApplicationRunner(parserFactory, notificationSenderFactory);

        // Запуск приложения
        appRunner.Run();
    }
}