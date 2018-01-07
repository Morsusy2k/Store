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
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository = new UserRepository();
        private ITransaction _transaction;

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAllUsers().Select(x => Map(x));
        }

        public User GetById(int id)
        {
            return Map(_repository.GetUserById(id));
        }

        public User Add(User user)
        {
            return Map(_repository.InsertUser(Map(user)));
        }

        public User Save(User user)
        {
            return Map(_repository.UpdateUser(Map(user)));
        }

        public void Remove(User user)
        {
            _repository.DeleteUser(Map(user));
        }        

        public User Map(DataAccessLayer.Models.User dbUser)
        {
            if (Equals(dbUser, null))
                return null;

            User user = new User(dbUser.FirstName, dbUser.LastName, dbUser.EmailAddress, dbUser.PhoneNumber, dbUser.Address, dbUser.Password, dbUser.LastLogin, dbUser.Activated, dbUser.Version, dbUser.Picture);
            user.Id = dbUser.Id;
            user.Version = dbUser.Version;

            return user;
        }

        public DataAccessLayer.Models.User Map(User user)
        {
            if (Equals(user, null))
                throw new ArgumentNullException("User", "Valid user is mandatory!");

            return new DataAccessLayer.Models.User(user.Id, user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.Address, user.Password, user.LastLogin, user.Activated, user.Version, user.Picture);
        }

    }
}
