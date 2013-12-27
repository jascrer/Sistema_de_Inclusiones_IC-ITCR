using System.Web;
using System.Web.Mvc;

namespace ITCR.InclusionesTec
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}