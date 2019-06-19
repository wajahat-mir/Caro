using Caro.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caro.Controllers
{
    public class HomeController : Controller
    {
         public ActionResult Index()
        {
            return View();
        }

        [OutputCache(CacheProfile = "Cache1Hour")]
        public ActionResult About()
        {
            ViewBag.Message = "Hey! A Description";

            return View();
        }

        [OutputCache(CacheProfile = "Cache1Hour")]
        public ActionResult Contact()
        {
            ViewBag.Message = "How to find us!";

            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

    }
}