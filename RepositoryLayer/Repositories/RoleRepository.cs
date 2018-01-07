using Store.DataAccessLayer.Models;
using Store.DataAccessLayer.SQLAccess.Providers;
using Store.RepositoryLayer.Interfaces;
using Store.Utilities.Common;
using System.Collections.Generic;

namespace Store.RepositoryLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleRepository _provider = new RoleProvider();

        public Role GetRoleById(int id)
        {
           return _provider.GetRoleById(id);
        }

        public List<Role> GetAllRoles()
        {
            return _provider.GetAllRoles();
        }

        public Role InsertRole(Role role, ITransaction transaction = null)
        {
            return _provider.InsertRole(role,transaction);
        }

        public Role UpdateRole(Role role, ITransaction transaction = null)
        {
            return _provider.UpdateRole(role, transaction);
        }

        public void DeleteRole(Role role, ITransaction transaction = null)
        {
            _provider.DeleteRole(role, transaction);
        }

        public ITransaction CreateNewTransaction()
        {
            return _provider.CreateNewTransaction();
        }
    }
}
