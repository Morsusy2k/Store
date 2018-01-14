using Store.DataAccessLayer.Models;
using Store.RepositoryLayer.Interfaces;
using Store.Utilities.Common;
using Store.Utilities.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Store.DataAccessLayer.SQLAccess.Providers
{
    public class SettingsProvider : ISettingsRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Log> GetAllLogs()
        {
            List<Log> result = new List<Log>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("LogGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Log>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }

        public List<Log> GetAllLogsByUserId(int id)
        {
            List<Log> result = new List<Log>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("LogGetAllByUserId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Log>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }

        public List<Settings> GetAllSettings()
        {
            List<Settings> result = new List<Settings>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SettingsGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Settings>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }

        public Settings GetSettingsByKey(string key)
        {
            Settings result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SettingsGetByKey", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Key", key);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows == true)
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Settings>(reader);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Settings GetSettingsById(int id)
        {
            Settings result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SettingsGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows == true)
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Settings>(reader);
                            }
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region [WriteMethods]

        public void InsertLog(Log log, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("LogInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertLogSqlCommand(sqlCommand, log);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("LogInsert", sqlConnection))
                    {
                        InsertLogSqlCommand(sqlCommand, log);
                    }
                }
            }
        }

        public void InsertSettings(Settings settings, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SettingsInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    InsertSettingsSqlCommand(sqlCommand, settings);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SettingsInsert", sqlConnection))
                    {
                        InsertSettingsSqlCommand(sqlCommand, settings);
                    }
                }
            }
        }

        public void UpdateSettings(Settings settings, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SettingsUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    UpdateSettingsSqlCommand(sqlCommand, settings);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SettingsUpdate", sqlConnection))
                    {
                        UpdateSettingsSqlCommand(sqlCommand, settings);
                    }
                }
            }
        }

        public void DeleteSettings(Settings settings, ITransaction transaction = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SettingsDelete", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", settings.Id);

                    int result = sqlCommand.ExecuteNonQuery();

                    if (result == 0)
                    {
                        throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
                    }
                }
            }
        }

        public void ClearLog()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SettingsClearLog", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    int result = sqlCommand.ExecuteNonQuery();

                    if (result == 0)
                    {
                        throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
                    }
                }
            }
        }

        public ITransaction CreateNewTransaction()
        {
            return new AdoTransaction(_connectionString);
        }
        #endregion

        #region [SqlCommandMethods]

        public void InsertLogSqlCommand(SqlCommand sqlCommand, Log log)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", log.UserId);
            sqlCommand.Parameters.AddWithValue("@Message", log.Message);
            sqlCommand.Parameters.AddWithValue("@Ip", log.Ip);
            sqlCommand.Parameters.AddWithValue("@Date", DateTime.Now);

            sqlCommand.ExecuteNonQuery();
        }

        public void InsertSettingsSqlCommand(SqlCommand sqlCommand, Settings settings)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Key", settings.Key);
            sqlCommand.Parameters.AddWithValue("@Value", settings.Value);

            sqlCommand.ExecuteNonQuery();
        }

        public void UpdateSettingsSqlCommand(SqlCommand sqlCommand, Settings settings)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", settings.Id);
            sqlCommand.Parameters.AddWithValue("@Value", settings.Value);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }
        }
        #endregion
    }
}
