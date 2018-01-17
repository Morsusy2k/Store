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

        public User GetUserByCredentials(string email, string password)
        {
            return _provider.GetUserByCredentials(email, password);
        }

        public User GetUserByEmail(string email)
        {
            return _provider.GetUserByEmail(email);
        }

        public List<Verification> GetAllVerifications()
        {
            return _provider.GetAllVerifications();
        }

        public Verification GetVerificationByUserId(int id)
        {
            return _provider.GetVerificationByUserId(id);
        }

        public User InsertUser(User user, ITransaction transaction = null)
        {
            return _provider.InsertUser(user, transaction);
        }

        public Verification InsertVerification(Verification verification, ITransaction transaction = null)
        {
            return _provider.InsertVerification(verification, transaction);
        }

        public User UpdateUser(User user, ITransaction transaction = null)
        {
            return _provider.UpdateUser(user, transaction);
        }

        public void DeleteUser(User user, ITransaction transaction = null)
        {
            _provider.DeleteUser(user, transaction);
        }

        public void DeleteVerification(Verification verification, ITransaction transaction = null)
        {
            _provider.DeleteVerification(verification);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
