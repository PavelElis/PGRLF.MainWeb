using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PGRLF.MainWeb.App_Start.Bundles
{
    public class Foundation
    {

        public static Bundle Styles()
        {
            return new StyleBundle("~/Content/foundation/css").Include(
                "~/Content/foundation/app.css",
                "~/Content/foundation/foundation-flex.css",
                "~/Content/foundation/foundation-icons.css"
                );
        }

        public static Bundle Scripts()
        {
            return new ScriptBundle("~/bundles/foundation").Include(
                //"~/Scripts/foundation/vendor/jquery.min.js",
                //"~/Scripts/foundation/vendor/what-input.min.js",
                "~/Scripts/foundation/app.js",
                "~/Scripts/foundation/foundation.js"
                );
        }
    }
}