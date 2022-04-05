using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Leaveapplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_Error(object sender, EventArgs e)
        {
            string strErrorPage = "";

            Exception exLast = Server.GetLastError();
            Exception ex = Server.GetLastError().GetBaseException();

            var exCode = (exLast is HttpException) ? (exLast as HttpException).GetHttpCode() : 500;

            if (exCode == 404)
            {
                strErrorPage = "Error404";
            }
            else if (!exLast.Message.Contains("A potentially dangerous Request.Path"))
            {
                if (ex != null)
                {
                    new LogsBLL().InsertErrror(ex, Request.Url.ToString());
                    strErrorPage = "Error500";
                }
            }
            if (strErrorPage.Trim() != "")
            {
                var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                Response.Redirect(urlHelper.Action(strErrorPage, "Errors"));
            }
        }
    }
}
