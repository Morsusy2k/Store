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

        public IEnumerable<Role> GetAllByUserId(int id)
        {
            return _repository.GetAllRolesByUserId(id).Select(x => Map(x));
        }

        public bool UserRoleExists(User user, Role role)
        {
            return _repository.UserRoleExists(Map(user), Map(role));
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

        public Role AddUserRole(Role role, User user)
        {
            return Map(_repository.InsertUserRole(Map(role), Map(user)));
        }

        public void RemoveUserRoles(User user)
        {
            _repository.DeleteAllUserRoles(Map(user));
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

        public User Map(DataAccessLayer.Models.User dbUser)
        {
            if (Equals(dbUser, null))
                return null;

            User user = new User(dbUser.FirstName, dbUser.LastName, dbUser.EmailAddress, dbUser.PhoneNumber, dbUser.Address, dbUser.Password, dbUser.LastLogin, dbUser.Activated, dbUser.Picture);
            user.Id = dbUser.Id;
            user.Version = dbUser.Version;

            return user;
        }

        public DataAccessLayer.Models.User Map(User user)
        {
            if (Equals(user, null))
                throw new ArgumentNullException("User", "Valid user is mandatory!");

            return new DataAccessLayer.Models.User(user.Id, user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.Address, user.Password, user.LastLogin, user.Activated, user.Version, user.Picture);
        }

    }
}
