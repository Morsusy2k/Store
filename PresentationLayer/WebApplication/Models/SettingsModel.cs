using Store.BusinessLogicLayer.Models;

namespace Store.PresentationLayer.WebApplication.Models
{
    public class LogModel
    {
        public LogModel() { }
        public LogModel(int userId, string message, string ip)
        {
            UserId = userId;
            Message = message;
            Ip = ip;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }

        public static implicit operator Log(LogModel lo)
        {
            Log log = new Log(lo.UserId, lo.Message, lo.Ip)
            {
                Id = lo.Id
            };

            return log;
        }

        public static implicit operator LogModel(Log l)
        {
            LogModel log = new LogModel(l.UserId, l.Message, l.Ip)
            {
                Id = l.Id
            };

            return log;
        }
    }

    public class SettingsModel
    {
        public SettingsModel() { }
        public SettingsModel(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public static implicit operator Settings(SettingsModel sm)
        {
            Settings set = new Settings(sm.Key, sm.Value)
            {
                Id = sm.Id
            };

            return set;
        }

        public static implicit operator SettingsModel(Settings s)
        {
            SettingsModel set = new SettingsModel(s.Key, s.Value)
            {
                Id = s.Id
            };

            return set;
        }
    }
}