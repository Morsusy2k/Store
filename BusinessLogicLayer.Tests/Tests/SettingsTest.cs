using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System;

namespace Store.BusinessLogicLayer.Tests
{
    public static class SettingsTest
    {
        private static readonly ISettingsManager _settingsManager = new SettingsManager();
        private static readonly IUserManager _userManager = new UserManager();

        public static void Menu()
        {
            int choice = 0;

            while (choice != 9)
            {
                Console.Clear();
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("- Settings menu -");
                Console.WriteLine("[1] Show logs");
                Console.WriteLine("[2] Show settings");
                Console.WriteLine("[3] Add settings");
                Console.WriteLine("[4] Update settings");
                Console.WriteLine("[5] Remove settings");
                Console.WriteLine("[6] Clear logs");

                Console.WriteLine("[9] Exit");

                ConsoleKeyInfo key = Console.ReadKey();
                if (char.IsDigit(key.KeyChar))
                {
                    choice = int.Parse(key.KeyChar.ToString());
                }
                else
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        ShowAllLogs();
                        Wait();
                        break;
                    case 2:
                        ShowAllSettings();
                        Wait();
                        break;
                    case 3:
                        AddSettings();
                        Wait();
                        break;
                    case 4:
                        UpdateSettings();
                        Wait();
                        break;
                    case 5:
                        RemoveSettings();
                        Wait();
                        break;
                    case 6:
                        ClearLog();
                        Wait();
                        break;
                }
            }
        }

        private static void ClearLog()
        {
            Console.WriteLine("\nRemoving all log entries!");
            Console.WriteLine("Please confirm by typing \"clear\"");
            string confirmation = Console.ReadLine();
            if (confirmation != "clear")
            {
                Console.WriteLine("Action canceled!");
                return;
            }
            else
            {
                _settingsManager.AddLog(new Log(0, "Log cleared!", "localhost"));
                _settingsManager.ClearLog();
                Console.WriteLine("Log cleared!");
            }
        }

        private static void RemoveSettings()
        {
            Console.Write("\nInsert settings id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Settings settings = _settingsManager.GetSettingsById(id);
            if (settings == null)
            {
                Console.WriteLine("Settings not found!");
                return;
            }

            Console.WriteLine($"Removing settings: {settings.Key} -> {settings.Value}.");
            Console.WriteLine("Please confirm by typing \"yes\"");
            string confirmation = Console.ReadLine();
            if (confirmation != "yes")
            {
                Console.WriteLine("Action canceled!");
                return;
            }
            else
            {
                _settingsManager.AddLog(new Log(0, $"Settings {settings.Id} {settings.Key} -> {settings.Value} removed", "localhost"));
                _settingsManager.RemoveSettings(settings);
                Console.WriteLine($"Settings {settings.Id} {settings.Key} -> {settings.Value} removed!");
            }
        }

        private static void UpdateSettings()
        {
            Console.Write("\nInsert settings id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Settings settings = _settingsManager.GetSettingsById(id);
            if (settings == null)
            {
                Console.WriteLine("Settings not found!");
                return;
            }

            Console.WriteLine("Changing settings: \n");
            ShowSettings(settings);

            Console.WriteLine("New value:");
            settings.Value = Console.ReadLine();

            _settingsManager.SaveSettings(settings);

            Console.WriteLine("Settings saved!");
        }

        private static void ShowAllLogs()
        {
            foreach(Log log in _settingsManager.GetAllLogs())
            {
                ShowLog(log);
            }
        }

        private static void ShowAllSettings()
        {
            foreach(Settings setting in _settingsManager.GetAllSettings())
            {
                ShowSettings(setting);
            }
        }

        private static void AddSettings()
        {
            Settings settings = new Settings();
            Console.WriteLine("\n- Add new settings -");
            Console.Write("Settings key: ");
            settings.Key = Console.ReadLine();
            Console.Write("Settings value: ");
            settings.Value = Console.ReadLine();
            _settingsManager.AddSettings(settings);
            _settingsManager.AddLog(new Log(0, $"({settings.Id}) {settings.Key} -> {settings.Value} added to settings", "localhost"));
            Console.WriteLine("\nAdded to settings!");
        }

        private static void ShowLog(Log log)
        {
            Console.Write($"\nId: {log.Id} \t User: ");
            if(log.UserId == 0)
            {
                Console.Write("root");
            }
            else
            {
                User user = _userManager.GetById(log.UserId);
                Console.Write($"({user.Id}) {user.FirstName} {user.LastName}");
            }
            Console.Write($"\t Ip: { log.Ip}\n");
            Console.WriteLine($"[ {log.Message} ]");
        }

        private static void ShowSettings(Settings settings)
        {
            Console.WriteLine($"\nId: {settings.Id} \t Key: {settings.Key} \t Value: {settings.Value}");
        }

        private static void Wait()
        {
            Console.WriteLine("\n\n\nPress [enter] to continue...");
            Console.ReadLine();
        }
    }
}
