using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System;

namespace Store.BusinessLogicLayer.Tests
{
    public static class CategoryTest
    {
        private static readonly ICategoryManager _categoryManager = new CategoryManager();
        private static readonly ISettingsManager _settingsManager = new SettingsManager();

        public static void Menu()
        {
            int choice = 0;
            while (choice != 9)
            {
                Console.Clear();
                ShowAll();
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("- [ Category test menu ] -");
                Console.WriteLine("[1] Insert new category");
                Console.WriteLine("[2] Update category");
                Console.WriteLine("[3] Remove category");
                Console.WriteLine("[4] Insert new sub category");
                Console.WriteLine("[5] Update sub category");
                Console.WriteLine("[6] Remove sub category");
                Console.WriteLine("[9] Exit");

                ConsoleKeyInfo key = Console.ReadKey();
                if (char.IsDigit(key.KeyChar))
                {
                    choice = int.Parse(key.KeyChar.ToString());
                }
                else
                {
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        InsertNewCategory();
                        Wait();
                        break;
                    case 2:
                        UpdateCategory();
                        Wait();
                        break;
                    case 3:
                        DeleteCategory();
                        Wait();
                        break;
                    case 4:
                        InsertNewSubCategory();
                        Wait();
                        break;
                    case 5:
                        UpdateSubCategory();
                        Wait();
                        break;
                    case 6:
                        DeleteSubCategory();
                        Wait();
                        break;
                }
            }
        }

        private static void DeleteSubCategory()
        {
            Console.Write("\nInsert sub category id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            SubCategory subCategory = _categoryManager.GetSubCategoryById(id);
            if (subCategory == null)
            {
                Console.WriteLine("Sub category not found!");
                return;
            }

            Console.WriteLine("Please confirm by typing \"yes\"");
            string confirmation = Console.ReadLine();
            if (confirmation != "yes")
            {
                Console.WriteLine("Action canceled!");
                return;
            }
            else
            {
                _settingsManager.AddLog(new Log(0, $"Category ({subCategory.Id}) {subCategory.Name} removed", "localhost"));
                _categoryManager.RemoveSubCategory(subCategory);
                Console.WriteLine("Sub category removed!");
            }
        }

        private static void UpdateSubCategory()
        {
            Console.Write("\nUpdate sub category id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            SubCategory subCategory = _categoryManager.GetSubCategoryById(id);
            if (subCategory == null)
            {
                Console.WriteLine("Sub category not found!");
                return;
            }

            Console.WriteLine("Changing sub category: \n");
            ShowSubCategory(subCategory);
            string oldSubCategoryName = subCategory.Name;

            Console.WriteLine("New sub category name:");
            subCategory.Name = Console.ReadLine();

            Console.WriteLine("New category description:");
            subCategory.Description = Console.ReadLine();

            ShowSubCategory(_categoryManager.SaveSubCategory(subCategory));
            _settingsManager.AddLog(new Log(0, $"Sub category ({subCategory.Id}) changed {oldSubCategoryName} > {subCategory.Name}", "localhost"));
            Console.WriteLine("Sub category saved!");
        }

        private static void InsertNewSubCategory()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            SubCategory subCategory = new SubCategory();
            Console.WriteLine("\n- Insert new sub category -");

            Console.Write("Parent category: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Category category = _categoryManager.GetById(id);
            if (category == null)
            {
                Console.WriteLine("Category not found!");
                return;
            }
            subCategory.CategoryId = id;

            Console.Write("Sub category name: ");
            subCategory.Name = Console.ReadLine();

            Console.Write("Sub category description: ");
            subCategory.Description = Console.ReadLine();

            subCategory.Version = CurrentTimeStamp;

            SubCategory newSubCategory = _categoryManager.AddSubCategory(subCategory);

            _settingsManager.AddLog(new Log(0, $"Sub category ({newSubCategory.Id}) {newSubCategory.Name} added under {newSubCategory.CategoryId}", "localhost"));
            Console.WriteLine("\nSub category created!");
        }

        private static void DeleteCategory()
        {
            Console.Write("\nInsert category id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Category category = _categoryManager.GetById(id);
            if (category == null)
            {
                Console.WriteLine("Category not found!");
                return;
            }

            Console.WriteLine("Please confirm by typing \"yes\"");
            string confirmation = Console.ReadLine();
            if (confirmation != "yes")
            {
                Console.WriteLine("Action canceled!");
                return;
            }
            else
            {
                _settingsManager.AddLog(new Log(0, $"Category ({category.Id}) {category.Name} removed", "localhost"));
                _categoryManager.Remove(category);
                Console.WriteLine("Category removed!");
            }
        }

        private static void UpdateCategory()
        {
            Console.Write("\nUpdate category id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Category category = _categoryManager.GetById(id);
            if (category == null)
            {
                Console.WriteLine("Category not found!");
                return;
            }

            Console.WriteLine("Changing category: \n");
            ShowCategory(category);
            string oldCategoryName = category.Name;

            Console.WriteLine("New category name:");
            category.Name = Console.ReadLine();

            Console.WriteLine("New category description:");
            category.Description = Console.ReadLine();

            ShowCategory(_categoryManager.Save(category));
            _settingsManager.AddLog(new Log(0, $"Category ({category.Id}) changed {oldCategoryName} > {category.Name}", "localhost"));
            Console.WriteLine("Category saved!");
        }

        private static void InsertNewCategory()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Category category = new Category();
            Console.WriteLine("\n- Insert new category -");

            Console.Write("Category name: ");
            category.Name = Console.ReadLine();

            Console.Write("Category description: ");
            category.Description = Console.ReadLine();

            category.Version = CurrentTimeStamp;

            Category newCategory = _categoryManager.Add(category);

            _settingsManager.AddLog(new Log(0, $"Category ({newCategory.Id}) {newCategory.Name} added", "localhost"));
            Console.WriteLine("\nCategory created!");
        }

        private static void ShowAll()
        {
            foreach (Category category in _categoryManager.GetAll())
            {
                ShowCategory(category);
            }
        }

        private static void ShowCategory(Category category)
        {
            Console.WriteLine($"\nId: {category.Id} \t Name: {category.Name} ");
            Console.WriteLine("Sub categories:");
            foreach (SubCategory subCategory in _categoryManager.GetAllSubCategoriesByCategoryId(category.Id))
            {
                Console.WriteLine($"\t\t-Id: {subCategory.Id} \t Name: {subCategory.Name}");
            }
        }

        private static void ShowSubCategory(SubCategory subCategory)
        {
            Console.WriteLine($"\nId: {subCategory.Id} \t Name: {subCategory.Name} \tCategory: {subCategory.CategoryId}");
        }

        private static void Wait()
        {
            Console.WriteLine("\n\n\nPress [enter] to continue...");
            Console.ReadLine();
        }
    }
}
