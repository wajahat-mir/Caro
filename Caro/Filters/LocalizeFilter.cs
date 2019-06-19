using Caro.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Caro.Filters
{
    public class LocalizeFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            string cultureName = null;

            HttpCookie cultureCookie = filterContext.RequestContext.HttpContext.Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = filterContext.RequestContext.HttpContext.Request.UserLanguages != null && filterContext.RequestContext.HttpContext.Request.UserLanguages.Length > 0 ?
                        filterContext.RequestContext.HttpContext.Request.UserLanguages[0] :
                        null;

            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}