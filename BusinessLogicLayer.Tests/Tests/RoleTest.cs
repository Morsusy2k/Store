using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System;

namespace Store.BusinessLogicLayer.Tests
{
    public static class RoleTest
    {
        private static readonly IRoleManager _roleManager = new RoleManager();

        public static void Menu()
        {
            

            int choice = 0;
            while (choice != 5)
            {
                Console.Clear();
                ShowAll();
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("- [ Role test menu ] -");
                Console.WriteLine("[1] Insert new role");
                Console.WriteLine("[2] Update role");
                Console.WriteLine("[3] Remove role");
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
                        InsertNewRole();
                        Wait();
                        break;
                    case 2:
                        UpdateAndShowRole();
                        Wait();
                        break;
                    case 3:
                        DeleteRole();
                        Wait();
                        break;
                }
            }
        }

        private static void DeleteRole()
        {
            Console.Write("\nInsert role id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            _roleManager.Remove(_roleManager.GetById(id));
            Console.WriteLine("Role removed!");
        }

        private static void UpdateAndShowRole()
        {
            Console.Write("\nInsert role id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            Role role = _roleManager.GetById(id);
            Console.WriteLine("Changing role: \n");
            ShowRole(role);

            Console.WriteLine("New role name:");
            role.Name = Console.ReadLine();

            ShowRole(_roleManager.Save(role));
            Console.WriteLine("Role saved!");
        }

        private static void InsertNewRole()
        {
            Role role = new Role();
            Console.WriteLine("\n- Insert new role -");
            Console.Write("Role name: ");
            role.Name = Console.ReadLine();
            _roleManager.Add(role);
            Console.WriteLine("\nRole created!");
        }

        private static void ShowAll()
        {
            foreach(Role role in _roleManager.GetAll())
            {
                ShowRole(role);
            }
        }

        private static void ShowRole(Role role)
        {
            Console.WriteLine($"\nId: {role.Id} \t Name: {role.Name} ");
        }

        private static void Wait()
        {
            Console.WriteLine("\n\n\nPress [enter] to continue...");
            Console.ReadLine();
        }
    }
}
