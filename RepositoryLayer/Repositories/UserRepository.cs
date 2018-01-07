using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.SQLAccess.Providers;
using Store.RepositoryLayer.Interfaces;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserRepository _provider = new UserProvider();

        public List<User> GetAllUsers()
        {
            return _provider.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _provider.GetUserById(id);
        }

        public User InsertUser(User user, ITransaction transaction = null)
        {
            return _provider.InsertUser(user, transaction);
        }

        public User UpdateUser(User user, ITransaction transaction = null)
        {
            return _provider.UpdateUser(user, transaction);
        }

        public void DeleteUser(User user, ITransaction transaction = null)
        {
            _provider.DeleteUser(user, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
