using Store.BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace Store.BusinessLogicLayer.Interfaces
{
    public interface IRoleManager
    {
        Role GetById(int id);
        IEnumerable<Role> GetAll();
        IEnumerable<Role> GetAllByUserId(int id);
        bool UserRoleExists(User user, Role role);

        Role Add(Role role);
        Role Save(Role role);
        void Remove(Role role);
        Role AddUserRole(Role role, User user);
        void RemoveUserRoles(User user);

        Role Map(DataAccessLayer.Models.Role dbRole);
        DataAccessLayer.Models.Role Map(Role role);
    }
}
