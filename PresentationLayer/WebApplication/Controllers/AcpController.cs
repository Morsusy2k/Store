using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.PresentationLayer.WebApplication.Models;
using Store.PresentationLayer.WebApplication.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Store.Utilities.Common.Constants;
using Membership = Store.PresentationLayer.WebApplication.Security.CustomMembershipProvider;

namespace Store.PresentationLayer.WebApplication.Controllers
{
    public class AcpController : Controller
    {
        private readonly ICategoryManager _categoryManager = new CategoryManager();
        private readonly IArticleManager _articleManager = new ArticleManager();
        private readonly ISettingsManager _settingsManager = new SettingsManager();

        [CustomAuthorize(Roles.Admin)]
        public ActionResult Index()
        {
            ViewBag.Page = "Acp";
            return View();
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult LoadManageCategories()
        {
            IEnumerable<CategoryModel> model = _categoryManager.GetAll().Select(x => (CategoryModel)x);
            return PartialView("Partial/_LoadManageCategories", model);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }

            CategoryModel cat = _categoryManager.Add(model);
            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Category ({cat.Id}) {cat.Name} created", Request.UserHostAddress);
            _settingsManager.AddLog(log);

            return RedirectToAction("Index", "Acp", new { render = "cat" });
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult SaveCategory(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }

            CategoryModel category = _categoryManager.GetById(model.Id);
            if (category == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            if (model.Name == category.Name)
            {
                return RedirectToAction("Index", "Acp", new { render = "cat" });
            }

            _categoryManager.Save(model);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Category ({model.Id}) updated {category.Name} > {model.Name}", Request.UserHostAddress);
            _settingsManager.AddLog(log);

            return RedirectToAction("Index", "Acp", new { render = "cat" });
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeleteCategory(int id)
        {
            CategoryModel category = _categoryManager.GetById(id);
            if (category == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            string name = category.Name;

            _categoryManager.Remove(category);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Category ({id}) {name} deleted", Request.UserHostAddress);
            _settingsManager.AddLog(log);

            return RedirectToAction("Index", "Acp", new { render = "cat" });
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult LoadManageSubCategories(string categoryId)
        {
            int id = Convert.ToInt32(categoryId);
            CategoryModel model = _categoryManager.GetById(id);

            if (model == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            return PartialView("Partial/_LoadManageSubCategories", model);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult AddSubCategory(SubCategoryModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }

            if (file != null)
            {
                if (file.ContentLength > 0 && (file.ContentType == "image/jpeg" || file.ContentType == "image/png"))
                {
                    model.Picture = new byte[file.ContentLength];
                    file.InputStream.Read(model.Picture, 0, file.ContentLength);
                }
            }

            SubCategoryModel sub = _categoryManager.AddSubCategory(model);
            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Subcategory ({sub.Id}) {sub.Name} created", Request.UserHostAddress);
            _settingsManager.AddLog(log);

            return RedirectToAction("Index", "Acp", new { render = "sub", catId = sub.CategoryId });
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult SaveSubCategory(SubCategoryModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }

            SubCategoryModel subcategory = _categoryManager.GetSubCategoryById(model.Id);
            if (subcategory == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            string logpic = "";

            if (file != null)
            {
                if (file.ContentLength > 0 && (file.ContentType == "image/jpeg" || file.ContentType == "image/png"))
                {
                    model.Picture = new byte[file.ContentLength];
                    file.InputStream.Read(model.Picture, 0, file.ContentLength);
                    logpic = " and picture";
                }
            }
            else
            {
                model.Picture = subcategory.Picture;
            }

            _categoryManager.SaveSubCategory(model);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"SubCategory ({model.Id}) updated {subcategory.Name} > {model.Name}{logpic}", Request.UserHostAddress);
            _settingsManager.AddLog(log);

            return RedirectToAction("Index", "Acp", new { render = "sub", catId = model.CategoryId });
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeleteSubCategory(int id)
        {
            SubCategoryModel subCategory = _categoryManager.GetSubCategoryById(id);

            if (subCategory == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            string name = subCategory.Name;

            _categoryManager.RemoveSubCategory(subCategory);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Subcategory ({id}) {name} deleted", Request.UserHostAddress);
            _settingsManager.AddLog(log);

            return RedirectToAction("Index", "Acp", new { render = "sub", catId = subCategory.CategoryId });
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult LoadNewArticles()
        {
            return PartialView("Partial/_PartialAddArticle");
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult AddArticle(ArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }
            model.UserId = Membership.CurrentUser().Id;
            ArticleModel article = _articleManager.Add(model);
            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Article ({article.Id}) {article.Name} created", Request.UserHostAddress);
            _settingsManager.AddLog(log);
            return RedirectToAction("Index", "Acp", new { render = "art"});
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult LoadManageArticles()
        {
            IEnumerable<ArticleModel> model = _articleManager.GetAll().Select(x => (ArticleModel)x);
            return PartialView("Partial/_LoadManageArticles", model);
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult LoadEditArticle(string articleId)
        {
            int id = Convert.ToInt32(articleId);
            ArticleModel model = _articleManager.GetById(id);

            if (model == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            return PartialView("Partial/_LoadEditArticle", model);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult SaveArticle(ArticleModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }

            ArticleModel article = _articleManager.GetById(model.Id);
            if (article == null)
            {
                return RedirectToAction("Index", "Acp");
            }

            _articleManager.Save(model);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Article ({model.Id}) updated", Request.UserHostAddress);
            _settingsManager.AddLog(log);
            return RedirectToAction("Index", "Acp", new { render = "art" });
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult LoadEditImages(string articleId)
        {
            int id = Convert.ToInt32(articleId);
           ArticleModel model = _articleManager.GetById(id);

            return PartialView("Partial/_LoadArticleImages", model);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        public ActionResult AddArticleImage(ArticleImageModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Acp");
            }

            if (file != null)
            {
                if (file.ContentLength > 0 && (file.ContentType == "image/jpeg" || file.ContentType == "image/png"))
                {
                    model.Picture = new byte[file.ContentLength];
                    file.InputStream.Read(model.Picture, 0, file.ContentLength);

                    model.UserId = Membership.CurrentUser().Id;
                    ArticleImageModel articleImage = _articleManager.AddImage(model);
                    LogModel log = new LogModel(Membership.CurrentUser().Id, $"Article image ({articleImage.Id}) created", Request.UserHostAddress);
                    _settingsManager.AddLog(log);
                    return RedirectToAction("Index", "Acp", new { render = "img", articleId = model.ArticleId });
                }
            }

            return RedirectToAction("Index", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult RemoveImage(string id)
        {
            int iid = Convert.ToInt32(id);
            ArticleImageModel image = _articleManager.GetImageById(iid);

            int aId = image.ArticleId;

            _articleManager.RemoveImage(image);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Article image ({iid}) removed", Request.UserHostAddress);
            _settingsManager.AddLog(log);
            return RedirectToAction("Index", "Acp", new { render = "img", articleId = aId });
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult RemoveArticle(string id)
        {
            int iid = Convert.ToInt32(id);
            ArticleModel article = _articleManager.GetById(iid);

            _articleManager.Remove(article);

            LogModel log = new LogModel(Membership.CurrentUser().Id, $"Article ({iid}) removed", Request.UserHostAddress);
            _settingsManager.AddLog(log);
            return RedirectToAction("Index", "Acp", new { render = "art"});
        }
    }
}