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
    public class UserProvider : IUserRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<User>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public User GetUserById(int id)
        {
            User result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<User>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region [WriteMethods]

        public User InsertUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserInsert", sqlConnection))
                    {
                        return InsertUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        public User UpdateUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserUpdate", sqlConnection))
                    {
                        return UpdateUserSqlCommand(sqlCommand, user);
                    }
                }
            }
        }
        public void DeleteUser(User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteUserSqlCommand(sqlCommand, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserDelete", sqlConnection))
                    {
                        DeleteUserSqlCommand(sqlCommand, user);
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

        public User InsertUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@Address", user.Address);
            sqlCommand.Parameters.AddWithValue("@Picture", user.Picture);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@LastLogin", user.LastLogin);
            sqlCommand.Parameters.AddWithValue("@Activated", user.Activated);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            user.Id = Convert.ToInt32(outputIdParam.Value);
            user.Version = (byte[])(outputVersionParam.Value);

            return user;
        }

        public User UpdateUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@Address", user.Address);
            sqlCommand.Parameters.AddWithValue("@Picture", user.Picture);
            sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            sqlCommand.Parameters.AddWithValue("@LastLogin", user.LastLogin);
            sqlCommand.Parameters.AddWithValue("@Activated", user.Activated);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = user.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            user.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return user;
        }

        public void DeleteUserSqlCommand(SqlCommand sqlCommand, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", user.Id);
            sqlCommand.Parameters.AddWithValue("@Version", user.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion
    }
}
