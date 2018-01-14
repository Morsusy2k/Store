namespace Store.DataAccessLayer.Models
{
    public class Category
    {
        public Category() { }
        public Category(int id, string name, string description, byte[] version)
        {
            Id = id;
            Name = name;
            Description = description;
            Version = version;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Version { get; set; }
    }

    public class SubCategory
    {
        public SubCategory() { }
        public SubCategory(int id,int categoryId, string name, string description, byte[] version)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Version = version;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Version { get; set; }
    }
}
