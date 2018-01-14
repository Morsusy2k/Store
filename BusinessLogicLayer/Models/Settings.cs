using System;
using System.Diagnostics;

namespace Store.BusinessLogicLayer.Models
{
    public class Log
    {
        private string message { get; set; }
        private string ip { get; set; }


        public Log() { }

        public Log(int userId, string message, string ip)
        {
            UserId = userId;
            Message = message;
            Ip = ip;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message
        {
            get
            {
                Debug.Assert(message != null);
                return message;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Message", "Valid message is mandatory!");

                string oldValue = message;
                try
                {
                    message = value;
                }
                catch
                {
                    message = oldValue;
                    throw;
                }
            }
        }
        public string Ip
        {
            get
            {
                Debug.Assert(ip != null);
                return ip;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Ip", "Valid ip is mandatory!");

                string oldValue = ip;
                try
                {
                    ip = value;
                }
                catch
                {
                    ip = oldValue;
                    throw;
                }
            }
        }
    }

    public class Settings
    {
        private string key { get; set; }
        private string keyValue { get; set; }

        public Settings() { }
        public Settings(string key, string keyValue)
        {
            Key = key;
            Value = keyValue;
        }
        public int Id { get; set; }
        public string Key
        {
            get
            {
                Debug.Assert(key != null);
                return key;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Key", "Valid key is mandatory!");

                string oldValue = key;
                try
                {
                    key = value;
                }
                catch
                {
                    key = oldValue;
                    throw;
                }
            }
        }
        public string Value
        {
            get
            {
                Debug.Assert(keyValue != null);
                return keyValue;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Value", "Valid keyValue is mandatory!");

                string oldValue = keyValue;
                try
                {
                    keyValue = value;
                }
                catch
                {
                    keyValue = oldValue;
                    throw;
                }
            }
        }
    }
}
