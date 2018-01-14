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
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _repository = new CategoryRepository();
        private ITransaction _transaction;

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAllCategories().Select(x => Map(x));
        }

        public Category GetById(int id)
        {
            return Map(_repository.GetCategoryById(id));
        }

        public Category Add(Category category)
        {
            return Map(_repository.InsertCategory(Map(category)));
        }

        public Category Save(Category category)
        {
            return Map(_repository.UpdateCategory(Map(category)));
        }

        public void Remove(Category category)
        {
            _repository.DeleteCategory(Map(category));
        }

        public Category Map(DataAccessLayer.Models.Category dbCategory)
        {
            if (Equals(dbCategory, null))
                return null;

            Category category = new Category(dbCategory.Name, dbCategory.Description);
            category.Id = dbCategory.Id;
            category.Version = dbCategory.Version;

            return category;
        }

        public DataAccessLayer.Models.Category Map(Category category)
        {
            if (Equals(category, null))
                throw new ArgumentNullException("Category", "Valid category is mandatory!");

            return new DataAccessLayer.Models.Category(category.Id, category.Name, category.Description, category.Version);
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return _repository.GetAllSubCategories().Select(x => Map(x));
        }

        public IEnumerable<SubCategory> GetAllSubCategoriesByCategoryId(int id)
        {
            return _repository.GetAllSubCategoriesByCategoryId(id).Select(x => Map(x));
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return Map(_repository.GetSubCategoryById(id));
        }

        public SubCategory AddSubCategory(SubCategory subCategory)
        {
            return Map(_repository.InsertSubCategory(Map(subCategory)));
        }

        public SubCategory SaveSubCategory(SubCategory subCategory)
        {
            return Map(_repository.UpdateSubCategory(Map(subCategory)));
        }

        public void RemoveSubCategory(SubCategory subCategory)
        {
            _repository.DeleteSubCategory(Map(subCategory));
        }

        public SubCategory Map(DataAccessLayer.Models.SubCategory dbSubCategory)
        {
            if (Equals(dbSubCategory, null))
                return null;

            SubCategory subCategory = new SubCategory(dbSubCategory.CategoryId, dbSubCategory.Name, dbSubCategory.Description);
            subCategory.Id = dbSubCategory.Id;
            subCategory.Version = dbSubCategory.Version;

            return subCategory;
        }

        public DataAccessLayer.Models.SubCategory Map(SubCategory subCategory)
        {
            if (Equals(subCategory, null))
                throw new ArgumentNullException("SubCategory", "Valid subCategory is mandatory!");

            return new DataAccessLayer.Models.SubCategory(subCategory.Id,subCategory.CategoryId, subCategory.Name, subCategory.Description, subCategory.Version);
        }
    }
}
