using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IUserManager
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        User GetByCredentials(string email, string password);
        User GetByEmail(string email);

        User Add(User user);
        User Save(User user);
        void Remove(User user);

        User Map(DataAccessLayer.Models.User dbuser);
        DataAccessLayer.Models.User Map(User user);

        Verification GetVerificationByUserId(int id);
        IEnumerable<Verification> GetAllVerifications();

        Verification AddVerification(Verification verification);
        void RemoveVerification(Verification verification);

        Verification Map(DataAccessLayer.Models.Verification dbVerification);
        DataAccessLayer.Models.Verification Map(Verification verification);
    }
}
