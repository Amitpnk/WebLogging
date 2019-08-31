using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLoggingUsingLog4net.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            try
            {
                Log.Debug("Log Debug Level");
                Log.Info("Log Info Level");
                Log.Warn("Log Warn Level");
                throw new NullReferenceException();
                //return View();
            }
            catch (Exception ex)
            {
                Log.Error("Log Error Level", ex);
                Log.Fatal("Log Fatal Level", ex);
                throw;
            }
        }
    }

}
