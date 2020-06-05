using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace HealthCareAppointment.HealthCare_Common
{
    public class HealthCareAppointmentCaching_Filter : ActionFilterAttribute
    {
        public int TimeDuration { get; set; }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(TimeDuration),
                MustRevalidate = true,
                Public = true
            };
        }
    }
}