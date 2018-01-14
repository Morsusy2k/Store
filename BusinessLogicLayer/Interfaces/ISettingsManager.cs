using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface ISettingsManager
    {
        IEnumerable<Log> GetAllLogs();
        IEnumerable<Log> GetAllLogsByUserId(int id);
        IEnumerable<Settings> GetAllSettings();
        Settings GetSettingsByKey(string key);
        Settings GetSettingsById(int id);

        void AddLog(Log log);
        void AddSettings(Settings settings);
        void SaveSettings(Settings settings);
        void RemoveSettings(Settings settings);
        void ClearLog();

        Log Map(DataAccessLayer.Models.Log dbRole);
        DataAccessLayer.Models.Log Map(Log role);
    }
}
