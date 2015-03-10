using System.Web;
using System.Web.Optimization;

namespace Ritual.Web.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ritual").Include(
                "~/Scripts/vendor/handlebars-v2.0.0.js",
                "~/Scripts/vendor/moment.js",
                "~/Scripts/vendor/date.format.js",
                "~/Scripts/vendor/handlebars-v2.0.0.js",
                "~/Scripts/ritual/ritual.templates.js",
                "~/Scripts/ritual/ritual.templates.utilities.js",
                "~/Scripts/ritual/ritual.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                        "~/Scripts/vendor/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendor/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/vendor/jquery-ui-1.11.2.min.js",
                        "~/Scripts/vendor/jquery-ui-timepicker-addon.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendor/bootstrap.js",
                      "~/Scripts/vendor/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jquery-ui-timepicker-addon.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                          "~/Content/themes/base/accordion.css",
                          "~/Content/themes/base/all.css",
                          "~/Content/themes/base/autocomplete.css",
                          "~/Content/themes/base/base.css",
                          "~/Content/themes/base/button.css",
                          "~/Content/themes/base/core.css",
                          "~/Content/themes/base/datepicker.css",
                          "~/Content/themes/base/dialog.css",
                          "~/Content/themes/base/draggable.css",
                          "~/Content/themes/base/menu.css",
                          "~/Content/themes/base/progressbar.css",
                          "~/Content/themes/base/resizable.css",
                          "~/Content/themes/base/selectable.css",
                          "~/Content/themes/base/selectmenu.css",
                          "~/Content/themes/base/slider.css",
                          "~/Content/themes/base/sortable.css",
                          "~/Content/themes/base/spinner.css",
                          "~/Content/themes/base/tabs.css",
                          "~/Content/themes/base/theme.css",
                          "~/Content/themes/base/tooltip.css"));

            bundles.Add(new StyleBundle("~/Content/foundation/css").Include(
                       "~/Content/foundation/foundation.css",
                       "~/Content/foundation/foundation.mvc.css",
                       "~/Content/foundation/app.css"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Scripts/foundation/foundation.min.js"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar/css").Include(
                      "~/Content/fullcalendar.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                      "~/Scripts/vendor/fullcalendar.min.js"));
        }
    }
}

