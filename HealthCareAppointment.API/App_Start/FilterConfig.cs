using System.Web;
using System.Web.Mvc;
using HealthCareAppointment.HealthCare_Common;

namespace HealthCareAppointment.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Logactionexecutionfilter());
        }
    }
}
