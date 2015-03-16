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
                        "~/Content/js/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ritual").Include(
                "~/Content/js/vendor/handlebars-v2.0.0.js",
                "~/Content/js/vendor/moment.js",
                "~/Content/js/vendor/jquery.newsTicker.min.js",
                "~/Content/js/vendor/croppic.min.js",
                "~/Content/js/vendor/date.format.js",
                "~/Content/js/vendor/handlebars-v2.0.0.js",
                "~/Content/js/ritual/ritual.templates.js",
                "~/Content/js/ritual/ritual.templates.utilities.js",
                "~/Content/js/ritual/ritual.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                        "~/Content/js/vendor/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/vendor/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/vendor/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Content/js/vendor/jquery-ui-1.11.2.min.js",
                        "~/Content/js/vendor/jquery-ui-timepicker-addon.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/vendor/bootstrap.js",
                      "~/Content/js/vendor/respond.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                          "~/Content/css/themes/base/accordion.css",
                          "~/Content/css/themes/base/all.css",
                          "~/Content/css/themes/base/autocomplete.css",
                          "~/Content/css/themes/base/base.css",
                          "~/Content/css/themes/base/button.css",
                          "~/Content/css/themes/base/core.css",
                          "~/Content/css/themes/base/datepicker.css",
                          "~/Content/css/themes/base/dialog.css",
                          "~/Content/css/themes/base/draggable.css",
                          "~/Content/css/themes/base/menu.css",
                          "~/Content/css/themes/base/progressbar.css",
                          "~/Content/css/themes/base/resizable.css",
                          "~/Content/css/themes/base/selectable.css",
                          "~/Content/css/themes/base/selectmenu.css",
                          "~/Content/css/themes/base/slider.css",
                          "~/Content/css/themes/base/sortable.css",
                          "~/Content/css/themes/base/spinner.css",
                          "~/Content/css/themes/base/tabs.css",
                          "~/Content/css/themes/base/theme.css",
                          "~/Content/css/themes/base/tooltip.css"));

            bundles.Add(new StyleBundle("~/Content/foundation/css").Include(
                       "~/Content/css/foundation/foundation.css",
                       "~/Content/css/foundation/foundation.mvc.css",
                       "~/Content/css/foundation/app.css"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Content/js/foundation/foundation.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/avatar").Include(
                      "~/Content/js/ritual/ritual.avatar.js"));

            bundles.Add(new ScriptBundle("~/bundles/jcrop").Include(
                      "~/Content/js/vendor/jquery.Jcrop.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryform").Include(
                      "~/Content/js/vendor/jquery.form.js"));

            bundles.Add(new StyleBundle("~/Content/fullcalendar").Include(
                      "~/Content/css/fullcalendar.min.css",
                      "~/Content/css/fullcalendar.print.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                      "~/Content/js/vendor/fullcalendar.min.js"));


            bundles.Add(new StyleBundle("~/Content/jcrop").Include(
                      "~/Content/css/jquery.Jcrop.css"));

            bundles.Add(new StyleBundle("~/Content/avatar").Include(
                      "~/Content/css/ritual.avatar.css"));
        }
    }
}
