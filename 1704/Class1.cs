
using System;

namespace DesignPatterns
{

    public interface ICustomLogger
    {
        void LogMessage(string message);
    }

    public class LegacyScanner
    {
        public void ExecuteScan(string data)
        {
            Console.WriteLine($"LegacyScanner: Scanning data - {data}");
        }
    }

    public class ScannerAdapter : ICustomLogger
    {
        private readonly LegacyScanner _legacyScanner;

        public ScannerAdapter(LegacyScanner legacyScanner)
        {
            _legacyScanner = legacyScanner;
        }

        public void LogMessage(string message)
        {
            _legacyScanner.ExecuteScan(message);
        }
    }

    public interface IMessageSender
    {
        void SendMessage(string text);
    }

    public class SmsSender : IMessageSender
    {
        public void SendMessage(string text)
        {
            Console.WriteLine($"SMS отправлено: {text}");
        }
    }

    public class EmailSender : IMessageSender
    {
        public void SendMessage(string text)
        {
            Console.WriteLine($"Email отправлен: {text}");
        }
    }

    public abstract class Notification
    {
        protected IMessageSender _messageSender;

        protected Notification(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public abstract void Notify(string message);
    }

    public class UrgentNotification : Notification
    {
        public UrgentNotification(IMessageSender messageSender) : base(messageSender) { }

        public override void Notify(string message)
        {
            _messageSender.SendMessage($"ПРИОРИТЕТ! {message}");
        }
    }

    public class InfoNotification : Notification
    {
        public InfoNotification(IMessageSender messageSender) : base(messageSender) { }

        public override void Notify(string message)
        {
            _messageSender.SendMessage($"[INFO] {message}");
        }
    }

    
    public class TVSystem
    {
        public void TurnOn()
        {
            Console.WriteLine("Телевизор включен");
        }

        public void SetInput(string input)
        {
            Console.WriteLine($"Телевизор: вход установлен на {input}");
        }
    }

    public class AudioSystem
    {
        public void SetVolume(int level)
        {
            Console.WriteLine($"Громкость установлена на {level}%");
        }

        public void TurnOn()
        {
            Console.WriteLine("Аудиосистема включена");
        }
    }

    public class LightingControl
    {
        public void DimLights(int percentage)
        {
            Console.WriteLine($"Свет приглушен до {percentage}%");
        }

        public void TurnOn()
        {
            Console.WriteLine("Освещение включено");
        }
    }

    public class SubscriptionService
    {
        public bool CheckSubscription(string service)
        {
            Console.WriteLine($"Проверка подписки на {service}...");
            return true;
        }

        public void ActivateService(string service)
        {
            Console.WriteLine($"Сервис {service} активирован");
        }
    }

    public class SmartHomeFacade
    {
        private readonly TVSystem _tv;
        private readonly AudioSystem _audio;
        private readonly LightingControl _lighting;
        private readonly SubscriptionService _subscription;

        public SmartHomeFacade(TVSystem tv, AudioSystem audio, LightingControl lighting, SubscriptionService subscription)
        {
            _tv = tv;
            _audio = audio;
            _lighting = lighting;
            _subscription = subscription;
        }

        public void WatchMovie()
        {
            Console.WriteLine("\n=== Запуск системы просмотра фильма ===\n");

            _tv.TurnOn();
            _tv.SetInput("HDMI 1");

            _audio.TurnOn();
            _audio.SetVolume(40);

            _lighting.TurnOn();
            _lighting.DimLights(20);

            if (_subscription.CheckSubscription("Netflix"))
            {
                _subscription.ActivateService("Netflix");
                Console.WriteLine("\nПриятного просмотра!");
            }
            else
            {
                Console.WriteLine("\nНет активной подписки для просмотра фильма!");
            }
        }
    }
}