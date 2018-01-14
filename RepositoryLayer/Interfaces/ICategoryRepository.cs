using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();

        Category InsertCategory(Category category, ITransaction transaction = null);
        Category UpdateCategory(Category category, ITransaction transaction = null);
        void DeleteCategory(Category category, ITransaction transaction = null);

        SubCategory GetSubCategoryById(int id);
        List<SubCategory> GetAllSubCategories();
        List<SubCategory> GetAllSubCategoriesByCategoryId(int id);

        SubCategory InsertSubCategory(SubCategory subCategory, ITransaction transaction = null);
        SubCategory UpdateSubCategory(SubCategory subCategory, ITransaction transaction = null);
        void DeleteSubCategory(SubCategory subCategory, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
