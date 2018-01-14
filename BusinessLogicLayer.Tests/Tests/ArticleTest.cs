using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System;

namespace Store.BusinessLogicLayer.Tests
{
    public static class ArticleTest
    {
        private static readonly IArticleManager _articleManager = new ArticleManager();
        private static readonly ISettingsManager _settingsManager = new SettingsManager();

        public static void Menu()
        {
            int choice = 0;
            while (choice != 9)
            {
                Console.Clear();
                ShowAll();
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("- [ Article test menu ] -");
                Console.WriteLine("[1] List articles");
                Console.WriteLine("[2] Insert new article");
                Console.WriteLine("[3] Update article");
                Console.WriteLine("[4] Remove article");
                Console.WriteLine("[5] Insert new article image");
                Console.WriteLine("[6] Remove article image");
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
                        ShowAll();
                        Wait();
                        break;
                    case 2:
                        InsertNewArticle();
                        Wait();
                        break;
                    case 3:
                        UpdateArticle();
                        Wait();
                        break;
                    case 4:
                        DeleteArticle();
                        Wait();
                        break;
                    case 5:
                        InsertNewImage();
                        Wait();
                        break;
                    case 6:
                        DeleteArticleImage();
                        Wait();
                        break;
                }
            }
        }

        private static void DeleteArticle()
        {
            Console.Write("\nInsert article id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Article article = _articleManager.GetById(id);
            if (article == null)
            {
                Console.WriteLine("Article not found!");
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
                _settingsManager.AddLog(new Log(0, $"Article ({article.Id}) {article.Name} removed", "localhost"));
                _articleManager.Remove(article);
                Console.WriteLine("Article removed!");
            }
        }

        private static void UpdateArticle()
        {
            Console.Write("\nInsert article id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Article article = _articleManager.GetById(id);
            if (article == null)
            {
                Console.WriteLine("Article not found!");
                return;
            }

            Console.WriteLine("Changing article: \n");
            ShowArticle(article);
            string oldArticleName = article.Name;

            Console.WriteLine("New article name:");
            article.Name = Console.ReadLine();

            ShowArticle(_articleManager.Save(article));
            _settingsManager.AddLog(new Log(0, $"Article ({article.Id}) name changed {oldArticleName} > {article.Name}", "localhost"));
            Console.WriteLine("Article saved!");
        }

        private static void InsertNewArticle()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Article article = new Article();
            Console.WriteLine("\n- Insert new article -");

            Console.Write("Article category: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            article.SubCategoryId = id;

            Console.Write("Article name: ");
            article.Name = Console.ReadLine();

            Console.Write("Article description: ");
            article.Description = Console.ReadLine();

            Console.Write("Article price: ");
            article.Price = Console.ReadLine();

            article.UserId = 1;
            article.Storage = 1;
            article.Version = CurrentTimeStamp;

            Article newArticle = _articleManager.Add(article);
            
            _settingsManager.AddLog(new Log(0, $"Article ({newArticle.Id}) {newArticle.Name} added", "localhost"));
            Console.WriteLine("\nArticle created!");
        }

        private static void InsertNewImage()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            Console.WriteLine("\n- Insert new article image -");

            Console.Write("Article id: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Article article = _articleManager.GetById(id);

            if(article == null)
            {
                Console.WriteLine("Article not found!");
                return;
            }

            ArticleImage image = new ArticleImage();

            image.UserId = 1;
            image.ArticleId = article.Id;

            Random rnd = new Random();

            Byte[] ByteArray = new Byte[(int)500 * (int)500];

            rnd.NextBytes(ByteArray);

            image.Picture = ByteArray;
            image.Version = CurrentTimeStamp;

            _articleManager.AddImage(image);

            _settingsManager.AddLog(new Log(0, $"Article image ({image.Id}) added", "localhost"));
            Console.WriteLine("\nArticle image created!");
        }

        private static void DeleteArticleImage()
        {
            Console.Write("\nInsert article image id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            ArticleImage image = _articleManager.GetImageById(id);
            if (image == null)
            {
                Console.WriteLine("Image not found!");
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
                _settingsManager.AddLog(new Log(0, $"Article image ({image.Id}) removed", "localhost"));
                _articleManager.RemoveImage(image);
                Console.WriteLine("Article image removed!");
            }
        }

        private static void ShowAll()
        {
            foreach(Article article in _articleManager.GetAll())
            {
                ShowArticle(article);
            }
        }

        private static void ShowArticle(Article article)
        {
            Console.WriteLine($"\nId: {article.Id} \t Name: {article.Name} ");
            foreach(ArticleImage image in _articleManager.GetAllImagesByArticleId(article.Id))
            {
                Console.WriteLine($"\t - Image id: {image.Id}");
            }
        }

        private static void Wait()
        {
            Console.WriteLine("\n\n\nPress [enter] to continue...");
            Console.ReadLine();
        }
    }
}