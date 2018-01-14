using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.SQLAccess.Providers;
using Store.RepositoryLayer.Interfaces;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IArticleRepository _provider = new ArticleProvider();

        public List<Article> GetAllArticles()
        {
            return _provider.GetAllArticles();
        }

        public Article GetArticleById(int id)
        {
            return _provider.GetArticleById(id);
        }

        public Article InsertArticle(Article article, ITransaction transaction = null)
        {
            return _provider.InsertArticle(article, transaction);
        }

        public Article UpdateArticle(Article article, ITransaction transaction = null)
        {
            return _provider.UpdateArticle(article, transaction);
        }

        public void DeleteArticle(Article article, ITransaction transaction = null)
        {
            _provider.DeleteArticle(article, transaction);
        }

        public List<ArticleImage> GetAllImagesByArticleId(int id)
        {
            return _provider.GetAllImagesByArticleId(id);
        }

        public ArticleImage GetArticleImageById(int id)
        {
            return _provider.GetArticleImageById(id);
        }

        public ArticleImage InsertArticleImage(ArticleImage articleImage, ITransaction transaction = null)
        {
            return _provider.InsertArticleImage(articleImage, transaction);
        }

        public void DeleteArticleImage(ArticleImage articleImage, ITransaction transaction = null)
        {
            _provider.DeleteArticleImage(articleImage, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
