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
    public class ArticleProvider : IArticleRepository
    {
        private readonly string _connectionString = AppSettings.ConnectionString;

        #region [ReadMethods]
        public List<Article> GetAllArticles()
        {
            List<Article> result = new List<Article>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("ArticleGetAll", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Article>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public Article GetArticleById(int id)
        {
            Article result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("ArticleGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<Article>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<Article> GetAllArticlesBySubCategoryId(int id)
        {
            List<Article> result = new List<Article>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("ArticleGetAllBySubCategoryId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SubCategoryId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<Article>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }

        public List<ArticleImage> GetAllImagesByArticleId(int id)
        {
            List<ArticleImage> result = new List<ArticleImage>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("ArticleImageGetAllByArticleId", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ArticleId", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result.Add(DBAccessExtensions.MapTableEntityTo<ArticleImage>(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }
        public ArticleImage GetArticleImageById(int id)
        {
            ArticleImage result = null;

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("ArticleImageGetById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                result = DBAccessExtensions.MapTableEntityTo<ArticleImage>(reader);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion

        #region [WriteMethods]
        public Article InsertArticle(Article article, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("ArticleInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertArticleSqlCommand(sqlCommand, article);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("ArticleInsert", sqlConnection))
                    {
                        return InsertArticleSqlCommand(sqlCommand, article);
                    }
                }
            }
        }
        public Article UpdateArticle(Article article, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("ArticleUpdate", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return UpdateArticleSqlCommand(sqlCommand, article);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("ArticleUpdate", sqlConnection))
                    {
                        return UpdateArticleSqlCommand(sqlCommand, article);
                    }
                }
            }
        }
        public void DeleteArticle(Article article, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("ArticleDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteArticleSqlCommand(sqlCommand, article);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("ArticleDelete", sqlConnection))
                    {
                        DeleteArticleSqlCommand(sqlCommand, article);
                    }
                }
            }
        }

        public ArticleImage InsertArticleImage(ArticleImage articleImage, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("ArticleImageInsert", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    return InsertArticleImageSqlCommand(sqlCommand, articleImage);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("ArticleImageInsert", sqlConnection))
                    {
                        return InsertArticleImageSqlCommand(sqlCommand, articleImage);
                    }
                }
            }
        }
        public void DeleteArticleImage(ArticleImage articleImage, ITransaction transaction = null)
        {
            if (transaction != null)
            {
                using (var sqlCommand = new SqlCommand("ArticleImageDelete", (SqlConnection)transaction.Connection, (SqlTransaction)transaction.Transaction))
                {
                    DeleteArticleImageSqlCommand(sqlCommand, articleImage);
                }
            }
            else
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("ArticleImageDelete", sqlConnection))
                    {
                        DeleteArticleImageSqlCommand(sqlCommand, articleImage);
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
        private Article InsertArticleSqlCommand(SqlCommand sqlCommand, Article article)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", article.UserId);
            sqlCommand.Parameters.AddWithValue("@SubCategoryId", article.SubCategoryId);
            sqlCommand.Parameters.AddWithValue("@Date", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@Name", article.Name);
            sqlCommand.Parameters.AddWithValue("@Description", article.Description);
            sqlCommand.Parameters.AddWithValue("@Price", article.Price);
            sqlCommand.Parameters.AddWithValue("@Storage", article.Storage);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            article.Id = Convert.ToInt32(outputIdParam.Value);
            article.Version = (byte[])(outputVersionParam.Value);

            return article;
        }
        private Article UpdateArticleSqlCommand(SqlCommand sqlCommand, Article article)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", article.Id);
            sqlCommand.Parameters.AddWithValue("@UserId", article.UserId);
            sqlCommand.Parameters.AddWithValue("@SubCategoryId", article.SubCategoryId);
            sqlCommand.Parameters.AddWithValue("@Name", article.Name);
            sqlCommand.Parameters.AddWithValue("@Description", article.Description);
            sqlCommand.Parameters.AddWithValue("@Price", article.Price);
            sqlCommand.Parameters.AddWithValue("@Storage", article.Storage);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.InputOutput;
            outputVersionParam.Value = article.Version;
            sqlCommand.Parameters.Add(outputVersionParam);

            int result = sqlCommand.ExecuteNonQuery();
            article.Version = (byte[])(outputVersionParam.Value);

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before updating.");
            }

            return article;
        }
        private void DeleteArticleSqlCommand(SqlCommand sqlCommand, Article article)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", article.Id);
            sqlCommand.Parameters.AddWithValue("@Version", article.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }

        private ArticleImage InsertArticleImageSqlCommand(SqlCommand sqlCommand, ArticleImage articleImage)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", articleImage.UserId);
            sqlCommand.Parameters.AddWithValue("@ArticleId", articleImage.ArticleId);
            sqlCommand.Parameters.AddWithValue("@Picture", articleImage.Picture);

            SqlParameter outputIdParam = new SqlParameter("@Id", SqlDbType.Int);
            outputIdParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputIdParam);

            SqlParameter outputVersionParam = new SqlParameter("@Version", SqlDbType.Timestamp);
            outputVersionParam.Direction = ParameterDirection.Output;
            sqlCommand.Parameters.Add(outputVersionParam);

            sqlCommand.ExecuteNonQuery();

            articleImage.Id = Convert.ToInt32(outputIdParam.Value);
            articleImage.Version = (byte[])(outputVersionParam.Value);

            return articleImage;
        }
        private void DeleteArticleImageSqlCommand(SqlCommand sqlCommand, ArticleImage articleImage)
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", articleImage.Id);
            sqlCommand.Parameters.AddWithValue("@Version", articleImage.Version);

            int result = sqlCommand.ExecuteNonQuery();

            if (result == 0)
            {
                throw new DBConcurrencyException("The record has been modified by an other user. Please reload the instance before deleting.");
            }
        }
        #endregion
    }
}
