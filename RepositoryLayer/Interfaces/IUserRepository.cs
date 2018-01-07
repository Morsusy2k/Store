using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();

        User InsertUser(User user, ITransaction transaction = null);
        User UpdateUser(User user, ITransaction transaction = null);
        void DeleteUser(User user, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
