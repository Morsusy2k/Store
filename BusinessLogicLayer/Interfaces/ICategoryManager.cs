using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface ICategoryManager
    {
        Category GetById(int id);
        IEnumerable<Category> GetAll();

        Category Add(Category category);
        Category Save(Category category);
        void Remove(Category category);

        Category Map(DataAccessLayer.Models.Category dbVerification);
        DataAccessLayer.Models.Category Map(Category verification);

        SubCategory GetSubCategoryById(int id);
        IEnumerable<SubCategory> GetAllSubCategories();
        IEnumerable<SubCategory> GetAllSubCategoriesByCategoryId(int id);

        SubCategory AddSubCategory(SubCategory subCategory);
        SubCategory SaveSubCategory(SubCategory subCategory);
        void RemoveSubCategory(SubCategory subCategory);

        SubCategory Map(DataAccessLayer.Models.SubCategory dbSubCategory);
        DataAccessLayer.Models.SubCategory Map(SubCategory subCategory);
    }
}
