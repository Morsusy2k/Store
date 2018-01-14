using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IArticleManager
    {
        Article GetById(int id);
        IEnumerable<Article> GetAll();

        Article Add(Article article);
        Article Save(Article article);
        void Remove(Article article);

        Article Map(DataAccessLayer.Models.Article dbArticle);
        DataAccessLayer.Models.Article Map(Article article);

        ArticleImage GetImageById(int id);
        IEnumerable<ArticleImage> GetAllImagesByArticleId(int id);

        ArticleImage AddImage(ArticleImage articleImage);
        void RemoveImage(ArticleImage articleImage);

        ArticleImage Map(DataAccessLayer.Models.ArticleImage dbArticleImage);
        DataAccessLayer.Models.ArticleImage Map(ArticleImage articleImage);
    }
}
