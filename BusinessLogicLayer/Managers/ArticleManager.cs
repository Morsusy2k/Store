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
    public class ArticleManager : IArticleManager
    {
        private readonly IArticleRepository _repository = new ArticleRepository();
        private ITransaction _transaction;

        public IEnumerable<Article> GetAll()
        {
            return _repository.GetAllArticles().Select(x => Map(x));
        }

        public IEnumerable<Article> GetAllBySubCategoryId(int id)
        {
            return _repository.GetAllArticlesBySubCategoryId(id).Select(x => Map(x));
        }

        public Article GetById(int id)
        {
            return Map(_repository.GetArticleById(id));
        }

        public Article Add(Article article)
        {
            return Map(_repository.InsertArticle(Map(article)));
        }

        public Article Save(Article article)
        {
            return Map(_repository.UpdateArticle(Map(article)));
        }

        public void Remove(Article article)
        {
            _repository.DeleteArticle(Map(article));
        }

        public Article Map(DataAccessLayer.Models.Article dbArticle)
        {
            if (Equals(dbArticle, null))
                return null;

            Article article = new Article(dbArticle.UserId, dbArticle.SubCategoryId, dbArticle.Name, dbArticle.Description, dbArticle.Price, dbArticle.Storage, dbArticle.Version);
            article.Id = dbArticle.Id;

            return article;
        }

        public DataAccessLayer.Models.Article Map(Article article)
        {
            if (Equals(article, null))
                throw new ArgumentNullException("Article", "Valid article is mandatory!");

            return new DataAccessLayer.Models.Article(article.Id, article.UserId, article.SubCategoryId, article.Name, article.Description, article.Price, article.Storage, article.Version);
        }

        public IEnumerable<ArticleImage> GetAllImagesByArticleId(int id)
        {
            return _repository.GetAllImagesByArticleId(id).Select(x => Map(x));
        }

        public ArticleImage GetImageById(int id)
        {
            return Map(_repository.GetArticleImageById(id));
        }

        public ArticleImage AddImage(ArticleImage articleImage)
        {
            return Map(_repository.InsertArticleImage(Map(articleImage)));
        }

        public void RemoveImage(ArticleImage articleImage)
        {
            _repository.DeleteArticleImage(Map(articleImage));
        }

        public ArticleImage Map(DataAccessLayer.Models.ArticleImage dbArticleImage)
        {
            if (Equals(dbArticleImage, null))
                return null;

            ArticleImage articleImage = new ArticleImage(dbArticleImage.UserId, dbArticleImage.ArticleId, dbArticleImage.Picture, dbArticleImage.Version);
            articleImage.Id = dbArticleImage.Id;

            return articleImage;
        }

        public DataAccessLayer.Models.ArticleImage Map(ArticleImage articleImage)
        {
            if (Equals(articleImage, null))
                throw new ArgumentNullException("ArticleImage", "Valid articleImage is mandatory!");

            return new DataAccessLayer.Models.ArticleImage(articleImage.Id, articleImage.UserId, articleImage.ArticleId, articleImage.Picture, articleImage.Version);
        }
    }
}
