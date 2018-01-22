using Membership = Store.PresentationLayer.WebApplication.Security.CustomMembershipProvider;
using System.Web.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using System.Web.Security;
using Store.PresentationLayer.WebApplication.Models;
using Store.PresentationLayer.WebApplication.Security;
using Store.PresentationLayer.WebApplication.Models.ViewModels;
using Store.Utilities.Common.Helpers;
using System;

namespace Store.PresentationLayer.WebApplication.Controllers
{
    [CustomAuthorize]
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager = new UserManager();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.EmailAddress, model.Password))
                {
                    UserModel user = _userManager.GetByEmail(model.EmailAddress);
                    user.LastLogin = DateTime.Now;
                    _userManager.Save(user);
                    FormsAuthentication.SetAuthCookie(model.EmailAddress, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("IncorrectCredentials", "Incorrect username and/or password");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Account", null);
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel newUser = new UserModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    Password = Helpers.GetMD5Hash(model.Password),
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Picture = model.Picture,
                    LastLogin = DateTime.Now

                };
                _userManager.Add(newUser);
                return RedirectToAction("Login", "Account", null);
            }
            return View(model);
        }

        [CustomAuthorize]
        public ActionResult ManageAccount()
        {
            UserModel model = _userManager.GetById(Membership.CurrentUser().Id);
            return View(model);
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAccount(UserModel model)
        {
            ModelState.Remove("Password");
            if (!ModelState.IsValid)
            {
                TempData.Add("AccountError", "Oops, Something went wrong.");
                return RedirectToAction("ManageAccount", "Account");
            }

            UserModel newModel = _userManager.GetById(model.Id);
            model.Password = newModel.Password;

            _userManager.Save(model);

            TempData.Add("AccountSuccess", "Account saved successfully.");
            return RedirectToAction("ManageAccount", "Account");
        }

        [CustomAuthorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [CustomAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            UserModel user = _userManager.GetById(Membership.CurrentUser().Id);

            if (!ModelState.IsValid || user == null)
            {
                TempData.Add("PassError", "Oops, Something went wrong.");
                return RedirectToAction("ChangePassword", "Account");
            }

            if (Helpers.GetMD5Hash(model.OldPassword) != user.Password)
            {
                TempData.Add("PassError", "Old password wrong.");
                return RedirectToAction("ChangePassword", "Account");
            }

            user.Password = Helpers.GetMD5Hash(model.NewPassword);
            _userManager.Save(user);

            TempData.Add("PassSuccess", "Password changed successfully.");
            return RedirectToAction("ChangePassword", "Account");
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}