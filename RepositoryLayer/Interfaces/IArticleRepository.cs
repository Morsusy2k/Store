using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface IArticleRepository
    {
        Article GetArticleById(int id);
        List<Article> GetAllArticles();

        Article InsertArticle(Article article, ITransaction transaction = null);
        Article UpdateArticle(Article article, ITransaction transaction = null);
        void DeleteArticle(Article article, ITransaction transaction = null);

        ArticleImage GetArticleImageById(int id);
        List<ArticleImage> GetAllImagesByArticleId(int id);

        ArticleImage InsertArticleImage(ArticleImage articleImage, ITransaction transaction = null);
        void DeleteArticleImage(ArticleImage articleImage, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
