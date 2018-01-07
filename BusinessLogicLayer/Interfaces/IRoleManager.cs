using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        Role GetById(int id);
        IEnumerable<Role> GetAll();

        Role Add(Role role);
        Role Save(Role role);
        void Remove(Role role);

        Role Map(DataAccessLayer.Models.Role dbRole);
        DataAccessLayer.Models.Role Map(Role role);
    }
}
