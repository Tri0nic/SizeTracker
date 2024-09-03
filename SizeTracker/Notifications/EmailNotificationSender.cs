using SizeTracker.Notifications;
using System.Net.Mail;
using System.Net;

namespace SizeTracker.Notification
{
    internal class EmailNotificationSender : INotificationSender
    {
        public void SendNotification(string message)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "";
            string smtpPassword = "";

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add("");
                    mailMessage.Subject = "Нужный размер товара доступен на сайте";
                    mailMessage.Body = message;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine(message);
                        Console.WriteLine("Уведомление отправлено на email");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
                    }
                }
            }
        }
    }
}
