using Store.BusinessLogicLayer.Tests;
using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.Clear();
                Console.WriteLine("- [ Administration console menu ] -");
                Console.WriteLine("[1] User manager");
                Console.WriteLine("[2] Role manager");
                Console.WriteLine("[3] Tests");
                Console.WriteLine("[4] Settings");
                Console.WriteLine("[5] Exit");

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
                        UserTest.Menu();
                        break;
                    case 2:
                        RoleTest.Menu();
                        break;
                    case 3:
                        Tests();
                        break;
                    case 4:
                        SettingsTest.Menu();
                        break;
                }
            }                
        }

        private static void Tests()
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.Clear();
                Console.WriteLine("- [ Test console menu ] -");
                Console.WriteLine("[1] Article manager");
                Console.WriteLine("[2] Category manager");
                Console.WriteLine("[5] Exit");

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
                        ArticleTest.Menu();
                        break;
                    case 2:
                        CategoryTest.Menu();
                        break;
                }
            }
        }
    }
}
