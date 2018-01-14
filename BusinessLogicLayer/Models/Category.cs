using System;
using System.Diagnostics;

namespace Store.BusinessLogicLayer.Models
{
    public class Category
    {
        private string name { get; set; }
        private string description { get; set; }

        public Category() { }
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
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
    }

    public class SubCategory
    {
        private string name { get; set; }
        private string description { get; set; }

        public SubCategory() { }
        public SubCategory(int categoryId, string name, string description)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
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
    }
}