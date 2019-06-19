using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caro.Filters
{
    public class LogErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Log(filterContext.Exception);

            base.OnException(filterContext);
        }

        private void Log(Exception exception)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info(exception.Source + exception.Message + exception.StackTrace);
        }
    }
}