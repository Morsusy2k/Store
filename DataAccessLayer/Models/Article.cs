namespace Store.DataAccessLayer.Models
{
    public class Article
    {
        public Article() { }
        public Article(int id, int userId, int subCategoryId, string name, string description, string price, int storage, byte[] version)
        {
            Id = id;
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
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Storage { get; set; }
        public byte[] Version { get; set; }
    }

    public class ArticleImage
    {
        public ArticleImage() { }
        public ArticleImage(int id, int userId, int articleId, byte[] picture, byte[] version)
        {
            Id = id;
            UserId = userId;
            ArticleId = articleId;
            Picture = picture;
            Version = version;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public byte[] Picture { get; set; }
        public byte[] Version { get; set; }
    }
}
