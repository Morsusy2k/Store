﻿using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Tests
{
    public static class UserTest
    {
        private static readonly IUserManager _userManager = new UserManager();
        private static readonly IRoleManager _roleManager = new RoleManager();

        public static void Menu()
        {
            int choice = 0;

            while (choice != 9)
            {
                Console.Clear();
                ShowAll();
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("- User test menu -");
                Console.WriteLine("[1] Insert new user");
                Console.WriteLine("[2] Update user");
                Console.WriteLine("[3] Remove user");
                Console.WriteLine("[4] Add a role to user");
                Console.WriteLine("[5] Remove all user roles");
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
                        InsertNewUser();
                        Wait();
                        break;
                    case 2:
                        UpdateAndShowUser();
                        Wait();
                        break;
                    case 3:
                        DeleteUser();
                        Wait();
                        break;
                    case 4:
                        AddRoleToUser();
                        Wait();
                        break;
                    case 5:
                        RemoveAllUserRoles();
                        Wait();
                        break;
                }
            }
        }

        private static void RemoveAllUserRoles()
        {
            Console.WriteLine("\n- Remove all user roles -");
            Console.Write("User id: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            User user = _userManager.GetById(id);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }
            Console.WriteLine($"Removing all roles of user {user.FirstName} {user.LastName}.");
            Console.WriteLine("Please confirm by typing \"yes\"");
            string confirmation = Console.ReadLine();
            if(confirmation != "yes")
            {
                Console.WriteLine("Action canceled!");
                return;
            }
            else
            {
                _roleManager.RemoveUserRoles(user);
                Console.WriteLine($"All roles of user {user.FirstName} {user.LastName} removed!");
            }
        }

        private static void AddRoleToUser()
        {
            Console.WriteLine("\n- Add a role to user -");
            Console.Write("User id: ");
            Int32.TryParse(Console.ReadLine(), out int id);
            User user = _userManager.GetById(id);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                return;
            }
            Console.WriteLine($"User {user.FirstName} {user.LastName} selected.");
            Console.Write("Role id: ");
            Int32.TryParse(Console.ReadLine(), out int rid);
            Role role = _roleManager.GetById(rid);
            if (role == null)
            {
                Console.WriteLine("Role not found!");
                return;
            }

            if(_roleManager.UserRoleExists(user, role))
            {
                Console.WriteLine("User already has this role!");
                return;
            }

            _roleManager.AddUserRole(role, user);
            Console.WriteLine($"Role {role.Name} added to user {user.FirstName} {user.LastName}");
        }

        private static void InsertNewUser()
        {
            DateTime dt = DateTime.Now;
            var CurrentTimeStamp = BitConverter.GetBytes(dt.Ticks);

            User user = new User();
            Console.WriteLine("\n- Insert new user -");
            Console.Write("First name: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            user.LastName = Console.ReadLine();
            Console.Write("Email address: ");
            user.EmailAddress = Console.ReadLine();
            Console.Write("Phone number: ");
            user.PhoneNumber = Console.ReadLine();
            Console.Write("Address: ");
            user.Address = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            user.Activated = true;
            user.LastLogin = DateTime.Now;
            user.Version = CurrentTimeStamp;

            _userManager.Add(user);
            Console.WriteLine("\nUser created!");

        }

        private static void ShowAll()
        {
            foreach (var user in _userManager.GetAll())
            {
                ShowUser(user);
            };
        }

        private static void UpdateAndShowUser()
        {
            Console.Write("\nInsert user id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            User user = _userManager.GetById(id);
            Console.WriteLine("Changing user: \n");
            ShowUser(user);

            Console.WriteLine("New first name:");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("New last name:");
            user.LastName = Console.ReadLine();

            ShowUser(_userManager.Save(user));
            Console.WriteLine("User saved!");
        }

        private static void DeleteUser()
        {
            Console.Write("\nInsert user id: ");
            Int32.TryParse(Console.ReadLine(), out int id);

            _userManager.Remove(_userManager.GetById(id));
            Console.WriteLine("User removed!");
        }

        private static void ShowUser(User user)
        {
            Console.Write($"\nId: {user.Id}\tName: {user.FirstName} {user.LastName}\tRoles: ");
            IEnumerable<Role> roles = _roleManager.GetAllByUserId(user.Id);

            foreach (Role role in roles)
            {
                Console.Write($"{role.Name} ({role.Id}) ");
            }

            Console.WriteLine();
        }

        private static void Wait()
        {
            Console.WriteLine("\n\n\nPress [enter] to continue...");
            Console.ReadLine();
        }
    }
}
