namespace Store.DataAccessLayer.Models
{
    public class Category
    {
        public Category() { }
        public Category(int id, string name, byte[] version)
        {
            Id = id;
            Name = name;
            Version = version;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Version { get; set; }
    }

    public class SubCategory
    {
        public SubCategory() { }
        public SubCategory(int id,int categoryId, string name ,byte[] version, byte[] picture = null)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Picture = picture;
            Version = version;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public byte[] Version { get; set; }
    }
}
