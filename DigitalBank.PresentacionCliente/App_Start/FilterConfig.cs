using System.Web;
using System.Web.Mvc;

namespace DigitalBank.PresentacionCliente
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
