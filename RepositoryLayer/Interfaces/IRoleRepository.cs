using Store.DataAccessLayer.Models;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Interfaces
{
    public interface IRoleRepository
    {
        Role GetRoleById(int id);
        List<Role> GetAllRoles();

        Role InsertRole(Role role, ITransaction transaction = null);
        Role UpdateRole(Role role, ITransaction transaction = null);
        void DeleteRole(Role role, ITransaction transaction = null);

        ITransaction CreateNewTransaction();
    }
}
