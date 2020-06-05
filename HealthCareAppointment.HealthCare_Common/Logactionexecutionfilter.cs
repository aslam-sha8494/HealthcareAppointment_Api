using System.Diagnostics;
using System.Web.Mvc;

namespace HealthCareAppointment.HealthCare_Common
{
    public class Logactionexecutionfilter : ActionFilterAttribute
    {
        Stopwatch watch;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Logactionexecutionfilter));
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch = new Stopwatch();
            watch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            watch.Stop();
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            Trace.WriteLine("ActionExecutionResultLogCapture : " + controllerName + "_" + actionName + "-Elapsed = " + watch.ElapsedMilliseconds + "ms");
            logger.Info("ActionExecutionResultLogCapture : " + controllerName + "_" + actionName + "-Elapsed = " + watch.ElapsedMilliseconds + "ms");
            logger.Debug("ActionExecutionResultLogCapture : " + controllerName + "_" + actionName + "-Elapsed = " + watch.ElapsedMilliseconds + "ms");
        }
    }
}