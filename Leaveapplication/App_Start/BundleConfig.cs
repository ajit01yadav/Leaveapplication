using System.Web;
using System.Web.Optimization;

namespace Leaveapplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/content/css").Include(
              "~/Assets/css/bootstrap.css",
              "~/Assets/css/animate.min.css",
              "~/Assets/css/bootstrap-datepicker.css",
              "~/Assets/css/flaticon.css",
              "~/Assets/css/unlock.css",
              "~/Assets/css/font-awesome.css"
              ));

            bundles.Add(new ScriptBundle("~/script/js").Include(
                "~/Assets/js/jquery-1.10.2.js",
                "~/Assets/js/jquery.validate.js",
                "~/Assets/js/jquery.validate.unobtrusive.js",
                "~/Assets/js/modernizr-2.6.2.js",
                "~/Assets/js/popper.js",
                "~/Assets/js/bootstrap.js",
                "~/Assets/js/bootstrap-datepicker.js",
                "~/Assets/js/script.js"
            ));
        }
    }
}
