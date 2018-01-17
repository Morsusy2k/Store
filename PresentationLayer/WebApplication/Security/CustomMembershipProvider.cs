using Store.PresentationLayer.WebApplication.Models;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using System.Web;
using System.Web.Security;
using System;
using Store.Utilities.Common.Helpers;

namespace Store.PresentationLayer.WebApplication.Security
{
    public static class CustomMembershipProvider
    {
        private static readonly IUserManager _userManager = new UserManager();
        private static readonly IRoleManager _roleManager = new RoleManager();

        public static bool ValidateUser(string username, string password)
        {
            UserModel user = new UserModel();
            UserModel userObj = _userManager.GetByCredentials(username, Helpers.GetMD5Hash(password));
            if (userObj != null)
                return true;

            return false;
        }

        public static bool IsInRole(string[] roles)
        {
            UserModel user = CurrentUser();

            if (user != null)
            {
                foreach (RoleModel role in _roleManager.GetAllByUserId(user.Id))
                {
                    foreach (string paramRole in roles)
                    {
                        if (role.Name == paramRole)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static UserModel CurrentUser()
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var cookieValue = authCookie.Value;
                if (!String.IsNullOrWhiteSpace(cookieValue))
                {
                    string ticket = FormsAuthentication.Decrypt(cookieValue).Name.ToString();
                    return _userManager.GetByEmail(ticket);
                }
            }
            return null;
        }
    }
}