using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PGRLF.MainWeb.App_Start.Bundles
{
    public class JQueryUI
    {

        public static Bundle Styles()
        {
            return new StyleBundle("~/Content/jqueryui/css").Include(
                       "~/Content/jquery-ui.css",
                       "~/Content/jquery-ui.structure.css",
                       "~/Content/jquery-ui.theme.css");
        }

        public static Bundle Scripts()
        {
            return new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui.js");
        }
    }
}