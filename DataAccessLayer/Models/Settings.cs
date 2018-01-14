namespace Store.DataAccessLayer.Models
{
    public class Log
    {
        public Log() { }
        public Log(int id, int userId, string message, string ip)
        {
            Id = id;
            UserId = userId;
            Message = message;
            Ip = ip;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }
    }

    public class Settings
    {
        public Settings() { }
        public Settings(int id, string key, string value)
        {
            Id = id;
            Key = key;
            Value = value;
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
