using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.PresentationLayer.WebApplication.Models
{
    public class CategoryModel
    {
        private readonly ICategoryManager _categoryManager = new CategoryManager();

        public CategoryModel() { }
        public CategoryModel(string name, byte[] version)
        {
            Name = name;
            Version = version;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Version { get; set; }
        public IEnumerable<SubCategoryModel> SubCategories
        {
            get
            {
                return _categoryManager.GetAllSubCategoriesByCategoryId(Id).Select(x => (SubCategoryModel)x);
            }
        }

        public static implicit operator Category(CategoryModel cm)
        {
            if (cm == null)
                return null;

            Category category = new Category(cm.Name, cm.Version)
            {
                Id = cm.Id
            };

            return category;
        }

        public static implicit operator CategoryModel(Category c)
        {
            if (c == null)
                return null;

            CategoryModel category = new CategoryModel(c.Name, c.Version)
            {
                Id = c.Id
            };

            return category;
        }
    }

    public class SubCategoryModel
    {
        private readonly ICategoryManager _categoryManager = new CategoryManager();

        public SubCategoryModel() { }
        public SubCategoryModel(int categoryId, string name, byte[] version, byte[] picture = null)
        {
            CategoryId = categoryId;
            Name = name;
            Version = version;
            Picture = picture;
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Picture { get; set; }
        public byte[] Version { get; set; }

        public string CategoryName
        {
            get
            {
                return _categoryManager.GetById(CategoryId).Name + " > " + Name;
            }
        }

        public static implicit operator SubCategory(SubCategoryModel scm)
        {
            if (scm == null)
                return null;

            SubCategory subCategory = new SubCategory(scm.CategoryId, scm.Name, scm.Version, scm.Picture)
            {
                Id = scm.Id
            };

            return subCategory;
        }

        public static implicit operator SubCategoryModel(SubCategory sc)
        {
            if (sc == null)
                return null;

            SubCategoryModel subCategory = new SubCategoryModel(sc.CategoryId, sc.Name, sc.Version, sc.Picture)
            {
                Id = sc.Id
            };

            return subCategory;
        }
    }
}