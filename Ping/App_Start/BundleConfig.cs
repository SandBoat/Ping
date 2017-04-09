using System.Web.Optimization;

namespace Ping
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //common
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/css/reset.css"));

            //Search
            bundles.Add(new StyleBundle("~/bundles/search_css").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/bootstrap-datetimepicker.css",
                "~/Content/css/search-page.css"));
            bundles.Add(new ScriptBundle("~/bundles/search_js").Include(
                "~/Content/jquery/jquery-1.8.3.min.js",
                "~/Content/script/bootstrap.min.js",
                "~/Content/script/bootstrap-datetimepicker.js",
                "~/Content/script/bootstrap-datetimepicker.fr.js",
                "~/Content/script/map-show-up.js",
                "~/Content/script/search-page-map.js",
                "~/Content/script/search/search.js"));


            //bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            //    "~/Resources/JQuery/jquery-1.11.3.min.js"));
        }
    }
}