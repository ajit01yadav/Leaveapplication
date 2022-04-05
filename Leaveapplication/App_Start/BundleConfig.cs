using System.Web;
using System.Web.Optimization;

namespace Leaveapplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Validation").Include(
                        "~/Assets/Js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/PluginJS").Include(
                         "~/Assets/Js/jquery-ui-1.10.4.custom.min.js",
                         "~/Assets/Js/bootstrap.min.js",
                         "~/Assets/Js/moment.js",
                         "~/Assets/Js/sb-admin.js",
                         "~/Assets/Js/jquery.metisMenu.js",
                         "~/Assets/Js/bootstrap-datepicker.js",
                         "~/Assets/Js/bootstrap-datetimepicker.min.js",
                         "~/Assets/Js/bootstrap-multiselect.js",
                         "~/Assets/Js/select2.min.js",
                         "~/Assets/Js/globel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/Js/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/PluginJqueryUI").Include(
                  "~/Assets/Js/jquery-ui.min.js"
              ));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                "~/Assets/Js/respond.js"
            ));

            bundles.Add(new StyleBundle("~/PluginCss").Include(
                      "~/Assets/Css/bootstrap.min.css",
                      "~/Assets/Css/dataTables.bootstrap.css",
                      "~/Assets/Css/sb-admin.css",
                      "~/Assets/Css/datepicker.css",
                      "~/Assets/Css/bootstrap-datetimepicker.css",
                      "~/Assets/Css/jquery-ui-1.8.16.custom.css",
                      "~/Assets/Css/bootstrap-multiselect.css",
                      "~/Assets/Css/select2.min.css",
                      "~/Assets/Css/unlock.css"));
        }
    }
}
