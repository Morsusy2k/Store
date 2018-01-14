using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models;
using Store.RepositoryLayer.Interfaces;
using Store.RepositoryLayer.Repositories;
using Store.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.BusinessLogicLayer.Managers
{
    public class SettingsManager : ISettingsManager
    {
        private readonly ISettingsRepository _repository = new SettingsRepository();
        private ITransaction _transaction;

        public IEnumerable<Log> GetAllLogs()
        {
            return _repository.GetAllLogs().Select(x => Map(x));
        }

        public IEnumerable<Settings> GetAllSettings()
        {
            return _repository.GetAllSettings().Select(x => Map(x));
        }

        public IEnumerable<Log> GetAllLogsByUserId(int id)
        {
            return _repository.GetAllLogsByUserId(id).Select(x => Map(x));
        }

        public Settings GetSettingsByKey(string key)
        {
            return Map(_repository.GetSettingsByKey(key));
        }

        public Settings GetSettingsById(int id)
        {
            return Map(_repository.GetSettingsById(id));
        }

        public void AddLog(Log log)
        {
            _repository.InsertLog(Map(log));
        }

        public void AddSettings(Settings settings)
        {
            _repository.InsertSettings(Map(settings));
        }

        public void SaveSettings(Settings settings)
        {
            _repository.UpdateSettings(Map(settings));
        }

        public void RemoveSettings(Settings settings)
        {
            _repository.DeleteSettings(Map(settings));
        }

        public void ClearLog()
        {
            _repository.ClearLog();
        }

        public Log Map(DataAccessLayer.Models.Log dbLog)
        {
            if (Equals(dbLog, null))
                return null;

            Log log = new Log(dbLog.UserId, dbLog.Message, dbLog.Ip);
            log.Id = dbLog.Id;
            return log;
        }

        public DataAccessLayer.Models.Log Map(Log log)
        {
            if (Equals(log, null))
                throw new ArgumentNullException("Log", "Valid log is mandatory!");

            return new DataAccessLayer.Models.Log(log.Id, log.UserId, log.Message, log.Ip);
        }

        public Settings Map(DataAccessLayer.Models.Settings dbSettings)
        {
            if (Equals(dbSettings, null))
                return null;

            Settings settings = new Settings(dbSettings.Key, dbSettings.Value);
            settings.Id = dbSettings.Id;
            return settings;
        }

        public DataAccessLayer.Models.Settings Map(Settings settings)
        {
            if (Equals(settings, null))
                throw new ArgumentNullException("Settings", "Valid settings is mandatory!");

            return new DataAccessLayer.Models.Settings(settings.Id, settings.Key, settings.Value);
        }
    }
}
