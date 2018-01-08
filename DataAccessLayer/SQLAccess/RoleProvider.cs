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
    public class RoleProvider : IRoleRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Role> GetAllRoles()
        {
            List<Role> result = new List<Role>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("RoleGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Role>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Role GetRoleById(int id)
        {
            Role result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("RoleGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Role>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public List<Role> GetAllRolesByUserId(int id)
        {
            List<Role> result = new List<Role>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRoleGetAllByUserId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Role>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool UserRoleExists(User user, Role role)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRoleExists", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
                    sqlCommand.Parameters.AddWithValue("@RoleId", role.Id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion

        #region [WriteMethods]

        public Role InsertRole(Role role, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("RoleInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertRoleSqlCommand(sqlCommand, role);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("RoleInsert", sqlConnection))
                    {
                        return InsertRoleSqlCommand(sqlCommand, role);
                    }
                }
            }
        }
        public Role UpdateRole(Role role, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("RoleUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateRoleSqlCommand(sqlCommand, role);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("RoleUpdate", sqlConnection))
                    {
                        return UpdateRoleSqlCommand(sqlCommand, role);
                    }
                }
            }
        }
        public void DeleteRole(Role role, ITransaction transaction = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("RoleDelete", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", role.Id);

                    int result = sqlCommand.ExecuteNonQuery();

                    if (result == 0)
                    {
                        throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
                    }
                }
            }

        }
        public Role InsertUserRole(Role role, User user, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("UserRoleInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertUserRoleSqlCommand(sqlCommand, role, user);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("UserRoleInsert", sqlConnection))
                    {
                        return InsertUserRoleSqlCommand(sqlCommand, role, user);
                    }
                }
            }
        }
        public void DeleteAllUserRoles(User user, ITransaction transaction = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("UserRoleDeleteAllByUserId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@UserId", user.Id);

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

        public Role InsertRoleSqlCommand(SqlCommand sqlCommand, Role role)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", role.Name);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            sqlCommand.ExecuteNonQuery();

            role.Id = Convert.ToInt32(outputIdParam.Value);

            return role;
        }

        public Role UpdateRoleSqlCommand(SqlCommand sqlCommand, Role role)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", role.Id);
            sqlCommand.Parameters.AddWithValue("@Name", role.Name);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return role;
        }

        public Role InsertUserRoleSqlCommand(SqlCommand sqlCommand, Role role, User user)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", user.Id);
            sqlCommand.Parameters.AddWithValue("@RoleId", role.Id);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            sqlCommand.ExecuteNonQuery();

            role.Id = Convert.ToInt32(outputIdParam.Value);

            return role;
        }
        #endregion
    }
}
