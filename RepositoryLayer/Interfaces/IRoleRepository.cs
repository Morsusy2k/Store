using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface IRoleRepository
    {
        Role GetRoleById(int id);
        List<Role> GetAllRoles();
        List<Role> GetAllRolesByUserId(int id);
        bool UserRoleExists(User user, Role role);

        Role InsertRole(Role role, ITransaction transaction = null);
        Role UpdateRole(Role role, ITransaction transaction = null);
        void DeleteRole(Role role, ITransaction transaction = null);

        Role InsertUserRole(Role role, User user, ITransaction transaction = null);
        void DeleteAllUserRoles(User user, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
