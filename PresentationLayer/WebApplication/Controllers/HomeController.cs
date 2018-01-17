using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingsManager _settingsManager = new SettingsManager();

        public ActionResult Index()
        {
            ViewBag.Title = _settingsManager.GetSettingsByKey("Title").Value;
            ViewBag.Page = "Home";

            return View();
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
    }
}