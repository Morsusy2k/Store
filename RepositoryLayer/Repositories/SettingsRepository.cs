using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.SQLAccess.Providers;
using Store.RepositoryLayer.Interfaces;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly ISettingsRepository _provider = new SettingsProvider();

        public List<Log> GetAllLogs()
        {
            return _provider.GetAllLogs();
        }

        public List<Settings> GetAllSettings()
        {
            return _provider.GetAllSettings();
        }

        public List<Log> GetAllLogsByUserId(int id)
        {
            return _provider.GetAllLogsByUserId(id);
        }

        public Settings GetSettingsByKey(string key)
        {
            return _provider.GetSettingsByKey(key);
        }

        public Settings GetSettingsById(int id)
        {
            return _provider.GetSettingsById(id);
        }

        public void InsertLog(Log log, ITransaction transaction = null)
        {
            _provider.InsertLog(log, transaction);
        }

        public void InsertSettings(Settings settings, ITransaction transaction = null)
        {
            _provider.InsertSettings(settings, transaction);
        }

        public void UpdateSettings(Settings settings, ITransaction transaction = null)
        {
            _provider.UpdateSettings(settings, transaction);
        }

        public void DeleteSettings(Settings settings, ITransaction transaction = null)
        {
            _provider.DeleteSettings(settings, transaction);
        }

        public void ClearLog()
        {
            _provider.ClearLog();
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
