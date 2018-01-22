using System;
using System.Diagnostics;

namespace Store.BusinessLogicLayer.Models
{
    public class Category
    {
        private string name { get; set; }

        public Category() { }
        public Category(string name, byte[] version)
        {
            Name = name;

            Version = version;
        }
        public int Id { get; set; }
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
    }

    public class SubCategory
    {
        private string name { get; set; }

        public SubCategory() { }
        public SubCategory(int categoryId, string name, byte[] version, byte[] picture = null)
        {
            CategoryId = categoryId;
            Name = name;
            Picture = picture;
            Version = version;
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public byte[] Picture { get; set; }
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
    }
}