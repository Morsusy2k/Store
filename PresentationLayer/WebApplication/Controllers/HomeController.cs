using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using Store.PresentationLayer.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Utilities.Common.Helpers;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsManager _settingsManager = new SettingsManager();
        private readonly IArticleManager _articleManager = new ArticleManager();
        private readonly ICategoryManager _categoryManager = new CategoryManager();

        public ActionResult Index()
        {
            ViewBag.Title = _settingsManager.GetSettingsByKey("Title").Value;
            ViewBag.Page = "Home";

            IEnumerable<ArticleModel> model = _articleManager.GetAll().Select(x => (ArticleModel)x);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Page = "About";
            ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Page = "Contact";
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Category(int id)
        {
            ViewBag.Page = "Category";
            SubCategoryModel sub = _categoryManager.GetSubCategoryById(id);
            if(sub == null)
            {
                return RedirectToAction("Index","Home");
            }

            IEnumerable<ArticleModel> model = _articleManager.GetAllBySubCategoryId(sub.Id).Select(x => (ArticleModel)x);
            if (!Helpers.IsAny(model))
            {
                return RedirectToAction("Index","Home");
            }

            return View(model);
        }
    }
}