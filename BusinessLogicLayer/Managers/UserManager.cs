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
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository = new UserRepository();
        private readonly ISettingsManager _settingsManager = new SettingsManager();
        private ITransaction _transaction;

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAllUsers().Select(x => Map(x));
        }

        public IEnumerable<Verification> GetAllVerifications()
        {
            return _repository.GetAllVerifications().Select(x => Map(x));
        }

        public User GetById(int id)
        {
            return Map(_repository.GetUserById(id));
        }

        public User GetByCredentials(string email, string password)
        {
            return Map(_repository.GetUserByCredentials(email, password));
        }

        public User GetByEmail(string email)
        {
            return Map(_repository.GetUserByEmail(email));
        }

        public Verification GetVerificationByUserId(int id)
        {
            return Map(_repository.GetVerificationByUserId(id));
        }

        public User Add(User user)
        {
            return Map(_repository.InsertUser(Map(user)));
        }

        public Verification AddVerification(Verification verification)
        {
            return Map(_repository.InsertVerification(Map(verification)));
        }

        public User Save(User user)
        {
            return Map(_repository.UpdateUser(Map(user)));
        }

        public void Remove(User user)
        {
            _repository.DeleteUser(Map(user));
        }

        public void RemoveVerification(Verification verification)
        {
            _repository.DeleteVerification(Map(verification));
        }

        public User Map(DataAccessLayer.Models.User dbUser)
        {
            if (Equals(dbUser, null))
                return null;

            User user = new User(dbUser.FirstName, dbUser.LastName, dbUser.EmailAddress, dbUser.PhoneNumber, dbUser.Address, dbUser.Password, dbUser.LastLogin, dbUser.Version ,dbUser.Picture);
            user.Id = dbUser.Id;

            return user;
        }

        public DataAccessLayer.Models.User Map(User user)
        {
            if (Equals(user, null))
                throw new ArgumentNullException("User", "Valid user is mandatory!");

            return new DataAccessLayer.Models.User(user.Id, user.FirstName, user.LastName, user.EmailAddress, user.PhoneNumber, user.Address, user.Password, user.LastLogin, user.Version, user.Picture);
        }

        public Verification Map(DataAccessLayer.Models.Verification dbVerification)
        {
            if (Equals(dbVerification, null))
                return null;

            Verification verification = new Verification(dbVerification.UserId);
            verification.Id = dbVerification.Id;

            return verification;
        }

        public DataAccessLayer.Models.Verification Map(Verification verification)
        {
            if (Equals(verification, null))
                throw new ArgumentNullException("Verification", "Valid verification is mandatory!");

            return new DataAccessLayer.Models.Verification(verification.Id, verification.UserId);
        }

    }
}
