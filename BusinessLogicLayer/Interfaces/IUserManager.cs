using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IUserManager
    {
        User GetById(int id);
        IEnumerable<User> GetAll();

        User Add(User user);
        User Save(User user);
        void Remove(User user);

        User Map(DataAccessLayer.Models.User dbuser);
        DataAccessLayer.Models.User Map(User user);
    }
}
