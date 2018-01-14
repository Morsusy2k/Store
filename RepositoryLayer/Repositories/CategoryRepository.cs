using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.SQLAccess.Providers;
using Store.RepositoryLayer.Interfaces;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryRepository _provider = new CategoryProvider();

        public List<Category> GetAllCategories()
        {
            return _provider.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _provider.GetCategoryById(id);
        }

        public Category InsertCategory(Category category, ITransaction transaction = null)
        {
            return _provider.InsertCategory(category, transaction);
        }

        public Category UpdateCategory(Category category, ITransaction transaction = null)
        {
            return _provider.UpdateCategory(category, transaction);
        }

        public void DeleteCategory(Category category, ITransaction transaction = null)
        {
            _provider.DeleteCategory(category, transaction);
        }

        public List<SubCategory> GetAllSubCategories()
        {
            return _provider.GetAllSubCategories();
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return _provider.GetSubCategoryById(id);
        }

        public List<SubCategory> GetAllSubCategoriesByCategoryId(int id)
        {
            return _provider.GetAllSubCategoriesByCategoryId(id);
        }

        public SubCategory InsertSubCategory(SubCategory subCategory, ITransaction transaction = null)
        {
            return _provider.InsertSubCategory(subCategory, transaction);
        }

        public SubCategory UpdateSubCategory(SubCategory subCategory, ITransaction transaction = null)
        {
            return _provider.UpdateSubCategory(subCategory, transaction);
        }

        public void DeleteSubCategory(SubCategory subCategory, ITransaction transaction = null)
        {
            _provider.DeleteSubCategory(subCategory, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
