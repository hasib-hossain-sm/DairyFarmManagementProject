using System.Web;
using System.Web.Mvc;

namespace Dairy_Farm_Management_Project_3rd_try
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
