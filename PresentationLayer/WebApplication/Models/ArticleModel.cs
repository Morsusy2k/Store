using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.PresentationLayer.WebApplication.Models
{
    public class ArticleModel
    {
        private readonly IArticleManager _articleManager = new ArticleManager();

        public ArticleModel() { }
        public ArticleModel(int userId, int subCategoryId, string name, string description, string price, int storage, byte[] version)
        {
            UserId = userId;
            SubCategoryId = subCategoryId;
            Name = name;
            Description = description;
            Price = price;
            Storage = storage;
            Version = version;
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Storage { get; set; }

        public byte[] Version { get; set; }

        public IEnumerable<ArticleImageModel> Images
        {
            get
            {
                return _articleManager.GetAllImagesByArticleId(Id).Select(x => (ArticleImageModel)x);
            }
        }

        public static implicit operator Article(ArticleModel am)
        {
            if (am == null)
                return null;

            Article article = new Article(am.UserId, am.SubCategoryId, am.Name, am.Description, am.Price, am.Storage, am.Version)
            {
                Id = am.Id
            };

            return article;
        }

        public static implicit operator ArticleModel(Article a)
        {
            if (a == null)
                return null;

            ArticleModel article = new ArticleModel(a.UserId, a.SubCategoryId, a.Name, a.Description, a.Price, a.Storage, a.Version)
            {
                Id = a.Id
            };

            return article;
        }
    }

    public class ArticleImageModel
    {
        public ArticleImageModel() { }
        public ArticleImageModel(int userId, int articleId, byte[] picture, byte[] version)
        {
            UserId = userId;
            ArticleId = articleId;
            Picture = picture;
            Version = version;
        }
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }
        public byte[] Picture { get; set; }
        public byte[] Version { get; set; }

        public static implicit operator ArticleImage(ArticleImageModel aim)
        {
            if (aim == null)
                return null;

            ArticleImage articleImage = new ArticleImage(aim.UserId, aim.ArticleId, aim.Picture, aim.Version)
            {
                Id = aim.Id
            };

            return articleImage;
        }

        public static implicit operator ArticleImageModel(ArticleImage ai)
        {
            if (ai == null)
                return null;

            ArticleImageModel articleImage = new ArticleImageModel(ai.UserId, ai.ArticleId, ai.Picture, ai.Version)
            {
                Id = ai.Id
            };

            return articleImage;
        }
    }
}
