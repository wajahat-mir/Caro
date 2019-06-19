using Caro.Filters;
using System.Web;
using System.Web.Mvc;

namespace Caro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomRequireHttpsFilter());
            filters.Add(new LogErrorHandler());
            filters.Add(new LocalizeFilter());
        }
    }
}
