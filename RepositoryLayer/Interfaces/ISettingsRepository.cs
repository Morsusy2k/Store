using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface ISettingsRepository
    {
        List<Log> GetAllLogs();
        List<Log> GetAllLogsByUserId(int id);
        List<Settings> GetAllSettings();
        Settings GetSettingsByKey(string key);
        Settings GetSettingsById(int id);

        void InsertLog(Log log, ITransaction transaction = null);
        void InsertSettings(Settings settings, ITransaction transaction = null);
        void UpdateSettings(Settings settings, ITransaction transaction = null);
        void DeleteSettings(Settings settings, ITransaction transaction = null);
        void ClearLog();

        ITransaction CreateNewTransaction();
    }
}
