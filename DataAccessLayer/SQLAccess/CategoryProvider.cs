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
    public class CategoryProvider : ICategoryRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]

        public List<Category> GetAllCategories()
        {
            List<Category> result = new List<Category>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("CategoryGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Category>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Category GetCategoryById(int id)
        {
            Category result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("CategoryGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Category>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<SubCategory> GetAllSubCategories()
        {
            List<SubCategory> result = new List<SubCategory>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubCategoryGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<SubCategory>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<SubCategory> GetAllSubCategoriesByCategoryId(int id)
        {
            List<SubCategory> result = new List<SubCategory>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubCategoryGetByCategoryId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CategoryId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<SubCategory>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public SubCategory GetSubCategoryById(int id)
        {
            SubCategory result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SubCategoryGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<SubCategory>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region [WriteMethods]

        public Category InsertCategory(Category category, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("CategoryInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertCategorySqlCommand(sqlCommand, category);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("CategoryInsert", sqlConnection))
                    {
                        return InsertCategorySqlCommand(sqlCommand, category);
                    }
                }
            }
        }
        public Category UpdateCategory(Category category, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("CategoryUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateCategorySqlCommand(sqlCommand, category);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("CategoryUpdate", sqlConnection))
                    {
                        return UpdateCategorySqlCommand(sqlCommand, category);
                    }
                }
            }
        }
        public void DeleteCategory(Category category, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("CategoryDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteCategorySqlCommand(sqlCommand, category);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("CategoryDelete", sqlConnection))
                    {
                        DeleteCategorySqlCommand(sqlCommand, category);
                    }
                }
            }
        }
        public SubCategory InsertSubCategory(SubCategory subCategory, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubCategoryInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertSubCategorySqlCommand(sqlCommand, subCategory);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubCategoryInsert", sqlConnection))
                    {
                        return InsertSubCategorySqlCommand(sqlCommand, subCategory);
                    }
                }
            }
        }
        public SubCategory UpdateSubCategory(SubCategory subCategory, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubCategoryUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateSubCategorySqlCommand(sqlCommand, subCategory);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubCategoryUpdate", sqlConnection))
                    {
                        return UpdateSubCategorySqlCommand(sqlCommand, subCategory);
                    }
                }
            }
        }
        public void DeleteSubCategory(SubCategory subCategory, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("SubCategoryDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteSubCategorySqlCommand(sqlCommand, subCategory);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SubCategoryDelete", sqlConnection))
                    {
                        DeleteSubCategorySqlCommand(sqlCommand, subCategory);
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

        public Category InsertCategorySqlCommand(SqlCommand sqlCommand, Category category)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Name", category.Name);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            category.Id = Convert.ToInt32(outputIdParam.Value);
            category.Version = (byte[])(outputVersionParam.Value);

            return category;
        }

        public Category UpdateCategorySqlCommand(SqlCommand sqlCommand, Category category)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", category.Id);
            sqlCommand.Parameters.AddWithValue("@Name", category.Name);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = category.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            category.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return category;
        }

        public void DeleteCategorySqlCommand(SqlCommand sqlCommand, Category category)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", category.Id);
            sqlCommand.Parameters.AddWithValue("@Version", category.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }

        public SubCategory InsertSubCategorySqlCommand(SqlCommand sqlCommand, SubCategory subCategory)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@CategoryId", subCategory.CategoryId);
            sqlCommand.Parameters.AddWithValue("@Name", subCategory.Name);
            sqlCommand.Parameters.AddWithValue("@Picture", subCategory.Picture);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            subCategory.Id = Convert.ToInt32(outputIdParam.Value);
            subCategory.Version = (byte[])(outputVersionParam.Value);

            return subCategory;
        }

        public SubCategory UpdateSubCategorySqlCommand(SqlCommand sqlCommand, SubCategory subCategory)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", subCategory.Id);
            sqlCommand.Parameters.AddWithValue("@CategoryId", subCategory.CategoryId);
            sqlCommand.Parameters.AddWithValue("@Name", subCategory.Name);
            sqlCommand.Parameters.AddWithValue("@Picture", subCategory.Picture);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = subCategory.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            subCategory.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return subCategory;
        }

        public void DeleteSubCategorySqlCommand(SqlCommand sqlCommand, SubCategory subCategory)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", subCategory.Id);
            sqlCommand.Parameters.AddWithValue("@Version", subCategory.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion
    }
}
