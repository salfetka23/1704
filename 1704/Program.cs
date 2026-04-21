
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 1: Adapter ===\n");

            LegacyScanner legacyScanner = new LegacyScanner();
            ICustomLogger logger = new ScannerAdapter(legacyScanner);
            logger.LogMessage("Важные данные для сканирования");

            Console.WriteLine("\n=== Задание 2: Bridge ===\n");

            IMessageSender smsSender = new SmsSender();
            IMessageSender emailSender = new EmailSender();

            Notification urgentSms = new UrgentNotification(smsSender);
            Notification urgentEmail = new UrgentNotification(emailSender);
            Notification infoEmail = new InfoNotification(emailSender);

            urgentSms.Notify("Код подтверждения: 1234");
            urgentEmail.Notify("Системная ошибка на сервере");
            infoEmail.Notify("Обновление программного обеспечения");

            Console.WriteLine("\n=== Задание 3: Facade ===\n");

            TVSystem tv = new TVSystem();
            AudioSystem audio = new AudioSystem();
            LightingControl lighting = new LightingControl();
            SubscriptionService subscription = new SubscriptionService();

            SmartHomeFacade smartHome = new SmartHomeFacade(tv, audio, lighting, subscription);
            smartHome.WatchMovie();

            Console.ReadKey();
        }
    }
}