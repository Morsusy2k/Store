using System;
using System.Diagnostics;

namespace Store.BusinessLogicLayer.Models
{
    public class Article
    {
        private string name { get; set; }
        private string description { get; set; }
        private string price { get; set; }

        public Article() { }
        public Article(int userId, int subCategoryId, string name, string description, string price, int storage)
        {
            UserId = userId;
            SubCategoryId = subCategoryId;
            Name = name;
            Description = description;
            Price = price;
            Storage = storage;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }
        public int Storage { get; set; }
        public byte[] Version { get; set; }
        public string Name
        {
            get
            {
                Debug.Assert(name != null);
                return name;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name", "Valid name is mandatory!");

                string oldValue = name;
                try
                {
                    name = value;
                }
                catch
                {
                    name = oldValue;
                    throw;
                }
            }
        }
        public string Description
        {
            get
            {
                Debug.Assert(description != null);
                return description;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Description", "Valid description is mandatory!");

                string oldValue = description;
                try
                {
                    description = value;
                }
                catch
                {
                    description = oldValue;
                    throw;
                }
            }
        }
        public string Price
        {
            get
            {
                Debug.Assert(price != null);
                return price;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Price", "Valid price is mandatory!");

                string oldValue = price;
                try
                {
                    price = value;
                }
                catch
                {
                    price = oldValue;
                    throw;
                }
            }
        }
    }

    public class ArticleImage
    {
        public ArticleImage() { }
        public ArticleImage(int userId, int articleId, byte[] picture)
        {
            UserId = userId;
            ArticleId = articleId;
            Picture = picture;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public byte[] Picture { get; set; }
        public byte[] Version { get; set; }
    }
}