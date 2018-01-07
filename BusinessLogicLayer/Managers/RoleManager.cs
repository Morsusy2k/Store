using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models;
using Store.RepositoryLayer.Interfaces;
using Store.RepositoryLayer.Repositories;
using Store.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.BusinessLogicLayer.Managers
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository _repository = new RoleRepository();
        private ITransaction _transaction;

        public IEnumerable<Role> GetAll()
        {
            return _repository.GetAllRoles().Select(x => Map(x));
        }

        public Role GetById(int id)
        {
            return Map(_repository.GetRoleById(id));
        }

        public Role Add(Role role)
        {
            return Map(_repository.InsertRole(Map(role)));
        }

        public Role Save(Role role)
        {
            return Map(_repository.UpdateRole(Map(role)));
        }

        public void Remove(Role role)
        {
            _repository.DeleteRole(Map(role));
        }
        
        public Role Map(DataAccessLayer.Models.Role dbRole)
        {
            if (Equals(dbRole, null))
                return null;

            Role role = new Role(dbRole.Name);
            role.Id = dbRole.Id;

            return role;
        }

        public DataAccessLayer.Models.Role Map(Role role)
        {
            if (Equals(role, null))
                throw new ArgumentNullException("Role", "Valid role is mandatory!");

            return new DataAccessLayer.Models.Role(role.Id, role.Name);
        }

    }
}
