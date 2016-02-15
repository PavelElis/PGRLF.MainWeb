using System.Web;
using System.Web.Optimization;
using PGRLF.MainWeb.App_Start.Bundles;

namespace PGRLF.MainWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                 "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/formscripts").Include(
                 "~/Scripts/formscripts.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Site.css"));

            #region Foundation Bundles
            bundles.Add(Foundation.Styles());
            bundles.Add(Foundation.Scripts());
            #endregion

            #region jQuery UI Bundles
            bundles.Add(JQueryUI.Styles());
            bundles.Add(JQueryUI.Scripts());
            #endregion
        }
    }
}