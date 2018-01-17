using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User GetUserByCredentials(string email, string password);
        User GetUserByEmail(string email);

        Verification GetVerificationByUserId(int id);
        List<Verification> GetAllVerifications();


        User InsertUser(User user, ITransaction transaction = null);
        User UpdateUser(User user, ITransaction transaction = null);
        void DeleteUser(User user, ITransaction transaction = null);

        Verification InsertVerification(Verification verification, ITransaction transaction = null);
        void DeleteVerification(Verification verification, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
